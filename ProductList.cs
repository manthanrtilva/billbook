using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BillBook
{
    public partial class ProductList : UserControl
    {
        DatabaseOperations databaseOperations;
        ProductForm productForm;
        public ProductList(DatabaseOperations databaseOperations)
        {
            InitializeComponent();
            this.databaseOperations = databaseOperations;
            productForm = new ProductForm(this.databaseOperations);
            productForm.updated += Product_updated;
        }

        private void Product_updated(object sender, ProductUpdatedArgs e)
        {
            dataGridView1.Rows[e.Rowid].SetValues(e.Id,e.Name,e.Price,e.Quantity,e.Gst,e.Hsn);
        }

        private void search_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            databaseOperations.GetProducts(nameTextBox.Text.Trim().ToUpper()).ForEach(product =>
            {
                dataGridView1.Rows.Add(product.Id, product.Name, product.Price, product.Quantity, product.Gst, product.Hsn, product.Created,"Edit","Delete");
            });
        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("ProductList_Load");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 7)
                {
                    //ShowMyDialog(int rowid, int id, string name, int price, int gst, int quaintity, string hsn)
                    
                    
                productForm.ShowMyDialog(e.RowIndex, // rowid
                        Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString()),  // id
                        senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString(),  // name
                        Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString()),  //price
                        Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString()), // gst
                        Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString()), //quaintity
                        senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString() // hsn
                        );
                }
                else if (e.ColumnIndex == 8)
                {
                    databaseOperations.DeleteProduct(Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}
