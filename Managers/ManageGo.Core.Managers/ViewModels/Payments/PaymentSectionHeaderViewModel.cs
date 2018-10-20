using System;
using System.Collections.Generic;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class PaymentSectionHeaderViewModel : BaseCollectionSectionViewModel
    {
		public string Amount { get; set; }
		public string PaymentDateTime { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }

        public PaymentSectionHeaderViewModel(Payment payment)
        {
            LoadPayment(payment);
        }

        void LoadPayment(Payment payment)
        {
            Amount = string.Format("${0:n}", payment.Amount);
            PaymentDateTime = payment.TransactionDate.ToShortDateTimeString();
            Name = $"{payment.Tenant?.TenantFirstName} {payment.Tenant?.TenantLastName}".Trim();
            Address = payment.Building.BuildingShortAddress;
            Children = new List<object>
            {
                new PaymentDetailsViewModel(payment)
            };
        }
    }
}
