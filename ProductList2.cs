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
using System.Xml.Linq;

namespace BillBook
{
    public partial class ProductList2 : UserControl
    {
        private Product productForm;
        private DatabaseOps databaseOps;
        public ProductList2(DatabaseOps databaseOps)
        {
            InitializeComponent();
            databaseOps.GetProducts().ForEach
                (product =>
                {
                    dataGridView1.Rows.Add(product.ID,product.Name,product.Price,product.Quantity,product.GST,"Edit","Delete");
                });
            productForm = new Product(databaseOps: databaseOps, true);
            this.databaseOps = databaseOps;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Debug.WriteLine("e.ColumnIndex:"+ e.ColumnIndex+ ",e.RowIndex:"+ e.RowIndex + ",id:" + senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                if(e.ColumnIndex == 5)
                {
                    productForm.ShowMyDialog(Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString()), senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString(), Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString()), Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString()), Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString()));
                }
                else if (e.ColumnIndex == 6)
                {
                    databaseOps.DeleteProduct(Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString()));
                }
            }
        }
    }
}
