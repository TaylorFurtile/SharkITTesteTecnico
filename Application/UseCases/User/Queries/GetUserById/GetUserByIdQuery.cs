using MediatR;
using Entities = SharkITTesteTecnico.Domain.Entities;

namespace SharkITTesteTecnico.Application.UseCases.User.Queries.GetUserById
{
    public record GetUserByIdQuery(Guid Id) : IRequest<Entities.User>;
}
