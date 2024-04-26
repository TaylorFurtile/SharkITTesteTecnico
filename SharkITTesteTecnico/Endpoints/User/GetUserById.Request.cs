using FastEndpoints;
using Microsoft.AspNetCore.Mvc;

namespace SharkITTesteTecnico.Api;

public class GetUserByIdRequest
{
    [BindFrom("id")]
    [FromRoute(Name = "id")]
    public Guid Id { get; set; }
}