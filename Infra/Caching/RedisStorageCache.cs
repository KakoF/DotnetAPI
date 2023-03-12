using Infra.Abstractions;
using Infra.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace Infra.Caching
{
    public class RedisStorageCache : CacheAbstraction, IRedisStorageCache
    {
        private readonly IDistributedCache _redisCache;
        private readonly DistributedCacheEntryOptions _redisOptions;
        private readonly ILogger<RedisStorageCache> _logger;

        public RedisStorageCache(IDistributedCache redisCache, IConfiguration configuration, ILogger<RedisStorageCache> logger) : base(configuration)
        {
            _redisCache = redisCache;
            _redisOptions = new DistributedCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMilliseconds(Convert.ToInt32(configuration["ConnectionStrings:redis:expriration_millisecond"])),
            };
            _logger = logger;
        }
        public override async Task<T> GetAsync<T>(string key)
        {
            try
            {
                var json = await _redisCache.GetStringAsync($"{_CACHE_KEY}:{key}");
                return (json == null) ? default(T) : JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Não foi possível recuperar o cache do Redis, chave -> {_CACHE_KEY}:{key}");
                return default(T);
            }
        }

        public async override Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> function)
        {
            var resultRedis = await GetAsync<T>(key);
            if (resultRedis != null) return resultRedis;

            var data = await function();

            Set(key, data);

            return data;
        }

        public override void Set<T>(string key, T data)
        {
            try
            {
                _redisCache.Set($"{_CACHE_KEY}:{key}", System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)), _redisOptions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Não foi possível setar o cache do Redis, chave -> {_CACHE_KEY}:{key}");
            }
            
        }

        public override void Remove(string key)
        {
            try
            {
                _redisCache.Remove($"{_CACHE_KEY}:{key}");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Não foi possível limpar o cache do Redis, chave -> {_CACHE_KEY}:{key}");
            }
          
        }

    }
}
