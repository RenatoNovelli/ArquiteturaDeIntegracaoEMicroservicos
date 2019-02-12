using System;

namespace GeekBurger.Dashboard.Model
{
    public class Sale
    {
        public Guid SaleId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
