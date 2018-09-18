using System;
using System.Threading.Tasks;

using System.Reactive.Linq;
using Akavache;
using System.Reactive;
using ManageGo.Core.Services;

namespace ManageGo.Services
{
    public class CacheService : ICacheService
    {
        public CacheService(string applicationName)
        {
            BlobCache.ApplicationName = applicationName;
        }

        public async Task InsertObjectAsync<T>(string key, T value, TimeSpan expiration)
        {
            await BlobCache.UserAccount.InsertObject(key, value, expiration);
        }

        public async Task<T> GetObjectAsync<T>(string key)
        {
            return await BlobCache.UserAccount.GetObject<T>(key);
        }

        public async Task InvalidateObjectAsync<T>(string key)
        {
            await BlobCache.UserAccount.InvalidateObject<T>(key);
        }
    }
}
