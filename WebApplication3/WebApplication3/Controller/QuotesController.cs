using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private QuotesDbContext _quotesDbContext = new QuotesDbContext();

        [HttpGet]
        public IEnumerable<Quotes>Get()
        {
            return _quotesDbContext.Quotes;
        }
    
    }
}
