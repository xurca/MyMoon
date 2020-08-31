using MyMoon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyMoon.Domain.Common;
using System.Threading.Tasks;
using System.Threading;

namespace MyMoon.Application.Common.Interfaces
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
        Task<int> SaveAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
