using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Tooth_Booth_API.DTO.Auth;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.BusinessLogic.Interface
{
    public interface IAuthBusiness
    {
        Task<bool> AddUser(IdentityUser user,string password,string RoleName);
        Task<bool> LogIn(UserLoginDTO userLoginModel);
        Task<bool> AddDentist(string clinicAdmin,DentistRegistrationDTO newDentist);
        Task<bool> AddClinic(ClinicRegistrationDTO newClinic);

      
    }
}
