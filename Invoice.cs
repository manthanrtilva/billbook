using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BillBook
{
    public partial class Invoice : Form
    {
        private Bitmap memoryImage = null;
        private Graphics memoryGraphics = null;
        private string stringToPrint = "";
        public Invoice()
        {
            InitializeComponent();
            HelperRegistry.SetBrowserEmulationVersion();
            this.KeyDown += Invoice_KeyDown;
        }

        private void Invoice_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("hello1");
            if (e.KeyCode == Keys.P)
            {
                Debug.WriteLine("hello2");
                MessageBox.Show("Hello");
            }
        }

       

        internal void AddBillData(ref DCustomer selectedCust, ref List<DBillItem> items)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "BillBook.Resources.BillTemplate.html";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                Debug.WriteLine( stream.ToString());

                using (StreamReader reader = new StreamReader(stream))
                {
                    string replace = "";
                        //"<tr>\r\n            <td>1</td>\r\n            <td>Name1</td>\r\n            <td>Unit Price1</td>\r\n            <td>Units1</td>\r\n            <td>GST1</td>\r\n            <td>Total1</td>\r\n        </tr>";
                    decimal index = 1;
                    decimal grandTotal = 0;
                    items.ForEach(x =>
                    {
                        decimal total = x.price * x.quantity;
                        replace += string.Format("<tr><td>{0}</td><td>{1}</td><td style='text-align: end;'>{2}</td><td style='text-align: end;'>{3}</td><td style='text-align: end;'>{4}</td></tr>\r\n", index,x.pName,x.price,x.quantity,total);
                        grandTotal += total;
                        index++;
                    });
                    replace += string.Format("<tr><td colspan=\"4\" style=\"font-weight: bold;\">Grand Total</td><td style=\"font-weight: bold;text-align: end;\">{0}</td></tr>", grandTotal);
                    var DocumentText = reader.ReadToEnd();
                    //string input = "test, and test but not testing.  But yes to test";
                    string pattern = @"\brows\b";
                    string result = Regex.Replace(DocumentText, pattern, replace);
                    Console.WriteLine(result);
                    webBrowser1.DocumentText = result;
                    Debug.WriteLine("webBrowser1.DocumentText:" + webBrowser1.DocumentText);
                }
            }
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string keyName = @"Software\Microsoft\Internet Explorer\PageSetup";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key != null)
                {
                    key.SetValue("footer", "");
                    key.SetValue("header", "");
                    webBrowser1.ShowPrintDialog();
                }
            }
            
        }
    }
}
