using System;

namespace GeekBurger.Dashboard.Model
{
    public class Sales
    {
        public Guid SaleId { get; set; }
        public Guid StoreId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
