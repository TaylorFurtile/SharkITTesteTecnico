namespace SharkITTesteTecnico.Infrastructure.Interfaces;

internal interface ISecretManager
{
    string GetRequiredSecret(string key);
}
