using FastEndpoints;

namespace SharkITTesteTecnico.Api;

public class GetUserByIdRequest
{
    [BindFrom("id")]
    public Guid Id { get; set; }
}