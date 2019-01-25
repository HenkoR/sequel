using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace MyTimesheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _db;
        readonly IConfiguration _config;
        public EmployeeController(EmployeeContext context, IConfiguration config)
        {
            _db = context;
            _config = config;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeEntry>>> Get()
        {

            return await _db.Entries.ToListAsync();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeEntry>> Get(int id)
        {
            return await _db.Entries.FindAsync(id);


        }

        // POST api/values
        [HttpPost]
        public async Task<string> Post([FromBody] EmployeeEntry value)
        {

            await _db.Entries.AddAsync(value);
            await _db.SaveChangesAsync();




            return value.EmployeeId + " - " + value.Name + " : " + value.Surname;



        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] EmployeeEntry value)
        {
            var entry = await _db.Entries.FindAsync(id);
            entry = value;
            await _db.SaveChangesAsync();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var entry = await _db.Entries.FindAsync(id);
            _db.Entries.Remove(entry);
            await _db.SaveChangesAsync();
        }
    }
}
