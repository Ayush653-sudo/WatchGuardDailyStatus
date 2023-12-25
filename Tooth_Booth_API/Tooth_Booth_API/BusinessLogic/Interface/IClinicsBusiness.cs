using Microsoft.AspNetCore.JsonPatch;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.BusinessLogic.Interface
{
    public interface IClinicsBusiness
    {
        IEnumerable<ClinicDTO> GetAllClinic(int? clinicId,string clinicName,string clinicCity, bool? isVerified);
         bool UpdateClinic(int id,JsonPatchDocument<Clinic> updateClinic);
        Task<bool> DeleteClinic(int id);
    }
}
