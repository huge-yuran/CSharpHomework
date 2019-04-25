using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace reorder {
  /// <summary>
  /// OrderService:provide ordering service,
  /// like add order, remove order, query order and so on
  /// 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
  /// </summary>
  class OrderService {

    private List<Order> orderList;
    /// <summary>
    /// OrderService constructor
    /// </summary>
    public OrderService() {
      orderList = new List<Order>();
    }

    /// <summary>
    /// add new order
    /// </summary>
    /// <param name="order">the order will be added</param>
    public void AddOrder(Order order) {
     //orderList.
      foreach (Order o in orderList) {
        if (o.Id.Equals(order.Id)) {
          throw new Exception($"order-{order.Id} is already existed!");
        }
      }
      orderList.Add(order);
      //orderList.ForEach(o=> )
    }

    /// <summary>
    /// query by orderId
    /// </summary>
    /// <param name="orderId">id of the order to find</param>
    /// <returns>List<Order></returns> 
    public Order GetById(uint orderId) {
      foreach (Order o in orderList) {
        if (o.Id == orderId) {
          return o;
        }
      }
      return null;
    }

    /// <summary>
    /// remove order
    /// </summary>
    /// <param name="orderId">id of the order which will be removed</param> 
    public void RemoveOrder(uint orderId) {
      Order order = GetById(orderId);
      if (order == null) return;
      orderList.Remove(order);
    }

    /// <summary>
    /// query all orders
    /// </summary>
    /// <returns>List<Order>:all the orders</returns> 
    public List<Order> QueryAllOrders() {
      return orderList;
    }

   
    /// <summary>
    /// query by goodsName
    /// </summary>
    /// <param name="goodsName">the name of goods in order's orderDetail</param>
    /// <returns></returns> 
    public List<Order> QueryByGoodsName(string goodsName) {
      List<Order> result = new List<Order>();
      foreach (Order order in orderList) {
        foreach (OrderDetail detail in order.Details) {
          if (detail.Goods.Name == goodsName) {
            result.Add(order);
            break;
          }
        }
      }
      return result;
    }

		public List<Order> QueryByGoodsNameLinq(string goodsName)
		{
			List<Order> result = new List<Order>();
			var query = from i in orderList
						from j in i.Details
						where j.Goods.Name == goodsName
						select i;
			return query.ToList();
		}

		/// <summary>
		/// query by customerName
		/// </summary>
		/// <param name="customerName">customer name</param>
		/// <returns></returns> 
		public List<Order> QueryByCustomerName(string customerName) {
			//var query = orderList
			//	  .Where(order => order.Customer.Name == customerName);
			// return query.ToList();

			var query = from i in orderList
						where i.Customer.Name == customerName
						select i;
			return query.ToList();
		}


		public void SortById()
	{
		orderList.Sort();
	}
	
		public void SortByAmount()
		{
			orderList = orderList.OrderByDescending(s => s.Amount).ToList<Order>();
		}

		public void SortByAmountLinq()
		{
			orderList = (from s in orderList orderby s.Amount descending select s).ToList<Order>();
		}

		// 将所有订单序列化为XML文件
		public void Export(string filename)
		{
			XmlSerializer xmls = new XmlSerializer(orderList.GetType());
			try
			{
				using (FileStream fs = new FileStream(filename, FileMode.Create))
				{
					xmls.Serialize(fs, orderList);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("导出为XML文件时出错。错误信息：" + e);
			}
		}

		// 从XML文件中载入订单
		public void Import(string filename)
		{
			XmlSerializer xmls = new XmlSerializer(orderList.GetType());
			try
			{
				using (FileStream fs = new FileStream(filename, FileMode.Open))
				{
					orderList = (List<Order>)xmls.Deserialize(fs);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("从XML文件中载入订单时。出错信息：" + e);
			}
		}
	}
}
