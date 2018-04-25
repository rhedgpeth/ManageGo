using System;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class MaintenanceTicketDetailsViewModel : BaseNavigationViewModel
    {
		MaintenanceTicket MaintenanceTicket { get; set; }
        
		public string Description { get; set; }

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

        public MaintenanceTicketDetailsViewModel(MaintenanceTicket ticket)
        {
			LoadMaintenanceTicket(ticket);
        }

        void LoadMaintenanceTicket(MaintenanceTicket ticket)
		{
			MaintenanceTicket = ticket;
			Description = ticket.Description;
		}
    }
}
