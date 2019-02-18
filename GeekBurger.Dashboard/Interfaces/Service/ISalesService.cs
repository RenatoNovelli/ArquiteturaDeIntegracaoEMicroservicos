using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Models.Enums;
using GeekBurger.Orders.Contract.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekBurger.Dashboard.Interfaces.Service
{
    public interface ISalesService
    {
        Task<IEnumerable<ConsolidatedSales>> GetSales(Interval? per, int? value);
        Task SaveSale(OrderChangedMessage order);
    }
}
