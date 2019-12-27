using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    // http:localhost:5000/api/{values}
    [Route("api/[controller]")] //Attribute based routing (Mapped as endpoint) 
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context; // Where to store database

        public ValuesController(DataContext context)
        {
            _context = context; //Get the database 
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues() // Use async to ensure the code runs even when processing the list of values
        {
            var values = await _context.Values.ToListAsync();//gets the values as a list

            return Ok(values);
        }

        // GET api/values/5(any number)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var values = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);//gets the values by finding the first instance that the id from the page is equal to any of the id in the database

            return Ok(values);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
