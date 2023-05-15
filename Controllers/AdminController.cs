using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly UserRoleService _userRoleService;

        public AdminController(UserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        public async Task<IActionResult> Index()
        {
            var userRoleList = await _userRoleService.GetAllUsersWithRolesAsync();

            return View(userRoleList);
        }
    }

}



