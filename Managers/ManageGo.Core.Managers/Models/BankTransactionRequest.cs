namespace ManageGo.Core.Managers.Models
{
    public class BankTransactionRequest : DateRangeRequest
    {
        public decimal? AmountFrom { get; set; }
        public decimal? AmountTo { get; set; }
        public int? BankAccountId { get; set; }
    }
}
