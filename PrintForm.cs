using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillBook
{
    public partial class PrintForm : Form
    {
        public PrintForm()
        {
            InitializeComponent();
        }

        internal string AddBillData(ref BillData billData, ref Customer customer)
        {
            var resourceName = "BillBook.Resources.BillTemplate.html";
            foreach (var item in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                Debug.WriteLine(item);
            }
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                Debug.WriteLine(stream.ToString());

                using (StreamReader reader = new StreamReader(stream))
                {
                    string replace = "<tr>\r\n            <td>1</td>\r\n            <td>Name1</td>\r\n            <td>Unit Price1</td>\r\n            <td>Units1</td>\r\n            <td>GST1</td>\r\n            <td>Total1</td>\r\n        </tr>";
                    decimal index = 2;
                    decimal grandTotal = 0;
                    billData.GetItems().ForEach(x =>
                    {
                        decimal total = x.Quantity * (((100 + x.Gst) / 100) * x.Price);
                        replace += string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>\r\n", index, x.Name, x.Price, x.Quantity, x.Gst, total);
                        grandTotal += total;
                        index++;
                    });
                    replace += string.Format("        <tr>\r\n            <td colspan=\"5\" style=\"font-weight: bold;\">Grand Total</td>\r\n            <td style=\"font-weight: bold;\">{0}</td>\r\n        </tr>\r\n", grandTotal);

                    var DocumentText = reader.ReadToEnd();
                    //string input = "test, and test but not testing.  But yes to test";
                    string pattern = @"\brows\b";
                    string result = Regex.Replace(DocumentText, pattern, replace);
                    Console.WriteLine(result);
                    //webBrowser1.DocumentText = result;
                    webBrowser1.DocumentText = DocumentText;
                    return DocumentText;
                }
            }
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {

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
                    //webBrowser1.ShowPrintDialog();
                    webBrowser1.Print();
                }
            }
        }
    }
}
