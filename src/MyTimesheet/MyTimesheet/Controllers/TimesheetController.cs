using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        public IConfiguration IConfiguration { get; }
        public object MyRedisConnectorHelper { get; private set; }
        public object RedisConnectorHelper { get; private set; }

        readonly IConfiguration _config;
        public TimesheetController(TimesheetContext context, IConfiguration _config)
        {
            _db = context;
            IConfiguration = _config;

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
        public async Task<String> Post([FromBody] TimesheetEntry value)
        {
            await _db.Entries.AddAsync(value);
            await _db.SaveChangesAsync();

            var cacheConnection = _config.GetValue<String>("CacheConnection").ToString();
            var lazyConnecction = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            IDatabase cache = lazyConnecction.Value.GetDatabase();
            //var cacheItem = await cache.StringGetAsync($"{value.Name}--{value.Surname}");
            await cache.StringSetAsync($"{value.Name}-{value.Surname}",value.ToString());
            var cacheItem = await cache.StringGetAsync($"{value.Name}--{value.Surname}");
            lazyConnecction.Value.Dispose();

            var cach = RedisConnectorHelper.Connection.GetDatabase();
            cach.StringSet(cacheItem);

            // var cacheItem =  cache.Execute("KEYS","LIST").ToString();'
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhhost");
            redis.StringSet(cacheItem);
            //IDatabase db = redis.
            return cacheItem;
        }

        public void SaveRedisBigData()
        {
            
            var cache = MyRedisConnectorHelper.RedisConnection.GetDatabase();
            cache.StringSet($"MySampleData:{i}", value);

        }

        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] TimesheetEntry value)
        {
            var entry = await _db.Entries.FindAsync(id);
            entry = value;
            await _db.SaveChangesAsync();
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhhost");
        //IDatabase db = redis.

        ConnectionMultiplexer cach = RedisConnectorHelper.Connection.GetDatabase();
        cach.StringSet(cacheItem);
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
