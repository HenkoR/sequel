using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using MyTimesheet.Interfaces;
using MyTimesheet.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetController : ControllerBase
    {
        private readonly TimesheetContext _db;
        readonly IConfiguration _config;
        private RediProviderInterface _redisPovider;
        public TimesheetController(TimesheetContext context, IConfiguration config, RediProviderInterface redisProvider)
        {
            _db = context;
            _config = config;
            _redisPovider = redisProvider;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimesheetEntry>>> Get()
        {

            var EntriesList =  await _db.Entries.ToListAsync();
            foreach(var entry in EntriesList)
            {
                entry.person = await _db.Person.FindAsync(entry.personId);
                entry.date = await _db.Date.FindAsync(entry.dateId);
                entry.client = await _db.Client.FindAsync(entry.clientIid);
            }
            return EntriesList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimesheetEntry>> Get(int id)
        {
            var entry =  await _db.Entries.FindAsync(id);
            entry.person = await _db.Person.FindAsync(entry.personId);
            entry.date = await _db.Date.FindAsync(entry.dateId);
            entry.client = await _db.Client.FindAsync(entry.clientIid);
            var thisOne = _redisPovider.GetAsync($"{entry.person.Name}-{entry.person.Surname}");
            return entry;

        }

        // POST api/values
        [HttpPost]
        public async Task<string> Post([FromBody] TimesheetEntry value)
        {
            await _db.Entries.AddAsync(value);
            await _db.SaveChangesAsync();


            var Saved = await _redisPovider.SaveAsync($"{value.person.Name}-{value.person.Surname}", value);
            if (Saved)
                return "Sucesfully saved to redis";
            else return "Failed to save to reis";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] TimesheetEntry value)
        {
            var entry = await _db.Entries.FindAsync(id);
            entry = value;
            await _db.SaveChangesAsync();
            var Saved = await _redisPovider.SaveAsync($"{entry.person.Name}-{entry.person.Surname}", value);
            

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
