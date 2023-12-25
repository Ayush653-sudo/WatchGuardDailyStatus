using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tooth_Booth_API.DTO;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.BusinessLogic.Interface
{
    public interface IAppointmentBusiness
    {
        bool AddAppointment(AppointmentAddDTO appointment,string userName);
        Task<bool> UpdateAppointment(int  id,string dentistId, JsonPatchDocument<Appointment>updateAppointment);
        IEnumerable<AppointmentDTO> GetAppointmentFilter(DateTime? dateTime,int? appointmentId,string patientUserName,string DoctorId,int? clinicId);

        bool DeleteAppointById(int id,string userName);
    }
}