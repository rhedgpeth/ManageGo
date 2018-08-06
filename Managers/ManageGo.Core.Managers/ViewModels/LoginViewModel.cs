using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class LoginViewModel : BaseNavigationViewModel 
    {
        ISecureStorageService _secureStorageService;
        ISecureStorageService SecureStorageService
        {
            get
            {
                if (_secureStorageService == null)
                {
                    _secureStorageService = ServiceContainer.Resolve<ISecureStorageService>();
                }

                return _secureStorageService;
            }
        }

		string _userName = "rob@managego.com";
        public string Username
		{
			get => _userName;
			set => SetPropertyChanged(ref _userName, value);
		}

		string _password = "123456";
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

        public Action<string> OnFailure { get; set; }

		public LoginViewModel()
        {
			Title = "Welcome";
		}

		async Task OnLoginCommand() 
        {
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                var response = await AuthenticationService.Instance.Authenticate(Username, Password); //.ConfigureAwait(false);

                if (response?.Status == Enumerations.ResponseStatus.Data)
                {
                    if (await Authorize(response.Result))
                    {
                        Navigation.SetRootView(new RootViewModel(), false);
                    }
                }
                else if (!string.IsNullOrEmpty(response.ErrorMessage))
                {
                    OnFailure?.Invoke(response?.ErrorMessage);
                }
                else
                {
                    OnFailure?.Invoke("Unknown error has occured. (OnLoginCommand)");
                }
            }
            else // Double check on client-side validation
            {
                OnFailure?.Invoke("Invalid username/password.");
            }
        }

        async Task<bool> Authorize(AuthenticationResponse response)
        {
            if (response != null && !string.IsNullOrEmpty(response.User?.AccessToken))
            {
                return await SecureStorageService.SetAsync(Constants.SecureStorageKeys.AccessToken, response.User.AccessToken);
            }
         
            OnFailure?.Invoke("Unknown error has occured. (Authorize)");

            return false;
        }

		Task OnResetPasswordCommand() => Navigation.PushAsync(new ResetPasswordViewModel());

		Task OnSignUpCommand() => Navigation.PushAsync(new RegisterViewModel());
    }
}
