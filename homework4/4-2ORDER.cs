using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order4_2
{
    class Order
    {
        public List<OrderDetails> OrderContent = new List<OrderDetails>();
        public string OrderNo{ get; set; }
        public string Client{ get; set; }
        public void Print()
        {
            Console.WriteLine("订单号：\t" + OrderNo);
            Console.WriteLine("客户名：\t" + Client);
            for (int i = 0; i < OrderContent.Count; i++)
            {
                Console.WriteLine("\t商品名：\t" + OrderContent[i].ItemName);
                Console.WriteLine("\t商品数量：\t" + OrderContent[i].ItemAmount);
                Console.WriteLine("\t商品单价：\t" + OrderContent[i].ItemPrice + "\n");
            }
        }
    }

    class OrderDetails
    {
        public int ItemAmount{ get; set; }
        public string ItemName{ get; set; }
        public double ItemPrice{ get; set;}
    }

    class SearchException : ApplicationException
    {
        public string msg;
        public SearchException(string message) : base(message)
        {
            msg = message;
        }
    }
    class OrderService
    {
        private List<Order> OrderList = new List<Order>();

        public void AddOrder()
        {
            try
            {
                Order NewOrder = new Order();

                Console.WriteLine("请输入订单号：");
                NewOrder.OrderNo = Console.ReadLine();

                Console.WriteLine("请输入客户名：");
                NewOrder.Client = Console.ReadLine();

                Console.WriteLine("请输入商品数量：");
                int n = Convert.ToInt32(Console.ReadLine());

                for (int i = 1; i <= n; i++)
                {
                    OrderDetails NewItem = new OrderDetails();

                    Console.WriteLine("请输入第" + i + "种商品名字：");
                    NewItem.ItemName = Console.ReadLine();

                    Console.WriteLine("请输入第" + i + "种商品编号：");
                    NewItem.ItemAmount = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("请输入第" + i + "种商品单价：");
                    NewItem.ItemPrice = Convert.ToDouble(Console.ReadLine());

                    NewOrder.OrderContent.Add(NewItem);
                }

                OrderList.Add(NewOrder);
                Console.WriteLine("添加成功！");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void PrintOrders(List<Order> Orders)
        {
            for (int i = 0; i < Orders.Count; i++)
            {
                Orders[i].Print();
            }
        }

        public void ModifyOrder()
        {
            DeleteOrder();
            AddOrder();
        }

        public void DeleteOrder()
        {
            List<int> SearchResult = new List<int>();
            SearchResult = SearchOrder();
            try
            {
                for (int i = SearchResult.Count - 1; i >= 0; i--)
                {
                    OrderList.RemoveAt(SearchResult[i]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("订单删除成功！");
        }

        public List<int> SearchOrder()
        {
            string res;
            List<int> Result = new List<int>();
            try
            {
                Console.WriteLine("按订单号搜索：[y/n]");
                res = Console.ReadLine();
                if (res == "y")
                {
                    Console.WriteLine("请输入订单号：");
                    Result = SearchByOrderNo(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("按客户名搜索：[y/n]");
                    res = Console.ReadLine();
                    if (res == "y")
                    {
                        Console.WriteLine("请输入客户名：");
                        Result = SearchByClient(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("按商品名搜索：[y/n]");
                        res = Console.ReadLine();
                        if (res == "y")
                        {
                            Console.WriteLine("请输入商品名：");
                            Result = SearchByClient(Console.ReadLine());
                        }
                    }
                }
            }
            catch (SearchException e)
            {
                Console.WriteLine(e.msg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("搜索结束");
            return Result;
        }

        public List<int> SearchByOrderNo(string OrderNo)
        {
            List<int> Result = new List<int>();
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (OrderList[i].OrderNo == OrderNo)
                {
                    Result.Add(i);
                }
            }
            if (Result.Count == 0)
            {
                SearchException e = new SearchException("404 Not Found");
                throw e;
            }
            return Result;
        }

        public List<int> SearchByClient(string Client)
        {
            List<int> Result = new List<int>();
            for (int i = 0; i < OrderList.Count; i++)
            {
                if (OrderList[i].OrderNo == Client)
                {
                    Result.Add(i);
                }
            }
            if (Result.Count == 0)
            {
                SearchException e = new SearchException("404 Not Found");
                throw e;
            }
            return Result;
        }

        public List<int> SearchByItemName(string ItemName)
        {
            List<int> Result = new List<int>();
            for (int i = 0; i < OrderList.Count; i++)
            {
                for (int j = 0; j < OrderList[i].OrderContent.Count; j++)
                {
                    if (OrderList[i].OrderContent[j].ItemName == ItemName)
                    {
                        Result.Add(i);
                        break;
                    }
                }
            }
            if (Result.Count == 0)
            {
                SearchException e = new SearchException("404 Not Found");
                throw e;
            }
            return Result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderService service = new OrderService();
            while (true)
            {
                Console.WriteLine("请输入指令（1搜索/2添加/3删除/4修改）：");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    service.SearchOrder();
                }
                else if (input == "2")
                {
                    service.AddOrder();
                }
                else if (input == "3")
                {
                    service.DeleteOrder();
                }
                else if (input == "4")
                {
                    service.ModifyOrder();
                }
                else
                {
                    Console.WriteLine("未能识别");
                    continue;
                }
            }
        }
    }
}
