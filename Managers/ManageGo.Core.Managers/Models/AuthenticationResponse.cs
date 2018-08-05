using Newtonsoft.Json;

namespace ManageGo.Core.Managers.Models
{
    public class AuthenticationResponse
    {
        [JsonProperty(PropertyName = "UserInfo")]
        public User User { get; set; }

        [JsonProperty(PropertyName = "PMCInfo")]
        public PropertyManagementCompany PropertyManageCompany { get; set; }

        [JsonProperty(PropertyName = "Permissions")]
        public UserPermissions UserPersmissions { get; set; }
    }
}
