using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace BillBook
{
    internal class BillRow
    {
        public decimal Id { get; private set; } = 0;
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public decimal GrandTotal { get; private set; }
        public decimal Items { get; private set; }
        public string Created {  get; private set; }

        public BillRow( decimal id, string name ,string phone, decimal total, decimal items, string created)
        {
            Id = id;
            Name = name;
            Phone = phone;
            GrandTotal = total;
            Items = items;
            Created = created;
        }
    }
    internal class BillData
    {
        public decimal Id { get; set; }
        public List<BillItem> items = new List<BillItem>();
        public decimal ItemCount { get; private set; } = 0;
        public decimal GrandTotal { get; private set; } = 0;
        //public BillData(decimal id = 0)
        //{
        //    Id = id;
        //}
        internal (BillItem,bool,int) AddItem(int id, string name, decimal price, decimal gst, decimal quantity, int index)
        {
            var item = items.Find(i => i.Name == name);
            if ( item == null)
            {
                item = new BillItem(id, name, price, gst, quantity, index);
                items.Add(item);
                GrandTotal += item.Total;
                ItemCount += quantity;
                return (item, false, item.Index);
            }
            else
            {
                GrandTotal -= item.Total;
                item.AddQuantity(quantity);
                GrandTotal += item.Total;
                ItemCount += quantity;
                return (item,true,item.Index);
            }
        }
        internal List<BillItem> GetItems()
        {
            return items;
        }
    }
    internal class BillItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set;}
        public decimal Gst { get; private set;}
        public decimal Quantity { get; private set;}
        public decimal Total { get; private set; } = 0;
        public int Index { get; set; } = -1;
        public BillItem(int id, string name, decimal price, decimal gst, decimal quantity, int index) 
        {
            Id = id;
            Name = name;
            Price = price;
            Gst = gst;
            Quantity = quantity;
            Index = index;
            Total = (Price * Quantity) * (1 + (Gst / 100));
        }

        internal void AddQuantity(decimal quantity)
        {
            Quantity += quantity;
            Total = (Price * Quantity) * (1 + (Gst / 100));
        }
    }
}
