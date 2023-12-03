using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Data;
using RealEstateApi.Models;
using System.Security.Claims;

namespace RealEstateApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : Controller
    {
        ApiDBContext _dbContext=new ApiDBContext();
        [HttpGet("{PropertyList}")]
        public IActionResult GetProperties(int categoryId)
        {
            var propertiesResult = _dbContext.properties.Where(c => c.CategoryId == categoryId);

            if(propertiesResult==null)
                return NotFound();
            return Ok(propertiesResult);

        }
        [HttpGet("PropertyDetail")]
        [Authorize]
        public IActionResult GetPropertiesDetails(int id) 
        {
            var propertiesResult=_dbContext.properties.FirstOrDefault(p=>p.Id==id);
            if(propertiesResult==null)
                return NotFound();
            return Ok(propertiesResult);
        
        }
        [HttpGet("SearchProperties")]
        [Authorize]
        public IActionResult GetSearchResult(string address)
        {
            var propertiesResult=_dbContext.properties.Where((p)=>p.Address.Contains(address));
            if(propertiesResult==null)
                return NotFound();
            return Ok(propertiesResult);    
        }
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Property property)
        {
            if (property == null)
                return NoContent();
            else
            {
                var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var user = _dbContext.users.FirstOrDefault(u => u.Email == userEmail);
                if (user == null)
                    return NotFound();
                property.IsTrending = false;
                property.UserId = user.Id;
                _dbContext.properties.Add(property);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);

            }
        }
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody]Property property)
        {
           var propertyResult=_dbContext.properties.FirstOrDefault(p => p.Id == id);    
            if(propertyResult == null)
                return NoContent();
            else
            {
                var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var user = _dbContext.users.FirstOrDefault(u => u.Email == userEmail);
                if(user == null)
                    return NotFound();
                propertyResult.Name = property.Name;
                propertyResult.Description = property.Description;
                propertyResult.Price= property.Price;
                propertyResult.Address = property.Address;

                property.IsTrending = false;
                property.UserId = user.Id;
                _dbContext.properties.Add(property);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created) ;
            }
        }
    }
}
