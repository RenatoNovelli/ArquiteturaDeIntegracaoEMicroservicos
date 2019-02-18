using System;

namespace GeekBurger.Dashboard.Contract
{
    public class ConsolidatedSales
    {
        public Guid StoredId { get; set; }
        public int Total { get; set; }
        public decimal Value { get; set; }
    }
}
