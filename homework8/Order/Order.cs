using System;
using System.Collections.Generic;
using System.Linq;

namespace project1
{
    [Serializable]
    public class Order
    {
        public List<OrderDetails> Items { set; get; }
        public string ID { set; get; }
        public string Name { set; get; }
        //public List<OrderDetails> Details { set; get => this.Items; }
        public double TotalPrice
        {
            get
            {
                return Items.Sum(d => d.Price * d.Num);
            }
        }
        public Order() { }
        public Order(string id, string name)
        {
            ID = id;
            Name = name;
           // Items = new List<OrderDetails>();
        }

        public override string ToString()
        {
            string order = "";
            order += $"ID：{ID}" + $"\t客户：{Name}";
            Items.ForEach(m => order += "\n\t" + m);
            return order;
        }

    }
}
