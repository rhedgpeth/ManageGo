using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class CalendarViewModel : BaseExpandableCollectionViewModel<CalendarSectionHeaderViewModel>
    {
        public CalendarViewModel()
        {
			Title = "Calendar";
        }

		public override async Task InitAsync()
		{
			var sectionHeaders = new List<CalendarSectionHeaderViewModel>();

            await Task.Run(() =>
            {
                for (int i = 1; i < 11; i++)
                {
                    var ticket = new MaintenanceTicket
                    {
                        TicketId = i,
                        TicketSubject = $"Maintenance Ticket #{i}",
                        FirstComment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                            "Sed vel dolor leo. Aliquam erat volutpat. Cras turpis sem, tempus eu " +
                            "turpis nec, fringilla sollicitudin quam. Maecenas quis auctor orci.",
                        TicketCreateTime = DateTime.Now.AddDays(i).AddHours(i),
                        Categories = new MaintenanceCategory[] { new MaintenanceCategory { Name = $"Category {i}" }},
                        TenantFirstName = "Tenant",
                        TenantLastName = i.ToString()
                    };

                    sectionHeaders.Add(new CalendarSectionHeaderViewModel(ticket));
                }
            });

            Items = new ObservableCollection<object>(sectionHeaders);
		}
	}
}
