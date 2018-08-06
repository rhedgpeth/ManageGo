using System.Threading.Tasks;

namespace ManageGo.Core.Services
{
    public interface ISecureStorageService
    {
        Task<bool> SetAsync(string key, string value);
        Task<string> GetAsync(string key);
        bool Remove(string key);
    }
}
