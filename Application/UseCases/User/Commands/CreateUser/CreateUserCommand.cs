using MediatR;

namespace SharkITTesteTecnico.Application.UseCases.User.Commands.CreateUser;

public record CreateUserCommand(string? Username, string? Email) : IRequest<Guid>;
