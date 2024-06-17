using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace BillBook
{
    public partial class BillBook : Form
    {
        DatabaseOperations databaseOperations = null;
        ProductList productList = null;
        CustomerList customerList = null;
        BillList billList = null;
        public BillBook()
        {
            InitializeComponent();
            HelperRegistry.SetBrowserEmulationVersion(BrowserEmulationVersion.Version11Edge);
        }

        private void BillBook_Load(object sender, EventArgs e)
        {
            const string dbPath = "BillBook.mdb";
            if (!File.Exists(dbPath))
            {
                using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("BillBook.Resources.BillBook.mdb"))
                {
                    using (var file = new FileStream(dbPath, FileMode.Create, FileAccess.Write))
                    {
                        resource.CopyTo(file);
                    }
                }
            }
            databaseOperations = new DatabaseOperations();
            productList = new ProductList(databaseOperations);
            customerList = new CustomerList(databaseOperations);
            billList = new BillList(databaseOperations);
            billList.viewBill += BillList_viewBill;
            if (ConfigurationManager.AppSettings == null || ConfigurationManager.AppSettings["GSTNO"] == null  || ConfigurationManager.AppSettings["GSTNO"].Count() == 0)
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");
                appSettings.Settings.Add("GSTNO", "<YOUR_GST_NUMBER>111");
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            }
            if (ConfigurationManager.AppSettings == null || ConfigurationManager.AppSettings["PANNO"] == null || ConfigurationManager.AppSettings["PANNO"].Count() == 0)
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");
                appSettings.Settings.Add("PANNO", "<YOUR_GST_NUMBER>1113");
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            }
            if (ConfigurationManager.AppSettings == null || ConfigurationManager.AppSettings["STATECODE"] == null || ConfigurationManager.AppSettings["STATECODE"].Count() == 0)
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");
                appSettings.Settings.Add("STATECODE", "<YOUR_GST_NUMBER>1112");
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            }
        }

        private void BillList_viewBill(object sender, ViewBillArgs e)
        {
            var bill = new Bill(databaseOperations, e.Id);
            while (Controls.Count > 1)
            {
                Controls.RemoveAt(Controls.Count - 1);
            }
            bill.Location = new System.Drawing.Point(0, 29);
            Controls.Add(bill);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var product = new ProductForm(databaseOperations);
            product.ShowDialog();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while(Controls.Count > 1) 
            {
                Controls.RemoveAt(Controls.Count - 1);
            }
            productList.Location = new System.Drawing.Point(0, 29);
            productList.LoadData();
            Controls.Add(productList);
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (Controls.Count > 1)
            {
                Controls.RemoveAt(Controls.Count - 1);
            }
            customerList.Location = new System.Drawing.Point(0, 29);
            customerList.LoadData();
            Controls.Add(customerList);
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var customer = new CustomerForm(databaseOperations);
            customer.ShowDialog();

        }

        private void newBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bill = new Bill(databaseOperations);
            while (Controls.Count > 1)
            {
                Controls.RemoveAt(Controls.Count - 1);
            }
            bill.Location = new System.Drawing.Point(0, 29);
            Controls.Add(bill);
        }

        private void bilsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (Controls.Count > 1)
            {
                Controls.RemoveAt(Controls.Count - 1);
            }
            billList.Location = new System.Drawing.Point(0, 29);
            billList.LoadData();
            Controls.Add(billList);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var setting = new SellerSettings();
            setting.Show();
        }
    }
}
