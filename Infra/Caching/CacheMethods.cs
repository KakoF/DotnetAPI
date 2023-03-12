using Domain.Interfaces.Cache;
using Infra.Interfaces;

namespace Infra.Caching
{
    public class CacheMethods : ICacheMethods
    {
        private readonly IMemoryStorageCache _memoryCache;
        private readonly IRedisStorageCache _redisCache;
        public CacheMethods(IMemoryStorageCache memoryCache, IRedisStorageCache redisCache)
        {
            _memoryCache = memoryCache;
            _redisCache= redisCache;
        }
        public async Task<T> GetAsync<T>(string key, Func<Task<T>> function)
        {
            var resultMemory = await _memoryCache.GetAsync<T>(key);
            if (resultMemory != null) return resultMemory;


            var resultRedis = await _redisCache.GetAsync<T>(key);
            if (resultRedis != null) return resultRedis;
            var data = await function();
            return data;
        }

        public async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> function)
        {
            
            var resultMemory = await _memoryCache.GetAsync<T>(key);
            if(resultMemory != null ) return resultMemory;
            
            
            var resultRedis = await _redisCache.GetAsync<T>(key);
            if(resultRedis != null ) return resultRedis;

            var data = await function();

            Set(key, data);

            return data;
        }

        public void Set<T>(string key, T data)
        {
            _memoryCache.Set(key, data);
            _redisCache.Set(key, data);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
            _redisCache.Remove(key);
        }
    }
}
