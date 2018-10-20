using System.Collections.Generic;
using ManageGo.Core.Managers.Models;

namespace ManageGo.Core.Managers
{
    public static class AppInstance
    {
        public static string ApiAccessToken { get; set; }

        public static List<User> Users { get; set; }

        public static class Maintenance
        {
            public static MaintenanceUserSettings Settings { get; set; }
        }
    }
}
