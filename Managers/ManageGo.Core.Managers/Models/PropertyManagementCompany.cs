using Newtonsoft.Json;

namespace ManageGo.Core.Managers.Models
{
    public class PropertyManagementCompany
    {
        /*
         * "PMCName": "Atos Management",
            "PMCID": 1,
            "MaintenanceEnabled": false
            */

        [JsonProperty(PropertyName = "PMCID")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "MaintenanceEnabled")]
        public bool IsMaintenanceEnabled { get; set; }
    }
}
