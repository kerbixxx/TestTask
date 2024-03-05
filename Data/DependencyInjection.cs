using Business.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SQLite");
            services.AddDbContext<DataDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IDataDbContext>(provider => provider.GetService<DataDbContext>());
            return services;
        }
    }
}
