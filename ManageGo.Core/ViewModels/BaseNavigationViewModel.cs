using System;
using System.Threading.Tasks;
using ManageGo.Core.Enumerations;
using ManageGo.Core.Services;

namespace ManageGo.Core.ViewModels
{
    public class BaseNavigationViewModel : BaseViewModel
    {
        IAlertService _alertService;
        protected IAlertService AlertService
        {
            get
            {
                if (_alertService == null)
                {
                    _alertService = ServiceContainer.Resolve<IAlertService>();
                }

                return _alertService;
            }
        }

        public ViewModelType Type { get; set; } = ViewModelType.Default;

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
              
        public virtual Task Dismiss()
        {
			Task task;

			if (Type == ViewModelType.Modal)
				task = Navigation.PopModalAsync();
			else if (Type == ViewModelType.Popup)
				task = Navigation.PopPopupAsync();
			else
				task = Navigation.PopAsync();

			return task;
        }   
    }
}
