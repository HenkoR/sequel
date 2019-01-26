using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace MyTimesheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesheetController : ControllerBase
    {
        private readonly TimesheetContext _db;
        private readonly IConfiguration _config;
        private Lazy<ConnectionMultiplexer> lazy;
        string cacheConnection;

        public TimesheetController(TimesheetContext context, IConfiguration config)
        {
            _db = context;
            _config = config;
            cacheConnection = _config.GetValue<string>("CacheConnection").ToString();
            lazy = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(cacheConnection);
            });
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimesheetEntry>>> Get()
        {
            try
            {
                IDatabase cache = lazy.Value.GetDatabase();
                var result = await cache.ExecuteAsync("KEYS", "*");
                return JsonConvert.DeserializeObject<List<TimesheetEntry>>(result.ToString());
            }
            catch (Exception e)
            {
                return await _db.Entries.ToListAsync();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimesheetEntry>> Get(int id)
        {
            IDatabase cache = lazy.Value.GetDatabase();
            var result = await cache.StringGetAsync($"{id}");


            if (!result.HasValue)
            {
                var value = await _db.Entries.FindAsync(id);
                await cache.StringSetAsync($"{id}", JsonConvert.SerializeObject(value));
                return value;
            }
            else
            {
                return JsonConvert.DeserializeObject<TimesheetEntry>(result);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] TimesheetEntry value)
        {
            await _db.Entries.AddAsync(value);
            await _db.SaveChangesAsync();

            IDatabase cache = lazy.Value.GetDatabase();
            var json = JsonConvert.SerializeObject(value);

            await cache.StringSetAsync($"{value.Id}", json);
            lazy.Value.Dispose();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] TimesheetEntry value)
        {
            var entry = await _db.Entries.FindAsync(id);
            entry = value;
            await _db.SaveChangesAsync();


            IDatabase cache = lazy.Value.GetDatabase();
            var json = JsonConvert.SerializeObject(value);

            await cache.StringSetAsync($"{value.Id}", json);
            lazy.Value.Dispose();
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
