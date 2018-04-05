using System;
using ManageGo.Core.Services;

namespace ManageGo.Core.ViewModels
{
    public class BaseNavigationViewModel : BaseViewModel
    {
        public bool IsModal { get; set; }

        INavigationService _navigationService;

        protected INavigationService Navigation
        {
            get
            {
                if (_navigationService == null)
                    _navigationService = ServiceContainer.Resolve<INavigationService>();

                return _navigationService;
            }
        }

        public virtual System.Threading.Tasks.Task Dismiss()
        {
            if (IsModal)
                return Navigation.PopModalAsync();

            return Navigation.PopAsync();
        }   
    }
}
