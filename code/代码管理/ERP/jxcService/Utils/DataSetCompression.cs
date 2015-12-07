using System;
using System.IO;
using System.Text;
using System.Data;
using System.IO.Compression;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;


namespace Utils
{
    class DataSetCompression
    {
        private DataSetCompression() { }
        /// <summary>
        /// 数据集格式转为二进制，并压缩
        /// </summary>
        /// <param name="dsOriginal"></param>
        /// <returns></returns>
        static public byte[] CompressionDataSet(DataSet dsOriginal)
        {
            // 序列化为二进制
            dsOriginal.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bFormatter = new BinaryFormatter();
            MemoryStream mStream = new MemoryStream();
            bFormatter.Serialize(mStream, dsOriginal);
            byte[] bytes = mStream.ToArray();
            // 压缩            
            MemoryStream oStream = new MemoryStream();
            DeflateStream zipStream = new DeflateStream(oStream, CompressionMode.Compress);
            zipStream.Write(bytes, 0, bytes.Length);
            zipStream.Flush();
            zipStream.Close();
            //
            return oStream.ToArray();
        }

        /// <summary>
        /// 解压缩二进制格式数据,得到数据集
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        static public DataSet DecompressionDataSet(byte[] bytes)
        {
            // 初始化流，设置读取位置
            MemoryStream mStream = new MemoryStream(bytes);
            mStream.Seek(0, SeekOrigin.Begin);
            // 解压缩
            DeflateStream unZipStream = new DeflateStream(mStream, CompressionMode.Decompress, true);
            // 反序列化得到数据集
            DataSet dsResult = new DataSet();
            dsResult.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bFormatter = new BinaryFormatter();
            dsResult = (DataSet)bFormatter.Deserialize(unZipStream);

            return dsResult;
        }
        #region comment
        /// <summary>
        /// 解压缩二进制格式数据,得到数据集
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static DataSet DecompressionDataSet1(byte[] bytes)
        {
            // 初始化流，设置读取位置
            MemoryStream mStream = new MemoryStream(bytes);
            mStream.Seek(0, SeekOrigin.Begin);
            // 解压缩流得到byte[]格式数据
            DeflateStream unZipStream = new DeflateStream(mStream, CompressionMode.Decompress, true);
            byte[] unzipBytes = StreamOperator.ReadWholeStream(unZipStream);
            unZipStream.Flush();
            unZipStream.Close();
            // 将数据装入内存
            MemoryStream resultStream = new MemoryStream(unzipBytes);
            resultStream.Seek(0, SeekOrigin.Begin);
            // 反序列化
            DataSet resultDataSet = new DataSet();
            resultDataSet.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bFormatter = new BinaryFormatter();
            resultDataSet = (DataSet)bFormatter.Deserialize(resultStream, null);
            //
            return resultDataSet;
        }
        ///// <summary>
        ///// 读取整个流的数据
        ///// </summary>
        ///// <param name="stream"></param>
        ///// <returns></returns>
        //public static byte[] ReadWholeStream(Stream stream)
        //{
        //    byte[] buffer = new byte[32768];
        //    using (MemoryStream mStream = new MemoryStream())
        //    {
        //        while (true)
        //        {                    
        //            int read = stream.Read(buffer, 0, buffer.Length);
        //            if (read <= 0)
        //            {
        //                return mStream.ToArray();
        //            }
        //            mStream.Write(buffer, 0, read);
        //        }
        //    }
        //}
        #endregion 
    }
}
