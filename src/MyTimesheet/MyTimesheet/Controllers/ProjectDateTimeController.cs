using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectDateTimeController : ControllerBase
    {
        private readonly TimesheetContext _db;
        public ProjectDateTimeController(TimesheetContext context)
        {
            _db = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDateTime>>> Get()
        {
            return await _db.ProjectDateTimeEntries.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDateTime>> Get(int id)
        {
            return await _db.ProjectDateTimeEntries.FindAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] ProjectDateTime value)
        {
            await _db.ProjectDateTimeEntries.AddAsync(value);
            await _db.SaveChangesAsync();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ProjectDateTime value)
        {
            var entry = await _db.ProjectDateTimeEntries.FindAsync(id);
            entry = value;
            await _db.SaveChangesAsync();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var entry = await _db.ProjectDateTimeEntries.FindAsync(id);
            _db.ProjectDateTimeEntries.Remove(entry);
            await _db.SaveChangesAsync();
        }
    }
}
