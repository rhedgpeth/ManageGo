using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class PaymentsViewModel : BaseFilterViewModel<PaymentSectionHeaderViewModel>
    {      
        public string SearchTerm { get; set; }

        public PaymentsViewModel()
        {
            Title = "Payments";
        }

        public override Task InitAsync() => LoadAsync(true);

        public override async Task LoadAsync(bool refresh)
        {
            IsBusy = true;

            await base.LoadAsync(refresh);

            var request = new PaymentRequest
            {
                DateFrom = new DateTime(2018, 2, 1),
                DateTo = new DateTime(2018, 2, 5),
                Page = Page,
                PageSize = 20,
                Search = SearchTerm
            };

            var paymentsResponse = await FinanceService.Instance.GetPayments(request).ConfigureAwait(false);

            if (paymentsResponse?.Status == Enumerations.ResponseStatus.Data ||
                paymentsResponse?.Status == Enumerations.ResponseStatus.NoData)
            {
                CanLoadMore = paymentsResponse.Result.Count == 20;

                var sectionHeaders = new List<PaymentSectionHeaderViewModel>();

                foreach (var payment in paymentsResponse.Result)
                {
                    sectionHeaders.Add(new PaymentSectionHeaderViewModel(payment));
                }

                LoadItems(refresh, sectionHeaders);
            }

            IsBusy = false;
        }
	}
}
