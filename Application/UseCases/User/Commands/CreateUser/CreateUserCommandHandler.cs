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
        var formattedRequest = request with
        {
            Email = request.Email?.ToLower()
        };

        var validator = new CreateUserCommandValidator(userRepository);
        var validationResult = await validator.ValidateAsync(formattedRequest, cancellationToken);

        if (validationResult.Errors.Count != 0)
        {
            throw new BadRequestException("User could not be created.", validationResult.ToDictionary());
        }

        Entities.User user = new()
        {
            Id = Guid.NewGuid(),
            Email = formattedRequest.Email!,
            Username = formattedRequest.Username!,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };

        await userRepository.Create(user);

        return user.Id;
    }
}
