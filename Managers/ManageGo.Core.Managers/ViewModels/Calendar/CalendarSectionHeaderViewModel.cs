using System;
using System.Collections.Generic;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class CalendarSectionHeaderViewModel : BaseCollectionSectionViewModel
    {
		public string TimeDescription { get; set; }      
		public string DateDescription { get; set; }      
		public string Title { get; set; }      
		public string Location { get; set; }

		public CalendarSectionHeaderViewModel(MaintenanceTicketEvent evt)
        {         
            LoadMaintenanceTicket(evt);
        }

        void LoadMaintenanceTicket(MaintenanceTicketEvent evt)
        {
            TimeDescription = $"{evt.TimeFrom} to {evt.TimeTo}";
			DateDescription = evt.Date.ToShortDateString();
            Title = evt.Title + $" {evt.TicketId}";
			Location = evt.Building?.BuildingShortAddress;

            Children = new List<object>
            {
                new CalendarDetailsViewModel(evt)
            };
        }
	}
}
