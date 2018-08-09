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
    }
}
