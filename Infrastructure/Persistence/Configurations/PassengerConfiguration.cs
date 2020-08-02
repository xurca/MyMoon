using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMoon.Domain.Entities;

namespace MyMoon.Infrastructure.Persistence.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength200().IsRequired(true);
            builder.Property(x => x.LastName).HasMaxLength200().IsRequired(true);
            builder.Property(x => x.UserId).HasMaxLength200();

            builder.ToTable("Passengers");
        }
    }
}
