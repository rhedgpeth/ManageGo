using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public class MaintenanceTicketsViewModel : BaseExpandableCollectionViewModel<MaintenanceTicketSectionHeaderViewModel>
    {
		ICommand _createEventCommand;
		public ICommand CreateEventCommand
		{
			get
			{
			    if (_createEventCommand == null)
				{
					_createEventCommand = new Command(async () => await OpenCreateEvent());
				}

				return _createEventCommand;
			}	
		}
        
		ICommand _createWorkorderCommand;
        public ICommand CreateWorkorderCommand
        {
            get
            {
				if (_createWorkorderCommand == null)
                {
					_createWorkorderCommand = new Command(async () => await OpenCreateWorkOrder());
                }

				return _createWorkorderCommand;
            }
        }

        public MaintenanceTicketsViewModel()
        {
			Title = "Tickets";
        }

		Task OpenCreateEvent() => Navigation.PushPopupAsync(new CreateEventViewModel());

		Task OpenCreateWorkOrder() => Navigation.PushPopupAsync(new CreateWorkOrderViewModel());
    }
}
