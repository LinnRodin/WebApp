using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AccountController : Controller
{   
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel registerViewModel)
    {   
        if (ModelState.IsValid) 
        { 
        
        }
        return View(registerViewModel);
    }










    public IActionResult Index()
    {
        return View();
    }
}
