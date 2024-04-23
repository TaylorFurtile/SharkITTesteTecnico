using FastEndpoints;
using MediatR;
using SharkITTesteTecnico.Application.UseCases.User.Queries.GetUserById;
using Entities = SharkITTesteTecnico.Domain.Entities;

namespace SharkITTesteTecnico.Api.Endpoints.User;

public class GetUserById(ISender sender) : Endpoint<GetUserByIdRequest, Entities.User>
{
    public override void Configure()
    {
        Get("api/users/{id}");
        DontThrowIfValidationFails();
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetUserByIdRequest req, CancellationToken ct)
    {
        var result = await sender.Send(new GetUserByIdQuery(req.Id), ct);

        await SendOkAsync(result, ct);
    }
}
