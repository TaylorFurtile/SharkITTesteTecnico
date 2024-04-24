using Moq;
using SharkITTesteTecnico.Application.Abstractions.Repository;
using SharkITTesteTecnico.Application.Exceptions;
using SharkITTesteTecnico.Application.UseCases.User.Queries.GetUserById;
using Entities = SharkITTesteTecnico.Domain.Entities;

namespace SharkITTesteTecnico.Test.User.Commands.GetByIdUser;

public class GetUserByIdQueryHandlerTests
{
    [Fact]
    public async Task GetUserByIdQuery_ShouldThrowException_WhenUserNotExists()
    {
        Mock<IUserRepository> userRepositoryMock = new();

        userRepositoryMock.Setup(x =>
            x.GetById(It.IsAny<Guid>())
        ).ReturnsAsync(null as Entities.User);

        var command = new GetUserByIdQuery(Guid.Empty);
        var handler = new GetUserByIdQueryHandler(userRepositoryMock.Object);

        Task<Entities.User> task() => handler.Handle(command, default);

        await Assert.ThrowsAsync<NotFoundException>(task);

        userRepositoryMock.Verify(x => x.GetById(It.IsAny<Guid>()), Times.Once());
    }
}
