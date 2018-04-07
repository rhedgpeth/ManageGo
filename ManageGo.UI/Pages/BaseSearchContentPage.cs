using System;
using ManageGo.Core.ViewModels;
using ManageGo.UI.Navigation;
using Xamarin.Forms;

namespace ManageGo.UI.Pages
{
    public abstract class BaseSearchContentPage<T> : BaseContentPage<T>, IViewFor<T> where T : BaseSearchViewModel, new()
    {
        public BaseSearchContentPage()
        {
            
        }
    }
}

