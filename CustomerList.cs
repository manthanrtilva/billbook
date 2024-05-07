using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BillBook
{
    public partial class CustomerList : UserControl
    {
        DatabaseOps databaseOps;
        private Customer customerForm;
        public CustomerList(DatabaseOps databaseOps)
        {
            InitializeComponent();
            this.databaseOps = databaseOps;
            customerForm = new Customer(databaseOps: databaseOps, true);
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            var items = databaseOps.GetCustomers();
            var row = 0;
            tableLayoutPanel1.RowCount = items.Count;
            foreach (var item in items)
            {
                addRow(row, item);
                row++;
            }
            Debug.WriteLine("tableLayoutPanel1.RowCount:"+ tableLayoutPanel1.RowCount);
            tableLayoutPanel1.ResumeLayout(true);
        }

        private void addRow(int row, DCustomer item)
        {
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(SizeType.AutoSize));
            var label = new System.Windows.Forms.Label();
            label.Text = item.ID.ToString();
            Debug.WriteLine(label.Text);
            tableLayoutPanel1.Controls.Add(label, 0, row);
            label = new System.Windows.Forms.Label();
            //Debug.WriteLine(item.Name);
            label.Text = item.Name;
            tableLayoutPanel1.Controls.Add(label, 1, row);
            label = new System.Windows.Forms.Label();
            label.Text = item.Phone;
            tableLayoutPanel1.Controls.Add(label, 2, row);
            label = new System.Windows.Forms.Label();
            label.Text = item.Email;
            tableLayoutPanel1.Controls.Add(label, 3, row);
            label = new System.Windows.Forms.Label();
            label.Text = item.Address;
            tableLayoutPanel1.Controls.Add(label, 4, row);
            label = new System.Windows.Forms.Label();
            label.Text = item.GST;
            tableLayoutPanel1.Controls.Add(label, 5, row);

            var button = new System.Windows.Forms.Button();
            button.Name = "Edit";
            button.Size = new System.Drawing.Size(75, 23);
            button.Text = "Edit";
            button.UseVisualStyleBackColor = true;
            button.Click += (sender, e) => { onedit(sender, e, item); };
            tableLayoutPanel1.Controls.Add(button, 6, row);
            button = new System.Windows.Forms.Button();
            button.Name = "Delete";
            button.Size = new System.Drawing.Size(75, 23);
            button.Text = "Delete";
            button.UseVisualStyleBackColor = true;
            button.Click += (sender, e) => { ondelete(sender, e, item); };
            tableLayoutPanel1.Controls.Add(button, 7, row);
        }

        private void ondelete(object sender, EventArgs e, DCustomer item)
        {
            databaseOps.DeleteCustomer(item.ID);
        }

        private void onedit(object sender, EventArgs e, DCustomer item)
        {
            customerForm.ShowMyDialog(item);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
