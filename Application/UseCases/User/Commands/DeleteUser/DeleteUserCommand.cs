using MediatR;

namespace SharkITTesteTecnico.Application.UseCases.User.Commands.DeleteUser;

public record DeleteUserCommand(Guid Id) : IRequest<Unit>;
