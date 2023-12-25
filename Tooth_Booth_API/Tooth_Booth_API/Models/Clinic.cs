using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Tooth_Booth_API.Models
{
    public class Clinic
    {

        [Key]
        public int ClinicId { get; set; }
        [ForeignKey("IdentityUser")]
        public string ClinicAdminId {  get; set; }
        [JsonIgnore]
        public IdentityUser ClinicAdmin { get; set; }
        public string ClinicName { get; set; }
        public string Description { get; set; }
        public string ClinicCity {  get; set; }
        [Required]
        public bool Isverified {  get; set; }
    }
}
