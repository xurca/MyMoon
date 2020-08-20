using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMoon.Domain.Entities;

namespace MyMoon.Infrastructure.Persistence.Configurations
{
    public class RoutePreferenceConfiguration : IEntityTypeConfiguration<RoutePreference>
    {
        public void Configure(EntityTypeBuilder<RoutePreference> builder)
        {
            builder.HasKey(x => new { x.RouteId, x.PreferenceId });
            builder
                .HasOne(x => x.Route)
                .WithMany(x => x.Preferences)
                .HasForeignKey(x => x.RouteId);
            builder
                .HasOne(x => x.Preference)
                .WithMany()
                .HasForeignKey(x => x.PreferenceId);

            builder.ToTable("RoutePreferences");
        }
    }
}
