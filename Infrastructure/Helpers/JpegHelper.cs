using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Infrastructure.Helper
{
    public static class JpegHelper
    {

        public static byte[] JpegCompress(byte[] image,CompressionLevel level)
        {
            return Compress(image, level);
        }

        public static byte[] JpegDeCompress(byte[] image)
        {
            return DeCompress(image);
        }

        private static byte[] Compress(byte[] data,CompressionLevel level)
        {
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(output, level))
            {
                dstream.Write(data, 0, data.Length);
            }
            return output.ToArray();
        }

        private static byte[] DeCompress(byte[] data)
        {
            MemoryStream input = new MemoryStream(data);
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(input, CompressionMode.Decompress))
            {
                dstream.CopyTo(output);
            }
            return output.ToArray();
        }
    }
}
