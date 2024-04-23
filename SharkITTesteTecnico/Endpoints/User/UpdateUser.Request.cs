using FastEndpoints;

namespace SharkITTesteTecnico.Api;

public class UpdateUserRequest {
    [BindFrom("id")]
    public Guid Id { get; init; }
    public string? Username { get; init; }
}