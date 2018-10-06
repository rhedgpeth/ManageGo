using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomCalendar;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;

namespace ManageGo.Core.Managers.ViewModels
{
    public class PaymentsViewModel : BaseFilterViewModel<PaymentSectionHeaderViewModel>
    {      
        public PaymentsViewModel()
        {
            Title = "Payments";
        }

        protected override void LoadFilters()
        {
            SelectedDates = new DateRange(DateTime.Now.AddDays(-30), DateTime.Now);
        }

        public override async Task LoadAsync(bool refresh)
        {
            IsBusy = true;

            await base.LoadAsync(refresh);

            var request = new PaymentRequest
            {
                DateFrom = SelectedDates.StartDate,
                DateTo = SelectedDates.EndDate.Value,
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
