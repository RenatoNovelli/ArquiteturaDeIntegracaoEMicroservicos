using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Models.Enums;
using System.Collections.Generic;

namespace GeekBurger.Dashboard.Interfaces.Service
{
    public interface ISalesService
    {
        IEnumerable<ConsolidatedSales> GetSales(Interval? per, int? value);
        bool SaveSale();
    }
}
