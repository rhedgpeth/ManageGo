using System.Collections.Generic;

namespace ManageGo.Core.Managers.Models
{
    public class Tenant
    {
		public string TenantFirstName { get; set; }
        public string TenantLastName { get; set; }
        public string TenantHomePhone { get; set; }
        public string TenantCellPhone { get; set; }
        public string TenantEmailAddress { get; set; }
        public List<Unit> TenantUnits { get; set; }   
    }
}
