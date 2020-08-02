using Microsoft.EntityFrameworkCore;
using MyMoon.Application.Common.Interfaces;
using MyMoon.Domain.Entities;

namespace MyMoon.Infrastructure.Persistence
{
    public class MyMoonDbContext : DbContext, IDbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        public MyMoonDbContext(DbContextOptions<MyMoonDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyMoonDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}