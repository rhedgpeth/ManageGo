using System;
using System.Collections.Generic;
using ManageGo.Core.Managers.Enumerations;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class TransactionSectionHeaderViewModel : BaseCollectionSectionViewModel
    {
		public string TransactionAmount { get; set; }
		public DateTime TransactionDateTime { get; set; }
		public string TransactionSourceName { get; set; }
		public string TransactionSourceId { get; set; }
		public TransactionSourceType TransactionSourceType { get; set; }

        public TransactionSectionHeaderViewModel(BankTransaction transaction)
        {
            LoadTransaction(transaction);
        }

        void LoadTransaction(BankTransaction transaction)
        {
            TransactionAmount = string.Format("${0:n}", transaction.Amount);
            TransactionDateTime = transaction.TransactionDate;
            TransactionSourceName = transaction.BankAccountInfo;
            TransactionSourceId = transaction.Number;
            TransactionSourceType = TransactionSourceType.Bank;

            Children = new List<object>
            {
                new TransactionDetailsViewModel(transaction.Payments)
            };
        }
    }
}
