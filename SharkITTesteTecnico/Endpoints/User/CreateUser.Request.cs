using FastEndpoints;

namespace SharkITTesteTecnico.Api;

public class CreateUserRequest
{
    public string? Username { get; init; }
    public string? Email { get; init; }
};