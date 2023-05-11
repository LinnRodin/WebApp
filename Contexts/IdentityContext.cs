using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;
using WebApp.Services;

namespace WebApp.Contexts
{
    public class IdentityContext : IdentityDbContext
    {
    
        public IdentityContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserProfileEntity> UserProfiles { get; set; }


    }
}




    //Borde också funka , testa i sommar. 

    /*  using (var serviceScope = this.GetService<IServiceScopeFactory>().CreateScope())
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
            }  */