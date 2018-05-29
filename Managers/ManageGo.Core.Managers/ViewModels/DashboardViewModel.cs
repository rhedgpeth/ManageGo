using System;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class DashboardViewModel : BaseSearchViewModel
    {
		ICommand _viewPaymentsCommand;
		public ICommand ViewPaymentsCommand
		{
			get
			{
				if (_viewPaymentsCommand == null)
				{
					_viewPaymentsCommand = new Command(async () => await Navigation.PushAsync(new PaymentsViewModel()));
				}

				return _viewPaymentsCommand;                                
			}
		}
        
		ICommand _viewTicketsCommand;
        public ICommand ViewTicketsCommand
        {
            get
            {
				if (_viewTicketsCommand == null)
                {
					_viewTicketsCommand = new Command(async () => await Navigation.PushAsync(new MaintenanceTicketsViewModel()));
                }

				return _viewTicketsCommand;
            }
        }

        public DashboardViewModel()
        {
            Title = "Welcome";
        }
    }
}
