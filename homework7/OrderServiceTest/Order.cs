using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {
    /// <summary>
    /// Order class : all orderDetails
    /// to record each goods and its quantity in this ordering
    /// </summary>
    class Order:IComparable{
        private List<OrderDetail> details=new List<OrderDetail>();
        /// <summary>
        /// Order constructor
        /// </summary>
        /// <param name="orderId">order id</param>
        /// <param name="customer">who orders goods</param>
        public Order(uint orderId, Customer customer) {
            Id = orderId;
            Customer = customer;
        }
        /// <summary>
        /// order id
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// the man who orders goods
        /// </summary>
        public Customer Customer { get; set; }
        public double totalValue
        {
            get
            {
                double sum = 0;
               foreach (OrderDetail k in Details)
                  sum += k.orderDetailValue;
                return sum;
                    
            }
        }
        public List<OrderDetail> Details {
            get =>this.details; }

        /// <summary>
        /// add new orderDetail to order
        /// </summary>
        /// <param name="orderDetail">the new orderDetail which will be added</param>
        public void AddDetails(OrderDetail orderDetail) {
            if (this.Details.Contains(orderDetail))  {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            details.Add(orderDetail);
        }
        public int CompareTo(object obj) //实现接口,将当前实例与同一类型的另一个对象进行比较，并返回一个整数，该整数指示当前实例在排序顺序中的位置是位于另一个对象之前、之后还是与其位置相同。
        {
            Order orderCompared = (Order)obj;
            if (this.Id < orderCompared.Id)
                return -1;
            else if (this.Id > orderCompared.Id)
                return 1;
            else
                return 0;
        }
        /// <summary>
        /// remove orderDetail by orderDetailId from order
        /// </summary>
        /// <param name="orderDetailId">id of the orderDetail which will be removed</param>
        public void RemoveDetails(uint orderDetailId) {
            details.RemoveAll(d =>d.Id==orderDetailId);
        }
        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>string:message of the Order object</returns>
        public override string ToString() {
            String result = $"orderId:{Id}, customer:({Customer})";
            details.ForEach(detail => result += "\n\t" + detail);
            return result;
        }
    }
}