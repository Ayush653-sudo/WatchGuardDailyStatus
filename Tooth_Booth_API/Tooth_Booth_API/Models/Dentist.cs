using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Tooth_Booth_API.Enum;

namespace Tooth_Booth_API.Models
{
    public class Dentist
    {

        [Key,ForeignKey("IdentityUser")]
        public string Id { get; set; }
        [JsonIgnore]
         public IdentityUser User { get; set; }

        
        public int ClinicID {  get; set; }
        [Required]
        public DentistCategory Category {  get; set; }
        [Required]
        public bool Availability {  get; set; }
        [Required]
        public int MaxAppointment {  get; set; }
        [JsonIgnore]

        public ICollection<Appointment> Appointments { get; set; }


    }
}
