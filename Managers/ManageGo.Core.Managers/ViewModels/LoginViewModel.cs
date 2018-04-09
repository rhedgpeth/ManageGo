using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class LoginViewModel : BaseNavigationViewModel 
    {
		string _userName;
        public string Username
		{
			get => _userName;
			set => SetPropertyChanged(ref _userName, value);
		}

		string _password;
        public string Password
		{
			get => _password;
			set => SetPropertyChanged(ref _password, value);
		}

		ICommand _loginCommand;
		public ICommand LoginCommand
		{
			get
			{
				if (_loginCommand == null)
				{
					_loginCommand = new Command(async () => await OnLoginCommand());
				}

				return _loginCommand;
			}
		}

		ICommand _resetPasswordCommand;
		public ICommand ResetPasswordCommand
		{
			get
			{
                if (_resetPasswordCommand == null)
				{
					_resetPasswordCommand = new Command(async () => await OnResetPasswordCommand());
				}

				return _resetPasswordCommand;
			}
		}

		ICommand _signUpCommand;
        public ICommand SignUpCommand
        {
            get
            {
                if (_signUpCommand == null)
                {
					_signUpCommand = new Command(async () => await OnSignUpCommand());
                }

				return _signUpCommand;
            }
        }

		public LoginViewModel()
        { }

        Task OnLoginCommand()
		{
			// TODO: Auth functionality

			// TODO: Set RootPage as the root view

			return Task.Run(() => { });
		}

		Task OnResetPasswordCommand() => Navigation.PushAsync(new ResetPasswordViewModel());

		Task OnSignUpCommand() => Navigation.PushAsync(new RegisterViewModel());
    }
}
