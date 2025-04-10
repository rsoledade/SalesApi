using SalesApi.Application.Services;
using SalesApi.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace SalesApi.Application.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IEventPublisher, ConsoleEventPublisher>();
            return services;
        }
    }
}
