using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyMoon.Domain.Entities;
using MyMoon.Domain.Enums;
using MyMoon.Domain.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyMoon.Infrastructure.Persistence
{
    public static class MigrationManager
    {
        public async static Task<IHost> MigrateDatabase(this IHost host)
        {
            //using (var scope = host.Services.CreateScope())
            //{
            //    using (var context = scope.ServiceProvider.GetRequiredService<MyMoonDbContext>())
            //    {
            //        try
            //        {
            //            context.Database.EnsureDeleted();

            //            if (context.Database.IsNpgsql())
            //                context.Database.Migrate();

            //            await SeedData(context);
            //            await Task.FromResult(0);
            //        }
            //        catch (Exception ex)
            //        {
            //            var logger = scope.ServiceProvider.GetRequiredService<ILogger<MyMoonDbContext>>();
            //            logger.LogError(ex, "Error while migrating data!");
            //        }
            //    }
            //}

            return host;
        }
        
        private async static Task SeedData(MyMoonDbContext context)
        {
            if (!context.Users.Any())
            {
                Random random = new Random();

                var firstLastNames = GetFirstLastNames();
                var locations = GetLocations();

                var preferences = GetPreferences().ToList();

                context.AddRange(preferences);

                context.SaveChanges();

                for (int i = 0; i < 100; i++)
                {
                    var firstLastName = firstLastNames[random.Next(firstLastNames.Length)];

                    var location = locations[random.Next(locations.Length)];

                    var destination = GetDestination(location);

                    var user = new User(firstLastName.first, firstLastName.last, (Gender)random.Next(2), null, null);

                    context.Users.Add(user);

                    var depDate = DateTime.Now.AddDays(random.Next(10));
                    var arrivalDate = depDate.AddHours(random.Next(6));

                    var route = new Route(location, destination, depDate, arrivalDate, random.RandomLagguageSize(), user, random.RandomPrice(), random.Next(5));

                    route.WithPreference(preferences.ElementAt(random.Next(4)));

                    context.Set<Route>().Add(route);
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

        #region Utils

        private static IEnumerable<Preference> GetPreferences()
        {
            yield return new Preference("მუსიკა");
            yield return new Preference("მოწევა");
            yield return new Preference("ცხოველები");
            yield return new Preference("გაგრილება");
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

        private static decimal RandomPrice(this Random random)
        {
            var prices = new decimal[] { 5, 10 };
            var index = random.Next(2);
            return prices[index];
        }

        #endregion
    }
}