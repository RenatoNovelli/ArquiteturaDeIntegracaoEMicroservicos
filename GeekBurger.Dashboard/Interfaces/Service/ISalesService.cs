using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Models.Enums;

namespace GeekBurger.Dashboard.Interfaces.Service
{
    public interface ISalesService
    {
        ConsolidatedSales GetSales(Interval per, int value);
    }
}
