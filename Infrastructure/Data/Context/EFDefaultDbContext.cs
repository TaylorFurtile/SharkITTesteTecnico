using Microsoft.EntityFrameworkCore;
using SharkITTesteTecnico.Domain.Entities;
using SharkITTesteTecnico.Infrastructure.Interfaces;

namespace SharkITTesteTecnico.Infrastructure.Data.Context;

internal class EFDefaultDbContext(ISecretManager secretManager) : DbContext
{
    private readonly ISecretManager _secretManager = secretManager;

    internal DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = _secretManager.GetRequiredSecret("ConnectionStrings:DefaultDb");

        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>();
    }
}
