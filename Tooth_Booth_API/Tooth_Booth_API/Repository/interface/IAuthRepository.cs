using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;


namespace Tooth_Booth_API.Repository.@interface
{
    public interface IAuthRepository
    {

        Task<IdentityResult> Register(IdentityUser identityUser, string password);
        Task<IdentityResult> AddToRole(IdentityUser identityUser, string Role);
        Task<SignInResult> LogIn(string userName, string password);

        Task<IdentityUser> Find(string userId);

        Task<IdentityResult>Delete(IdentityUser identityUser);



    }
}
