using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace BillBook
{
    public partial class ProductForm : Form
    {
        DatabaseOperations databaseOperations = null;
        public event EventHandler<ProductUpdatedArgs> updated;
        int updateid = 0;
        int rowid = 0;
        public ProductForm(DatabaseOperations databaseOperations)
        {
            InitializeComponent();
            this.databaseOperations = databaseOperations;
            priceNumericUpDown.Maximum = decimal.MaxValue;
            quantityNumericUpDown.Maximum = decimal.MaxValue;
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("save");
            if (nameTextBox.Text.Trim().Count() == 0)
            {
                MessageBox.Show("Name is empty");
                Close();
                return;
            }
            if(updateid == 0)
            {
                databaseOperations.AddProduct(nameTextBox.Text.Trim().ToUpper(), priceNumericUpDown.Value, gstNumericUpDown.Value, quantityNumericUpDown.Value);

            }
            else
            {
                databaseOperations.UpdateProduct(updateid, nameTextBox.Text.Trim().ToUpper(), priceNumericUpDown.Value, gstNumericUpDown.Value, quantityNumericUpDown.Value);
                EventHandler<ProductUpdatedArgs> handler = updated;
                if (handler != null)
                {
                    handler(this, new ProductUpdatedArgs(rowid, updateid, nameTextBox.Text.Trim().ToUpper(), priceNumericUpDown.Value, gstNumericUpDown.Value, quantityNumericUpDown.Value));
                }

            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("cancel");
            Close();
        }

        internal DialogResult ShowMyDialog(int rowid, int id, string name, int price, int gst, int quaintity)
        {
            this.rowid = rowid;
            updateid = id;
            nameTextBox.Text = name;
            priceNumericUpDown.Value = price;
            gstNumericUpDown.Value = gst;
            quantityNumericUpDown.Value = quaintity;
            return ShowDialog();
        }
    }
    public class ProductUpdatedArgs : EventArgs
    {
        public ProductUpdatedArgs(int rowid, int id, string name, decimal price, decimal gst, decimal quantity)
        {
            Rowid   = rowid;
            Id = id;
            Name = name;
            Price = price;
            Gst = gst;
            Quantity = quantity;
        }
        public int Rowid { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Gst { get; set; }
        public decimal Quantity { get; set; }
    }
}
