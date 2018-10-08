using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class CalendarDetailsViewModel : BaseNavigationViewModel
	{
        MaintenanceTicketEvent Event { get; set; }
		 
		public string Description { get; set; }      
		public List<string> Participants { get; set; }      
		public string EventDateDescription { get; set; }      
		public string EventTimeDescription { get; set; }

		ICommand _viewTicketCommand;
        public ICommand ViewTicketCommand
		{
			get
			{
			    if (_viewTicketCommand == null)
				{
					_viewTicketCommand = new Command(async () => 
					                                 await Navigation.PushAsync(new MaintenanceTicketViewModel(Event.TicketId)));
				}

				return _viewTicketCommand;
			}
		}

		ICommand _editTicketCommand;
        public ICommand EditTicketCommand
        {
            get
            {
				if (_editTicketCommand == null)
                {
					_editTicketCommand = new Command(async () =>
                                                     await Navigation.PushPopupAsync(new MaintenanceTicketEventViewModel(Event)));
                }

				return _editTicketCommand;
            }
        }

        public CalendarDetailsViewModel(MaintenanceTicketEvent evt)
        { 
			LoadMaintenanceTicket(evt);
        }

        void LoadMaintenanceTicket(MaintenanceTicketEvent evt)
        {
			Event = evt;

			Description = evt.Note;
            Participants = GetParticipants(evt);
            EventTimeDescription = $"{evt.TimeFrom} to {evt.TimeTo}";
			EventDateDescription = evt.Date.ToShortDateString();         
        }

        List<string> GetParticipants(MaintenanceTicketEvent evt)
        {
            var participants = new List<string>();

            if (evt.SendToExternalContacts?.Count >0)
            {
                participants.AddRange(evt.SendToExternalContacts);
            }

            if (evt.SendToEmail?.Length > 0)
            {
                participants.AddRange(evt.SendToUsers.Select(x => $"{x.UserFirstName} {x.UserLastName}"));
            }

            if (evt.SendToTenant?.Count > 0)
            {
                participants.AddRange(evt.SendToTenant.Select(x => $"{x.TenantFirstName} {x.TenantLastName}"));
            }

            return participants;
        }
    }
}
