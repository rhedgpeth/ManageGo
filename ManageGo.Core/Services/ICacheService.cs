using System;
using System.Threading.Tasks;

namespace ManageGo.Core.Services
{
    public interface ICacheService
    {
        Task InsertObjectAsync<T>(string key, T value, TimeSpan expiration);

        Task<T> GetObjectAsync<T>(string key);

        Task InvalidateObjectAsync<T>(string key);
    }
}
