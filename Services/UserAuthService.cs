using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;
using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Services;

public class UserAuthService
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IdentityContext _identityContext;
    private readonly SeedService _seedService;

    public UserAuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager, SeedService seedService, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _identityContext = identityContext;
        _signInManager = signInManager;
        _seedService = seedService;
        _roleManager = roleManager;
    }




    public async Task<bool> SignUpAsync(RegisterViewModel registerViewmodel)
    {
        try   
        {
            await _seedService.SeedRoles();
            var roleName = "user";
            //Om det inte finns några användare, lägg till roll till admin rollen annars user rollen.
            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";
           
            //Skapa användare/registrerar  
            IdentityUser identityUser = registerViewmodel;
            await _userManager.CreateAsync(identityUser, registerViewmodel.Password);

            await _userManager.AddToRoleAsync(identityUser, roleName);

            //Skapa profil för användarprofil
            UserProfileEntity userprofileEntity = registerViewmodel;
            userprofileEntity.UserId = identityUser.Id;

            //sparar ner till identitycontext
            _identityContext.UserProfiles.Add(userprofileEntity);
            await _identityContext.SaveChangesAsync();

            return true;

        }
        catch { return false; }
            
    }


    //Login
    public async Task<bool> SignInAsync(LoginViewModel loginViewModel)
    {
        try
        {

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberLogin, false);

            return result.Succeeded;
        }
        catch { return false; }

    }


    public async Task<bool> SignOutAsync(ClaimsPrincipal user)
    {

         await _signInManager.SignOutAsync();
         return _signInManager.IsSignedIn(user);



    }

}





