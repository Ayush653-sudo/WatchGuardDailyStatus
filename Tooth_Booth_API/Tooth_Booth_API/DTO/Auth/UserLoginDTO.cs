using System.ComponentModel.DataAnnotations;

namespace Tooth_Booth_API.DTO.Auth
{
    public class UserLoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
