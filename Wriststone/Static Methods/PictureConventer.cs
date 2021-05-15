using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.IO;

namespace Wriststone.Static_Methods
{
    public static class PictureConventer
    {
        public static byte[] ConvertToByte(Image x)
        {
            ImageConverter imageConverter = new ImageConverter();
            byte[] xByte = (byte[])imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        public static Image ConvertToImage(byte[] byteArrayIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
                ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                return Image.FromStream(ms, true);
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public static byte[] GetBytesFromFile(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return target.ToArray();
            }
        }
    }
}
