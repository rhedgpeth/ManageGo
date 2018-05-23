using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
	public class CreateEventViewModel : BaseEditViewModel
    {
		bool _showCalendar;
        public bool ShowCalendar
		{
			get => _showCalendar;
			set => SetPropertyChanged(ref _showCalendar, value);
		}

		ICommand _showDateTimeCommand;
		public ICommand ShowDateTimeCommand
		{
			get
			{
				if (_showDateTimeCommand == null)
				{
					_showDateTimeCommand = new Command(ToggleCalendar);
				}

				return _showDateTimeCommand;
			}
		}

        public CreateEventViewModel()
        { }

		protected override Task Save()
        {
            // TODO: Save thangs

            return Dismiss();
        }

		void ToggleCalendar() => ShowCalendar = !ShowCalendar;
    }
}
