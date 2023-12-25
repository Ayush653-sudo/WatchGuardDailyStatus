using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private QuotesDbContext _quotesDbContext;

        public QuotesController(QuotesDbContext quotesDbContext)
        {
            _quotesDbContext = quotesDbContext;
        }

        [HttpGet]
        [ResponseCache(Duration =60,Location =ResponseCacheLocation.Client)]
        public IActionResult Get()
        {
            return StatusCode(200, _quotesDbContext.Quotes);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           
            var entity= _quotesDbContext.Quotes.Find(id);
            if(entity == null)
                return NotFound("Id does not exists");
            return Ok(entity);
        }
        [HttpGet]
        public IActionResult PagingQuote(int? pageNumber,int? pageSize)
        {
            var quotes=_quotesDbContext.Quotes;
            var currentPageNumber = pageNumber ?? 1;
            var currentPageSize = pageSize ?? 2;
            return StatusCode(200,quotes.Skip((currentPageNumber-1)*currentPageSize).Take(currentPageSize));

        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult SearchQuote(string type)
        {
            var quotes=_quotesDbContext.Quotes.Where(q=>q.Description.StartsWith(type));
            return Ok(quotes);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Quotes quote)
        {
            _quotesDbContext.Quotes.Add(quote);
            _quotesDbContext.SaveChanges();
            return Ok("Added sucessfully");
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Quotes quote)
        {
            var entity = _quotesDbContext.Quotes.Find(id);
            if (entity ==null)
            return NotFound("No record found");
            entity.Title = quote.Title;
            entity.Description = quote.Description;
            entity.Author = quote.Author;
            _quotesDbContext.SaveChanges();
            return Ok("Record updated sucessfully");
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           var entityToBeDeleted= _quotesDbContext.Quotes.Find(id);
            _quotesDbContext.Remove(entityToBeDeleted);
            _quotesDbContext.SaveChanges();
        }
    
    }
}
