using MyMoon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MyMoon.Application.Common.Interfaces
{
    public interface IDbContext
    {
        DbSet<Route> Routes { get; set; }
        DbSet<Passenger> Passengers { get; set; }
    }
}
