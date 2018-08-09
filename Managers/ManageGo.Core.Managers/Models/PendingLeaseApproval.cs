namespace ManageGo.Core.Managers.Models
{
    public class PendingLeaseApproval
    {
        public int LeaseId { get; set; }
        public string ApprovalType { get; set; }
        public string BuildingShortAddress { get; set; }
        public string UnitName { get; set; }
        public string TenantFirstName { get; set; }
        public string TenantLastName { get; set; }
        public string TenantHomePhone { get; set; }
        public string TenantCellPhone { get; set; }
        public string TenantEmailAddress { get; set; }
    }
}
