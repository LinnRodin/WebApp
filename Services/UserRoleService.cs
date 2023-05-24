using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApp.ViewModels;

namespace WebApp.Services
{
    public class UserRoleService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserRoleService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        //Hämtar alla användare och deras roller. 
        public async Task<List<UserRoleViewModel>> GetAllUsersWithRolesAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRoleList = users.Select(async user =>
            {
                var roles = await _userManager.GetRolesAsync(user);
                return new UserRoleViewModel
                {
                    IdentityUser = user.UserName,
                    IdentityRole = roles.FirstOrDefault()
                };
            });

            return (await Task.WhenAll(userRoleList)).ToList();
        }



        //VG Delar

        // Lägger till en helt ny användare

        //public async Task<bool> CreateRoleAsync(string roleName)
        //{
        //    var roleExists = await _roleManager.RoleExistsAsync(roleName);
        //    if (roleExists)
        //        return false;

        //    var role = new IdentityRole(roleName);
        //    var result = await _roleManager.CreateAsync(role);

        //    return result.Succeeded;
        //}



        //// Uppdaterar/ändrar användarroll för en användare

        //public async Task<bool> UpdateUserRoleAsync(string userId, string newRole)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //        return false;

        //    var currentRoles = await _userManager.GetRolesAsync(user);
        //    await _userManager.RemoveFromRolesAsync(user, currentRoles.ToArray());
        //    await _userManager.AddToRoleAsync(user, newRole);

        //    return true;
        //}

        // Lägger till en användarroll för en existerande användare

        //public async Task<bool> AddUserRoleAsync(string userId, string role)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //        return false;

        //    await _userManager.AddToRoleAsync(user, role);

        //    return true;
        //}

     


    }
}
