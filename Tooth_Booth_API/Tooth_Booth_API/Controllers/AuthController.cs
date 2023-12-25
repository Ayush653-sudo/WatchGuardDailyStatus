

using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.DTO.Auth;
using Tooth_Booth_API.Enum;
using Tooth_Booth_API.Models;

namespace Tooth_Booth_API.Controllers
{


    [Route("[controller]")]
    public class AuthController:ControllerBase
    {

        private readonly IAuthBusiness _authBusiness;
       
       public AuthController(IAuthBusiness authBusiness)
        {
        
            _authBusiness = authBusiness;


        }

        [HttpPost("Register/Dentist")]
        
        public async Task<IActionResult> RegisterDentist([FromBody]DentistRegistrationDTO userInput)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

         
                bool result=await _authBusiness.AddDentist(userId,userInput);
                

                 if (result)
                {
                    return Ok("User Created and loggedIn");
                }
            }
            return BadRequest("Something went wrong");
           
        }
        [HttpPost("Register/Clinic")]

        public async Task<IActionResult> RegisterClinic([FromBody] ClinicRegistrationDTO userInput)
        {
            if (ModelState.IsValid)
            {
        
               bool result = await _authBusiness.AddClinic(userInput);


                if (result)
                {
                    return Ok("Clinic Admin and Clinic Created Sucessfully");
                }
            }
            return BadRequest("Something went wrong");

        }
        [HttpPost("Register/Patient")]
        public async Task<IActionResult> RegisterPatient([FromBody]RegistrationDTO userInput)
        {
            var user = new IdentityUser { UserName = userInput.UserName, Email = userInput.EmailAddress};

            bool isRegistered = await _authBusiness.AddUser(user, userInput.Password, "Patient");
              if (isRegistered)
            {
            return Ok(" Registration Sucessfull");
            }
            return BadRequest();
            
        }
        [HttpPost("Register/Admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegistrationDTO userInput)
        {
            var user = new IdentityUser { UserName = userInput.UserName, Email = userInput.EmailAddress };

            bool isRegistered = await _authBusiness.AddUser(user, userInput.Password, "Admin");
           if (isRegistered)
            {
                return Ok(" Registration Sucessfull");
            }
            return BadRequest();

        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginModel)
        {
            var result = await _authBusiness.LogIn(userLoginModel);
            if (result)
            {
                return Ok("Sucessfully Logged In");
            }
            return Unauthorized("Invalid Login Attempts ");
        }      

    }
}
