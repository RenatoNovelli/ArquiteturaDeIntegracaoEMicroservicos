using GeekBurger.Dashboard.Contract;
using GeekBurger.Dashboard.Data.Mapping;
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

        public DbSet<UserWithLessOffer> UserWithLessOffer { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MapSales());
            modelBuilder.ApplyConfiguration(new MapUserWithLessOffer());

            base.OnModelCreating(modelBuilder);
        }
    }
}
