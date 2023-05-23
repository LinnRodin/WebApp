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
    }

}



