using Npgsql;
using Microsoft.Extensions.Configuration;
using SharkITTesteTecnico.Infrastructure.Interfaces;

namespace SharkITTesteTecnico.Infrastructure;

public class SecretManager(IConfiguration configuration) : ISecretManager
{
    public string GetRequiredSecret(string key)
    {
        string? secret = Environment.GetEnvironmentVariable("DEFAULTDB_CONNECTION_STRING") ?? configuration[key];

        ArgumentNullException.ThrowIfNull(secret, nameof(secret));

        return secret;
    }
}
