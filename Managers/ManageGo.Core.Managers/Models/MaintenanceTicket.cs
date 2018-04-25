using System;
namespace ManageGo.Core.Managers.Models
{
    public class MaintenanceTicket
    {
		public int TicketId { get; set; }

		public string Title { get; set; }
     
		public string Description { get; set; }

		public DateTime CreatedDateTime { get; set; }

		// TODO: Replace with enumeration or category type/id from server
		public string Category { get; set; }

		// TODO: Possibly refactor to attach multiple tenants
		public Tenant Tenant { get; set; }
    }
}
