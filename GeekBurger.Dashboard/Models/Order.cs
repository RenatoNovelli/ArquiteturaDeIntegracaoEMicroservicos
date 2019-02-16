using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Dashboard.Model
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid StoreId { get; set; }
        public decimal Total { get; set; }
        public List<Product> Products { get; set; }
        public Guid[] ProductionIds { get; set; }
    }

    public class Product
    {
        public Guid ProductId { get; set; }
    }
}
