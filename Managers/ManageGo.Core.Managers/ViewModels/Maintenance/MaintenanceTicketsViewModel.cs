using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class MaintenanceTicketsViewModel : BaseExpandableCollectionViewModel<MaintenanceTicketSectionHeaderViewModel>
    {
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

            var request = new MaintenanceTicketsRequest
            {
                FromDate = new DateTime(2018, 2, 1),
                ToDate = new DateTime(2018, 2, 5)
            };

            var ticketsResponse = await MaintenanceService.Instance.GetTickets(request).ConfigureAwait(false);

            if (ticketsResponse?.Status == Enumerations.ResponseStatus.Data)
            {
                var sectionHeaders = new List<MaintenanceTicketSectionHeaderViewModel>();

                await Task.Run(() =>
                {
                    foreach (var ticket in ticketsResponse.Result)
                    {
                        sectionHeaders.Add(new MaintenanceTicketSectionHeaderViewModel(ticket));
                    }
                });

                Items = new System.Collections.ObjectModel.ObservableCollection<object>(sectionHeaders);
            }

            IsBusy = false;
        }
    }
}
