using System;
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
        Task PushAsync(BaseNavigationViewModel viewModel);
        Task PushAsync<T>(Action<T> initialize = null) where T : BaseNavigationViewModel;
        Task PushModalAsync<T>(Action<T> initialize = null) where T : BaseNavigationViewModel;
        Task PushModalAsync(BaseNavigationViewModel viewModel);
        Task PopToRootAsync(bool animate);

        void SwitchDetailPage<T>(Action<T> initialize = null) where T : BaseNavigationViewModel;
        void SwitchDetailPage(BaseNavigationViewModel viewModel);
    }
}
