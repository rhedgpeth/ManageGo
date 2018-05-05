using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class TransactionsViewModel : BaseExpandableCollectionViewModel<TransactionSectionHeaderViewModel>
    {
        public TransactionsViewModel()
        {
			Title = "Bank transactions";
        }

		public override async Task InitAsync()
        {
            var items = new List<object>();

            for (int i = 0; i < 10; i++)
            {
				items.Add(new TransactionSectionHeaderViewModel
				{
					TransactionAmount = string.Format("${0:#.00}", Convert.ToDecimal(RandomNumberBetween(1, 10000) / 100)),
					TransactionDateTime = DateTime.Now.AddDays(-10).AddDays(i).ToShortDateString() + " 8:00 AM",
					TransactionSourceName = $"Transaction Source {i}",
					TransactionSourceId = $"B0073{i}",
					TransactionSourceType = i % 2 == 0 ? Enumerations.TransactionSourceType.Bank : Enumerations.TransactionSourceType.Building,
                    Children = new List<object> 
                    { 
                        new TransactionDetailsViewModel 
                        { 
                            //Description = $"This is a description for transaction {i}." 
                        }
                    }  
                });
            }

            Items = new ObservableCollection<object>(items);
        } 
    }
}
