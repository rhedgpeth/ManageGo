using System;

namespace ManageGo.Core.Managers.Models
{
    public class DateRangeRequest : PagedRequest
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
