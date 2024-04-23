using FastEndpoints;
using MediatR;
using SharkITTesteTecnico.Application.UseCases.User.Commands.UpdateUser;

namespace SharkITTesteTecnico.Api.Endpoints.User;

public class UpdateUser(ISender sender) : Endpoint<UpdateUserRequest, Unit>
{
    public override void Configure()
    {
        Put("/api/users/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateUserRequest req, CancellationToken ct)
    {
        await sender.Send(new UpdateUserCommand(req.Id, req.Username), ct);

        await SendNoContentAsync(ct);
    }
}
