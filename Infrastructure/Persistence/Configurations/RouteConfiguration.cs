using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMoon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Infrastructure.Persistence.Configurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasOne(x => x.Passenger).WithMany().HasForeignKey(x => x.PassengerId).IsRequired(false);

            builder.Property(x => x.Location).HasMaxLength400().IsRequired(true);
            builder.Property(x => x.Destination).HasMaxLength400().IsRequired(true);

            builder.ToTable("Routes");
        }
    }
}
