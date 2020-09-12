using Gap.IPM.Domain.Entities;
using Gap.IPM.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Gap.IPM.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Administrator1!");
            }
        }

        //TODO create seed for Gap Insurance Application
        public static async Task SeedSampleDataAsync(ApplicationInsurancePolicyDbContext context)
        {
            await SeedCoverageTypeAsync(context);
            await SeedCustomerTypeAsync(context);
        }


        private static async Task SeedCoverageTypeAsync(ApplicationInsurancePolicyDbContext context)
        {
            if (!context.CoverageType.Any())
            {
                context.CoverageType.Add(new CoverageType {CoverageTypeName = "Terremoto" });
                context.CoverageType.Add(new CoverageType {CoverageTypeName = "Incendio" });
                context.CoverageType.Add(new CoverageType {CoverageTypeName = "Robo" });
                context.CoverageType.Add(new CoverageType {CoverageTypeName = "Pérdida" });

                await context.SaveChangesAsync();
            }
        }
        private static async Task SeedCustomerTypeAsync(ApplicationInsurancePolicyDbContext context)
        {
            if (!context.Customer.Any())
            {
                context.Customer.Add(new Customer
                {
                    CustomerId = "71123456",
                    FirstName = "Mauricio",
                    LastName = "Ramirez",
                    Address = "Avenida simpre viva 742",
                    Phone = "3001234567",
                    City = "Springfield",
                    Region = "Unknown",
                    Country = "United States",
                    PostalCode = "055450"
                });
                await context.SaveChangesAsync();
            }
           
        }
    }
}
