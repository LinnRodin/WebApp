using Microsoft.AspNetCore.Identity;

namespace WebApp.Services
{
    public class SeedService
    {

        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        // Metod för att skapa roller vid seedning av databasen.
        public async Task SeedRoles()
        {   
            if (!await _roleManager.RoleExistsAsync("admin"))                // Kontrollerar om rollen "admin" redan finns, om inte skapas den.
                await _roleManager.CreateAsync(new IdentityRole("admin"));

            if (!await _roleManager.RoleExistsAsync("user"))                 // Kontrollerar om rollen "user" redan finns, om inte skapas den.
                await _roleManager.CreateAsync(new IdentityRole("user"));
        }
    }
}
