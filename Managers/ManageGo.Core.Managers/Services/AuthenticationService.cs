using System;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Services;

namespace ManageGo.Core.Managers.Services
{
    public class AuthenticationService : BaseHttpService
    {
        static readonly Lazy<AuthenticationService> lazy = new Lazy<AuthenticationService>(() => new AuthenticationService());
        public static AuthenticationService Instance { get { return lazy.Value; } }

        AuthenticationService() : base(Constants.BaseApiUrl) { }

        public Task<BaseResponse<AuthenticationResponse>> Authenticate(string username, string password) 
            => PostAsync<BaseResponse<AuthenticationResponse>, AuthenticationRequest>("authorize", 
                                                                        new AuthenticationRequest { Login = username, Password = password });
    }
}
