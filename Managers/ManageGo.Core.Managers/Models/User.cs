using Newtonsoft.Json;

namespace ManageGo.Core.Managers.Models
{
    public class User
    {
        /*
        "AccessToken": "2903c1a1-6c67-4df2-9dc9-83292ba28dc0",
        "UserFirstName": "PMC",
        "UserLastName": "Admin",
        "UserEmailAddress": "pmc.mail.test@gmail.com",
        "UserID": 354,
        "PaymentPushNotification": false,
        "MaintenancePushNotification": false,
        "TenantPushNotification": false
        */

        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "UserID")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "UserFirstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "UserLastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "UserEmailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "PaymentPushNotification")]
        public bool AllowPaymentPushNotifications { get; set; }

        [JsonProperty(PropertyName = "MaintenancePushNotification")]
        public bool AllowMaintenancePushNotifications { get; set; }

        [JsonProperty(PropertyName = "TenantPushNotification")]
        public bool AllowTenantPushNotifications { get; set; }
    }
}
