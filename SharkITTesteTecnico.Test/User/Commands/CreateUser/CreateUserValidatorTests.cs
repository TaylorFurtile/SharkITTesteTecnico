using FluentValidation.Results;
using FluentValidation.TestHelper;
using Moq;
using SharkITTesteTecnico.Application.Abstractions.Repository;
using SharkITTesteTecnico.Application.UseCases.User.Commands.CreateUser;

namespace SharkITTesteTecnico.Test.User.Commands.CreateUser;

public class CreateUserValidatorTests
{
    [Fact]
    public async Task CreateUserCommand_ShouldNotHaveAnyValidationErrors_WhenValidInfo()
    {
        Mock<IUserRepository> userRepositoryMock = new();

        userRepositoryMock.Setup(x =>
            x.IsEmailUnique(It.IsAny<string>())
        ).ReturnsAsync(true);

        CreateUserCommand userCommand = new ("Teste User", "teste@teste.com.br");
        CreateUserCommandValidator userValidor = new (userRepositoryMock.Object);

        var validationResult = await userValidor.TestValidateAsync(userCommand);

        validationResult.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public async Task CreateUserCommand_ShouldHaveValidationErrors_WhenInValidInfo()
    {
        Mock<IUserRepository> userRepositoryMock = new();

        userRepositoryMock.Setup(x =>
            x.IsEmailUnique(It.IsAny<string>())
        ).ReturnsAsync(true);

        CreateUserCommand userCommand = new("teste@.com.br", "");
        CreateUserCommandValidator userValidor = new(userRepositoryMock.Object);

        var validationResult = await userValidor.TestValidateAsync(userCommand);

        validationResult.ShouldHaveAnyValidationError();
    }
}
