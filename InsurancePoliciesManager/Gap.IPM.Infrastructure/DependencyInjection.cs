using Gap.IPM.Application.Common.Interfaces;
using Gap.IPM.Infrastructure.Identity;
using Gap.IPM.Infrastructure.Persistence;
using Gap.IPM.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gap.IPM.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationIndentityDbContext>(options =>
                    options.UseInMemoryDatabase("GapIPMIdentityMDB"));
                services.AddDbContext<ApplicationInsurancePolicyDbContext>(options =>
                   options.UseInMemoryDatabase("GapIPMDB"));
            }
            else
            {
                services.AddDbContext<ApplicationIndentityDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("IPMIdentityDbConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationIndentityDbContext).Assembly.FullName)));
                services.AddDbContext<ApplicationInsurancePolicyDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("IPMDbConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationInsurancePolicyDbContext).Assembly.FullName)));
            }

            services.AddScoped<IApplicationInsurancePolicyDbContext>(provider => provider.GetService<ApplicationInsurancePolicyDbContext>());
            
            services.AddDefaultIdentity<ApplicationUser>()
                   .AddEntityFrameworkStores<ApplicationIndentityDbContext>();
            
            services.AddIdentityServer()
               .AddApiAuthorization<ApplicationUser, ApplicationIndentityDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication()
               .AddIdentityServerJwt();

            return services;

        }
    }
}
