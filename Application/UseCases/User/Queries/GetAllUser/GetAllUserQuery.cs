using MediatR;
using Entities = SharkITTesteTecnico.Domain.Entities;

namespace SharkITTesteTecnico.Application.UseCases.User.Queries.GetAllUser
{
    public record GetAllUserQuery() : IRequest<List<Entities.User>>;
}
