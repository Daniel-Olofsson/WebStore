using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStore.Models;

namespace WebStore.Contexts;

public class IdentityContext : IdentityDbContext
{
    public IdentityContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }
    public DbSet<UserEntity> UserProfiles { get; set; }
    public DbSet<ContactEntity> ContactMessages { get; set; }

    protected override  void OnModelCreating(ModelBuilder builder)
    {
        
        base.OnModelCreating(builder);
        builder.Entity<IdentityRole>().HasData(new IdentityRole("admin"));
        builder.Entity<IdentityRole>().HasData(new IdentityRole("user"));
        //if (! _roleManager.RoleExistsAsync("admin").Result)
        //{
        //     _roleManager.CreateAsync(new IdentityRole("admin")).Wait();
        //}
        //if (! _roleManager.RoleExistsAsync("user").Result)
        //{
        //     _roleManager.CreateAsync(new IdentityRole("user")).Wait();
        //}
    }

    public DbSet<WebStore.Models.ProductEntity> ProductEntity { get; set; } = default!;
}
