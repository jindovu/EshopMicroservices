using Ordering.Application.Data;
using Ordering.Infrastructure.Intercepters;

namespace Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            //Add services to the container.
            services.AddScoped<ISaveChangesInterceptor, AuditableEntityIntercepter>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsIntercepter>();

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetService<ISaveChangesInterceptor>());
                options.UseSqlServer(connectionString);
            });

            //services
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            return services;
        }
    }
}
