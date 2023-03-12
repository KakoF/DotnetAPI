using Infra.Abstractions;
using Infra.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infra.Caching
{
    public class MemoryStorageCache : CacheAbstraction, IMemoryStorageCache
    {
        private readonly IMemoryCache _memoryCache;
        private readonly TimeSpan _timeExpiration;
        private readonly ILogger<MemoryStorageCache> _logger;
        public MemoryStorageCache(IMemoryCache memoryCache, IConfiguration configuration, ILogger<MemoryStorageCache> logger) : base(configuration)
        {
            _memoryCache = memoryCache;
            _timeExpiration = TimeSpan.FromMilliseconds(Convert.ToInt32(configuration["ConnectionStrings:memoryCache:expriration_millisecond"]));
            _logger = logger;
        }
        public override Task<T> GetAsync<T>(string key)
        {
            try
            {
                return Task.FromResult(_memoryCache.Get<T>($"{_CACHE_KEY}:{key}"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Não foi possível recuperar o cache do Memory Cache, chave -> {_CACHE_KEY}:{key}");
                return Task.FromResult(default(T));
            }
            
        }

        public override async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> function)
        {
            var resultMemory = await GetAsync<T>(key);
            if (resultMemory != null) return resultMemory;

            var data = await function();

            Set(key, data);

            return data;
        }

        public override void Remove(string key)
        {
            try
            {
                _memoryCache.Remove($"{_CACHE_KEY}:{key}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Não foi possível limpar o cache do Memory Cache, chave -> {_CACHE_KEY}:{key}");
            }
            
        }

        public override void Set<T>(string key, T data)
        {
            try
            {
                _memoryCache.Set($"{_CACHE_KEY}:{key}", data, _timeExpiration);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Não foi possível setar o cache do Memory Cache, chave -> {_CACHE_KEY}:{key}");
            }
           
        }
    }
}