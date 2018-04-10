using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class RegisterViewModel : BaseNavigationViewModel
    {
		string _name;
        public string Name
        {
            get => _name;
            set => SetPropertyChanged(ref _name, value);
        }

		string _companyName;
        public string CompanyName
        {
			get => _companyName;
			set => SetPropertyChanged(ref _companyName, value);
        }

		string _email;
        public string Email
        {
            get => _email;
            set => SetPropertyChanged(ref _email, value);
        }

		string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => SetPropertyChanged(ref _phoneNumber, value);
        }

		string _unitCount;
        public string UnitCount
        {
            get => _unitCount;
            set => SetPropertyChanged(ref _unitCount, value);
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

		Task OnSubmitCommand()
        {
            return Task.Run(() => { });
        }
    }
}
