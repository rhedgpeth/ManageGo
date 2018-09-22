using System.Threading.Tasks;
using ManageGo.Core.Enumerations;
using ManageGo.Core.Services;
using Plugin.Toasts;
using Xamarin.Forms;

namespace ManageGo.Services
{
    public class AlertService : IAlertService
    {
        public async Task ShowToast(AlertType type, string title, string descripton, int? duration = null)
        {
            var notificator = DependencyService.Get<IToastNotificator>();

            var options = new NotificationOptions()
            {
                Title = title,
                Description = descripton
            };

            var result = await notificator.Notify(options);

            // TODO: Handle result
        }

        public Task ShowMessage(string title, string message, string cancel)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public Task<bool> ShowMessage(string title, string message, string accept, string cancel)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}
