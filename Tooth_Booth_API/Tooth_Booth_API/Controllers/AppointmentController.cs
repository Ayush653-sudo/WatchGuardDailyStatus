

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.Models;
using Tooth_Booth_API.DTO;

namespace Tooth_Booth_API.Controllers
{
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        IAppointmentBusiness _appointmentBusiness { get; set; }
        public AppointmentController(IAppointmentBusiness appointmentBusiness)
        {
            this._appointmentBusiness = appointmentBusiness;
        }

        [HttpPost]
        [Authorize(Roles ="Patient")]
        public IActionResult Post([FromBody] AppointmentAddDTO model)

        {

            if (ModelState.IsValid)
            {
                try
                {


                    var userName = User.Identity.GetUserName();
                    if (_appointmentBusiness.AddAppointment(model, userName))
                    {
                        return Ok("Appointment Added Sucessfully");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);

                }
            }
            return BadRequest();
            
            }
      
        

       

        [HttpGet]
    [Authorize(Roles = "Dentist,Patient")]
 
        public IActionResult Get(DateTime? date,int? appointmentId,string patientUserName,string DoctorId,int? clinicId)
        {
            try
            {
                if (User.IsInRole("Dentist"))
                {
                    DoctorId = User.Identity.GetUserId();
                }
                if (User.IsInRole("Patient"))
                {
                    patientUserName = User.Identity.GetUserName();
                }


                IEnumerable<AppointmentDTO> appointments = _appointmentBusiness.GetAppointmentFilter(date, appointmentId, patientUserName, DoctorId, clinicId);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

     

        [HttpPatch("{id}")]
      [Authorize(Roles ="Dentist")]
        public async Task<IActionResult> Patch(int id,[FromBody] JsonPatchDocument<Appointment> updateAppointment)
        {

            try
            {
                var dentistId = User.Identity.GetUserId();

                if (await _appointmentBusiness.UpdateAppointment(id, dentistId, updateAppointment))
                    return Ok("Pescription added sucessfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var userName = User.Identity.GetUserName();
                if (_appointmentBusiness.DeleteAppointById(id, userName))
                    return Ok();
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex) 
            {
                return BadRequest(ex);
            }
        
        }

    }
}
