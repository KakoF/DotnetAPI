using Infra.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Infra.Abstractions
{
    public abstract class CacheAbstraction: IStorageCache
    {
        protected readonly string _CACHE_KEY;
       
        public CacheAbstraction(IConfiguration configuration)
        {
            _CACHE_KEY = configuration["CacheKey"];
        }
        public abstract Task<T> GetAsync<T>(string key);
        public abstract Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> function);

        public abstract void Set<T>(string key, T data);
        public abstract void Remove(string key);
    }

}
