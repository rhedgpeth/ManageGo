using System;
using System.Net.Http;
using ManageGo.Core.Services;

namespace ManageGo.Core.Managers.Services
{
    public abstract class BaseAuthenticatedHttpService : BaseHttpService
    {
        public BaseAuthenticatedHttpService() : base(Constants.BaseApiUrl)
        { }

        protected void AddAccessToken(HttpRequestMessage message)
        {
            message.Headers.Add("AccessToken", AppInstance.ApiAccessToken);
        }
    }
}
