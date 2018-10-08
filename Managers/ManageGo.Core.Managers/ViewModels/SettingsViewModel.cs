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
        bool _initialValuesLoaded = false;

		string _firstName;
        public string FirstName 
		{
			get => _firstName;
			set 
            {
                SetPropertyChanged(ref _firstName, value);

                if (_initialValuesLoaded)
                {
                    User.UserFirstName = _firstName;
                }
            }
		}

        string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                SetPropertyChanged(ref _lastName, value);

                if (_initialValuesLoaded)
                {
                    User.UserLastName = _lastName;
                }
            }
        }

        string _email;
        public string Email
        {
			get => _email;
			set 
            {
                SetPropertyChanged(ref _email, value);

                if (_initialValuesLoaded)
                {
                    User.UserEmailAddress = _email;
                }
            }
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

        bool _enablePushNotifications = true;
        public bool EnablePushNotifications
        {
            get => _enablePushNotifications;
            set
            {
                SetPropertyChanged(ref _enablePushNotifications, value);

                if (_initialValuesLoaded)
                {
                    User.PaymentPushNotification = EnablePaymentsPushNotifications = _enablePushNotifications;
                    User.MaintenancePushNotification = EnableMaintenancePushNotifications = _enablePushNotifications;
                    User.TenantPushNotification = EnableTenantsPushNotifications = _enablePushNotifications;

                    Task.Run(Save);
                }
            }
        }

        bool _enablePaymentsPushNotifications = true;
        public bool EnablePaymentsPushNotifications
        {
            get => _enablePaymentsPushNotifications;
            set
            {
                SetPropertyChanged(ref _enablePaymentsPushNotifications, value);

                if (_initialValuesLoaded)
                {
                    User.PaymentPushNotification = _enablePaymentsPushNotifications;
                    Task.Run(Save);
                }
            }
        }

        bool _enableMaintenancePushNotifications = true;
        public bool EnableMaintenancePushNotifications
        {
            get => _enableMaintenancePushNotifications;
            set
            {
                SetPropertyChanged(ref _enableMaintenancePushNotifications, value);

                if (_initialValuesLoaded)
                {
                    User.MaintenancePushNotification = _enableMaintenancePushNotifications;
                    Task.Run(Save);
                }
            } 
        }

        bool _enableTenantsPushNotifications = true;
        public bool EnableTenantsPushNotifications
        {
            get => _enableTenantsPushNotifications;
            set 
            {
                SetPropertyChanged(ref _enableTenantsPushNotifications, value);

                if (_initialValuesLoaded)
                {
                    User.TenantPushNotification = _enableTenantsPushNotifications;
                    Task.Run(Save);
                }
            }
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
                FirstName = User.UserFirstName;
                LastName = User.UserLastName;
                Email = User.UserEmailAddress;
                DisplayName = "Robby H";
                Password = "******";

                EnableTenantsPushNotifications = User.TenantPushNotification;
                EnableMaintenancePushNotifications = User.MaintenancePushNotification;
                EnablePaymentsPushNotifications = User.PaymentPushNotification;

                if (!EnableTenantsPushNotifications && !EnableMaintenancePushNotifications &&  !EnablePaymentsPushNotifications)
                {
                    EnablePushNotifications = false;
                }
            }

            _initialValuesLoaded = true;
		}

        async Task Save()
        {
            var result = await UserService.Instance.SaveUserSettings(User);

            if (result?.Status == Enumerations.ResponseStatus.ActionSuccessful)
            {
                await CacheService.InvalidateObjectAsync<User>("UserSettings");
                await CacheService.InsertObjectAsync("UserSettings", User, new TimeSpan(30,0,0,0));
            }
        }
	}
}
