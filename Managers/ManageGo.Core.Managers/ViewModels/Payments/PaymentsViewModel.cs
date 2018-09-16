using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using CustomCalendar;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;

namespace ManageGo.Core.Managers.ViewModels
{
    public class PaymentsViewModel : BaseFilterViewModel<PaymentSectionHeaderViewModel>
    {      
        public string SearchTerm { get; set; }

        DateRange _selectedDates;
        public DateRange SelectedDates 
        {
            get => _selectedDates;
            set
            {
                SetPropertyChanged(ref _selectedDates, value);

                if (_selectedDates != null)
                {
                    var startMonthShortName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(_selectedDates.StartDate.Month);

                    if (_selectedDates.EndDate.HasValue && _selectedDates.StartDate != _selectedDates.EndDate.Value)
                    {
                        var endMonthShortName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(_selectedDates.EndDate.Value.Month);

                        SelectedDatesDescription = $"{startMonthShortName} {_selectedDates.StartDate.Day} - " +
                                                    $"{endMonthShortName} {_selectedDates.EndDate.Value.Day}";
                    }
                    else
                    {
                        SelectedDatesDescription = $"{startMonthShortName} {_selectedDates.StartDate.Day}";
                    }
                }
            }
        }

        string _selectedDatesDescription;
        public string SelectedDatesDescription
        {
            get => _selectedDatesDescription;
            set => SetPropertyChanged(ref _selectedDatesDescription, value);
        }

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
