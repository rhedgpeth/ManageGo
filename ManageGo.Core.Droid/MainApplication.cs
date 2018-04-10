using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using ManageGo.Core.Enumerations;

namespace ManageGo.Core.Droid
{
	[Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public static Activity CurrentActivity { get; private set; }

        // TODO: verify these are set in the right place
        public static ApplicationState CurrentState { get; private set; }

        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
            CurrentState = ApplicationState.Active;
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
            CurrentState = ApplicationState.Background;
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CurrentActivity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CurrentActivity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            CurrentActivity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {
        }
    }
}
