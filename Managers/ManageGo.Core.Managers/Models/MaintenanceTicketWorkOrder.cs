using System.Collections.Generic;

namespace ManageGo.Core.Managers.Models
{
    public class MaintenanceTicketWorkOrder
    {
        public int? WorkOrderId { get; set; }
        public int TicketId { get; set; }
        public string Summary { get; set; }
        public string Details { get; set; }
        public List<int> SendToUsers { get; set; }
        public List<int> SendToExternalContacts { get; set; }
        public string SendToEmail { get; set; }
    }
}
