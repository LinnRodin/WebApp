using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AccountController : Controller
{

    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }

    [Authorize]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {   
        if (ModelState.IsValid) 
        {

            if (await _userService.CheckUserExists(x => x.Email == registerViewModel.Email))
            {
                ModelState.AddModelError("", "A user with the same Email already exists");
            }
            else 
            {
                if (await _userService.RegisterAsync(registerViewModel))
                    return RedirectToAction("Login", "Account");
                else
                    ModelState.AddModelError("", "Something went wrong when trying to create a userprofile");
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
            if (await _userService.LoginAsync(loginViewModel))
             return RedirectToAction("Index");


           ModelState.AddModelError("", "A user with the same email already exists");

        }

        return View(loginViewModel);
    }



    public IActionResult Index()
    {
        return View();
    }
}
