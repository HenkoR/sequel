using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyTimesheet.Models;
using Newtonsoft.Json;
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
        public TimesheetController(TimesheetContext context,IConfiguration config)
        {
            _db = context;
            _config = config;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimesheetEntry>>> Get()
        {
            return await _db.Entries.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimesheetEntry>> Get(int id)
        {
            return await _db.Entries.FindAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<string> Post([FromBody] TimesheetEntry value)
        {

            await _db.Entries.AddAsync(value);
            await _db.SaveChangesAsync();




            var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {

                return ConnectionMultiplexer.Connect(_config.GetValue<string>("CacheConnection"));
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();
            var SerialData = JsonConvert.SerializeObject(value);
            await cache.StringSetAsync($"{value.Id}", SerialData);

            var CacheItem = await cache.StringGetAsync($"{value.Id}");
            lazyConnection.Value.Dispose();

            return CacheItem;



        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] TimesheetEntry value)
        {
            var entry = await _db.Entries.FindAsync(id);
            entry = value;
            await _db.SaveChangesAsync();

            var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {

                return ConnectionMultiplexer.Connect(_config.GetValue<string>("CacheConnection"));
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            var cacheItem = await cache.StringGetAsync($"{id}");
            var SerData = JsonConvert.SerializeObject(value);
            await cache.StringSetAsync($"{value.Id}", SerData);
            lazyConnection.Value.Dispose();

            return JsonConvert.SerializeObject(value);
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
