using System.Collections.Generic;

namespace ManageGo.Core.Managers.Models
{
	public class Unit
	{
		public int BuildingId { get; set; }

		public string Number { get; set; }
        
		public List<Tenant> Tenants { get; set; }
	}
}
