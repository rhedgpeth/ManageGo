using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
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

        public CreateMaintenanceTicketReplyViewModel()
        { }

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
