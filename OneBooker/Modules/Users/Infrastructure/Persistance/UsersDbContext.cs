using Microsoft.EntityFrameworkCore;
using OneBooker.Modules.Users.Domain.Addresses.Entities;
using OneBooker.Modules.Users.Domain.UserManagement.Entities;
using OneBooker.Modules.Users.Infrastructure.Persistance.SeedData;

namespace OneBooker.Modules.Users.Infrastructure.Persistance;

public class UsersDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<ResetPasswordToken> Tokens { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<City> Cities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Users");
        modelBuilder.SeedGeography();
        base.OnModelCreating(modelBuilder);
    }
}