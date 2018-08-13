using System;

namespace ManageGo.Core.Managers.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Amount { get; set; }
        public decimal OtherFee { get; set; }
        public decimal TenantFee { get; set; }
        public decimal Total { get; set; }
        public decimal TotalAmountAndFees { get; set; }

        public string TenantName { get; set; }

    }
}
