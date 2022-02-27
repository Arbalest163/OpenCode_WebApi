using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AccessControlService.Application.Interfaces;

namespace AccessControlService.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence
            (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<AccessControlDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IAccessControlDbContext>(provider =>
                provider.GetService<AccessControlDbContext>());
            return services;
        }
    }
}
