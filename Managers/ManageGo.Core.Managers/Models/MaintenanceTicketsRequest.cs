using System;

namespace ManageGo.Core.Managers.Models
{
    public class MaintenanceTicketsRequest : DateRangeRequest
    {
        public string Search { get; set; }
    }
}
