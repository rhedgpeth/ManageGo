using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Services;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class CreateMaintenanceTicketReplyViewModel : BaseNavigationViewModel
    {
		ICommand _replyCommand;
		public ICommand ReplyCommand
		{
			get
			{
				if (_replyCommand == null)
				{
					_replyCommand = new Command(async () => await Reply());
				}

				return _replyCommand;
			}
		}

		ICommand _replyStaffOnlyCommand;
        public ICommand ReplyStaffOnlyCommand
        {
            get
            {
				if (_replyStaffOnlyCommand == null)
                {
					_replyStaffOnlyCommand = new Command(async () => await ReplyStaffOnly());
                }

				return _replyStaffOnlyCommand;
            }
        }

        ICommand _takePhotoCommand;
        public ICommand TakePhotoCommand
        {
            get
            {
                if (_takePhotoCommand == null)
                {
                    _takePhotoCommand = new Command(async () => await TakePhoto());
                }

                return _takePhotoCommand;
            }
        }

        IMediaService _mediaService;
        IMediaService MediaService
        {
            get
            {
                if (_mediaService == null)
                {
                    _mediaService = ServiceContainer.Resolve<IMediaService>();
                }

                return _mediaService;
            }
        }

        public CreateMaintenanceTicketReplyViewModel()
        { }

        async Task TakePhoto()
        {
            var photo = await MediaService.TakePhoto().ConfigureAwait(false);

            if (photo != null)
            {
                // Test 
            }
        }

        Task Reply()
		{
			// TODO: Thangs

			return Navigation.PopPopupAsync();
		}

		Task ReplyStaffOnly()
		{
			// TODO: Thangs

            return Navigation.PopPopupAsync();         
		}
    }
}
