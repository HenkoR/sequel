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
        public async Task<string> Get(int id)
        {
            var cacheConnection = _config.GetValue<string>("CacheConnection").ToString();

            var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {

                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();
            var cacheItem = await cache.StringGetAsync(id.ToString());


            return cacheItem;
        }

        // POST api/values
        [HttpPost]
        public async Task<string> Post([FromBody] TimesheetEntry value)
        {
            await _db.Entries.AddAsync(value);
            await _db.SaveChangesAsync();
            var cacheConnection = _config.GetValue<string>("CacheConnection").ToString();



            //var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            //{
            //    string cacheConnection = ConfigurationManager.AppSettings["CacheConnection"].ToString();
            //    return ConnectionMultiplexer.Connect(cacheConnection);
            //});

            //// Connection refers to a property that returns a ConnectionMultiplexer
            //// as shown in the previous example.
            //IDatabase cache = lazyConnection.Value.GetDatabase();

            var data = await _db.Entries.Include(v => v.Employee).Include(c => c.Project).Include(c => c.Project.Client).FirstOrDefaultAsync(x => x.Employee.Id == value.Employee.Id);
            var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {

                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            IDatabase cache = lazyConnection.Value.GetDatabase();

            await cache.StringSetAsync(data.Id.ToString(), JsonConvert.SerializeObject(data));

            var cacheItem = await cache.StringGetAsync(data.Id.ToString());

            lazyConnection.Value.Dispose();
            return cacheItem.ToString(); ;
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
