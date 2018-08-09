using System.Collections.Generic;
using Newtonsoft.Json;

namespace ManageGo.Core.Managers.Models
{
    public class Tenant
    {
        [JsonProperty(PropertyName = "TenantFirstName")]
		public string FirstName { get; set; }

        [JsonProperty(PropertyName = "TenantLastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "TenantHomePhone")]
        public string HomePhone { get; set; }

        [JsonProperty(PropertyName = "TenantCellPhone")]
        public string CellPhone { get; set; }

        [JsonProperty(PropertyName = "TenantEmailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty(PropertyName = "TenantUnits")]
        public IList<Unit> Units { get; set; }
    }
}
