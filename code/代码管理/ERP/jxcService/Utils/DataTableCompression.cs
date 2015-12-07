using System;
using System.IO;
using System.Text;
using System.Data;
using System.IO.Compression;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace Utils
{
    public  class DataTableCompression
    {
        private DataTableCompression() { }
        static public byte[] CompressionDataTable(DataTable dtOriginal)
        {
            dtOriginal.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bFormatter = new BinaryFormatter();
            MemoryStream mStream = new MemoryStream();
            bFormatter.Serialize(mStream, dtOriginal);
            byte[] bytes = mStream.ToArray();

            MemoryStream oStream = new MemoryStream();
            DeflateStream zipStream = new DeflateStream(oStream, CompressionMode.Compress);
            zipStream.Write(bytes, 0, bytes.Length);
            zipStream.Flush();
            zipStream.Close();

            //
            return oStream.ToArray();
        }      

        public static DataTable DecompressionDataTable1(byte[] bytes)
        {
            MemoryStream mStream = new MemoryStream(bytes);
            mStream.Seek(0, SeekOrigin.Begin);

            DeflateStream unzipStream = new DeflateStream(mStream, CompressionMode.Decompress, true);

            DataTable dtResult = new DataTable();
            dtResult.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bFormatter = new BinaryFormatter();
            dtResult = (DataTable)bFormatter.Deserialize(unzipStream);

            return dtResult;
        }

        #region commented
        static public DataTable DecompressionDataTable(byte[] bytes)
        {
            MemoryStream mStream = new MemoryStream(bytes);
            mStream.Seek(0, SeekOrigin.Begin);

            DeflateStream unZipStream = new DeflateStream(mStream, CompressionMode.Decompress, true);
            byte[] unZipBytes = StreamOperator.ReadWholeStream(unZipStream);
            unZipStream.Flush();
            unZipStream.Close();

            MemoryStream resultStream = new MemoryStream(unZipBytes);
            resultStream.Seek(0, SeekOrigin.Begin);

            DataTable dtResult = new DataTable();
            dtResult.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bFormatter = new BinaryFormatter();
            dtResult = (DataTable)bFormatter.Deserialize(resultStream, null);

            return dtResult;
        }
        #endregion
    }
}
