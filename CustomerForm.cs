using System;
using System.Windows.Forms;

namespace BillBook
{
    public partial class CustomerForm : Form
    {
        DatabaseOperations databaseOperations = null;
        int updateid = 0;
        int rowid = 0;
        public event EventHandler<CustomerUpdatedArgs> updated;
        public CustomerForm(DatabaseOperations databaseOperations)
        {
            InitializeComponent();
            this.databaseOperations = databaseOperations;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text.Trim().Length == 0)
            {
                Close();
                MessageBox.Show("Name is empty");
                return;
            }
            if (updateid == 0)
            {
                databaseOperations.AddCustomer(nameTextBox.Text.Trim().ToUpper(), addressTextBox.Text.Trim().ToUpper(), phoneTextBox.Text.Trim().ToUpper(), gstTextBox.Text.Trim().ToUpper());
            }
            else
            {
                databaseOperations.UpdateCustomer(updateid, nameTextBox.Text.Trim().ToUpper(), addressTextBox.Text.Trim().ToUpper(), phoneTextBox.Text.Trim().ToUpper(), gstTextBox.Text.Trim().ToUpper());
                EventHandler<CustomerUpdatedArgs> handler = updated;
                if (handler != null)
                {
                    handler(this, new CustomerUpdatedArgs(rowid, updateid, nameTextBox.Text.Trim().ToUpper(), addressTextBox.Text.Trim().ToUpper(), phoneTextBox.Text.Trim().ToUpper(), gstTextBox.Text.Trim().ToUpper()));
                }
            }
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }
        internal DialogResult ShowMyDialog(int rowid, int id, string name, string address, string phone, string gst)
        {
            this.rowid = rowid;
            updateid = id;
            nameTextBox.Text = name;
            addressTextBox.Text = address;
            phoneTextBox.Text = phone;
            gstTextBox.Text = gst;
            return ShowDialog();
        }
    }
    public class CustomerUpdatedArgs : EventArgs
    {
        public CustomerUpdatedArgs(int rowid, int id, string name, string address, string phone, string gst)
        {
            Rowid = rowid;
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Gst = gst;
        }
        public int Rowid { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gst { get; set; }
    }
}
