using System;
using System.Windows.Input;
using ManageGo.Core.Services;
using ManageGo.Core.ViewModels;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Enumerations;
using System.Threading.Tasks;
using ManageGo.Core.Managers.Services;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.Enumerations;

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

        IAlertService _alertService;
        IAlertService AlertService
        {
            get
            {
                if (_alertService == null)
                {
                    _alertService = ServiceContainer.Resolve<IAlertService>();
                }

                return _alertService;
            }
        }

        IMessageService _messageService;
        IMessageService MessageService
        {
            get
            {
                if (_messageService == null)
                {
                    _messageService = ServiceContainer.Resolve<IMessageService>();
                }

                return _messageService;
            }
        }

        public int LeaseId { get; set; }
        public string LeaseName { get; set; }
		public NotificationType NotificationType { get; set; } 
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

        ICommand _approveCommand;
        public ICommand ApproveCommand
        {
            get 
            {
                if (_approveCommand == null)
                {
                    _approveCommand = new Command(async () => await UpdatePendingLeaseApproval(true));
                }

                return _approveCommand;
            }   
        }

        ICommand _declineCommand;
        public ICommand DeclineCommand
        {
            get
            {
                if (_declineCommand == null)
                {
                    _declineCommand = new Command(async () => await UpdatePendingLeaseApproval(false));
                }

                return _declineCommand;
            }
        }

        public NotificationDetailsViewModel()
        { 
            // TODO: Resolve IAlertService
        }

        async Task UpdatePendingLeaseApproval(bool isApproved)
        {
            /*
            var response = await PMCService.Instance.UpdatePendingLeaseApproval(new PendingLeaseApprovalAction
            {
                LeaseId = LeaseId,
                IsApproved = isApproved
            });

            if (response.Status == ResponseStatus.ActionSuccessful)
            {
                // Success toast
                // TODO: Add IAlertService (for Toast in this situation)
            }
            else
            {
                // Report error
            }
            */

            // TODO: Send message (pub-sub) to refresh the list.

            MessageService.Send(this, "RefreshList");

            if (isApproved)
            {
                await AlertService.ShowToast(AlertType.Success, "Lease Approved", $"{LeaseName} has been approved.");
            }
            else
            {
                await AlertService.ShowToast(AlertType.Failure, "Lease Declined", $"{LeaseName} has been declined.");
            }
        }

		void CallPhoneNumber(string phoneNumber) => ExternalAppService.CallPhoneNumber(phoneNumber);

        void OpenEmailApp() => ExternalAppService.Open(new Uri($"mailto:{Email}"));
    }
}
