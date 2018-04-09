using System.Reflection;
using Android.Content;
using Android.Support.V7.Widget;
using ManageGo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

using Android.Support.V7;
using Android.Support.V7.App;
using Android.App;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationRenderer))]
namespace ManageGo.Droid
{
    public class CustomNavigationRenderer : NavigationPageRenderer
    {
		public CustomNavigationRenderer(Context context) : base(context)
		{ }

        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);

            var bar = (Toolbar)typeof(NavigationPageRenderer)
                        .GetField("_toolbar", BindingFlags.NonPublic | BindingFlags.Instance)
                        .GetValue(this);

			//bar.SetLogo(Resource.Drawable.logo);         
        }
    }
}