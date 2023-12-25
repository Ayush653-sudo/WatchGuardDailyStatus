using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.BusinessLogic.Interface
{
    public interface IDentistBusiness
    {
        IEnumerable<DentistDTO> GetDentistByClinicId(int? ClinicUserName);
        bool UpdateDentist(string id,JsonPatchDocument<Dentist> updateDentint);
        Task<bool> DeleteDentist(string id,string userID);



    }
}