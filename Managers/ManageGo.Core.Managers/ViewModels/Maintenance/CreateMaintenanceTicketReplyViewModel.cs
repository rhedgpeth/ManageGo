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
                    _takePhotoCommand = new Command(async () => await TakePhotoAsync());
                }

                return _takePhotoCommand;
            }
        }

        ICommand _takeVideoCommand;
        public ICommand TakeVideoCommand
        {
            get
            {
                if (_takeVideoCommand == null)
                {
                    _takeVideoCommand = new Command(async () => await TakeVideoAsync());
                }

                return _takeVideoCommand;
            }
        }

        ICommand _pickPhotoCommand;
        public ICommand PickPhotoCommand
        {
            get
            {
                if (_pickPhotoCommand == null)
                {
                    _pickPhotoCommand = new Command(async () => await PickPhotoAsync());
                }

                return _pickPhotoCommand;
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

        async Task TakeVideoAsync()
        {
            var video = await MediaService.TakeVideoAsync().ConfigureAwait(false);

            if (video != null)
            {
                // Test 
            }
        }

        async Task TakePhotoAsync()
        {
            var photo = await MediaService.TakePhotoAsync().ConfigureAwait(false);

            if (photo != null)
            {
                // Test 
            }
        }

        async Task PickPhotoAsync()
        {
            var photo = await MediaService.PickVideoAsync().ConfigureAwait(false);

            if (photo != null)
            {

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
