using Newtonsoft.Json;

namespace ManageGo.Core.Managers.Models
{
    public class UserPermissions
    {
        [JsonProperty(PropertyName = "ListOfBuildingsUserHasAccess")]
        public int[] BuildingIDs { get; set; }

        [JsonProperty(PropertyName = "AccessToPayments")]
        public bool HasAccessToPayments { get; set; }

        [JsonProperty(PropertyName = "AccessToTenants")]
        public bool HasAccessToTenants { get; set; }

        [JsonProperty(PropertyName = "AccessToMaintenance")]
        public bool HasAccessToMaintenance { get; set; }

        [JsonProperty(PropertyName = "AccessToMailer")]
        public bool HasAccessToMailer { get; set; }

        public bool CanReplyPublicly { get; set; }

        public bool LimitToAssignedTicketsOnly { get; set; }
    }
}
