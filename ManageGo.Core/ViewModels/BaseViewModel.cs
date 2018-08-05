using System.Threading.Tasks;

namespace ManageGo.Core.ViewModels
{
    public abstract class BaseViewModel : BaseNotify
    {
		string _title;
        public string Title
		{
			get => _title;
			set => SetPropertyChanged(ref _title, value);
		}

        bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetPropertyChanged(ref _isBusy, value);
        }

        public virtual Task InitAsync() => Task.FromResult(true);
    }
}
