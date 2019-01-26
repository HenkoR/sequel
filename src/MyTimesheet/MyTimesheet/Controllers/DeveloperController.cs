using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController: ControllerBase
    {
        private readonly TimesheetContext _db;
   
        public DeveloperController(TimesheetContext context)
        {
            _db = context;
         
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Developer>>> Get()
        {
            return await _db.DevEntries.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> Get(int id)
        {
            return await _db.DevEntries.FindAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] Developer value)
        {
            await _db.DevEntries.AddAsync(value);
            await _db.SaveChangesAsync();

            // var cacheConnection = _config.GetValue<string>("CacheConnection").ToString();

            //var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            //{
            //return ConnectionMultiplexer.Connect(cacheConnection);
            // });
            // IDatabase cache = lazyConnection.Value.GetDatabase();
            // await cache.StringSetAsync($"{value.Name}-{value.Surname}",value.ToString());

            //var cacheItem = await cache.StringGetAsync($"{value.Name}-{value.Surname}");


            //  lazyConnection.Value.Dispose();
            //  return cacheItem;

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Developer value)
        {
            var entry = await _db.DevEntries.FindAsync(id);
            entry = value;
            await _db.SaveChangesAsync();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var entry = await _db.DevEntries.FindAsync(id);
            _db.DevEntries.Remove(entry);
            await _db.SaveChangesAsync();
        }
    }


}
