using Microsoft.Extensions.DependencyInjection;

namespace SharkITTesteTecnico.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration
                    .RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly);
            });

            return services;
        }
    }
}
