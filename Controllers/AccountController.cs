using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AccountController : Controller
{

    private readonly UserAuthService _auth;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(UserAuthService auth, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _auth = auth;
        _userManager = userManager;
        _roleManager = roleManager;
    }



    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _auth.SignUpAsync(registerViewModel))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ModelState.AddModelError("", "A user with the same email already exists");
            }
        }

        return View(registerViewModel);
    }




    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _auth.SignInAsync(loginViewModel))
            {
                var user = await _userManager.FindByNameAsync(loginViewModel.Email);
                if(user is not null) 
                {
                    var role = await _userManager.GetRolesAsync(user);
                    if(role is not null)
                    {
                        if (role.Contains("admin"))
                            return RedirectToAction("Index", "admin");
                        else return RedirectToAction("Index", "Account");
                    }
                    
                }
               
            }
         
           ModelState.AddModelError("", "Incorrect email or password");

        }

        return View(loginViewModel);
    }


    [Authorize]
    public new async Task <IActionResult> SignOut()
    {
        if (await _auth.SignOutAsync(User))
            return LocalRedirect("/");

        return RedirectToAction("Index");


    }


    [Authorize]    
    
    public IActionResult Index()
    {
        return View();
    }
}
