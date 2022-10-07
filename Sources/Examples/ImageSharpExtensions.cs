using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace FFmpeg.NET.ImageSharp
{
    public static class ImageSharpExtensions
    {
        public static Image<Bgra32> ToImage(this AVFrame frame)
        {
            var target = AVFrame.ConvertVideoFrame(frame, AVPixelFormat.BGRA);
            if (target == null)
                return null;

            var source = target.data[0].ToArray();
            var image = Image.LoadPixelData<Bgra32>(source, target.width, target.height);
            return image;
        }
    }
}
