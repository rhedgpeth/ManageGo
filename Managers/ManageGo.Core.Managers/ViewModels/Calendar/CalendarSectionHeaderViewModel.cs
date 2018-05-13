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

		public CalendarSectionHeaderViewModel(MaintenanceTicket ticket)
        {         
            LoadMaintenanceTicket(ticket);
        }

        void LoadMaintenanceTicket(MaintenanceTicket ticket)
        {
			TimeDescription = "4:00 PM to 5:00 PM";
			DateDescription = ticket.CreatedDateTime.ToShortDateString();
            Title = ticket.Title;
			Location = "123 Main St, Astoria, NY #4B";

            Children = new List<object>
            {
                new CalendarDetailsViewModel(ticket)
            };
        }
    }
}
