using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace project1
{
    [Serializable]
    public class OrderDetails
    {
        [Key]
        public string Id { set; get; }
        public string Item { set; get; }  //商品名称
        public int Num { set; get; }   //数量
        public double Price
        {
            set;get;
            
        }
        public OrderDetails(string id,  string item, int num, double price)
        {
            Id = id;
            Item = item;
            Num = num;
            Price = price;
        }
        public OrderDetails()
        {
            Id = Guid.NewGuid().ToString();
        }     //将items返回为string类型的id  外键
        public override string ToString()
        {
            string details = "";
            details += $"商品：{Item}" + $"\t数量：{Num}" + $"\t价格：{Price}";
            return details;
        }
    }
}
