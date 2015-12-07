using System;
using System.IO;
using System.Text;
using System.Collections.Generic;


namespace Utils
{
    class StreamOperator
    {
        private StreamOperator() { }
        internal static byte[] ReadWholeStream(Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream mStream = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                    {
                        return mStream.ToArray();
                    }
                    mStream.Write(buffer, 0, read);
                }
            }
        }
    }
}
