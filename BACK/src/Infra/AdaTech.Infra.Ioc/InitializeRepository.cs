using AdaTech.Domain.Interfaces;
using AdaTech.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AdaTech.Infra.Ioc
{
    public static class InitializeRepository
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}