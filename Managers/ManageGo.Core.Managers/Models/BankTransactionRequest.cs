using System.Collections.Generic;

namespace ManageGo.Core.Managers.Models
{
    public class BankTransactionRequest : DateRangeRequest
    {
        public decimal? AmountFrom { get; set; }
        public decimal? AmountTo { get; set; }
        public List<int> BankAccounts { get; set; }
        public string Search { get; set; }
    }
}
