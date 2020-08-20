using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMoon.Domain.Entities;

namespace MyMoon.Infrastructure.Persistence.Configurations
{
    public class PreferenceConfiguration : IEntityTypeConfiguration<Preference>
    {
        public void Configure(EntityTypeBuilder<Preference> builder)
        {
            builder.Property(x => x.Name).HasMaxLength400().IsRequired(true);

            builder.ToTable("Preferences");
        }
    }
}
