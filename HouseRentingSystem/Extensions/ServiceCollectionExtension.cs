
using HouseRentingSystem.Infrastructurea.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationsServices(this IServiceCollection service )
        {
            return service;
        }
        public static IServiceCollection AddApplicationsDbContext(this IServiceCollection services, IConfiguration confic)
        {
            var connectionString = confic.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
        public static IServiceCollection AddApplicationsIdentity(this IServiceCollection services, IConfiguration confic)
        {
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;

                })
    .AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }
    }

}
