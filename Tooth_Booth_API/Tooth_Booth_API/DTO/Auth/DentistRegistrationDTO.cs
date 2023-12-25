using System.ComponentModel.DataAnnotations;
using Tooth_Booth_API.Enum;

namespace Tooth_Booth_API.DTO.Auth
{
    public class DentistRegistrationDTO : RegistrationDTO
    {



        public DentistCategory Category { get; set; }
        [Required]
        public bool Availability { get; set; }
        [Required]
        public int MaxAppointment { get; set; }


    }
}
