using System;
using System.ComponentModel.DataAnnotations;

namespace GeekBurger.Dashboard.Model
{
    public class Sales
    {
        [Key]
        public Guid SaleId { get; set; }
        public Guid StoreId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
