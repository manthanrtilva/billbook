using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BillBook
{
    public class DBillItem
    {
        public int ID { get; set; }
        public string pName { get; set; }
        public int pID { get; set; }
        public int bID { get; set; }
        public decimal quantity { get; set; }
        public decimal price { get; set; }
        public decimal gst {  get; set; }
    }
    public class DProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        public decimal Price { get; set; }

        public decimal GST { get; set; } = 0;

        public decimal Quantity { get; set; } = 0;
        public DProduct(int iD, string name, decimal price, decimal gst, decimal quantity)
        {
            ID = iD;
            Name = name;
            Price = price;
            GST = gst;
            Quantity = quantity;
        }
    }
    public class DCustomer
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
        public string GST { get; set; }
        public DCustomer(int iD, string name, string phone, string email ,string address, string gst)
        {
            ID = iD;
            Name = name;
            Phone = phone;
            Email = email;
            Address = address;
            GST = gst;
        }
    }
    public class DatabaseOps
    {
        public DatabaseOps()
        {
            var binPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            var rootPath = System.IO.Directory.GetParent(binPath).FullName;
            var dataPath = "C:\\Users\\ZTI-Manthan\\source\\repos\\BillBook\\Database1.mdb"; // Path.Combine(rootPath, "data");
            _databaseConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + dataPath;
        }
        public Boolean AddProduct(string name, decimal price, decimal gst, decimal quantity)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_databaseConnectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("INSERT INTO PRODUCTS (PNAME,PPRICE,PGST,PQUANTITY) values('{0}',{1},{2},{3})", name.ToUpper(), price, gst, quantity);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        internal List<DProduct> GetProducts(string name = "")
        {
            List<DProduct> products = new List<DProduct>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_databaseConnectionString))
                {
                    connection.Open();
                    string where = string.Empty;
                    if (name.Length > 0)
                    {
                        where += string.Format("AND PNAME = '{0}' ", name.ToUpper());
                    }
                    using (OleDbCommand command = new OleDbCommand(string.Format("SELECT ID, PPRICE, PGST, PQUANTITY, PNAME FROM PRODUCTS  WHERE 1 = 1 {0} ORDER BY PNAME ASC",where), connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var p = new DProduct(reader.GetInt32(0), reader.GetString(4), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
                            products.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"\n"+ ex.StackTrace);
            }
            return products;
        }

        public Boolean DeleteProduct(int id)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_databaseConnectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("DELETE FROM PRODUCTS WHERE ID = {0}", id);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        internal Boolean UpdateProduct(int hiddenId, string name, decimal price, decimal gst, decimal quantity)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_databaseConnectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("UPDATE PRODUCTS SET PNAME='{1}',PPRICE={2},PGST={3},PQUANTITY={4} WHERE ID = {0}", hiddenId,name.ToUpper(),price,gst,quantity);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        internal void UpdateCustomer(string name, string phone, string email, string address, string gst, int id)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_databaseConnectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("UPDATE CUSTOMERS SET CNAME='{0}',CPHONE='{1}',CEMAIL='{2}',CADDRESS='{3}',CGST='{4}' WHERE ID = {5}",name.ToUpper(),phone.ToUpper(), email.ToUpper(), address.ToUpper(), gst.ToUpper(), id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void AddCustomer(string name, string phone, string email, string address, string gst)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_databaseConnectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("INSERT INTO CUSTOMERS (CNAME,CPHONE,CEMAIL,CADDRESS, CGST) values('{0}','{1}','{2}','{3}','{4}')", name.ToUpper(), phone.ToUpper(), email.ToUpper(), address.ToUpper(), gst.ToUpper());
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        internal void DeleteCustomer(int id)
        {

            try
            {
                using (OleDbConnection connection = new OleDbConnection(_databaseConnectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("DELETE FROM CUSTOMERS WHERE ID = {0}", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        internal List<DCustomer> GetCustomers(string name = "", string phone = "", string email = "", string address = "", string gst = "", string id = "")
        {
            List<DCustomer> ret = new List<DCustomer>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_databaseConnectionString))
                {
                    connection.Open();
                    string where = string.Empty;
                    if (id.Length > 0)
                    {
                        where += string.Format("AND ID = {0} ", id);
                    }
                    if (name.Length > 0)
                    {
                        where += string.Format("AND CNAME LIKE '%{0}%' ", name.ToUpper());
                    }
                    if (phone.Length > 0)
                    {
                        where += string.Format("AND CPHONE LIKE '{0}%' ", phone.ToUpper());
                    }
                    if (email.Length > 0)
                    {
                        where += string.Format("AND CEMAIL LIKE '{0}%' ", email.ToUpper());
                    }
                    if (address.Length > 0)
                    {
                        where += string.Format("AND CADDRESS LIKE '%{0}%' ", address.ToUpper());
                    }
                    if (gst.Length > 0)
                    {
                        where += string.Format("AND CGST LIKE '{0}%' ", gst.ToUpper());
                    }
                    var sql = string.Format("SELECT ID, CNAME, CPHONE, CEMAIL, CADDRESS, CGST FROM CUSTOMERS WHERE 1 = 1 {0} ORDER BY CNAME ASC",where);
                    Debug.WriteLine(sql);
                    using (OleDbCommand command = new OleDbCommand(sql, connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var c = new DCustomer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),reader.GetString(3), reader.GetString(4), reader.GetString(5));
                            ret.Add(c);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            return ret;

        }

        internal void AddBill(ref DCustomer selectedCust, ref List<DBillItem> items, string status)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(_databaseConnectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("INSERT INTO BILLS (BCID,BPAYSTATUS) VALUES({0},'{1}')",selectedCust.ID,status);
                        Debug.WriteLine(command.CommandText);
                        command.ExecuteNonQuery();
                        OleDbCommand insertedId = new OleDbCommand("SELECT @@IDENTITY", connection);
                        var billid = (int)insertedId.ExecuteScalar();
                        foreach (var item in items)
                        {
                            using (OleDbCommand command1 = connection.CreateCommand())
                            {
                                command1.CommandText = string.Format("INSERT INTO BILLITEMS (BIBID,BIPID,BIQUNTITY,BIPRICE,BIGST) VALUES({0},{1},{2},{3},{4})",billid,item.pID,item.quantity,item.price,item.gst);
                                command1.ExecuteNonQuery();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private string _databaseConnectionString;
    }
}
