using System;
using System.Collections.Generic;
using System.Text;
using UFIDA.Retail.Components;
using System.Windows.Forms;
using UFIDA.Retail.Utility;
using UFIDA.Retail.Common;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;

namespace UFIDA.Retail.VIPCardControl
{
    public class VIPDoWithEx
    {
        private string s01_fchrApplicant = SysPara.GetString("����Ա����");
        private string s01_fchrStoreID = SysPara.GetString("StoreId");
        //private 
        public void RefreshDataGrid(object sender, ExternalMethodCallArgs args)
        {
            string sotreCode = SysPara.GetString("StoreCode");
            DataSet gridDS = new DataSet();
            string strcmd = string.Format("select T1.S01_fchrApplyID,T1.S01_fchrReceiptNO,T1.S01_fintApplyTypeNO,T1.S01_fdtmDate,T1.S01_fchrStoreID,T1.S01_fchrApplicant,T1.S01_fchrDepartmentID,T1.S01_fchrVerifier,T1.S01_fchrMemo,T1.fbitExport,T1.S01_fbitAudit,T2.S01_VIPInfoApplyTypeName as VIPInfoApplyTypeName,T3.fchrDepartmentName as fchrDepartmentName from S01_VIPInfoModify as T1 left join S01_VIPInfoApplyType as T2 ON T1.S01_fintApplyTypeNO=T2.S01_fintApplyTypeNO left join department as T3  on T1.S01_fchrDepartmentID=T3.fchrDepartmentID order by T1.S01_fchrReceiptNO desc");
            DataTable resultTable = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, strcmd);
            if (resultTable != null && resultTable.Rows.Count > 0)
            {
                gridDS.Tables.Add(resultTable);
                gridDS.Tables[0].TableName = "DTDetail";
            }
            //gridDt.na
            HandleEvent handleEvent = args.HandleEvent;
            try
            {
                DataGrid dataGrid = handleEvent.GetDataGrid();
                dataGrid.DataSource = gridDS;
                if (dataGrid.DataSource != null)
                {
                    handleEvent.InitFormClass.DGrid.DataSource = dataGrid.DataSource;
                    //handleEvent.InitFormClass.MainForm.in
                }
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message);
            }
        }

        public void AddDetail(object sender, ExternalMethodCallArgs args)
        {
            frmVipInfoApllyDetail frmEdit = new frmVipInfoApllyDetail();
            frmEdit.Text = "VIP�ͻ���Ϣ������뵥(����)";
            frmEdit.IsAddConsumer = true;
            frmEdit.S01_fchrApplicant = s01_fchrApplicant;
            frmEdit.S01_fchrStoreID = s01_fchrStoreID;
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                RefeshWindow(args);
            }
        }
        public void EditDetail(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent handleEvent = args.HandleEvent;
            try
            {
                DataGrid dataGrid = handleEvent.GetDataGrid();
                DataTable table = (dataGrid.DataSource as DataSet).Tables[dataGrid.DataMember];
                if ((dataGrid == null) || (dataGrid.CurrentRowIndex < 0))
                {
                    return;
                }
                if ((table == null) || (table.Rows.Count == 0))
                {
                    return;
                }
                else
                {
                    DataRow editRow = table.Rows[dataGrid.CurrentRowIndex];
                    frmVipInfoApllyDetail frmEdit = new frmVipInfoApllyDetail();
                    frmEdit.Text = "VIP�ͻ���Ϣ������뵥(�༭)";
                    frmEdit.S01_fchrApplicant = s01_fchrApplicant;
                    frmEdit.S01_fchrStoreID = s01_fchrStoreID;
                    frmEdit.DrDetailData = editRow;
                    if (frmEdit.ShowDialog() == DialogResult.OK)
                    {
                        RefeshWindow(args);
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message);
            }
        }

        public void DelDetail(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent handleEvent = args.HandleEvent;
            string s01_fchrApplyID = "";
            try
            {
                DataGrid dataGrid = handleEvent.GetDataGrid();
                DataTable table = (dataGrid.DataSource as DataSet).Tables[dataGrid.DataMember];
                if ((dataGrid == null) || (dataGrid.CurrentRowIndex < 0))
                {
                    return;
                }
                if ((table == null) || (table.Rows.Count == 0))
                {
                    return;
                }
                else
                {
                    DataRow editRow = table.Rows[dataGrid.CurrentRowIndex];
                    s01_fchrApplyID = editRow["S01_fchrApplyID"].ToString();
                    if (CheckExport(s01_fchrApplyID))
                    {
                        RetailMessageBox.ShowInformation("�������ϴ�������ɾ��");
                        return;
                    }
                    else if (RetailMessageBox.ShowConfirm("��ȷ��ɾ����") == DialogResult.OK)
                    {
                        if (DeleteData(s01_fchrApplyID))
                            RefeshWindow(args);
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message);
            }
        }
        private bool DeleteData(string S01_fchrApplyID)
        {
            StringBuilder updateSql = new StringBuilder();
            updateSql.AppendFormat("delete from S01_VIPInfoModify where S01_fchrApplyID='{0}'", S01_fchrApplyID);
            int count = 0;
            count = SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, updateSql.ToString());
            if (count > 0)
            {
                RetailMessageBox.ShowInformation("ɾ���ɹ�");
                return true;
            }
            else
            {
                RetailMessageBox.ShowInformation("ɾ��ʧ��");
                return false;
            }
        }
        public bool CheckExport(string S01_fchrApplyID)
        {
            bool result = false;
            string strcmd = string.Format("select * from S01_VIPInfoModify where S01_fchrApplyID='{0}'", S01_fchrApplyID);
            DataTable resultTable = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, strcmd);
            if (resultTable != null && resultTable.Rows.Count > 0)
            {
                if (resultTable.Rows[0]["fbitExport"].ToString() != "" && (bool)resultTable.Rows[0]["fbitExport"])
                    result = true;
            }
            return result;
        }

        public void RefeshWindow(ExternalMethodCallArgs args)
        {
            HandleEvent handleEvent = args.HandleEvent;
            Init initFormClass = handleEvent.InitFormClass;
            initFormClass.MainForm.GetType().InvokeMember("ExecuteQuery", BindingFlags.InvokeMethod, null, initFormClass.MainForm, null);
        }

        /// <summary>
        /// ���VIP������Ϣ������Ӧ�Ŀͻ�֮��Ĺ�ϵ
        /// </summary>
        /// <param name="strVipConsumer"></param>
        /// <param name="strVipCode"></param>
        /// <returns></returns>
        private bool CheckVipConsumer(string strVipConsumerID, string strVipCode)
        {

            string strError = "";
            int intState = 0;
            string strVipConsumeName = "";
            try
            {
                SqlParameter myParm1 = new SqlParameter("@fchrvipconsumerid", SqlDbType.NVarChar, 100);
                myParm1.Value = strVipConsumerID;

                SqlParameter myParm2 = new SqlParameter("@fchrVipCode", SqlDbType.NVarChar, 100);
                myParm2.Value = strVipCode;

                SqlParameter myParm3 = new SqlParameter("@BackVipConsumeName", SqlDbType.NVarChar, 100);
                myParm3.Direction = ParameterDirection.Output;

                SqlParameter myParm4 = new SqlParameter("@State", SqlDbType.Int);
                myParm4.Direction = ParameterDirection.Output;

                SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.StoredProcedure, "procCheckVIPConsumerRelation", new SqlParameter[] { myParm1, myParm2, myParm3, myParm4 });

                strVipConsumeName = Tools.GetStringColumnValue(myParm3.Value);
                intState = Tools.GetIntColumnValue(myParm4.Value);

                switch (intState)
                {
                    case 1:
                    case 2:
                        string questionMessage = string.Format("��VIP���ѷ����ͻ�[{0}]���Ƿ������", strVipConsumeName);
                        if (RetailMessageBox.ShowQuestion(questionMessage) == DialogResult.No)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    case 3:
                        strError = string.Format("��VIP���ѷ����ͻ�[{0}]�����Ҳ��ڱ��귢����", strVipConsumeName);
                        RetailMessageBox.ShowExclamation(strError);
                        return false;
                    case 4:
                        strError = string.Format("��VIP���ѷ����ͻ������Ҳ��ڱ��귢����", strVipConsumeName);
                        RetailMessageBox.ShowExclamation(strError);
                        return false;
                    default:
                        return true;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                return false;
            }
            finally
            {
            }
        }

        //ʤ���Ϳ�ȫ�ֱ���
        public static string DetailStrVipCode = string.Empty;

        /// <summary>
        /// ����VIP����VIP�ͻ�֮��Ĺ�ϵ��ֻ����ʾ����ʱ��TABLE��
        /// </summary>
        public void CreateVipConsumerRelation(object sender, ExternalMethodCallArgs args)
        {
            DetailStrVipCode = "";
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            string strVIPConsumerID = "";
            string strVIPClassID = "";
            DataSet dsSave = new DataSet();
            DataRow dr = null;
            DataRow drSelect = null;
            String StrSQL = "";

            try
            {

                //�õ��ͻ���ID
                Control controlSource = HandleEvent.FindControl("fchrvipconsumerid", InitFormClass.MainForm);
                strVIPConsumerID = HandleEventHelper.GetControlValues(controlSource, "ExLabel");

                controlSource = HandleEvent.FindControl("fchrVIPCardClassID",InitFormClass.MainForm);
                strVIPClassID = HandleEventHelper.GetControlValues(controlSource,"RefControl");

                // �õ������е�VIP��Ϣ��ϸ
                HandleEvent.FilterEmptyRows(InitFormClass.DGrid);
                DataGrid ParentGrid = InitFormClass.DGrid;
                DataSet ds = ParentGrid.DataSource as DataSet;

                if (strVIPClassID == "")
                {
                    RetailMessageBox.ShowExclamation("��ѡ����Ҫ�����ļ���");
                    return;
                }

                if (!CheckVIPClassIsValid(strVIPClassID, strVIPConsumerID))
                {
                    RetailMessageBox.ShowError("ֻ����ѡ���뵱ǰ�ͻ����¿ͻ�������ͬ�ļ�����л�����");
                    return;
                }

                //ʤ���Ϳ�-��ȡԭVIP����
                if (ds.Tables["DTDetail"].Rows.Count > 0)
                {
                    StrSQL = string.Format("select top 1 fchrvipcards from vipconsumer where fchrvipconsumerid = '{0}'",strVIPConsumerID);
                    DetailStrVipCode = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, StrSQL).ToString();
                }
                //ʤ���Ϳ�


                //���VIP������
                StrSQL = string.Format("select * from vipcodecollate where fchrvipconsumerid = '{0}' and fdtmEndDate>=Convert(varchar(100),getdate(),23) and fdtmStopDate is null and fbitUse = 1", strVIPConsumerID);
                DataTable DetailTable = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, StrSQL);
                if (DetailTable.Rows.Count >= 2)
                {
                    RetailMessageBox.ShowError("һ���ͻ�ֻ�ܷ���һ�ſ�������Ҫ������ز�������");
                    return;
                }



                // ��ʾ��  VIP��Ϣ����ʾ
                frmSelect selectForm = new frmSelect();
                selectForm.TemplateID = "Ref_VipCode";
                selectForm.PageNumber = 1;
                selectForm.MultiSelect = false;
                selectForm.MustShowForm = true;
                selectForm.ParentCondition = string.Format(" fchrvipconsumerid IS NULL and  S01_fchrVipCardClassID ='{0}' ", strVIPClassID);// string.Format (  " fchrvipconsumerid IS NULL OR  fchrvipconsumerid !='{0}' ",strVIPConsumerID);
                selectForm.FilterText = "";
                selectForm.FocusOnFilter = true;
                selectForm.Init();

                if (selectForm.DialogResult == DialogResult.OK)
                {
                    drSelect = selectForm.GetCurrentDataRow();
                    if (CheckVipConsumer(strVIPConsumerID, Tools.GetStringColumnValue(drSelect["fchrVipCode"])))
                    {
                        DataTable dt = ds.Tables["DTDetail"];
                        foreach (DataRow drlist in dt.Rows)
                        {
                            if (drlist.RowState != DataRowState.Deleted)
                            {
                                if (Tools.GetStringColumnValue(drSelect["fchrVipCode"]) == Tools.GetStringColumnValue(drlist["fchrVipCode"]))
                                    return;
                            }
                        }
                        if (dt.Rows.Count <= 0)
                        {
                            dr = dt.NewRow();
                            //dr.ItemArray = drSelect.ItemArray;
                            for (int i = 0; i < drSelect.Table.Columns.Count; i++)
                            {
                                if (dt.Columns.Contains(drSelect.Table.Columns[i].ColumnName))
                                {
                                    dr[drSelect.Table.Columns[i].ColumnName] = drSelect[i];
                                }

                            }
                            dt.Rows.Add(dr);
                        }
                        else if (strVIPClassID != "")
                        {

                            dr = dt.Rows[0];
                            dt.Rows.Clear();
                            for (int i = 0; i < drSelect.Table.Columns.Count; i++)
                            {
                                if (dt.Columns.Contains(drSelect.Table.Columns[i].ColumnName))
                                {
                                    dr[drSelect.Table.Columns[i].ColumnName] = drSelect[i];
                                }
                            }
                            dt.Rows.Add(dr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);

            }
            finally
            {

            }
        }

        /// <summary>
        /// �����ѡ�������Ƿ��뵱ǰ���¿�����ͬ��
        /// </summary>
        /// <param name="fchrvipcardclassid"></param>
        /// <param name="fchrvipconsumerid"></param>
        /// <returns></returns>
        private bool CheckVIPClassIsValid(string fchrvipcardclassid, string fchrvipconsumerid)
        {
            string sql = string.Empty;
            bool bFlag = true;
            string fchrCurVIPCardClassID = string.Empty;
            sql = string.Format(@"select top 1 S01_fchrVIPCardClassID from vipcodecollate where fchrvipcode = (select top 1 fchrVipCards from vipconsumer
                                  where fchrvipconsumerid = '{0}')", fchrvipconsumerid);
            fchrCurVIPCardClassID = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sql).ToString();
            if (fchrvipcardclassid.ToUpper() != fchrCurVIPCardClassID.ToUpper())
            {
                bFlag = false;
            }

            return bFlag;
        }

        #region
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
      

        /// <summary>
        /// ��ȡ�����ļ�ָ����ֵ
        /// </summary>
        /// <param name="Configfile">�����ļ���ȫ·���ļ���</param>
        /// <param name="Section">����</param>
        /// <param name="Key">����</param>
        /// <param name="def">Ϊ�յ�Ĭ��ֵ</param>
        /// <returns>�ַ���ֵ</returns>
        public static string GetPrivateProfileString(string Configfile, string Section, string Key, string def)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, def, temp, 255, Configfile);
            return temp.ToString();
        }

        #endregion
        /// <summary>
        /// ����ȷ���õ�VIP����VIP�ͻ�֮��Ĺ�ϵ�������ı��浽���ݿ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void SaveVipConsumerRelation(object sender, ExternalMethodCallArgs args)
        {
 
         
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            string strVIPConsumerID = "";
            string errDesc = "";
            string strVipCode = "";
            string strSQL = "";
            bool bolProvide = false;          //�Ƿ񷢿�
            string strVIPConsumerName = "";
            string strVIPCalssID = "";
            DataSet dsSave = new DataSet();
            SqlConnection oConn = null;
            IDbTransaction tran = null;
            string fdtmSamClassEndate = "";
            string DetailvipCode = string.Empty;
            bool fbitIsSameClass = false;
            string vipCurrCardClassID = null;
         
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

                Control controlSource = null;
                // �õ������е�VIP��Ϣ��ϸ
                HandleEvent.FilterEmptyRows(InitFormClass.DGrid);
                DataGrid ParentGrid = InitFormClass.DGrid;
                DataSet ds = ParentGrid.DataSource as DataSet;


                //�õ��ͻ���ID
                controlSource = HandleEvent.FindControl("fchrvipconsumerid", InitFormClass.MainForm);
                strVIPConsumerID = HandleEventHelper.GetControlValues(controlSource, "ExLabel");

                controlSource = HandleEvent.FindControl("fchrVIPCardClassID", InitFormClass.MainForm);
                strVIPCalssID = HandleEventHelper.GetControlValues(controlSource, "RefControl");


                //�����е���Ʒ��Ϣ��ϸ�Ƿ�Ϊ��
                if (ds != null)
                {
                    DataTable dt = ds.Tables["DTDetail"];

                    if (dt.Rows.Count == 0)
                    {
                        RetailMessageBox.ShowExclamation("û����ϸ���ݼ�¼���޷����棡");
                        return;
                    }

                    //���ݶ�ɾ��ʱ�������档V891һ�ڲ��� 
                    if (dt.Select("", "", DataViewRowState.Deleted).Length == dt.Rows.Count)
                    {
                        RetailMessageBox.ShowExclamation("û����ϸ���ݼ�¼���޷����棡");
                        return;
                    }

                    //�жϸÿͻ��Ƿ����ϴ������Ѻ˶�
                    strSQL = string.Format("select top 1 fbitExport,fbitCheck,fbitVerify_DQ from vipconsumer where fchrvipconsumerid = '{0}'", strVIPConsumerID);
                    DataSet dsCheck = SqlAccess.ExecuteDataset(tran, CommandType.Text, strSQL);
                    if (dsCheck.Tables[0].Rows.Count > 0)
                    {
                        if ((!(bool)dsCheck.Tables[0].Rows[0]["fbitExport"] && dsCheck.Tables[0].Rows[0]["fbitVerify_DQ"].ToString() == "") || dsCheck.Tables[0].Rows[0]["fbitVerify_DQ"].ToString() == "0")
                        {
                            RetailMessageBox.ShowExclamation("VIP�ͻ�����δ�˶ԣ����ܼ��������򻻿���");
                            return;
                        }
                    }

                    strSQL = string.Format("select fchrVIPCardClassID from vipconsumer where fchrvipconsumerid = '" + strVIPConsumerID.ToString() + "'");
                    vipCurrCardClassID = Convert.ToString(SqlAccess.ExecuteScalar(tran, CommandType.Text, strSQL));
                    if (vipCurrCardClassID == strVIPCalssID)
                    {
                        fbitIsSameClass = true;
                        strSQL = string.Format("select top 1 fdtmEnddate from vipcodecollate where fchrVipCode = '" + DetailStrVipCode + "'");
                        fdtmSamClassEndate = Convert.ToString(SqlAccess.ExecuteScalar(tran, CommandType.Text, strSQL));
                    }

                    strVIPConsumerName = GetConsumerName(strVIPConsumerID);
                    // ִ��SQL��䣬������ȥ������ͻ����е�VIP������Ϣ

                    //strSQL = string.Format("UPDATE VipCodeCollate set fchrvipconsumerid=null,fnarconsumername=null WHERE fchrvipconsumerid='{0}'", strVIPConsumerID);
                    //SqlAccess.ExecuteNonQuery(tran, CommandType.Text, strSQL);

                    //strSQL = string.Format("UPDATE VipConsumer set fbitProvide=0, WHERE fchrvipconsumerid='{0}'", strVIPConsumerID);
                    //SqlAccess.ExecuteNonQuery(tran, CommandType.Text, strSQL);
                 
                   
                    bolProvide = false;
                    // ������  �ڽ�������������Ϣһ��һ���� ȥ������ϵ
                    StringBuilder strBuilder = new StringBuilder();
                    foreach (DataRow oRows in dt.Rows)
                    {
                        if (oRows.RowState != DataRowState.Deleted)
                        {
                            strVipCode = Tools.GetStringColumnValue(oRows["fchrVipCode"]);

                            if (Convert.ToBoolean(oRows["fbitUse"]))   //���ʹ�õĿ�����Ŀͻ����ù�����ȥ��ԭ���Ĺ�ϵ������ά��
                            {
                                if (strVIPCalssID == "")
                                {
                                    strSQL = "select fchrVIPCardClassID from vipcardclass where fbitDefaultClass='true'";
                                    strVIPCalssID = SqlAccess.ExecuteScalar(tran, CommandType.Text, strSQL).ToString();
                                }

                                string strVIPCards = GetVipCards(strVipCode);

                                strSQL = string.Format("UPDATE VIPConsumer  SET fchrVipcards='{2}',fbitExport=0,fchrVIPCardClassID='{3}' WHERE fchrVipConsumerID IN (SELECT fchrVipConsumerID  FROM VipCodeCollate WHERE fchrVipCode='{0}' AND fchrVipConsumerID<>'{1}');Update VipCodeCollate set fchrNewCardCode = '{0}' where fchrvipCode = '{4}'",
                                            strVipCode, strVIPConsumerID, strVIPCards, strVIPCalssID, DetailStrVipCode);

                                SqlAccess.ExecuteNonQuery(tran, CommandType.Text, strSQL);
                            }
                            

                            //strSQL = string.Format("UPDATE VipCodeCollate set fchrvipconsumerid='{0}',fnarconsumername='{1}' WHERE fchrVipCode='{2}'", strVIPConsumerID, strVIPConsumerName, strVipCode);
                            //SqlAccess.ExecuteNonQuery(tran, CommandType.Text, strSQL);
                            strBuilder.AppendFormat(",'{0}'", strVipCode);
                            bolProvide = true;
                        }
                    }
                    string str = GetPrivateProfileString(@".\RepairBillDate.Ini", "RepairBill", "RepairBillDate", "");

                    //ʤ���Ϳ�-����VIP����Ч��˳�ӡ����¾ɿ���Ϣ
                    if (fbitIsSameClass)
                    {
                        //ͬ�������ɿ�
                        strSQL = string.Format("UPDATE vipcodeCollate set fdtmEndDate= Convert(varchar(100),getdate(),23),fbitExport = 0,fbitUse = 0,fbitOldCard = 1,fdtmStopDate = null,fchrNewCardCode = '{1}' where fchrvipCode = '{0}'", DetailStrVipCode, strVipCode);
                        SqlAccess.ExecuteNonQuery(tran, CommandType.Text, strSQL);
                    }
                    else
                    {
                        //���������ɿ�
                        strSQL = string.Format("UPDATE vipcodeCollate set fdtmEndDate=Convert(varchar(50),Convert(varchar(100),dateadd(dd,-day(convert(varchar(10),dateadd(day,30,getdate()),121)),dateadd(m,1,convert(varchar(10),dateadd(day,30,getdate()),121))),23),23),fbitExport = 0,fbitOldCard = 1,fdtmStopDate = null,fbitUse = 1,fchrNewCardCode = '{1}' where fchrvipCode = '{0}'", DetailStrVipCode, strVipCode);
                        SqlAccess.ExecuteNonQuery(tran, CommandType.Text, strSQL);
                    }


                    //�����¿���Ϣ
                    if (bolProvide)
                    {
                        //��ȡ��������  by ljx
                        string selCmd = string.Format("select S01_fintPromotPoints from vipCardClass where fchrVIPCardClassID='{0}'", strVIPCalssID);
                        object s01_fintPromotPoints = SqlAccess.ExecuteScalar(tran, CommandType.Text, selCmd);
                        //��ȡRM�����õĽ����������� by ljx
                        selCmd = string.Format("select fchrSelectionString from sl_VipCardDueConfig where fchrType='Pro'");
                        object relString = SqlAccess.ExecuteScalar(tran, CommandType.Text, selCmd);
                        relString = "1=1"; 
                       // if (relString == null)
                       // { relString = "1=1"; }

                        string strVipCodes = strBuilder.ToString().Substring(1);  //ȥ��ǰ������
                        if (fbitIsSameClass)
                        {
                            strSQL = string.Format("UPDATE VipCodeCollate SET fchrvipconsumerid='{0}',fnarconsumername='{1}',S01_fchrVIPCardClassID='{4}',fdtmstartdate = convert(varchar(100),getdate(),23),fdtmenddate = '" + fdtmSamClassEndate + "',fbitExport = 0,fbitOldCard = 0 from vipcardclass c with(nolock) WHERE fchrVipCode IN ('{2}') and c.fchrvipcardclassid = '{4}';UPDATE VipConsumer SET fbitExport=0, fbitProvide=1,fchrVipCards='{3}',fchrVIPCardClassID='{4}',fintInitTotal={5} WHERE fchrvipconsumerid='{0}' and {6}",
                                                    strVIPConsumerID, strVIPConsumerName, strVipCode, strVipCodes.Replace("'", ""), strVIPCalssID, s01_fintPromotPoints, relString);
                        }
                        else
                        {
                            strSQL = string.Format("UPDATE VipCodeCollate SET fchrvipconsumerid='{0}',fnarconsumername='{1}',S01_fchrVIPCardClassID='{4}',fdtmstartdate =convert(varchar(100),getdate(),23),fdtmenddate = convert(varchar(10),dateadd(month,isnull(c.S01_fintValidMonths,24)+1,isnull(getdate(),getdate()))-day(dateadd(month,isnull(c.S01_fintValidMonths,24)+1,isnull(getdate(),getdate()))),121),fbitExport = 0,fbitOldCard = 0 from vipcardclass c with(nolock) WHERE fchrVipCode IN ('{2}') and c.fchrvipcardclassid = '{4}';UPDATE VipConsumer SET fbitExport=0, fbitProvide=1,fchrVipCards='{3}',fchrVIPCardClassID='{4}',fintInitTotal={5}  WHERE fchrvipconsumerid='{0}' and {6}",
                                                    strVIPConsumerID, strVIPConsumerName, strVipCode, strVipCodes.Replace("'", ""), strVIPCalssID, s01_fintPromotPoints, relString);
                        }
                        SqlAccess.ExecuteNonQuery(tran, CommandType.Text, strSQL); { }
                    }

                    //SqlAccess.ExecuteNonQuery(tran, CommandType.Text, "EXEC ProcCheckVipConsumerProvide");

                    RetailMessageBox.ShowInformation("VIP����Ϣ����ɹ���");

                    //��ֵ������
                    string OldStoredCardID = "";
                    string NewStoredCardID = "";
                    OldStoredCardID = GetStoredCardID(DetailStrVipCode);
                    NewStoredCardID = GetStoredCardID(strVipCode);
                    if (OldStoredCardID != "" && NewStoredCardID != "")
                    {
                        ChangeStoredCard(OldStoredCardID, NewStoredCardID, DetailStrVipCode, strVipCode);
                        tran.Commit();
                        SqlAccess.Close(oConn);
                    }
                    else if (OldStoredCardID == "")
                    {
                        RetailMessageBox.ShowInformation(DetailStrVipCode + " �Ĵ�ֵ�������ڣ���ֵ������ʧ�ܣ�");
                        tran.Rollback();
                        SqlAccess.Close(oConn);
                        return;
                    }
                    else if (NewStoredCardID == "")
                    {
                        RetailMessageBox.ShowInformation(strVipCode + " �Ĵ�ֵ�������ڣ���ֵ������ʧ�ܣ�");
                        tran.Rollback();
                        SqlAccess.Close(oConn);
                        return;
                    }
                }
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
        /// ����VIP�ͻ�ID�ĵ�VIP�ͻ�������
        /// </summary>
        /// <param name="strVIPConsumerID"></param>
        /// <returns></returns>
        public string GetConsumerName(string strVIPConsumerID)
        {
            SqlConnection sConn = new SqlConnection();
            sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
            string strVIPConsumerName = "";
            string strSQL = "";

            try
            {
                strSQL = string.Format("Select fnarconsumername FROM vipconsumer WITH(NOLOCK) WHERE fchrvipconsumerid='{0}'", strVIPConsumerID);
                object oTemp = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL);
                if (oTemp != null)
                    strVIPConsumerName = oTemp.ToString();
                else
                    strVIPConsumerName = "";
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return strVIPConsumerName;
        }

        /// <summary>
        /// ����VIP�ͻ�ID�ĵ�VIP�ͻ�������
        /// </summary>
        /// <param name="strVIPConsumerID"></param>
        /// <returns></returns>
        public string GetVipCards(string strDeleteVipCode)
        {
            SqlConnection sConn = new SqlConnection();
            sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
            string strVIPCards = "";
            string strSQL = "";

            try
            {
                strSQL = string.Format("SELECT fchrVipCode FROM VipCodeCollate WITH(NOLOCK) WHERE fchrVipConsumerID IN (SELECT fchrVipConsumerID FROM VipCodeCollate WITH(NOLOCK) WHERE fchrVipCode='{0}') AND fchrVipCode<>'{0}'", strDeleteVipCode);
                DataSet dtSet = SqlAccess.ExecuteDataset(sConn, CommandType.Text, strSQL);
                if (dtSet.Tables[0].Rows.Count > 0)
                {
                    string[] strVIPCardList = new string[dtSet.Tables[0].Rows.Count];
                    for (int i = 0; i < dtSet.Tables[0].Rows.Count; i++)
                    {
                        strVIPCardList[i] = Tools.GetStringColumnValue(dtSet.Tables[0].Rows[i][0]);
                    }

                    strVIPCards = string.Join(",", strVIPCardList);
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return strVIPCards;

        }

        /// <summary>
        /// ��ֵ����������
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="cardIDNew"></param>
        /// <param name="cardCode"></param>
        /// <param name="cardCodeNew"></param>
        public void ChangeStoredCard(string cardID,string cardIDNew,string cardCode,string cardCodeNew)
        {
            string strOperator = Tools.GetStringSysPara("����Ա����");
            string strChangeType = "3";
            string errorString = "";
            bool succeed = GatheringReceipt.business.InTerfaceCartSavingOperater.ChangeCardCode(Tools.GetStringSysPara("StoreID"), cardID, cardIDNew, strChangeType, strOperator, ref errorString);
            if (!succeed)
            {
                RetailMessageBox.ShowWarning(errorString);
            }
            else
            {
                RetailMessageBox.ShowInformation(string.Format("��ֵ�������ɹ���\r\n���ţ�{0}�ݸ���Ϊ��{1}��", cardCode, cardCodeNew));
            }
        }

        /// <summary>
        /// ��ȡVIP���Ŷ�Ӧ�Ĵ�ֵ����
        /// </summary>
        /// <param name="VipCardCode">VIP����</param>
        /// <returns></returns>
        public string GetStoredCardID(string VipCardCode)
        {
            string customerQuery = "";
            string phoneQuery = "";
            string errorString = "";
            string cardID = "";
            string cardCode = "";
            string phone = "";
            string customerName = "";
            bool isStop;
            DataTable dt = GatheringReceipt.business.InTerfaceCartSavingOperater.CardQuery(VipCardCode, customerQuery, phoneQuery, ref errorString);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow[] dr = dt.Select("fchrStoredCardCode = '"+VipCardCode+"'");
                if (dr.Length > 0) {
                    cardID = Tools.GetStringColumnValue(dr[0]["fchrStoredCardID"]);
                    cardCode = Tools.GetStringColumnValue(dr[0]["fchrStoredCardCode"]);
                    phone = Tools.GetStringColumnValue(dr[0]["fchrCustomerPhone"]);
                    customerName = Tools.GetStringColumnValue(dr[0]["fchrCustomerName"]);
                    isStop = Tools.GetBoolColumnValue(dr[0]["fbitIsStop"]);
                }
            }
            return cardID;
        }
    }
}
