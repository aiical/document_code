using System;
using System.IO;
using System.Data;
using System.Web;
using System.Collections;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO.Compression;
using System.Configuration;
using System.Web.Services;
using System.Runtime.Serialization;
using System.Web.Services.Protocols;
using System.Runtime.Serialization.Formatters.Binary;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Service : System.Web.Services.WebService
{
    public Service () {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod(EnableSession = true)]
    public string Login(string userName, string password)
    {
        if (userName == "YGA" && password == "Kinger")
        {
            Session["login"] = 1;
            return "success";
        }
        else
            return "failed";
    }

    [WebMethod]
    public string GetConStr(string strDB)
    {
        string strCon = "";
        string strServer = System.Configuration.ConfigurationManager.AppSettings["Server"]+"\\SQL2008";
        string strLogID = System.Configuration.ConfigurationManager.AppSettings["LogID"];
        string strPsw = System.Configuration.ConfigurationManager.AppSettings["LogPsw"];
        strCon = "Data Source="+strServer+";Initial Catalog="+strDB+";Persist Security Info=True;User ID="+strLogID+";Password="+strPsw;
        return strCon;
    }

    [WebMethod]
    public DataSet GetDs(string strDB,string strSQL)
    {
        DataSet ds = App_Code.SqlHelper.ExecuteDataset(GetConStr(strDB), CommandType.Text, strSQL);
        return ds;
    }

    [WebMethod]
    public byte[] GetOtherByte(ref string err, string strDB, string strSQL, byte[] Parm)
    {
        byte[] bArranyResult = null;
        try
        {
            object objParm = App_Code.DataSetCompression.DeserializeData(Parm);
            Hashtable htParm = (Hashtable)objParm;

            int intCnt = htParm.Count;

            SqlParameter[] sqlParm = new SqlParameter[intCnt];

            int i = 0;
            foreach (DictionaryEntry de in htParm)
            {
                sqlParm[i] = new SqlParameter(de.Key.ToString(), de.Value);
                i++;
            }

            DataSet ds = App_Code.SqlHelper.ExecuteDataset(GetConStr(strDB), CommandType.Text, strSQL, sqlParm);
            bArranyResult = App_Code.DataSetCompression.CompressionDataSet(ds); 
        }
        catch (Exception ee)
        {
            err = ee.Message.ToString();
        }
        return bArranyResult;
    }

    
    [WebMethod]
    public byte[] GetCompressDataSet(ref string err, string strDB, string strSQL)
    {
        byte[] bArranyResult = null;
        try
        {
            DataSet ds = App_Code.SqlHelper.ExecuteDataset(GetConStr(strDB), CommandType.Text, strSQL);
            bArranyResult = App_Code.DataSetCompression.CompressionDataSet(ds);
        }
        catch (Exception ee)
        {
            err = ee.Message.ToString();
        }
        return bArranyResult;
    }
    

    [WebMethod]
    public byte[] BinaryUserSelect(ref string err,string strDB,string strSQL)
    {
        byte[] bArrayResult = null;
        try
        {
            DataSet ds = App_Code.SqlHelper.ExecuteDataset(GetConStr(strDB), CommandType.Text, strSQL);
            ds.RemotingFormat = SerializationFormat.Binary;
            MemoryStream ms = new MemoryStream();
            IFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, ds);
            bArrayResult = ms.ToArray();
            //StreamReader sr = new StreamReader("");
            //StreamWriter sw = new StreamWriter("");

            //FileStream fs = new FileStream()
            ms.Close();
        }
        catch (Exception ee)
        {
            err = ee.Message.ToString();
        }
        return bArrayResult; 
    }


    //保存数据
    [WebMethod]
    public string SaveData(string strDB,DataSet ds, string strSQL)
    {  
        try
        {
            SqlConnection con = new SqlConnection(GetConStr(strDB));
            
            SqlDataAdapter myAdt = new SqlDataAdapter(strSQL, con);
            SqlCommandBuilder bd = new SqlCommandBuilder(myAdt);
            
            myAdt.Update(ds);
            con.Dispose();
            myAdt.Dispose();
            bd.Dispose();
            return "";
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2627)
                return "数据重复，请检查!!";
            else
                return ex.Message;
        }
    }

    //执行无返回结果ＳＱＬ语句
    [WebMethod]
    public string ExecuteSQL(string strDB,string strSQL)
    {
        SqlConnection sqlCon = new SqlConnection(GetConStr(strDB));
        SqlCommand myCommand = new SqlCommand(strSQL, sqlCon);
        myCommand.CommandTimeout = 0;
        try
        {
            try
            {
                sqlCon.Open();
                myCommand.ExecuteNonQuery();
                sqlCon.Close();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        finally
        {
            myCommand.Dispose();
            sqlCon.Dispose();
        }
    }

    /*
    //保存数据
    [WebMethod]
    public byte[] GetCompressDataSet(ref string err, string strSQL, params SqlParameter[] commandParameters)
    {
        byte[] bArranyResult = null;
        try
        {
            string strCon = System.Configuration.ConfigurationManager.AppSettings["ConStr"];
            DataSet ds = App_Code.SqlHelper.ExecuteDataset(strCon, CommandType.Text, strSQL, commandParameters);
            bArranyResult = App_Code.DataSetCompression.CompressionDataSet(ds);
        }
        catch (Exception ee)
        {
            err = ee.Message.ToString();
        }
        return bArranyResult;
    }
     */ 

    //保存数据
    [WebMethod]
    public string SaveMuteData(string strDB,DataSet[] ds, string[] strSQL)
    {
        //string strCon = System.Configuration.ConfigurationManager.AppSettings["ConStr"];
        SqlConnection con = new SqlConnection(GetConStr(strDB));
        int intCnt, i;
        intCnt = ds.Length;
        con.Open();
        SqlTransaction tran = con.BeginTransaction();
        try
        {
            try
            {
                for (i = 0; i < intCnt; i++)
                {
                    SqlCommand myComm = new SqlCommand();
                    myComm.Connection = con;
                    myComm.Transaction = tran;
                    myComm.CommandText = strSQL[i];

                    myComm.CommandTimeout = 0;

                    SqlDataAdapter myAdt = new SqlDataAdapter();
                    myAdt.SelectCommand = myComm;

                    SqlCommandBuilder bd = new SqlCommandBuilder(myAdt);
                    myAdt.Update(ds[i]);
                }
                tran.Commit();
                return "";
            }
            catch (Exception ex)
            {
                tran.Rollback();
                return ex.Message;
            }
        }
        finally
        {
            tran.Dispose();
        }

    }

    //保存数据
    [WebMethod]
    public string SaveMuteData1(string strDB, DataSet[] ds, string[] strSQL, byte[] Parm)
    {
        //string strCon = System.Configuration.ConfigurationManager.AppSettings["ConStr"];

        object objParm = App_Code.DataSetCompression.DeserializeData(Parm);
        Hashtable htParm = (Hashtable)objParm;

        int intPCnt = htParm.Count;

        SqlParameter[] sqlParm = new SqlParameter[intPCnt];

        int j = 0;
        foreach (DictionaryEntry de in htParm)
        {
            sqlParm[j] = new SqlParameter(de.Key.ToString(), de.Value);
            j++;
        }

        SqlConnection con = new SqlConnection(GetConStr(strDB));
        int intCnt, i;
        intCnt = ds.Length;
        con.Open();
        SqlTransaction tran = con.BeginTransaction();
        try
        {
            try
            {
                for (i = 0; i < intCnt; i++)
                {
                    SqlCommand myComm = new SqlCommand();
                    myComm.Connection = con;
                    myComm.Transaction = tran;
                    myComm.CommandText = strSQL[i];
                    myComm.Parameters.AddWithValue(sqlParm[0].ParameterName, sqlParm[0].Value);
                    //myComm.Parameters.Add(sqlParm[0].ParameterName, sqlParm[0].Value);
                    //myComm.Parameters.Add("@Value", SqlDbType.VarChar, 30, P[0].Value.ToString());
                    myComm.CommandTimeout = 0;

                    SqlDataAdapter myAdt = new SqlDataAdapter();
                    myAdt.SelectCommand = myComm;

                    SqlCommandBuilder bd = new SqlCommandBuilder(myAdt);
                    myAdt.Update(ds[i]);
                    myComm.Dispose();
                }
                tran.Commit();
                return "";
            }
            catch (Exception ex)
            {
                tran.Rollback();
                return ex.Message;
            }
        }
        finally
        {
            tran.Dispose();
        }

    }


   /*
    public bool UpdateData(string strSQL, string strDelSQL, DataSet ds)
    {


        SqlConnection con = new SqlConnection(strCon);

        con.Open();
        SqlCommand cd = new SqlCommand(strDelSQL, con);
        cd.ExecuteNonQuery();
        con.Close();

        SqlDataAdapter adt = new SqlDataAdapter(strSQL, con);
        SqlCommandBuilder cb = new SqlCommandBuilder(adt);

        foreach (DataRow oRow in ds.Tables[0].Rows)
        {
            oRow.SetAdded();
        }

        adt.Update(ds);
        cb.Dispose();
        adt.Dispose();
        con.Dispose();

    }
    */

    [WebMethod]
    public DataSet GetAccount()
    {
        string strDB = Server.MapPath(HttpContext.Current.Request.ApplicationPath)+"\\Account.mdb";
        string strOleCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strDB;
        DataSet ds = null;

        OleDbConnection oleCon = new OleDbConnection(strOleCon);
        OleDbDataAdapter oleAdt = new OleDbDataAdapter("select * from t_JXCAccount", oleCon);
        ds = new DataSet();
        oleAdt.Fill(ds);
 
        return ds;
    }

    [WebMethod]
    public bool SaveDocument(Byte[] docbinaryarray, string docname)
    {
        string strdocPath;
        
        strdocPath = "C:\\DocumentDirectory\\" + docname;
        FileStream objfilestream = new FileStream(strdocPath, FileMode.Create, FileAccess.ReadWrite);
        objfilestream.Write(docbinaryarray, 0, docbinaryarray.Length);
        objfilestream.Close();

        return true;
    }

    [WebMethod]
    public int GetDocumentLen(string DocumentName)
    {
        string strdocPath;
        strdocPath = "C:\\DocumentDirectory\\" + DocumentName;

        FileStream objfilestream = new FileStream(strdocPath, FileMode.Open, FileAccess.Read);
        int len = (int)objfilestream.Length;
        objfilestream.Close();

        return len;
    }


    [WebMethod]
    public Byte[] GetDocument(string DocumentName)
    {
        string strdocPath;
        strdocPath = "C:\\DocumentDirectory\\" + DocumentName;

        FileStream objfilestream = new FileStream(strdocPath, FileMode.Open, FileAccess.Read);
        int len = (int)objfilestream.Length;
        Byte[] documentcontents = new Byte[len];
        objfilestream.Read(documentcontents, 0, len);
        objfilestream.Close();

        return documentcontents;
    } 


    
}
