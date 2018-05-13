using System;
using System.Windows.Input;
using ManageGo.Core.Services;
using ManageGo.Core.ViewModels;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Enumerations;

namespace ManageGo.Core.Managers.ViewModels
{
	public class NotificationDetailsViewModel : BaseNavigationViewModel
	{      
		IExternalAppService _externalAppService;
        IExternalAppService ExternalAppService
        {
            get
            {
                if (_externalAppService == null)
                {
                    _externalAppService = ServiceContainer.Resolve<IExternalAppService>();
                }

                return _externalAppService;
            }
        }

		public NotificationType NotificationType { get; set; } 
        public string Email { get; set; }
        public string HomePhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
		public string ActivationDescription
		{
			get
			{
				string target = string.Empty;

				if (NotificationType == NotificationType.Tenant)
					target = "tenant";
				else
					target = "unit";

				return $"Approve {target} and activate:";
			}
		}

        ICommand _emailCommand;
        public ICommand EmailCommand
        {
            get
            {
                if (_emailCommand == null)
                {
                    _emailCommand = new Command(OpenEmailApp);
                }

                return _emailCommand;
            }
        }

        ICommand _homePhoneCommand;
        public ICommand HomePhoneCommand
        {
            get
            {
                if (_homePhoneCommand == null)
                {
                    _homePhoneCommand = new Command(() => CallPhoneNumber(HomePhoneNumber));
                }

                return _homePhoneCommand;
            }
        }

        ICommand _cellPhoneCommand;
        public ICommand CellPhoneCommand
        {
            get
            {
                if (_cellPhoneCommand == null)
                {
                    _cellPhoneCommand = new Command(() => CallPhoneNumber(CellPhoneNumber));
                }

                return _cellPhoneCommand;
            }
        }

        public NotificationDetailsViewModel()
        { }

		void CallPhoneNumber(string phoneNumber) => ExternalAppService.CallPhoneNumber(phoneNumber);

        void OpenEmailApp() => ExternalAppService.Open(new Uri($"mailto:{Email}"));
    }
}
