using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RealEstateApi.Data;
using RealEstateApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstateApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        ApiDBContext _dbContext= new ApiDBContext();
        private IConfiguration _config;

        public UsersController(IConfiguration config)
        {
            this._config = config;
        }

        [HttpPost("[action]")]
        public IActionResult Register([FromBody] User users)
        {
          var userExists=  _dbContext.users.FirstOrDefault(u=>u.Email == users.Email);
            if (userExists!=null)
            {
                return BadRequest("User with same email already exists");   
            }
            _dbContext.users.Add(users);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromBody] User user) 
        {
        var currentUser= _dbContext.users.FirstOrDefault((u)=>u.Email == user.Email);   
            if (currentUser==null) 
            { 
            return NotFound();
            }
          var securityKey=  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
           var credential= new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),


            };
            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials:credential
                ) ;
          var jwt=new JwtSecurityTokenHandler().WriteToken(token) ;
           return Ok(jwt);



        }
        
    }
}
