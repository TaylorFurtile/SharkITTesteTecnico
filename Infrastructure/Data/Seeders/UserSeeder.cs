using SharkITTesteTecnico.Domain.Entities;
using SharkITTesteTecnico.Infrastructure.Data.Context;
using SharkITTesteTecnico.Infrastructure.Interfaces;

namespace SharkITTesteTecnico.Infrastructure.Data.Seeders;

internal class UserSeeder(EFDefaultDbContext dbContext) : IDatabaseSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Users.Any())
            {
                var users = GetUsers();
                dbContext.Users.AddRange(users);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private static List<User> GetUsers()
    {
        return [
            new () {
                Id = new Guid("de082516-1218-44e9-9915-750ecb67028b"),
                CreatedAt = DateTimeOffset.Parse("2024-02-28T18:41:37.000Z").UtcDateTime,
                UpdatedAt = DateTimeOffset.Parse("2024-04-19T14:57:27.000Z").UtcDateTime,
                Email = "teste@teste.com.br",
                Username = "User Teste"
            },

            new () {
                Id = new Guid("950d7d30-c6ec-4275-9d10-ab9dcda9a8fa"),
                CreatedAt = DateTimeOffset.Parse("2024-03-12T15:34:20.000Z").UtcDateTime,
                UpdatedAt = DateTimeOffset.Parse("2024-04-11T10:26:06.000Z").UtcDateTime,
                Email = "teste_2@teste.com.br",
                Username = "User Teste 2"
            }
        ];
    }
}
