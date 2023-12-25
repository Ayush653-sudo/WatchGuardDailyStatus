
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.Controllers
{

   [Route("[controller]")]
    public class ClinicsController : ControllerBase
    {
        private readonly IClinicsBusiness _clinicsBusiness;
        public ClinicsController(IClinicsBusiness clinicBusiness)
        { this._clinicsBusiness = clinicBusiness;

        }
     


        [HttpGet]
        public IActionResult Get(int?clinicId,string clinicName,string clinicCity,bool? isVerified)
        {
          
           
            IEnumerable<ClinicDTO> listOfClinic = _clinicsBusiness.GetAllClinic(clinicId,clinicName,clinicCity,isVerified);
            return Ok(listOfClinic);

        }

        [HttpPatch("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Patch(int id,[FromBody] JsonPatchDocument<Clinic> updateClinic)
        {

            if (_clinicsBusiness.UpdateClinic(id,updateClinic))
                return Ok("sucessful!!");
            return BadRequest();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {


           if(await _clinicsBusiness.DeleteClinic(id))
                return Ok();
            else
                return NotFound();
        }

    }
}
