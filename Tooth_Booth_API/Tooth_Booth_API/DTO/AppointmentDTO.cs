using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Tooth_Booth_API.Enum;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.DTO
{
    public class AppointmentDTO
    {
        
        public int AppointmentId { get; set; }
        public string PatientUserName { get; set; }

        public string DoctorId { get; set; }
       
        public DateTime AppointmentDate { get; set; }

        public int ClinicId { get; set; }

        public string Prescription { get; set; }

        public PaymentType PaymentType { get; set; }
    }
}
