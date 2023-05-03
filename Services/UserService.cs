using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Services;

public class UserService
{

    private readonly DataContext _context;

    public UserService(DataContext context)
    {
        _context = context;
    }



    public async Task<bool> CheckUserExists(Expression<Func<UserEntity, bool>> predicate )
    {
        if (!await _context.Users.AnyAsync(predicate))
           return true; 
        
        return false;
    }


    public async Task<UserEntity> GetUserAsync(Expression<Func<UserEntity, bool>> predicate)
    {   
        var UserEntity = await _context.Users.FirstOrDefaultAsync(predicate);
            return UserEntity!;
    }



    public async Task<bool> RegisterAsync(RegisterViewModel registerViewModel)
    {
        try
        {
            

            //Konverterar till userentity och profileentity från reg.formulär
            UserEntity userEntity = registerViewModel;
            ProfileEntity profileEntity = registerViewModel;

            //Skapar användare
            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            //Skapar användarprofil
            profileEntity.UserId = userEntity.Id;
            _context.Profiles.Add(profileEntity);
            await _context.SaveChangesAsync();

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
    }
}
