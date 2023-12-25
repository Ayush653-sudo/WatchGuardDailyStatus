using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tooth_Booth_API.Enum;

namespace Tooth_Booth_API.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        [Required]
        public string PatientUserName { get; set; }

        [ForeignKey("Dentist")]
        public string DoctorId { get; set; }
        [JsonIgnore]
        public virtual Dentist Dentist { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public int ClinicId { get; set; }
        [Required]
        public string Prescription { get; set; }
        [Required]
       
        public PaymentType PaymentType { get; set; }
    }
}
