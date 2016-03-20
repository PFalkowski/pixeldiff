using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace PixelDiff
{
    internal static class Extensions
    {
        public class DisposableImageData : IDisposable
        {
            private readonly Bitmap _bitmap;

            private readonly BitmapData _data;

            public IntPtr Scan0
            {
                get
                {
                    return this._data.Scan0;
                }
            }

            public int Stride
            {
                get
                {
                    return this._data.Stride;
                }
            }

            public int Width
            {
                get
                {
                    return this._data.Width;
                }
            }

            public int Height
            {
                get
                {
                    return this._data.Height;
                }
            }

            public PixelFormat PixelFormat
            {
                get
                {
                    return this._data.PixelFormat;
                }
            }

            public int Reserved
            {
                get
                {
                    return this._data.Reserved;
                }
            }

            internal DisposableImageData(Bitmap bitmap, Rectangle rect, ImageLockMode flags, PixelFormat format)
            {
                this._bitmap = bitmap;
                this._data = bitmap.LockBits(rect, flags, format);
            }

            public void Dispose()
            {
                this._bitmap.UnlockBits(this._data);
            }
        }

        public static Bitmap Resize(this Image image, int width, int height)
        {
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap bitmap = new Bitmap(width, height);
            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (ImageAttributes imageAttributes = new ImageAttributes())
                {
                    imageAttributes.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
                }
            }
            return bitmap;
        }

        public static Extensions.DisposableImageData LockBitsDisposable(this Bitmap bitmap, Rectangle rect, ImageLockMode flags, PixelFormat format)
        {
            return new Extensions.DisposableImageData(bitmap, rect, flags, format);
        }
    }
}
