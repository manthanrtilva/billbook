using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillBook
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Gst {  get; set; }
        public decimal Quantity { get; set; }
        public string Created {  get; set; }
        public Product(int id, string name, decimal price, decimal gst, decimal quantity, string created)
        {
            Id = id;
            Name = name;
            Price = price;
            Gst = gst;
            Quantity = quantity;
            Created = created;
        }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Gst { get; set; }
        public string Address { get; set; }
        public string Created { get; set; }
        public Customer(int id, string name , string phone, string address, string gst, string created)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Gst = gst;
            Address = address;
            Created = created;
        }
    }
    public class DatabaseOperations
    {
        const string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=BillBook.mdb";
        public DatabaseOperations() 
        {
            
        }
        public void AddProduct(string name, decimal price, decimal gst, decimal quantity)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("INSERT INTO PRODUCTS (PNAME,PPRICE,PGST,PQUANTITY) values('{0}',{1},{2},{3})", name.ToUpper(), price, gst, quantity);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public List<Product> GetProducts(string name = "")
        {
            List<Product> products = new List<Product>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string where = string.Empty;
                    if (name.Length > 0)
                    {
                        where += string.Format("AND PNAME like '%{0}%' ", name.ToUpper());
                    }
                    using (OleDbCommand command = new OleDbCommand(string.Format("SELECT ID, PPRICE, PGST, PQUANTITY, PNAME, PCREATED FROM PRODUCTS  WHERE 1 = 1 {0} ORDER BY PNAME ASC", where), connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //Debug.WriteLine(reader.GetDataTypeName(5));
                            
                            var p = new Product(reader.GetInt32(0), reader.GetString(4), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(5).ToString());
                            products.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            return products;
        }


        internal void DeleteProduct(int id)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("DELETE FROM PRODUCTS WHERE ID = {0}", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        internal string GetNullableString(ref OleDbDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? string.Empty : reader.GetString(index);
        }

        internal void UpdateProduct(int id, string name, decimal price, decimal gst, decimal quaintity)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("UPDATE PRODUCTS SET PNAME='{1}',PPRICE={2},PGST={3},PQUANTITY={4} WHERE ID = {0}", id, name.ToUpper(), price, gst, quaintity);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void AddCustomer(string name, string address, string phone, string gst)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("INSERT INTO CUSTOMERS (CNAME,CADDRESS,CPHONE,CGST) values('{0}','{1}','{2}','{3}')", name.ToUpper(), address.ToUpper(), phone.ToUpper(), gst.ToUpper());
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        internal List<Customer> GetCustomers(string name, string phone)
        {
            List<Customer> customers = new List<Customer>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string where = string.Empty;
                    if (name.Length > 0)
                    {
                        where += string.Format("AND CNAME like '%{0}%' ", name.ToUpper());
                    }
                    if (phone.Length > 0)
                    {
                        where += string.Format("AND CPHONE like '%{0}%' ", phone);
                    }
                    string sql = string.Format("SELECT ID, CNAME, CADDRESS, CPHONE, CGST, CCREATED FROM CUSTOMERS WHERE 1 = 1 {0} ORDER BY CNAME ASC", where);
                    using (OleDbCommand command = new OleDbCommand(sql, connection))
                    {
                        Debug.WriteLine("sql:" + sql);
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var p = new Customer(reader.GetInt32(0), //id
                                GetNullableString(ref reader, 1),  //name
                                GetNullableString(ref reader, 3), // phone
                                GetNullableString(ref reader, 2), //address
                                GetNullableString(ref reader, 4), //gst
                                reader.GetDateTime(5).ToString() //created
                                );
                            customers.Add(p);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            return customers;
        }

        internal void UpdateCustomer(int id, string name, string address, string phone, string gst)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("UPDATE CUSTOMERS SET CNAME='{1}',CADDRESS='{2}',CPHONE='{3}',CGST='{4}' WHERE ID = {0}", id, name.ToUpper(), address.ToUpper(), phone.ToUpper(), gst.ToUpper());
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
                using (OleDbConnection connection = new OleDbConnection(connectionString))
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

    }
}
