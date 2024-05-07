using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace BillBook
{
    public partial class BillBook : Form
    {
        //private List<DProduct> products = new List<DProduct>();
        private string[] productNames = null;
        private string[] customerNumbers = null;
        public BillBook()
        {
            InitializeComponent();
            productForm = new Product(databaseOps: databaseOps, false);
            customerForm = new Customer(databaseOps: databaseOps, false);
            var products = databaseOps.GetProducts();
            productNames = products.Select(p => p.Name).ToArray();
            var customers = databaseOps.GetCustomers();
            customerNumbers = customers.Select(p => p.Phone).ToArray();
            KeyDown += Invoice_KeyDown;
        }
        private void Invoice_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("hello1");
            if (e.KeyCode == Keys.P)
            {
                Debug.WriteLine("hello2");
                MessageBox.Show("Hello");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void masterBill1_Load(object sender, EventArgs e)
        {

        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (productForm.ShowDialog() == DialogResult.OK)
            {
                var products = databaseOps.GetProducts();
                productNames = products.Select(p => p.Name).ToArray();
            }
        }
        private DatabaseOps databaseOps = new DatabaseOps();
        private Product productForm =null;
        private Customer customerForm = null;

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            while(Controls.Count > 1)
            {
                Controls.RemoveAt(Controls.Count - 1);
            }
            //var products = new ProductList(databaseOps);
            //products.Location = new System.Drawing.Point(0, 29);
            //Controls.Add(products); 
            var products = new ProductList2(databaseOps);
            products.Location = new System.Drawing.Point(0, 29);
            Controls.Add(products);
        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (Controls.Count > 1)
            {
                Controls.RemoveAt(Controls.Count - 1);
            }
            var bill = new MasterBill(databaseOps, productNames, customerNumbers);
            bill.Location = new System.Drawing.Point(0, 29);
            Controls.Add(bill);
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            while (Controls.Count > 1)
            {
                Controls.RemoveAt(Controls.Count - 1);
            }
            var customers = new CustomerList2(databaseOps);
            customers.Location = new System.Drawing.Point(0, 29);
            Controls.Add(customers);
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(customerForm.ShowDialog() == DialogResult.OK)
            {
                var customers = databaseOps.GetCustomers();
                customerNumbers = customers.Select(p => p.Phone).ToArray();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
