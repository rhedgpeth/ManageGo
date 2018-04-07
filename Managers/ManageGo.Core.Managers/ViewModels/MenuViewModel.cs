using System;
using System.Collections.Generic;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class MenuViewModel : BaseNavigationViewModel
    {
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
                    SetDetailViewModel(new MaintenanceItemsViewModel());
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
    }
}
