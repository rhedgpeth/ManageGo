using System;
using ManageGo.iOS.Renderers;
using ManageGo.UI.Pages;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BaseContentPage), typeof(BasePageRenderer))]

namespace ManageGo.iOS.Renderers
{   
    public class BasePageRenderer : PageRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

			if (ParentViewController?.NavigationItem != null)
			{
				ParentViewController.NavigationItem.TitleView = new UIImageView(UIImage.FromFile("logo.png"))
				{
					ContentMode = UIViewContentMode.ScaleAspectFit
				};
			}
        }
	}
}
