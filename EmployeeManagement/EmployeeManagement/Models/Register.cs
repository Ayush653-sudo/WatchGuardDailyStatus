using EmployeeManagement.Utils;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Register
    {
        [Required]
        [ValidEmailDomainAttributes(allowedDomain:"gmail.com",ErrorMessage="Email Domain must be gmail")]
        public string Email {  get; set; }
        public string Password { get; set; }
        public string City {  get; set; }
    }
}
