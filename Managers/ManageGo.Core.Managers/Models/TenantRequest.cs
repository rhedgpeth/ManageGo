using System;
using System.Collections.Generic;
using ManageGo.Core.Managers.Enumerations;

namespace ManageGo.Core.Managers.Models
{
    public class TenantRequest : PagedRequest
    {
        public int PropertyId { get; set; }
        public string Search { get; set; }
        public TenantStatus Status { get; set; }
        public List<int> Buildings { get; set; }
        public List<int> Units { get; set; }
    }
}
