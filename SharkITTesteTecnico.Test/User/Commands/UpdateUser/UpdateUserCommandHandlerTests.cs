using FluentAssertions;
using MediatR;
using Moq;
using SharkITTesteTecnico.Application.Abstractions.Repository;
using SharkITTesteTecnico.Application.Exceptions;
using SharkITTesteTecnico.Application.UseCases.User.Commands.UpdateUser;
using Entities = SharkITTesteTecnico.Domain.Entities;

namespace SharkITTesteTecnico.Test.User.Commands.UpdateUser;

public class DeleteUserCommandHandlerTests
{
    [Fact]
    public async Task UpdateUserCommand_ShouldThrowException_WhenUserNotExists()
    {
        Mock<IUserRepository> userRepositoryMock = new();

        userRepositoryMock.Setup(x =>
            x.GetById(It.IsAny<Guid>())
        ).ReturnsAsync(null as Entities.User);

        var command = new UpdateUserCommand(Guid.Empty, "Teste User");
        var handler = new UpdateUserCommandHandler(userRepositoryMock.Object);

        Task<Unit> task() => handler.Handle(command, default);

        await Assert.ThrowsAsync<NotFoundException>(task);

        userRepositoryMock.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once());
        userRepositoryMock.Verify(x => x.Update(It.IsAny<Entities.User>()), Times.Never());
    }

    [Fact]
    public async Task UpdateUserCommand_ShouldThrowException_WhenInvalidInfos()
    {
        Mock<IUserRepository> userRepositoryMock = new();

        var command = new UpdateUserCommand(Guid.Empty, "123");
        var handler = new UpdateUserCommandHandler(userRepositoryMock.Object);

        Task<Unit> task() => handler.Handle(command, default);

        var error = await Assert.ThrowsAsync<BadRequestException>(task);

        error.Errors.Should().HaveCount(1);
    }
}
