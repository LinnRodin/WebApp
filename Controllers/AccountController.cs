using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AccountController : Controller
{

    private readonly UserAuthService _auth;

    public AccountController(UserAuthService auth)
    {
        _auth = auth;
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
             return RedirectToAction("Index");


           ModelState.AddModelError("", "Incorrect email or password");

        }

        return View(loginViewModel);
    }


    [Authorize]
    public IActionResult SignOut()
    {
        return View();
    }




    public IActionResult Index()
    {
        return View();
    }
}
