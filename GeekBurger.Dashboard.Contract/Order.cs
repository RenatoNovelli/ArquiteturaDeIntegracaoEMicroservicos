using System;

namespace GeekBurger.Dashboard.Contract
{
    class Order
    {
        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public string Value { get; set; }
        public DateTime Date { get; set; }
    }
}
