using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;

namespace ManageGo.Core.ViewModels
{
    public abstract class BaseCollectionViewModel<T> : BaseNavigationViewModel
    {
        protected bool CanLoadMore { get; set; } = true;
        protected int Page { get; set; } = 1;

        protected ObservableCollection<T> _items = new ObservableCollection<T>();
        public ObservableCollection<T> Items
        {
            get => _items;
            set => SetPropertyChanged(ref _items, value);
        }

        ICommand _loadMoreItemsCommand;
        public ICommand LoadMoreItemsCommand
        {
            get
            {
                if (_loadMoreItemsCommand == null)
                {
                    _loadMoreItemsCommand = new Command(async () => await LoadMoreItems());
                }

                return _loadMoreItemsCommand;
            }
        }

        async Task LoadMoreItems()
        {
            if (CanLoadMore && !IsBusy)
            {
                Page++;

                await LoadAsync(false);
            }
        }

        public override Task LoadAsync(bool refresh)
        {
            if (refresh)
            {
                Page = 1;
            }

            return base.LoadAsync(refresh);
        }
    }
}
