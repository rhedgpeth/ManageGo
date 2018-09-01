using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ManageGo.Core.Input;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Managers.ViewModels
{
    public abstract class BaseFilterViewModel<T> : BaseExpandableCollectionViewModel<T> where T : BaseCollectionSectionViewModel
    {
        ICommand _applyFilterCommand;

        public ICommand ApplyFilterCommand
        {
            get
            {
                if (_applyFilterCommand == null)
                {
                    _applyFilterCommand = new Command(async () => await LoadAsync(true));
                }

                return _applyFilterCommand;
            }
        }

        public override async Task InitAsync()
        {
            LoadFilters();

            await LoadAsync(true);
        }

        protected virtual void LoadFilters() { }
    }
}
