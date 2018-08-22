using System;
using System.Linq;
using System.Collections.Generic;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class MaintenanceTicketSectionHeaderViewModel : BaseCollectionSectionViewModel
    {
        MaintenanceTicket Ticket { get; set; }

		public string Title { get; private set; }
		public string CreatedDateTime { get; private set; }
        public int ReplyCount { get; private set; }
		public string Categories { get; private set; }
		public string TenantName { get; private set; }
		public string TenantAddress { get; private set; }
        public bool HasPet { get; private set; }
        public bool HasEvent { get; private set; }
        public bool HasWorkorder { get; private set; }
        public bool HasAccess { get; private set; }

        public MaintenanceTicketSectionHeaderViewModel(MaintenanceTicket ticket)
        {
			LoadMaintenanceTicket(ticket);
        }

        void LoadMaintenanceTicket(MaintenanceTicket ticket)
		{
            Ticket = ticket;

			Title = ticket.TicketSubject;
			
            CreatedDateTime = ticket.TicketCreateTime.ToShortDateString();

            ReplyCount = ticket.NumberOfReplies;

            if (ticket.Categories?.Count > 0)
            {
                Categories = string.Join(", ", ticket.Categories.Select(x => x.CategoryName));
            }

            TenantName = $"{ticket.TenantFirstName} {ticket.TenantLastName}".Trim();
			
            TenantAddress = ticket.ShortAddress;

            HasPet = ticket.HasPet;
            HasEvent = ticket.HasEvent;
            HasWorkorder = ticket.HasWorkorder;
            HasAccess = ticket.HasAccess;
                     
			Children = new List<object>
			{
				new MaintenanceTicketDetailsViewModel(ticket)
			}; 
		}
    }
}
