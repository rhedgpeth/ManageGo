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
		MaintenanceTicket MaintenanceTicket { get; set; }  

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
					                                 await Navigation.PushAsync(new MaintenanceTicketViewModel(MaintenanceTicket)));
				}

				return _viewTicketCommand;
			}
		}

        public CalendarDetailsViewModel(MaintenanceTicket ticket)
        { 
			LoadMaintenanceTicket(ticket);
        }

        void LoadMaintenanceTicket(MaintenanceTicket ticket)
        {
			MaintenanceTicket = ticket;

            //Description = ticket.Description;
			Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
                " Sed et risus fermentum, imperdiet arcu ut, dapibus quam.Nam sit amet lobortis tortor.";
			Participants = new List<string> { "John Doe", "Jim Doe", "Jake Doe" };
			EventTimeDescription = "2:00 PM to 3:00 PM";
			EventDateDescription = ticket.CreatedDateTime.ToShortDateString();         
        }
    }
}
