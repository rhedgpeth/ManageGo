using System;
using System.Collections.Generic;

namespace ManageGo.Core.Managers.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string Number { get; set; }
        public decimal Amount { get; set; }
        public decimal OtherFee { get; set; }
        public decimal TenantFee { get; set; }
        public decimal Total { get; set; }
        public decimal TotalAmountAndFees { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionStatus { get; set; }
        public string TransactionType { get; set; }
        public string PaymentType { get; set; }
        public bool IsMarked { get; set; }
        public string PaymentNote { get; set; }
        public string PaymentAcctUsed { get; set; }
        public int? RecurringId { get; set; }
        public List<BankTransaction> ReverseTransactions { get; set; }
        public List<BankTransaction> BankTransactions { get; set; }
        public Tenant Tenant { get; set; }
        public Unit Unit { get; set; }
        public Building Building { get; set; }
    }
}
