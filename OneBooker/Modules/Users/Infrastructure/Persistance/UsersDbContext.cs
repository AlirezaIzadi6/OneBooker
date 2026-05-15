using Microsoft.EntityFrameworkCore;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;

namespace OneBooker.Modules.Users.Infrastructure.Persistance;

public class UsersDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Users");
        base.OnModelCreating(modelBuilder);
    }
}