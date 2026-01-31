using System.IO;
using System.IO.Compression;
using System.Text;

namespace Oracle.Utilities
{
    public static class CompressUtility
    {
        public static byte[] CompressString(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            using (var oStream = new MemoryStream())
            {
                using (var iStream = new MemoryStream(Encoding.UTF8.GetBytes(text)))
                {
                    using (var cStream = new GZipStream(oStream, CompressionMode.Compress, true))
                    {
                        byte[] buffer = new byte[4096];

                        int bytesRead; while ((bytesRead = iStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            cStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }

                return oStream.ToArray();
            }
        }

        public static string DecompressString(byte[] data)
        {
            if (data == null)
            {
                return null;
            }

            using (var oStream = new MemoryStream())
            {
                using (var iStream = new MemoryStream(data))
                {
                    using (var cStream = new GZipStream(iStream, CompressionMode.Decompress, true))
                    {
                        byte[] buffer = new byte[4096];

                        int bytesRead; while ((bytesRead = cStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            oStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }

                return Encoding.UTF8.GetString(oStream.ToArray());
            }
        }
    }
}