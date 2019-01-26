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
    public class ProjectDetailsController : ControllerBase
    {
        private readonly TimesheetContext _db;
        public ProjectDetailsController(TimesheetContext context)
        {
            _db = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDetails>>> Get()
        {
            return await _db.ProjectDetailsEntries.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDetails>> Get(int id)
        {
            return await _db.ProjectDetailsEntries.FindAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] ProjectDetails value)
        {
            await _db.ProjectDetailsEntries.AddAsync(value);
            await _db.SaveChangesAsync();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ProjectDetails value)
        {
            var entry = await _db.ProjectDetailsEntries.FindAsync(id);
            entry = value;
            await _db.SaveChangesAsync();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var entry = await _db.ProjectDetailsEntries.FindAsync(id);
            _db.ProjectDetailsEntries.Remove(entry);
            await _db.SaveChangesAsync();
        }
    }

}