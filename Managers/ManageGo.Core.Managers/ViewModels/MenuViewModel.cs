using System;
using System.Collections.Generic;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class MenuViewModel : BaseNavigationViewModel
    {
		IExternalAppService _externalAppService;
		IExternalAppService ExternalAppService
		{
			get
			{
				if (_externalAppService == null)
				{
					_externalAppService = ServiceContainer.Resolve<IExternalAppService>();
				}

				return _externalAppService;
			}
		}

        public string Email 
		{
			get
			{
				return "support@managegocom";
			}
		}

        public string PhoneNumber
		{
			get
			{
				return "212-300-7950";
			}
		}

        public IList<string> MenuItems
		{
			get;
			set;
		}

        ICommand _menuItemSelectedCommand;
        public ICommand MenutItemSelectedCommand
        {
            get
            {
                if (_menuItemSelectedCommand == null)
                {
                    _menuItemSelectedCommand = new Command<string>(OnMenuItemSelected);
                }

                return _menuItemSelectedCommand;
            }
        }

		ICommand _emailCommand;
		public ICommand EmailCommand
        {
            get
            {
				if (_emailCommand == null)
                {
					_emailCommand = new Command(OpenEmailApp);
                }

				return _emailCommand;
            }
        }
        
		ICommand _phoneCommand;
        public ICommand PhoneCommand
        {
            get
            {
                if (_phoneCommand == null)
                {
                    _phoneCommand = new Command(CallPhoneNumber);
                }

                return _phoneCommand;
            }
        }

        public MenuViewModel()
        {


            LoadMenuItems();
        }

        void LoadMenuItems()
        {
            MenuItems = new List<string>
            {
                "Payments",
                "Bank transactions",
                "Maintenance",
                "Calendar",
                "Buildings",
                "Tenants",
                "Settings",
                "Feedback",
                "Logout"
            };
        }   

        void OnMenuItemSelected(string item)
        {
            switch(item)
            {
                case "Payments":
                    SetDetailViewModel(new PaymentsViewModel());
                    break;
                case "Bank transactions":
                    SetDetailViewModel(new TransactionsViewModel());
                    break;
                case "Maintenance":
                    SetDetailViewModel(new MaintenanceTicketsViewModel());
                    break;
                case "Calendar":
                    SetDetailViewModel(new CalendarViewModel());
                    break;
                case "Buildings":
                    SetDetailViewModel(new BuildingsViewModel());
                    break;
                case "Tenants":
                    SetDetailViewModel(new TenantsViewModel());
                    break;
                case "Settings":
                    SetDetailViewModel(new SettingsViewModel());
                    break;
                case "Feedback":
                    // TODO: Do something here
                    break;
                case "Logout":
                    Logout();
                    break;
            }
        }

        void SetDetailViewModel(BaseNavigationViewModel vm) => Navigation.SetDetailView(vm);

        void Logout()
        {
            Console.WriteLine("Logged Out");

            // TODO: Do stuff here to log out.

            Navigation.SetRootView(new LoginViewModel());
        }

		void CallPhoneNumber() => ExternalAppService.CallPhoneNumber(PhoneNumber);

		void OpenEmailApp() => ExternalAppService.Open(new Uri($"mailto:{Email}"));
    }
}
