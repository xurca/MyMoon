using MyMoon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyMoon.Domain.Common;

namespace MyMoon.Application.Common.Interfaces
{
    public interface IDbContext
    {
        DbSet<Route> Routes { get; set; }
        DbSet<User> Users { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
    }
}
