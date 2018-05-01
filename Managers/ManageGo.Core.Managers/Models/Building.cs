using System;

namespace ManageGo.Core.Managers.Models
{
    public class Building
    {
		public int BuildingId { get; set; }

		public string Name { get; set; }
        
		// TODO: Replace with Address object
		public string Address { get; set; }

		public int UnitCount { get; set; }

		public int TenantCount { get; set; }

		public int TicketCount { get; set; }
    }
}
