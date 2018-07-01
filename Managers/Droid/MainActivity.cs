using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ManageGo.Core;
using ManageGo.Core.Services;
using ManageGo.Core.Droid.Services;
using FFImageLoading.Forms.Platform;
using FFImageLoading;

namespace ManageGo.Droid
{
    [Activity(Label = "ManageGo.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");

            CachedImageRenderer.Init(true);

            ImageService.Instance.Initialize();

			RegisterServices();

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
        
        void RegisterServices()
		{
			ServiceContainer.Register<IExternalAppService>(() => new ExternalAppService());
		}
    }
}
