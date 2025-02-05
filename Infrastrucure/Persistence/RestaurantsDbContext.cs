using Application.Contracts.Users;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucure.Persistence;

public class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options, IUserContext userContext) : DbContext(options)
{
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Menus)
            .WithOne(m => m.Restaurant)
            .HasForeignKey(m => m.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Orders)
            .WithOne(o => o.Restaurant)
            .HasForeignKey(o => o.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);

        List<Restaurant> restaurants = new()
        {
            new Restaurant { Id = 1, Name = "Restaurant 1", Phone = "1234567890", Created = DateTime.UtcNow, OwnerId = "ed2029f6-757d-463f-88a3-3ed4133a50e0" },
            new Restaurant { Id = 2, Name = "Restaurant 2", Phone = "1234567590", Created = DateTime.UtcNow, OwnerId = "ed2029f6-757d-463f-88a3-3ed4133a50e0" },
        };

        List<Menu> menus = new()
        {
            new Menu { Id = 1, Name = "Menu 1", Price = 10.00m, RestaurantId = 1, Created = DateTime.UtcNow },
            new Menu { Id = 2, Name = "Menu 2", Price = 20.00m, RestaurantId = 1, Created = DateTime.UtcNow },
            new Menu { Id = 3, Name = "Menu 3", Price = 30.00m, RestaurantId = 2, Created = DateTime.UtcNow},
            new Menu { Id = 4, Name = "Menu 4", Price = 40.00m, RestaurantId = 2, Created = DateTime.UtcNow},
        };

        modelBuilder.Entity<Restaurant>().HasData(restaurants);
        modelBuilder.Entity<Menu>().HasData(menus);

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntry>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created = DateTime.UtcNow;
                    entry.Entity.CreatedBy = userContext.GetCurrentUser()?.UserId ?? "Anonymous";
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = userContext.GetCurrentUser()?.UserId ?? "Anonymous";
                    break;
                default:
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
