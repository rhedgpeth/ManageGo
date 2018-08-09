using Newtonsoft.Json;

namespace ManageGo.Core.Managers.Models
{
    public class AuthenticatedUser : User
    {
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "PaymentPushNotification")]
        public bool AllowPaymentPushNotifications { get; set; }

        [JsonProperty(PropertyName = "MaintenancePushNotification")]
        public bool AllowMaintenancePushNotifications { get; set; }

        [JsonProperty(PropertyName = "TenantPushNotification")]
        public bool AllowTenantPushNotifications { get; set; }
    }
}
