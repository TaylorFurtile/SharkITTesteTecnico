using FastEndpoints;
using MediatR;
using SharkITTesteTecnico.Application.UseCases.User.Commands.DeleteUser;

namespace SharkITTesteTecnico.Api.Endpoints.User;

public class DeleteUser(ISender sender) : Endpoint<DeleteUserRequest, Unit>
{
    public override void Configure()
    {
        Delete("/api/users/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteUserRequest req, CancellationToken ct)
    {
        await sender.Send(new DeleteUserCommand(req.Id), ct);

        await SendNoContentAsync(ct);
    }
}
