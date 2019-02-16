using GeekBurger.Dashboard.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekBurger.Dashboard.Repository
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options)
           : base(options)
        {
        }

        public DbSet<Sales> Sales { get; set; }
    }
}
