using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTimesheet.Models;

namespace MyTimesheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly TimesheetContext _db;
        public DeveloperController(TimesheetContext context)
        {
            _db = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Developer>>> Get()
        {
            return await _db.DeveloperEntries.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> Get(int id)
        {
            return await _db.DeveloperEntries.FindAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] Developer value)
        {
            await _db.DeveloperEntries.AddAsync(value);
            await _db.SaveChangesAsync();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Developer value)
        {
            var entry = await _db.DeveloperEntries.FindAsync(id);
            entry = value;
            await _db.SaveChangesAsync();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var entry = await _db.DeveloperEntries.FindAsync(id);
            _db.DeveloperEntries.Remove(entry);
            await _db.SaveChangesAsync();
        }
    }

}