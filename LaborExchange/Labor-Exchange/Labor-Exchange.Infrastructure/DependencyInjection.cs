using Microsoft.Extensions.DependencyInjection;
using Labor_Exchange.Infrastructure.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Labor_Exchange.Application.IRepositories;
using Labor_Exchange.Infrastructure.Repositories;
using Labor_Exchange.Application.IServices;
using Labor_Exchange.Infrastructure.Services;

namespace Labor_Exchange.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<EFContext>(options =>
                options.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = LaborExchangeDB; Trusted_Connection = True;")
            );

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IItemsServices, Service>();

            return services;
        }
    }
}
