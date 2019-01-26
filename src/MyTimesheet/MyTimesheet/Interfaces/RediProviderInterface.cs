using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Interfaces
{
    public interface RediProviderInterface
    {
        Task<bool> SaveAsync(string key, object obj);
        Task<string> GetAsync(string Key);


    }
}
