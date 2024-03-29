﻿using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class DashboardViewModel : BaseNavigationViewModel
    {
        string _totalPaymentsThisWeek;
        public string TotalPaymentsThisWeek
        {
            get => _totalPaymentsThisWeek;
            private set => SetPropertyChanged(ref _totalPaymentsThisWeek, value);
        }

        string _totalPaymentsThisMonth;
        public string TotalPaymentsThisMonth
        {
            get => _totalPaymentsThisMonth;
            private set => SetPropertyChanged(ref _totalPaymentsThisMonth, value);
        }

        int? _openTicketCount;
        public int? OpenTicketCount
        {
            get => _openTicketCount;
            private set => SetPropertyChanged(ref _openTicketCount, value);
        }

        int? _noReplyTicketCount;
        public int? NoReplyTicketCount
        {
            get => _noReplyTicketCount;
            private set => SetPropertyChanged(ref _noReplyTicketCount, value);
        }

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

        public override async Task InitAsync()
        {
            await LoadDashboard();

            // We do not want to wait for these results - fire and forget
            LoadUsers();
            LoadUserSettings();
        }

        async Task LoadDashboard()
        {
            IsBusy = true;

            var dashboard = await PMCService.Instance.GetDashboard();

            IsBusy = false;

            if (dashboard?.Status == Enumerations.ResponseStatus.Data
                && dashboard.Result != null)
            {
                TotalPaymentsThisWeek = dashboard.Result.TotalPaymentsThisWeek.ToString("c");
                TotalPaymentsThisMonth = dashboard.Result.TotalPaymentsThisMonth.ToString("c");
                OpenTicketCount = dashboard.Result.OpenTicketCount;
                NoReplyTicketCount = dashboard.Result.NoReplyTicketCount;
            }
        }

        async void LoadUserSettings()
        {
            var maintenanceUserSettings = await MaintenanceService.Instance.GetUserSettings().ConfigureAwait(false);

            if (maintenanceUserSettings?.Status == Enumerations.ResponseStatus.Data)
            {
                AppInstance.Maintenance.Settings = maintenanceUserSettings.Result;
            }
        }

        async void LoadUsers()
        {
            var usersResponse = await UserService.Instance.GetUsers().ConfigureAwait(false);

            if (usersResponse?.Status == Enumerations.ResponseStatus.Data)
            {
                AppInstance.Users = usersResponse.Result;
            }
        }
    }
}
