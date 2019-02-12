using GeekBurger.Dashboard.Contract;

namespace GeekBurger.Dashboard.Interfaces.Service
{
    public interface ISalesService
    {
        Sales GetSales();
        Sales GetSalesByInterval(string per, int value);
    }
}
