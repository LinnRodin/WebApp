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
    private readonly IdentityContext _identityContext;

    public UserAuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _identityContext = identityContext;
        _signInManager = signInManager;
    }




    public async Task<bool> SignUpAsync(RegisterViewModel registerViewmodel)
    {
        try
        {    //Skapa användare  
            IdentityUser identityUser = registerViewmodel;
            await _userManager.CreateAsync(identityUser, registerViewmodel.Password);

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









/*public async Task<bool> CheckUserExists(Expression<Func<UserEntity, bool>> predicate )
{
    if (!await _userManager.Users.AnyAsync(predicate))
       return true; 

    return false;
}


public async Task<UserEntity> GetUserAsync(Expression<Func<UserEntity, bool>> predicate)
{   
    var UserEntity = await _userManager.Users.FirstOrDefaultAsync(predicate);
        return UserEntity!;
}



public async Task<bool> RegisterAsync(RegisterViewModel registerViewModel)
{
    try
    {


        //Konverterar till userentity och profileentity från reg.formulär
        UserEntity userEntity = registerViewModel;
        UserProfileEntity profileEntity = registerViewModel;

        //Skapar användare
        _userManager.Users.Add(userEntity);
        await _userManager.SaveChangesAsync();

        //Skapar användarprofil
        profileEntity.UserId = userEntity.Id;
        _userManager.Profiles.Add(profileEntity);
        await _userManager.SaveChangesAsync();

        return true; 


    }
    catch
    {
        return false;

    }

}



public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
{

    var userEntity = await GetUserAsync(x => x.Email == loginViewModel.Email);
    if (userEntity != null)
        return userEntity.VerifySecurePassword(loginViewModel.Password);

    return false;
} */
