using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using WebApp.Services;

namespace WebApp.Factories
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser>
    {   
        private readonly UserService _userService;

        public CustomClaimsPrincipalFactory(UserManager<IdentityUser> userManager, IOptions<IdentityOptions> optionsAccessor, UserService userService) : base(userManager, optionsAccessor)
        {
            _userService = userService;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user) 
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);

            var userProfileEntity = await _userService.GetUserProfileAsync(user.Id);

            claimsIdentity.AddClaim(new Claim("DisplayName", $"{userProfileEntity.FirstName} {userProfileEntity.LastName}"));

            var roles = await UserManager.GetRolesAsync(user);
             foreach(var role in roles)
             {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
             } 
            
            return claimsIdentity;
        }
           

    }
}
