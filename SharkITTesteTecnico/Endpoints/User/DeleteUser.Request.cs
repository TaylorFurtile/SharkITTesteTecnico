using FastEndpoints;

namespace SharkITTesteTecnico.Api;

public class DeleteUserRequest {
    [BindFrom("id")] 
    public Guid Id { get; init; }
};