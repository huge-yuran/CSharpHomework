using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ordertest {
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

			public void SortById()
			{
				orderList.Sort();
			}

			public void SortByMoney()
			{
				orderList.OrderBy(Order => Order.totalValue);
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
        public List<Order> QueryByCustomerName(string customerName) {
			var query = orderList.Where(order => order.Customer.Name == customerName);
			return query.ToList();
		}
    }
}