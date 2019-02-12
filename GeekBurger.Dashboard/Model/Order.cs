using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Dashboard.Model
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public int StoreId { get; set; }
        public decimal Total { get; set; }
        public List<Product> Products { get; set; }
        public int[] ProductionIds { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
    }
}
