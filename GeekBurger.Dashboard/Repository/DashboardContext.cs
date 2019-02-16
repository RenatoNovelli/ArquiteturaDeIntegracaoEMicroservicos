using GeekBurger.Dashboard.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekBurger.Dashboard.Repository
{
    public class DashboardContext : DbContext
    {
        public DashboardContext(DbContextOptions<DashboardContext> options)
           : base(options)
        {
        }

        public DbSet<Sales> Sales { get; set; }
    }
}
