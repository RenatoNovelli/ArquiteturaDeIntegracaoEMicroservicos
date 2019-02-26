using GeekBurger.Dashboard.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekBurger.Dashboard.Data.Mapping
{
    public class MapUserWithLessOffer : IEntityTypeConfiguration<UserWithLessOffer>
    {
        public void Configure(EntityTypeBuilder<UserWithLessOffer> builder)
        {
            builder.ToTable("UserWithLessOffer");
        }
    }
}
