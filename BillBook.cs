using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace BillBook
{
    public partial class BillBook : Form
    {
        DatabaseOperations databaseOperations = null;
        ProductList productList = null;
        CustomerList customerList = null;
        public BillBook()
        {
            InitializeComponent();
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
    }
}
