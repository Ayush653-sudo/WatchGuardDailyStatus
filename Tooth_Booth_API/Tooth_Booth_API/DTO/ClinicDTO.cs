using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tooth_Booth_API.DTO
{
    public class ClinicDTO
    {
        public int ClinicId { get; set; }
      
        public string ClinicAdminId { get; set; }
        public string ClinicName { get; set; }
        public string Description { get; set; }
        public string ClinicCity { get; set; }
      
        public bool Isverified { get; set; }
    }
}
