using FurnitureShop.Api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FurnitureShop.Api.Data;

public class AppDbContext : IdentityDbContext<UserEntity, UserEntityRole, Guid>
{
    public DbSet<OrganizationUser>? OrganizationUsers { get; set; }
    public DbSet<Organization>? Organizations { get; set; }
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<OrganizationUser>().HasKey(user => new { user.UserId, user.OrganizationId });
    }
}
