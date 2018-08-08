using System;
using Newtonsoft.Json;

namespace ManageGo.Core.Managers.Models
{
    public class Building
    {
		public int Id { get; set; }

        [JsonProperty(PropertyName = "BuildingName")]
		public string Name { get; set; }

        [JsonProperty(PropertyName = "BuildingShortAddress")]
		public string ShortAddress { get; set; }

        [JsonProperty(PropertyName = "NumberOfUnits")]
		public int UnitCount { get; set; }

        [JsonProperty(PropertyName = "NumberOfTenant")]
		public int TenantCount { get; set; }

        [JsonProperty(PropertyName = "NumberOfOpenTickets")]
		public int OpenTicketCount { get; set; }
    }
}
