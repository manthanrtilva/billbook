using System;
using System.Linq;
using System.Windows.Forms;

namespace BillBook
{
    public partial class Product : Form
    {
        private DatabaseOps databaseOps = null;
        private bool update = false;
        private int hiddenId = 0;
        public Product(DatabaseOps databaseOps,bool update)
        {
            InitializeComponent();
            this.databaseOps = databaseOps;
            this.update = update;
            priceNumericUpDown.Maximum = decimal.MaxValue;

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text.Count() == 0)
            {
                MessageBox.Show("Product name is empty");
            }
            else if(!update)
            {
                databaseOps.AddProduct(nameTextBox.Text, priceNumericUpDown.Value, gstNumericUpDown.Value, quantityNmericUpDown.Value);
            } else
            {
                databaseOps.UpdateProduct(hiddenId, nameTextBox.Text, priceNumericUpDown.Value, gstNumericUpDown.Value, quantityNmericUpDown.Value);
            }
            nameTextBox.Text = "";
            priceNumericUpDown.Value = 0;
            gstNumericUpDown.Value = 0; 
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
            priceNumericUpDown.Value = 0;
            gstNumericUpDown.Value = 0;
            Close();
        }

        internal DialogResult ShowMyDialog(int id, string name, decimal price, decimal gst, decimal quantity)
        {
            if (update)
            {
                hiddenId = id;
                nameTextBox.Text = name;
                priceNumericUpDown.Value = price;
                gstNumericUpDown.Value = gst;
            }
            return ShowDialog();
        }

        private void Product_Load(object sender, EventArgs e)
        {

        }
    }
}
