using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.Services;

namespace ManageGo.Core.ViewModels
{
    public abstract class BaseViewModel : BaseNotify
    {
        IAnalyticsService _analyticsService;
        protected IAnalyticsService AnalyticsService
        {
            get
            {
                if (_analyticsService == null)
                {
                    _analyticsService = ServiceContainer.Resolve<IAnalyticsService>();
                }

                return _analyticsService;
            }
        }

        ICacheService _cacheService;
        protected ICacheService CacheService
        {
            get
            {
                if (_cacheService == null)
                {
                    _cacheService = ServiceContainer.Resolve<ICacheService>();
                }

                return _cacheService;
            }
        }

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

        bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetPropertyChanged(ref _isRefreshing, value);
        }

        ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                {
                    _refreshCommand = new Command(async () => 
                    {
                        IsRefreshing = true;

                        await LoadAsync(true);

                        IsRefreshing = false;
                    });
                }

                return _refreshCommand;
            }
        }

        public virtual Task InitAsync() => Task.FromResult(true);

        public virtual Task LoadAsync(bool refresh) => Task.FromResult(true);
    }
}
