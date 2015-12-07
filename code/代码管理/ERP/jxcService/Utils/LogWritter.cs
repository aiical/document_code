using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class LogWriter
    {
        private LogWriter() {         
        }
        static private LogWriter m_Writer = null;
        static public LogWriter GetInstance
        { 
            get{
                if (m_Writer == null)
                {
                    m_Writer = new LogWriter();
                }
                return m_Writer;
            }
        }

        private string path = null;
        public string Path
        {
            get {
                return path;
            }
            set {
                path = value;
            }
        }

        public void Write(string timeSpan, QueryMethod method)
        {
            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write);
                fs.Flush();
                fs.Close();
                fs = null;
            }
            StreamWriter writer = new StreamWriter(path, true, System.Text.Encoding.Default);
            writer.WriteLine(timeSpan + "         " + method.ToString());
            writer.Flush();
            writer.Close();
            writer.Dispose();
        }

        public void Dispose()
        {            
            m_Writer = null;
        }
    }

    public enum QueryMethod
    {
        CompressionMe,
        CompressionForeigner,
        BinaryOriginal,
        DataTableOriginal
    }
}
