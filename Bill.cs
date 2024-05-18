using System;
using System.Windows.Forms;

namespace BillBook
{
    public partial class Bill : UserControl
    {
        ProductSelectForm productSelectForm;
        DatabaseOperations databaseOperations;
        decimal billItems = 0;
        decimal billAmount = 0;
        public Bill(DatabaseOperations databaseOperations)
        {
            InitializeComponent();
            this.databaseOperations = databaseOperations;
            productSelectForm = new ProductSelectForm(databaseOperations.GetAllProductName().ToArray());
            productSelectForm.selected += Product_selected;
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
                dataGridView1.Rows.Add(p[0].Name, p[0].Price, p[0].Gst, e.quantity,amount);
                billItems += e.quantity;
                billAmount += amount;
                items.Text = billItems.ToString();
                amounts.Text = billAmount.ToString();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            productSelectForm.ShowDialog();
        }
    }
}
