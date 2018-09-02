using System;
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
			Participants = new List<string> { "John Doe", "Jim Doe", "Jake Doe" };
            EventTimeDescription = $"{evt.TimeFrom} to {evt.TimeTo}";
			EventDateDescription = evt.EventDateStart.ToShortDateString();         
        }
    }
}
