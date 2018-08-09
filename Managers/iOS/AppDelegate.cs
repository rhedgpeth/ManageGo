using FFImageLoading.Forms.Platform;
using Foundation;
using ManageGo.Core;
using ManageGo.Core.iOS.Services;
using ManageGo.Core.Services;
using Plugin.Toasts;
using UIKit;
using UserNotifications;
using Xamarin.Forms;

namespace ManageGo.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {         
            global::Xamarin.Forms.Forms.Init();

            DependencyService.Register<ToastNotification>();
            ToastNotification.Init();

            RequestNotificationPermissions(app);

            CachedImageRenderer.Init();

			RegisterServices();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        void RequestNotificationPermissions(UIApplication app)
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
            {
                // Request Permissions
                UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound, (granted, error) =>
                {
                    // Do something if needed
                });
            }
            else if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(
                 UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null
                    );

                app.RegisterUserNotificationSettings(notificationSettings);
            }
        }

		void RegisterServices()
        {
            ServiceContainer.Register<IExternalAppService>(() => new ExternalAppService());
        }
    }
}
