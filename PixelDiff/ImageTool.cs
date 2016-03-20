using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace PixelDiff
{
    public class ImageTool
    {
        public unsafe static Tuple<Bitmap, uint> GetDifferenceImage(Bitmap image1, Bitmap image2, Color matchColor)
        {
            if (image1 == null | image2 == null)
            {
                return null;
            }
            if (image1.Height != image2.Height || image1.Width != image2.Width)
            {
                return null;
            }
            Bitmap bitmap = image2.Clone() as Bitmap;
            int height = image1.Height;
            int width = image1.Width;
            BitmapData bitmapData = image1.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData bitmapData2 = image2.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData bitmapData3 = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            byte* ptr = (byte*)((void*)bitmapData.Scan0);
            byte* ptr2 = (byte*)((void*)bitmapData2.Scan0);
            byte* ptr3 = (byte*)((void*)bitmapData3.Scan0);
            byte[] array = new byte[]
            {
                matchColor.B,
                matchColor.G,
                matchColor.R
            };
            int num = bitmapData.Stride - image1.Width * 3;
            uint num2 = 0u;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int num3 = 0;
                    byte[] array2 = new byte[3];
                    for (int k = 0; k < 3; k++)
                    {
                        array2[k] = *ptr2;
                        if (*ptr == *ptr2)
                        {
                            num3++;
                        }
                        ptr++;
                        ptr2++;
                    }
                    for (int l = 0; l < 3; l++)
                    {
                        *ptr3 = ((num3 == 3) ? array[l] : array2[l]);
                        ptr3++;
                    }
                    if (num3 != 3)
                    {
                        num2 += 1u;
                    }
                }
                if (num > 0)
                {
                    ptr += num;
                    ptr2 += num;
                    ptr3 += num;
                }
            }
            image1.UnlockBits(bitmapData);
            image2.UnlockBits(bitmapData2);
            bitmap.UnlockBits(bitmapData3);
            return new Tuple<Bitmap, uint>(bitmap, num2);
        }
    }
}
