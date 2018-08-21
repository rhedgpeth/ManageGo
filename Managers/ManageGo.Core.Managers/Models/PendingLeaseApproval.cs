namespace ManageGo.Core.Managers.Models
{
    public class PendingLeaseApproval
    {
        public int LeaseId { get; set; }
        public string ApprovalType { get; set; }
        public Tenant Tenant { get; set; }
        public Unit Unit { get; set; }
        public Building Building { get; set; }
    }
}
