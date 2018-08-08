using System;
namespace ManageGo.Core.Managers.Models
{
    public class MaintenanceTicketsRequest
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
