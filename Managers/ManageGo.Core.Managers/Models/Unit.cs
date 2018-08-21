using System.Collections.Generic;

namespace ManageGo.Core.Managers.Models
{
	public class Unit
	{
		public int BuildingId { get; set; }
		public string Number { get; set; }

        public int UnitId { get; set; }
        public string UnitName { get; set; }

		public List<Tenant> Tenants { get; set; }
	}
}
