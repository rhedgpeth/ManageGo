using System;
using ManageGo.Core.Services;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace ManageGo.Services
{
    public class AnalyticsService : IAnalyticsService
    { 
        const string Android_Key = "cf43701a-0702-44e3-8a34-57ca6bb1adf3";
        const string iOS_Key = "20751d27-4ffe-4a73-a1bf-829a30d73240";

        public AnalyticsService()
        { }

        public void Start()
        {
            AppCenter.Start($"android={Android_Key};" +
                            $"ios={iOS_Key}",
                  typeof(Analytics), typeof(Crashes));
        }

        public void TrackError(Exception ex) => Crashes.TrackError(ex);

        public void TrackEvent(string message) => Analytics.TrackEvent(message);
    }
}
