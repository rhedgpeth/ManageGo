﻿using System.Threading.Tasks;

namespace ManageGo.Core.Services
{
    public interface ISecureStorageService
    {
        Task<bool> Set(string key, string value);
        Task<string> Get(string key);
        bool Remove(string key);
    }
}
