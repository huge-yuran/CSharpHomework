using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Xsl;
using System.Data.Entity;

namespace project1
{
    public class OrderService
    {
        public void AddOrder(Order order)
        {
            using(var db = new OrderDB())
            {
                db.tb_Order.Add(order);
                db.SaveChanges();
            }
        }
        public void DeleteByID(String id)
        {
            using(var db = new OrderDB())
            {
                var order = db.tb_Order.Include("Items").SingleOrDefault(m => m.ID == id);
                db.tb_OrderDetails.RemoveRange(order.Items);   //还需要删除 items 的内容
                db.tb_Order.Remove(order);
                db.SaveChanges();
            }
        }
        public void Update(Order order)
        {
            using (var db = new OrderDB())
            {
                db.tb_Order.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                order.Items.ForEach(item => db.Entry(item).State = EntityState.Modified);
                db.SaveChanges();
            }
        }
        public List<Order> SearchAllOrders()
        {
            using (var db = new OrderDB())
            {
                return db.tb_Order.Include("Items").ToList<Order>();
            }
        }
        public List<Order> SearchOrderbyID(string temp)
        {
            using (var db = new OrderDB())
            {
                return db.tb_Order.Include("Items").Where(m => m.ID == temp).ToList();
            }
        }
        public List<Order> SearchOrderbyName(string temp)
        {
            using (var db = new OrderDB())
            {
                return db.tb_Order.Include("Items").Where(m => m.Name == temp).ToList<Order>();
            }
        }
        public List<Order> SearchPriceLessThan(double temp)
        {
            using (var db = new OrderDB())
            {
                return db.tb_Order.Include("Items").Where(m => m.TotalPrice <= temp).ToList<Order>();
            }
        }
        public List<Order> SearchPriceMoreThan(double temp)
        {
            using (var db = new OrderDB())
            {
                return db.tb_Order.Include("Items").Where(m => m.TotalPrice >= temp).ToList<Order>();
            }
        }
        public List<Order> SearchOrderbyItem(string temp)
        {
            using (var db = new OrderDB())
            {
                var query =  db.tb_Order.Include("Items").Where(m => m.Items.Where
                (n => n.Item == temp).Count() > 0);
                return query.ToList<Order>();
            }
        }
        public static void XmlSerialize(XmlSerializer ser, string fileName, object obj)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            ser.Serialize(fs, obj);
            fs.Close();
        }
        public void Export(string fileName)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            ///XmlSerialize(xmlser, fileName, orders);
            XmlSerialize(xmlser, fileName, SearchAllOrders());
            string xml = File.ReadAllText(fileName);
        }
        //public void Import(string fileName)
        //{
        //    XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
        //    FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        //    orders = xmlser.Deserialize(fileStream)
        //        as List<Order>;
        //    fileStream.Close();
        //}
        public List<Order> Import1(string fileName)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            List<Order> orders = new List<Order>();
            orders = xmlser.Deserialize(fileStream)
                as List<Order>;
            fileStream.Close();
            return orders;
        }
        public void XmlToHtml(string fileName)
        {
            XslCompiledTransform trans = new XslCompiledTransform();
            
            trans.Load(@"..\..\OrderTest.xsl");
            trans.Transform(@"..\..\Order.xml", fileName);
        }
    }
}