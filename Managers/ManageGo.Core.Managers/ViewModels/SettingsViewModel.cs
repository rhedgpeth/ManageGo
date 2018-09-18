using System;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Models;
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

        public SettingsViewModel()
        {
			Title = "Settings"; 
        }

		public override async Task InitAsync()
		{
            var user = await CacheService.GetObjectAsync<AuthenticatedUser>("UserSettings");

            /*
			Name = "Robert Hedgpeth";
			Email = "rob@hedgpethconsulting.com";
			*/

            Name = $"{user.FirstName} {user.LastName}".Trim();
            Email = user.EmailAddress;

			DisplayName = "Robby H";
			Password = "******";
		}
	}
}
