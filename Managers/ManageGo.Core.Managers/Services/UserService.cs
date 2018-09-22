using System;
using System.Threading;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;

namespace ManageGo.Core.Managers.Services
{
    public class UserService : BaseAuthenticatedHttpService
    {
        static readonly Lazy<UserService> lazy = new Lazy<UserService>(() => new UserService());
        public static UserService Instance { get { return lazy.Value; } }

        UserService() { }

        public Task<BaseResponse> SaveUserSettings(AuthenticatedUser user)
            => PostAsync<BaseResponse, AuthenticatedUser>("usersettings", user, default(CancellationToken), AddAccessToken);
    }
}
