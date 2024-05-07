using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Windows.Forms;

namespace BillBook
{
    public partial class Customer : Form
    {
        private DatabaseOps databaseOps = null;
        private bool update = false;
        private int id = 0;
        public Customer(DatabaseOps databaseOps, bool update)
        {
            InitializeComponent();
            this.databaseOps = databaseOps;
            this.update = update;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Count() == 0 &&
                phoneTextBox.Text.Count() == 0 &&
                emailTextBox.Text.Count() == 0 &&
                addressTextBox.Text.Count() == 0 &&
                gstTextBox.Text.Count() == 0)
            {
                MessageBox.Show("All field are empty");
            }
            else if (update)
            {
                databaseOps.UpdateCustomer(nameTextBox.Text, phoneTextBox.Text,
                    emailTextBox.Text,
                    addressTextBox.Text,
                    gstTextBox.Text, id);
            }
            else
            {
                databaseOps.AddCustomer(nameTextBox.Text, phoneTextBox.Text,
                    emailTextBox.Text,
                    addressTextBox.Text,
                    gstTextBox.Text);
            }
            nameTextBox.Text = string.Empty;
            phoneTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            addressTextBox.Text = string.Empty;
            gstTextBox.Text = string.Empty;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = string.Empty;
            phoneTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            addressTextBox.Text = string.Empty;
            gstTextBox.Text = string.Empty;
            Close();
        }

        internal void ShowMyDialog(DCustomer item)
        {
            id = item.ID;
            nameTextBox.Text = item.Name;
            phoneTextBox.Text = item.Phone;
            emailTextBox.Text = item.Email;
            addressTextBox.Text = item.Address;
            gstTextBox.Text = item.GST;
            ShowDialog();
        }
        internal void ShowMyDialog(int id)
        {
            var custs = databaseOps.GetCustomers(id: id.ToString());
            if(custs.Count() == 0)
            {
                MessageBox.Show("No customer found");
            }
            else if(custs.Count() > 1) 
            {
                MessageBox.Show("Many customer found");
            }
            else
            {
                ShowMyDialog(custs[0]);
            }
        }
    }
}
