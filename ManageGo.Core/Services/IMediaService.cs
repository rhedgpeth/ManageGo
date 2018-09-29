using System.Threading.Tasks;

namespace ManageGo.Core.Services
{
    public interface IMediaService
    {
        bool IsCameraAvailable { get; }
        Task<byte[]> PickPhotoAsync();
        Task<byte[]> PickVideoAsync();
        Task<byte[]> TakePhotoAsync();
        Task<byte[]> TakeVideoAsync();
    }
}
