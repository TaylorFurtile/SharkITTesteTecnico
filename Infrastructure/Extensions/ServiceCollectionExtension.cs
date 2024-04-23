using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using SharkITTesteTecnico.Application.Abstractions.Repository;
using SharkITTesteTecnico.Infrastructure.Data.Context;
using SharkITTesteTecnico.Infrastructure.Data.Repositories;
using SharkITTesteTecnico.Infrastructure.Data.Seeders;
using SharkITTesteTecnico.Infrastructure.Interfaces;

namespace SharkITTesteTecnico.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddSecretManager(this IServiceCollection services)
    {
        services.AddSingleton<ISecretManager, SecretManager>();
          
        return services;
    }

    public static IServiceCollection AddDefaultDatabase(this IServiceCollection services)
    {
        services.AddDbContext<EFDefaultDbContext>();

        return services;
    }

    public static IServiceCollection AddDefaultDatabaseRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();

        return services;
    }

    public static IServiceCollection AddDefaultDatabaseSeeders(this IServiceCollection services)
    {
        services.AddScoped<IDatabaseSeeder, UserSeeder>();

        return services;
    }
}
