using System;

namespace ManageGo.Core.Managers.Models
{
    public class BankTransactionRequest : PagedRequest
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal? AmountFrom { get; set; }
        public decimal? AmountTo { get; set; }
        public int? BankAccountId { get; set; }
    }
}
