using Gap.IPM.Application.Common.Interfaces;
using Gap.IPM.Domain.Entities;
using Gap.IPM.Infrastructure.Persistence;
using Gap.IPM.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace Gap.IPM.ApplicationUnitTest.Common
{
    public class IPMDabaseContextFactory
    {
        public static ApplicationInsurancePolicyDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationInsurancePolicyDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var currentUserService = new CurrentUserServiceTest();
            var datime = new DateTimeService();

            var context = new ApplicationInsurancePolicyDbContext(options,currentUserService, datime);

            context.Database.EnsureCreated();

            context.Customer.AddRange(new[] {
                new Gap.IPM.Domain.Entities.Customer {  
                    CustomerId = "1234567",
                    FirstName = "Mauricio",
                    LastName = "Ramirez",
                    Address = "Avenida simpre viva 742",
                    Phone = "3001234567",
                    City = "Springfield",
                    Region = "Unknown",
                    Country = "United States",
                    PostalCode = "055450" 
                }
            });


            context.SaveChanges();

            return context;
        }
        public static void Destroy(ApplicationInsurancePolicyDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
