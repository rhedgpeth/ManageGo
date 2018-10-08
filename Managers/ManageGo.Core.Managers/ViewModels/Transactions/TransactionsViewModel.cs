using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CustomCalendar;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;

namespace ManageGo.Core.Managers.ViewModels
{
	public class TransactionsViewModel : BaseFilterViewModel<TransactionSectionHeaderViewModel>
    {
        ObservableCollection<SelectableItem> _bankAccounts
            = new ObservableCollection<SelectableItem> { new SelectableItem { Id = -1, Description = "All" } };

        public ObservableCollection<SelectableItem> BankAccounts
        {
            get => _bankAccounts;
            set => SetPropertyChanged(ref _bankAccounts, value);
        }

        List<SelectableItem> _selectedBankAccounts;
        public List<SelectableItem> SelectedBankAccounts
        {
            get => _selectedBankAccounts;
            set => SetPropertyChanged(ref _selectedBankAccounts, value);
        }

        string _selectedBankAccountsDescription = "All";
        public string SelectedBankAccountsDescription
        {
            get => _selectedBankAccountsDescription;
            set => SetPropertyChanged(ref _selectedBankAccountsDescription, value);
        }

        public TransactionsViewModel()
        {
			Title = "Bank transactions";
        }

        protected override async void LoadFilters()
        {
            SelectedDates = new DateRange(DateTime.Now.AddDays(-30).Date, DateTime.Now.Date);

            var bankAccountsResponse = await FinanceService.Instance.GetBankAccounts();

            if (bankAccountsResponse?.Status == Enumerations.ResponseStatus.Data)
            {
                var items = bankAccountsResponse.Result.Select(ba =>
                                                               new SelectableItem
                                                               { Id = ba.BankAccountId, Description = ba.BankAccountName }).ToList();

                items.Insert(0, new SelectableItem { Id = -1, Description = "All" });

                BankAccounts = new ObservableCollection<SelectableItem>(items);
            }
        }

        public override async Task LoadAsync(bool refresh)
        {
            IsBusy = true;

            await base.LoadAsync(refresh);

            var request = new BankTransactionRequest
            {
                DateFrom = SelectedDates.StartDate,
                DateTo = SelectedDates.EndDate,
                Page = Page,
                PageSize = 20,
                Search = SearchTerm
            };

            var bankTransactionsResponse = await FinanceService.Instance.GetBankTransactions(request); //.ConfigureAwait(false);

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
