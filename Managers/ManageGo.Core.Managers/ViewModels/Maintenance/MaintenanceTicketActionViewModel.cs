using System;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class MaintenanceTicketActionViewModel : BaseNavigationViewModel
    {
		public string FirstColor { get; set; }

        public string SecondColor { get; set; }
        
		public new string Title { get; set; }

		public string CreateDateTimeDescription { get; set; }

		public string ScheduledDateTimeSpan { get; set; }

		public string Description { get; set; }

		public string ViewDescription { get; set; }

		ICommand _viewCommand;
		public ICommand ViewCommand
		{
			get
			{
				if (_viewCommand == null)
				{
					_viewCommand = new Command(async () => await Navigation.PushAsync(new CalendarViewModel()));
				}

				return _viewCommand;
			}
		}

        public MaintenanceTicketActionViewModel()
        { }
    }
}
