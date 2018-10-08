using System;

namespace ManageGo.Core.Services
{
    public interface IAnalyticsService
    {
        void Start();
        void TrackError(Exception ex);
        void TrackEvent(string message);
    }
}
