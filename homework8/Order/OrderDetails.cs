using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    [Serializable]
    public class OrderDetails
    {
        public string Item { set; get; }  //商品名称
        public uint Num { set; get; }   //数量
        public double Price
        {
            set;get;
           
        }  
        public OrderDetails() { }
        public OrderDetails(string item, uint num, double price)
        {
            Item = item;
            Num = num;
            Price = price;
        }

        public override string ToString()
        {
            string details = "";
            details += $"商品：{Item}" + $"\t数量：{Num}" + $"\t价格：{Price}";
            return details;
        }
    }
}
