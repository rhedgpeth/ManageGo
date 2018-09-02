using System;
using System.Collections.Generic;

namespace ManageGo.Core.Managers.Models
{
    public class MaintenanceTicketEvent
    {
        public int EventId { get; set; }
        public int TicketId { get; set; }
        public string Title { get; set; } = "Mock Ticket";
        public string Note { get; set; } = "This is a mock note.";
        public DateTime EventDateStart { get; set; }
        public DateTime EventDateEnd { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public List<int> SendToUsers { get; set; }
        public List<int> SendToTenant { get; set; }
        public List<int> SendToExternalContacts { get; set; }
        public string SendToEmail { get; set; }
    }
}
