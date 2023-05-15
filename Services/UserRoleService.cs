using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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




    }
}
