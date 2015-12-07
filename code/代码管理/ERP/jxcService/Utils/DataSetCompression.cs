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
        /// ���ݼ���ʽתΪ�����ƣ���ѹ��
        /// </summary>
        /// <param name="dsOriginal"></param>
        /// <returns></returns>
        static public byte[] CompressionDataSet(DataSet dsOriginal)
        {
            // ���л�Ϊ������
            dsOriginal.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bFormatter = new BinaryFormatter();
            MemoryStream mStream = new MemoryStream();
            bFormatter.Serialize(mStream, dsOriginal);
            byte[] bytes = mStream.ToArray();
            // ѹ��            
            MemoryStream oStream = new MemoryStream();
            DeflateStream zipStream = new DeflateStream(oStream, CompressionMode.Compress);
            zipStream.Write(bytes, 0, bytes.Length);
            zipStream.Flush();
            zipStream.Close();
            //
            return oStream.ToArray();
        }

        /// <summary>
        /// ��ѹ�������Ƹ�ʽ����,�õ����ݼ�
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        static public DataSet DecompressionDataSet(byte[] bytes)
        {
            // ��ʼ���������ö�ȡλ��
            MemoryStream mStream = new MemoryStream(bytes);
            mStream.Seek(0, SeekOrigin.Begin);
            // ��ѹ��
            DeflateStream unZipStream = new DeflateStream(mStream, CompressionMode.Decompress, true);
            // �����л��õ����ݼ�
            DataSet dsResult = new DataSet();
            dsResult.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bFormatter = new BinaryFormatter();
            dsResult = (DataSet)bFormatter.Deserialize(unZipStream);

            return dsResult;
        }
        #region comment
        /// <summary>
        /// ��ѹ�������Ƹ�ʽ����,�õ����ݼ�
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static DataSet DecompressionDataSet1(byte[] bytes)
        {
            // ��ʼ���������ö�ȡλ��
            MemoryStream mStream = new MemoryStream(bytes);
            mStream.Seek(0, SeekOrigin.Begin);
            // ��ѹ�����õ�byte[]��ʽ����
            DeflateStream unZipStream = new DeflateStream(mStream, CompressionMode.Decompress, true);
            byte[] unzipBytes = StreamOperator.ReadWholeStream(unZipStream);
            unZipStream.Flush();
            unZipStream.Close();
            // ������װ���ڴ�
            MemoryStream resultStream = new MemoryStream(unzipBytes);
            resultStream.Seek(0, SeekOrigin.Begin);
            // �����л�
            DataSet resultDataSet = new DataSet();
            resultDataSet.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bFormatter = new BinaryFormatter();
            resultDataSet = (DataSet)bFormatter.Deserialize(resultStream, null);
            //
            return resultDataSet;
        }
        ///// <summary>
        ///// ��ȡ������������
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
