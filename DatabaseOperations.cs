using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BillBook
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Gst { get; set; }
        public decimal Quantity { get; set; }
        public string Created { get; set; }
        public string Hsn { get; set; }
        public Product(int id, string name, decimal price, decimal gst, decimal quantity, string created, string hsn)
        {
            Id = id;
            Name = name;
            Price = price;
            Gst = gst;
            Quantity = quantity;
            Created = created;
            Hsn = hsn;
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
        public Customer(int id, string name, string phone, string address, string gst, string created)
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
        List<string> allProductName = new List<string>();
        List<string> allCustomerPhone = new List<string>();
        bool productUpdate = true;
        bool customerUpdate = true;
        public DatabaseOperations()
        {

        }
        public void AddProduct(string name, decimal price, decimal gst, decimal quantity, string hsn)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("INSERT INTO PRODUCTS (PNAME,PPRICE,PGST,PQUANTITY,HSN) values('{0}',{1},{2},{3},{4})", name.ToUpper(), price, gst, quantity,hsn.ToUpper());
                        command.ExecuteNonQuery();
                        productUpdate = true;
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
        public List<Product> GetProducts(string name = "", bool like = true)
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
                        if (like)
                        {
                            where += string.Format("AND PNAME like '%{0}%' ", name.ToUpper());
                        }
                        else
                        {
                            where += string.Format("AND PNAME = '{0}' ", name.ToUpper());
                        }
                    }
                    using (OleDbCommand command = new OleDbCommand(string.Format("SELECT ID, PPRICE, PGST, PQUANTITY, PNAME, PCREATED, HSN FROM PRODUCTS  WHERE 1 = 1 {0} ORDER BY PNAME ASC", where), connection))
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var p = new Product(reader.GetInt32(0), GetNullableString(ref reader,4), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(5).ToString(), GetNullableString(ref reader,6));
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
        public List<String> GetAllProductName()
        {
            if (productUpdate)
            {
                productUpdate = false;
                allProductName.Clear();
                GetProducts().ForEach(p =>
                {
                    allProductName.Add(p.Name);
                });
            }
            return allProductName;
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
                        productUpdate = true;
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

        internal void UpdateProduct(int id, string name, decimal price, decimal gst, decimal quaintity,string hsn)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("UPDATE PRODUCTS SET PNAME='{1}',PPRICE={2},PGST={3},PQUANTITY={4},HSN={5} WHERE ID = {0}", id, name.ToUpper(), price, gst, quaintity,hsn);
                        command.ExecuteNonQuery();
                        productUpdate = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal Customer AddCustomer(string name, string address, string phone, string gst)
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
                        OleDbCommand insertedId = new OleDbCommand("SELECT @@IDENTITY", connection);
                        var id = (int)insertedId.ExecuteScalar();
                        customerUpdate = true;
                        return new Customer(id, name, phone, address, gst, string.Empty);
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
            return null;
        }
        internal List<Customer> GetCustomers(string name = "", string phone = "", int id = 0)
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
                    if (id != 0)
                    {
                        where += string.Format("AND ID = {0} ", id);
                    }
                    string sql = string.Format("SELECT ID, CNAME, CADDRESS, CPHONE, CGST, CCREATED FROM CUSTOMERS WHERE 1 = 1 {0} ORDER BY CNAME ASC", where);
                    using (OleDbCommand command = new OleDbCommand(sql, connection))
                    {
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
                        customerUpdate = true;
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
                        customerUpdate = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void SaveBill(ref BillData billData, ref Customer customer, string paymentStatus)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("INSERT INTO BILLS (BCID,BPAYSTATUS,BGRANDTOTAL,BITEMS) VALUES({0},'{1}',{2},{3})", customer.Id, paymentStatus, billData.GrandTotal, billData.ItemCount);
                        command.ExecuteNonQuery();
                        OleDbCommand insertedId = new OleDbCommand("SELECT @@IDENTITY", connection);
                        var billid = (int)insertedId.ExecuteScalar();
                        billData.Id = billid;
                        foreach (var item in billData.GetItems())
                        {
                            using (OleDbCommand command1 = connection.CreateCommand())
                            {
                                command1.CommandText = string.Format("INSERT INTO BILLITEMS (BIBID,BIPID,BIQUANTITY,BIPRICE,BIGST) VALUES({0},{1},{2},{3},{4})", billid, item.Id, item.Quantity, item.Price, item.Gst);
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

        internal List<BillRow> GetBills(string name = "", string phone = "")
        {
            List<BillRow> bills = new List<BillRow>();
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
                    string sql = string.Format("SELECT B.ID,C.CNAME,C.CPHONE,B.BGRANDTOTAL,B.BITEMS,B.BCREATED FROM BILLS AS B RIGHT JOIN CUSTOMERS AS C ON B.BCID = C.ID WHERE 1 = 1 {0} ORDER BY B.ID ASC", where);
                    using (OleDbCommand command = new OleDbCommand(sql, connection))
                    {
                        Debug.WriteLine("sql:" + sql);
                        var reader = command.ExecuteReader();
                        //reader.
                        while (reader.HasRows)
                        {
                            reader.Read();
                            Debug.WriteLine(reader.GetDataTypeName(0));
                                reader.GetInt32(0);
                                GetNullableString(ref reader, 1);
                                GetNullableString(ref reader, 2);
                                reader.GetInt32(3);
                                reader.GetInt32(4);
                                reader.GetDateTime(5).ToString();
                            var bill = new BillRow(
                                reader.GetInt32(0), //id
                                GetNullableString(ref reader, 1),  //name
                                GetNullableString(ref reader, 2),  //phone
                                reader.GetInt32(3), //grandtotal
                                reader.GetInt32(4), //items
                                reader.GetDateTime(5).ToString() //created
                                );
                            bills.Add(bill);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            return bills;
        }
        internal (BillData, Customer, string) GetBillData(int id)
        {
            BillData billData = null;
            Customer customer = null;
            string status = string.Empty;
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("SELECT B.ID, B.BCID, B.BPAYSTATUS FROM BILLS AS B WHERE B.ID = {0}", id);
                        var reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            status = reader.GetString(2);
                            var cid = (int)reader.GetInt32(1);
                            var c = GetCustomers(id: cid);
                            if (c == null)
                            {
                                MessageBox.Show("Invalid customer id");
                            }
                            else
                            {
                                customer = c[0];
                            }
                        }
                        else
                        {
                            MessageBox.Show("Can't find bill");
                        }
                    }
                    using (OleDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format("SELECT BI.BIPID,BI.BIQUANTITY,BI.BIPRICE,BI.BIGST,P.PNAME FROM BILLITEMS AS BI RIGHT JOIN PRODUCTS AS P ON P.ID = BI.BIPID WHERE BI.BIBID = {0}", id);
                        var reader = command.ExecuteReader();
                        int index = 1;
                        billData = new BillData();
                        while (reader.Read())
                        {
                            billData.AddItem(0, reader.GetString(4), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(1), index++);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            return (billData, customer, status);
        }

        internal List<String> GetAllCustomerPhone()
        {
            if (customerUpdate)
            {
                customerUpdate = false;
                allCustomerPhone.Clear();
                GetCustomers().ForEach(p =>
                {
                    allCustomerPhone.Add(p.Phone);
                });
            }
            return allCustomerPhone;
        }
    }
}
