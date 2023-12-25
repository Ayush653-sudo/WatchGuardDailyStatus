

using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.Repository.@interface;

namespace Tooth_Booth_API.Repository
{
    public class AuthRepository:IAuthRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AuthRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            this.signInManager = signInManager;
        }
    
      public async Task<IdentityResult>   Register(IdentityUser identityUser, string password)
        {
           return  await _userManager.CreateAsync(identityUser, password);
        }

      public   async Task<SignInResult> LogIn(string userName, string password)
        {
            return await signInManager.PasswordSignInAsync(userName, password, false, false);
        }
       public async Task<IdentityResult> AddToRole(IdentityUser identityUser, string Role)
        {
           return  await _userManager.AddToRoleAsync(identityUser, Role);
        }

        public async Task<IdentityUser>Find(string id)
        {
           return  await _userManager.FindByIdAsync(id);
        }
        public async Task<IdentityResult>Delete(IdentityUser identityUser)
        {
            return  await _userManager.DeleteAsync(identityUser);
        }

    }
}
