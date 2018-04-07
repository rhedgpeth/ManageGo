using System;
using Xamarin.Forms;
using ManageGo.Core.Managers.ViewModels;

namespace ManageGo.Pages
{
    public class RootPage : MasterDetailPage
    {
        public RootPage(Page page)
        {
            Master = new MenuPage()
            {
                ViewModel = new MenuViewModel()
            };

            Detail = new NavigationPage(page);
        }
    }
}

