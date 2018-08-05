using System;
using System.Threading.Tasks;
using ManageGo.Core.Services;
using Xamarin.Essentials;

namespace ManageGo.Services
{
    public class SecureStorageService : ISecureStorageService
    {
        public async Task<bool> Set(string key, string value)
        {
            try
            {
                await SecureStorage.SetAsync(key, value);

                return true;
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.

                // TODO: Handle this better

                return false;
            }
        }

        public async Task<string> Get(string key)
        {
            try
            {
                return await SecureStorage.GetAsync(key);
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.

                // TODO: Handle this better

                return null;
            }
        }

        public bool Remove(string key) => SecureStorage.Remove(key);
    }
}
