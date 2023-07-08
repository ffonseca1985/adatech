using AdaTech.Domain.Interfaces;
using AdaTech.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdaTech.Infra.Ioc
{
    public static class InitializeRepository
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("AdaTech"));

            return services;
        }
    }
}