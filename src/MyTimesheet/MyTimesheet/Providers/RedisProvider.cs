using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyTimesheet.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Providers
{
    public class RedisProvider : RediProviderInterface
    {
        private readonly ILogger<RedisProvider> _logger;
        private readonly IConfiguration _config;
        private IDatabase cache;

        public RedisProvider(ILogger<RedisProvider> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            var cacheConnection = _config.GetValue<string>("CacheConnection").ToString();
            var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(cacheConnection);
            });

            cache = lazyConnection.Value.GetDatabase();
        }
        public async Task<bool> SaveAsync(string key, object obj)
        {

            await cache.StringSetAsync(key, obj.ToString());

            var cacheItem = await cache.StringGetAsync(key);
            if (cacheItem.ToString().Length > 0)
                return true;
            else return false;
        }
        public async Task <string> GetAsync(string Key)
        {
            return await cache.StringGetAsync(Key);
        }

    }
}
