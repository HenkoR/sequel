using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using StackExchange.Redis;
using Microsoft.Extensions.Configuration;

namespace MyTimesheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly TimesheetContext _db;
        private readonly IConfiguration _configuration;
        public SessionController(TimesheetContext context, IConfiguration config)
        {
            _db = context;
            _configuration = config;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Session>>> Get()
        {
            return await _db.Sessions.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{Session_Id}")]
        public async Task<ActionResult<Session>> Get(int id)
        {
            return await _db.Sessions.FindAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<String> Post([FromBody] Session value)
        {
            await _db.Sessions.AddAsync(value);
            await _db.SaveChangesAsync();

            var cacheConnection = _configuration.GetValue<String>("CacheConnection").ToString();
            var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {

                return ConnectionMultiplexer.Connect(cacheConnection);
            });
            IDatabase cache = lazyConnection.Value.GetDatabase();
            await cache.SetAddAsync($"{value.Date} - {value.TimeStart} - {value.TimeEnd}", value.ToString());
            var cacheItem = await cache.StringGetAsync($"{value.Date} - {value.TimeStart} - {value.TimeEnd}");

            lazyConnection.Value.Dispose();
            return cacheItem;
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Session value)
        {
            var entry = await _db.Sessions.FindAsync(id);
            entry = value;
            await _db.SaveChangesAsync();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var entry = await _db.Sessions.FindAsync(id);
            _db.Sessions.Remove(entry);
            await _db.SaveChangesAsync();
        }
    }
}
