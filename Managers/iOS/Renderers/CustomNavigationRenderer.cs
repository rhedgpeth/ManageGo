using System;
using ManageGo.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer (typeof(NavigationPage), typeof(CustomNavigationRenderer))]
namespace ManageGo.iOS.Renderers
{
    public class CustomNavigationRenderer : NavigationRenderer
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad ();

			NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            NavigationBar.ShadowImage = new UIImage();
        }

        /*
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			NavigationBar.TopItem.TitleView = new UIImageView(UIImage.FromBundle("logo"))
            {
                ContentMode = UIViewContentMode.ScaleAspectFit
            };
		}*/
	}
}