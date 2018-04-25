using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{   
    public class MaintenanceTicketViewModel : BaseSearchViewModel
    {
		MaintenanceTicket _maintenanceTicket;
        public MaintenanceTicket MaintenanceTicket
        {
            get => _maintenanceTicket;
            set
            {
				_maintenanceTicket = value;
            }
        }

		ICommand _replyCommand;
		public ICommand ReplyCommand
		{
			get
			{
				if (_replyCommand == null)
				{
					_replyCommand = new Command(async () => await Navigation.PushPopupAsync(new CreateMaintenanceTicketReplyViewModel()));
				}

				return _replyCommand;
			}
		}

		ICommand _createEventCommand;
		public ICommand CreateEventCommand
		{
			get
			{
				if (_createEventCommand == null)
				{
					_createEventCommand = new Command(async () => await Navigation.PushPopupAsync(new CreateEventViewModel()));
				}

				return _createEventCommand;
			}
		}

		ICommand _createWorkOrderCommand;
        public ICommand CreateWorkOrderCommand
        {
            get
            {
                if (_createWorkOrderCommand == null)
                {
					_createWorkOrderCommand = new Command(async () => await Navigation.PushPopupAsync(new CreateWorkOrderViewModel()));
                }

				return _createWorkOrderCommand;
            }
        }

        public MaintenanceTicketViewModel(MaintenanceTicket ticket)
        {
			MaintenanceTicket = ticket;

			Title = $"Ticket #{_maintenanceTicket.TicketId}"; 
		}

		public override Task InitAsync()
		{
			//Title = $"Ticket #{_maintenanceTicket.TicketId}"; 
			return base.InitAsync();
		}
	}
}
