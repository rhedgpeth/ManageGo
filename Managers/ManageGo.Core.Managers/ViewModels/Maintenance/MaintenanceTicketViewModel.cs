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
					                                  => await Navigation.PushPopupAsync(new MaintenanceTicketEventViewModel()));
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
					                                      => await Navigation.PushPopupAsync(new CreateWorkOrderViewModel()));
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
			MaintenanceTicket = ticket;

			Title = $"Ticket #{_maintenanceTicket.TicketId}"; 
		}

        public MaintenanceTicketViewModel(int ticketId)
        {
            // TODO:
        }

		public override async Task InitAsync()
		{
			var items = new List<object>();

			items.Add(new MaintenanceTicketCommentViewModel
			{
				FirstColor = "#FFFFFF",
				SecondColor = "#4E9AF5",
				Name = "Bruce Wayne",
				CreateDateTimeDescription =  "Dec 15 - 8:00 AM",
				Comment = "I have a question about my roommate. He signed on to the lease at the beginning of November.",
				IsAccessGranted = false
			});

			items.Add(new MaintenanceTicketCommentViewModel
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
            });

			items.Add(new MaintenanceTicketActionViewModel
            {
				FirstColor = "#E13D40",
				SecondColor = "#55C433",
                Title = "Event created",
				ScheduledDateTimeSpan = "3/1/2018 - 10:30 AM to 3:15 PM",
                Description = "Fix the tiles in the kitchen.",
				ViewDescription = "View in calendar"
            });

			items.Add(new MaintenanceTicketCommentViewModel
            {
				FirstColor = "#55C433",
				SecondColor = "#4E9AF5",
                Name = "Diana Prince",
				CreateDateTimeDescription = "Dec 15 - 8:00 AM",
                Comment = "I have a question about my roommate. He signed on to the lease at the beginning of November.",
                HasImage = true,
                ImageName = "img_attach_1.jpg"

            });

			items.Add(new MaintenanceTicketActionViewModel
            {
				FirstColor = "#4E9AF5",
				SecondColor = "#E13D40",
                Title = "Work order created",
				ScheduledDateTimeSpan = "3 / 1 / 2018 - 10:30 AM to 3:15 PM",
                Description = "Fix the tiles in the kitchen.",
                ViewDescription = "View work order"					
            });

			Items = new ObservableCollection<object>(items);
		}
	}
}
