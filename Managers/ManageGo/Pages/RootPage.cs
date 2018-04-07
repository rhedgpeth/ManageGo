using System;

using Xamarin.Forms;

namespace ManageGo.Pages
{
    public class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            Master = new MenuPage();
        }
    }
}

