using FIAPCloudGames.Domain.Entities;
using FIAPCloudGames.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace FIAPCloudGames.Infrastructure;

public class FCGContext: DbContext
{
    public FCGContext(DbContextOptions<FCGContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new UserConfiguration());
        //modelBuilder.Seed();
    }
}

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { 
                FullName = "Administrator", 
                Login = "administrator", 
                Password = "1234@&.AsYh", 
                UserType = 2,
                IsActive = true,
                CreatedBy = DateTime.UtcNow
            }
        );
    }
}
