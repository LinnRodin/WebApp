using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize(Roles = "admin")] //Behörighetsattribut för att bara tilldela åtkomst för användaren med admin rollen. 
    public class AdminController : Controller
    {
        private readonly UserRoleService _userRoleService;

        public AdminController(UserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        public async Task<IActionResult> Index()
        {
            var userRoleList = await _userRoleService.GetAllUsersWithRolesAsync(); // Hämtar en lista med användare och deras roller genom att anropa GetAllUsersWithRolesAsync-metoden i UserRoleService.

            return View(userRoleList);  // Returnerar vyn med listan. 
        }


        // VG delar för att ändra och lägga till roller. 

        //[HttpPost]
        //public async Task<IActionResult> UpdateUserRole(string userId, string newRole)
        //{
        //    var result = await _userRoleService.UpdateUserRoleAsync(userId, newRole);
        //    if (result)
        //        return RedirectToAction("Index");

        //    // Handle error case
        //    return RedirectToAction("Index");
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddUserRole(string userId, string role)
        //{
        //    var result = await _userRoleService.AddUserRoleAsync(userId, role);
        //    if (result)
        //        return RedirectToAction("Index");

        //    // Handle error case
        //    return RedirectToAction("Index");
        //}
        //[HttpPost]
        //public async Task<IActionResult> CreateRoleAsync(string roleName)
        //{
        //    var result = await _userRoleService.CreateRoleAsync(roleName);
        //    if (result)
        //        return RedirectToAction("Index");

        //    // Handle error case
        //    return RedirectToAction("Index");
        //}

    }

}



