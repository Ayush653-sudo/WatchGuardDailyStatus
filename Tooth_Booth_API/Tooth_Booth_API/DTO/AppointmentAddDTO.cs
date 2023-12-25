using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Tooth_Booth_API.Enum;
using Tooth_Booth_API.Models;
using System.Text.Json.Serialization;

namespace Tooth_Booth_API.DTO
{
    public class AppointmentAddDTO
    {


        [Required]
        public string DoctorId { get; set; }
        [JsonIgnore]
        public virtual Dentist Dentist { get; set; }

        [Required]
        public string Prescription { get; set; }
        [Required]

        public PaymentType PaymentType { get; set; }
    }
}
