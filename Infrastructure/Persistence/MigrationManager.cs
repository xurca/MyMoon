using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyMoon.Domain.Entities;
using MyMoon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMoon.Infrastructure.Persistence
{
    public static class MigrationManager
    {
        public async static Task<IHost> MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<MyMoonDbContext>())
                {
                    try
                    {
                        if (context.Database.IsNpgsql())
                            context.Database.Migrate();

                        await SeedData(context);
                    }
                    catch (Exception ex)
                    {
                        var logger = scope.ServiceProvider.GetRequiredService<ILogger<MyMoonDbContext>>();
                        logger.LogError(ex, "Error while migrating data!");
                    }
                }
            }

            return host;
        }

        private async static Task SeedData(MyMoonDbContext context)
        {
            if (!context.Passengers.Any())
            {
                Random random = new Random();

                var firstLastNames = GetFirstLastNames();
                var locations = GetLocations();

                for (int i = 0; i < 100; i++)
                {
                    var firstLastName = firstLastNames[random.Next(firstLastNames.Length)];

                    var location = locations[random.Next(locations.Length)];

                    var destination = GetDestination(location);

                    var passenger = new Passenger(firstLastName.first, firstLastName.last, random.RandomStar(), random.RandomIsRental(), null);

                    passenger.Id = i + 1;

                    context.Passengers.Add(passenger);

                    var route = new Route(location, destination, DateTime.Now.AddDays(random.Next(10)), random.RandomLagguageSize(), passenger.Id);

                    context.Routes.Add(route);
                }

                await context.SaveChangesAsync();

                string GetDestination(string loc)
                {
                    string dest;

                    do
                    {
                        dest = locations[random.Next(locations.Length)];
                    }
                    while (dest == loc);

                    return dest;
                }
            }
        }

        private static (string first, string last)[] GetFirstLastNames()
        {
            return new (string first, string last)[]
            {
                ("dato", "khurtsidze"),
                ("levan", "tavartkiladze"),
                ("dito", "orkodashvili"),
                ("maka", "zurabishvili"),
                ("nino", "sudadze"),
                ("sopho", "taniashvili"),
                ("nini", "nadareishvili"),
                ("valera", "gviniashvili")
            };
        }

        private static string[] GetLocations()
        {
            return new string[]
            {
                "Tbilisi",
                "Kvariati",
                "Batumi",
                "Khashuri",
                "Kutaisi",
                "Borjomi",
                "Bakuriani",
                "Rustavi"
            };
        }

        private static int RandomStar(this Random random)
        {
            return random.Next(0, 6);
        }

        private static bool RandomIsRental(this Random random)
        {
            return random.Next(100) < 50;
        }

        private static LagguageSize? RandomLagguageSize(this Random random)
        {
            var size = random.Next(4);

            return size == 3 ? (LagguageSize?)null : (LagguageSize)size;
        }
    }
}
//using (var scope = host.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;

//    try
//    {
//        var context = services.GetRequiredService<ApplicationDbContext>();

//        if (context.Database.IsSqlServer())
//        {
//            context.Database.Migrate();
//        }

//        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

//        await ApplicationDbContextSeed.SeedDefaultUserAsync(userManager);
//        await ApplicationDbContextSeed.SeedSampleDataAsync(context);
//    }
//    catch (Exception ex)
//    {
//        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

//        logger.LogError(ex, "An error occurred while migrating or seeding the database.");

//        throw;
//    }
//}