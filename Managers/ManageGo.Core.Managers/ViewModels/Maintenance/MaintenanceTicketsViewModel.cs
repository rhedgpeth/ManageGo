using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class MaintenanceTicketsViewModel : BaseExpandableCollectionViewModel<MaintenanceTicketSectionHeaderViewModel>
    {
        public List<string> StatusOptions => new List<string> { "New", "Assigned", "In progress", "Closed" };

        public MaintenanceTicketsViewModel()
        {
			Title = "Tickets";
        }

		public override async Task InitAsync()
		{
			var sectionHeaders = new List<MaintenanceTicketSectionHeaderViewModel>();

			await Task.Run(() =>
			{            
				for (int i = 1; i < 11; i++)
				{
					var ticket = new MaintenanceTicket
					{
						TicketId = i,
						Title = $"Maintenance Ticket #{i}",
						Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
							"Sed vel dolor leo. Aliquam erat volutpat. Cras turpis sem, tempus eu " +
							"turpis nec, fringilla sollicitudin quam. Maecenas quis auctor orci.",
						CreatedDateTime = DateTime.Now.AddDays(i).AddHours(i),
						Category = $"Category {i}",
						Tenant = new Tenant
						{
							Name = $"Tenant Name {i}",
							Building = new Building
							{
								Name = "Building {i}",
								Address = $"{i} Main St."
							},
							Unit = $"{i}B"
						}
					};

					sectionHeaders.Add(new MaintenanceTicketSectionHeaderViewModel(ticket));
				}
			});
           
			Items = new System.Collections.ObjectModel.ObservableCollection<object>(sectionHeaders);
		}
    }
}
