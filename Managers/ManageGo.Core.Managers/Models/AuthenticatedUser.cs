using Newtonsoft.Json;

namespace ManageGo.Core.Managers.Models
{
    public class AuthenticatedUser : User
    {
        public string AccessToken { get; set; }

        public bool PaymentPushNotification { get; set; }

        public bool MaintenancePushNotification { get; set; }

        public bool TenantPushNotification { get; set; }
    }
}
