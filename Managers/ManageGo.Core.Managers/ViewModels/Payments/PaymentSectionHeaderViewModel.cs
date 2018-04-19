using System;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class PaymentSectionHeaderViewModel : BaseCollectionSectionViewModel
    {
		public string Amount { get; set; }
		public string PaymentDateTime { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }

        public PaymentSectionHeaderViewModel()
        { }
    }
}
