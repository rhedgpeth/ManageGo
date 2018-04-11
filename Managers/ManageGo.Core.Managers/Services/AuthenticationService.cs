using System;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Services;

namespace ManageGo.Core.Managers.Services
{
    public class AuthenticationService : BaseHttpService
    {
        public AuthenticationService() : base(Constants.BaseApiUrl)
        { }

        public Task<AuthResponse> Authenticate(string username, string password) 
            => PostAsync<AuthResponse, AuthRequest>("authorize", new AuthRequest { Username = username, Password = password });
    }
}
