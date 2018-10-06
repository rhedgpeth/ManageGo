using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;

namespace ManageGo.Core.Managers.ViewModels
{
	public class CalendarViewModel : BaseFilterViewModel<CalendarSectionHeaderViewModel>
    {
        List<DateTime> _highlightedDates;
        public List<DateTime> HighlightedDates 
        {
            get => _highlightedDates;
            set => SetPropertyChanged(ref _highlightedDates, value);
        }

        public CalendarViewModel()
        {
			Title = "Calendar";
        }

        protected override async void LoadFilters()
        {
            var request = new DateRangeRequest
            {
                DateFrom = DateTime.Now.AddYears(-1),
                DateTo = DateTime.Now.AddYears(1)
            };

            HighlightedDates = new List<DateTime>
            {
                new DateTime(2018,9,3),
                new DateTime(2018,8,31),
                new DateTime(2018,8,22),
                new DateTime(2018,8,21),
                new DateTime(2018,6,25)
            };

            /*
            var eventDatesResponse = await MaintenanceService.Instance.GetEventDates(request);

            if (eventDatesResponse?.Status == Enumerations.ResponseStatus.Data)
            {
                HighlightedDates = eventDatesResponse.Result?.Dates;
            }
            */
        }

        public override async Task LoadAsync(bool refresh)
        {
            IsBusy = true;

            var eventsRequest = new DateRangeRequest { DateFrom = SelectedDate, DateTo = SelectedDate };

            var eventsResponse = await MaintenanceService.Instance.GetEvents(eventsRequest);

            if (eventsResponse?.Status == Enumerations.ResponseStatus.Data ||
                eventsResponse?.Status == Enumerations.ResponseStatus.NoData)
            {
                var tenantsSectionHeaderViewModels = eventsResponse.Result?.Select(x => new CalendarSectionHeaderViewModel(x));

                LoadItems(refresh, tenantsSectionHeaderViewModels);
            }

            IsBusy = false;
        }
	}
}
