using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BillBook
{
    public partial class MasterBill : UserControl
    {
        internal class UBillItem
        {
            public Label name = new Label();
            public Label unit = new Label();
            public Label unitprice = new Label();
            public Label gst = new Label();
            public Label total = new Label();
            public Button delete = new Button();
            public int pId { get; set; } = 0;
        };
        private List<DCustomer> filteredCust = new List<DCustomer>();
        private DCustomer selectedCust = new DCustomer(1, "", "", "", "", "");
        private DatabaseOps databaseOps;
        private SelectBillItem selectedBillItem = null;
        private decimal totalCount = 0;
        private decimal itemsCount = 0;
        private List<DBillItem> items = new List<DBillItem>();
        private List<UBillItem> uitems = new List<UBillItem>();
        public MasterBill(DatabaseOps databaseOps, string[] productNames, string[] customerNumbers)
        {
            InitializeComponent();
            this.databaseOps = databaseOps;
            phoneTextBox.KeyDown += phoneTextBox_KeyDown;
            phoneTextBox.KeyPress += phoneTextBox_KeyPress;
            phoneTextBox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            phoneTextBox.AutoCompleteCustomSource.AddRange(customerNumbers);
            selectedBillItem = new SelectBillItem(productNames);
            selectedBillItem.ItemAdded += SelectedBillItem_ItemAdded;
            tableLayoutPanel1.ColumnStyles.Clear();
            paystatusComboBox.SelectedIndex = 0;
            for(var i=0;i< tableLayoutPanel1.ColumnCount;i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            }
            printButton.Enabled = true;
        }

        private void SelectedBillItem_ItemAdded(object sender, ItemAddedEventArgs e)
        {
            var items = databaseOps.GetProducts(name: e.Name);
            if(items.Count() > 1)
            {
                MessageBox.Show("Multiple product with Name : "+e.Name);
            } else if (items.Count() == 0)
            {
                MessageBox.Show("No product found with Name : "+e.Name);
            }
            else
            {
                addRow(items[0],e.Quantity);
            }
        }

        private void addRow(DProduct dProduct, decimal quantity)
        {
            saveButton.Enabled = true;
            tableLayoutPanel1.RowCount += 1;
            var billitem = new DBillItem();
            var ubillitem = new UBillItem();
            billitem.pID = dProduct.ID;
            billitem.quantity = quantity;
            billitem.pName = dProduct.Name;
            billitem.price = dProduct.Price;
            billitem.gst = dProduct.GST;

            ubillitem.name.Text = billitem.pName;

            ubillitem.unit.Text = billitem.quantity.ToString();

            ubillitem.unitprice.Text = billitem.price.ToString();

            ubillitem.gst.Text = dProduct.GST.ToString();

            ubillitem.total.Text = (billitem.quantity * billitem.price).ToString();

            ubillitem.delete.Text = "Remove";
            ubillitem.delete.Click += (sender, e) => { DeleteItemFromBill(sender, e, dProduct.ID); };
            ubillitem.pId = dProduct.ID;
            itemsCount += billitem.quantity;
            totalCount += billitem.quantity * billitem.price;
            itemsLabel.Text = itemsCount.ToString();
            totalLabel.Text = totalCount.ToString();
            items.Add(billitem);
            uitems.Add(ubillitem);

            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.Controls.Add(ubillitem.name, 0, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.Add(ubillitem.unit, 1, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.Add(ubillitem.unitprice, 2, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.Add(ubillitem.gst, 3, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.Add(ubillitem.total, 4, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.Controls.Add(ubillitem.delete, 5, tableLayoutPanel1.RowCount - 1);
            tableLayoutPanel1.ResumeLayout(true);
        }

        private void DeleteItemFromBill(object sender, EventArgs e, int iD)
        {
            var ui = uitems.FindIndex(i => i.pId == iD);
            if (ui == -1)
            {
                MessageBox.Show("Can't find Item to delete");
            }
            else
            {
                tableLayoutPanel1.SuspendLayout();
                tableLayoutPanel1.Controls.Remove(uitems[ui].name);
                tableLayoutPanel1.Controls.Remove(uitems[ui].unit);
                tableLayoutPanel1.Controls.Remove(uitems[ui].unitprice);
                tableLayoutPanel1.Controls.Remove(uitems[ui].gst);
                tableLayoutPanel1.Controls.Remove(uitems[ui].total);
                tableLayoutPanel1.Controls.Remove(uitems[ui].delete);
                tableLayoutPanel1.ResumeLayout(true);
                var bi = items.FindIndex(i => i.pID == iD);
                var billitem = items[bi];
                itemsCount -= billitem.quantity;
                totalCount -= billitem.quantity * billitem.price;
                itemsLabel.Text = itemsCount.ToString();
                totalLabel.Text = totalCount.ToString();
                uitems.RemoveAt(ui);
                items.RemoveAt(bi);
                if(itemsCount == 0)
                {
                    saveButton.Enabled = false;
                }
            }

        }

        private void phoneTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) && phoneTextBox.Text.Count() < 10)|| e.KeyChar == (char)Keys.Back )
            {
                e.Handled = false;
            } else
            {
                e.Handled = true;
            }
        }

        private void phoneTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                System.Diagnostics.Debug.WriteLine("Enter pressed:" + phoneTextBox.Text);
                var customers = databaseOps.GetCustomers(phone:phoneTextBox.Text);
                var item = customers.Find(c => c.Phone == phoneTextBox.Text);
                if (item != null)
                {
                    cEMailTextBox.Text = item.Email;
                    cAddressTextBox.Text = item.Address;
                    cGSTTextBox.Text = item.GST;
                    cNameTextBox.Text = item.Name;
                    System.Diagnostics.Debug.WriteLine("Using Name:" + item.Name);
                    selectedCust = item;
                }
                else
                {
                    cNameTextBox.Text = string.Empty;
                    cEMailTextBox.Text = string.Empty;
                    cAddressTextBox.Text = string.Empty;
                    cGSTTextBox.Text = string.Empty;
                    System.Diagnostics.Debug.WriteLine("No item with:" + phoneTextBox.Text);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            selectedBillItem.ShowDialog();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(items.Count() > 0)
            {
                databaseOps.AddBill(ref selectedCust, ref items, paystatusComboBox.Text);
                addButton.Enabled = false;
                saveButton.Enabled = false;
                printButton.Enabled = true;
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            var invoice = new Invoice();
            invoice.AddBillData(ref selectedCust, ref items);
            invoice.ShowDialog();
        }
    }
}
