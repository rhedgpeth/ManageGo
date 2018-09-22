using System.Threading.Tasks;
using ManageGo.Core.Enumerations;

namespace ManageGo.Core.Services
{
    public interface IAlertService
    {
        Task ShowToast(AlertType type, string title, string description, int? duration = null);
        Task ShowMessage(string title, string message, string cancel);
        Task<bool> ShowMessage(string title, string message, string accept, string cancel);
    }
}
