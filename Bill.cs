using BillBook.Properties;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BillBook
{
    public partial class Bill : UserControl
    {
        ProductSelectForm productSelectForm;
        DatabaseOperations databaseOperations;
        Customer customer = new Customer(1,string.Empty,string.Empty,string.Empty,string.Empty,string.Empty);
        BillData billData = new BillData();
        private int id;

        public Bill(DatabaseOperations databaseOperations)
        {
            InitializeComponent();
            this.databaseOperations = databaseOperations;
            productSelectForm = new ProductSelectForm(databaseOperations.GetAllProductName().ToArray());
            productSelectForm.selected += Product_selected;
            paymentComboBox.SelectedIndex = 0;
            phoneTextBox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            phoneTextBox.AutoCompleteCustomSource.AddRange(databaseOperations.GetAllCustomerPhone().ToArray());
            phoneTextBox.KeyDown += phoneTextBox_KeyDown;
            phoneTextBox.KeyPress += phoneTextBox_KeyPress;
        }

        public Bill(DatabaseOperations databaseOperations, int id)
        {
            InitializeComponent();
            this.id = id;
            addButton.Enabled = false;
            saveButton.Enabled = false;
            nameTextBox.Enabled = false;
            addressTextBox.Enabled = false;
            phoneTextBox.Enabled = false;
            gstTextBox.Enabled = false;
            var (billData,customer,status) = databaseOperations.GetBillData(id);
            nameTextBox.Text = customer.Name;
            addressTextBox.Text = customer.Address;
            phoneTextBox.Text = customer.Phone;
            gstTextBox.Text = customer.Gst;
            paymentComboBox.Text = status;
            billData.GetItems().ForEach(item =>
            {
                dataGridView1.Rows.Add(item.Name, item.Price, item.Gst, item.Quantity, item.Total);
            });
            items.Text = billData.ItemCount.ToString();
            amounts.Text = billData.GrandTotal.ToString();
        }

        private void Product_selected(object sender, ProductSelectArgs e)
        {
            var p = databaseOperations.GetProducts(name: e.name, like: false);

            if (p.Count == 0)
            {
                MessageBox.Show("No product Found");
            }
            else if(p.Count > 1)
            {
                MessageBox.Show("Many Product Found:"+ p.Count);
            }
            else
            {
                var amount = e.quantity * (((100 + p[0].Gst) / 100) * p[0].Price);
                var (item,update,index) = billData.AddItem(p[0].Id, p[0].Name, p[0].Price, p[0].Gst, e.quantity, dataGridView1.Rows.Count);
                if (update)
                {
                    dataGridView1.Rows.RemoveAt(index);
                    dataGridView1.Rows.Add(item.Name, item.Price, item.Gst, item.Quantity, item.Total);
                    item.Index = dataGridView1.Rows.Count-1;
                }
                else
                {
                    dataGridView1.Rows.Add(item.Name, item.Price, item.Gst, item.Quantity, item.Total);
                }
                items.Text = billData.ItemCount.ToString();
                amounts.Text = billData.GrandTotal.ToString();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            productSelectForm.ShowDialog();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            addButton.Enabled = false;
            if(customer.Id == 1)
            {
                if ( nameTextBox.Text.Trim().Length > 0 
                    || phoneTextBox.Text.Trim().Length > 0
                    || gstTextBox.Text.Trim().Length > 0 )
                {
                    customer = databaseOperations.AddCustomer(
                        nameTextBox.Text.Trim().ToUpper(),
                        addressTextBox.Text.Trim().ToUpper(),
                        phoneTextBox.Text.Trim().ToUpper(),
                        gstTextBox.Text.Trim().ToUpper()
                        );
                }
            }
            databaseOperations.SaveBill(ref billData, ref customer, paymentComboBox.Text);
            saveButton.Enabled = false;
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            //var print = new PrintForm();
            var bill = BillHTML();
            var defaultBrowserPath  = GetDefaultBrowserPath(GetDefaultBrowserId());
            var fileUri = System.IO.Directory.GetCurrentDirectory()+"\\bill.html";
            File.WriteAllText(fileUri, bill);
            Process.Start(defaultBrowserPath.FullName, fileUri);
        }
        private string BillHTML()
        {
            var resourceName = "BillBook.Resources.BillTemplate.html";
            //foreach (var item in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            //{
            //    Debug.WriteLine(item);
            //}
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string replace = string.Empty;
                    billData.GetItems().ForEach(x =>
                    {
                        decimal total = x.Quantity * (((100 + x.Gst) / 100) * x.Price);
                        replace += "<tr>";
                        replace += string.Format("<td style=\"text-align: end; width: 5%;\">{0}</td>",x.Index+1);
                        replace += string.Format("<td>{0}</td>", x.Name);
                        replace += string.Format("<td style=\"text-align: end; width: 10%;\">{0}</td>", x.Price);
                        replace += string.Format("<td style=\"text-align: end; width: 5%;\">{0}</td>", x.Quantity);
                        replace += string.Format("<td style=\"text-align: end; width: 5%;\">{0}</td>", x.Gst);
                        replace += string.Format("<td style=\"text-align: end; width: 10%;\">{0}</td>", x.Total);
                        replace += "</tr>";
                    });
                    replace += string.Format("<tr><td colspan=\"5\" style=\"font-weight: bold;\">Grand Total</td><td style=\"font-weight: bold;\">{0}</td></tr>", billData.GrandTotal);
                    var template = reader.ReadToEnd();
                    string pattern = @"\brows\b";
                    string result = Regex.Replace(template, pattern, replace);
                    return result;
                }
            }
        }

        private void customerGroupBox_Enter(object sender, EventArgs e)
        {

        }
        private string GetDefaultBrowserId()
        {
            const string userChoice = @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice";
            string progId;
            //BrowserApplication browser;
            using (RegistryKey userChoiceKey = Registry.CurrentUser.OpenSubKey(userChoice))
            {
                if (userChoiceKey == null)
                {
                    throw new NotSupportedException("No standard browser id found in registry");
                    //break;
                }
                object progIdValue = userChoiceKey.GetValue("Progid");
                if (progIdValue == null)
                {
                    throw new NotSupportedException("No standard browser id found in registry");
                    //break;
                }
                progId = progIdValue.ToString();
                return progId;
            }
        }
        private FileInfo GetDefaultBrowserPath(string defaultBrwoserId)
        {
            const string exeSuffix = ".exe";
            string path = defaultBrwoserId + @"\shell\open\command";
            FileInfo browserPath = null;
            using (RegistryKey pathKey = Registry.ClassesRoot.OpenSubKey(path))
            {
                if (pathKey == null)
                {
                    throw new NotSupportedException("Standard browser not properly registred in registry!");
                    //return;
                }

                // Trim parameters.
                try
                {
                    path = pathKey.GetValue(null).ToString().ToLower().Replace("\"", "");
                    if (!path.EndsWith(exeSuffix))
                    {
                        path = path.Substring(0, path.LastIndexOf(exeSuffix, StringComparison.Ordinal) + exeSuffix.Length);
                        browserPath = new FileInfo(path);
                    }
                }
                catch
                {
                    // Assume the registry value is set incorrectly, or some funky browser is used which currently is unknown.
                    throw new NotSupportedException("Standard browser not properly registred in registry!");
                }
            }

            return browserPath;

        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void phoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) && phoneTextBox.Text.Count() < 10) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void phoneTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                System.Diagnostics.Debug.WriteLine("Enter pressed:" + phoneTextBox.Text);
                var customers = databaseOperations.GetCustomers(phone: phoneTextBox.Text);
                var item = customers.Find(c => c.Phone == phoneTextBox.Text);
                if (item != null)
                {
                    addressTextBox.Text = item.Address;
                    gstTextBox.Text = item.Gst;
                    nameTextBox.Text = item.Name;
                    System.Diagnostics.Debug.WriteLine("Using Name:" + item.Name);
                    customer = item;
                }
            }
        }
    }
}
