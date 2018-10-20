using System;
using System.Collections.Generic;

namespace ManageGo.Core.Managers.Models
{
    public class MaintenanceTicketsRequest : DateRangeRequest
    {
        public string Search { get; set; }
        public List<int> Buildings { get; set; }
        public List<int> Categories { get; set; }
        public List<int> Tags { get; set; }
        public List<int> Statuses { get; set; }
        public List<int> Priorites { get; set; }
    }
}
