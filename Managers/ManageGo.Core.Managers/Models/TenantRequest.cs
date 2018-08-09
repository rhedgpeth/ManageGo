using System;

namespace ManageGo.Core.Managers.Models
{
    public class TenantRequest : PagedRequest
    {
        public int PropertyId { get; set; }
        public string Search { get; set; }
    }
}
