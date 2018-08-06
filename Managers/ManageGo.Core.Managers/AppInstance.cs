using System;
using ManageGo.Core.Managers.Models;

namespace ManageGo.Core.Managers
{
    public static class AppInstance
    {
        public static string ApiAccessToken;

        public static class Maintenance
        {
            public static MaintenanceUserSettings Settings { get; set; }
        }
    }
}
