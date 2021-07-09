using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMoon.Application.Common.Interfaces;
using MyMoon.Domain.Common;
using MyMoon.Domain.Entities;
using MyMoon.Domain.UserManagement;
using MyMoon.Infrastructure.EventDispatching;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyMoon.Infrastructure.Persistence
{
    public class MyMoonDbContext : DbContext, IDbContext
    {
        public DbSet<User> Users { get; set; }

        IEventDispatcher _eventDispatcher;

        public MyMoonDbContext(DbContextOptions<MyMoonDbContext> options, IEventDispatcher eventDispatcher) : base(options)
        {
            _eventDispatcher = eventDispatcher;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyMoonDbContext).Assembly);

            var types = modelBuilder.Model.GetEntityTypes().Where(x => typeof(AuditableEntity).IsAssignableFrom(x.ClrType));

            foreach (var type in types)
            {
                modelBuilder.Entity(type.ClrType, (b) => b.Property("CreatedBy").HasMaxLength(200));
                modelBuilder.Entity(type.ClrType, (b) => b.Property("LastModifiedBy").HasMaxLength(200));
            }

            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            modelBuilder.Entity<UserToken>().ToTable("UserTokens");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims");

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            DispatchDomainEvents().GetAwaiter().GetResult();
            var res = base.SaveChanges();
            return res;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.Database.BeginTransaction();

            await DispatchDomainEvents();

            var res = await base.SaveChangesAsync(cancellationToken);

            this.Database.CommitTransaction();

            return res;
        }

        private async Task DispatchDomainEvents()
        {
            var domainEventEntities = ChangeTracker.Entries<IAggregateRoot>()
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

        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : Entity
        {
            return base.Set<TEntity>();
        }

        public Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            return SaveChangesAsync(cancellationToken);
        }
    }
}