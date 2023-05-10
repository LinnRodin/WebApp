using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Contexts
{
    public class IdentityContext : IdentityDbContext
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public IdentityContext(DbContextOptions options, RoleManager<IdentityRole> roleManager) : base(options)
        {
            _roleManager = roleManager;
        }


        public DbSet<UserProfileEntity> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            if (!_roleManager.RoleExistsAsync("admin").Result)
                _roleManager.CreateAsync(new IdentityRole("admin")).Wait();

                if (!_roleManager.RoleExistsAsync("user").Result)
                _roleManager.CreateAsync(new IdentityRole("user")).Wait();

        }
    }
}
