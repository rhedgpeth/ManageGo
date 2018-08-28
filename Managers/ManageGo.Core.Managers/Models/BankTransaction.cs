using System;
using System.Collections.Generic;

namespace ManageGo.Core.Managers.Models
{
    public class BankTransaction
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsMarked { get; set; }
        public string BankAccountInfo { get; set; }
        public int TenantTransactionsCount { get; set; }
        public List<PaymentBase> Payments { get; set; }
    }
}
