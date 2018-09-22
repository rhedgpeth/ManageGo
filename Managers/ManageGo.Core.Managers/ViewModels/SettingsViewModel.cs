using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class SettingsViewModel : BaseNavigationViewModel
    {
		string _name;
        public string Name 
		{
			get => _name;
			set => SetPropertyChanged(ref _name, value);
		}

		string _email;
        public string Email
        {
			get => _email;
			set => SetPropertyChanged(ref _email, value);
        }

		string _displayName;
        public string DisplayName
        {
			get => _displayName;
			set => SetPropertyChanged(ref _displayName, value);
        }

		string _password;
        public string Password
        {
			get => _password;
			set => SetPropertyChanged(ref _password, value);
        }

        bool _enableBiometrics;
        public bool EnableBiometrics
        {
            get => _enableBiometrics;
            set => SetPropertyChanged(ref _enableBiometrics, value);
        }

        bool _enablePushNotifications;
        public bool EnablePushNotifications
        {
            get => _enablePushNotifications;
            set
            {
                SetPropertyChanged(ref _enablePushNotifications, value);

                EnablePaymentsPushNotifications = _enablePushNotifications;
                EnableMaintenancePushNotifications = _enablePushNotifications;
                EnableTenantsPushNotifications = _enablePushNotifications;
            }
        }

        bool _enablePaymentsPushNotifications;
        public bool EnablePaymentsPushNotifications
        {
            get => _enablePaymentsPushNotifications;
            set => SetPropertyChanged(ref _enablePaymentsPushNotifications, value);
        }

        bool _enableMaintenancePushNotifications;
        public bool EnableMaintenancePushNotifications
        {
            get => _enableMaintenancePushNotifications;
            set => SetPropertyChanged(ref _enableMaintenancePushNotifications, value);
        }

        bool _enableTenantsPushNotifications;
        public bool EnableTenantsPushNotifications
        {
            get => _enableTenantsPushNotifications;
            set => SetPropertyChanged(ref _enableTenantsPushNotifications, value);
        }

        ICommand _saveCommand;
        public ICommand SaveCommand 
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new Command(async () => await Save());
                }

                return _saveCommand;
            }
        }

        ICommand _resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                {
                    _resetCommand = new Command(async () => await Reset());
                }

                return _resetCommand;
            }
        }

        AuthenticatedUser User { get; set; }

        public SettingsViewModel()
        {
			Title = "Settings"; 
        }

		public override async Task InitAsync()
		{
            User = await CacheService.GetObjectAsync<AuthenticatedUser>("UserSettings");

            if (User != null)
            {
                Name = $"{User.UserFirstName} {User.UserLastName}".Trim();
                Email = User.UserEmailAddress;

                DisplayName = "Robby H";
                Password = "******";
            }
		}

        async Task Save()
        {
            User.UserEmailAddress = Email;
            User.MaintenancePushNotification = EnableMaintenancePushNotifications;
            User.PaymentPushNotification = EnablePaymentsPushNotifications;
            User.TenantPushNotification = EnableTenantsPushNotifications;

            /*
            var result = await UserService.Instance.SaveUserSettings(User);

            if (result.Status == Enumerations.ResponseStatus.ActionSuccessful)
            {
                
            }*/

            await AlertService.ShowToast(Core.Enumerations.AlertType.Success, "Success", "Settings updated");
        }

        async Task Reset()
        {
            if (await AlertService.ShowMessage("Reset", "Are you sure you want to reset your changes?", "Yes", "No"))
            {
                Email = User.UserEmailAddress;
            }
        }
	}
}
