using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Tooth_Booth_API.Enum;

namespace Tooth_Booth_API.DTO
{
    public class DentistDTO
    {
        public string Id { get; set; }
        
        public int ClinicID { get; set; }
     
        public bool Availability { get; set; }
      
        public int MaxAppointment { get; set; }

        public DentistCategory Category { get; set; }
    }
}
