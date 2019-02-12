using System;

namespace GeekBurger.Dashboard.Model
{
    public class Sales
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
