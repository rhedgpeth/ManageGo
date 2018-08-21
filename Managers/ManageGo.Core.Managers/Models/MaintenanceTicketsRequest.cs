using System;

namespace ManageGo.Core.Managers.Models
{
    public class MaintenanceTicketsRequest : PagedRequest
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
