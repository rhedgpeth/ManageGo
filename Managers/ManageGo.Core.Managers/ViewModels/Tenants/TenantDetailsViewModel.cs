using System;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Services;

namespace ManageGo.Core.Managers.ViewModels
{
    public class TenantDetailsViewModel
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

		public string Email { get; set; }
		public string HomePhoneNumber { get; set; }
		public string CellPhoneNumber { get; set; }

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

        public TenantDetailsViewModel()
        { }

		void CallPhoneNumber(string phoneNumber) => ExternalAppService.CallPhoneNumber(phoneNumber);

        void OpenEmailApp() => ExternalAppService.Open(new Uri($"mailto:{Email}"));
    }
}
