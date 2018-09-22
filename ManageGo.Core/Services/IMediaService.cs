using System.Threading.Tasks;

namespace ManageGo.Core.Services
{
    public interface IMediaService
    {
        Task<byte[]> TakePhoto();
    }
}
