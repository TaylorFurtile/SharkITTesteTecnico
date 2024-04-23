using MediatR;
using SharkITTesteTecnico.Application.Abstractions.Repository;
using SharkITTesteTecnico.Application.Exceptions;
using Entities = SharkITTesteTecnico.Domain.Entities;

namespace SharkITTesteTecnico.Application.UseCases.User.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository) 
    : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateUserCommandValidator(userRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count != 0)
        {
            throw new BadRequestException("User could not be created.", validationResult.ToDictionary());
        }

        Entities.User user = new()
        {
            Id = Guid.NewGuid(),
            Email = request.Email!,
            Username = request.Username!,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        return await userRepository.Create(user);
    }
}
