using System;
using System.Linq;

namespace ManageGo.Core.Managers.Models
{
    public class MaintenanceTicket
    {
		public int TicketId { get; set; }
        public string TicketNumber { get; set; }
        public string TicketStatus { get; set; }
        public DateTime TicketCreateTime { get; set; }
        public string TenantFirstName { get; set; }
        public string TenantLastName { get; set; }
        public string ShortAddress { get; set; }
        public string TicketSubject { get; set; }
        public string FirstComment { get; set; }

        public MaintenanceCategory[] Categories { get; set; }

        //public DateTime DueDate { get; set; }
        public int NumberOfReplies { get; set; }
        public bool HasWorkorder { get; set; }
        public bool HasEvent { get; set; }
        public bool HasPet { get; set; }
        public bool HasAccess { get; set; }
    }
}
