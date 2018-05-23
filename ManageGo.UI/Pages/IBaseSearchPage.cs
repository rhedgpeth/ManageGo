using System;

namespace ManageGo.UI.Pages
{
	public delegate void SearchHandler();

    public interface IBaseSearchPage  
    {  
        event SearchHandler OnSearchIconTapped;  
    } 
}
