using System.IO;
using System.Threading.Tasks;
using ManageGo.Core.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace ManageGo.Services
{
    public class MediaService : IMediaService
    {
        public bool IsCameraAvailable
        {
            get => CrossMedia.Current.IsCameraAvailable;
        }

        public async Task<byte[]> PickPhotoAsync()
        {
            var result = await CrossMedia.Current.PickPhotoAsync();

            return result != null ? GetBytesFromStream(result.GetStream()) : null;
        }

        public async Task<byte[]> TakePhotoAsync()
        {
            var options = new StoreCameraMediaOptions
            {
                CompressionQuality = 75
            };

            var result = await CrossMedia.Current.TakePhotoAsync(options).ConfigureAwait(false);

            return result != null ? GetBytesFromStream(result.GetStream()) : null;
        }

        public async Task<byte[]> PickVideoAsync()
        {
            var result = await CrossMedia.Current.PickVideoAsync();

            return result != null ? GetBytesFromStream(result.GetStream()) : null;
        }

        public async Task<byte[]> TakeVideoAsync()
        {
            var options = new StoreVideoOptions
            {
                CompressionQuality = 75
            };

            var result = await CrossMedia.Current.TakeVideoAsync(options).ConfigureAwait(false);

            return result != null ? GetBytesFromStream(result.GetStream()) : null;
        }

        byte[] GetBytesFromStream(Stream stream)
        {
            using (var ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
