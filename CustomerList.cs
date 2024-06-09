using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BillBook
{
    public partial class CustomerList : UserControl
    {
        DatabaseOperations databaseOperations;
        CustomerForm customerForm;
        public CustomerList(DatabaseOperations databaseOperations)
        {
            InitializeComponent();
            this.databaseOperations = databaseOperations;
            customerForm = new CustomerForm(this.databaseOperations);
            customerForm.updated += Customer_updated; ;
        }

        private void Customer_updated(object sender, CustomerUpdatedArgs e)
        {
            dataGridView1.Rows[e.Rowid].SetValues(e.Id, e.Name, e.Phone, e.Address, e.Gst);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            databaseOperations.GetCustomers(name:nameTextBox.Text.Trim().ToUpper(),phone:phoneTextBox.Text.Trim().ToUpper()).ForEach(customer =>
            {
                dataGridView1.Rows.Add(customer.Id, customer.Name, customer.Phone, customer.Address, customer.Gst, customer.Created, "Edit", "Delete");
            });
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    customerForm.ShowMyDialog(
                        e.RowIndex, 
                        Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString()), 
                        senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString(), 
                        senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString(), 
                        senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString(), 
                        senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString()
                        );
                }
                else if (e.ColumnIndex == 7)
                {
                    databaseOperations.DeleteCustomer(Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {

        }
    }
}
