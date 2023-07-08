using AdaTech.Application.Card;
using Microsoft.Extensions.DependencyInjection;

namespace AdaTech.Infra.Ioc
{
    public static class InitializeMediator
    {
        public static IServiceCollection RegisterMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>cfg.RegisterServicesFromAssembly(typeof(CardHandler).Assembly));
            return services;
        }
    }
}
