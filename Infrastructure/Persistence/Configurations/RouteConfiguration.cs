using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMoon.Domain.Entities;

namespace MyMoon.Infrastructure.Persistence.Configurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).IsRequired(false);

            builder.Property(x => x.Location).HasMaxLength400().IsRequired(true);
            builder.Property(x => x.Destination).HasMaxLength400().IsRequired(true);

            builder.ToTable("Routes");
        }
    }
}
