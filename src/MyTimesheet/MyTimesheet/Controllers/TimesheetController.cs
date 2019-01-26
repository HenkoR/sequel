using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
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
        public TimesheetController(TimesheetContext context, IConfiguration config)
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
        public async Task<String> Post([FromBody] TimesheetEntry value)
        {

            await _db.Entries.AddAsync(value);
            await _db.SaveChangesAsync();

            var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                string cacheConnection = _config.GetValue<string>("CacheConnection").ToString();
                return ConnectionMultiplexer.Connect(cacheConnection);
            });


            IDatabase cache = lazyConnection.Value.GetDatabase() ;





            TimesheetEntry results = _db.Entries.Include(v => v.Employee).Include(c => c.Project).Include(v => v.Project.Client).FirstOrDefault(x => x.Id == value.Id);


            await cache.StringSetAsync(results.Id.ToString(), JsonConvert.SerializeObject(results));
            // await cache.StringSetAsync($"{value.Employee.Name}-{value.Employee.Surname}", $"{{value.Employee.Name}-{value.Employee.Surname}");

            var   cacheItem =  await cache.StringGetAsync(results.Id.ToString());

          //  var cacheItem = cache.ExecuteAsync("KEYS *").ToString();

            //var cacheItem = ya;
         //   lazyConnection.Value.Dispose();

            return cacheItem.ToString();

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
