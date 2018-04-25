using System;
using Xamarin.Forms;
using ManageGo.Core.Managers.ViewModels;
using ManageGo.UI.Navigation;

namespace ManageGo.Pages
{
	public class RootPage : MasterDetailPage, IViewFor<RootViewModel> 
    {
		RootViewModel _viewModel;

		public RootViewModel ViewModel
        {
            get
            {
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
				ViewModel = (RootViewModel)value;
            }
        }
              
        public RootPage()
        {
            Master = new MenuPage
            {
                ViewModel = new MenuViewModel()
            };

			var dashboardPage = new DashboardPage
			{
                ViewModel = new DashboardViewModel()
			};
         
			Detail = new NavigationPage(dashboardPage);
        }
    }
}

