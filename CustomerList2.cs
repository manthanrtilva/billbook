using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillBook
{
    public partial class CustomerList2 : UserControl
    {
        private DatabaseOps databaseOps = null;
        private Customer customerForm;
        string lastSearchedName = string.Empty;
        string lastSearchedPhone = string.Empty;
        public CustomerList2(DatabaseOps databaseOps)
        {
            InitializeComponent();
            this.databaseOps = databaseOps;
            customerForm = new Customer(databaseOps: databaseOps, true);
            databaseOps.GetCustomers().ForEach
                (customer =>
                {
                    dataGridView1.Rows.Add(customer.ID, customer.Name, customer.Phone, customer.Email, "Edit", "Delete");
                });
//            dataGridView1.DataSource = databaseOps.GetCustomers();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Debug.WriteLine("e.ColumnIndex:" + e.ColumnIndex + ",e.RowIndex:" + e.RowIndex + ",id:" + senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (e.ColumnIndex == 4)
                {
                    customerForm.ShowMyDialog(Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString()));
                }
                else if (e.ColumnIndex == 5)
                {
                    databaseOps.DeleteCustomer(Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString()));
                }
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if(phoneTextBox.Text.Length > 0 || nameTextBox.Text.Length > 0)
            {
                if(
                    (phoneTextBox.Text != lastSearchedPhone) ||
                    (nameTextBox.Text != lastSearchedName)
                    )
                {
                    dataGridView1.Rows.Clear();
                    databaseOps.GetCustomers(name: nameTextBox.Text, phone: phoneTextBox.Text).ForEach
                        (customer =>
                        {
                            dataGridView1.Rows.Add(customer.ID, customer.Name, customer.Phone, customer.Email, "Edit", "Delete");
                        });
                    lastSearchedPhone = phoneTextBox.Text;
                    lastSearchedName = nameTextBox.Text;
                }                
            }
        }
    }
}
