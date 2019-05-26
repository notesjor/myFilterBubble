using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace myFilterBubble.Sdk.Helper
{
  public static class ByteArrayToBitmapHelper
  {
    public static Bitmap ToBitmap(this byte[] array, int width, int height,
                                  PixelFormat format = PixelFormat.Format16bppGrayScale)
    {
      var res = new Bitmap(width, height, format);
      var data = res.LockBits(new Rectangle(0, 0, res.Width, res.Height), ImageLockMode.WriteOnly, res.PixelFormat);

      Marshal.Copy(array, 0, data.Scan0, array.Length);
      res.UnlockBits(data);

      return res;
    }
  }
}