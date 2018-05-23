using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class RegisterViewModel : BaseNavigationViewModel
    {
		Registration _registration;
        public Registration Registration 
		{
			get => _registration;
			set => SetPropertyChanged(ref _registration, value);
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

        public RegisterViewModel()
        {
			Title = "Sign up";
        }

		public override Task InitAsync()
		{
			Registration = new Registration();

			return base.InitAsync();
		}

		Task OnSubmitCommand()
        {
            return Task.Run(() => { });
        }
    }
}
