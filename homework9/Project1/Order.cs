using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
namespace project1
{
    [Serializable]
    public class Order
    {
        [Key]
        public string ID { set; get; }
        public string Name { set; get; }
        public string phoneNum { set; get; }
        public List<OrderDetails> Items { set; get; }
        public double TotalPrice
        {
            get
            {
                return Items.Sum(d => d.Price * d.Num);
            }
            set {}
        }
        public Order()
        {
            Items = new List<OrderDetails>();
        }
        public Order(string id, string name, string phone, List<OrderDetails> items)
        {
            ID = id;
            Name = name;
            phoneNum = phone;
            Items = items;
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
