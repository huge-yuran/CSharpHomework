using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            OrderService orderService = new OrderService();

            OrderDetails details1 = new OrderDetails("1","beats", 2, 1099);
            OrderDetails details2 = new OrderDetails("2","xiaomi", 1, 1999);
            OrderDetails details3 = new OrderDetails("3","iphone", 4, 6999);

            List<OrderDetails> items1 = new List<OrderDetails> { details1, details2 };
            List<OrderDetails> items2 = new List<OrderDetails> { details3 };
          
            Order order1 = new Order("100001", "fafa", "13647118626", items1);
            Order order2 = new Order("100002", "lulu", "13886318833", items2);
     

            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
        }
    }   
}