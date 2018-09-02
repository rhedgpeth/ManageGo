using ManageGo.Core.ViewModels;
using ManageGo.UI.Navigation;
using Xamarin.Forms;

namespace ManageGo.UI.Pages
{   
	public abstract class BaseSearchContentPage<T, K> : BaseContentPage<T>, IBaseSearchPage,
	    IViewFor<T> where T : BaseCollectionViewModel<K> //, new()
    {
		public event SearchHandler OnSearchIconTapped;

        public BaseSearchContentPage()
        {
			ToolbarItems.Add(new ToolbarItem("Search", "search_blue",
			                                  () => 
			{
				OnSearchIconTapped?.Invoke();
			}));
        }
    }
}

