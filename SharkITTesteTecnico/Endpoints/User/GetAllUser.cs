using FastEndpoints;
using MediatR;
using SharkITTesteTecnico.Application.UseCases.User.Queries.GetAllUser;
using Entities = SharkITTesteTecnico.Domain.Entities;

namespace SharkITTesteTecnico.Api.Endpoints.User;

public class GetAllUser(ISender sender) : EndpointWithoutRequest<List<Entities.User>>
{
    public override void Configure()
    {
        Get("/api/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var results = await sender.Send(new GetAllUserQuery(), ct);

        await SendOkAsync(results, ct);
    }
}
