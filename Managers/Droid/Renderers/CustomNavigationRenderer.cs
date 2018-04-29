using System.Reflection;
using Android.Content;
using ManageGo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.App;
using Android.Widget;
using Android.Support.V7.Graphics.Drawable;
using System.Threading.Tasks;

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

			var bar = (Android.Support.V7.Widget.Toolbar)typeof(NavigationPageRenderer)
                        .GetField("_toolbar", BindingFlags.NonPublic | BindingFlags.Instance)
                        .GetValue(this);        
        }

		protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            
            if (toolbar == null)
                toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
                
            for (var i = 0; i < toolbar.ChildCount; i++)
            {
                var imageButton = toolbar.GetChildAt(i) as ImageButton;

                var drawerArrow = imageButton?.Drawable as DrawerArrowDrawable;

                if (drawerArrow == null)
                    continue;

                imageButton.SetImageDrawable(Context.GetDrawable(Resource.Drawable.nav_menu_icon));
            }
        }

		public Android.Support.V7.Widget.Toolbar toolbar;
        
		protected override Task<bool> OnPushAsync(Page view, bool animated)
        {
            var retVal = base.OnPushAsync(view, animated);
            
            if (toolbar == null)
                toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);

            if (toolbar != null)
            {
                if (toolbar.NavigationIcon != null)
                {
                    toolbar.NavigationIcon = Android.Support.V4.Content.ContextCompat.GetDrawable(Context, Resource.Drawable.nav_back_icon);
                }
            }

            return retVal;
        }
    }
}