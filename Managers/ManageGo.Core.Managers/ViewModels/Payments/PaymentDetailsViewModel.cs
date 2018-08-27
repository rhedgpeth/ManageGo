using System;
using ManageGo.Core.Managers.Models;

namespace ManageGo.Core.Managers.ViewModels
{
    public class PaymentDetailsViewModel
    {
        public string TotalAmount { get; set; }
        public string TotalFees { get; set; }
        public string TotalAmountAndFees { get; set; }
        public string PaymentAccountDescription { get; set; }
		public string PaymentNote { get; set; }

        public PaymentDetailsViewModel(Payment payment)
        {
            PaymentNote = payment.PaymentNote;
            PaymentAccountDescription = payment.PaymentAcctUsed;
            TotalAmount = string.Format("${0:n}", payment.Amount);
            TotalFees = string.Format("${0:n}", payment.OtherFee + payment.TenantFee);
            TotalAmountAndFees = string.Format("${0:n}", payment.TotalAmountAndFees);
        }
    }
}
