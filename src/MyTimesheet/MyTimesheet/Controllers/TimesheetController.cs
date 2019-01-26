﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<string> Post([FromBody] TimesheetEntry value)
        {
            await _db.Entries.AddAsync(value);
            await _db.SaveChangesAsync();

           
            var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                string cacheConnection = _config.GetValue<string>("CacheConnection").ToString();
                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            //await cache.StringSetAsync("key", "4");
            //var cacheItem = await cache.StringGetAsync($"{value.Name}--{value.Surname}");
            
            IDatabase cache = lazyConnection.Value.GetDatabase();
            await cache.StringSetAsync($"{value.Project.Name}--{value.Employee.Name}", value.ToString());
            var cacheItem = await cache.StringGetAsync($"{value.Project.Name}--{value.Employee.Name}");

            lazyConnection.Value.Dispose();
            
            return cacheItem;
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
