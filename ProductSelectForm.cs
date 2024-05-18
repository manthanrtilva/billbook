using System;
using System.Windows.Forms;

namespace BillBook
{
    public partial class ProductSelectForm : Form
    {
        public event EventHandler<ProductSelectArgs> selected;
        public ProductSelectForm(string[] items)
        {
            InitializeComponent();
            quantityNumericUpDown.Maximum = decimal.MaxValue;
            nameComboBox.Items.AddRange(items);
            nameComboBox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            nameComboBox.AutoCompleteCustomSource.AddRange(items);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            EventHandler<ProductSelectArgs> handler = selected;
            if (handler != null)
            {
                handler(this, new ProductSelectArgs(nameComboBox.Text,quantityNumericUpDown.Value));
            }
            Close();
        }

        private void ProductSelectForm_Load(object sender, EventArgs e)
        {

        }

        private void nameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public new DialogResult ShowDialog()
        {
            nameComboBox.Focus();
            nameComboBox.SelectedIndex = 0;
            quantityNumericUpDown.Value = 1;
            ActiveControl = nameComboBox;
            return base.ShowDialog();
        }
    }
    public class ProductSelectArgs : EventArgs
    {
        public string name { get; private set; }
        public decimal quantity { get; private set; }
        public ProductSelectArgs(string name, decimal quantity)
        {
            this.name = name;
            this.quantity = quantity;
        }
    }
}
