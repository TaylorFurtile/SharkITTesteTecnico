using FluentValidation.TestHelper;
using Moq;
using SharkITTesteTecnico.Application.Abstractions.Repository;
using SharkITTesteTecnico.Application.UseCases.User.Commands.UpdateUser;

namespace SharkITTesteTecnico.Test.User.Commands;

public class UpdateUserValidatorTests
{
    [Fact]
    public async Task UpdateUserCommand_ShouldNotHaveAnyValidationErrors_WhenValidInfo()
    {
        UpdateUserCommand userCommand = new(Guid.NewGuid(), "Teste User");
        UpdateUserCommandValidator userValidor = new();

        var validationResult = await userValidor.TestValidateAsync(userCommand);

        validationResult.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public async Task UpdateUserCommand_ShouldHaveValidationErrors_WhenInValidInfo()
    {
        Mock<IUserRepository> userRepositoryMock = new();

        UpdateUserCommand userCommand = new(Guid.Empty, "");
        UpdateUserCommandValidator userValidor = new();

        var validationResult = await userValidor.TestValidateAsync(userCommand);

        validationResult.ShouldHaveAnyValidationError();
    }
}
