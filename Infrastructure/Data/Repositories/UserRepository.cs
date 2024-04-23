using Microsoft.EntityFrameworkCore;
using SharkITTesteTecnico.Application.Abstractions.Repository;
using SharkITTesteTecnico.Domain.Entities;
using SharkITTesteTecnico.Infrastructure.Data.Context;

namespace SharkITTesteTecnico.Infrastructure.Data.Repositories
{
    internal sealed class UserRepository(EFDefaultDbContext dbContext)
        : BaseRepository<User>(dbContext), IUserRepository
    {
        public async Task<bool> IsEmailUnique(string email)
        {
            var exists = await dbContext.Users.AnyAsync(u => u.Email == email);

            return exists == false;
        }
    }
}
