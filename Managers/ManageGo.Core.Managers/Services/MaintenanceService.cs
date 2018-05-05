using System;
using ManageGo.Core.Services;

namespace ManageGo.Core.Managers.Services
{
    public class MaintenanceService : BaseHttpService
    {
        public MaintenanceService() : base(Constants.BaseApiUrl)
        { }
    }
}
