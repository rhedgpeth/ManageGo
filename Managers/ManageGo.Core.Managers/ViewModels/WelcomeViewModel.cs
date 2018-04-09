using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class WelcomeViewModel : BaseNavigationViewModel
    {
        public string WelcomeText
		{
			get
			{
				return "Welcome to a smarter, faster and better way to manage your property.";	
			}
		}

		public string BiometricsText
        {
            get
            {
                return "Touch the fingerprint sensor to login.";
            }
        }

		ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
				if (_loginCommand == null)
                {
					_loginCommand = new Command(async () => await OnLoginSelected());
                }

				return _loginCommand;
            }
        }

		ICommand _signUpCommand;
        public ICommand SignUpCommand
        {
            get
            {
				if (_signUpCommand == null)
                {
					_signUpCommand = new Command(async () => await OnSignUpSelected());
                }

				return _signUpCommand;
            }
        }

        public WelcomeViewModel()
        { }

		Task OnLoginSelected() => Navigation.PushAsync(new LoginViewModel());

		Task OnSignUpSelected() => Navigation.PushAsync(new RegisterViewModel());
    }
}
