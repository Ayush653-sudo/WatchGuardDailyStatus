using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class LogIn
    {
        [Required]
        public string Email {  get; set; }
        [Required]
        public string Password {  get; set; }
        public string RememberMe {  get; set; }

    }
}
