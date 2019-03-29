using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Order : IComparable
    {
        public int id;              //订单号
        public string client;       //客户名
        public string name;         //商品名
        public int CompareTo(object m)
        {
            Order OR = (Order)m;
            if (id > OR.id) return 1; else return 0;
        }
        public override bool Equals(object obj)
        {
            if (obj is Order)
            {
                Order m = (Order)obj;
                if (m.client == client && m.id == id && m.name == name) return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "订单编号为" + id + "；客户名为" + client + "；商品名为" + name;
        }
        public Order(int _id, string _client, string _name)
        {
            this.id = _id;
            this.client = _client;
            this.name = _name;
        }
        public void print()
        {
            Console.WriteLine();
            Console.WriteLine("订单编号为" + id + "；客户名为" + client + "；商品名为" + name);
            Console.WriteLine();
        }
    }

    class OrderServices
    {
        List<Order> L = new List<Order>();

        public void Add()
        {
            Console.WriteLine("请输入订单号");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("请输入客户名");
            string client = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("请输入商品名");
            string name = Console.ReadLine();
            Order OR = new Order(id, client, name);
            foreach (Order order in L)
            {
                if (order.Equals(OR) == true)
                {
                    Console.WriteLine("订单已经存在！");
                    Console.WriteLine();
                    return;
                }

            }
            L.Add(OR);
        }

        public void Delete()
        {
            bool flag = false;
            Console.WriteLine("请输入订单号");
            int k = int.Parse(Console.ReadLine());
            foreach (Order order in L)
            {
                if (order.id == k)
                {
                    L.Remove(order);
                    flag = true;
                    break;
                }

            }
            if (flag == false)
            {
                Console.WriteLine("删除失败！");
                Console.WriteLine();
            }
        }

        public void Search()
        {
            bool flag = false;
            Console.WriteLine("请输入订单号");
            int X = int.Parse(Console.ReadLine());
            foreach (Order order in L)
            {
                if (order.id == X)
                {
                    Console.WriteLine(order);
                    flag = true;
                    break;
                }

            }
            if (flag == false)
            {
                Console.WriteLine();
                Console.WriteLine("没有此结果！");
                Console.WriteLine();
            }
        }

        public void Modify()
        {
            bool flag = false;
            Console.WriteLine();
            Console.WriteLine("请输入要修改的订单号");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("请输入修改后的客户名");
            string client = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("请输入修改后的商品名");
            string name = Console.ReadLine();
            Order OR = new Order(k, client, name);
            foreach (Order order in L)
            {
                if (order.id == k)
                {
                    order.client = client;
                    order.name = name;
                    flag = true;
                    break;
                }

            }
            if (flag == false)
            {
                Console.WriteLine();
                Console.WriteLine("修改失败！");
                Console.WriteLine();
            }

        }

        public void Show()
        {
            L.Sort();
            foreach (Order order in L) Console.WriteLine(order);
            Console.WriteLine();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderServices OR = new OrderServices();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1添加 2删除 3查找 4修改 5显示所有订单");
                int fun = int.Parse(Console.ReadLine());
                if (fun == 1)
                    OR.Add();
                else if (fun == 2)
                    OR.Delete();
                else if (fun == 3)
                    OR.Search();
                else if (fun == 4)
                    OR.Modify();
                else
                    OR.Show();
            }
        }

    }
}
