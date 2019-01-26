using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyTimesheet.Models;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace MyTimesheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly TimesheetContext _db;
        private readonly IConfiguration _config;
        private Lazy<ConnectionMultiplexer> lazy;
        string cacheConnection;
        public DeveloperController(TimesheetContext context, IConfiguration config)
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
        public async Task<ActionResult<IEnumerable<Developer>>> Get()
        {
            
            try
            {
                IDatabase cache = lazy.Value.GetDatabase();
                var result = await cache.ExecuteAsync("KEYS", "*");
                return JsonConvert.DeserializeObject<List<Developer>>(result.ToString());
            } catch (Exception e)
            {
                return await _db.DeveloperEntries.ToListAsync();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> Get(int id)
        {
            IDatabase cache = lazy.Value.GetDatabase();
            var result = await cache.StringGetAsync($"{id}");
            

            if (!result.HasValue)
            {
                var value = await _db.DeveloperEntries.FindAsync(id);
                await cache.StringSetAsync($"{id}", JsonConvert.SerializeObject(value));
                return value;
            } else
            {
                return JsonConvert.DeserializeObject<Developer>(result);
            }
            
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] Developer value)
        {
            
            await _db.DeveloperEntries.AddAsync(value);
            await _db.SaveChangesAsync();

            IDatabase cache = lazy.Value.GetDatabase();
            var json = JsonConvert.SerializeObject(value);

            await cache.StringSetAsync($"{value.Id}", json);
            lazy.Value.Dispose();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Developer value)
        {
            var entry = await _db.DeveloperEntries.FindAsync(id);
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
            var entry = await _db.DeveloperEntries.FindAsync(id);
            _db.DeveloperEntries.Remove(entry);
            await _db.SaveChangesAsync();
            
        }
    }

}