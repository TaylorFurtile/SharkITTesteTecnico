using FluentAssertions;
using Moq;
using SharkITTesteTecnico.Application.Abstractions.Repository;
using SharkITTesteTecnico.Application.Exceptions;
using SharkITTesteTecnico.Application.UseCases.User.Commands.CreateUser;
using Entities = SharkITTesteTecnico.Domain.Entities;

namespace SharkITTesteTecnico.Test.User.Commands.CreateUser;

public class CreateUserCommandHandlerTests
{
    [Fact]
    public async Task CreateUserCommand_ShouldReturnUserId_WhenValidInfos()
    {
        Mock<IUserRepository> userRepositoryMock = new();

        userRepositoryMock.Setup(x =>
            x.IsEmailUnique(It.IsAny<string>())
        ).ReturnsAsync(true);

        var command = new CreateUserCommand("Teste User", "teste@teste.com.br");
        var handler = new CreateUserCommandHandler(userRepositoryMock.Object);

        var guid = await handler.Handle(command, default);

        guid.Should().NotBeEmpty();

        userRepositoryMock.Verify(x => x.IsEmailUnique(It.IsAny<string>()), Times.Once());
        userRepositoryMock.Verify(x => x.Create(It.IsAny<Entities.User>()), Times.Once());
    }

    [Fact]
    public async Task CreateUserCommand_ShouldThrowException_WhenInvalidInfos()
    {
        Mock<IUserRepository> userRepositoryMock = new();

        var command = new CreateUserCommand("teste@.com.br", "123");
        var handler = new CreateUserCommandHandler(userRepositoryMock.Object);

        Task<Guid> task() => handler.Handle(command, default);

        var error = await Assert.ThrowsAsync<BadRequestException>(task);

        error.Errors.Should().HaveCount(2);

        userRepositoryMock.Verify(x => x.IsEmailUnique(It.IsAny<string>()), Times.Once());
        userRepositoryMock.Verify(x => x.Create(It.IsAny<Entities.User>()), Times.Never());
    }
}
