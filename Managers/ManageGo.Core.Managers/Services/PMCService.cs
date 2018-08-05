using System;
using System.Threading;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;

namespace ManageGo.Core.Managers.Services
{
    public class PMCService : BaseAuthenticatedHttpService
    {
        static readonly Lazy<PMCService> lazy = new Lazy<PMCService>(() => new PMCService());
        public static PMCService Instance { get { return lazy.Value; } }

        PMCService() { }

        public Task<BaseResponse<Dashboard>> GetDashboard() 
            => PostAsync<BaseResponse<Dashboard>>("dashboard", default(CancellationToken), AddAccessToken); 
    }
}
