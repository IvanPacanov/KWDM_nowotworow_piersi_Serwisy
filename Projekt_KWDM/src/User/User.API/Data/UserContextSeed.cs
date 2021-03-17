using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.API.Data
{
    public class UserContextSeed
    {
        public static async Task SeedAsync(UserContext userContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                // INFO: Run this if using a real database. Used to automaticly migrate docker image of sql server db.
                userContext.Database.Migrate();
                //orderContext.Database.EnsureCreated();

                if (!userContext.User.Any())
                {
                    userContext.User.AddRange(GetPreconfiguredOrders());
                    await userContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 3)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<UserContextSeed>();
                    log.LogError(exception.Message);
                    System.Threading.Thread.Sleep(2000);
                    await SeedAsync(userContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<Entities.User> GetPreconfiguredOrders()
        {
            return new List<Entities.User>()
            {
                new Entities.User() { UserName = "Admin", Password = "Admin" },
                new Entities.User() { UserName = "Guest", Password = "Guest"}
            };
        }
    }
}
