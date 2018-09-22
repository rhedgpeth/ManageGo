using System;
using System.IO;
using System.Threading.Tasks;
using ManageGo.Core.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace ManageGo.Services
{
    public class MediaService : IMediaService
    {
        public async Task<byte[]> TakePhoto()
        {
            var options = new StoreCameraMediaOptions
            {
                CompressionQuality = 75
            };

            var result = await CrossMedia.Current.TakePhotoAsync(options).ConfigureAwait(false);

            if (result != null)
            {
                var stream = result.GetStream();

                using (var ms = new MemoryStream())
                {
                    stream.CopyTo(ms);

                    return ms.ToArray();
                }
            }

            return null;
        }
    }
}
