using System;
using ManageGo.Core.ViewModels;
using ManageGo.UI.Navigation;
using Xamarin.Forms;

namespace ManageGo.UI.Pages
{
    public abstract class BaseContentPage<T> : ContentPage, IViewFor<T> where T : BaseNavigationViewModel, new()
    {
        T _viewModel;

        public T ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value;

                BindingContext = _viewModel;

                Init();
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

        protected BaseContentPage()
        { }

        async void Init()
        {
            await ViewModel.InitAsync();
        }
    }
}
