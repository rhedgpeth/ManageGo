using System;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class ResetPasswordViewModel : BaseNavigationViewModel
    {
        const string SuccessHexColor = "#3E90F4";
        const string ErrorHexColor = "#E13D40";

		string _email;
        public string Email
        {
			get => _email;
			set => SetPropertyChanged(ref _email, value);
        }

        string _submitResponse;
        public string SubmitResponse
        {
            get => _submitResponse;
            set => SetPropertyChanged(ref _submitResponse, value);
        }

        string _submitResponseColor = ErrorHexColor;
        public string SubmitResponseColor
        {
            get => _submitResponseColor;
            set => SetPropertyChanged(ref _submitResponseColor, value);
        }

		ICommand _submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
				if (_submitCommand == null)
                {
					_submitCommand = new Command(async () => await OnSubmitCommand());
                }

				return _submitCommand;
            }
        }

        public ResetPasswordViewModel()
        {
			Title = "Reset password";
        }

        async Task OnSubmitCommand()
		{
            // TODO: Add regex for validating email
            if (!string.IsNullOrEmpty(Email) && IsValidEmail(Email))
            {
                IsBusy = true;

                var result = await AuthenticationService.Instance.ResetPassword(new ResetPasswordRequest { PMCUserEmailAddress = Email.ToLower() });

                Email = null;

                if (result != null)
                {
                    if (result?.Status == Enumerations.ResponseStatus.Error)
                    {
                        UpdateSubmitReponse(result?.ErrorMessage, false);
                    }
                    else
                    {
                        UpdateSubmitReponse(result?.Result, true);
                    }
                }
                else
                {
                    UpdateSubmitReponse("An error occured with the request", false);
                }

                IsBusy = false;
            }
            else
            {
                UpdateSubmitReponse("Invalid email address", false);
            }

            Email = null;
		}

        void UpdateSubmitReponse(string message, bool success)
        {
            SubmitResponseColor = success ? SuccessHexColor : ErrorHexColor;
            SubmitResponse = message;
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
