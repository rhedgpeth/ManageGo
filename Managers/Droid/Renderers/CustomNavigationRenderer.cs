using System.Reflection;
using Android.Content;
using ManageGo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.Widget;
using Android.Support.V7.Graphics.Drawable;
using System.Threading.Tasks;
using ManageGo.UI.Pages;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationRenderer))]
namespace ManageGo.Droid
{
    public class CustomNavigationRenderer : NavigationPageRenderer
    {
		ImageView _titleImageView;
		EditText _searchTextView;

		public CustomNavigationRenderer(Context context) : base(context)
		{ }

        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);

			var bar = (Android.Support.V7.Widget.Toolbar)typeof(NavigationPageRenderer)
                        .GetField("_toolbar", BindingFlags.NonPublic | BindingFlags.Instance)
                        .GetValue(this);
            
			_titleImageView = bar.FindViewById<ImageView>(Resource.Id.titleImageView);
			_searchTextView = bar.FindViewById<EditText>(Resource.Id.searchEditText);
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
			var page = view as IBaseSearchPage;
            
			if (page != null)
			{
                page.OnSearchIconTapped += OnSearchIconTapped;

				_titleImageView.Visibility = Android.Views.ViewStates.Visible;
                _searchTextView.Visibility = Android.Views.ViewStates.Gone;
            }

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

		void OnSearchIconTapped()
        {
            if (_titleImageView.Visibility == Android.Views.ViewStates.Visible)
			{
				_titleImageView.Visibility = Android.Views.ViewStates.Gone;
				_searchTextView.Visibility = Android.Views.ViewStates.Visible;
				_searchTextView.RequestFocusFromTouch();
			}
			else
			{
				_titleImageView.Visibility = Android.Views.ViewStates.Visible;
                _searchTextView.Visibility = Android.Views.ViewStates.Gone;
			}
        }
    }
}  