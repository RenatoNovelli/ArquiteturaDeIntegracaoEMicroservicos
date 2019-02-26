using GeekBurger.Dashboard.Interfaces.Repository;
using GeekBurger.Dashboard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Dashboard.Repository
{
    public class SalesRepository : ISalesRepository
    {
        private DashboardContext _context;

        public SalesRepository(DashboardContext context)
        {
            _context = context;
        }

        public async Task<List<Sales>> GetAll()
        {
            return _context.Sales?
                .ToList();
        }

        public async Task<List<Sales>> GetByInterval(DateTime start, DateTime end)
        {
            return _context.Sales
                .Where(x => x.Date >= start && x.Date < end).ToList();
        }

        public async Task Add(Sales sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

    }
}
