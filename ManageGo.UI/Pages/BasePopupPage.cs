using System;
using ManageGo.Core.ViewModels;
using ManageGo.UI.Navigation;
using Rg.Plugins.Popup.Pages;

namespace ManageGo.UI.Pages
{
	public abstract class BasePopupPage<T> : PopupPage, IViewFor<T> where T : BaseNavigationViewModel, new()
	{
		T _viewModel;

        public T ViewModel
        {
            get
            {
                if (_viewModel == null)
                    _viewModel = Activator.CreateInstance<T>();

                return _viewModel;
            }
            set
            {
                _viewModel = value;
            }
        }

        object IViewFor.ViewModel
        {
            get { return _viewModel; }
            set
            {
                ViewModel = (T)value;
            }
        }

        public BasePopupPage()
        {
			BindingContext = ViewModel;
        }
    }
}
