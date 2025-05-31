using FIAPCloudGames.Application.Utils;
using FIAPCloudGames.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIAPCloudGames.Infrastructure.Context;

public class FCGContext : DbContext
{
    public FCGContext(DbContextOptions<FCGContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
    }
}

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FullName = "Administrator",
                Login = "administrator",
                Password = Utils.HashPassword("1234@&.AsYh"),
                Email = "adm@adm.com",
                UserType = UserRole.Admin,
                IsActive = true,
                CreatedAt = new DateTime(2025, 5, 30, 12, 50, 51, 795, DateTimeKind.Utc).AddTicks(8972)
            }
        );
    }
}
