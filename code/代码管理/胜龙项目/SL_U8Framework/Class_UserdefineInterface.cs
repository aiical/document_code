using System;
using System.Collections.Generic;
using System.Text;
using UFIDA.U8.MomServiceCommon;
using UFIDA.U8.U8MOMAPIFramework;
using UFIDA.U8.U8APIFramework;
using UFIDA.U8.U8APIFramework.Meta;
using UFIDA.U8.U8APIFramework.Parameter;
using MSXML2;
using System.Data;
using System.Data.SqlClient;
using UFIDA.U8.Portal.Proxy.supports;
using UFIDA.U8.Portal.Proxy.editors;
using UFIDA.U8.Portal.Proxy.Actions;
using System.Windows.Forms;
using UFIDA.U8.Portal.Framework.Actions;
using System.Xml;
using Donlim.Common;
using Donlim.Controls;
using Donlim.Data;

namespace SL_U8Framework
{
    class Class_UserdefineInterface : NetLoginable
    {
        private DataAccess ado;
        private string oldXml;
        #region 自定义项档案处理

        public bool Define_AfterInset(ref MSXML2.IXMLDOMDocument2 archivedata, ref string errMsg)
        {
            /********** 获取插件上下文信息：登录对象、连接、事件ID ***************/

            //获取插件上下文
            MomCallContext ctx = MomCallContextCache.Instance.CurrentMomCallContext;
            InitSqlConn(ctx.U8Login as U8Login.clsLogin);
             return UpdateFixTime(archivedata.xml, "Insert");
        }
        

         /// <summary>
        /// 自定义项档案更新前事件处理
        public bool Define_BeforeUpdate(ref MSXML2.IXMLDOMDocument2 archivedata, ref string errMsg)
        {
            //获取编辑时的值
            //MomCallContext ctx = MomCallContextCache.Instance.CurrentMomCallContext;
            
            //oldXml=archivedata.xml;
           return true;
        }
 
        /// <summary>
        /// 自定义项档案更新后事件处理
        /// </summary>
         public bool Define_AfterUpdate(ref MSXML2.IXMLDOMDocument2 archivedata, ref string errMsg)
        {
            /********** 获取插件上下文信息：登录对象、连接、事件ID ***************/

            //获取插件上下文
            //获取插件上下文
            //MomCallContext ctx = MomCallContextCache.Instance.CurrentMomCallContext;
            //InitSqlConn(ctx.U8Login as U8Login.clsLogin);
            //return UpdateFixTime(archivedata.xml,"Update");  //u8tool.ExeEAI("自定项档案", @"EAI\SL\define.xml");
            return true;
        }

         /// <summary>
         /// 自定义项档案删除后事件处理
         /// </summary>
         public bool Define_AfterDelete(ref MSXML2.IXMLDOMDocument2 archivedata, ref string errMsg)
         {
             /********** 获取插件上下文信息：登录对象、连接、事件ID ***************/

             //获取插件上下文
             MomCallContext ctx = MomCallContextCache.Instance.CurrentMomCallContext;
             InitSqlConn(ctx.U8Login as U8Login.clsLogin);
             return UpdateFixTime(archivedata.xml, "Delete");  //u8tool.ExeEAI("自定项档案", @"EAI\SL\define.xml");
         }

        #endregion

         private void InitSqlConn(U8Login.clsLogin u8login)
         {
             string connStr = u8login.UfDbName.ToString();
             string[] conSplit = connStr.Split(";".ToCharArray());
             string Server = conSplit[1].ToLower().Replace("data source=", "");
             string Uid = conSplit[2].ToLower().Replace("user id=", "");
             string Password = u8login.SysPassword;
             string DataBase = conSplit[4].ToLower().Replace("initial catalog=", "");
             string userName = u8login.cUserName;
             GlobalData.sysCon = Donlim.Data.DataAccess.GetSqlConnection(Server, DataBase, Uid, Password);
             if (ado == null)
             {
                 ado = new DataAccess();
             }

         }

         //SL_t_BanXing表事件处理
         private bool UpdateFixTime(string _xml, string _flag)
         {
             XmlDocument xmldoc = new XmlDocument();
             xmldoc.LoadXml(_xml);
             string id = xmldoc.SelectSingleNode("/userdefine/cid").InnerText;
             string value = xmldoc.SelectSingleNode("/userdefine/cvalue").InnerText;
             string alias = "";
             try
             {
                  alias = xmldoc.SelectSingleNode("/userdefine/calias").InnerText;
             }
             catch
             {
             }           
             string Cid = ado.ExeScalar("Select cId from userdef where cClass='客户' and citem='自定义项6' ").ToString();
             if (Cid == id) //须确定自定义项是哪个
             {
                 switch (_flag)
                 {
                     case "Insert":
                         {
                             ado.ExeSql("insert into SL_t_BanXing(u8calias,U8cValue,[Timestamp]) VALUES(" + (alias==""?"Null,'":"'"+alias+"','") +value + "',GETDATE())");
                             break;
                         }
                     case "Update":
                         {
                         XmlDocument oldxmldoc = new XmlDocument();
                         oldxmldoc.LoadXml(oldXml);
                         string oldid = oldxmldoc.SelectSingleNode("/userdefine/cid").InnerText;
                         string oldvalue = oldxmldoc.SelectSingleNode("/userdefine/cvalue").InnerText;
                         string oldalias = "";
                         try
                         {
                             oldalias = oldxmldoc.SelectSingleNode("/userdefine/calias").InnerText;
                         }
                         catch
                         {
                         }
                             ado.ExeSql("update SL_t_BanXing set u8calias=" + (alias==""?"Null":"'"+alias+"'") + ",U8cValue='" + value + "',[Timestamp]=GETDATE() where u8calias=" + (oldalias==""?"Null":"'"+oldalias+"'") + " and U8cValue='" + oldvalue + "'");
                             break;
                         }
                     case "Delete":
                         {
                             ado.ExeSql("delete SL_t_BanXing  where U8cValue='" + value + "'");
                             break;
                         }
                 }
             }
             return true;
         }

    }
}
