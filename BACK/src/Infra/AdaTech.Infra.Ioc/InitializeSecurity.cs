using AdaTech.Infra.Data.Repository.Seeds;
using AdaTech.Infra.Security;
using Microsoft.Extensions.DependencyInjection;

namespace AdaTech.Infra.Ioc
{
    public static class InitializeSecurity
    {
        public static IServiceCollection RegisterSecurity(this IServiceCollection services)
        {
            services.AddTransient<TokenService>();
            services.AddTransient<UserSeeder>();

            services.BuildServiceProvider().GetService<UserSeeder>()!.Seed();
            return services;
        }
    }
}
