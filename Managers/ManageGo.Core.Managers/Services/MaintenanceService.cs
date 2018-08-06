using System;
using System.Threading;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;

namespace ManageGo.Core.Managers.Services
{
    public class MaintenanceService : BaseAuthenticatedHttpService
    {
        static readonly Lazy<MaintenanceService> lazy = new Lazy<MaintenanceService>(() => new MaintenanceService());
        public static MaintenanceService Instance { get { return lazy.Value; } }

        MaintenanceService() { }

        public Task<BaseResponse<MaintenanceUserSettings>> GetUserSettings()
            => PostAsync<BaseResponse<MaintenanceUserSettings>>("maintenanceobjects", default(CancellationToken), AddAccessToken); 
    }
}
