using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManageGo.Core.ViewModels;

namespace ManageGo.Core.Services
{   
    public interface INavigationService
    {
        void RegisterViewModels(System.Reflection.Assembly asm);
        void Register(Type viewModelType, Type viewType);

        Task PopAsync();
        Task PopModalAsync();
		Task PopPopupAsync(bool animate = true);
        Task PushAsync(BaseNavigationViewModel viewModel);
        Task PushAsync<T>(Action<T> initialize = null) where T : BaseNavigationViewModel;
        Task PushModalAsync<T>(Action<T> initialize = null) where T : BaseNavigationViewModel;
        Task PushModalAsync(BaseNavigationViewModel viewModel);
		Task PushPopupAsync(BaseNavigationViewModel viewModel, bool animate = true);
        Task PopToRootAsync(bool animate);
      
        Task SetDetailView<T>(Action<T> initialize = null) where T : BaseNavigationViewModel;
        Task SetDetailView(BaseNavigationViewModel viewModel);

        void SetRootView(BaseNavigationViewModel viewModel, bool withNavigationEnabled = true);      
    }
}
