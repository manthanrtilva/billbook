using System;
using System.Windows.Forms;

namespace BillBook
{
    public partial class BillList : UserControl
    {
        DatabaseOperations databaseOperations;
        public event EventHandler<ViewBillArgs> viewBill;

        public BillList(DatabaseOperations databaseOperations)
        {
            InitializeComponent();
            this.databaseOperations = databaseOperations;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( e.ColumnIndex == 5 )
            {
                var senderGrid = (DataGridView)sender;
                var bid = Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());

                EventHandler<ViewBillArgs> handler = viewBill;
                if (handler != null)
                {
                    handler(this, new ViewBillArgs(bid));
                }
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        internal void LoadData()
        {
            dataGridView1.Rows.Clear();
            databaseOperations.GetBills(name: nameTextBox.Text.Trim().ToUpper(), phone: phoneTextBox.Text.Trim().ToUpper()).ForEach(b =>
            {
                dataGridView1.Rows.Add(b.Id, b.Name, b.Phone, b.GrandTotal, b.Items, "View");
            }
            );
        }
    }
    public class ViewBillArgs : EventArgs
    {
        public int Id { get; private set; }
        public ViewBillArgs(int id)
        {
            Id = id;
        }
    }

}
