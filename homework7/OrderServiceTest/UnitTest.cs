using Microsoft.VisualStudio.TestTools.UnitTesting;
using ordertest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest.UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        OrderService os = new OrderService();

        [TestMethod]
        //≤‚ ‘AddOrder
        public void AddOrderTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Order order1 = new Order(100, customer1);
            os.AddOrder(order1);
            List<Order> orderLIst = os.QueryAllOrders();
            Assert.AreEqual(orderLIst[0].Customer.Name, "Customer1");
            Assert.AreEqual((int)orderLIst[0].Customer.Id, 1);
            Assert.AreEqual((int)orderLIst[0].Id, 100);
        }

        [TestMethod]
        //≤‚ ‘RemoveOrder
        public void RemoveOrderTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Order order1 = new Order(100, customer1);
            os.AddOrder(order1);
            List<Order> orderLIst = os.QueryAllOrders();
            os.RemoveOrder(100);
            Assert.IsTrue(orderLIst.Count == 0);
        }

        [TestMethod]
        //≤‚ ‘QueryAllOrders
        public void QueryAllOrdersTest()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Order order1 = new Order(100, customer1);
            os.AddOrder(order1);
            List<Order> orderLIst = os.QueryAllOrders();
            Assert.AreEqual(orderLIst[0].Customer.Name, "Customer1");
            Assert.AreEqual((int)orderLIst[0].Customer.Id, 1);
            Assert.AreEqual((int)orderLIst[0].Id, 100);
        }

        [TestMethod]
        //≤‚ ‘QueryByGoodsName
        public void QueryByGoodsNameTest()
        {
            List<Order> orderList = os.QueryAllOrders();
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Order order1 = new Order(100, customer1);
            Order order2 = new Order(101, customer2);
            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails3);
            order2.AddDetails(orderDetails2);
            os.AddOrder(order1);
            os.AddOrder(order2);
            orderList = os.QueryByGoodsName("Milk");
            Assert.AreEqual((int)orderList[0].Id, 100);
            Assert.IsTrue((int)orderList[0].Customer.Id == 1);
            
        }

        [TestMethod]
        //≤‚ ‘ QueryByCustomerName
        public void QueryByCustomerNameTest()
        {
            List<Order> orderList = os.QueryAllOrders();
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Order order1 = new Order(100, customer1);
            Order order2 = new Order(101, customer2);
            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails3);
            order2.AddDetails(orderDetails2);
            os.AddOrder(order1);
            os.AddOrder(order2);
            orderList = os.QueryByCustomerName("Customer2");
            Assert.AreEqual((int)orderList[0].Id, 101);
            Assert.IsTrue((int)orderList[0].Customer.Id == 2);

        }
    }
}