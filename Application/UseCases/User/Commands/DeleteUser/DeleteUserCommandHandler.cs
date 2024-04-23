using MediatR;
using SharkITTesteTecnico.Application.Abstractions.Repository;
using SharkITTesteTecnico.Application.Exceptions;
using Entities = SharkITTesteTecnico.Domain.Entities;

namespace SharkITTesteTecnico.Application.UseCases.User.Commands.DeleteUser;

public class DeleteUserCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, Unit>
{
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteUserCommandValidator();
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

        await userRepository.Delete(user.Id);

        return Unit.Value;
    }
}
