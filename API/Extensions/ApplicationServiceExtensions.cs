using API.Data;
using API.Interfaces;
using API.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        // Everything Service related goes here
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Service implements Interface methods
            services.AddScoped<ITokenService, TokenService>();
            // Adding DataContext.cs on Startup services
            services.AddDbContext<DataContext>(options =>
            // Lambda expression (used to pass expressions as parameters)
            {
                // Accessing database through connectionString....
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        } 
    }
}