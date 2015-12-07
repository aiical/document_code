using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Utils
{
    public class DataConverter
    {
        private DataConverter() { }

        static public byte[] GetBinaryData(DataTable dtOriginal)
        {
            dtOriginal.RemotingFormat = SerializationFormat.Binary;
            IFormatter bFormatter = new BinaryFormatter();

            MemoryStream mStream = new MemoryStream();
            bFormatter.Serialize(mStream, dtOriginal);
            byte[] bytesResult = mStream.ToArray();
            return bytesResult;
        }

        static public DataTable GetDataTable(byte[] bytes)
        {
            MemoryStream mStream = new MemoryStream(bytes);
            IFormatter bFormatter = new BinaryFormatter();

            DataTable dtResult = new DataTable();
            dtResult = (DataTable)bFormatter.Deserialize(mStream);
            return dtResult;
        }
    }
}
