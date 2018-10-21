using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class MaintenanceTicketViewModel : BaseNavigationViewModel
    {
        public MaintenanceTicket MaintenanceTicket { get; set; }

        public string Subject { get; private set; }
        public string BuildingUnitAddress { get; set; }
        public bool HasPet { get; private set; }
        public bool HasEvent { get; private set; }
        public bool HasWorkorder { get; private set; }
        public bool HasAccess { get; private set; }

        ICommand _replyCommand;
		public ICommand ReplyCommand
		{
			get
			{
				if (_replyCommand == null)
				{
					_replyCommand = new Command(async () 
					                            => await Navigation.PushPopupAsync(new CreateMaintenanceTicketReplyViewModel()));
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
					_createEventCommand = new Command(async () 
					                                  => await Navigation.PushPopupAsync(new MaintenanceTicketEventViewModel(MaintenanceTicket.TicketId)));
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
					_createWorkOrderCommand = new Command(async () 
					                                      => await Navigation.PushPopupAsync(new CreateWorkOrderViewModel(MaintenanceTicket.TicketId)));
                }

				return _createWorkOrderCommand;
            }
        }

		ObservableCollection<object> _items;
		public ObservableCollection<object> Items
		{
			get => _items;
			set => SetPropertyChanged(ref _items, value);
		}

        public MaintenanceTicketViewModel(MaintenanceTicket ticket)
        {
			Title = $"Ticket #{ticket.TicketId}";
            LoadMaintenanceTicket(ticket);
		}

        public MaintenanceTicketViewModel(int ticketId)
        {
            MaintenanceTicket = new MaintenanceTicket { TicketId = ticketId };
            // TODO: Retrieve the rest of the maintenance ticket
        }

        void LoadMaintenanceTicket(MaintenanceTicket ticket)
        {
            if (ticket != null)
            {
                MaintenanceTicket = ticket;

                Subject = ticket.TicketSubject;

                BuildingUnitAddress = $"{ticket.Building?.BuildingShortAddress} #{ticket.Unit?.UnitName}";

                HasPet = ticket.HasPet;
                HasEvent = ticket.HasEvent;
                HasAccess = ticket.HasAccess;
                HasWorkorder = ticket.HasWorkorder;
            }
        }

		public override async Task InitAsync()
		{
            /*
            var ticketDetailsResponse = await MaintenanceService.Instance.GetTicketDetails(MaintenanceTicket);

            if (ticketDetailsResponse.Status == Enumerations.ResponseStatus.Data)
            {
                MaintenanceTicket = ticketDetailsResponse.Result;
            }*/

            var items = new List<object>
            {
                new MaintenanceTicketCommentViewModel
                {
                    FirstColor = "#FFFFFF",
                    SecondColor = "#4E9AF5",
                    Name = "Bruce Wayne",
                    CreateDateTimeDescription = "Dec 15 - 8:00 AM",
                    Comment = "I have a question about my roommate. He signed on to the lease at the beginning of November.",
                    IsAccessGranted = false
                },

                new MaintenanceTicketCommentViewModel
                {
                    FirstColor = "#4E9AF5",
                    SecondColor = "#E13D40",
                    Name = "Clark Kent",
                    CreateDateTimeDescription = "Dec 15 - 8:00 AM",
                    Comment = "I have a question about my roommate. He signed on to the lease at the beginning of November.",
                    IsAccessGranted = true,
                    AccessDescription = "This is a note on access, we have this field by the tenant side and it shows here.",
                    AccessGrantedDateTime = "Dec 15 - 7:32 AM",
                    AccessGrantedTimeSpan = "3/1/2018 - 10:30 AM to 3:15 PM"
                },

                new MaintenanceTicketActionViewModel
                {
                    FirstColor = "#E13D40",
                    SecondColor = "#55C433",
                    Title = "Event created",
                    ScheduledDateTimeSpan = "3/1/2018 - 10:30 AM to 3:15 PM",
                    Description = "Fix the tiles in the kitchen.",
                    ViewDescription = "View in calendar"
                },

                new MaintenanceTicketCommentViewModel
                {
                    FirstColor = "#55C433",
                    SecondColor = "#4E9AF5",
                    Name = "Diana Prince",
                    CreateDateTimeDescription = "Dec 15 - 8:00 AM",
                    Comment = "I have a question about my roommate. He signed on to the lease at the beginning of November.",
                    HasImage = true,
                    ImageName = "img_attach_1.jpg"

                },

                new MaintenanceTicketActionViewModel
                {
                    FirstColor = "#4E9AF5",
                    SecondColor = "#E13D40",
                    Title = "Work order created",
                    ScheduledDateTimeSpan = "3 / 1 / 2018 - 10:30 AM to 3:15 PM",
                    Description = "Fix the tiles in the kitchen.",
                    ViewDescription = "View work order"
                }
            };

            Items = new ObservableCollection<object>(items);
		}
	}
}
