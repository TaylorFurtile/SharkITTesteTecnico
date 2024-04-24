using FastEndpoints;
using MediatR;
using SharkITTesteTecnico.Application.UseCases.User.Commands.CreateUser;

namespace SharkITTesteTecnico.Api.Endpoints.User;

public class CreateUser(ISender sender) : Endpoint<CreateUserRequest, Guid>
{
    public override void Configure()
    {
        Post("/api/users");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        Guid id = await sender.Send(new CreateUserCommand(req.Username, req.Email), ct);

        await SendOkAsync(id, ct);
    }
}
