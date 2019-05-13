namespace project1
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OrderDB : DbContext
    {

        public OrderDB()
            : base("OrderDataBase")
        {
        }
        public DbSet<Order> tb_Order { get; set; }

        public DbSet<OrderDetails> tb_OrderDetails { get; set; }
    }

}