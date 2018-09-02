using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Managers.Models;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class MaintenanceTicketEventViewModel : BaseEditViewModel
    {
		bool _showDateTime;
        public bool ShowDateTime
		{
			get => _showDateTime;
			set => SetPropertyChanged(ref _showDateTime, value);
		}

		ICommand _toggleDateTimeCommand;
		public ICommand ToggleDateTimeCommand
		{
			get
			{
				if (_toggleDateTimeCommand == null)
				{
					_toggleDateTimeCommand = new Command(ToggleDateTime);
				}

				return _toggleDateTimeCommand;
			}
		}

        public MaintenanceTicketEventViewModel()
        { }

        public MaintenanceTicketEventViewModel(MaintenanceTicketEvent evt)
        {
            
        }

		protected override Task Save()
        {
            // TODO: Save thangs

            return Dismiss();
        }

		void ToggleDateTime() => ShowDateTime = !ShowDateTime;
    }
}
