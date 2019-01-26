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
            var cacheConnection = _config.GetValue<string>("CacheConnection").ToString();//That is the connection string
            var lazyConnection = new Lazy<ConnectionMultiplexer>(() => //connecting to our Redis
            {
                //Connecting to Redis
                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();//This is the connection to the Redis database

            string key = Convert.ToString(id);
            if (!cache.KeyExists(key))
            {
                return await _db.Entries.FindAsync(id);
            }
            else await cache.StringGetAsync(key);
            return await _db.Entries.FindAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<RedisValue> Post([FromBody] TimesheetEntry value)
        {
            await _db.Entries.AddAsync(value);
            await _db.SaveChangesAsync();

            var cacheConnection = _config.GetValue<string>("CacheConnection").ToString();//That is the connection string
            var lazyConnection = new Lazy<ConnectionMultiplexer>(() => //connecting to our Redis
            {
                //Connecting to Redis
                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();//This is the connection to the Redis database

            //Adding to cache using this key which is the ID and the values
            string key = Convert.ToString(value.Id);
            await cache.StringSetAsync(key,value.ToString());
            await cache.KeyPersistAsync(key); //Creating peristence on the key, in order for it to always be saved on cache

            //List of people in our cache, remember cache lies in memory
            var cacheItem = cache.Execute("KEYS", "*").ToString();

            lazyConnection.Value.Dispose();

            return cacheItem;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] TimesheetEntry value)
        {
            var entry = await _db.Entries.FindAsync(id);
            entry = value;

            var cacheConnection = _config.GetValue<string>("CacheConnection").ToString();//That is the connection string
            var lazyConnection = new Lazy<ConnectionMultiplexer>(() => //connecting to our Redis
            {
                //Connecting to Redis
                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();//This is the connection to the Redis database

            //Adding to cache using this key which is the ID and the values
            string key = Convert.ToString(id);
            await cache.StringSetAsync(key, value.ToString());
            await cache.KeyPersistAsync(key); //Creating peristence on the key, in order for it to always be saved on cache
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
