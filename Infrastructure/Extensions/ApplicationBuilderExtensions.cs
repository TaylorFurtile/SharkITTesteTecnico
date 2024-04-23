using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SharkITTesteTecnico.Infrastructure.Interfaces;

namespace SharkITTesteTecnico.Infrastructure.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseDefaultDatabaseSeeders(this IApplicationBuilder builder)
    {
        var scope = builder.ApplicationServices.CreateScope();

        var seeders = scope.ServiceProvider.GetServices<IDatabaseSeeder>();

        foreach (var seeder in seeders)
            seeder.Seed();

        return builder;
    }
}
