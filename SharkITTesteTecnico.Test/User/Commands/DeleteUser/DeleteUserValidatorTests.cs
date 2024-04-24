using FluentValidation.TestHelper;
using Moq;
using SharkITTesteTecnico.Application.Abstractions.Repository;
using SharkITTesteTecnico.Application.UseCases.User.Commands.DeleteUser;

namespace SharkITTesteTecnico.Test.User.Commands;

public class DeleteUserValidatorTests
{
    [Fact]
    public async Task DeleteUserCommand_ShouldNotHaveAnyValidationErrors_WhenValidInfo()
    {
        DeleteUserCommand userCommand = new(Guid.NewGuid());
        DeleteUserCommandValidator userValidor = new();

        var validationResult = await userValidor.TestValidateAsync(userCommand);

        validationResult.ShouldNotHaveAnyValidationErrors();
    }
}
