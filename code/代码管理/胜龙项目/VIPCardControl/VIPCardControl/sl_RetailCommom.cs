using System;
using System.Collections.Generic;
using System.Text;
using UFIDA.Retail.Common;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using UFIDA.Retail.Utility;
using System.Data;
using UFIDA.Retail.Components;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using UFIDA.Retail.Discount;
using System.Collections;
using CompressDataSet;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace UFIDA.Retail.VIPCardControl
{
    class sl_RetailCommom
    {
        private static string _QueryVouchCode;

        public static string QueryVouchCode
        {
            get { return sl_RetailCommom._QueryVouchCode; }
            set { sl_RetailCommom._QueryVouchCode = value; }
        }

        /// <summary>
        /// 展厅冲单/补单公共查询条件
        /// </summary>
        private static string _frmReturnFormRelation;

        public static string FrmReturnFormRelation
        {
            get { return sl_RetailCommom._frmReturnFormRelation; }
            set { sl_RetailCommom._frmReturnFormRelation = value; }
        }

        /// <summary>
        /// 检查网络是否连接成功
        /// </summary>
        /// <param name="IpAddr"></param>
        /// <returns></returns>
        public bool CheckNetIsConnected(string IpAddr)
        {
            bool bflag = true;
            Ping pingSender = new Ping();
            PingReply reply = null;
            try
            {
                reply = pingSender.Send(IpAddr, 1000);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.InnerException.Message);
                bflag = false;
            }
            finally
            {
                if (reply == null || (reply != null && reply.Status != IPStatus.Success))
                {
                    RetailMessageBox.ShowInformation("远程服务器无法连接,请检查网络!");
                    bflag = false;
                }
                else if (reply.Status == IPStatus.Success)
                {
                    //this.Text = "连接成功";
                    bflag = true;
                }
            }
            return bflag;
        }

        /// <summary>
        /// 获取指定表中的字段值
        /// </summary>
        /// <param name="ReturnFieldName"></param>
        /// <param name="TableName"></param>
        /// <param name="KeyFieldName"></param>
        /// <param name="KeyFieldValue"></param>
        /// <returns></returns>
        public static string GetValues(string ReturnFieldName, string TableName, string KeyFieldName, string KeyFieldValue)
        {
            string returnValue = "";
            string sql = string.Format(@" select top 1 {0} from {1} where {2} = '{3}'", ReturnFieldName, TableName, KeyFieldName, KeyFieldValue);
            using (SqlDataReader sdr = SqlAccess.ExecuteReader(SysPara.ConnectionString,CommandType.Text,sql) as SqlDataReader)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        returnValue = sdr[ReturnFieldName].ToString();
                    }
                }
            }

            return returnValue;
        }

        /// <summary>
        /// 检查VIP客户持有VIP卡的合法性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool CheckVIPCardInventoryAddMuti(string New_CardCode, string ConsumerID)
        {
            bool checkResult = true;
            VIPCardControl cardControl = new VIPCardControl();

            //检查所指定的VIP是否被占用或已分配
            if (cardControl.checkVipCardToConsumer(New_CardCode))
            {
                RetailMessageBox.ShowError("您所选择的VIP卡已经分配客户，请重新选择！");
                checkResult = false;
            }
            //胜龙二次开发-卡级别检测机制
            //if (!cardControl.checkVipCardClass(New_CardCode, ConsumerID))
            //{
            //    RetailMessageBox.ShowError("您选择的卡级别和客户级别不匹配，请重新选择！");
            //    checkResult = false;
            //}

            return checkResult; 
        }

        /// <summary>
        /// 检查新增的VIP卡级别对应的存货是否有足够的库存
        /// </summary>
        /// <param name="fchrVIPCardClassID"></param>
        /// <returns></returns>
        public bool CheckVIPCardsItemStocks(string fchrVIPCardClassID)
        {
            float flotQty = 0;
            string sql = string.Format(@"select isnull(flotQuantity,0) as flotQuantity from ItemStocks
                                       where fchritemid = (select S01_fchritemid from vipcardclass where fchrVIPCardClassID = '{0}') ", fchrVIPCardClassID);
            try
            {
                SqlDataReader sdr = (SqlDataReader)SqlAccess.ExecuteReader(SysPara.ConnectionString, CommandType.Text, sql, null);
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        flotQty = Convert.ToSingle(sdr["flotQuantity"]);
                    }
                }
            }
            catch (Exception ex) { RetailMessageBox.Show(ex.Message); }

            if (flotQty > 0)
                return true;
            else
                return false;
        }

        #region  写rel.ini 文件
        [System.Runtime.InteropServices.DllImport("kernel32")]
        public static extern bool WritePrivateProfileString(string section, string key, string def, string filePath);
        // e.g. WritePrivateProfileString("RepairBillDate", "RepairBill", objItemData.RepairBillDate.ToString("yyyy-MM-dd"), @".\RepairBillDate.Ini");
        #endregion

        #region  读取rel.ini 文件
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        //StringBuilder ResultValue = new StringBuilder(65535);
        //int i = sl_RetailCommom.GetPrivateProfileString("RepairBillDate", "RepairBill", "", ResultValue, 65535, @".\rel.Ini");
        #endregion

        /// <summary>
        /// 读取配置文件指定的值
        /// </summary>
        /// <param name="Configfile">配置文件的全路径文件名</param>
        /// <param name="Section">段名</param>
        /// <param name="Key">项名</param>
        /// <param name="def">为空的默认值</param>
        /// <returns>字符串值</returns>
        public static string GetPrivateProfileString(string Configfile, string Section, string Key, string def)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, def, temp, 255, Configfile);
            return temp.ToString();
        }

        /// <summary>
        /// 删除指定节点下的KEY值
        /// </summary>
        /// <param name="section">指定节点</param>
        /// <param name="key">指定节点下的key</param>
        /// <returns>删除成功或不存在时都返回true</returns>
        public static bool DeleteKey(string section, string key,string filtpath)
        {
            bool flag = false;
            try
            {
                if (section.Trim().Length <= 0 || key.Trim().Length <= 0)
                {
                    flag = false;
                }
                else
                {
                    if (WritePrivateProfileString(section, key, null, filtpath))
                    {
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 删除指定节点
        /// </summary>
        /// <param name="section">要删除的节点名</param>
        /// <returns>删除成功或节点不存在，返回值都为真</returns>
        public static bool DeleteSection(string section, string filtpath)
        {
            bool flag = false;//标志
            try
            {
                if (section.Trim().Length <= 0)
                {//找不到节点
                    flag = false;
                }
                else
                {
                    if (WritePrivateProfileString(section, null, null, filtpath))
                    {
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                    }
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 将所确立好的VIP卡与VIP客户之间的关系，真正的保存到数据库中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void SaveVipConsumerRelation(string strVIPConsumerID, string strVIPCalssID,string strVipCode,string Old_CardCode,ref string ErrMsg)
        {
            //HandleEvent eventHandler = args.HandleEvent;
            //Init InitFormClass = eventHandler.InitFormClass;
            //string strVIPConsumerID = "";
            string errDesc = "";
            //string strVipCode = "";
            string strSQL = "";
            bool bolProvide = false;          //是否发卡
            string strVIPConsumerName = "";
            //string strVIPCalssID = "";
            DataSet dsSave = new DataSet();
            SqlConnection oConn = null;
            IDbTransaction tran = null;
            string fdtmSamClassEndate = "";
            string DetailvipCode = string.Empty;
            bool fbitIsSameClass = false;
            string vipCurrCardClassID = null;
            VIPDoWithEx VipDoWith = new VIPDoWithEx();

            try
            {

                try
                {
                    oConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
                    SqlAccess.Open(oConn);
                }
                catch
                {
                    SqlAccess.Close(oConn);
                    return;
                }
                tran = SqlAccess.BeginTransaction(oConn);

                //Control controlSource = null;
                // 得到网格中的VIP信息明细
                //HandleEvent.FilterEmptyRows(InitFormClass.DGrid);
                //DataGrid ParentGrid = InitFormClass.DGrid;
                //DataSet ds = ParentGrid.DataSource as DataSet;


                //得到客户的ID
                //controlSource = HandleEvent.FindControl("fchrvipconsumerid", InitFormClass.MainForm);
                //strVIPConsumerID = HandleEventHelper.GetControlValues(controlSource, "ExLabel");

                //controlSource = HandleEvent.FindControl("fchrVIPCardClassID", InitFormClass.MainForm);
                //strVIPCalssID = HandleEventHelper.GetControlValues(controlSource, "RefControl");


                //网格中的商品信息明细是否为空
                //if (ds != null)
                //{
                    //DataTable dt = ds.Tables["DTDetail"];

                    //if (dt.Rows.Count == 0)
                    //{
                    //    RetailMessageBox.ShowExclamation("没有明细数据记录，无法保存！");
                    //    return;
                    //}

                    ////数据都删除时不允许保存。V891一期补丁 
                    //if (dt.Select("", "", DataViewRowState.Deleted).Length == dt.Rows.Count)
                    //{
                    //    RetailMessageBox.ShowExclamation("没有明细数据记录，无法保存！");
                    //    return;
                    //}

                    //判断该客户是否已上传并且已核对
                    strSQL = string.Format("select top 1 fbitExport,fbitCheck,fbitVerify_DQ from vipconsumer where fchrvipconsumerid = '{0}'", strVIPConsumerID);
                    DataSet dsCheck = SqlAccess.ExecuteDataset(tran, CommandType.Text, strSQL);
                    if (dsCheck.Tables[0].Rows.Count > 0)
                    {
                        if ((!(bool)dsCheck.Tables[0].Rows[0]["fbitExport"] && dsCheck.Tables[0].Rows[0]["fbitVerify_DQ"].ToString() == "") || dsCheck.Tables[0].Rows[0]["fbitVerify_DQ"].ToString() == "0")
                        {
                            //RetailMessageBox.ShowExclamation("VIP客户资料未核对，不能继续晋级或换卡！");
                            ErrMsg = "VIP客户资料未核对，不能继续晋级或换卡！";
                            return;
                        }
                    }

                    strSQL = string.Format("select fchrVIPCardClassID from vipconsumer where fchrvipconsumerid = '" + strVIPConsumerID.ToString() + "'");
                    vipCurrCardClassID = Convert.ToString(SqlAccess.ExecuteScalar(tran, CommandType.Text, strSQL));
                    if (vipCurrCardClassID == strVIPCalssID)
                    {
                        fbitIsSameClass = true;
                        strSQL = string.Format("select top 1 fdtmEnddate from vipcodecollate where fchrVipCode = '" + Old_CardCode + "'");
                        fdtmSamClassEndate = Convert.ToString(SqlAccess.ExecuteScalar(tran, CommandType.Text, strSQL));
                    }

                    strVIPConsumerName = VipDoWith.GetConsumerName(strVIPConsumerID);
                    // 执行SQL语句，首先先去掉这个客户所有的VIP卡的信息

                    //strSQL = string.Format("UPDATE VipCodeCollate set fchrvipconsumerid=null,fnarconsumername=null WHERE fchrvipconsumerid='{0}'", strVIPConsumerID);
                    //SqlAccess.ExecuteNonQuery(tran, CommandType.Text, strSQL);

                    //strSQL = string.Format("UPDATE VipConsumer set fbitProvide=0, WHERE fchrvipconsumerid='{0}'", strVIPConsumerID);
                    //SqlAccess.ExecuteNonQuery(tran, CommandType.Text, strSQL);


                    bolProvide = false;
                    // 在依据  在界面所看到的信息一个一个的 去建立关系
                    StringBuilder strBuilder = new StringBuilder();
                    //foreach (DataRow oRows in dt.Rows)
                    //{
                    //    if (oRows.RowState != DataRowState.Deleted)
                    //    {
                            //strVipCode = Tools.GetStringColumnValue(oRows["fchrVipCode"]);

                            //if (Convert.ToBoolean(oRows["fbitUse"]))   //如果使用的卡被别的客户引用过，则去掉原来的关系并进行维护
                            //{
                                if (strVIPCalssID == "")
                                {
                                    strSQL = "select fchrVIPCardClassID from vipcardclass where fbitDefaultClass='true'";
                                    strVIPCalssID = SqlAccess.ExecuteScalar(tran, CommandType.Text, strSQL).ToString();
                                }

                                string strVIPCards = VipDoWith.GetVipCards(strVipCode);

                                strSQL = string.Format("UPDATE VIPConsumer  SET fchrVipcards='{2}',fbitExport=0,fchrVIPCardClassID='{3}' WHERE fchrVipConsumerID IN (SELECT fchrVipConsumerID  FROM VipCodeCollate WHERE fchrVipCode='{0}' AND fchrVipConsumerID<>'{1}');Update VipCodeCollate set fchrNewCardCode = '{0}' where fchrvipCode = '{4}'",
                                            strVipCode, strVIPConsumerID, strVIPCards, strVIPCalssID, Old_CardCode);

                                SqlAccess.ExecuteNonQuery(tran, CommandType.Text, strSQL);
                            //}

                            //strSQL = string.Format("UPDATE VipCodeCollate set fchrvipconsumerid='{0}',fnarconsumername='{1}' WHERE fchrVipCode='{2}'", strVIPConsumerID, strVIPConsumerName, strVipCode);
                            //SqlAccess.ExecuteNonQuery(tran, CommandType.Text, strSQL);
                            strBuilder.AppendFormat(",'{0}'", strVipCode);
                            bolProvide = true;
                    //    }
                    //}
                    string str = GetPrivateProfileString(@".\RepairBillDate.Ini", "RepairBill", "RepairBillDate", "");

                    //胜龙客开-将旧VIP卡有效期顺延、更新旧卡信息
                    //if (fbitIsSameClass)
                    //{
                    //    //同级换卡旧卡
                    //    strSQL = string.Format("UPDATE vipcodeCollate set fdtmEndDate= Convert(varchar(100),getdate(),23),fbitExport = 0,fbitUse = 0,fbitOldCard = 1,fdtmStopDate = null,fchrNewCardCode = '{1}' where fchrvipCode = '{0}'", Old_CardCode, strVipCode);
                    //    SqlAccess.ExecuteNonQuery(tran, CommandType.Text, strSQL);
                    //}
                    //else
                    //{
                        //晋级换卡旧卡
                        strSQL = string.Format("UPDATE vipcodeCollate set fdtmEndDate=Convert(varchar(50),Convert(varchar(100),dateadd(dd,-day(convert(varchar(10),dateadd(day,30,getdate()),121)),dateadd(m,1,convert(varchar(10),dateadd(day,30,getdate()),121))),23),23),fbitExport = 0,fbitOldCard = 1,fdtmStopDate = null,fbitUse = 1,fchrNewCardCode = '{1}' where fchrvipCode = '{0}'", Old_CardCode, strVipCode);
                        SqlAccess.ExecuteNonQuery(tran, CommandType.Text, strSQL);
                    //}


                    //更新新卡信息
                    if (bolProvide)
                    {
                        //获取晋级积分  by ljx
                        string selCmd = string.Format("select S01_fintPromotPoints from vipCardClass where fchrVIPCardClassID='{0}'", strVIPCalssID);
                        object s01_fintPromotPoints = SqlAccess.ExecuteScalar(tran, CommandType.Text, selCmd);
                        //获取RM的设置的晋级积分条件 by ljx
                        selCmd = string.Format("select fchrSelectionString from sl_VipCardDueConfig where fchrType='Pro'");
                        object relString = SqlAccess.ExecuteScalar(tran, CommandType.Text, selCmd);
                        relString = "1=1";
                        // if (relString == null)
                        // { relString = "1=1"; }

                        string strVipCodes = strBuilder.ToString().Substring(1);  //去掉前导逗号
                        //if (fbitIsSameClass)
                        //{
                        //    strSQL = string.Format("UPDATE VipCodeCollate SET fchrvipconsumerid='{0}',fnarconsumername='{1}',S01_fchrVIPCardClassID='{4}',fdtmstartdate = convert(varchar(100),getdate(),23),fdtmenddate = '" + fdtmSamClassEndate + "',fbitExport = 0,fbitOldCard = 0 from vipcardclass c with(nolock) WHERE fchrVipCode IN ('{2}') and c.fchrvipcardclassid = '{4}';UPDATE VipConsumer SET fbitExport=0, fbitProvide=1,fchrVipCards='{3}',fchrVIPCardClassID='{4}',fintInitTotal={5} WHERE fchrvipconsumerid='{0}' and {6}",
                        //                            strVIPConsumerID, strVIPConsumerName, strVipCode, strVipCodes.Replace("'", ""), strVIPCalssID, s01_fintPromotPoints, relString);
                        //}
                        //else
                        //{
                            strSQL = string.Format("UPDATE VipCodeCollate SET fchrvipconsumerid='{0}',fnarconsumername='{1}',S01_fchrVIPCardClassID='{4}',fdtmstartdate =convert(varchar(100),getdate(),23),fdtmenddate = convert(varchar(10),dateadd(month,isnull(c.S01_fintValidMonths,24)+1,isnull(getdate(),getdate()))-day(dateadd(month,isnull(c.S01_fintValidMonths,24)+1,isnull(getdate(),getdate()))),121),fbitExport = 0,fbitOldCard = 0 from vipcardclass c with(nolock) WHERE fchrVipCode IN ('{2}') and c.fchrvipcardclassid = '{4}';UPDATE VipConsumer SET fbitExport=0, fbitProvide=1,fchrVipCards='{3}',fchrVIPCardClassID='{4}',fintInitTotal={5}  WHERE fchrvipconsumerid='{0}' and {6}",
                                                    strVIPConsumerID, strVIPConsumerName, strVipCode, strVipCodes.Replace("'", ""), strVIPCalssID, s01_fintPromotPoints, relString);
                        //}
                        SqlAccess.ExecuteNonQuery(tran, CommandType.Text, strSQL);
                    }

                    //SqlAccess.ExecuteNonQuery(tran, CommandType.Text, "EXEC ProcCheckVipConsumerProvide");

                    //RetailMessageBox.ShowInformation("VIP卡信息保存成功！");

                    //储值卡换卡
                    string OldStoredCardID = "";
                    string NewStoredCardID = "";
                    OldStoredCardID = VipDoWith.GetStoredCardID(Old_CardCode);
                    NewStoredCardID = VipDoWith.GetStoredCardID(strVipCode);
                    if (OldStoredCardID != "" && NewStoredCardID != "")
                    {
                        //VipDoWith.ChangeStoredCard(OldStoredCardID, NewStoredCardID, Old_CardCode, strVipCode);
                        tran.Commit();
                        SqlAccess.Close(oConn);
                    }
                    //else if (OldStoredCardID == "")
                    //{
                    //    RetailMessageBox.ShowInformation(Old_CardCode + " 的储值卡不存在，储值卡换卡失败！");
                    //    tran.Rollback();
                    //    SqlAccess.Close(oConn);
                    //    return;
                    //}
                    //else if (NewStoredCardID == "")
                    //{
                    //    RetailMessageBox.ShowInformation(strVipCode + " 的储值卡不存在，储值卡换卡失败！");
                    //    tran.Rollback();
                    //    SqlAccess.Close(oConn);
                    //    return;
                    //}
                //}
            }
            catch (Exception ex)
            {
                tran.Rollback();
                SqlAccess.Close(oConn);
                errDesc = ex.Message;
                return;
            }
        }
        
        /// <summary>
        /// 检查当前VIP卡是否走多层判断流程
        /// </summary>
        /// <param name="fchrCurVIPCardCode"></param>
        /// <returns></returns>
        public bool CheckVIPValid(string fchrCurVIPCardCode)
        {
            bool bFlag = true;
            DataTable dt = new DataTable();
            string sql = string.Empty;
            sql = string.Format(@"select isnull(fdtmEndDate,'') as fdtmEndDate,isnull(fbitOldCard,0) as fbitOldCard from vipcodecollate
                                  where fchrVipCode = '{0}' and isnull(fdtmStopDate,'') = ''", fchrCurVIPCardCode);
            dt = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, sql);
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToBoolean(dt.Rows[0]["fbitOldCard"])) //属于旧卡
                {
                    if (dt.Rows[0]["fdtmEndDate"].ToString() != "")
                    {
                        if (Convert.ToDateTime(dt.Rows[0]["fdtmEndDate"].ToString()) >= Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")))
                        {
                            bFlag = false;
                        }
                    }
                }
                else //属于新卡
                {
                    bFlag = true;
                }
            }

            return bFlag;
        }

        /// <summary>
        /// 检查当前客户最新的VIP卡卡号是否为升级换卡
        /// </summary>
        /// <param name="fchrVipCode"></param>
        /// <returns></returns>
        public bool CheckVipCodeIsUpgrade(string vipCode)
        {
            string sql = string.Empty;
            bool bFlag = true;
            sql = string.Format(@"select count(1) from S01_VIPCardChangeRecord
                                  where S01_fchrNewCardCode = (select top 1 fchrvipcards from vipconsumer where fchrvipconsumerid = (select top 1 fchrvipconsumerid from vipcodecollate where fchrvipcode = '{0}')) and isnull(fbitUpgrade,0) = 1", vipCode);
            int i = 0;
            i = Convert.ToInt32(SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sql));
            if (i <= 0)
              bFlag = false;
            return bFlag;
        }

        /// <summary>
        /// VIP客户管理列表输出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void VIPListExportToExcel(object sender, ExternalMethodCallArgs args)
        {
            DataExport export = new DataExport();
            //HandleEvent handleEvent = args.HandleEvent;
            //Init initFormClass = handleEvent.InitFormClass;
            //DataSet dataSource = initFormClass.DGrid.DataSource as DataSet;
            //DataSet dataSource = handleEvent.GetDataGrid().DataSource as DataSet;
            //string strVIPConsumerID = HandleEventHelper.GetControlValues(HandleEvent.FindControl("fchrvipconsumerid", initFormClass.MainForm), "ExLabel");
            string FieldNameStr = string.Empty;
            FieldNameStr = @"fchrVipCode as 'VIP卡号',
                               fnarconsumername as '客户名称',
                               fchrVIPCardClassName as 'VIP客户级别',
                               Convert(varchar(10),fdtmApplyTime,23) as '申请日期',
                               Convert(decimal(18,2),fintTotalPoints) as '累计积分',
                               Convert(decimal(18,2),flotPointBalance) as '剩余积分',
                               fnarmobilephone as '移动电话',
                               fnarphone as '固定电话',
                               fnarsex as '性别',
                               fintBirthdayYear as '出生年',
                               fintBirthdayMonth as '出生月',
                               fintBirthdayDay as '出生日',
                               fnarcertificatecode as '有效证件号码',
                               fchrEmployee as '经手营业员',
                               (case when fbitExport = 1 then '是' else '否' end) as '已上传',
                               (case when fbitCheck = 1 then '是' else '否' end) as '已核对',
                               (case when fbitPromoteAudit = 1 then '是' else '否' end) as '晋级是否审核',
                               fchrVIPCusDefine1Name as '单位名称',
                               fchrVIPCusDefine2Name as '职称',
                               fchrVIPCusDefine3Name as '年龄',
                               fchrVIPCusDefine4Name as '学历',
                               fchrVIPCusDefine5Name as '平均月收入',
                               fchrVIPCusDefine6Name as '从事行业',
                               fchrVIPCusDefine7Name as '职位'";
            string sql = string.Format(@"select {0} from viewvipconsumerlist
                                         where fchrStoreid = (select top 1 fchrstoredefineid from storedefine)", FieldNameStr);
            DataSet dataSource = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql);
            if (dataSource != null)
            {
                DataTable table = dataSource.Tables[0];
                DataTable DetailTable;

                //输出Excel处理过程
                DataTable tmpDataTable = null;
                string FilePath = "";
                System.Windows.Forms.SaveFileDialog saveFile = new System.Windows.Forms.SaveFileDialog();
                saveFile.Filter = "Excel文件(*.xls)|*.xls";
                saveFile.FilterIndex = 2;
                saveFile.FileName = string.Format("VipConsumer_{0}.xls", DateTime.Now.ToString("yyyyMMddHHmmss"));
                saveFile.RestoreDirectory = true;
                if (saveFile.ShowDialog() == DialogResult.OK)   
                {
                    FilePath = saveFile.FileName.ToString();
                    tmpDataTable = table.Copy();
                    if (tmpDataTable != null)
                    {
                        //ExcelControl.KillProcess("EXCEL");
                        //UpdateColName(ref tmpDataTable);
                        export.DataTabletoExcel(tmpDataTable, FilePath);
                        MessageBox.Show("数据输出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("沒有满足条件的数据导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
        }

        /// <summary>
        /// 更新DataTable中文字段名称
        /// </summary>
        /// <param name="dt"></param>
        private void UpdateColName(ref DataTable dt)
        {
            for (int c = 0; c < dt.Columns.Count; c++)
            {
                switch (dt.Columns[c].ColumnName)
                {
                    case "fchrvipconsumerid":
                        dt.Columns[c].ColumnName = "VIP客户ID";
                        break;
                    case "fdtmApplyTime":
                        dt.Columns[c].ColumnName = "VIP申请时间";
                        break;
                    case "fnarconsumername":
                        dt.Columns[c].ColumnName = "VIP客户名称";
                        break;
                    case "fnarsex":
                        dt.Columns[c].ColumnName = "性别";
                        break;
                    case "fdtmbirthday":
                        dt.Columns[c].ColumnName = "生日";
                        break;
                    case "fnarcertificatetype":
                        dt.Columns[c].ColumnName = "证件类型";
                        break;
                    case "fnarcertificatecode":
                        dt.Columns[c].ColumnName = "证件号码";
                        break;
                    case "fnarphone":
                        dt.Columns[c].ColumnName = "固定电话";
                        break;
                    case "fnarmobilephone":
                        dt.Columns[c].ColumnName = "移动电话";
                        break;
                    case "fnaremail":
                        dt.Columns[c].ColumnName = "电子邮箱地址";
                        break;
                    case "fnaraddress":
                        dt.Columns[c].ColumnName = "地址";
                        break;
                    case "fnarpostalcode":
                        dt.Columns[c].ColumnName = "邮政编码";
                        break;
                    case "fbitExport":
                        dt.Columns[c].ColumnName = "是否上传";
                        break;
                    case "fchrVIPCusDefine1":
                        dt.Columns[c].ColumnName = "单位名称";
                        break;
                    case "fchrVIPCusDefine2":
                        dt.Columns[c].ColumnName = "职称";
                        break;
                    case "fchrVIPCusDefine3":
                        dt.Columns[c].ColumnName = "年龄";
                        break;
                    case "fchrVIPCusDefine4":
                        dt.Columns[c].ColumnName = "学历";
                        break;
                    case "fchrVIPCusDefine5":
                        dt.Columns[c].ColumnName = "平均月收入";
                        break;
                    case "fchrVIPCusDefine6":
                        dt.Columns[c].ColumnName = "从事行业";
                        break;
                    case "fchrVIPCusDefine7":
                        dt.Columns[c].ColumnName = "职位";
                        break;
                    //case "fintMinusTotal":
                    //    dt.Columns[c].ColumnName = "兑付积分";
                    //    break;
                    //case "fintReturnTotal":
                    //    dt.Columns[c].ColumnName = "退货积分";
                    //    break;
                    //case "flotInitialTotal":
                    //    dt.Columns[c].ColumnName = "职位";
                    //    break;
                    //case "fintTotal":
                    //    dt.Columns[c].ColumnName = "职位";
                    //    break;
                    //case "fchrVIPCusDefine8":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine9":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine10":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine11":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine12":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine13":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine14":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine15":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine16":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine17":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine18":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine19":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine20":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine21":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine22":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine23":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine24":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine25":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    //case "fchrVIPCusDefine26":
                    //    dt.Columns[c].ColumnName = "";
                    //    break;
                    case "fchrEmployee":
                        dt.Columns[c].ColumnName = "营业员";
                        break;
                    case "fchrStoreid":
                        dt.Columns[c].ColumnName = "门店ID";
                        break;
                    case "fintBirthdayYear":
                        dt.Columns[c].ColumnName = "出生年";
                        break;
                    case "fintBirthdayMonth":
                        dt.Columns[c].ColumnName = "出生月";
                        break;
                    case "fintBirthdayDay":
                        dt.Columns[c].ColumnName = "出生日";
                        break;
                    case "flotPointBalance":
                        dt.Columns[c].ColumnName = "剩余积分";
                        break;
                    case "fchrVIPCardClassName":
                        dt.Columns[c].ColumnName = "VIP客户级别";
                        break;
                    case "fchrVIPCardClassID":
                        dt.Columns[c].ColumnName = "VIP客户级别ID";
                        break;
                    case "fchrVipCode":
                        dt.Columns[c].ColumnName = "VIP卡号";
                        break;
                    case "fnarconsumercode":
                        dt.Columns[c].ColumnName = "VIP客户编码";
                        break;
                    case "fintTotalPoints":
                        dt.Columns[c].ColumnName = "累计积分";
                        break;
                    case "fbitVerify_DQ":
                        dt.Columns[c].ColumnName = "地区是否审核";
                        break;
                    case "fbitCheck":
                        dt.Columns[c].ColumnName = "总部是否审核";
                        break;
                    case "fbitPromoteAudit":
                        dt.Columns[c].ColumnName = "晋级是否审核";
                        break;
                }
                dt.AcceptChanges();
            }
        }

        ///// <summary>
        ///// 删除没用的列
        ///// </summary>
        ///// <param name="dt"></param>
        //private void DelNoUseColumns(ref DataTable dt)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int c = dt.Columns.Count - 1; c >=0; c--)
        //        {
        //            if (dt.Columns[c].ColumnName.Contains("ID") || dt.Columns[c].ColumnName.StartsWith("fchrVIPCusDefine"))
        //            {
        //                dt.Columns.RemoveAt(c);
        //                continue;
        //            }
        //        }
        //    }
        //}

//        /// <summary>
//        /// 获取商品信息列表
//        /// </summary>
//        /// <param name="PageSize"></param>
//        /// <param name="CurPages"></param>
//        /// <param name="rel"></param>
//        /// <returns></returns>
//        public DataTable GetItemList(string SqlString,int PageSize,int CurPages,string rel,ref int TotalRows)
//        {
//            string sql = string.Empty;
//            DataTable dt = new DataTable();
//            if (string.IsNullOrEmpty(rel))
//                rel = " 1=1 ";
//            sql = string.Format(@"with i as
//                                (
//                                {3} and {2}
//                                )
//                                SELECT TOP {0} *
//                                FROM i
//                                WHERE id >
//                                           (
//                                           SELECT ISNULL(MAX(id),0) 
//                                          FROM 
//                                                 (
//                                                 SELECT TOP ({0}*({1}-1)) id FROM i ORDER BY id
//                                                 ) A
//                                           )
//                                ORDER BY id;select Count(*) as TotalPages
//                                from ({3} and {2}) as RowsCount", PageSize, CurPages, rel,SqlString);
//            dt = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql).Tables[0];
//            TotalRows = Convert.ToInt32(SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql).Tables[1].Rows[0][0]);

//            if (dt.Rows.Count > 0)
//            {
//                dt.Columns.Remove("ID");
//                dt.AcceptChanges();
//            }

//            return dt;
//        }

        /// <summary>
        /// 获取商品信息列表(改为SQL Server 2000兼容语法)
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="CurPages"></param>
        /// <param name="rel"></param>
        /// <returns></returns>
        public DataTable GetItemList(string SqlString,string TableName, int PageSize, int CurPages, string rel, string OrderByField, ref int TotalRows)
        {
            TotalRows = 0;
            string sql = string.Empty;
            DataTable dt = new DataTable();
            if (string.IsNullOrEmpty(rel))
                rel = " 1=1 ";

            TableName = string.Format("({0} and {1}) as TmpTlb", TableName, rel);
            TotalRows = Convert.ToInt32(SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, SqlString));

            SqlParameter[] param = { 
                                      new SqlParameter("@Table_Name",TableName),  //表名
                                      new SqlParameter("@Sign_Record",OrderByField),  //主键
                                      new SqlParameter("@Filter_Condition",""), //筛选条件,不带where
                                      new SqlParameter("@Page_Size",PageSize), //页大小
                                      new SqlParameter("@Page_Index",CurPages), //页索引
                                      new SqlParameter("@TaxisField",OrderByField), //排序字段
                                      new SqlParameter("@Taxis_Sign",0),  //排序方式 1为 DESC, 0为 ASC
                                      new SqlParameter("@Find_RecordList",""), //查找的字段
                                      new SqlParameter("@Record_Count",TotalRows) //总记录数
                                   };

            dt = SqlAccess.ExecuteDataset(SysPara.ConnectionString, "ProcCustomPage", param).Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    dt.Columns.Remove("ID");
            //    dt.AcceptChanges();
            //}

            return dt;
        }

        /// <summary>
        /// 获取指定的值
        /// </summary>
        /// <param name="ReturnFiledName"></param>
        /// <param name="TableName"></param>
        /// <param name="KeyFieldName"></param>
        /// <param name="KeyFieldValue"></param>
        /// <returns></returns>
        public static string GetDatas(string ReturnFiledName,string TableName,string KeyFieldName,string KeyFieldValue)
        {
            string sql = string.Empty;
            string returnValue = "";
            sql = string.Format(@"select top 1 {0} from {1} where {2} = '{3}'", ReturnFiledName, TableName, KeyFieldName, KeyFieldValue);
            using (SqlDataReader sdr = SqlAccess.ExecuteReader(SysPara.ConnectionString, CommandType.Text, sql) as SqlDataReader)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        returnValue = sdr[ReturnFiledName].ToString();
                    }
                }
            }

            return returnValue;
        }

        /// <summary>
        /// 获取表体明细数据临时表
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public DataTable GetDetailTable(C1.Win.C1FlexGrid.C1FlexGrid dgv)
        {
            DataTable DetailTab = new DataTable();
            DataRow dr;
            //创建明细临时表
            DetailTab.Columns.Add("fchrItemID", typeof(string));
            DetailTab.Columns.Add("fchrItemCode", typeof(string));
            DetailTab.Columns.Add("fchrItemName", typeof(string));
            DetailTab.Columns.Add("fchrFree1", typeof(string));
            DetailTab.Columns.Add("fchrFree2", typeof(string));
            DetailTab.Columns.Add("fchrUnitName", typeof(string));
            DetailTab.Columns.Add("flotQuantity", typeof(float));
            DetailTab.Columns.Add("flotUseQuantity", typeof(float));
            DetailTab.Columns.Add("fchrBodyMemo", typeof(string));

            if (dgv.Rows.Count > 1)
            {
                for (int r = 1; r < dgv.Rows.Count; r++)
                {
                    dr = DetailTab.NewRow();
                    dr["fchrItemID"] = GetDatas("fchrItemID", "Item", "fchrItemCode", dgv.Rows[r]["fchrItemCode"].ToString());
                    dr["fchrItemCode"] = dgv.Rows[r]["fchrItemCode"].ToString();
                    dr["fchrItemName"] = dgv.Rows[r]["fchrItemName"].ToString();
                    dr["fchrFree1"] = dgv.Rows[r]["fchrFree1"] != null ? dgv.Rows[r]["fchrFree1"].ToString() : "";
                    dr["fchrFree2"] = dgv.Rows[r]["fchrFree2"] != null ? dgv.Rows[r]["fchrFree2"].ToString() : "";
                    dr["fchrUnitName"] = dgv.Rows[r]["fchrUnitName"].ToString();
                    dr["flotQuantity"] = dgv.Rows[r]["flotQuantity"].ToString();
                    dr["fchrBodyMemo"] = dgv.Rows[r]["fchrBodyMemo"] != null ? dgv.Rows[r]["fchrBodyMemo"].ToString() : "";
                    DetailTab.Rows.Add(dr);
                    DetailTab.AcceptChanges();
                }
            }

            return DetailTab;
        }

        /// <summary>
        /// 向单据明细添加扫描数据行
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="dr"></param>
        public void AddScanDataRow(C1.Win.C1FlexGrid.C1FlexGrid dgv,DataRow dr)
        {
            int RowIndex = 0;
            bool IsExits = false;
            if (dgv.Rows.Count > 1)
            {
                for (int r = 1; r < dgv.Rows.Count; r++)
                {
                    if (dgv.Rows[r]["fchrItemCode"].ToString() == dr["fchrItemCode"].ToString() && (dgv.Rows[r]["fchrFree1"] != null ? dgv.Rows[r]["fchrFree1"].ToString() : "") == dr["fchrFree1"].ToString())
                    {
                        RowIndex = r;
                        IsExits = true;
                        break;
                    }
                }

                if (IsExits)
                {
                    dgv.Rows[RowIndex]["fchrItemCode"] = dr["fchrItemCode"].ToString();
                    dgv.Rows[RowIndex]["fchrItemName"] = GetDatas("fchrItemName", "Item", "fchrItemCode", dr["fchrItemCode"].ToString());
                    dgv.Rows[RowIndex]["fchrFree1"] = dr["fchrFree1"].ToString();
                    dgv.Rows[RowIndex]["fchrFree2"] = dr["fchrFree2"].ToString();
                    if (dgv.Cols.Contains("flotCurStock"))
                        dgv.Rows[RowIndex]["flotCurStock"] = dr["flotUseQuantity"].ToString();
                    dgv.Rows[RowIndex]["fchrUnitName"] = GetDatas("fchrUnitName", "Item", "fchrItemCode", dr["fchrItemCode"].ToString());
                    dgv.Rows[RowIndex]["flotQuantity"] = dr["flotQuantity"].ToString();
                }
                else
                {
                    dgv.Rows.Add();
                    dgv.Rows[dgv.Rows.Count - 1]["fchrItemCode"] = dr["fchrItemCode"].ToString();
                    dgv.Rows[dgv.Rows.Count - 1]["fchrItemName"] = GetDatas("fchrItemName", "Item", "fchrItemCode", dr["fchrItemCode"].ToString());
                    dgv.Rows[dgv.Rows.Count - 1]["fchrFree1"] = dr["fchrFree1"].ToString();
                    dgv.Rows[dgv.Rows.Count - 1]["fchrFree2"] = dr["fchrFree2"].ToString();
                    if (dgv.Cols.Contains("flotCurStock"))
                        dgv.Rows[dgv.Rows.Count - 1]["flotCurStock"] = dr["flotUseQuantity"].ToString();
                    dgv.Rows[dgv.Rows.Count - 1]["fchrUnitName"] = GetDatas("fchrUnitName", "Item", "fchrItemCode", dr["fchrItemCode"].ToString());
                    dgv.Rows[dgv.Rows.Count - 1]["flotQuantity"] = dr["flotQuantity"].ToString();
                }
            }
            else
            {
                dgv.Rows.Add();
                dgv.Rows[dgv.Rows.Count - 1]["fchrItemCode"] = dr["fchrItemCode"].ToString();
                dgv.Rows[dgv.Rows.Count - 1]["fchrItemName"] = GetDatas("fchrItemName", "Item", "fchrItemCode", dr["fchrItemCode"].ToString());
                dgv.Rows[dgv.Rows.Count - 1]["fchrFree1"] = dr["fchrFree1"].ToString();
                dgv.Rows[dgv.Rows.Count - 1]["fchrFree2"] = dr["fchrFree2"].ToString();
                dgv.Rows[dgv.Rows.Count - 1]["fchrUnitName"] = GetDatas("fchrUnitName","Item","fchrItemCode",dr["fchrItemCode"].ToString());
                dgv.Rows[dgv.Rows.Count - 1]["flotQuantity"] = dr["flotQuantity"].ToString();
                if (dgv.Cols.Contains("flotCurStock"))
                   dgv.Rows[dgv.Rows.Count - 1]["flotCurStock"] = dr["flotUseQuantity"].ToString();
            }
        }

        /// <summary>
        /// 获取指定物理表的表结构
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static DataTable GetDateTableSchema(string TableName)
        {
            string sql = string.Empty;
            sql = string.Format(@"select * from {0} where 1=2", TableName);
            return SqlAccess.ExecuteDataTable(SysPara.ConnectionString, sql);
        }

        /// <summary>
        /// 使用SqlBulkCopy将DataTable中的数据批量插入数据库中
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="dtData"></param>
        /// <param name="ConnStr"></param>
        public static void SqlBulkCopyInsert(string strTableName, DataTable dtData, string ConnStr,ref string ErrMsg)
        {
            //BCP copy  
            ErrMsg = "";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConnStr;
            conn.Open();

            SqlTransaction sqlbulkTransaction = conn.BeginTransaction();

            //请在插入数据的同时检查约束，如果发生错误调用sqlbulkTransaction事务  
            SqlBulkCopy copy = new SqlBulkCopy(conn, SqlBulkCopyOptions.CheckConstraints, sqlbulkTransaction);

            copy.DestinationTableName = strTableName;
            foreach (DataColumn dc in dtData.Columns)
            {
                copy.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
            }
            try
            {
                copy.WriteToServer(dtData);
                sqlbulkTransaction.Commit();
            }
            catch (Exception ex)
            {
                sqlbulkTransaction.Rollback();
                //Console.WriteLine(ex.ToString());
                ErrMsg = ex.Message;
            }
            finally
            {
                copy.Close();
                conn.Close();
            }
        }

        /// <summary>
        /// 生成新的物流结算单号
        /// </summary>
        /// <returns></returns>
        public static string GenNewVouchCode(string Prefiex, string TableName, string VouchCodeField)
        {
            string NewCode = "";
            SqlParameter[] param = { 
                                      new SqlParameter("@TableName",TableName),
                                      new SqlParameter("@cVouchCodeField",VouchCodeField),
                                      new SqlParameter("@Prefix",Prefiex + DateTime.Now.ToString("yyMMdd")),
                                      new SqlParameter("@NewCode",SqlDbType.VarChar,50)
                                   };
            param[3].Direction = ParameterDirection.Output;
            SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.StoredProcedure, "SL_proc_GenNewVouchCode", param);
            if (param[3].Value != null)
            {
                //NewCode = "WL" + param[1].Value.ToString();
                NewCode = param[3].Value.ToString();
            }
            return NewCode;
        }

        /// <summary>
        /// 刷新数据-借出单/归还单
        /// </summary>
        /// <param name="fchrItemID"></param>
        public void DataRefresh(string fchrItemID, string VouchType, C1.Win.C1FlexGrid.C1FlexGrid dgv, string GetRealtion)
        {
            DataTable dtResult = new DataTable();
            SqlParameter[] paras = { 
                                      new SqlParameter("@fchrItemID",fchrItemID),
                                      new SqlParameter("@fchrVouchType",VouchType),
                                      new SqlParameter("@filterString",GetRealtion)
                                   };
            dtResult = SqlAccess.ExecuteDataset(SysPara.ConnectionString, "sl_proc_GetLoanReturnVouchList", paras).Tables[0];

            if (dtResult.Rows.Count > 0)
            {
                dgv.DataSource = dtResult;
            }
            else
            {
                if (dgv.Rows.Count > 1)
                {
                    for (int r = dgv.Rows.Count - 1; r > 0; r--)
                    {
                        dgv.Rows.Remove(r);
                    }
                }
                else
                {
                    RetailMessageBox.ShowInformation("未找到任何数据！");
                    return;
                }
            }

            if(dgv.Cols.Contains("备注"))
               dgv.Cols["备注"].Width = 250;
        }

        /// <summary>
        /// 刷新数据-展厅客户档案
        /// </summary>
        /// <param name="rel"></param>
        public void DataRefresh(C1.Win.C1FlexGrid.C1FlexGrid dgvForm, string rel)
        {
            DataTable dtResult = new DataTable();
            if (!string.IsNullOrEmpty(rel))
                rel = " And " + rel;

            string sql = string.Format(@"select ID as ID, fchrCusCode as '客户编码',fchrCusName as '客户名称',fchrMobileNum as '手机号码',fchrPhoneNum as '固定电话',fchrFax as '传真',fchrWorkPlace as '工作单位',fchrAddress as '联系地址',fchrCreatePerson as '创建人',fdtmAddTime as '创建日期',isnull(fbitExport,0) as '是否上传'
                                         from sl_ZT_Customer
                                         where 1=1 {0} order by fdtmAddTime desc", rel);

            if (dgvForm.Rows.Count > 1)
            {
                //dgvForm.Rows.RemoveRange(1, dgvForm.Rows.Count - 1);
                //dgvForm.Clear(C1.Win.C1FlexGrid.ClearFlags.All);
                for (int r = dgvForm.Rows.Count - 1; r > 0 ; r--)
                {
                    dgvForm.Rows.Remove(r);
                }
            }

            dtResult = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, sql);
            if (dtResult.Rows.Count > 0)
            {
                dgvForm.DataSource = dtResult;
                dgvForm.Cols["是否上传"].DataType = typeof(bool);
            }
            else
            {
                //RetailMessageBox.ShowInformation("没有查询到任何数据！");
                return;
            }

            dgvForm.Cols["ID"].Visible = false;
            //dgvForm.Cols["创建日期"].Visible = false;
            dgvForm.AutoSizeCols();

            dgvForm.Cols[0].Width = 10;
        }

        /// <summary>
        /// 获取单据表头及表体数据
        /// </summary>
        /// <param name="cVouchCode"></param>
        /// <param name="cVouchType"></param>
        /// <returns></returns>
        public DataSet GetVouchDataInfo(string cVouchCode,string cVouchType)
        {
            DataSet ds = new DataSet();
            string sql = string.Empty;
            sql = string.Format(@"select * from sl_t_RdVouchMain where fchrCode = '{0}' and fchrVouchType = '{1}';
                                  select * from sl_t_RdVouchDetail where MainID in(select top 1 MainID from sl_t_RdVouchMain where fchrCode = '{0}' and fchrVouchType = '{1}')", cVouchCode, cVouchType);
            ds = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql);
            return ds;
        }

        /// <summary>
        /// 更新现存量
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cVouchType"></param>
        public void UpdateCurStock(DataTable dt,string cVouchType)
        {
            string sql = string.Empty;
            if (dt.Rows.Count > 0)
            {
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    if (cVouchType == "JC")
                        sql = string.Format(@"update dbo.ItemStocks set flotQuantity = flotQuantity - {0},fdtmUpdateTime = Convert(varchar(50),getdate(),121) where fchrItemID = '{1}' and isnull(fchrFree1,'') = '{2}'", Convert.ToDouble(dt.Rows[r]["flotQuantity"]), dt.Rows[r]["fchrItemID"].ToString(), dt.Rows[r]["fchrFree1"].ToString());
                    else if (cVouchType == "GH")
                        sql = string.Format(@"update dbo.ItemStocks set flotQuantity = flotQuantity + {0},fdtmUpdateTime = Convert(varchar(50),getdate(),121) where fchrItemID = '{1}' and isnull(fchrFree1,'') = '{2}'", Convert.ToDouble(dt.Rows[r]["flotQuantity"]), dt.Rows[r]["fchrItemID"].ToString(), dt.Rows[r]["fchrFree1"].ToString());
                    SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, sql);
                }
            }
        }

        /// <summary>
        /// 销售类别参照选择窗口
        /// </summary>
        public void SaleTypeRefForm()
        {
            if (ItemData.Sl_ZT_ZTSaleVouchFlag == "冲单" || ItemData.Sl_ZT_ZTSaleVouchFlag == "补单")
            {
                RetailMessageBox.ShowInformation("冲单或补单状态下不允许修改销售类别！");
                return;
            }

            string sql = string.Empty;
            string sqlTlbName = string.Empty;

//            sql = string.Format(@"select 0 as sel,fchrSaleTypeCode as '销售类型编码',fchrSaleTypeName as '销售类型名称',ROW_NUMBER() over(order by fchrSaleTypeCode) as ID
//                                  from SL_ZT_SaleType where 1=1SL_ZT_SaleType
//            sql = string.Format(@"SELECT 100 percent 0 as sel,fchrSaleTypeCode as '销售类型编码',fchrSaleTypeName as '销售类型名称',(select count(1) from SL_ZT_SaleType where Convert(int,fchrSaleTypeCode) <=Convert(int,t.fchrSaleTypeCode)) AS ID FROM  
//                                  SL_ZT_SaleType t where 1=1 ");

            sqlTlbName = string.Format(@"SELECT 0 as sel,fchrSaleTypeCode as '销售类型编码',fchrSaleTypeName as '销售类型名称'
                                              FROM SL_ZT_SaleType where 1=1");

            sql = string.Format(@"SELECT Count(1) FROM SL_ZT_SaleType where 1=1");

            //if (!string.IsNullOrEmpty(TxtValue)) sql += string.Format(@" and fchrSaleTypeCode like '{0}' or fchrSaleTypeName like '%{0}%'", TxtValue);
            frmRefForm Ref = new frmRefForm("销售类别", "销售类别", sql, "fchrSaleTypeCode,fchrSaleTypeName", sqlTlbName, "销售类型编码");
            if (Ref.ShowDialog() == DialogResult.OK)
            {
                //先删除整个销售类别节点部分
                DeleteSection("SaleType", @".\SL_ZT_RefInfo.ini");
                //写入销售类别节点部分键值
                WritePrivateProfileString("SaleType", "SaleTypeText", Ref.CRefTxt, @".\SL_ZT_RefInfo.ini");
                WritePrivateProfileString("SaleType", "SaleTypeValue", Ref.CRefValue, @".\SL_ZT_RefInfo.ini");
            }
        }

        /// <summary>
        /// 销售方式参照选择窗口
        /// </summary>
        public void SaleStyleRefForm()
        {
            if (ItemData.Sl_ZT_ZTSaleVouchFlag == "冲单" || ItemData.Sl_ZT_ZTSaleVouchFlag == "补单")
            {
                RetailMessageBox.ShowInformation("冲单或补单状态下不允许修改销售方式！");
                return;
            }

            string sql = string.Empty;
            string sqlTlbName = string.Empty;
//            sql = string.Format(@"select 0 as sel,fchrSaleStyleCode as '销售方式编码',fchrSaleStyleName as '销售方式名称',ROW_NUMBER() over(order by fchrSaleStyleCode) as ID
//                                  from SL_ZT_SaleStyle where 1=1");
//            sql = string.Format(@"SELECT 0 as sel,fchrSaleStyleCode as '销售方式编码',fchrSaleStyleName as '销售方式名称',(select count(1) from SL_ZT_SaleStyle where Convert(int,fchrSaleStyleCode) <=Convert(int,t.fchrSaleStyleCode)) AS ID FROM  
//                                  SL_ZT_SaleStyle t where 1=1 ");

            sqlTlbName = string.Format(@"SELECT 0 as sel,fchrSaleStyleCode as '销售方式编码',fchrSaleStyleName as '销售方式名称'
                                              FROM SL_ZT_SaleStyle where 1=1");

            sql = string.Format(@"SELECT Count(1) FROM SL_ZT_SaleStyle where 1=1");

            //if (!string.IsNullOrEmpty(TxtValue)) sql += string.Format(@" and fchrSaleStyleCode like '{0}' or fchrSaleStyleName like '%{0}%'", TxtValue);
            frmRefForm Ref = new frmRefForm("销售方式", "销售方式", sql, "fchrSaleStyleCode,fchrSaleStyleName", sqlTlbName, "销售方式编码");
            if (Ref.ShowDialog() == DialogResult.OK)
            {
                //先删除整个销售方式节点部分
                DeleteSection("SaleStyle", @".\SL_ZT_RefInfo.ini");
                //写入销售方式节点部分键值
                WritePrivateProfileString("SaleStyle", "SaleStyleText", Ref.CRefTxt, @".\SL_ZT_RefInfo.ini");
                WritePrivateProfileString("SaleStyle", "SaleStyleValue", Ref.CRefValue, @".\SL_ZT_RefInfo.ini");
            }
        }

        /// <summary>
        /// 自动调整列宽
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="cVouchType"></param>
        public void AutoSizeDgvCols(C1.Win.C1FlexGrid.C1FlexGrid dgv,string cVouchType)
        {
            dgv.Cols["fchrItemCode"].Width = 100;
            dgv.Cols["fchrItemName"].Width = 100;
            dgv.Cols["fchrBodyMemo"].Width = 500;
            dgv.AutoSizeCol(dgv.Cols["fchrFree1"].Index);
            dgv.AutoSizeCol(dgv.Cols["fchrFree2"].Index);
            dgv.AutoSizeCol(dgv.Cols["fchrUnitName"].Index);
            dgv.AutoSizeCol(dgv.Cols["flotQuantity"].Index);

            if (cVouchType == "JC")
            {
                dgv.AutoSizeCol(dgv.Cols["flotReturnQty"].Index);
                dgv.AutoSizeCol(dgv.Cols["flotCurStock"].Index);
            }
        }

        /// <summary>
        /// 获取指定借出单行的已归还数量
        /// </summary>
        /// <param name="fchrSourceCode"></param>
        /// <param name="fchrItemCode"></param>
        /// <param name="fchrFree1"></param>
        /// <returns></returns>
        public string GetReturnQtySum(string fchrSourceCode,string fchrItemCode,string fchrFree1)
        {
            string sql = string.Empty;
            string returnValue = string.Empty;
            sql = string.Format(@"select Sum(isnull(flotQuantity,0)) as flotReturnQty from sl_t_RdVouchMain m
                                  left join sl_t_RdVouchDetail d on m.Mainid = d.Mainid
                                  where fchrVouchType = 'GH' and isnull(fbitTempSave,0) = 0 and fchrSourceCode = '{0}' and fchrItemCode = '{1}'", fchrSourceCode, fchrItemCode);
            if (!string.IsNullOrEmpty(fchrFree1))
                sql += string.Format(" and isnull(fchrFree1,'') = '{0}'", fchrFree1);
            using (SqlDataReader sdr = SqlAccess.ExecuteReader(SysPara.ConnectionString, CommandType.Text, sql) as SqlDataReader)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        returnValue = sdr["flotReturnQty"].ToString();
                    }
                }
            }

            return returnValue;
        }

        /// <summary>
        /// 获取指定借出单行的暂存归还单数量
        /// </summary>
        /// <param name="fchrSourceCode"></param>
        /// <param name="fchrItemCode"></param>
        /// <param name="fchrFree1"></param>
        /// <returns></returns>
        public string GetTmpQtySum(string fchrSourceCode, string fchrItemCode, string fchrFree1,string fchrCurCode)
        {
            string sql = string.Empty;
            string returnValue = string.Empty;
            sql = string.Format(@"select isnull(Sum(isnull(flotQuantity,0)),0) as flotTmpQty from sl_t_RdVouchMain m
                                  left join sl_t_RdVouchDetail d on m.Mainid = d.Mainid
                                  where fchrVouchType = 'GH' and isnull(fbitTempSave,0) = 1 and fchrSourceCode = '{0}' and fchrItemCode = '{1}' and fchrCode <> '{2}'", fchrSourceCode, fchrItemCode, fchrCurCode);
            if (!string.IsNullOrEmpty(fchrFree1))
                sql += string.Format(" and isnull(fchrFree1,'') = '{0}'", fchrFree1);
            using (SqlDataReader sdr = SqlAccess.ExecuteReader(SysPara.ConnectionString, CommandType.Text, sql) as SqlDataReader)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        returnValue = sdr["flotTmpQty"].ToString();
                    }
                }
            }

            return returnValue;
        }

        /// <summary>
        /// 获取指定归还单行对应指定的借出单号的可归还数量
        /// </summary>
        /// <param name="fchrSourceCode"></param>
        /// <param name="fchrItemCode"></param>
        /// <param name="fchrFree1"></param>
        /// <returns></returns>
        public string GetAvaReturnQty(string fchrSourceCode, string fchrItemCode, string fchrFree1,string flotQuantity,string fchrCurCode)
        {
            string sql = string.Empty;
            string returnValue = string.Empty;
            string ReturnQtySum = string.Empty;
            string TmpQtySum = string.Empty;

            ReturnQtySum = GetReturnQtySum(fchrSourceCode, fchrItemCode, fchrFree1) == "" ? "0" : GetReturnQtySum(fchrSourceCode, fchrItemCode, fchrFree1);
            TmpQtySum = GetTmpQtySum(fchrSourceCode, fchrItemCode, fchrFree1, fchrCurCode) == "" ? "0" : GetTmpQtySum(fchrSourceCode, fchrItemCode, fchrFree1, fchrCurCode);

            if (!string.IsNullOrEmpty(flotQuantity))
            {
                returnValue = Convert.ToString(Convert.ToInt32(flotQuantity) - (Convert.ToInt32(ReturnQtySum) + Convert.ToInt32(TmpQtySum)));
            }

            if (string.IsNullOrEmpty(returnValue)) returnValue = "0";

            return returnValue;
        }

        /// <summary>
        /// 归还单保存前检查
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="fchrSourceCode"></param>
        /// <param name="ErrMsg"></param>
        /// <returns></returns>
        public bool ReturnVouchBeforeSaveCheck(C1.Win.C1FlexGrid.C1FlexGrid dgv,string fchrSourceCode,string fchrCurCode,ref string ErrMsg)
        {
            string flotLoanQty = string.Empty;
            bool bFlag = true;
            ErrMsg = "";
            if (!string.IsNullOrEmpty(fchrSourceCode))
            {
                if (dgv.Rows.Count > 1)
                {
                    for (int r = 1; r < dgv.Rows.Count; r++)
                    {
                        if (CheckItemCodoIsExistsInLoanVouch(fchrSourceCode, dgv.Rows[r]["fchrItemCode"].ToString(), dgv.Rows[r]["fchrFree1"] == null ? "" : dgv.Rows[r]["fchrFree1"].ToString()))
                        {
                            flotLoanQty = GetLoanQtyWithItemInfo(fchrSourceCode, dgv.Rows[r]["fchrItemCode"].ToString(), dgv.Rows[r]["fchrFree1"] == null ? "" : dgv.Rows[r]["fchrFree1"].ToString()).ToString();
                            if (Convert.ToInt32(dgv.Rows[r]["flotQuantity"] == null ? "0" : dgv.Rows[r]["flotQuantity"]) > Convert.ToInt32(GetAvaReturnQty(fchrSourceCode, dgv.Rows[r]["fchrItemCode"].ToString(), dgv.Rows[r]["fchrFree1"] == null ? "" : dgv.Rows[r]["fchrFree1"].ToString(), flotLoanQty, fchrCurCode)))
                            {
                                ErrMsg += string.Format(@"第{0}行记录，货号【{1}】/尺码【{2}】的归还数量大于可归还数量！" + "\r\n", r.ToString(), dgv.Rows[r]["fchrItemCode"].ToString(), dgv.Rows[r]["fchrFree1"] == null ? "" : dgv.Rows[r]["fchrFree1"].ToString());
                            }
                            else
                                continue;
                        }
                        else
                        {
                            ErrMsg += string.Format(@"第{0}行记录，货号【{1}】/尺码【{2}】不存在对应的借出单记录！" + "\r\n", r.ToString(), dgv.Rows[r]["fchrItemCode"].ToString(), dgv.Rows[r]["fchrFree1"] == null ? "" : dgv.Rows[r]["fchrFree1"].ToString());
                        }
                    }
                }
            }

            if (ErrMsg != "") bFlag = false;
            return bFlag;
        }

        /// <summary>
        /// 获取指定单据编号及商品信息的借出单行数量
        /// </summary>
        /// <param name="fchrSourceCode"></param>
        /// <param name="fchrItemCode"></param>
        /// <param name="fchrFree1"></param>
        /// <returns></returns>
        private int GetLoanQtyWithItemInfo(string fchrSourceCode, string fchrItemCode, string fchrFree1)
        {
            string returnvalue = string.Empty;
            string sql = string.Empty;
            sql = string.Format(@"select Sum(flotQuantity) as flotQuantity from sl_t_RdVouchMain m 
                                  left join sl_t_RdVouchDetail d on m.MainId = d.MainId where fchrVouchType = 'JC' and fchrItemCode = '{0}' and isnull(fchrFree1,'') = '{1}' and fchrCode = '{2}'", fchrItemCode, fchrFree1, fchrSourceCode);
            using (SqlDataReader sdr = SqlAccess.ExecuteReader(SysPara.ConnectionString, CommandType.Text, sql) as SqlDataReader)
            {
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        returnvalue = sdr["flotQuantity"].ToString();
                    }
                }
            }

            if (string.IsNullOrEmpty(returnvalue)) returnvalue = "0";
            return Convert.ToInt32(returnvalue);
        }

        /// <summary>
        /// 检查归还单明细行中指定的货号和尺码在对应的借出单中是否存在
        /// </summary>
        /// <param name="fchrSourceCode"></param>
        /// <param name="fchrItemCode"></param>
        /// <param name="fchrFree1"></param>
        /// <returns></returns>
        private bool CheckItemCodoIsExistsInLoanVouch(string fchrSourceCode, string fchrItemCode, string fchrFree1)
        {
            bool bFlag = true;
            string sql = string.Empty;
            sql = string.Format(@"select Count(1) from sl_t_RdVouchMain m 
                                  left join sl_t_RdVouchDetail d on m.MainId = d.MainId where fchrVouchType = 'JC' and fchrItemCode = '{0}' and isnull(fchrFree1,'') = '{1}' and fchrCode = '{2}'", fchrItemCode, fchrFree1, fchrSourceCode);
            if (Convert.ToInt32(SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sql)) <= 0)
            {
                bFlag = false;
            }

            return bFlag;
        }

        public void TwodimensionPrintOutForIn(object sender, ExternalMethodCallArgs args)
        { 
          HandleEvent handleEvent = args.HandleEvent;
            Init initFormClass = handleEvent.InitFormClass;
            string fchrVouchID = string.Empty;
            string fchrCode = string.Empty;
            int printId = 0;
            object obj = null;
            string StrSQL = "";
            string VipCode = "";
            try
            {
                DataSet dataSource = initFormClass.DGrid.DataSource as DataSet;
                fchrVouchID = HandleEventHelper.GetControlValues(HandleEvent.FindControl("fchrInOutVouchID", initFormClass.MainForm), "ExLabel");
                fchrCode = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, string.Format(@"select top 1 fchrCode from inoutvouch where fchrinoutvouchid = '{0}'", fchrVouchID)).ToString();
                if (!string.IsNullOrEmpty(fchrCode))
                {
                    string sql = string.Format("select printID from sl_PrintRight where cUserId='{0}' and cVouchType = '店存入库单'", SysPara.GetString("操作员ID"));
                    obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sql);
                    if (obj != null)
                    {
                        printId = Convert.ToInt32(obj);
                    }
                    else
                    {
                        RetailMessageBox.ShowInformation("首次使用请先设置纸张！");
                        return;
                    }

                    frmPrint print = new frmPrint(fchrCode, "店存入库单", SysPara.ConnectionString, printId, SysPara.GetString("操作员ID"));
                    print.ShowDialog();
                }
                else
                {
                    RetailMessageBox.ShowInformation("单据号获取失败！");
                    return;
                }
            }
            catch (Exception ex) {
                RetailMessageBox.ShowWarning(ex.Message);
            }
        }

        public void PrintPageSetupForIn(object sender, ExternalMethodCallArgs args)
        {
            frmPrintType frm = new frmPrintType(SysPara.ConnectionString, SysPara.GetString("操作员ID"), "店存入库单");
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RetailMessageBox.ShowInformation("打印设置成功！");
                //frmPrint frm1 = new frmPrint(cCode, cCodeType, conStr, printTemplateType, frm.PrintID, SysPara.GetString("操作员ID"));
                //frm1.ShowDialog();
            }
        }

        public void TwodimensionPrintOutForOut(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent handleEvent = args.HandleEvent;
            Init initFormClass = handleEvent.InitFormClass;
            string fchrVouchID = string.Empty;
            string fchrCode = string.Empty;
            int printId = 0;
            object obj = null;
            string StrSQL = "";
            string VipCode = "";
            try
            {
                DataSet dataSource = initFormClass.DGrid.DataSource as DataSet;
                fchrVouchID = HandleEventHelper.GetControlValues(HandleEvent.FindControl("fchrInOutVouchID", initFormClass.MainForm), "ExLabel");
                fchrCode = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, string.Format(@"select top 1 fchrCode from inoutvouch where fchrinoutvouchid = '{0}'", fchrVouchID)).ToString();
                if (!string.IsNullOrEmpty(fchrCode))
                {
                    string sql = string.Format("select printID from sl_PrintRight where cUserId='{0}' and cVouchType = '店存出库单'", SysPara.GetString("操作员ID"));
                    obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sql);
                    if (obj != null)
                    {
                        printId = Convert.ToInt32(obj);
                    }
                    else
                    {
                        RetailMessageBox.ShowInformation("首次使用请先设置纸张！");
                        return;
                    }

                    frmPrint print = new frmPrint(fchrCode, "店存出库单", SysPara.ConnectionString, printId, SysPara.GetString("操作员ID"));
                    print.ShowDialog();
                }
                else
                {
                    RetailMessageBox.ShowInformation("单据号获取失败！");
                    return;
                }
            }
            catch (Exception ex)
            {
                RetailMessageBox.ShowWarning(ex.Message);
            }
        }

        public void PrintPageSetupForOut(object sender, ExternalMethodCallArgs args)
        {
            frmPrintType frm = new frmPrintType(SysPara.ConnectionString, SysPara.GetString("操作员ID"), "店存出库单");
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RetailMessageBox.ShowInformation("打印设置成功！");
                //frmPrint frm1 = new frmPrint(cCode, cCodeType, conStr, printTemplateType, frm.PrintID, SysPara.GetString("操作员ID"));
                //frm1.ShowDialog();
            }
        }

        /// <summary>
        /// 获取多选值字符串
        /// </summary>
        /// <param name="MulValueList"></param>
        /// <returns></returns>
        public static string GetMulValueString(List<string> MulValueList)
        {
            string ReturnValue = "";
            foreach (string Value in MulValueList)
            {
                ReturnValue += Value + ",";
            }
            return ReturnValue.Substring(0, ReturnValue.Length - 1);
        }

        /// <summary>
        /// 处理多选字符串
        /// </summary>
        /// <param name="filterstr"></param>
        /// <returns></returns>
        public static string GetFilterStr(string filterstr)
        {
            string str = "";
            string[] strArray = filterstr.Split(",".ToCharArray());
            foreach (string str2 in strArray)
            {
                str = str + string.Format("'{0}',", str2.ToString());
            }
            return str.Remove(str.Length - 1);
        }

        /// <summary>
        /// 检查所选冲单原单据是否存在不同客户
        /// </summary>
        /// <param name="DetailTlb"></param>
        /// <returns></returns>
        public static bool CheckRetailVouchDetailIsExistsDiffCustomer(DataTable DetailTlb)
        {
            bool bFlag = false;
            string sql = string.Empty;
            string CustomerCode = string.Empty;
            ArrayList list = new ArrayList();

            if (DetailTlb.Rows.Count > 0)
            {
                for (int r = 0; r < DetailTlb.Rows.Count; r++)
                {
                    sql = string.Format(@"select top 1 sl_ZT_CustomerCode from retailvouch where fchrretailvouchid in(select top 1 fchrretailvouchid from retailvouchdetail where fchrretailvouchdetailid = '{0}')", DetailTlb.Rows[r]["fchrZTOrigVouchDetailId"].ToString());
                    CustomerCode = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sql).ToString();
                    if (!list.Contains(CustomerCode))
                    {
                        list.Add(CustomerCode);
                    }
                }

                //存在不同客户
                if (list.Count > 1)
                {
                    bFlag = true;
                }
            }

            return bFlag;
        }

        /// <summary>
        /// 获取借出/归还单数据集
        /// </summary>
        /// <param name="MainId"></param>
        /// <returns></returns>
        public DataSet GetDsData(string MainId,string fchrVouchType)
        {
            DataSet ds = new DataSet();
            DataTable dtMain = new DataTable();
            DataTable dtDetail = new DataTable();
            DataTable dtCustomer = new DataTable();
            string sql = string.Empty;

            if (fchrVouchType == "JC" || fchrVouchType == "GH")
            {
                sql = string.Format(@"select * from sl_t_RdVouchMain where MainId = '{0}'", MainId);
                dtMain = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql).Tables[0].Copy();
                dtMain.TableName = "sl_t_RdVouchMain";

                sql = string.Format(@"select * from sl_t_RdVouchDetail where MainId = '{0}'", MainId);
                dtDetail = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql).Tables[0].Copy();
                dtDetail.TableName = "sl_t_RdVouchDetail";

                if (dtMain.Rows.Count > 0 && dtDetail.Rows.Count > 0)
                {
                    ds.Tables.Add(dtMain);
                    ds.Tables.Add(dtDetail);
                }
                else
                    ds = null;
            }
            else
            {
                sql = string.Format(@"select * from sl_ZT_Customer where ID = '{0}'", MainId);
                dtCustomer = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql).Tables[0].Copy();
                dtCustomer.TableName = "sl_ZT_Customer";

                if (dtCustomer.Rows.Count > 0)
                {
                    ds.Tables.Add(dtCustomer);
                }
                else
                    ds = null;
            }

            return ds;
        }


        /// <summary>
        /// 获取上传U8前数据集
        /// </summary>
        /// <param name="MainId"></param>
        /// <returns></returns>
        public DataSet GetDsDataToU8(string MainId)
        {
            DataSet ds = new DataSet();
            DataTable dtMain = new DataTable();
            DataTable dtDetail = new DataTable();
            string sql = string.Empty;

            sql = string.Format(@"select MainID,fchrCode,fdtmDate,w.fchrWhCode,'demo' as fchrPersonCode,m.fchrMemo,fchrSourceCode from sl_t_RdVouchMain m
                                  left join warehouse w on m.fchrWarehouseID = w.fchrwarehouseid where MainId = '{0}'", MainId);
            dtMain = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql).Tables[0].Copy();
            dtMain.TableName = "sl_t_RdVouchMain";

            sql = string.Format(@"select * from sl_t_RdVouchDetail where MainId = '{0}'", MainId);
            dtDetail = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql).Tables[0].Copy();
            dtDetail.TableName = "sl_t_RdVouchDetail";

            if (dtMain.Rows.Count > 0 && dtDetail.Rows.Count > 0)
            {
                ds.Tables.Add(dtMain);
                ds.Tables.Add(dtDetail);
            }
            else
                ds = null;

            return ds;
        }

        /// <summary>
        /// 更新单据上传标志
        /// </summary>
        /// <param name="MainId"></param>
        /// <param name="SysType"></param>
        public void SetUploadFlag(string MainId, string SysType)
        {
            string sql = string.Empty;
            sql = string.Format(@"update sl_t_RdVouchMain set {0} = 1 where MainId = '{1}'", SysType == "RM" ? "fbitTransferToRetail" : "fbitTransferToU8", MainId);
            SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, sql);
        }

        /// <summary>
        /// 更新展厅客户档案上传标志
        /// </summary>
        /// <param name="MainId"></param>
        /// <param name="SysType"></param>
        public void SetUploadFlagForCustomer(string ID)
        {
            string sql = string.Empty;
            sql = string.Format(@"update sl_ZT_Customer set fbitExport = 1 where ID = '{0}'", ID);
            SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, sql);
        }

        /// <summary>
        /// 序列化为Binary字节流
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="ErrMsg"></param>
        /// <returns></returns>
        public static byte[] Serialize(DataSet ds, ref string ErrMsg)
        {
            DataSetSurrogate sds = new DataSetSurrogate(ds);
            MemoryStream s = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            byte[] e = null;

            try
            {
                bf.Serialize(s, sds);
                e = s.ToArray();
            }
            catch (Exception ex) { ErrMsg = ex.InnerException.Message; }

            return e;
        }

        /// <summary>
        /// 借出/归还单保存后自动上传零售系统方法
        /// </summary>
        /// <param name="MainId"></param>
        /// <param name="fchrCode"></param>
        /// <param name="VouchType"></param>
        /// <param name="AlterMsg"></param>
        /// <returns></returns>
        public bool UploadDataToRM(string MainId, string fchrCode, string VouchType, ref string AlterMsg)
        {
            bool bFlag = true;
            DataTable dt = new DataTable();
            DataSet DsRdVouch = new DataSet();
            //string AlterMsg = string.Empty;
            AlterMsg = "";
            DsRdVouch = GetDsData(MainId, VouchType);
            if (DsRdVouch != null)
            {
                //上传操作
                string ErrMsg = "";
                string selCmd = "select fchrSelectionString from sl_VipCardDueConfig where fchrType='RmWebService'";
                object objSelStr = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd);

                if (Convert.IsDBNull(objSelStr) || string.IsNullOrEmpty(Convert.ToString(objSelStr)))
                {
                    //RetailMessageBox.ShowInformation("RMWebServiceURL不存在,请先日常下载!");
                    AlterMsg += VouchType == "JC" ? "借出单" : "归还单" + "【" + fchrCode + "】上传零售系统失败，原因：RMWebServiceURL不存在,请先日常下载!" + "\r\n";
                    bFlag = false;
                }

                if (bFlag)
                {
                    if (!CheckNetIsConnected(objSelStr.ToString().Split('/')[2].Split(':')[0].ToString()))
                    {
                        AlterMsg += VouchType == "JC" ? "借出单" : "归还单" + "【" + fchrCode + "】上传零售系统失败，原因：与总部服务器连接失败，请检查网络连接是否正常！" + "\r\n";
                        bFlag = false;
                        //RetailMessageBox.ShowInformation("与总部服务器连接失败，请检查网络连接是否正常！");                    
                    }
                }

                string url = Convert.ToString(objSelStr);
                object obj = null;
                string Err = "";
                try
                {
                    if (bFlag)
                    {
                        object[] args = { MainId, DsRdVouch };
                        //上传RM操作
                        bFlag = Convert.ToBoolean(Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "sl_ZT_DataExchangeFromPosToRM", args));
                        if (bFlag)
                        {
                            //MessageBox.Show("借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】已成功上传到零售系统！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AlterMsg += VouchType == "JC" ? "借出单" : "归还单" + "【" + fchrCode + "】已成功上传到零售系统！" + "\r\n";
                            //更新借出单上传标志
                            SetUploadFlag(MainId, "RM");
                            bFlag = true;
                        }
                        else
                        {
                            //MessageBox.Show("借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】上传到零售系统失败，请稍后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AlterMsg += VouchType == "JC" ? "借出单" : "归还单" + "【" + fchrCode + "】上传零售系统失败，请稍后再试！" + "\r\n";
                            bFlag = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    selCmd = "select fchrSelectionString from sl_VipCardDueConfig where fchrType='RmService'";
                    objSelStr = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd);

                    if (Convert.IsDBNull(objSelStr) || string.IsNullOrEmpty(Convert.ToString(objSelStr)))
                    {
                        //RetailMessageBox.ShowInformation("RMWebServiceURL不存在,请先日常下载!");
                        AlterMsg += VouchType == "JC" ? "借出单" : "归还单" + "【" + fchrCode + "】上传零售系统失败，原因：RMWebServiceURL不存在,请先日常下载!" + "\r\n";
                        bFlag = false;
                    }

                    if (bFlag)
                    {
                        if (!CheckNetIsConnected(objSelStr.ToString().Split('/')[2].Split(':')[0].ToString()))
                        {
                            AlterMsg += VouchType == "JC" ? "借出单" : "归还单" + "【" + fchrCode + "】上传零售系统失败，原因：与总部服务器连接失败，请检查网络连接是否正常！" + "\r\n";
                            //RetailMessageBox.ShowInformation("与总部服务器连接失败，请检查网络连接是否正常！");
                            bFlag = false;
                        }
                    }

                    url = Convert.ToString(objSelStr);

                    if (bFlag)
                    {
                        try
                        {
                            object[] args = { MainId, DsRdVouch };
                            //上传RM操作
                            bFlag = Convert.ToBoolean(Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "sl_ZT_DataExchangeFromPosToRM", args));
                            if (bFlag)
                            {
                                //MessageBox.Show("借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】已成功上传到零售系统！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                AlterMsg += VouchType == "JC" ? "借出单" : "归还单" + "【" + fchrCode + "】已成功上传到零售系统！" + "\r\n";
                                //更新借出单上传标志
                                SetUploadFlag(MainId, "RM");
                                bFlag = true;
                            }
                            else
                            {
                                AlterMsg += VouchType == "JC" ? "借出单" : "归还单" + "【" + fchrCode + "】上传零售系统失败，请稍后再试！" + "\r\n";
                                //MessageBox.Show("借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】上传到零售系统失败，请稍后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bFlag = false;
                            }
                        }
                        catch
                        {
                            //RetailMessageBox.ShowInformation("远程服务器无法连接,请检查网络!");
                            AlterMsg += VouchType == "JC" ? "借出单" : "归还单" + "【" + fchrCode + "】上传零售系统失败，原因：远程服务器无法连接,请检查网络!" + "\r\n";
                            bFlag = false;
                        }
                    }
                }
            }
            else 
            {
                AlterMsg += "获取单据数据失败！";
                bFlag = false;
            }

            return bFlag;
        }

        /// <summary>
        /// 借出/归还单保存后自动生成U8其他出入库单据方法
        /// </summary>
        /// <param name="MainId"></param>
        /// <param name="fchrCode"></param>
        /// <param name="VouchType"></param>
        /// <param name="AlterMsg"></param>
        /// <returns></returns>
        public bool UploadDataToU8(string MainId, string fchrCode, string VouchType, ref string AlterMsg)
        {
            bool bFlag = false;
            string ErrMsg = string.Empty;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();            
            //string AlterMsg = string.Empty;
            AlterMsg = "";
            //AssamblyWLWeb.Service ser = new AssamblyWLWeb.Service();
            WebTest.Service ser = new UFIDA.Retail.VIPCardControl.WebTest.Service();
            ds = GetDsDataToU8(MainId);
            if (ds != null)
            {
                byte[] DsBytes = sl_RetailCommom.Serialize(ds, ref ErrMsg);
                //ser.RMGenOtherInVouch(DsBytes, ref ErrMsg)
                if (ser.GenU8VoucherFromRM(DsBytes, VouchType == "JC" ? "09" : "08", ref ErrMsg))
                {
                    SetUploadFlag(MainId, "U8");
                    bFlag = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(ErrMsg))
                    {
                        if (VouchType == "JC")
                        {
                            AlterMsg += "借出单【" + fchrCode + "】生成U8【其他出库单】失败！" + "\r\n" + ErrMsg + "\r\n";
                        }
                        else
                        {
                            AlterMsg += "归还单【" + fchrCode + "】生成U8【其他入库单】失败！" + "\r\n" + ErrMsg + "\r\n";
                        }

                        bFlag = false;
                    }
                }

                //if (!string.IsNullOrEmpty(AlterMsg))
                //{
                //    RetailMessageBox.ShowInformation(AlterMsg);
                //    return;
                //}
            }
            else
            {
                AlterMsg += "获取单据数据失败！";
                bFlag = false;
                //RetailMessageBox.ShowInformation("获取单据数据失败！");
                //return;
            }

            return bFlag;
        }
    }
}
