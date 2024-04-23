using MediatR;
using SharkITTesteTecnico.Application.Abstractions.Repository;
using Entities = SharkITTesteTecnico.Domain.Entities;

namespace SharkITTesteTecnico.Application.UseCases.User.Queries.GetAllUser
{
    public class GetAllUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetAllUserQuery, List<Entities.User>>
    {
        public async Task<List<Entities.User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var result = await userRepository.GetAll();

            return result.ToList();
        }
    }
}
