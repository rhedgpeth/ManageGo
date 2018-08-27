using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class MaintenanceTicketsViewModel : BaseFilterViewModel<MaintenanceTicketSectionHeaderViewModel>
    {
        public string SearchTerm { get; set; }

        public List<string> StatusOptions => new List<string> { "New", "Assigned", "In progress", "Closed" };

        public List<SelectableItem> Priorities { get; set; } = new List<SelectableItem>();

        public MaintenanceTicketsViewModel()
        {
			Title = "Tickets";

            Priorities.Add(new SelectableItem { Id = -1, Description = "All" });
            Priorities.Add(new SelectableItem { Id = 0, Description = "Low" });
            Priorities.Add(new SelectableItem { Id = 1, Description = "Medium" });
            Priorities.Add(new SelectableItem { Id = 2, Description = "High" });
        }

        public override Task InitAsync() => LoadAsync(true);

        public override async Task LoadAsync(bool refresh)
        {
            IsBusy = true;

            await base.LoadAsync(refresh);

            var request = new MaintenanceTicketsRequest
            {
                DateFrom = new DateTime(2018, 2, 1),
                DateTo = new DateTime(2018, 2, 5),
                Page = Page,
                PageSize = 20,
                Search = SearchTerm
            };

            var ticketsResponse = await MaintenanceService.Instance.GetTickets(request).ConfigureAwait(false);

            if (ticketsResponse?.Status == Enumerations.ResponseStatus.Data ||
                ticketsResponse?.Status == Enumerations.ResponseStatus.NoData)
            {
                CanLoadMore = ticketsResponse.Result.Count == 20;

                var sectionHeaders = new List<MaintenanceTicketSectionHeaderViewModel>();

                foreach (var ticket in ticketsResponse.Result)
                {
                    sectionHeaders.Add(new MaintenanceTicketSectionHeaderViewModel(ticket));
                }

                LoadItems(refresh, sectionHeaders);
            }

            IsBusy = false;
        }
    }
}
