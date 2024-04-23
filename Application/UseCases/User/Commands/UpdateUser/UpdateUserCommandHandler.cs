using MediatR;
using SharkITTesteTecnico.Application.Abstractions.Repository;
using SharkITTesteTecnico.Application.Exceptions;
using Entities = SharkITTesteTecnico.Domain.Entities;

namespace SharkITTesteTecnico.Application.UseCases.User.Commands.UpdateUser;

public class UpdateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateUserCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count != 0)
        {
            throw new BadRequestException("User could not be created.", validationResult.ToDictionary());
        }

        Entities.User? user = await userRepository.GetById(request.Id);

        if (user == null)
        {
            throw new NotFoundException(nameof(Entities.User));
        }

        user.Username = request.Username!;

        await userRepository.Update(user);

        return Unit.Value;
    }
}
