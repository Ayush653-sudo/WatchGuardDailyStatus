using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.Controllers
{
   [Route("[controller]")]
    public class DentistController:ControllerBase
    {
        IDentistBusiness _dentistBusiness {  get; set; }
        public DentistController(IDentistBusiness dentistBusiness) 
        {
            this._dentistBusiness = dentistBusiness;
        }

       [HttpGet]
        public IActionResult Get(int? ClinicId)
        {
            try
            {
                return Ok(_dentistBusiness.GetDentistByClinicId(ClinicId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }
        [HttpPatch]
      
        [Authorize(Roles = "Dentist")]
        public IActionResult Patch( [FromBody] JsonPatchDocument<Dentist> updateDentist)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                if (_dentistBusiness.UpdateDentist(userId, updateDentist))
                    return Ok("sucessful!!");
                return BadRequest();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ClinicAdmin")]
        public async Task<IActionResult> Delete(string id) 
        {

            try
            {
                var userId = User.Identity.GetUserId();
                if (await _dentistBusiness.DeleteDentist(id, userId))
                    return Ok();
                else
                    return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





    }
}
