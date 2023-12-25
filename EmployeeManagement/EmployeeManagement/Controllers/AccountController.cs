using EmployeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
   
    
    public class AccountController : Controller
    {

        public UserManager<ApplicationUser> UserManager { get; set; }
        public SignInManager<ApplicationUser> SignInManager { get; set; }
        public AccountController(UserManager<ApplicationUser>userManager,
            SignInManager<ApplicationUser>signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return Ok("User LogOut Sucessfully");
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]Register model)
        {
            
                Console.WriteLine("aaa");
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email,City=model.City };
           
                var result=await UserManager.CreateAsync(user, model.Password);
          
            if (result.Succeeded)
                {
                   await SignInManager.SignInAsync(user, isPersistent: false);
                    return Ok("User Registered sucessfully");
                }
                foreach(var error in result.Errors) 
                { 
                ModelState.AddModelError(string.Empty, error.Description);
                }
                return StatusCode(400, ModelState); 
            
         //   return StatusCode(400);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LogIn model)
        {
            if(ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe=="false"?false:true,false);
                if(result.Succeeded)
                {
                    return Ok("User LogIn Sucessfully");
                }
                else
                {
                    return NotFound("User not able to login");
                }
                
            }
            return StatusCode(400, ModelState);

        }

    }
}
