using System;
using System.Text.RegularExpressions;
using Foundation;
using ManageGo.Core.Services;
using UIKit;

namespace ManageGo.Core.iOS.Services
{
	public class ExternalAppService : IExternalAppService
    {      
		public void CallPhoneNumber(string phone)
        {
            var digits = new Regex(@"[^\d]", RegexOptions.None, TimeSpan.FromSeconds(1));

            phone = digits.Replace(phone, string.Empty);

            MainThread.Run(() =>
            {
                var url = new NSUrl($"tel:{phone}");

                if (UIApplication.SharedApplication.CanOpenUrl(url))
                    UIApplication.SharedApplication.OpenUrl(url);
            });
        }

		public void Open(Uri uri)
        {
            MainThread.Run(() =>
            {
                var url = new NSUrl(uri.ToString());
                if (UIApplication.SharedApplication.CanOpenUrl(url))
                    UIApplication.SharedApplication.OpenUrl(url);
            });
        }
    }
}
