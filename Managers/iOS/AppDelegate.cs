using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading.Forms.Platform;
using Foundation;
using ManageGo.Core;
using ManageGo.Core.iOS.Services;
using ManageGo.Core.Services;
using UIKit;

namespace ManageGo.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {         
            global::Xamarin.Forms.Forms.Init();

            CachedImageRenderer.Init();

			RegisterServices();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

		void RegisterServices()
        {
            ServiceContainer.Register<IExternalAppService>(() => new ExternalAppService());
        }
    }
}
