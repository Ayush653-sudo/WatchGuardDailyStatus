using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateApi.Data;

namespace RealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        ApiDBContext _dBContext=new ApiDBContext();
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_dBContext.categories);
        }
    }
}
