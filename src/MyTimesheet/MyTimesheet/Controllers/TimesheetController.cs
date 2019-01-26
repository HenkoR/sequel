using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace MyTimesheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetController : ControllerBase
    {
        private readonly TimesheetContext _db;
        private IConfiguration _config;
        public TimesheetController(TimesheetContext context, IConfiguration configuration)
        {
            _db = context;
            _config = configuration;
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
        public async Task<RedisValue> Post([FromBody] TimesheetEntry value)
        {
            await _db.Entries.AddAsync(value);
            await _db.SaveChangesAsync();

            var cacheConnection = _config.GetValue<string>("CacheConnection").ToString();
            var lazyConnection = new Lazy<ConnectionMultiplexer>(() => //connecting to our redis
            {
    
                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();
            //await cache.StringSetAsync($"{value.Name}-{value.Surname}", value.ToString()); //Adding to cache using this key

            //var cacheItem= await cache.StringGetAsync($"{value.Name}-{value.Surname}".ToString());//Reads the value


            //return cacheItem;

            //List of people in our cache, remember cache lies in memory
            var cacheItem = cache.Execute("KEYS", "LIST").ToString();

            //var cacheItem = cache.Execute("KEYS", "*").ToString();

            lazyConnection.Value.Dispose();

            return cacheItem;

            //Never store in the redis, because the stuff can get lost. not persstent. but there exists tools to make it persistent
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] TimesheetEntry value)
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
