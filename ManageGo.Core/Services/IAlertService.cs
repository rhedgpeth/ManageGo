using System.Threading.Tasks;
using ManageGo.Core.Enumerations;

namespace ManageGo.Core.Services
{
    public interface IAlertService
    {
        Task ShowToast(AlertType type, string title, string description, int? duration = null);
    }
}
