using Domain.Constants;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identites;

public class AppIdentityContextDb : IdentityDbContext<AppUser>
{
    public AppIdentityContextDb(DbContextOptions<AppIdentityContextDb> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        List<IdentityRole> roles = new List<IdentityRole>()
        {
            new IdentityRole { Name = UsersRoles.ADMIN, NormalizedName = "ADMIN" },
            new IdentityRole { Name = UsersRoles.MODERATOR, NormalizedName = "MODERATOR" },
            new IdentityRole { Name = UsersRoles.MEMBER, NormalizedName = "MEMBER" }
        };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}
