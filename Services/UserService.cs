using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Services;

public class UserService
{

    private readonly UserManager<IdentityUser> _userManager;

    public UserService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }



    public async Task<bool> SignUpAsync(RegisterViewModel registerViewmodel)
    {
        IdentityUser identityUser = registerViewmodel;
        var result = await _userManager.CreateAsync(identityUser, registerViewmodel.Password);



        return false;


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
}
