using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;

namespace ManageGo.Core.ViewModels
{
	public abstract class BaseEditViewModel : BaseNavigationViewModel
    {
		ICommand _saveCommand;
		public ICommand SaveCommand
		{
			get
			{
				if (_saveCommand == null)
				{
					_saveCommand = new Command(async () => await Save());
				}

				return _saveCommand;
			}
		}

		ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new Command(async () => await Cancel());
                }

                return _cancelCommand;
            }
        }

        public BaseEditViewModel()
        { }

		protected abstract Task Save();
      
		protected virtual Task Cancel() => Dismiss();
    }
}
