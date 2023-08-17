
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace CourseWebApi.DAL.Caching
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public T Get<T>(string key)
        {
            var value = _cache.GetString(key);

            if (value != null)
            {
                return JsonSerializer.Deserialize<T>(value);
            }

            return default;
        }

        public object RemoveData(string key)
        {
            if (_cache.Get(key) != null)
            {
                return _cache.RemoveAsync(key);
            }
            return false;
        }

        public T Set<T>(string key, T value)
        {
            var timeOut = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
                SlidingExpiration = TimeSpan.FromSeconds(360)
            };

            _cache.SetString(key, JsonSerializer.Serialize(value), timeOut);

            return value;
        }

        public T Set<T>(string key, T value, int absoluteExpirationSeconds, int slidingExpirationSeconds)
        {
            var timeOut = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(absoluteExpirationSeconds),
                SlidingExpiration = TimeSpan.FromSeconds(slidingExpirationSeconds)
            };

            _cache.SetString(key, JsonSerializer.Serialize(value), timeOut);

            return value;
        }
    }

}
