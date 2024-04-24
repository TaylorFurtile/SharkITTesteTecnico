using FluentAssertions;
using MediatR;
using Moq;
using SharkITTesteTecnico.Application.Abstractions.Repository;
using SharkITTesteTecnico.Application.Exceptions;
using SharkITTesteTecnico.Application.UseCases.User.Commands.DeleteUser;
using Entities = SharkITTesteTecnico.Domain.Entities;

namespace SharkITTesteTecnico.Test.User.Commands.DeleteUser;

public class DeleteUserCommandHandlerTests
{
    [Fact]
    public async Task DeleteUserCommand_ShouldThrowException_WhenUserNotExists()
    {
        Mock<IUserRepository> userRepositoryMock = new();

        userRepositoryMock.Setup(x =>
            x.GetById(It.IsAny<Guid>())
        ).ReturnsAsync(null as Entities.User);

        var command = new DeleteUserCommand(Guid.Empty);
        var handler = new DeleteUserCommandHandler(userRepositoryMock.Object);

        Task<Unit> task() => handler.Handle(command, default);

        await Assert.ThrowsAsync<NotFoundException>(task);

        userRepositoryMock.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once());
        userRepositoryMock.Verify(x => x.Delete(It.IsAny<Guid>()), Times.Never());
    }
}
