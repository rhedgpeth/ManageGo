using System;
using System.Threading.Tasks;
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

        public SettingsViewModel()
        {
			Title = "Settings"; 
        }

		public override Task InitAsync()
		{
			Name = "Robert Hedgpeth";
			Email = "rob@hedgpethconsulting.com";
			DisplayName = "Robby H";
			Password = "******";

			return base.InitAsync();
		}
	}
}
