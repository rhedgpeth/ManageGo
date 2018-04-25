using System;
using System.Collections.Generic;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class MaintenanceTicketSectionHeaderViewModel : BaseCollectionSectionViewModel
    {
		public string Title { get; set; }
       
		public string CreatedDateTime { get; set; }

		public string Category { get; set; }

		public string TenantName { get; set; }

		public string TenantAddress { get; set; }

        public MaintenanceTicketSectionHeaderViewModel(MaintenanceTicket ticket)
        {
			LoadMaintenanceTicket(ticket);
        }

        void LoadMaintenanceTicket(MaintenanceTicket ticket)
		{
			Title = ticket.Title;
			CreatedDateTime = ticket.CreatedDateTime.ToShortDateString();
			Category = ticket.Category;
			TenantName = ticket.Tenant.Name;
			TenantAddress = $"{ticket.Tenant.Building.Address}, {ticket.Tenant.Unit}";
                     
			Children = new List<object>
			{
				new MaintenanceTicketDetailsViewModel(ticket)
			}; 
		}
    }
}
