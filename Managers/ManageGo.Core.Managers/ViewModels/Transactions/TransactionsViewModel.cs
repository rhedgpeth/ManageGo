using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class TransactionsViewModel : BaseFilterViewModel<TransactionSectionHeaderViewModel>
    {
        public string SearchTerm { get; set; }

        public TransactionsViewModel()
        {
			Title = "Bank transactions";
        }

        public override Task InitAsync() => LoadAsync(true);

        public override async Task LoadAsync(bool refresh)
        {
            IsBusy = true;

            await base.LoadAsync(refresh);

            var request = new BankTransactionRequest
            {
                DateFrom = new DateTime(2018, 1, 1),
                DateTo = new DateTime(2018, 6, 30),
                Page = Page,
                PageSize = 20,
                Search = SearchTerm
            };

            var bankTransactionsResponse = await FinanceService.Instance.GetBankTransactions(request).ConfigureAwait(false);

            if (bankTransactionsResponse?.Status == Enumerations.ResponseStatus.Data ||
                bankTransactionsResponse?.Status == Enumerations.ResponseStatus.NoData)
            {
                CanLoadMore = bankTransactionsResponse.Result.Count == 20;

                var sectionHeaders = new List<TransactionSectionHeaderViewModel>();

                foreach (var transaction in bankTransactionsResponse.Result)
                {
                    sectionHeaders.Add(new TransactionSectionHeaderViewModel(transaction));
                }

                LoadItems(refresh, sectionHeaders);
            }

            IsBusy = false;
        }
    }
}
