﻿using Microsoft.EntityFrameworkCore;
using MyMoon.Application.Common.Interfaces;
using MyMoon.Domain.Common;
using MyMoon.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyMoon.Infrastructure.Persistence
{
    public class MyMoonDbContext : DbContext, IDbContext
    {
        IEventDispatcher _eventDispatcher;

        public DbSet<Route> Routes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        public MyMoonDbContext(DbContextOptions<MyMoonDbContext> options, IEventDispatcher eventDispatcher) : base(options)
        {
            _eventDispatcher = eventDispatcher;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyMoonDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            _preSaveChanges().GetAwaiter().GetResult();
            var res = base.SaveChanges();
            return res;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _preSaveChanges();
            var res = await base.SaveChangesAsync(cancellationToken);
            return res;
        }

        private async Task _preSaveChanges()
        {
            await _dispatchDomainEvents();
        }

        private async Task _dispatchDomainEvents()
        {
            var domainEventEntities = ChangeTracker.Entries<IEntity>()
                .Select(po => po.Entity)
                .Where(po => po.Events.Any())
                .ToArray();

            foreach (var entity in domainEventEntities)
            {
                foreach (var @event in entity.Events)
                {
                    await _eventDispatcher.DispatchAsync(@event);
                }
            }
        }
    }
}