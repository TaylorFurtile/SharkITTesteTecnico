using MediatR;

namespace SharkITTesteTecnico.Application.UseCases.User.Commands.UpdateUser;

public record UpdateUserCommand(Guid Id, string? Username) : IRequest<Unit>;
