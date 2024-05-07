using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BillBook
{
    public partial class SelectBillItem : Form
    {
        public event EventHandler<ItemAddedEventArgs> ItemAdded;
        public SelectBillItem(string[] productNames)
        {
            InitializeComponent();
            nameComboBox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            nameComboBox.AutoCompleteCustomSource.AddRange(productNames);
            nameComboBox.Items.AddRange(productNames);
        }

        private void nameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(nameComboBox.Text.Count() > 0 && quantityNumericUpDown.Value > 0)
            {
                ItemAddedEventArgs args = new ItemAddedEventArgs(nameComboBox.Text, quantityNumericUpDown.Value);
                OnItemAdded(args);
            }
            nameComboBox.Text = string.Empty;
            quantityNumericUpDown.Value = 1;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            nameComboBox.Text = string.Empty;
            quantityNumericUpDown.Value = 1;
            Close();
        }
        protected virtual void OnItemAdded(ItemAddedEventArgs e)
        {
            EventHandler<ItemAddedEventArgs> handler = ItemAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
    public class ItemAddedEventArgs : EventArgs
    {
        public ItemAddedEventArgs(string text, decimal value)
        {
            this.Name = text;
            this.Quantity = value;
        }

        public string Name { get; set; }
        public decimal Quantity { get; set; }
    }
}
