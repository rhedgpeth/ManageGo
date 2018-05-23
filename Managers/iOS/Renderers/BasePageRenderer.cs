using System;
using ManageGo.iOS.Renderers;
using ManageGo.UI.Pages;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using ManageGo.Core.ViewModels;

[assembly: ExportRenderer(typeof(BaseContentPage), typeof(BasePageRenderer))]

namespace ManageGo.iOS.Renderers
{   
    public class BasePageRenderer : PageRenderer
    {
        IBaseSearchPage _page;      
        
        UISearchBar _searchBar;
        UIImageView _imageView;
        
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                _page = e.NewElement as IBaseSearchPage;

                if (_page != null)
                {
                    _page.OnSearchIconTapped += OnSearchIconTapped;
                }
            }
        }

        void OnSearchIconTapped()
        {
            if (ParentViewController.NavigationItem.TitleView.GetType() == typeof(UIImageView))
            {
                if (_searchBar == null)
                {
                    _searchBar = new UISearchBar(new CGRect(0, 0, 100, 21.0));
                    _searchBar.Placeholder = "Search...";
                }

                _searchBar.BecomeFirstResponder();

                ParentViewController.NavigationItem.TitleView = _searchBar;
            }
            else
            {
                ParentViewController.NavigationItem.TitleView = _imageView;
            }
        }

		public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            
			if (ParentViewController?.NavigationController?.NavigationItem != null)
            {
                ParentViewController.NavigationController.NavigationBar.BackIndicatorImage = UIImage.FromFile("nav_back_icon");
                ParentViewController.NavigationController.NavigationBar.BackIndicatorTransitionMaskImage = UIImage.FromFile("nav_back_icon");
            }

            if (ParentViewController?.NavigationItem != null)
            {      
				ParentViewController.NavigationItem.BackBarButtonItem = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, null);

                _imageView = new UIImageView(UIImage.FromFile("logo.png"))
                {
                    ContentMode = UIViewContentMode.ScaleAspectFit
                };

                ParentViewController.NavigationItem.TitleView = _imageView;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

			if (_page != null)
			{
				_page.OnSearchIconTapped -= OnSearchIconTapped;
				_page = null;
			}
        }
    }
}
