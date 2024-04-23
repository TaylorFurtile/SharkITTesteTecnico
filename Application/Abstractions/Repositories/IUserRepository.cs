using SharkITTesteTecnico.Domain.Entities;
using SharkITTesteTecnico.Infrastructure.Interfaces;

namespace SharkITTesteTecnico.Application.Abstractions.Repository;

public interface IUserRepository : IBaseRepository<User>
{
    public Task<bool> IsEmailUnique(string email);
}
