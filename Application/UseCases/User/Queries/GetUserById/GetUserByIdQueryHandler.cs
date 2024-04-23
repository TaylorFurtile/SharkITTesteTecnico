using MediatR;
using SharkITTesteTecnico.Application.Abstractions.Repository;
using SharkITTesteTecnico.Application.Exceptions;
using Entities = SharkITTesteTecnico.Domain.Entities;

namespace SharkITTesteTecnico.Application.UseCases.User.Queries.GetUserById
{
    public class GetUserByIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, Entities.User>
    {
        public async Task<Entities.User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await userRepository.GetById(request.Id);

            if (result == null)
            {
                throw new NotFoundException(nameof(Entities.User));
            }

            return result;
        }
    }
}
