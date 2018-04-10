using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class ResetPasswordViewModel : BaseNavigationViewModel
    {
		string _email;
        public string Email
        {
			get => _email;
			set => SetPropertyChanged(ref _email, value);
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

        Task OnSubmitCommand()
		{
			return Task.Run(() => { });
		}
    }
}
