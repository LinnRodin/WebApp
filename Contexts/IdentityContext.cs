using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

            using (var serviceScope = this.GetService<IServiceScopeFactory>().CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!roleManager.RoleExistsAsync("admin").Result)
                {
                    roleManager.CreateAsync(new IdentityRole("admin")).Wait();
                }

                if (!roleManager.RoleExistsAsync("user").Result)
                {
                    roleManager.CreateAsync(new IdentityRole("user")).Wait();
                }
            }
        }

    }
}
