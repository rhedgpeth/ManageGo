using System;
using System.Text.RegularExpressions;
using Android.Content;
using ManageGo.Core.Services;

namespace ManageGo.Core.Droid.Services
{
	public class ExternalAppService : IExternalAppService
    {      
		public void CallPhoneNumber(string phone)
        {
            var digits = new Regex(@"[^\d]", RegexOptions.None, TimeSpan.FromSeconds(1));

            phone = digits.Replace(phone, string.Empty);

            MainThread.Run(() =>
            {
                var uri = Android.Net.Uri.Parse($"tel:{phone}");
                var intent = new Intent(Intent.ActionDial, uri);
                MainApplication.CurrentActivity.StartActivity(intent);
            });
        }

		public void Open(Uri uri)
        {
            MainThread.Run(() =>
            {
                var nativeUri = Android.Net.Uri.Parse(uri.ToString());
                var intent = new Intent(Intent.ActionView, nativeUri);
                MainApplication.CurrentActivity.StartActivity(intent);
            });
        }
    }
}
