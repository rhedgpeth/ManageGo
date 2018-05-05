using System;
using ManageGo.Core.Managers.Enumerations;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class TransactionSectionHeaderViewModel : BaseCollectionSectionViewModel
    {
		public string TransactionAmount { get; set; }
		public string TransactionDateTime { get; set; }
		public string TransactionSourceName { get; set; }
		public string TransactionSourceId { get; set; }
		public TransactionSourceType TransactionSourceType { get; set; }

        public TransactionSectionHeaderViewModel()
        { }
    }
}
