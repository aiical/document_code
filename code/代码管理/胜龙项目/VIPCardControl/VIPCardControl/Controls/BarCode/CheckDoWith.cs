using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Xml;
using System.Windows.Forms;
using System.Reflection;
using UFIDA.Retail.Components;
using UFIDA.Retail.Common;
using UFIDA.Retail.DataAccess;
using UFIDA.Retail.Utility;
using UFIDA.Retail.RetailPrint;
using System.Collections.Generic;
using System.Text;
using UFIDA.Retail.Business.Common;

namespace UFIDA.Retail.VIPCardControl
{
    /// <summary>
    /// Class1 ��ժҪ˵����
    /// </summary>
    public class CheckDoWith
    {
        public CheckDoWith()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

        /// <summary>
        /// �ж���Ʒ���������Ƿ���ȷ
        /// </summary>
        /// <param name="strItemID">
        /// ��ƷID
        /// </param>
        /// <param name="strFreeKey">
        /// ��������
        /// </param>
        /// <param name="strFreeValue">
        /// ������ȡֵ��Χ
        /// </param>
        /// <returns></returns>
        public bool CheckItemFree(string strItemID, string strFreeKey, string strFreeValue)
        {
            //			int intBitFree = 0;
            int intFreeNumber = 0;
            IDataReader readerTemp = null;
            string strSQL = "";
            bool bolExistItemAllotAnalysis = false;
            SqlConnection sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());

            // �жϴ��������ֵ�Ƿ����
            try
            {
                strSQL = string.Format("Select Count(*) AS FreeNumber FROM UserDefineDatas WHERE fchrFieldName='{0}' AND fchrValue='{1}'", strFreeKey, strFreeValue);
                object oTemp = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL);
                if (oTemp != null)
                    intFreeNumber = Tools.GetIntColumnValue(oTemp);
                else
                    intFreeNumber = 0;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {

            }
            if (intFreeNumber == 0)
                return false;

            //����Ƿ���,�Ƿ����������Ʒ��������ȡֵ��Χ
            if (Tools.GetStringSysPara("BackSystem") == "DRP860")
            {
                try
                {

                    strSQL = string.Format("Select Count(*) AS FreeNumber FROM ItemAllotAnalysis WHERE fchrItemID='{0}' AND fchrFieldName='{1}' AND fchrValue='{2}'", strItemID, strFreeKey, strFreeValue);
                    object oTemp = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL);
                    if (oTemp != null)
                        intFreeNumber = Tools.GetIntColumnValue(oTemp);
                    else
                        intFreeNumber = 0;

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                finally
                {

                }
                if (intFreeNumber == 0)
                    return false;
            }
            else
            {
                // �����U8�����ж� ������Ʒ������������ȡֵ��Χ�Ƿ����

                strSQL = string.Format("Select Count(*) AS FreeNumber FROM ItemAllotAnalysis WHERE fchrItemID='{0}' AND fchrFieldName='{1}' ", strItemID, strFreeKey);

                try
                {
                    readerTemp = SqlAccess.ExecuteReader(sConn, CommandType.Text, strSQL);
                    strSQL = string.Format("Select Count(*) AS FreeNumber FROM ItemAllotAnalysis WHERE fchrItemID='{0}' AND fchrFieldName='{1}' AND fchrValue='{2}'", strItemID, strFreeKey, strFreeValue);
                    object oTemp = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL);
                    if (oTemp != null)
                        intFreeNumber = Tools.GetIntColumnValue(oTemp);
                    else
                        intFreeNumber = 0;

                    if (intFreeNumber != 0)
                        bolExistItemAllotAnalysis = true;
                    else
                        bolExistItemAllotAnalysis = false;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                finally
                {

                }

                // ������ھ�Ҫ�ͷ�������һ�µ��㷨  
                if (bolExistItemAllotAnalysis)
                {
                    try
                    {

                        strSQL = string.Format("Select Count(*) AS FreeNumber FROM ItemAllotAnalysis WHERE fchrItemID='{0}' AND fchrFieldName='{1}' AND fchrValue='{2}'", strItemID, strFreeKey, strFreeValue);

                        readerTemp = SqlAccess.ExecuteReader(sConn, CommandType.Text, strSQL);

                        object oTemp = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL);
                        if (oTemp != null)
                            intFreeNumber = Tools.GetIntColumnValue(oTemp);
                        else
                            intFreeNumber = 0;

                        if (intFreeNumber == 0)
                            return false;

                    }
                    catch (SqlException ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                    finally
                    {

                    }
                }
            }
            return true;
        }
        /// <summary>
        /// �����ⵥ�Ƿ��Ѿ��ر�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool CheckInOutVouchState(object sender, ExternalMethodCallArgs args)
        {
            string InOutVouchIDControlName = args.ConfigNode.Attributes["InOutVouchIDControlName"].Value;
            Control inoutVouchIDControl = HandleEventHelper.FindControlFromMainForm(InOutVouchIDControlName, args.HandleEvent.SourceForm);
            string inOutVouchID = HandleEventHelper.GetControlValue(inoutVouchIDControl);
            //���inOutVouchIDΪ�մ���˵�����������򲻼��״̬
            if (inOutVouchID == "")
            {
                return true;
            }
            string commandText = string.Format("select fintState from InOutVouch where fchrInOutVouchID = '{0}'", inOutVouchID);
            try
            {
                DataTable dtResult = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, commandText);
                string state = dtResult.Rows[0][0].ToString();
                //2��ʾ�Ѿ��ر�
                if (state == "2")
                {
                    RetailMessageBox.ShowWarning("��ǰ���ݲ�������״̬�������½��룡");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                return false;
            }
        }


        /// <summary>
        /// ��������������������Ƿ�����˴���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool CheckFreeErrors(object sender, ExternalMethodCallArgs args)
        {
            string strItemIDControlName = "";                  //��ƷID�Ŀؼ�����
            string strItemIDControlType = "";                //��ƷID�Ŀؼ�����
            string strItemIDControlValue = "";                                                //��ƷID�Ŀؼ�ֵ

            string strFreeControlName = "";													 //��Ʒ������Ŀؼ�����
            string strFreeControlType = "";													 //��Ʒ������Ŀؼ�����
            string strFreeControlValue = "";													 //��Ʒ������Ŀؼ�ֵ

            string strFreeName = "";
            bool fbitFree = false;

            string sqlBuilder = "";

            Control controlSource = null;
            IDataReader readerTemp = null;
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;

            XmlNode configNode = args.ConfigNode;
            DataGrid dg = args.HandleEvent.InitFormClass.DGrid;

            //�����ƷID�Ŀؼ��������Բ����ڣ��򲻼��
            if (configNode == null || configNode.Attributes["ItemIDControl"] == null)
            {
                return true;
            }

            strItemIDControlName = configNode.Attributes["ItemIDControl"].Value;

            //�����ƷID�Ŀؼ����Ͳ����ڣ��򲻼��
            if (configNode == null || configNode.Attributes["ItemIDControlType"] == null)
            {
                return true;
            }

            strItemIDControlType = configNode.Attributes["ItemIDControlType"].Value;

            controlSource = HandleEvent.FindControl(strItemIDControlName, args.HandleEvent.GetDetailForm(sender));
            strItemIDControlValue = HandleEventHelper.GetControlValues(controlSource, strItemIDControlType);


            if (strItemIDControlValue != "")
            {
                sqlBuilder = string.Format("SELECT fbitFree1, fbitFree2 , fbitFree3, fbitFree4, fbitFree5, fbitFree6, fbitFree7, fbitFree8, fbitFree9, fbitFree10 from item Where  fchrItemID='{0}'", strItemIDControlValue);
                SqlConnection sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
                try
                {
                    readerTemp = SqlAccess.ExecuteReader(sConn, CommandType.Text, sqlBuilder);
                    if (readerTemp.Read())
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            strFreeName = string.Format("fbitFree{0}", i.ToString());
                            fbitFree = Tools.GetBoolColumnValue(readerTemp[strFreeName]);
                            if (fbitFree)
                            {
                                if (configNode == null || configNode.Attributes[string.Format("Free{0}Control", i.ToString())] == null)
                                {
                                    return true;
                                }

                                strFreeControlName = configNode.Attributes[string.Format("Free{0}Control", i.ToString())].Value;

                                if (configNode == null || configNode.Attributes[string.Format("Free{0}ControlType", i.ToString())] == null)
                                {
                                    return true;
                                }

                                strFreeControlType = configNode.Attributes[string.Format("Free{0}ControlType", i.ToString())].Value;

                                controlSource = HandleEvent.FindControl(strFreeControlName, args.HandleEvent.GetDetailForm(sender));
                                strFreeControlValue = HandleEventHelper.GetControlValues(controlSource, strFreeControlType);
                                if (strFreeControlValue != "")
                                {
                                    if (!CheckItemFree(strItemIDControlValue, strFreeControlName, strFreeControlValue))
                                        return true;
                                }
                                else
                                    return true;
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                finally
                {
                    if (readerTemp != null && !readerTemp.IsClosed)
                        readerTemp.Close();

                    SqlAccess.Close(sConn);
                }
            }
            return false;
        }
        /// <summary>
        /// ��������������������Ƿ�����˴���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool CheckFreeError(object sender, ExternalMethodCallArgs args)
        {
            string strItemIDControlName = "";                  //��ƷID�Ŀؼ�����
            string strItemIDControlType = "";                //��ƷID�Ŀؼ�����
            string strItemIDControlValue = "";                                                //��ƷID�Ŀؼ�ֵ

            string strFreeControlName = "";													 //��Ʒ������Ŀؼ�����
            string strFreeControlType = "";													 //��Ʒ������Ŀؼ�����
            string strFreeControlValue = "";													 //��Ʒ������Ŀؼ�ֵ

            string strFreeName = "";
            bool fbitFree = false;

            string sqlBuilder = "";

            Control controlSource = null;
            IDataReader readerTemp = null;
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;

            XmlNode configNode = args.ConfigNode;
            DataGrid dg = args.HandleEvent.InitFormClass.DGrid;

            //�����ƷID�Ŀؼ��������Բ����ڣ��򲻼��
            if (configNode == null || configNode.Attributes["ItemIDControl"] == null)
            {
                return true;
            }

            strItemIDControlName = configNode.Attributes["ItemIDControl"].Value;

            //�����ƷID�Ŀؼ����Ͳ����ڣ��򲻼��
            if (configNode == null || configNode.Attributes["ItemIDControlType"] == null)
            {
                return true;
            }

            strItemIDControlType = configNode.Attributes["ItemIDControlType"].Value;

            controlSource = HandleEvent.FindControl(strItemIDControlName, args.HandleEvent.GetDetailForm(sender));
            strItemIDControlValue = HandleEventHelper.GetControlValues(controlSource, strItemIDControlType);


            if (strItemIDControlValue != "")
            {
                sqlBuilder = string.Format("SELECT fbitFree1, fbitFree2 , fbitFree3, fbitFree4, fbitFree5, fbitFree6, fbitFree7, fbitFree8, fbitFree9, fbitFree10 from item Where  fchrItemID='{0}'", strItemIDControlValue);
                SqlConnection sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
                try
                {
                    readerTemp = SqlAccess.ExecuteReader(sConn, CommandType.Text, sqlBuilder);
                    if (readerTemp.Read())
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            strFreeName = string.Format("fbitFree{0}", i.ToString());
                            fbitFree = Tools.GetBoolColumnValue(readerTemp[strFreeName]);
                            if (fbitFree)
                            {
                                if (configNode == null || configNode.Attributes[string.Format("Free{0}Control", i.ToString())] == null)
                                {
                                    return true;
                                }

                                strFreeControlName = configNode.Attributes[string.Format("Free{0}Control", i.ToString())].Value;

                                if (configNode == null || configNode.Attributes[string.Format("Free{0}ControlType", i.ToString())] == null)
                                {
                                    return true;
                                }

                                strFreeControlType = configNode.Attributes[string.Format("Free{0}ControlType", i.ToString())].Value;

                                controlSource = HandleEvent.FindControl(strFreeControlName, args.HandleEvent.GetDetailForm(sender));
                                strFreeControlValue = HandleEventHelper.GetControlValues(controlSource, strFreeControlType);
                                if (strFreeControlValue != "")
                                {
                                    if (!CheckItemFree(strItemIDControlValue, strFreeControlName, strFreeControlValue))
                                        return true;
                                }
                                else
                                    return true;
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
                finally
                {
                    if (readerTemp != null && !readerTemp.IsClosed)
                        readerTemp.Close();

                    SqlAccess.Close(sConn);
                }
            }
            return false;
        }
        /// <summary>
        /// �жϵ�ǰҪɾ���İ���Ƿ����ڱ�ʹ���ŵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool CheckCurrentlySquad(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            int intCurrentRowIndex = 0;
            DataRow dr = null;
            HandleEvent.FilterEmptyRows(InitFormClass.DGrid);
            DataGrid ParentGrid = InitFormClass.DGrid;
            DataSet ds = ParentGrid.DataSource as DataSet;
            string strSquadID = "";
            if (ds == null)
            {
                return false;
            }
            DataTable dt = ds.Tables["DTDetail"];

            if (dt.Rows.Count == 0)
            {
                RetailMessageBox.ShowExclamation("û����ϸ���ݼ�¼���޷�ɾ����");
                return false;
            }

            // ɾ��������¼	
            intCurrentRowIndex = ParentGrid.CurrentRowIndex;
            dr = eventHandler.DetailRowsindex(dt, intCurrentRowIndex);
            if (HandleEvent.IsEmptyRow(dr))
            {
                return false;
            }
            strSquadID = Tools.GetStringColumnValue(Tools.GetStringSysPara("���ID"));
            if (strSquadID != "")
            {
                if (Tools.GetStringColumnValue(dr["fchrSquadID"]) == strSquadID)
                {
                    RetailMessageBox.ShowExclamation("�õ����ѱ�ʹ�ã��޷�ɾ����");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void ControlSetValue(object sender, ExternalMethodCallArgs args)
        {
            string strWarehouseID = "";
            Control controlSource = null;
            string strControlSourceName = "";
            string strControlSourceType = "";
            string strObjectiveSourceName = "";
            string strObjectiveSourceValueType = "";
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            XmlNode configNode = args.ConfigNode;
            //�õ�ԭ�ؼ�������
            if (configNode == null || configNode.Attributes["ControlSourceName"] == null)
            {
                return;
            }

            strControlSourceName = Tools.GetStringColumnValue(configNode.Attributes["ControlSourceName"].Value);

            //�õ�ԭ�ؼ�������
            if (configNode == null || configNode.Attributes["ControlSourceType"] == null)
            {
                return;
            }

            strControlSourceType = Tools.GetStringColumnValue(configNode.Attributes["ControlSourceType"].Value);

            //�õ�Ŀ��ؼ�������
            if (configNode == null || configNode.Attributes["ObjectiveSourceName"] == null)
            {
                return;
            }

            strObjectiveSourceName = Tools.GetStringColumnValue(configNode.Attributes["ObjectiveSourceName"].Value);

            //�õ�Ŀ��ؼ��ĸ�ֵ����
            if (configNode == null || configNode.Attributes["ObjectiveSourceValueType"] == null)
            {
                return;
            }

            strObjectiveSourceValueType = Tools.GetStringColumnValue(configNode.Attributes["ObjectiveSourceValueType"].Value);


            controlSource = HandleEvent.FindControl(strControlSourceName, eventHandler.InitFormClass.MainForm);
            strWarehouseID = HandleEventHelper.GetControlValues(controlSource, strControlSourceType);
            controlSource = HandleEvent.FindControl(strObjectiveSourceName, eventHandler.InitFormClass.MainForm);
            eventHandler.SetControlProperty(controlSource, strObjectiveSourceValueType, strWarehouseID);
        }
        /// <summary>
        /// ʵ�̵�����ʱ,�����յ���ƷӦΪ�̵�׼�����е���Ʒ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void RealCheckDataControl(object sender, ExternalMethodCallArgs args)
        {
            string strCheckSetoutID = "";
            string strParentCondition = "";
            Control controlSource = null;
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            try
            {
                controlSource = HandleEvent.FindControl("fchrCheckSetoutID", eventHandler.InitFormClass.MainForm);
                strCheckSetoutID = HandleEventHelper.GetControlValues(controlSource, "ExLabel");
                controlSource = HandleEvent.FindControl("����", args.HandleEvent.GetDetailForm(sender));
                if (Tools.GetIntSysPara("CheckInputItemRange") == 1)
                {

                    strParentCondition = string.Format("item.ftinItemModel=1 AND IsNull(item.fbitNoUsed,0)=0 And item.fchrItemID IN (SELECT DISTINCT fchrItemID FROM CheckSetoutDetail WHERE fchrCheckSetoutID='{0}')", strCheckSetoutID);

                }
                else
                {
                    //����ʵ�̵�¼��ʱ��������¼��׼������û�У�������������е���Ʒ��V891���ڲ���
                    //strParentCondition = string.Format("item.ftinItemModel=1 And IsNull(item.fbitNoUsed,0)=0 ");//AND item.fchrItemID IN (SELECT  DISTINCT fchrItemID FROM CheckSetoutDetail WHERE fchrCheckSetoutID='{0}' UNION ALL SELECT  DISTINCT fchrItemID FROM Item WHERE fchrItemID NOT IN (SELECT DISTINCT fchrItemID FROM ItemStocks))", strCheckSetoutID);

                    string strSQL = "TRUNCATE TABLE TempItem;";
                    strSQL = strSQL + string.Format("INSERT INTO TempItem SELECT DISTINCT fchrItemID FROM CheckSetoutDetail WHERE fchrCheckSetoutID='{0}' UNION ALL SELECT DISTINCT fchrItemID FROM Item WHERE fchrItemID NOT IN (SELECT DISTINCT fchrItemID FROM ItemStocks);", strCheckSetoutID);
                    SqlAccess.ExecuteNonQuery(SysPara.GetSysPara("SysConn").ToString(), CommandType.Text, strSQL);

                    strParentCondition = string.Format("item.ftinItemModel=1 And IsNull(item.fbitNoUsed,0)=0 AND (item.fchrItemID IN (SELECT fchrItemID FROM TempItem ))", strCheckSetoutID);
                }
                eventHandler.SetControlProperty(controlSource, "ParentCondition", strParentCondition);
            }
            catch (Exception ex)
            {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }



        public bool CheckItemBitFree(string strItemID, string strFreeName)
        {
            string strSQL = "";
            int intFreeNumber = 0;
            SqlConnection sConn = new SqlConnection();
            sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
            try
            {

                strSQL = string.Format("Select {0} AS Free FROM Item WHERE fchrItemID='{1}'", strFreeName, strItemID);


                object oTemp = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL);
                if (oTemp != null)
                    intFreeNumber = Tools.GetIntColumnValue(oTemp);
                else
                    intFreeNumber = 0;

                if (intFreeNumber == 0)
                    return false;
                else
                    return true;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool JudgeClearBill(object sender, ExternalMethodCallArgs args)
        {
            if (DialogResult.No == RetailMessageBox.ShowQuestion("��ȷ����ձ�����Ʒ����", MessageBoxDefaultButton.Button2))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public bool CheckItemBatchCode(object sender, ExternalMethodCallArgs args)
        {
            string strControlName = "";
            string strError = "";
            string strItemID = "";
            string strItemCode = "";
            string strItemName = "";
            string strBatchCode = "";
            string strProduceDate = "";
            string strFreeValue = "";
            string strFreeControlName = "";
            string strFreeControlType = "";
            string strSQL = "";
            int intNoteNumber = 0;
            int intCurrentRowIndex = 0;
            bool bolISNotBatchCode = false;
            bool bolISNotProduceDate = false;
            SqlConnection sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
            XmlNode configNode = args.ConfigNode;
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;

            DataGrid ParentGrid = InitFormClass.DGrid;
            DataSet ds = ParentGrid.DataSource as DataSet;
            DataTable dt = new DataTable();
            intCurrentRowIndex = 0;

            if (!Tools.GetBoolSysPara("ProductManageType"))
                return true;

            if (ds.Tables.Contains("DTDetail"))
            {
                dt = ds.Tables["DTDetail"].Copy();
                dt.AcceptChanges();
                foreach (DataRow sRow in ds.Tables["DTDetail"].Rows)
                {

                    if (sRow.RowState != DataRowState.Deleted)
                    {
                        intCurrentRowIndex++;

                        ParentGrid.UnSelect(intCurrentRowIndex - 1);
                        //�õ���Ʒ��ID
                        if (configNode == null || configNode.Attributes["ItemIDControl"] == null)
                        {
                            return false;
                        }

                        strControlName = Tools.GetStringColumnValue(configNode.Attributes["ItemIDControl"].Value);

                        strItemID = Tools.GetStringColumnValue(sRow[strControlName]);


                        strSQL = string.Format("SELECT COUNT(*) AS NoteNumber FROM ITEMSTOCKS WHERE fchrItemID='{0}' ", strItemID);

                        // �õ���Ʒ�ı���

                        if (configNode == null || configNode.Attributes["ItemCodeControl"] == null)
                        {
                            return false;
                        }

                        strControlName = Tools.GetStringColumnValue(configNode.Attributes["ItemCodeControl"].Value);

                        strItemCode = Tools.GetStringColumnValue(sRow[strControlName]);

                        // �õ���Ʒ������

                        if (configNode == null || configNode.Attributes["ItemNameControl"] == null)
                        {
                            return false;
                        }

                        strControlName = Tools.GetStringColumnValue(configNode.Attributes["ItemNameControl"].Value);

                        strItemName = Tools.GetStringColumnValue(sRow[strControlName]);

                        //�õ���Ʒ������
                        if (configNode == null || configNode.Attributes["BatchCodeControl"] == null)
                        {
                            return false;
                        }

                        strControlName = Tools.GetStringColumnValue(configNode.Attributes["BatchCodeControl"].Value);


                        strBatchCode = Tools.GetStringColumnValue(sRow[strControlName]);


                        strError = string.Format("��Ʒ��{0}��{1}��������Ч�����ţ�", strItemCode, strItemName);

                        //   �ж���Ʒ�Ƿ������ι����
                        if (CheckItemBitFree(strItemID, "fbitBatch"))
                        {
                            bolISNotBatchCode = false;
                            //   �����,û¼����  ����
                            if (strBatchCode == "")
                            {

                                RetailMessageBox.ShowExclamation(strError);
                                ParentGrid.Select(intCurrentRowIndex - 1);
                                ParentGrid.CurrentRowIndex = intCurrentRowIndex - 1;
                                return false;
                            }

                        }
                        else
                        {
                            bolISNotBatchCode = true;
                            //   ����¼������  ����
                            if (strBatchCode != "")
                            {
                                RetailMessageBox.ShowExclamation(strError);
                                ParentGrid.Select(intCurrentRowIndex - 1);
                                ParentGrid.CurrentRowIndex = intCurrentRowIndex - 1;
                                return false;
                            }
                        }

                        if (!bolISNotBatchCode)
                        {
                            if (strBatchCode != "")
                                strSQL = string.Format("{0} AND fchrBatchCode='{1}' ", strSQL, strBatchCode);
                            else
                                strSQL = string.Format("{0} AND ISNULL(fchrBatchCode,'')='' ", strSQL);
                        }
                        //�õ���Ʒ����������
                        if (configNode == null || configNode.Attributes["ProduceDateControl"] == null)
                        {
                            return false;
                        }

                        strControlName = Tools.GetStringColumnValue(configNode.Attributes["ProduceDateControl"].Value);

                        if (Tools.GetStringColumnValue(sRow[strControlName]) != "")
                            strProduceDate = Convert.ToDateTime(Tools.GetStringColumnValue(sRow[strControlName])).ToString("yyyy-MM-dd");
                        else
                            strProduceDate = "";

                        strError = string.Format("��Ʒ��{0}��{1}����������Ч�����ڣ�", strItemCode, strItemName);

                        if (CheckItemBitFree(strItemID, "fbitValidDay"))
                        {
                            bolISNotProduceDate = false;
                            if (strProduceDate == "")
                            {
                                RetailMessageBox.ShowExclamation(strError);
                                ParentGrid.Select(intCurrentRowIndex - 1);
                                ParentGrid.CurrentRowIndex = intCurrentRowIndex - 1;
                                return false;
                            }

                        }
                        else
                        {
                            bolISNotProduceDate = true;
                            if (strProduceDate != "")
                            {
                                RetailMessageBox.ShowExclamation(strError);
                                ParentGrid.Select(intCurrentRowIndex - 1);
                                ParentGrid.CurrentRowIndex = intCurrentRowIndex - 1;
                                return false;
                            }
                        }
                        if (!bolISNotProduceDate)
                        {
                            if (strProduceDate != "")
                                strSQL = string.Format("{0} AND CONVERT(VARCHAR(10),fdtmProduceDate,121) ='{1}' ", strSQL, strProduceDate);
                            else
                                strSQL = string.Format("{0} AND ISNULL(fdtmProduceDate,'')='' ", strSQL);
                        }
                        if (bolISNotProduceDate && bolISNotBatchCode)
                            return true;
                        //�õ���Ʒ����������Ϣ
                        for (int i = 1; i <= 10; i++)
                        {

                            strFreeControlName = "Free" + i.ToString() + "Control";
                            strFreeControlType = "Free" + i.ToString() + "ControlType";
                            if (CheckItemBitFree(strItemID, "fbitfree" + i.ToString()))
                            {

                                if (configNode == null || configNode.Attributes[strFreeControlName] == null)
                                {
                                    return false;
                                }

                                strControlName = Tools.GetStringColumnValue(configNode.Attributes[strFreeControlName].Value);

                                strFreeValue = Tools.GetStringColumnValue(sRow[strControlName]);

                                if (strFreeValue != "")
                                    strSQL = string.Format("{0} AND fchrfree{1} ='{2}' ", strSQL, i.ToString(), strFreeValue);
                                else
                                    strSQL = string.Format("{0} AND fchrfree{1} ='' ", strSQL, i.ToString());
                            }
                        }

                        try
                        {
                            // ��ѯ���ݿ⣬�Ƿ���ڼ�¼
                            object oTemp = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL);
                            if (oTemp != null)
                                intNoteNumber = Tools.GetIntColumnValue(oTemp);
                            else
                                intNoteNumber = 0;
                        }
                        catch
                        {
                            intNoteNumber = 0;
                        }
                        finally
                        {

                        }
                        if (intNoteNumber == 0)
                        {
                            if (!bolISNotProduceDate)
                            {
                                if (!bolISNotBatchCode)
                                    strError = string.Format("��Ʒ��{0}��{1}����������Ч�����ź����ڣ�", strItemCode, strItemName);
                                else
                                    strError = string.Format("��Ʒ��{0}��{1}����������Ч�����ڣ�", strItemCode, strItemName);
                            }
                            else
                                strError = string.Format("��Ʒ��{0}��{1}����������Ч�����ţ�", strItemCode, strItemName);

                            RetailMessageBox.ShowExclamation(strError);
                            ParentGrid.Select(intCurrentRowIndex - 1);
                            ParentGrid.CurrentRowIndex = intCurrentRowIndex - 1;
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool CheckItemStocks(object sender, ExternalMethodCallArgs args)
        {
            double douQuantity = 0;
            double douItemStocksQuantity = 0;
            double douItemSaleQuantity = 0;
            int intCurrentRowIndex = 0;
            string strItemID = "";
            string strBatchCode = "";
            string strProduceDate = "";
            string strFreeValue;
            string strItemCode = "";
            string strItemName = "";
            string strSQL = "";
            string strSQL2 = "";
            string strError = "";
            string strControlName = "";
            string strBitName = "";
            string strName = "";
            string strTemp = "";
            string strSQL3 = "";
            string strSQL4 = "";
            string strPositionID = "";
            string strPositionName = "";

            string strQuantityName = "";
            bool bolExistFree = false;
            bool bolIsEditBill = false;
            string strControlType = "";
            Control controlSource = null;
            string strBillID = "";
            DataRow[] foundRows = null;
            XmlNode configNode = args.ConfigNode;
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            SqlConnection sConn = new SqlConnection();
            DataGrid ParentGrid = InitFormClass.DGrid;
            sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
            DataSet ds = ParentGrid.DataSource as DataSet;
            DataTable dt = new DataTable();
            intCurrentRowIndex = 0;
            if (!Tools.GetBoolSysPara("IsCheckItemStocks"))
            {
                if (ds.Tables.Contains("DTDetail"))
                {
                    dt = ds.Tables["DTDetail"].Copy();
                    dt.AcceptChanges();
                    foreach (DataRow sRow in ds.Tables["DTDetail"].Rows)
                    {

                        if (sRow.RowState != DataRowState.Deleted)
                        {
                            intCurrentRowIndex++;
                            strSQL = "";
                            strSQL2 = "";
                            strSQL3 = "";

                            strError = "";
                            bolExistFree = false;

                            ParentGrid.UnSelect(intCurrentRowIndex - 1);
                            //����������Բ����ڣ��򲻼��
                            if (configNode == null || configNode.Attributes["QuantityControl"] == null)
                            {
                                return false;
                            }

                            strQuantityName = Tools.GetStringColumnValue(configNode.Attributes["QuantityControl"].Value);

                            douQuantity = Tools.GetDblColumnValue(sRow[strQuantityName]);

                            if (douQuantity > 0)
                            {

                                if (configNode == null || configNode.Attributes["IsEdit"] == null)
                                {
                                    return false;
                                }

                                bolIsEditBill = Tools.GetBoolColumnValue(configNode.Attributes["IsEdit"].Value);

                                //�����Ʒ�������Բ����ڣ��򲻼��
                                if (configNode == null || configNode.Attributes["ItemNameControl"] == null)
                                {
                                    return false;
                                }

                                strControlName = Tools.GetStringColumnValue(configNode.Attributes["ItemNameControl"].Value);
                                strItemName = Tools.GetStringColumnValue(sRow[strControlName]);

                                //�����Ʒ�������Բ����ڣ��򲻼��
                                if (configNode == null || configNode.Attributes["ItemCodeControl"] == null)
                                {
                                    return false;
                                }
                                strControlName = Tools.GetStringColumnValue(configNode.Attributes["ItemCodeControl"].Value);
                                strItemCode = Tools.GetStringColumnValue(sRow[strControlName]);


                                //�����ƷID���Բ����ڣ��򲻼��
                                if (configNode == null || configNode.Attributes["ItemIDControl"] == null)
                                {
                                    return false;
                                }

                                strControlName = Tools.GetStringColumnValue(configNode.Attributes["ItemIDControl"].Value);

                                strItemID = Tools.GetStringColumnValue(sRow["fchritemid"]);

                                strTemp = string.Format("{0} ='{1}'", strControlName, strItemID);
                                strSQL3 = strTemp;


                                //�����Ʒ�������Բ����ڣ��򲻼��
                                if (configNode == null || configNode.Attributes["BatchCodeControl"] == null)
                                {
                                    return false;
                                }

                                strControlName = Tools.GetStringColumnValue(configNode.Attributes["BatchCodeControl"].Value);

                                strBatchCode = "";
                                if (sRow.Table.Columns.IndexOf(strControlName) != -1)
                                    strBatchCode = Tools.GetStringColumnValue(sRow[strControlName]);


                                strTemp = string.Format("ISNULL({0},'') ='{1}'", strControlName, strBatchCode);
                                strSQL3 = string.Format("{0} AND {1}", strSQL3, strTemp);


                                //�����Ʒ��Ч�������Բ����ڣ��򲻼��
                                if (configNode == null || configNode.Attributes["ProduceDateControl"] == null)
                                {
                                    return false;
                                }

                                strControlName = Tools.GetStringColumnValue(configNode.Attributes["ProduceDateControl"].Value);

                                strProduceDate = "";
                                if (sRow.Table.Columns.IndexOf(strControlName) != -1)
                                    strProduceDate = Tools.GetStringColumnValue(sRow[strControlName]);

                                if (strProduceDate != "")
                                {
                                    strTemp = string.Format("ISNULL({0},'') ='{1}'", strControlName, strProduceDate);
                                    strSQL3 = string.Format("{0} AND {1}", strSQL3, strTemp);
                                }
                                else
                                {
                                    strSQL3 = string.Format("{0} AND (fdtmproducedate ='' OR fdtmproducedate Is NULL)", strSQL3);
                                }

                                //׷�ӻ�λ��V8.91, libo, 2010-02-01
                                //ȡ�û�λ
                                if (configNode != null && configNode.Attributes["PositionIDControl"] != null)
                                {
                                    strControlName = Tools.GetStringColumnValue(configNode.Attributes["PositionIDControl"].Value);

                                    strPositionID = "";
                                    if (sRow.Table.Columns.IndexOf(strControlName) != -1)
                                        strPositionID = Tools.GetStringColumnValue(sRow[strControlName]);

                                    //�жϵ���Ʒ��Ϊ����Ʒ+������+����+��������/��Ч����+��λ�� V8.91, libo, 2010-02-01  
                                    if (string.IsNullOrEmpty(strPositionID))
                                    {
                                        strTemp = string.Format("({0} IS NULL OR {0}='')", strControlName);
                                        strSQL3 = string.Format("{0} AND {1}", strSQL3, strTemp);
                                    } 
                                    else
                                    {
                                        strTemp = string.Format("{0} ='{1}'", strControlName, strPositionID);
                                        strSQL3 = string.Format("{0} AND {1}", strSQL3, strTemp);
                                    }
                                }

                                //ȡ�û�λ����
                                if (configNode != null && configNode.Attributes["PositionNameControl"] != null)
                                {
                                    strControlName = Tools.GetStringColumnValue(configNode.Attributes["PositionNameControl"].Value);
                                    strPositionName = Tools.GetStringColumnValue(sRow[strControlName]);
                                }

                                strSQL = string.Format("SELECT flotQuantity FROM ITEMSTOCKS WHERE fchrItemID='{0}'", strItemID);
                                //�޸�ȡ����Ʒ������.V891һ�ڲ���
                                //strSQL2 = "SELECT SUM(flotQuantity) as flotQuantity  FROM viewRetailVouchDetail  ";
                                //strSQL2 = strSQL2 + "  WHERE  IsNull(ftinPayment,0)<>2 ";
                                //strSQL2 = strSQL2 + string.Format(" AND fbitNegative=0 AND fchrItemID='{0}'", strItemID);

                                strSQL = string.Format("{0} AND ISNULL(fchrBatchCode,'')='{1}'", strSQL, strBatchCode);
                                strSQL2 = string.Format("{0} AND ISNULL(fchrBatchCode,'')='{1}'", strSQL2, strBatchCode);


                                if (strProduceDate != "")
                                {
                                    strSQL = string.Format("{0} AND ISNULL(convert(varchar(10),fdtmProduceDate,121) ,'')=convert(varchar(10),cast ('{1}' as datetime),121)", strSQL, strProduceDate);
                                    strSQL2 = string.Format("{0} AND ISNULL(convert(varchar(10),fdtmProduceDate,121) ,'')=convert(varchar(10),cast ('{1}' as datetime),121)", strSQL2, strProduceDate);
                                }
                                else
                                {
                                    strSQL = string.Format("{0} AND ISNULL(fdtmProduceDate ,'')=''", strSQL);
                                    strSQL2 = string.Format("{0} AND ISNULL(fdtmProduceDate,'')=''", strSQL2);
                                }

                                //�жϵ���Ʒ��Ϊ����Ʒ+������+����+��������/��Ч����+��λ�� V8.91, libo, 2010-02-01  
                                if (string.IsNullOrEmpty(strPositionID))
                                {
                                    strSQL = string.Format("{0} AND fchrPosID IS NULL", strSQL);
                                    strSQL2 = string.Format("{0} AND fchrPosID IS NULL", strSQL2);
                                }
                                else
                                {
                                    strSQL = string.Format("{0} AND fchrPosID ='{1}'", strSQL, strPositionID);
                                    strSQL2 = string.Format("{0} AND fchrPosID ='{1}'", strSQL2, strPositionID);
                                }

                                //�ж���Ʒ��������
                                for (int i = 1; i <= 10; i++)
                                {
                                    strBitName = "fbitfree" + i.ToString();
                                    strName = "fchrfree" + i.ToString();

                                    if (CheckItemBitFree(strItemID, strBitName))
                                    {
                                        if (sRow.Table.Columns.IndexOf(strName) != -1)
                                        {
                                            bolExistFree = true;
                                            strFreeValue = Tools.GetStringColumnValue(sRow[strName]);
                                            strSQL = string.Format("{0} AND fchrFree{1}='{2}'", strSQL, i.ToString(), strFreeValue);
                                            strSQL2 = string.Format("{0} AND fchrFree{1}='{2}'", strSQL2, i.ToString(), strFreeValue);
                                            if (strError == "")
                                                strError = strFreeValue;
                                            else
                                                strError = string.Format("{0}��{1}", strError, strFreeValue);
                                            strTemp = string.Format("{0} ='{1}'", strName, strFreeValue);
                                            strSQL3 = string.Format("{0} AND {1}", strSQL3, strTemp);
                                        }
                                    }
                                }

                                foundRows = dt.Select(strSQL3);


                                // ������������Ʒ��Ϣ��ͬ��������������
                                douQuantity = 0;
                                foreach (DataRow rRow in foundRows)
                                {
                                    if (rRow.RowState != DataRowState.Deleted)
                                    {
                                        douQuantity = douQuantity + Tools.GetDblColumnValue(rRow[strQuantityName]);
                                    }
                                }

                                // �����Ƿ��Ǳ༭��״̬,����Ǳ༭��״̬,��Ҫ��ԭ���������׳���
                                if (bolIsEditBill)
                                {
                                    //�õ����ݵ�ID
                                    if (configNode == null || configNode.Attributes["BillIDControl"] == null)
                                    {
                                        return false;
                                    }

                                    strControlName = Tools.GetStringColumnValue(configNode.Attributes["BillIDControl"].Value);

                                    controlSource = HandleEvent.FindControl(strControlName, InitFormClass.MainForm);

                                    //�����Ʒ��Ч�������Բ����ڣ��򲻼��
                                    if (configNode == null || configNode.Attributes["BillIDControlType"] == null)
                                    {
                                        return false;
                                    }

                                    strControlType = Tools.GetStringColumnValue(configNode.Attributes["BillIDControlType"].Value);


                                    strBillID = HandleEventHelper.GetControlValues(controlSource, strControlType);


                                    //������������������Ȳ�ѯ�ǲ���ֻ����Ʒ������
                                    strSQL4 = string.Format("SELECT fchrItemID,cast(fdtmProduceDate as datetime) as fdtmProduceDate,flotQuantity,fchrFree1,fchrFree3,fchrFree4,"
                                        + " fchrFree5,fchrFree6,fchrFree2,fchrFree7,fchrFree8,fchrFree9,fchrFree10,ISNULL(fchrBatchCode,'') as fchrBatchCode,fchrPosID "
                                        + " FROM viewInOutVouchDetail WHERE  fchrInOutVouchID='{0}' and IsNull(fbitTempSave,0)=0 ", strBillID);
                                    DataSet ds1 = new DataSet();
                                    SqlAccess.FillDataset(sConn, CommandType.Text, strSQL4, ds1, "Detail");
                                    DataTable dt2 = new DataTable();
                                    dt2 = ds1.Tables["Detail"];
                                    DataRow[] foundRows2 = dt2.Select(strSQL3);

                                    foreach (DataRow rRow2 in foundRows2)
                                    {
                                        if (rRow2.RowState != DataRowState.Deleted)
                                        {
                                            douQuantity = douQuantity - Tools.GetDblColumnValue(rRow2["flotQuantity"]);
                                        }
                                    }
                                    //									if (douQuantity<=0)
                                    //										continue;
                                }


                                object oTemp = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL);
                                if (oTemp != null)
                                {
                                    douItemStocksQuantity = Tools.GetDblColumnValue(oTemp.ToString());
                                }
                                else
                                    douItemStocksQuantity = 0;

                                if (!bolIsEditBill)
                                {
                                    if (douItemStocksQuantity <= 0)
                                    {
                                        if (bolExistFree)
                                            strError = string.Format("��{0}��{1}��{2}���Ŀ��������㣡", strItemCode, strItemName, strError);
                                        else
                                            strError = string.Format("��{0}��{1}�Ŀ��������㣡", strItemCode, strItemName);

                                        //���û�λ����ʱ��ʾ��ʾ[��λ����]��ʾ ��V8.91, libo, 2010-02-01
                                        if (SysPara.IsPosManage())
                                        {
                                            if (string.IsNullOrEmpty(strPositionID))
                                            {
                                                strError = string.Format("�ջ�λ��{1}", strPositionName, strError);
                                            }
                                            else
                                            {
                                                strError = string.Format("[{0}]{1}", strPositionName, strError);
                                            }
                                        }
                                        RetailMessageBox.ShowExclamation(strError);

                                        for (int j = 0; j < dt.Rows.Count; j++)
                                        {
                                            if (dt.Rows[j].RowState != DataRowState.Deleted && dt.Rows[j].RowState != DataRowState.Detached)
                                            {
                                                ParentGrid.UnSelect(j);
                                            }
                                        }
                                        ParentGrid.Select(intCurrentRowIndex - 1);
                                        ParentGrid.CurrentRowIndex = intCurrentRowIndex - 1;
                                        return false;
                                    }
                                }
                                //�޸�ȡ����Ʒ������.V891һ�ڲ���
                                //object oTemp2 = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL2);
                                //if (oTemp2 != null)
                                //{
                                //    douItemSaleQuantity = Tools.GetDblColumnValue(oTemp2.ToString());
                                //}
                                //else
                                //    douItemSaleQuantity = 0;

                                //double TempDouble = douItemStocksQuantity - douItemSaleQuantity;
                                double TempDouble = BusinessHelper.GetUseQuantity(strItemID, strSQL2);
                                if (Tools.GetDblColumnValue(douQuantity.ToString(SysPara.FormatQuantity())) > Tools.GetDblColumnValue(TempDouble.ToString(SysPara.FormatQuantity())))
                                {
                                    if (bolExistFree)
                                        strError = string.Format("��{0}��{1}��{2}���Ŀ��������㣡", strItemCode, strItemName, strError);
                                    else
                                        strError = string.Format("��{0}��{1}�Ŀ��������㣡", strItemCode, strItemName);

                                    //���û�λ����ʱ��ʾ��ʾ[��λ����]��ʾ ��V8.91, libo, 2010-02-01
                                    if (SysPara.IsPosManage())
                                    {
                                        if (string.IsNullOrEmpty(strPositionID))
                                        {
                                            strError = string.Format("�ջ�λ��{1}", strPositionName, strError);
                                        }
                                        else
                                        {
                                            strError = string.Format("[{0}]{1}", strPositionName, strError);
                                        }
                                    }
                                    RetailMessageBox.ShowExclamation(strError);
                                    for (int j = 0; j < dt.Rows.Count; j++)
                                    {
                                        if (dt.Rows[j].RowState != DataRowState.Deleted && dt.Rows[j].RowState != DataRowState.Detached)
                                        {
                                            ParentGrid.UnSelect(j);
                                        }
                                    }
                                    ParentGrid.Select(intCurrentRowIndex - 1);
                                    ParentGrid.CurrentRowIndex = intCurrentRowIndex - 1;
                                    return false;
                                }
                            }
                        }
                    }
                }
                else
                    return false;
            }
            return true;
        }

        /// <summary>
        /// ��������У��ж��Ƿ���С��0��ֵ
        /// </summary>
        /// <returns></returns>
        public bool RealCheckQuantity(object sender, ExternalMethodCallArgs args)
        {
            XmlNode configNode = args.ConfigNode;
            //	DataTable detailTable = args.HandleEvent.GetDetailTable();
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;

            string quantityColumnName = "";
            string ItemCodeColumnName = "";
            string ItemNameColumnName = "";

            string ItemCodeValue = "";
            string ItemNameValue = "";

            string strError = "";
            int intCurrentRowIndex = 0;
            //���QuantityColumnName���Բ����ڣ��򲻼��
            if (configNode == null || configNode.Attributes["QuantityColumnName"] == null)
            {
                return true;
            }
            quantityColumnName = configNode.Attributes["QuantityColumnName"].Value;

            //���ItemCodeColumnName���Բ����ڣ��򲻼��
            if (configNode == null || configNode.Attributes["ItemCodeColumnName"] == null)
            {
                return true;
            }
            ItemCodeColumnName = configNode.Attributes["ItemCodeColumnName"].Value;

            //���ItemNameColumnName���Բ����ڣ��򲻼��
            if (configNode == null || configNode.Attributes["ItemNameColumnName"] == null)
            {
                return true;
            }
            ItemNameColumnName = configNode.Attributes["ItemNameColumnName"].Value;

            DataGrid ParentGrid = InitFormClass.DGrid;
            DataSet ds = ParentGrid.DataSource as DataSet;

            if (ds == null)
            {
                return false;
            }
            DataTable detailTable = ds.Tables["DTDetail"];
            intCurrentRowIndex = 0;
            foreach (DataRow dr in detailTable.Rows)
            {
                try
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        intCurrentRowIndex++;
                        double quantity = Tools.GetDblColumnValue(dr[quantityColumnName]);
                        if (quantity < 0)
                        {
                            ItemCodeValue = Tools.GetStringColumnValue(dr[ItemCodeColumnName]);
                            ItemNameValue = Tools.GetStringColumnValue(dr[ItemNameColumnName]);
                            strError = string.Format("��{0}��{1}��ʵ������С��0�����ܱ��棡 ", ItemCodeValue, ItemNameValue);
                            RetailMessageBox.ShowExclamation(strError);

                            ParentGrid.Select(intCurrentRowIndex - 1);
                            ParentGrid.CurrentRowIndex = intCurrentRowIndex - 1;
                            return false;
                        }

                    }
                }
                finally
                {
                }
            }
            return true;
        }


        /// <summary>
        /// �����̵�׼��������Ӧ��ʵ�̵�����Ʒ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public void BackCheckQuantity(object sender, ExternalMethodCallArgs args)
        {
            string fchrCheckSetoutID = "";
            string strSQL = "";
            SqlConnection sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
            Control controlSource = null;
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            DataTable detailTable = args.HandleEvent.GetDetailTable();

            //   �õ��̵�׼������ID
            controlSource = HandleEvent.FindControl("fchrCheckSetoutID", eventHandler.InitFormClass.MainForm);
            fchrCheckSetoutID = HandleEventHelper.GetControlValues(controlSource, "ExLabel");
            foreach (DataRow dr in detailTable.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    try
                    {
                        strSQL = string.Format("SELECT SUM(flotQuantity) FROM RealStocks,RealStocksDetail " +
                            " Where RealStocks.fchrRealStocksID=RealStocksDetail.fchrRealStocksID" +
                            " AND RealStocks.fchrCheckSetoutID = '{0}' " +
                            " AND RealStocksDetail.fchrItemID='{1}' " +
                            " AND ISNULL(RealStocksDetail.fchrFree1,'')=ISNULL('{2}','')  " +
                            " AND ISNULL(RealStocksDetail.fchrFree2,'')=ISNULL('{3}','') " +
                            " AND ISNULL(RealStocksDetail.fchrFree3,'')=ISNULL('{4}','') " +
                            " AND ISNULL(RealStocksDetail.fchrFree4,'')=ISNULL('{5}','') " +
                            " AND ISNULL(RealStocksDetail.fchrFree5,'')=ISNULL('{6}','') " +
                            " AND ISNULL(RealStocksDetail.fchrFree6,'')=ISNULL('{7}','') " +
                            " AND ISNULL(RealStocksDetail.fchrFree7,'')=ISNULL('{8}','') " +
                            " AND ISNULL(RealStocksDetail.fchrFree8,'')=ISNULL('{9}','') " +
                            " AND ISNULL(RealStocksDetail.fchrFree9,'')=ISNULL('{10}','') " +
                            " AND ISNULL(RealStocksDetail.fchrFree10,'')=ISNULL('{11}','')" +
                            " AND ISNULL(RealStocksDetail.fchrBatchCode,'')=ISNULL('{12}','') " +
                            " AND ISNULL(RealStocksDetail.fdtmProduceDate,'')=ISNULL('{13}','')",
                            fchrCheckSetoutID,
                            Tools.GetStringColumnValue(dr["fchrItemID"]),
                            Tools.GetStringColumnValue(dr["fchrFree1"]),
                            Tools.GetStringColumnValue(dr["fchrFree2"]),
                            Tools.GetStringColumnValue(dr["fchrFree3"]),
                            Tools.GetStringColumnValue(dr["fchrFree4"]),
                            Tools.GetStringColumnValue(dr["fchrFree5"]),
                            Tools.GetStringColumnValue(dr["fchrFree6"]),
                            Tools.GetStringColumnValue(dr["fchrFree7"]),
                            Tools.GetStringColumnValue(dr["fchrFree8"]),
                            Tools.GetStringColumnValue(dr["fchrFree9"]),
                            Tools.GetStringColumnValue(dr["fchrFree10"]),
                            Tools.GetStringColumnValue(dr["fchrBatchCode"]),
                            Tools.GetStringColumnValue(dr["fdtmProduceDate"]));
                        object oTemp = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL);
                        if (oTemp != null)
                            dr["flotInputQuantity"] = Tools.GetDblColumnValue(oTemp);
                        else
                            dr["flotInputQuantity"] = "0";
                    }
                    catch (SqlException ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                        dr["flotInputQuantity"] = "0";
                    }
                    finally
                    {

                    }
                }
            }
            args.HandleEvent.CalGridTotal(detailTable);
        }



        /// <summary>
        /// �����Ʒ�������Ƿ���пյļ�¼
        /// </summary>
        /// <remarks>Modified by dailu, 2007-10-16</remarks>
        /// <returns></returns>
        public bool CheckQuantityISNULL(object sender, ExternalMethodCallArgs args)
        {
            DataGrid ParentGrid = ((PageGrid)args.HandleEvent.InitFormClass.ListGrid).DBGrid as DataGrid;
            DataSet dsGrid = ParentGrid.DataSource as DataSet;
            DataTable detailTable = dsGrid.Tables["DTDetail"].Copy();
            detailTable.AcceptChanges();
            if (ParentGrid.CurrentRowIndex < 0)
            {
                return true;
            }
            if (detailTable.Rows.Count == 0)
            {
                return true;
            }
            string checkSetOutId = Tools.GetStringColumnValue(detailTable.Rows[ParentGrid.CurrentRowIndex]["fchrCheckSetOutId"]);
            try
            {
                SqlParameter sqlParameterCheckSetOutId = new SqlParameter("@fchrCheckSetOutId", SqlDbType.NVarChar, 100);
                sqlParameterCheckSetOutId.Value = checkSetOutId;
                SqlParameter sqlParameterBackError = new SqlParameter("@BackError", SqlDbType.NVarChar, 100);
                sqlParameterBackError.Direction = ParameterDirection.Output;
                SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.StoredProcedure, "procCheckQuantityISNULL", new SqlParameter[] { sqlParameterCheckSetOutId, sqlParameterBackError });
                string strError = Tools.GetStringColumnValue(sqlParameterBackError.Value);

                if (strError != "")
                {
                    RetailMessageBox.ShowExclamation(strError + "��ʵ�̵��д�������Ϊ�յ���Ʒ�У���¼��ʵ������");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// ������ⵥ�ĵ�����ϸ���Ƿ���װ�䷽ʽ�ļ�¼
        /// </summary>
        /// <returns></returns>
        public bool CheckISTrunk(object sender, ExternalMethodCallArgs args)
        {
            DataGrid ParentGrid = args.HandleEvent.GetDataGrid();
            DataSet dsGrid = ParentGrid.DataSource as DataSet;
            DataTable detailTable = dsGrid.Tables["DTDetail"];
            int intCurrIndex = ParentGrid.CurrentRowIndex;
            DataRow dr = null;
            string strTrunkID = "";
            DataGridNumericColumnStyleBeginEditEventArgs dargs = args.HandleEvent.EventArgs as DataGridNumericColumnStyleBeginEditEventArgs;


            if (detailTable.Rows.Count > 0)
            {
                try
                {
                    dr = detailTable.Rows[intCurrIndex];
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        strTrunkID = Tools.GetStringColumnValue(dr["fchrTrunkID"]);
                        if (strTrunkID != "")
                        {
                            dargs.Cancel = true;
                            return true;
                        }
                        else
                        {
                            dargs.Cancel = false;
                            return false;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// �õ�ʵ�̵�������
        /// </summary>
        /// <param name="strRealCheckID"></param>
        /// <returns></returns>
        private string GetRealCheckDate(string strRealCheckID)
        {


            string strSQL = "";
            string strRealCheckDate = "";
            SqlConnection sConn = new SqlConnection();
            sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
            try
            {

                strSQL = string.Format("Select fdtmDate FROM RealStocks WHERE fchrRealStocksID='{0}'", strRealCheckID);


                object oTemp = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL);
                if (oTemp != null)
                    strRealCheckDate = Tools.GetStringColumnValue(oTemp);
                else
                    strRealCheckDate = Tools.GetStringColumnValue(DateTime.Now.ToString("yyyy-MM-dd"));


            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);

            }
            return strRealCheckDate;
        }

        /// <summary>
        /// �ж��̵�׼�����Ƿ��Ѿ������˹�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool CheckSetoutCodeIsCheck(object sender, ExternalMethodCallArgs args)
        {
            string strCheckSetoutID = "";
            string sqlBuilder = "";
            bool fbitCheck = true;
            bool bosExistError = false;
            Control controlSource = null;
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            IDataReader readerTemp = null;
            try
            {
                controlSource = HandleEvent.FindControl("fchrCheckSetoutID", eventHandler.InitFormClass.MainForm);
                strCheckSetoutID = HandleEventHelper.GetControlValues(controlSource, "ExLabel");
                sqlBuilder = string.Format("SELECT fbitCheck AS Value  from CheckSetout Where  fchrCheckSetoutID='{0}'", strCheckSetoutID);

                SqlConnection sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());

                readerTemp = SqlAccess.ExecuteReader(sConn, CommandType.Text, sqlBuilder);
                if (readerTemp.Read())
                {
                    fbitCheck = Tools.GetBoolColumnValue(readerTemp["Value"]);
                    if (fbitCheck)
                    {
                        RetailMessageBox.ShowExclamation("��Ӧ���̵�׼�����ѱ����ˣ��������棡");
                        bosExistError = true;
                    }

                }
                else
                {
                    bosExistError = true;
                }
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (readerTemp != null)
                    readerTemp.Close();

            }
            if (bosExistError)
                return false;
            else
                return true;
        }

        /// <summary>
        /// �ж�һ���̵�׼�����Ƿ��Ѿ�����һ�Ż���ŵ�ʵ�̵�,
        /// ���һ���̵�׼�����Ƿ��Ѿ����ڶ��ŵ�ʵ�̵�,�ǾͲ����ٱ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool InputCheckBill(object sender, ExternalMethodCallArgs args)
        {
            Control controlSource = null;
            string strCheckRealID = "";
            string strCheckSetoutID = "";
            string strCheckRealName = "";
            string strBackMultiInput = "";
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;

            controlSource = HandleEvent.FindControl("fchrRealStocksID", eventHandler.InitFormClass.MainForm);
            strCheckSetoutID = HandleEventHelper.GetControlValues(controlSource, "ExLabel");
            if (strCheckSetoutID != "")
            {
                if (CheckRealBillIsMulti(sender, args, ref strCheckRealID, ref strCheckRealName, ref strBackMultiInput))
                {
                    RetailMessageBox.ShowExclamation("��ѡ�̵�׼�����Ѵ��ڶ��Ŷ�Ӧ��ʵ�̵����������棡");
                    return false;
                }
                if (strCheckSetoutID == "")
                {

                    DataTable detailTable = args.HandleEvent.GetDetailTable();

                    foreach (DataRow oRow in detailTable.Rows)
                    {

                        oRow["fchrRealStocksDetailID"] = System.DBNull.Value;

                    }
                    detailTable.AcceptChanges();
                    controlSource = HandleEvent.FindControl("fchrRealStocksID", eventHandler.InitFormClass.MainForm);
                    eventHandler.SetControlProperty(controlSource, "ControlValue", "");

                    controlSource = HandleEvent.FindControl("fchrCode", eventHandler.InitFormClass.MainForm);
                    eventHandler.SetControlProperty(controlSource, "ControlValue", "");
                    RetailMessageBox.ShowInformation("ԭ���ݱ�ɾ�����µ��ݱ���ɹ���");
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// �ж�һ���̵�׼�����Ƿ����һ������Ӧ��ʵ�̵�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ExistSinglenessRealBill(object sender, ExternalMethodCallArgs args)
        {
            string strCheckRealID = "";
            string strCheckRealName = "";
            string strBackMultiInput = "";
            if (!CheckRealBillIsMulti(sender, args, ref strCheckRealID, ref strCheckRealName, ref strBackMultiInput))
            {
                if (Tools.GetIntColumnValue(strBackMultiInput) == 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// �ж�һ���̵�׼�����Ƿ�û������Ӧ��ʵ�̵�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool UNExistRealBill(object sender, ExternalMethodCallArgs args)
        {
            string strCheckRealID = "";
            string strCheckRealName = "";
            string strBackMultiInput = "";
            if (!CheckRealBillIsMulti(sender, args, ref strCheckRealID, ref strCheckRealName, ref strBackMultiInput))
            {
                if (Tools.GetIntColumnValue(strBackMultiInput) < 0)
                    return true;
            }
            return false;
        }

        public bool ExistMultiRealBill(object sender, ExternalMethodCallArgs args)
        {
            string strCheckRealID = "";
            string strCheckRealName = "";
            string strBackMultiInput = "";
            if (CheckRealBillIsMulti(sender, args, ref strCheckRealID, ref strCheckRealName, ref strBackMultiInput))
                return true;
            else
                return false;
        }
        /// <summary>
        ///  �ж�һ���̵�׼�����Ƿ��Ѿ����ڶ��ŵ�ʵ�̵�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="strCheckRealID"></param>
        /// <param name="strCheckRealName"></param>
        /// <param name="strBackMultiInput"></param>
        /// <returns></returns>
        public bool CheckRealBillIsMulti(object sender, ExternalMethodCallArgs args, ref string strCheckRealID, ref string strCheckRealName, ref string strBackMultiInput)
        {
            Control controlSource = null;
            string fchrCheckSetoutID = "";
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;

            controlSource = HandleEvent.FindControl("fchrCheckSetoutID", eventHandler.InitFormClass.MainForm);
            fchrCheckSetoutID = HandleEventHelper.GetControlValues(controlSource, "ExLabel");

            try
            {
                SqlParameter parmID = new SqlParameter("@fchrCheckSetOutId", SqlDbType.NVarChar, 100);
                parmID.Value = "{" + fchrCheckSetoutID + "}";
                SqlParameter parmBackName = new SqlParameter("@BackRealStocksName", SqlDbType.NVarChar, 100);
                parmBackName.Direction = ParameterDirection.Output;
                SqlParameter parmBackID = new SqlParameter("@BackRealStocksID", SqlDbType.NVarChar, 100);
                parmBackID.Direction = ParameterDirection.Output;
                SqlParameter parmBackInput = new SqlParameter("@BackMustInput", SqlDbType.NVarChar, 100);
                parmBackInput.Direction = ParameterDirection.Output;

                SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.StoredProcedure, "procRealCheckID", new SqlParameter[] { parmID, parmBackName, parmBackID, parmBackInput });

                strCheckRealID = Tools.GetStringColumnValue(parmBackID.Value);
                strCheckRealName = Tools.GetStringColumnValue(parmBackName.Value);
                strBackMultiInput = Tools.GetStringColumnValue(parmBackInput.Value);

                if (strBackMultiInput == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// �ж�һ���̵�׼�����Ƿ��Ѿ�����һ�Ż���ŵ�ʵ�̵�,���������,�ͽ���ʵ�̵�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void InputCheckData(object sender, ExternalMethodCallArgs args)
        {
            Control controlSource = null;
            XmlDocument doc = new XmlDocument();
            DataSet dsRefer = new DataSet();
            DataSet ds = new DataSet();
            DataGrid oSourceGrid = new DataGrid();
            DataTable dtRefer = null;
            string strCheckRealID = "";
            string strCheckRealName = "";
            string strCheckSetoutID = "";
            string inXml = "";
            string ErrDesc = "";
            string strBackMultiInput = "";
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            DataTable detailTable = args.HandleEvent.GetDetailTable();
            string strRealCheckDate = DateTime.Now.ToString("yyyy-MM-dd");


            if (CheckRealBillIsMulti(sender, args, ref strCheckRealID, ref strCheckRealName, ref strBackMultiInput))
            {
                RetailMessageBox.ShowExclamation("��ѡ�̵�׼�����Ѵ��ڶ��Ŷ�Ӧ��ʵ�̵�����������գ�");

                controlSource = HandleEvent.FindControl("fchrCheckSetoutID", eventHandler.InitFormClass.MainForm);
                eventHandler.SetControlProperty(controlSource, "ControlValue", "");

                controlSource = HandleEvent.FindControl("fchrCheckSetoutCode", eventHandler.InitFormClass.MainForm);
                eventHandler.SetControlProperty(controlSource, "RefName", "");

                controlSource = HandleEvent.FindControl("fchrCheckSetoutCode", eventHandler.InitFormClass.MainForm);
                eventHandler.SetControlProperty(controlSource, "RefID", "");
                return;
            }
            if (strCheckRealID == "")
            {
                controlSource = HandleEvent.FindControl("fdtmDate", eventHandler.InitFormClass.MainForm);
                eventHandler.SetControlProperty(controlSource, "ControlValue", strRealCheckDate);
                this.CheckInventoryNoParam(args);
            }
            else
            {
                controlSource = HandleEvent.FindControl("fchrCheckSetoutID", eventHandler.InitFormClass.MainForm);
                strCheckSetoutID = HandleEventHelper.GetControlValues(controlSource, "ExLabel");

                controlSource = HandleEvent.FindControl("fchrRealStocksID", eventHandler.InitFormClass.MainForm);
                eventHandler.SetControlProperty(controlSource, "ControlValue", strCheckRealID);

                controlSource = HandleEvent.FindControl("fchrCode", eventHandler.InitFormClass.MainForm);
                eventHandler.SetControlProperty(controlSource, "ControlValue", strCheckRealName);

                if (Tools.IsDate(GetRealCheckDate(strCheckRealID)))
                {
                    strRealCheckDate = GetRealCheckDate(strCheckRealID);
                }

                controlSource = HandleEvent.FindControl("fdtmDate", eventHandler.InitFormClass.MainForm);
                eventHandler.SetControlProperty(controlSource, "ControlValue", strRealCheckDate);


                Type t = InitFormClass.DGrid.GetType();

                string pageNum = t.InvokeMember("CurrentPage", BindingFlags.GetProperty, null, InitFormClass.DGrid, null).ToString();
                inXml = "<Data ParentCondition=' 1=1 '  PageSize=\"1\"  PageIndex=\"" + (pageNum == "0" || pageNum == "0" ? "1" : pageNum) + "\" TemplateName='CheckRealDetail' ><Where><Node Name='fchrCheckSetoutID' Value=\"" + strCheckSetoutID + "\"/></Where></Data>";
                doc.LoadXml(inXml);
                SQLSource Process = new SQLSource(SysPara.GetSysPara("SysConn").ToString());
                Process.GetReferData(doc.DocumentElement.OuterXml, dsRefer, out ErrDesc);
                HandleEvent.AddSelectableColumn(true, InitFormClass.DGrid, dsRefer);
                oSourceGrid = InitFormClass.DGrid;

                if (dsRefer.Tables.Count > 0)
                    dtRefer = dsRefer.Tables[0];

                //���˵����� by ylc 
                HandleEvent.FilterEmptyRows(oSourceGrid);
                foreach (DataRow oRow in dtRefer.Rows)
                {
                    oRow["UFSoft_Retail_Select"] = true;
                }
                eventHandler.ImportDataRow(oSourceGrid, dtRefer);

                ds = (DataSet)InitFormClass.DGrid.DataSource;
                dtRefer = ds.Tables[0];
                dtRefer.AcceptChanges();
            }
        }

        /// <summary>
        /// ��������ⵥ����Ʒ�Ƿ�����Ʒ�����д���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool CheckExistItem(object sender, ExternalMethodCallArgs args)
        {
            string strInOutVouchID = "";
            IDataReader readerTemp = null;
            string strSQL = "";
            int intItemNumber = 0;
            int intCurrentRowIndex = 0;
            bool bolExistError = false;
            DataRow oRows = null;

            SqlConnection sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
            HandleEvent eventHandler = args.HandleEvent;
            XmlNode configNode = args.ConfigNode;
            Init InitFormClass = eventHandler.InitFormClass;
            DataGrid ParentGrid = null;
            if (InitFormClass.ListGrid == null)
            {
                return false;
            }
            try
            {
                ParentGrid = ((PageGrid)args.HandleEvent.InitFormClass.ListGrid).DBGrid as DataGrid;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
            }
            string strMessage = configNode.Attributes["Message"].Value;
            intCurrentRowIndex = ParentGrid.CurrentRowIndex;
            DataSet ds = ParentGrid.DataSource as DataSet;
            if (ds != null)
            {
                //�õ����ݵ���ϸ
                DataTable dt = ds.Tables["DTDetail"];

                if (dt.Rows.Count > 0)
                {
                    oRows = dt.Rows[intCurrentRowIndex];
                    if (oRows.RowState != DataRowState.Deleted)
                    {
                        string strColumnName = args.ConfigNode.Attributes["InOutVouchID"].Value;
                        if (string.IsNullOrEmpty(strColumnName))
                        {
                            strColumnName = "������ⵥID";
                        }
                        strInOutVouchID = Tools.GetStringColumnValue(oRows[strColumnName]);
                        try
                        {
                            //  ����  ������û����Ʒ�����ļ�¼������
                            bolExistError = false;

                            //�޸Ĵ�����Ϣ����Ϣ�к�����Ʒ���롣V8.91, libo, 2010-03-15
                            strSQL = string.Format("SELECT fchrItemCode FROM InOutVouchDetail,InOutVouch WHERE InOutVouchDetail.fchrInOutVouchID=InOutVouch.fchrInOutVouchID AND InOutVouch.fchrInOutVouchID ='{0}' AND fchrItemID NOT IN(SELECT DISTINCT fchrItemID FROM ITEM)", strInOutVouchID);

                            DataSet objDs = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, strSQL);

                            if (objDs.Tables[0].Rows.Count > 0)
                            {
                                string strTemp = string.Empty;
                                foreach (DataRow dr in objDs.Tables[0].Rows)
                                {
                                    if (strTemp.Contains(dr["fchrItemCode"].ToString()) == false)
                                    {
                                        if (strTemp == string.Empty)
                                        {
                                            strTemp = strTemp + "\r\n" + dr["fchrItemCode"].ToString();
                                        }
                                        else
                                        {
                                            strTemp = strTemp + "��\r\n" + dr["fchrItemCode"].ToString();
                                        }
                                    }
                                }

                                strMessage = strMessage + strTemp;
                                RetailMessageBox.ShowExclamation(strMessage);
                                bolExistError = true;

                            }
                        }
                        catch (SqlException ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.Message);
                        }
                        finally
                        {
                            if (readerTemp != null)
                                readerTemp.Close();
                        }

                    }
                }
            }
            if (bolExistError)
                return false;
            else
                return true;
        }


        /// <summary>
        /// ��¼ʵ�̵�������,��ʵ�̲��츴��ʱ���Ա���ʵ�̵�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void RealCheckDataSave(object sender, ExternalMethodCallArgs args)
        {

            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            string strCheckSetoutID = "";
            DataTable dtGrid = null;
            string outXML = "";
            string errDesc = "";
            DataTable dtBake = null;
            DataSet dsSave = new DataSet();
            try
            {
                // �õ������е���Ʒ��Ϣ��ϸ
                HandleEvent.FilterEmptyRows(InitFormClass.DGrid);
                DataGrid ParentGrid = InitFormClass.DGrid;
                DataSet ds = ParentGrid.DataSource as DataSet;
                //�õ����յ��̵�׼������ID
                Control controlSource = HandleEvent.FindControl("fchrCheckSetoutID", InitFormClass.MainForm);
                strCheckSetoutID = HandleEventHelper.GetControlValues(controlSource, "ExLabel");
                //�����е���Ʒ��Ϣ��ϸ�Ƿ�Ϊ��
                if (ds != null)
                {

                    DataTable dt = ds.Tables["DTDetail"];

                    if (dt.Rows.Count == 0)
                    {
                        RetailMessageBox.ShowExclamation("û����ϸ���ݼ�¼���޷����棡");
                        return;
                    }
                    dtBake = dt.Copy();
                    foreach (DataRow oRows in dt.Rows)
                    {
                        if (oRows.RowState != DataRowState.Deleted)
                        {
                            if (Tools.GetStringColumnValue(oRows["fchrRealStocksDetailID"]) == "")
                                oRows["flotQuantity"] = 0;
                        }
                    }
                    //foreach (DataRow oRow in dtBake.Rows)
                    //{
                    //    if (oRow.RowState != DataRowState.Deleted)
                    //    {
                    //        if (Tools.GetStringColumnValue(oRow["fchrRealStocksDetailID"]) == "")
                    //            oRow.Delete();
                    //    }
                    //}
                    DataView objView = dtBake.DefaultView;
                    objView.RowFilter = "fchrRealStocksDetailID<>''";
                    dtBake = objView.ToTable();
                    dtBake.AcceptChanges();
                    if (dtBake.Rows.Count == 0)
                    {
                        RetailMessageBox.ShowExclamation("û����ϸ���ݼ�¼���޷����棡");
                        return;
                    }
                    DataTable dtMain = eventHandler.CreateMainTable();
                    dtMain.TableName = "Main";

                    dtGrid = dtBake.Copy();
                    dtGrid.TableName = "Detail";


                    dsSave.ExtendedProperties.Add("TemplateID", "Save_RealStocksCheck");
                    dsSave.Tables.Add(dtMain);
                    dsSave.Tables.Add(dtGrid);
                    Data process = new Data();
                    process.Save("<u/>", dsSave, ref outXML, ref errDesc);

                    if (errDesc != "")
                    {
                        RetailMessageBox.ShowExclamation("����ʱ��������\n" + errDesc);
                        return;
                    }
                    Control saveButton = sender as Control;
                    Form sourceForm = saveButton.FindForm();
                    if (sourceForm is IEditForm)
                    {
                        ((IEditForm)sourceForm).HasChanged = false;
                    }
                    RetailMessageBox.ShowInformation("���ݱ���ɹ���");
                    eventHandler.CalGridTotal(ds.Tables["DTDetail"]);
                    (InitFormClass.MainForm as frmMain).HasChanged = false;
                }
            }
            catch (Exception ex)
            {
                errDesc = ex.Message;
                return;
            }
        }


        /// <summary>
        /// ��СƱ��ӡ����ӡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void POSPrintBill(object sender, ExternalMethodCallArgs args)
        {
            string strBillValue = "";
            string strBillControlName = "";
            string strBillControlType = "";
            string strTemplateName = "";
            bool bolIsExistBill = false;
            string strCheckSetoutCode = "";
            string strCheckSetoutDate = "";
            string strMaker = "";
            string strEmployee = "";
            string strMemo = "";
            string strSQL = "";
            string strError = "";
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            Control controlSource = null;
            SqlConnection sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
            XmlNode configNode = args.ConfigNode;

            //�������ID���Բ����ڣ��򲻼��
            if (configNode == null || configNode.Attributes["BillControlName"] == null)
            {
                return;
            }
            strBillControlName = configNode.Attributes["BillControlName"].Value;

            //�������ID���Բ����ڣ��򲻼��
            if (configNode == null || configNode.Attributes["BillControlType"] == null)
            {
                return;
            }
            strBillControlType = configNode.Attributes["BillControlType"].Value;

            //�������ID���Բ����ڣ��򲻼��
            if (configNode == null || configNode.Attributes["TemplateName"] == null)
            {
                return;
            }
            strTemplateName = configNode.Attributes["TemplateName"].Value;

            //�����Ƿ񲻴���
            if (configNode == null || configNode.Attributes["IsExistBill"] == null)
            {
                return;
            }
            bolIsExistBill = Tools.GetBoolColumnValue(configNode.Attributes["IsExistBill"].Value);
            // ����������Ѿ������
            if (bolIsExistBill)
            {
                // �õ�  ��Ҫ��ӡ�ĵ��ݵ�ID
                controlSource = HandleEvent.FindControl(strBillControlName, args.HandleEvent.GetMainForm(sender));
                strBillValue = HandleEventHelper.GetControlValues(controlSource, strBillControlType);

                int nPrinterType = Tools.GetIntSysPara("PrinterType");     //��ӡ������ 0 POS��ӡ 1 ��ͨ
                if (!nPrinterType.Equals(0)) strTemplateName = strTemplateName + "_C";
                DataSet objDs = new DataSet("Main");
                DataTable objTable = args.HandleEvent.GetDetailTable();
                DataTable objTempTable = objTable.Copy();
                objTempTable.TableName = "CheckSetoutODetail";
                objDs.Tables.Add(objTempTable);
                string sRet = PrintReceipt.GetPrintLSReceiptXML(strBillValue, strTemplateName, ref strError, objDs);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sRet);
                int intBackPrintResult = PosPrint.PrintLSDReceipt(doc.OuterXml);
            }
            else
            {
                //�õ����յ��̵�׼������ID

                //�õ����յ��̵�׼������ID
                controlSource = HandleEvent.FindControl("fchrCode", InitFormClass.MainForm);
                strCheckSetoutCode = HandleEventHelper.GetControlValues(controlSource, "ExLabel");
                //�õ����յ��̵�׼����������
                controlSource = HandleEvent.FindControl("fdtmDate", InitFormClass.MainForm);
                strCheckSetoutDate = HandleEventHelper.GetControlValues(controlSource, "ExDatePicker");
                //�õ����յ��̵�׼�������Ƶ���
                controlSource = HandleEvent.FindControl("fchrMaker", InitFormClass.MainForm);
                strMaker = HandleEventHelper.GetControlValues(controlSource, "ExLabel");
                //�õ����յ��̵�׼������ӪҵԱ
                controlSource = HandleEvent.FindControl("fchrEmployeeID", InitFormClass.MainForm);
                strEmployee = HandleEventHelper.GetControlValues(controlSource, "ExComboBox");
                //�õ����յ��̵�׼�����ı�ע
                controlSource = HandleEvent.FindControl("fchrMemo", InitFormClass.MainForm);
                strMemo = HandleEventHelper.GetControlValues(controlSource, "ExTextBox");

                strSQL = "TRUNCATE TABLE POSPrintTemp";
                SqlAccess.ExecuteNonQuery(sConn, CommandType.Text, strSQL);

                strSQL = "TRUNCATE TABLE POSPrintTempDetail";
                SqlAccess.ExecuteNonQuery(sConn, CommandType.Text, strSQL);

                strSQL = string.Format("INSERT INTO POSPrintTemp(POSPrintTemp1,POSPrintTemp2,POSPrintTemp3,POSPrintTemp4,POSPrintTemp5) VALUES ('{0}','{1}','{2}','{3}','{4}')", strCheckSetoutCode, strCheckSetoutDate, strMaker, strEmployee, strMemo);
                SqlAccess.ExecuteNonQuery(sConn, CommandType.Text, strSQL);
                string sRet = PrintReceipt.GetPrintLSReceiptXML("1111", strTemplateName, ref strError);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(sRet);
                int intBackPrintResult = PosPrint.PrintLSDReceipt(doc.OuterXml);
            }
            //
        }
        /// <summary>
        /// ����۸����ļ�¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void SavePriceChange(Form modifyForm)
        {

            string strItemID = "";
            double douQuotePrice = 0;
            double douVipPrice1 = 0;
            double douVipPrice2 = 0;
            double douVipPrice3 = 0;
            double douVipPrice4 = 0;
            double douVipPrice5 = 0;
            double douVipPrice6 = 0;
            Control controlSource = null;
            try
            {
                // �õ�  ��������Ʒ��ID
                controlSource = HandleEventHelper.GetControlByName("���id", modifyForm);
                strItemID = HandleEventHelper.GetControlValues(controlSource, "ExLabel");
                // �õ�  ��������Ʒ�Ľ������ۼ�
                controlSource = HandleEventHelper.GetControlByName("���ۼ�", modifyForm);

                douQuotePrice = Tools.GetDblColumnValue(((ExNumbericText)controlSource).ControlValue);
                // �õ�  ��������Ʒ��VIPһ����
                controlSource = HandleEventHelper.GetControlByName("VIPһ����", modifyForm);
                douVipPrice1 = Tools.GetDblColumnValue(((ExNumbericText)controlSource).ControlValue);
                // �õ�  ��������Ʒ��VIP������
                controlSource = HandleEventHelper.GetControlByName("VIP������", modifyForm);
                douVipPrice2 = Tools.GetDblColumnValue(((ExNumbericText)controlSource).ControlValue);
                // �õ�  ��������Ʒ��VIP������
                controlSource = HandleEventHelper.GetControlByName("VIP������", modifyForm);
                douVipPrice3 = Tools.GetDblColumnValue(((ExNumbericText)controlSource).ControlValue);
                // �õ�  ��������Ʒ��VIP�ļ���
                controlSource = HandleEventHelper.GetControlByName("VIP�ļ���", modifyForm);
                douVipPrice4 = Tools.GetDblColumnValue(((ExNumbericText)controlSource).ControlValue);
                // �õ�  ��������Ʒ��VIP�弶��
                controlSource = HandleEventHelper.GetControlByName("VIP�弶��", modifyForm);
                douVipPrice5 = Tools.GetDblColumnValue(((ExNumbericText)controlSource).ControlValue);
                // �õ�  ��������Ʒ��VIP������
                controlSource = HandleEventHelper.GetControlByName("VIP������", modifyForm);
                douVipPrice6 = Tools.GetDblColumnValue(((ExNumbericText)controlSource).ControlValue);

                //���ô洢����,����۸�仯�ͽ��˱仯��¼����

                SqlParameter myParm1 = new SqlParameter("@fchrItemID", SqlDbType.NVarChar, 37);
                myParm1.Value = strItemID;

                SqlParameter myParm2 = new SqlParameter("@flotQuotePrice", SqlDbType.Decimal);
                myParm2.Value = douQuotePrice;

                SqlParameter myParm3 = new SqlParameter("@flotVipPrice1", SqlDbType.Decimal);
                myParm3.Value = douVipPrice1;

                SqlParameter myParm4 = new SqlParameter("@flotVipPrice2", SqlDbType.Decimal);
                myParm4.Value = douVipPrice2;

                SqlParameter myParm5 = new SqlParameter("@flotVipPrice3", SqlDbType.Decimal);
                myParm5.Value = douVipPrice3;

                SqlParameter myParm6 = new SqlParameter("@flotVipPrice4", SqlDbType.Decimal);
                myParm6.Value = douVipPrice4;

                SqlParameter myParm7 = new SqlParameter("@flotVipPrice5", SqlDbType.Decimal);
                myParm7.Value = douVipPrice5;

                SqlParameter myParm8 = new SqlParameter("@flotVipPrice6", SqlDbType.Decimal);
                myParm8.Value = douVipPrice6;

                SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.StoredProcedure, "procNotePriceChange", new SqlParameter[] { myParm1, myParm2, myParm3, myParm4, myParm5, myParm6, myParm7, myParm8 });
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
        /// ����������ѯ (ȡ�ؼ�FreeItemXml�ؼ���ֵ������)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        ///  add by wq 2007.11.7
        public bool RefFilterCondition(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            XmlNode configNode = args.ConfigNode;
            Control control;
            XmlDocument xmlDoc = new XmlDocument();
            XmlNodeList xmlList;
            XmlNode xmlNode;
            SqlConnection sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
            string strControlID = "";
            string strFilterCondition = "";
            string strOwnerControl = "";
            string strSQL = "";
            string strSQL1 = "";
            string para = "";
            string strFreeItemXmlControl = "";
            string strOtherRefSource = "";
            string strfbitFree = "";
            bool fbitFree;
            string strFreeXml = "";
            string strTemp = "";
            string strTemp1 = "";
            string strTemp2 = "";
            try
            {
                //��ȡֵ�ؼ�
                strFilterCondition = configNode.Attributes["FilterCondition"].Value;
                //�޸ĵĿؼ�
                strOwnerControl = configNode.Attributes["OwnerControl"].Value;
                //�ؼ���ȡ��ֵ��Ӧ��sql������
                para = configNode.Attributes["Para"].Value;
                //����������xml�Ŀؼ�
                strFreeItemXmlControl = configNode.Attributes["FreeItemXmlControl"].Value;
                //�Ƿ�����������Ŀؼ���ֵ
                strfbitFree = configNode.Attributes["strfbitFree"].Value;
                //�Ƿ���Ҫ��������ģ��
                strOtherRefSource = configNode.Attributes["OtherRefSource"].Value;

                if (strFilterCondition == "" || strOwnerControl == "")
                    return false;
                //��ȡitemid
                control = HandleEvent.FindControl(strFilterCondition, InitFormClass.DetailForm);
                strControlID = HandleEventHelper.GetControlValue(control);
                //��ȡ�������ַ���
                control = HandleEvent.FindControl(strFreeItemXmlControl, InitFormClass.DetailForm);
                strFreeXml = HandleEventHelper.GetControlValue(control);
                //��ȡ�Ƿ�����������
                control = HandleEvent.FindControl(strfbitFree, InitFormClass.DetailForm);
                fbitFree = Convert.ToBoolean(HandleEventHelper.GetControlValue(control));

                strSQL = string.Format("{0}='{1}'", para, strControlID);
                //���������������������ݼӵ��ַ�����
                if (fbitFree == true)
                {
                    xmlDoc.LoadXml(strFreeXml);
                    xmlNode = xmlDoc.SelectSingleNode("Root");
                    int count;
                    count = xmlNode.SelectNodes("Item").Count;
                    xmlList = xmlNode.SelectNodes("Item");
                    strSQL1 = "";
                    for (int i = 0; i < count; i++)
                    {
                        strTemp2 = "";
                        xmlNode = xmlList.Item(i);
                        for (int j = 1; j <= 10; j++)
                        {
                            strTemp = string.Format("fbitFree{0}", j.ToString());
                            string strcmd;
                            strcmd = string.Format("select {0} from dbo.Item where {1}", strTemp, strSQL);
                            strTemp1 = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strcmd).ToString();
                            strTemp = string.Format("fchrFree{0}", j.ToString());
                            if (Tools.GetStringSysPara(strTemp) != "" && strTemp1 == "True")
                            {

                                strTemp1 = "";
                                if (xmlNode.Attributes[strTemp].Value != "")
                                    strTemp1 = string.Format("{0} = '{1}'", strTemp, xmlNode.Attributes[strTemp].Value);
                                if (strTemp2 == "")
                                    strTemp2 = strTemp1;
                                else
                                    strTemp2 += string.Format(" and {0}", strTemp1);
                            }
                        }
                        if (strSQL1 == "")
                            strSQL1 = string.Format("({0})", strTemp2);
                        else
                            strSQL1 += string.Format(" or ({0})", strTemp2);

                    }
                    if (strSQL1 != "")
                        strSQL += string.Format(" and ({0})", strSQL1);

                }
                //�Ƿ�������Ч��
                //���ڹ���
                if (strOtherRefSource != "")
                {
                    strSQL1 = string.Format("select fbitValidDay from dbo.Item where fchrItemID='{0}'", strControlID);
                    strTemp = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL1).ToString();
                    if (strTemp.ToUpper() == "FALSE")
                    {
                        control = HandleEvent.FindControl(strOwnerControl, InitFormClass.DetailForm);
                        eventHandler.SetControlProperty(control, "TemplateID", strOtherRefSource);
                        ((RefControl)control).TempalteID = strOtherRefSource;
                    }
                }
                control = HandleEvent.FindControl(strOwnerControl, InitFormClass.DetailForm);
                eventHandler.SetControlProperty(control, "ParentCondition", strSQL);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }

        }
        /// <summary>
        /// ����������ѯ(�޸�ʱ,ȡfchrfree1-10�ؼ����������ֵ�����жϣ�ͬʱ��ȡFreeItemXml�ؼ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// add by wq 2007.11.7
        public bool RefFilterConditionEdit(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            XmlNode configNode = args.ConfigNode;
            Control control;
            XmlDocument xmlDoc = new XmlDocument();
            string strControlID = "";
            string strFilterCondition = "";
            string strOwnerControl = "";
            string strSQL = "";
            string strSQL1 = "";
            string para = "";
            string strfbitFree = "";
            bool fbitFree;
            string strTemp = "";
            string strFree = "";
            string strFreeItemXmlControl = "";
            string strTemp1 = "";
            string strTemp2 = "";
            XmlNode xmlNode;
            XmlNodeList xmlList;
            string strFreeXml = "";
            string strOtherRefSource = "";
            SqlConnection sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
            try
            {
                //��ȡֵ�ؼ�
                strFilterCondition = configNode.Attributes["FilterCondition"].Value;
                //�޸ĵĿؼ�
                strOwnerControl = configNode.Attributes["OwnerControl"].Value;
                //�ؼ���ȡ��ֵ��Ӧ��sql������
                para = configNode.Attributes["Para"].Value;
                //�Ƿ�����������Ŀؼ���ֵ
                strfbitFree = configNode.Attributes["strfbitFree"].Value;
                //����������xml�Ŀؼ�
                strFreeItemXmlControl = configNode.Attributes["FreeItemXmlControl"].Value;
                //�Ƿ���Ҫ��������ģ��
                strOtherRefSource = configNode.Attributes["OtherRefSource"].Value;

                if (strFilterCondition == "" || strOwnerControl == "")
                    return false;
                //��ȡitemid
                control = HandleEvent.FindControl(strFilterCondition, InitFormClass.DetailForm);
                strControlID = HandleEventHelper.GetControlValue(control);
                //��ȡ�Ƿ�����������
                control = HandleEvent.FindControl(strfbitFree, InitFormClass.DetailForm);
                fbitFree = Convert.ToBoolean(HandleEventHelper.GetControlValue(control));
                //��ȡ�������ַ���
                control = HandleEvent.FindControl(strFreeItemXmlControl, InitFormClass.DetailForm);
                strFreeXml = HandleEventHelper.GetControlValue(control);
                //ƴ��sql
                strSQL = string.Format("{0}='{1}'", para, strControlID);

                //strFreeItemXmlControl���յ�����Ǳ༭ʱ���������
                //��Ϊֱ��ѡ����Ʒ���б༭
                if (strFreeXml != "")
                {
                    if (fbitFree == true)
                    {
                        xmlDoc.LoadXml(strFreeXml);
                        xmlNode = xmlDoc.SelectSingleNode("Root");
                        int count;
                        count = xmlNode.SelectNodes("Item").Count;
                        xmlList = xmlNode.SelectNodes("Item");
                        strSQL1 = "";
                        for (int i = 0; i < count; i++)
                        {
                            strTemp2 = "";
                            xmlNode = xmlList.Item(i);
                            for (int j = 1; j <= 10; j++)
                            {
                                strTemp = string.Format("fbitFree{0}", j.ToString());
                                string strcmd;
                                strcmd = string.Format("select {0} from dbo.Item where {1}", strTemp, strSQL);
                                strTemp1 = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strcmd).ToString();
                                strTemp = string.Format("fchrFree{0}", j.ToString());
                                if (Tools.GetStringSysPara(strTemp) != "" && strTemp1 == "True")
                                {

                                    strTemp1 = "";
                                    if (xmlNode.Attributes[strTemp].Value != "")
                                        strTemp1 = string.Format("{0} = '{1}'", strTemp, xmlNode.Attributes[strTemp].Value);
                                    if (strTemp2 == "")
                                        strTemp2 = strTemp1;
                                    else
                                        strTemp2 += string.Format(" and {0}", strTemp1);
                                }
                            }
                            if (strSQL1 == "")
                                strSQL1 = string.Format("({0})", strTemp2);
                            else
                                strSQL1 += string.Format(" or ({0})", strTemp2);

                        }
                        if (strSQL1 != "")
                            strSQL += string.Format(" and ({0})", strSQL1);

                    }

                }
                else
                { //���������������������ݼӵ��ַ�����
                    if (fbitFree == true)
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            strTemp = string.Format("fchrFree{0}", i.ToString());
                            if (Tools.GetStringSysPara(strTemp) != "")
                            {
                                control = HandleEvent.FindControl(strTemp, InitFormClass.DetailForm);
                                strFree = HandleEventHelper.GetControlValue(control);
                                if (strFree != "")
                                {
                                    strSQL += string.Format(" and {0} = '{1}'", strTemp, strFree);
                                }
                            }
                        }

                    }

                }
                //�Ƿ�������Ч��
                //���ڹ���
                if (strOtherRefSource != "")
                {
                    strSQL1 = string.Format("select fbitValidDay from dbo.Item where fchrItemID='{0}'", strControlID);
                    strTemp = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL1).ToString();
                    if (strTemp.ToUpper() == "FALSE")
                    {
                        control = HandleEvent.FindControl(strOwnerControl, InitFormClass.DetailForm);
                        eventHandler.SetControlProperty(control, "TemplateID", strOtherRefSource);
                        ((RefControl)control).TempalteID = strOtherRefSource;
                    }
                }
                control = HandleEvent.FindControl(strOwnerControl, InitFormClass.DetailForm);
                eventHandler.SetControlProperty(control, "ParentCondition", strSQL);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }

        }
        /// <summary>
        /// ��ⵥ��������ʱ��Ч�ڵĿ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// ��¼��������ڵ�������в����ڣ��������¼����������/��Ч������
        /// ��¼��������ڵ�������д��ڣ�����������/��Ч������������¼�룬Ӧ�Զ�������������Ӧ�ġ���������/��Ч���������Ҳ����ֹ��޸ġ�
        /// add by wq 2007.11.20
        public bool RelationBatchAndDateTextIn(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            XmlNode configNode = args.ConfigNode;
            Control control;
            XmlDocument xmlDoc = new XmlDocument();

            if (!Tools.GetBoolSysPara("ProductManageType"))
                return true;
            string strIsProduceDate;
            control = HandleEvent.FindControl("�Ƿ���Ч�ڹ���", InitFormClass.DetailForm);
            strIsProduceDate = HandleEventHelper.GetControlValue(control);
            if (strIsProduceDate == "False")
                return true;

            //���ſؼ�
            string strBatchControl = "";
            strBatchControl = configNode.Attributes["BatchControl"].Value;
            //��Ч�ڿؼ�
            string strDateControl = "";
            strDateControl = configNode.Attributes["ProduceDateControl"].Value;

            //�Ƿ�����������Ŀؼ���ֵ
            string strfbitFree = "";
            strfbitFree = configNode.Attributes["strfbitFree"].Value;


            //��ȡitemid
            string strItemID = "";
            control = HandleEvent.FindControl("���id", InitFormClass.DetailForm);
            strItemID = HandleEventHelper.GetControlValue(control);
            //�������ַ����ؼ�
            string strFreeItemXmlControl = "";
            strFreeItemXmlControl = configNode.Attributes["FreeItemXmlControl"].Value;
            //��ȡ�������ַ���
            string strFreeXml = "";
            control = HandleEvent.FindControl(strFreeItemXmlControl, InitFormClass.DetailForm);
            strFreeXml = HandleEventHelper.GetControlValue(control);
            //��ȡ�Ƿ�����������
            bool fbitFree;
            control = HandleEvent.FindControl(strfbitFree, InitFormClass.DetailForm);
            fbitFree = Convert.ToBoolean(HandleEventHelper.GetControlValue(control));

            //
            string strSqlCondition = "";
            strSqlCondition = string.Format("fchrItemID='{0}'", strItemID);
            //���ֻ��1����Ʒ����������������ж���Ч�ڣ���Ϊ1��������Ʒ������
            object objResult = null;
            if (fbitFree)
                //ƴдsql
                CheckItemFree(strFreeXml, strSqlCondition, out objResult, args);
            OperateDateControlByBatch(objResult, strDateControl, args);
            return true;
        }
        /// <summary>
        /// �������ſؼ�������Ч�ڿؼ�������
        /// </summary>
        /// <param name="strBatchControl">���ſؼ�����</param>
        /// <param name="strDateControl">��Ч�ڿؼ�����</param>
        /// <param name="strSqlCondition">sql�������</param>
        /// add by wq 2007.11.20
        private void OperateDateControlByBatch(object objResult, string strDateControl, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            XmlNode configNode = args.ConfigNode;
            Control control;


            bool sign = true;
            string strResult;
            if (objResult is ArrayList)
            {
                ArrayList list = objResult as ArrayList;
                string element = list[0].ToString();
                foreach (string result in list)
                {
                    if (result != element)
                    {
                        sign = false;
                        continue;
                    }
                }
                strResult = element;
            }
            else
                strResult = objResult.ToString();
            if (strResult != string.Empty && sign)
            {
                control = HandleEvent.FindControl(strDateControl, InitFormClass.DetailForm);
                eventHandler.SetControlProperty(control, "EnableControl", "False");
                ((ExTextBox)control).ControlValue = strResult;
            }
            else
            {
                control = HandleEvent.FindControl(strDateControl, InitFormClass.DetailForm);
                eventHandler.SetControlProperty(control, "EnableControl", "True");
                ((ExTextBox)control).ControlValue = "";
            }
        }

        //��������ȡ��Ч��
        public void GetDateByBatch(string strSqlCondition, ref string objResult, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            XmlNode configNode = args.ConfigNode;

            Control control;
            //ȡ���ſؼ���ֵ
            string strBatch = "";
            //���ſؼ�
            string strBatchControl = "";
            strBatchControl = configNode.Attributes["BatchControl"].Value;
            control = HandleEvent.FindControl(strBatchControl, InitFormClass.DetailForm);
            strBatch = HandleEventHelper.GetControlValue(control);
            //ƴдsql
            string strSQL = "";
            strSQL = string.Format("select COUNT(DISTINCT fdtmProduceDate) as count from dbo.ItemStocks where {0} AND fchrBatchCode='{1}'", strSqlCondition, strBatch);
            //��ȡ��Ч�ڵ�ֵ
            using (SqlConnection sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString()))
            {
                int count = Convert.ToInt32(SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL));
                if (count == 1)
                {
                    strSQL = strSQL.Replace("COUNT(DISTINCT fdtmProduceDate) as count", "DISTINCT fdtmProduceDate");
                    objResult = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL).ToString();
                }
            }
        }
        //��������ȡ��Ч��
        public void GetDateByBatch(string strSqlCondition, ref ArrayList objResult, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            XmlNode configNode = args.ConfigNode;

            Control control;
            //ȡ���ſؼ���ֵ
            string strBatch = "";
            //���ſؼ�
            string strBatchControl = "";
            strBatchControl = configNode.Attributes["BatchControl"].Value;
            control = HandleEvent.FindControl(strBatchControl, InitFormClass.DetailForm);
            strBatch = HandleEventHelper.GetControlValue(control);
            //ƴдsql
            string strSQL = "";
            strSQL = string.Format("select COUNT(DISTINCT fdtmProduceDate) as count from dbo.ItemStocks where {0} AND fchrBatchCode='{1}'", strSqlCondition, strBatch);
            //��ȡ��Ч�ڵ�ֵ
            using (SqlConnection sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString()))
            {
                int count = Convert.ToInt32(SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL));
                if (count == 0)
                    objResult.Add("0000");
                if (count == 1)
                {
                    strSQL = strSQL.Replace("COUNT(DISTINCT fdtmProduceDate) as count", "DISTINCT fdtmProduceDate");
                    objResult.Add(SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSQL).ToString());
                }
            }
        }
        /// <summary>
        /// ����Ƿ���ڸ������ƴ��SQL
        /// </summary>
        /// <param name="strFreeXml">������ؼ�xml</param>
        /// <param name="strSQL">sql����</param>
        /// <returns></returns>
        /// add by wq 2007.11.20
        private void CheckItemFree(string strFreeXml, string strSqlCondition, out object objResult, ExternalMethodCallArgs args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode xmlNode;
            string strSqlTemp = "";
            string strTemp = "";
            try
            {
                if (strFreeXml != string.Empty)
                {
                    //��ȡfreexml�ڵ�
                    xmlDoc.LoadXml(strFreeXml);
                    xmlNode = xmlDoc.SelectSingleNode("Root");
                    //������ڵ�����
                    XmlNodeList xmlList;
                    xmlList = xmlNode.SelectNodes("Item");
                    SqlConnection sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
                    string strFreeName;
                    string strFreeValue;
                    strTemp = strSqlCondition;
                    string strSqlConditionTemp;
                    ArrayList list = new ArrayList();
                    foreach (XmlNode _node in xmlList)
                    {
                        strSqlCondition = strTemp;
                        strSqlConditionTemp = string.Empty;
                        foreach (XmlAttribute att in _node.Attributes)
                        {
                            if (att.Name.Contains("fchrFree"))
                            {
                                strFreeName = att.Name;
                                strFreeValue = att.Value;
                                if (strSqlConditionTemp == string.Empty)
                                    strSqlConditionTemp = string.Format(" {0} = '{1}' ", strFreeName, strFreeValue);
                                else
                                    strSqlConditionTemp += string.Format(" AND {0} = '{1}' ", strFreeName, strFreeValue);
                            }
                        }
                        strSqlCondition += string.Format(" AND ({0}) ", strSqlConditionTemp);
                        GetDateByBatch(strSqlCondition, ref list, args);
                    }
                    objResult = list;
                }
                else
                {
                    HandleEvent eventHandler = args.HandleEvent;
                    Init InitFormClass = eventHandler.InitFormClass;
                    Control control;
                    string strFree;
                    string result = "";
                    for (int i = 1; i <= 10; i++)
                    {
                        strTemp = string.Format("fchrFree{0}", i.ToString());
                        if (Tools.GetStringSysPara(strTemp) != "")
                        {
                            control = HandleEvent.FindControl(strTemp, InitFormClass.DetailForm);
                            strFree = HandleEventHelper.GetControlValue(control);
                            if (strFree != "")
                            {
                                if (strSqlTemp == string.Empty)
                                    strSqlTemp = string.Format(" {0} = '{1}'", strTemp, strFree);
                                else
                                    strSqlTemp += string.Format(" and {0} = '{1}'", strTemp, strFree);
                            }
                        }
                    }
                    if (strSqlTemp != string.Empty)
                        strSqlCondition += string.Format("AND ({0})", strSqlTemp);
                    GetDateByBatch(strSqlCondition, ref result, args);
                    objResult = result;
                }
            }
            catch (Exception ex)
            {
                objResult = null;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// ���Ż���Ч��Ϊ��ʱ��ʾ��Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// add by wq 2007.11.20
        public bool RealCheckBatchAndDate(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            Control control;
            XmlNode configNode = args.ConfigNode;

            try
            {
                //��ȡ��Ʒ�Ƿ����ţ���Ч�ڹ���
                string strIsBatchManage;
                control = HandleEvent.FindControl("�Ƿ����ι���", InitFormClass.DetailForm);
                strIsBatchManage = HandleEventHelper.GetControlValue(control);
                string strIsProduceDateManage;
                control = HandleEvent.FindControl("�Ƿ���Ч�ڹ���", InitFormClass.DetailForm);
                strIsProduceDateManage = HandleEventHelper.GetControlValue(control);

                //ȡ���ſؼ���ֵ
                string strBatchControl = "";
                string strBatch = "";
                strBatchControl = configNode.Attributes["BatchControl"].Value;
                control = HandleEvent.FindControl(strBatchControl, InitFormClass.DetailForm);
                strBatch = HandleEventHelper.GetControlValue(control);
                //ȡ��Ч�ڿؼ���ֵ
                string strDateControl = "";
                string strDate = "";
                strDateControl = configNode.Attributes["ProduceDateControl"].Value;
                control = HandleEvent.FindControl(strDateControl, InitFormClass.DetailForm);
                strDate = HandleEventHelper.GetControlValue(control);
                //ȡ��Ʒ����
                string strItemName;
                string strItemNameControl;
                strItemNameControl = configNode.Attributes["ItemNameControl"].Value;
                control = HandleEvent.FindControl(strItemNameControl, InitFormClass.DetailForm);
                strItemName = ((RefControl)control).RefName;
                //ȡ��Ʒ����
                string strItemCode;
                string strItemCodeControl;
                strItemCodeControl = configNode.Attributes["ItemCodeControl"].Value;
                control = HandleEvent.FindControl(strItemCodeControl, InitFormClass.DetailForm);
                strItemCode = HandleEventHelper.GetControlValue(control);

                string strTemp;
                strTemp = string.Format("��Ʒ[{0} {1}]�����š���������/��Ч����������Ϊ�գ�", strItemCode, strItemName);

                if ((strBatch == string.Empty && strIsBatchManage == "True") || (strDate == string.Empty && strIsProduceDateManage == "True"))
                {
                    RetailMessageBox.ShowExclamation(strTemp);
                    return false;
                }
                else
                { }
                return true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }



        }
        /// <summary>
        /// �����ϸ����ʱ������Ч�ڿؼ��Ĳ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// add by wq 2007.11.20
        public bool CheckProductDateEnable(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            Control control;
            XmlNode configNode = args.ConfigNode;

            //ȡ����
            string strBatchControl;
            string strBatch;
            strBatchControl = configNode.Attributes["BatchControl"].Value;
            control = HandleEvent.FindControl(strBatchControl, InitFormClass.DetailForm);
            strBatch = HandleEventHelper.GetControlValue(control);
            //ȡ��Ч��
            string strProductDateControl;
            string strProductDate;
            strProductDateControl = configNode.Attributes["ProduceDateControl"].Value;
            control = HandleEvent.FindControl(strProductDateControl, InitFormClass.DetailForm);
            strProductDate = HandleEventHelper.GetControlValue(control);

            if (strBatch == string.Empty || strProductDate == string.Empty)
                return true;

            //ȡ��ƷID
            string strItemID;
            control = HandleEvent.FindControl("���id", InitFormClass.DetailForm);
            strItemID = HandleEventHelper.GetControlValue(control);

            //ƴдsql
            string strSqlCondition = string.Format(" fchrItemID = '{0}' ", strItemID);
            string strFree;
            string strTemp;
            string strSqlTemp = "";
            for (int i = 1; i <= 10; i++)
            {
                strTemp = string.Format("fchrFree{0}", i.ToString());
                if (Tools.GetStringSysPara(strTemp) != "")
                {
                    control = HandleEvent.FindControl(strTemp, InitFormClass.DetailForm);
                    strFree = HandleEventHelper.GetControlValue(control);
                    if (strFree != "")
                    {
                        if (strSqlTemp == string.Empty)
                            strSqlTemp = string.Format(" {0} = '{1}'", strTemp, strFree);
                        else
                            strSqlTemp += string.Format(" and {0} = '{1}'", strTemp, strFree);
                    }
                }
            }
            if (strSqlTemp != string.Empty)
                strSqlCondition += string.Format("AND ({0})", strSqlTemp);

            string strSql;
            strSql = string.Format("select Count(*) from dbo.ItemStocks where {0}  AND fchrBatchCode = '{1}' AND fdtmProduceDate = '{2}'", strSqlCondition, strBatch, strProductDate);

            string strResult;
            SqlConnection sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
            strResult = SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSql).ToString();

            if (1 == Convert.ToInt32(strResult))
            {
                control = HandleEvent.FindControl(strProductDateControl, InitFormClass.DetailForm);
                ((ExTextBox)control).EnableControl = "False";
                string strSignControl;
                strSignControl = configNode.Attributes["SignControl"].Value;
                control = HandleEvent.FindControl(strSignControl, InitFormClass.DetailForm);
                ((ExTextBox)control).ControlValue = "1";
            }
            return true;
        }
        /// <summary>
        /// ���ǰ�������������š���Ч���Ƿ��Ӧ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// add by wq 2007.11.28
        /// ���ǰ�������������ITEMID �����ţ���Ч���Ƿ��Ӧ
        /// ֻ����������ʱ����ж�
        public bool CheckBatchDateFreeError(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            Control control;
            XmlNode configNode = args.ConfigNode;

            //�Ƿ�����������
            string strfbitFreeControl;
            bool fbitFree;
            strfbitFreeControl = configNode.Attributes["fbitFreeControl"].Value;
            control = HandleEvent.FindControl(strfbitFreeControl, InitFormClass.DetailForm);
            fbitFree = Convert.ToBoolean(HandleEventHelper.GetControlValue(control));

            //�������ַ����ؼ�
            string strFreeItemXmlControl = "";
            strFreeItemXmlControl = configNode.Attributes["FreeItemXmlControl"].Value;
            //��ȡ�������ַ���
            string strFreeXml = "";
            control = HandleEvent.FindControl(strFreeItemXmlControl, InitFormClass.DetailForm);
            strFreeXml = HandleEventHelper.GetControlValue(control);

            if (!fbitFree)
                return true;
            else
            //����������ж�
            {
                //��ȡitemid
                string strItemID = "";
                control = HandleEvent.FindControl("���id", InitFormClass.DetailForm);
                strItemID = HandleEventHelper.GetControlValue(control);
                //ITEMID�����ݲ�ѯ����
                string strSqlCondition;
                strSqlCondition = string.Format(" WHERE fchrItemID = '{0}' ", strItemID);

                if (strFreeXml == string.Empty)
                    return CheckBatchDateFreeByFreeControl(args, strItemID, strSqlCondition);
                else
                    return CheckBatchDateFreeByFreeItemControl(args, strItemID, strFreeXml, strSqlCondition);
            }

        }
        /// <summary>
        /// ����FREEITEM�ؼ���ֵ�ж�
        /// </summary>
        /// <param name="args"></param>
        /// <param name="strItemID"></param>
        /// <param name="strFreeXml">freeitem�ؼ����ַ���</param>
        /// <param name="strSqlCondition"></param>
        /// <returns></returns>
        /// add by wq 2007.11.28
        /// ���ǰ�������������ITEMID �����ţ���Ч���Ƿ��Ӧ
        private bool CheckBatchDateFreeByFreeItemControl(ExternalMethodCallArgs args, string strItemID, string strFreeXml, string strSqlCondition)
        {

            //��ȡ�������ַ���
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(strFreeXml);
            XmlNodeList xmlList;
            xmlList = xmlDoc.SelectNodes("Root/Item");
            string strFreeName;
            string strFreeValue;
            string strSqlConditionTemp = "";
            bool sign = true;
            string strTemp;
            strTemp = strSqlCondition;
            foreach (XmlNode xmlNode in xmlList)
            {
                if (!sign)
                    break;
                strSqlConditionTemp = string.Empty;
                strSqlCondition = strTemp;
                foreach (XmlAttribute att in xmlNode.Attributes)
                {
                    if (att.Name.Contains("fchrFree"))
                    {
                        strFreeName = att.Name;
                        strFreeValue = att.Value;
                        if (strSqlConditionTemp == string.Empty)
                            strSqlConditionTemp = string.Format(" {0} = '{1}' ", strFreeName, strFreeValue);
                        else
                            strSqlConditionTemp += string.Format(" AND {0} = '{1}' ", strFreeName, strFreeValue);
                    }
                }
                strSqlCondition += string.Format(" AND ({0}) ", strSqlConditionTemp);
                CheckBatchDateFreeDeal(strSqlCondition, args, out sign);
            }
            return sign;

        }
        /// <summary>
        /// ����10��������ؼ����ж�
        /// </summary>
        /// <param name="args"></param>
        /// <param name="strItemID"></param>
        /// <param name="strSqlCondition"></param>
        /// <returns></returns>
        /// add by wq 2007.11.28
        /// ���ǰ�������������ITEMID �����ţ���Ч���Ƿ��Ӧ
        private bool CheckBatchDateFreeByFreeControl(ExternalMethodCallArgs args, string strItemID, string strSqlCondition)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            Control control;

            string strFreeControlName;
            string strFreeValue;
            string strSqlConditionTemp = "";
            string strTemp = "";
            bool sign = true;
            for (int i = 1; i <= 10; i++)
            {
                strFreeControlName = string.Format("fchrFree{0}", i);
                if (Tools.GetStringSysPara(strFreeControlName) != string.Empty)
                {
                    control = HandleEvent.FindControl(strFreeControlName, InitFormClass.DetailForm);
                    strFreeValue = HandleEventHelper.GetControlValue(control);
                    if (strFreeValue != string.Empty)
                        strTemp = string.Format(" {0} = '{1}' ", strFreeControlName, strFreeValue);
                    if (strSqlConditionTemp == string.Empty)
                        strSqlConditionTemp = strTemp;
                    else
                        strSqlConditionTemp += string.Format(" AND {0} ", strTemp);
                }
            }
            strSqlCondition += string.Format(" AND ({0}) ", strSqlConditionTemp);
            CheckBatchDateFreeDeal(strSqlCondition, args, out sign);
            return sign;
        }
        /// <summary>
        /// ���ݿ��ѯ���ж����š���Ч���Ƿ���itemid��Ӧ���� 
        /// </summary>
        /// <param name="strSqlCondition">���ݿ��ѯ������</param>
        /// <returns></returns>
        /// add by wq 2007.11.28
        /// ���ǰ�������������ITEMID �����ţ���Ч���Ƿ��Ӧ
        private void CheckBatchDateFreeDeal(string strSqlCondition, ExternalMethodCallArgs args, out bool sign)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            Control control;
            XmlNode configNode = args.ConfigNode;

            string strSql;
            strSql = string.Format("SELECT COUNT(DISTINCT fchrBatchCode) from dbo.ItemStocks {0}", strSqlCondition);

            //ȡ����
            string strBatchControl;
            string strBatch;
            strBatchControl = configNode.Attributes["BatchControl"].Value;
            control = HandleEvent.FindControl(strBatchControl, InitFormClass.DetailForm);
            strBatch = HandleEventHelper.GetControlValue(control);
            //ȡ��Ч��
            string strProductDateControl;
            string strProductDate;
            strProductDateControl = configNode.Attributes["ProduceDateControl"].Value;
            control = HandleEvent.FindControl(strProductDateControl, InitFormClass.DetailForm);
            strProductDate = HandleEventHelper.GetControlValue(control);

            if (strBatch != string.Empty)
                strSql += string.Format(" AND fchrBatchCode = '{0}' ", strBatch);
            if (strProductDate != string.Empty)
                strSql += string.Format(" AND fdtmProduceDate = '{0}' ", strProductDate);

            using (SqlConnection sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString()))
            {
                int count;
                count = Convert.ToInt32(SqlAccess.ExecuteScalar(sConn, CommandType.Text, strSql));
                if (count != 1)
                {
                    sign = false;
                    RetailMessageBox.ShowExclamation("����������Ż�Ч�ڲ���ȷ��");
                }
                else
                    sign = true;
            }

        }
        /// <summary>
        /// ��ԭ���˻���Ʒģʽ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>      
        /// add by wq 2007-12.19
        public bool CheckItemModelInNoExistBill(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            Control control;
            XmlNode configNode = args.ConfigNode;

            //��Ʒģʽ�ؼ���ֵ
            string strItemModelControl = "";
            int ftinItemModel;

            if (configNode.Attributes["ItemModelControl"] == null)
                strItemModelControl = "ftinItemModel";
            else
                strItemModelControl = configNode.Attributes["ItemModelControl"].Value;
            control = HandleEvent.FindControl(strItemModelControl, InitFormClass.DetailForm);
            ftinItemModel = Convert.ToInt32(HandleEventHelper.GetControlValue(control));

            //������ʾ��Ϣ
            string strErrorInfo = "";
            string strErrorInfoOpp = "";
            strErrorInfo = configNode.Attributes["ErrorInfo"].Value;
            strErrorInfoOpp = configNode.Attributes["ErrorInfoOpp"].Value;

            //ȡ��������
            DataSet ds;
            ds = (DataSet)InitFormClass.DGrid.DataSource;
            DataTable dt = new DataTable();
            dt = ds.Tables["DTDetail"];

            //û�����ݵ����
            if (dt.Rows.Count <= 1)
                return true;
            else
            {
                return CheckItemModel(dt, ftinItemModel, strErrorInfo, strErrorInfoOpp);
            }
        }
        /// <summary>
        /// �ж�¼����Ʒ����Ʒģʽ���Ƿ�������е�1��һ��
        /// </summary>
        /// <param name="dt">mainform�е����ݱ�</param>
        /// <param name="ftinItemModel">detail��ѡ������Ʒ��itemmodel</param>
        /// <param name="strErrorInfo">������Ϣ</param>
        /// <param name="strErrorInfoOpp">������Ϣ</param>
        /// <returns></returns>
        /// add by wq 2007-12.19
        private bool CheckItemModel(DataTable dt, int ftinItemModel, string strErrorInfo, string strErrorInfoOpp)
        {
            //ȡ��1�н��бȽ�
            int ftinTemp = Convert.ToInt32(dt.Rows[0]["ftinItemModel"]);
            //��ͬ���أ���ͬ����ͬ�����ʾ��Ϣ
            if (ftinItemModel == ftinTemp)
                return true;
            else
            {
                if (ftinItemModel == 1)
                    RetailMessageBox.ShowExclamation(strErrorInfo);
                else
                    RetailMessageBox.ShowExclamation(strErrorInfoOpp);

                return false;
            }
        }
        /// <summary>
        /// ԭ���˻���Ʒģʽ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// ��ע��
        /// ���пͻ�û��ʹ����Ӫ��Ʒ
        /// ���ڿ����Ѿ����ƣ�ԭ���˻��Ͳ����ܳ���ͬʱ������Ӫ��Ʒ�ͷ���Ӫ��Ʒ�����
        /// add by wq 2007.12.25
        /*  public bool CheckItemModelInExistBill(object sender, ExternalMethodCallArgs args)
          {
              HandleEvent eventHandler = args.HandleEvent;
              Init InitFormClass = eventHandler.InitFormClass;
              XmlNode configNode = args.ConfigNode;

              //List��������
              if (!eventHandler.SourceForm.GetType().Equals(typeof(frmList)))
                  return false;
              frmList oList=eventHandler.SourceForm as frmList;

              if (null == oList || null == oList.FormEngine || null == oList.FormEngine.sourceForm)
                  return false;
            
              //main��������
              DataGrid oReferGrid = ((PageGrid)oList.FormEngine.ListGrid).DBGrid as DataGrid;
              DataSet dsRefer = oReferGrid.DataSource as DataSet;
              DataTable dtRefer = dsRefer.Tables["DTDetail"];
              string standardItemModel = "";

              //ע�͵������Ǵ������е��ݴ�����Ӫ�ͷ���Ӫ��Ʒ��
              //��Ŀǰû�пͻ�ʹ����Ӫ��Ʒ�������ж�û��Ҫ
              //bool sign = true;
              //foreach (DataRow row in dtRefer.Select("UFSoft_Retail_Select = True"))
              //{
              //    if (standardItemModel == string.Empty)
              //        standardItemModel = row["ftinItemModel"].ToString();
              //    else
              //    {
              //        if (standardItemModel != row["ftinItemModel"].ToString())
              //        {
              //            sign = false;
              //            break;
              //        }
              //    }
              //}

              //ȡ��ѡ���ݵ�1�е�itemmodel
              standardItemModel = dtRefer.Select("UFSoft_Retail_Select = True")[0]["ftinItemModel"].ToString();

              //������ʾ��Ϣ
              string strErrorInfo = "";
              //string strErrorInfoM = "";
              string strErrorInfoOpp = "";            
              // strErrorInfoM = configNode.Attributes["ErrorInfoM"].Value;            
              //if (!sign)
              //{
              //    RetailMessageBox.ShowExclamation(strErrorInfoM);
              //    return false;
              //}
              //else
              //{

              //������Ϣ
              strErrorInfo = configNode.Attributes["ErrorInfo"].Value;
              strErrorInfoOpp = configNode.Attributes["ErrorInfoOpp"].Value;
              //��ǰ�б��ڵĸ�����ΪfrmMain,ת��ΪfrmMain
              frmMain oMain = oList.SourceForm as frmMain;
              DataSet dsGrid = oMain.FormEngine.DGrid.DataSource as DataSet;
              DataTable dtGrid = dsGrid.Tables["DTDetail"];
              if (dtGrid.Rows.Count < 1)
                  return true;
              else
              {
                  return CheckItemModel(dtGrid, Convert.ToInt32(standardItemModel),strErrorInfo,strErrorInfoOpp);
              }
           
          }*/
        /// <summary>
        /// �������
        /// ���ControlRequireClean�ڵ㶨��Ŀؼ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// ���ܣ����ݸ���
        /// ������������ӱ�id�ã������ݿ���������ݣ������Ǳ���
        /// add by wq 2007.12.25
        public void CleanControlValue(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            XmlNode configNode = args.ConfigNode;
            Control control;

            DataSet ds = InitFormClass.DGrid.DataSource as DataSet;
            DataTable dtDetail = ds.Tables["DTDetail"];
            DataTable dtMain = ds.Tables["DTMain"];

            //��Ҫ��յĿؼ�
            //main�����detail����ֿ�
            string strControlRC;
            string strDetailControlRC;
            string[] arrayControlRC;
            string[] arrayDetailControlRC;
            //main���岿��
            if (configNode.Attributes["ControlRequireClean"] != null)
            {
                strControlRC = configNode.Attributes["ControlRequireClean"].Value;
                arrayControlRC = strControlRC.Split(',');
                //��������
                foreach (string strControlName in arrayControlRC)
                {
                    control = HandleEvent.FindControl(strControlName, InitFormClass.MainForm);
                    control.Text = string.Empty;
                    if (dtMain != null)
                    {
                        foreach (DataRow row in dtMain.Rows)
                        {
                            row[strControlName] = DBNull.Value;
                        }
                    }
                }
            }
            //detail���岿��
            if (configNode.Attributes["DetailControlRequireClean"] != null)
            {
                strDetailControlRC = configNode.Attributes["DetailControlRequireClean"].Value;
                arrayDetailControlRC = strDetailControlRC.Split(',');
                //��������
                foreach (string strControlName in arrayDetailControlRC)
                {
                    //  control = HandleEvent.FindControl(strControlName, InitFormClass.DetailForm);
                    //  control.Text = string.Empty;
                    if (dtDetail != null)
                    {
                        foreach (DataRow row in dtDetail.Rows)
                        {
                            row[strControlName] = DBNull.Value;
                        }
                    }
                }
            }

        }
        /// <summary>
        /// ����ϴ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// ���ܣ����ݸ���
        /// add by wq 2007.12.25
        public void CleanUploadSign(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            XmlNode configNode = args.ConfigNode;

            DataSet ds = InitFormClass.DGrid.DataSource as DataSet;
            DataTable dtMain = ds.Tables["DTMain"];

            try
            {
                if (dtMain.Rows[0]["fbitexport"].Equals("true"))
                    dtMain.Rows[0]["fbitexport"] = "false";
            }
            catch (Exception ex)
            {
                RetailMessageBox.ShowExclamation(ex.Message);
            }

        }
        /// <summary>
        /// �޸����ϵ����ڵ���ǰ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// add by wq 2007.12.25
        public void ModifyDateToNow(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            XmlNode configNode = args.ConfigNode;

            //Ҫ�޸ĵ�����
            string strDateColumnName = configNode.Attributes["DateColumnName"].Value;

            DataSet ds = InitFormClass.DGrid.DataSource as DataSet;
            DataTable dtDetail = ds.Tables["DTDetail"];
            //�޸�ʱ�䵽��ǰʱ��
            if (dtDetail.Rows.Count < 1)
                return;
            else
            {
                foreach (DataRow row in dtDetail.Rows)
                {
                    row[strDateColumnName] = DateTime.Now.Date;
                }
            }
        }
        /// <summary>
        /// �ж�grid�Ƿ�����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// add by wq 2007.12.25
        /// �����ݷ���true
        public bool CheckDataIsEmpty(object sender, ExternalMethodCallArgs args)
        {
            return !CheckDataIsOrNotEmpty(args);
        }
        /// <summary>
        /// �ж�grid�Ƿ�����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// �����ݷ���false
        public bool CheckDataIsNotEmpty(object sender, ExternalMethodCallArgs args)
        {
            return CheckDataIsOrNotEmpty(args);
        }
        //�ж�grid�������Ƿ�Ϊ��
        private bool CheckDataIsOrNotEmpty(ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;

            DataSet ds = InitFormClass.DGrid.DataSource as DataSet;
            if (ds.Tables["DTDetail"].Rows.Count < 1)
                return false;
            else return true;
        }

        /// <summary>
        /// ��������¼��    ssy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void AddByBarCode(object sender, ExternalMethodCallArgs args)
        {
            string param = Tools.GetStringAttribute((XmlElement)args.ConfigNode, "param");
            bool isInOutBill = true;
            HandleEvent eventHandler = args.HandleEvent;
            if (param.Equals("RealCheck") || param.Equals("RealCheckDetail"))
            {
                Control objControl = sender as Control;
                Form objForm = objControl.FindForm();
                RefControl barCode = HandleEventHelper.FindControl("fchrCheckSetoutCode", objForm) as RefControl;
                if (barCode != null)
                {
                    if (barCode.TextBox.TextLength == 0)
                    {
                        RetailMessageBox.ShowWarning("��ѡ���̵�׼������");
                        return;
                    }
                }
                isInOutBill = false;
            }
            frmAddDetail frmadd = new frmAddDetail();
            frmadd.Sender = sender;
            frmadd.ExternalMethodCall = args;
            frmadd.CheckDoWith = this;
            frmadd.ConfigNode = args.ConfigNode;
            frmadd.HandleEvent = eventHandler;
            frmadd.DataGrid = eventHandler.GetDataGrid();
            frmadd.Size = new System.Drawing.Size(459, 136);
            frmadd.IsInOutBill = isInOutBill;
            frmadd.ShowIcon = false;
            frmadd.ShowInTaskbar = false;
            frmadd.ShowDialog();
        }

        public void VaildateBarCode(object sender, ExternalMethodCallArgs args)
        {
            RefControl refControl = HandleEventHelper.FindControl("����", args.HandleEvent.SourceForm) as RefControl;
            frmAddDetail frm = new frmAddDetail();
            frm.DataGrid = args.HandleEvent.GetDataGrid();
            frm.CheckBarCode(refControl.TextBox.Text);
        }
        public bool CheckItemRangeForAddButton(object sender, ExternalMethodCallArgs args)
        {
            //����ʵ�̵�¼��ʱ��������¼��׼������û�У�������������е���Ʒ��V891���ڲ���
            //if (Tools.GetIntSysPara("CheckInputItemRange") == 1)
            //{
                RefControl objRefControl = HandleEventHelper.FindControl("fchrCheckSetoutCode", args.HandleEvent.GetMainForm(sender)) as RefControl;
                string fchrCheckSetoutCode = objRefControl.TextBox.Text.Trim();
                if (string.IsNullOrEmpty(fchrCheckSetoutCode))
                {
                    RetailMessageBox.ShowExclamation("����ѡ���̵�׼������");
                    return false;
                }

                RefControl refControl = HandleEventHelper.FindControl("����", args.HandleEvent.SourceForm) as RefControl;
                if (string.IsNullOrEmpty(refControl.RefID))
                    return false;
                if (refControl.RefID.IndexOf(',') != -1)
                    return true;//��ѡΪ��������������ǣ��ڲ���������Ѿ���������

                //StringBuilder objSql = new StringBuilder();
                string fchrItemID = refControl.RefID;
                //objSql.Append("select [fchrItemID]");
                //objSql.Append(" from [CheckSetoutDetail] Where fchrCheckSetoutID in ");
                //objSql.AppendFormat(" (Select top 1 fchrCheckSetoutID From CheckSetout Where fchrCode='{0}') AND fchrItemID='{1}'", fchrCheckSetoutCode, fchrItemID);

                //DataTable objTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, objSql.ToString()).Tables[0];
                //if (objTable.Rows.Count < 1)
                //{
                //    RetailMessageBox.ShowExclamation("�������Ʒ���ڵ�ǰ�̵�׼�����ڣ�");
                //    refControl.Clear();
                //    return false;
                //}
                //else
                //    return true;


                string strErroeMessage = string .Empty;
                if (CheckUtility.CheckRealStockInputItemRange(fchrCheckSetoutCode, fchrItemID, out strErroeMessage))
                {
                    return true;
                }
                else
                {
                    RetailMessageBox.ShowExclamation(strErroeMessage);
                    refControl.Clear();
                    return false;
                }

            //}
            //return true;
        }
        public bool CheckItemRangeForAddButtonModify(object sender, ExternalMethodCallArgs args)
        {
            //����ʵ�̵�¼��ʱ��������¼��׼������û�У�������������е���Ʒ��V891���ڲ���
            //if (Tools.GetIntSysPara("CheckInputItemRange") == 1)
            //{
                ExLabel objRefControl = HandleEventHelper.FindControl("fchrCheckSetoutCode", args.HandleEvent.GetMainForm(sender)) as ExLabel;
                string fchrCheckSetoutCode = objRefControl.ControlValue.Trim();
                if (string.IsNullOrEmpty(fchrCheckSetoutCode))
                {
                    RetailMessageBox.ShowExclamation("����ѡ���̵�׼������");
                    return false;
                }

                RefControl refControl = HandleEventHelper.FindControl("����", args.HandleEvent.SourceForm) as RefControl;
                if (string.IsNullOrEmpty(refControl.RefID))
                    return false;
                if (refControl.RefID.IndexOf(',') != -1)
                    return true;//��ѡΪ��������������ǣ��ڲ���������Ѿ���������

                //StringBuilder objSql = new StringBuilder();
                string fchrItemID = refControl.RefID;
                //objSql.Append("select [fchrItemID]");
                //objSql.Append(" from [CheckSetoutDetail] Where fchrCheckSetoutID in ");
                //objSql.AppendFormat(" (Select top 1 fchrCheckSetoutID From CheckSetout Where fchrCode='{0}') AND fchrItemID='{1}'", fchrCheckSetoutCode, fchrItemID);

                //DataTable objTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, objSql.ToString()).Tables[0];
                //if (objTable.Rows.Count < 1)
                //{
                //    RetailMessageBox.ShowExclamation("�������Ʒ���ڵ�ǰ�̵�׼�����ڣ�");
                //    refControl.Clear();
                //    return false;
                //}
                //else
                //    return true;

                string strErroeMessage = string.Empty;
                if (CheckUtility.CheckRealStockInputItemRange(fchrCheckSetoutCode, fchrItemID, out strErroeMessage))
                {
                    return true;
                }
                else
                {
                    RetailMessageBox.ShowExclamation(strErroeMessage);
                    refControl.Clear();
                    return false;
                }
            //}
            //return true;
        }

        /// <summary>
        /// ���̵�׼��������
        /// </summary>
        public void ShowCheckListRef(object sender, ExternalMethodCallArgs args)
        {
            //ssy
            Control c = null;
            string strValues = "";
            string inXml = "";
            string ErrDesc = "";
            DataSet dsRefer = new DataSet();
            DataTable dtRefer = null;
            DataGrid oReferGrid = new DataGrid();
            DataGrid oSourceGrid = new DataGrid();

            RefControl refcontrol = HandleEventHelper.FindControl("fchrCheckSetoutCode", args.HandleEvent.InitFormClass.MainForm) as RefControl;
            //if (refcontrol.TextBox.ReadOnly)
            //{
            //    //if (Tools.GetStringSysPara("CheckRelation") == "1")
            //    //{
            //        RetailMessageBox.ShowWarning(args.HandleEvent.InitFormClass.MainForm, "�����Ʒ�к���ܲ��գ�");
            //        return;
            //    //}
            //}
            DataGrid ParentGrid = args.HandleEvent.InitFormClass.DGrid;
            DataSet ds = ParentGrid.DataSource as DataSet;
            if (ds != null)
            {
                if (ds.Tables.Contains(ApplicationConstraints.DetailTableName))
                {
                    if (ds.Tables[ApplicationConstraints.DetailTableName].Rows.Count > 0)
                    {
                        RetailMessageBox.ShowWarning(args.HandleEvent.InitFormClass.MainForm, "�����Ʒ�к���ܲ��գ�");
                        return;
                    }
                }
            }
            //�ж�ϵͳ����ʵ�̵���Ӧ��ϵ�����Ϊһ��һʱ���������£�
            if (Tools.GetStringSysPara("CheckRelation") == "0")
            {
                refcontrol.ParentCondition = refcontrol.ParentCondition + " and fchrCheckSetoutID not in (select fchrCheckSetoutID from realstocks) ";
            }
            frmSelect frmselect = refcontrol.GetSelectFrom();

            if (frmselect.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            strValues = frmselect.RefName;

            c = HandleEvent.FindControl("fchrCheckSetoutCode", args.HandleEvent.SourceForm);
            if (null == c) return;
            (c as RefControl).TextBox.Text = strValues;

            //������� 
            string refID = frmselect.RefID;
            (HandleEventHelper.FindControl("fchrCheckSetoutID", args.HandleEvent.InitFormClass.MainForm) as ExLabel).ControlValue = refID;
            (HandleEventHelper.FindControl("fchrCheckSetoutCode", args.HandleEvent.InitFormClass.MainForm) as RefControl).ControlValue = strValues;


            Type t = args.HandleEvent.InitFormClass.DGrid.GetType();
            XmlDocument doc = new XmlDocument();

            //ParentGrid=((PageGrid)InitFormClass.ListGrid).DBGrid as DataGrid;
            HandleEvent.FilterEmptyRows(ParentGrid);

            string pageNum = t.InvokeMember("CurrentPage", BindingFlags.GetProperty, null, args.HandleEvent.InitFormClass.DGrid, null).ToString();
            inXml = "<Data ParentCondition=' 1=1 '  PageSize=\"1\"  PageIndex=\"" + (pageNum == "0" || pageNum == "0" ? "1" : pageNum) + "\" TemplateName='CheckSetoutDetail' ><Where><Node Name='fchrCode' Value=\"" + strValues + "\"/></Where></Data>";
            doc.LoadXml(inXml);
            SQLSource Process = new SQLSource(SysPara.GetSysPara("SysConn").ToString());
            Process.GetReferData(doc.DocumentElement.OuterXml, dsRefer, out ErrDesc);
            AddSelectableColumn(true, args.HandleEvent.InitFormClass.DGrid, dsRefer);
            oSourceGrid = args.HandleEvent.InitFormClass.DGrid;
            if (dsRefer.Tables.Count > 0)
                dtRefer = dsRefer.Tables[0];

            //���˵����� by ylc 
            HandleEvent.FilterEmptyRows(oSourceGrid);
            foreach (DataRow oRow in dtRefer.Rows)
            {
                oRow[ApplicationConstraints.SelectColumnName] = true;
                //��ʾ�����
                try
                {
                    //�жϽ���Ƿ�Ϊ��
                    if (Convert.ToInt32(oRow["flotmoney"]) == 0)
                    {
                        if (oRow["flotQuantity"] == DBNull.Value)
                        {
                        }
                        else if (oRow["flotQuantity"].ToString() == "")
                        {
                            oRow["flotQuantity"] = "0";
                        }

                        if (oRow["flotQuotePrice"].ToString() == "")
                        {
                            oRow["flotQuotePrice"] = "0";
                        }

                        if (oRow["flotQuantity"] == DBNull.Value)
                        {
                            oRow["flotmoney"] = DBNull.Value;
                        }
                        else
                        {
                            float flotmoney = float.Parse(oRow["flotQuantity"].ToString()) * float.Parse(oRow["flotQuotePrice"].ToString());
                            oRow["flotmoney"] = flotmoney.ToString();
                        }
                        
                    }
                }
                catch { }
            }
            args.HandleEvent.ImportDataRow(oSourceGrid, dtRefer);
        }

        /// <summary>
        /// ��Grid�������
        /// </summary>
        /// <param name="fromRow">Դ</param>
        /// <param name="destRow">Ŀ��</param>
        /// <param name="columnNames">Ҫ��ӵ���</param>
        public void AddRow(DataRow fromRow, DataRow destRow, List<string> columnNames)
        {
            foreach (string columnName in columnNames)
            {
                try
                {
                    destRow[columnName] = fromRow[columnName];
                }
                catch
                {
                }
            }
        }

        public static void AddSelectableColumn(bool boolShowCheckBox, Control grid, DataSet inDataSet)
        {
            string _SelectionColumnTitle = "ѡ��";
            string _SelectionColumnName = ApplicationConstraints.SelectColumnName;
            if (!boolShowCheckBox)
                return;

            if (null == grid || null == inDataSet)
                return;

            //Ϊ��������ѡ����
            if (inDataSet.Tables.Count > 0)
            {
                DataColumn oCol = new DataColumn(_SelectionColumnName, typeof(System.Boolean));
                oCol.Caption = _SelectionColumnTitle;
                oCol.DefaultValue = false;
                inDataSet.Tables[0].Columns.Add(oCol);
            }
        }

        public void CheckInventory(object sender, ExternalMethodCallArgs args)
        {
            CheckInventoryNoParam(args);
        }

        public void CheckInventoryNoParam(ExternalMethodCallArgs args)
        {
            Control c = null;
            string strValues = "";
            //string inXml = "";
            //string ErrDesc = "";
            //DataSet dsRefer = new DataSet();
            //DataTable dtRefer = null;
            DataGrid oReferGrid = new DataGrid();
            DataGrid oSourceGrid = new DataGrid();
            c = HandleEvent.FindControl("fchrCheckSetoutCode", args.HandleEvent.SourceForm);
            if (null == c) return;
            strValues = HandleEventHelper.GetControlValues(c, "RefControl");
            (HandleEventHelper.FindControl("fchrCheckSetoutID", args.HandleEvent.InitFormClass.MainForm) as ExLabel).ControlValue = strValues;
            #region
            //(HandleEventHelper.FindControl("fchrCheckSetoutCode", args.HandleEvent.InitFormClass.MainForm) as RefControl).ControlValue = (c as RefControl).RefName;

            /*
                //ʵ�̵�¼����棬���ڱ�ͷ�ġ��̵�׼��������ѡ��ĳ���̵�׼����ʱ�����ٵ�����ʾ���Ƿ���Ӹ��̵�׼������������Ʒ������
                //Ҳ�����׼�����е���Ʒ���������ϡ�
                //872 chb 2008-09-10
                if (RetailMessageBox.ShowQuestion("�Ƿ���Ӹ��̵�׼������������Ʒ��") == DialogResult.Yes)
                {
                    Type t = args.HandleEvent.InitFormClass.DGrid.GetType();
                    XmlDocument doc = new XmlDocument();

                    //ParentGrid=((PageGrid)InitFormClass.ListGrid).DBGrid as DataGrid;
                    DataGrid ParentGrid = args.HandleEvent.InitFormClass.DGrid;
                    HandleEvent.FilterEmptyRows(ParentGrid);
                    DataSet ds = ParentGrid.DataSource as DataSet;
                    if (ds != null)
                    {
                        if (ds.Tables.Contains(ApplicationConstraints.DetailTableName))
                        {
                            if (ds.Tables[ApplicationConstraints.DetailTableName].Rows.Count > 0)
                            {
                                if (RetailMessageBox.ShowQuestion("�Ƿ����ԭ����Ʒ�У�") == DialogResult.Yes)
                                {
                                    ds.Tables[ApplicationConstraints.DetailTableName].Clear();
                                }
                            }
                        }
                    }

                    string pageNum = t.InvokeMember("CurrentPage", BindingFlags.GetProperty, null, args.HandleEvent.InitFormClass.DGrid, null).ToString();
                    inXml = "<Data ParentCondition=' 1=1 '  PageSize=\"1\"  PageIndex=\"" + (pageNum == "0" || pageNum == "0" ? "1" : pageNum) + "\" TemplateName='CheckSetoutDetail' ><Where><Node Name='fchrCode' Value=\"" + strValues + "\"/></Where></Data>";
                    doc.LoadXml(inXml);
                    SQLSource Process = new SQLSource(SysPara.GetSysPara("SysConn").ToString());
                    Process.GetReferData(doc.DocumentElement.OuterXml, dsRefer, out ErrDesc);
                    AddSelectableColumn(true, args.HandleEvent.InitFormClass.DGrid, dsRefer);
                    oSourceGrid = args.HandleEvent.InitFormClass.DGrid;
                    if (dsRefer.Tables.Count > 0)
                        dtRefer = dsRefer.Tables[0];

                    //���˵����� by ylc 
                    HandleEvent.FilterEmptyRows(oSourceGrid);
                    foreach (DataRow oRow in dtRefer.Rows)
                    {
                        oRow[ApplicationConstraints.SelectColumnName] = true;
                    }
                    args.HandleEvent.ImportDataRow(oSourceGrid, dtRefer);
                }
           */
            #endregion
        }

        /// <summary>
        /// ���ʵ�̵�����ʱ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool CheckQuantityForCheckSetout(object sender, ExternalMethodCallArgs args)
        {
            DataGrid dg = args.HandleEvent.GetDataGrid();
            DataTable dt = (dg.DataSource as DataSet).Tables[ApplicationConstraints.DetailTableName];
            foreach (DataRow row in dt.Rows)
            {
                if (row["flotQuantity"].ToString() == "")
                {
                    RetailMessageBox.ShowWarning("��ϸ���ݵ���������Ϊ�ա�\n����ִ�б��������");
                    //DataSet ds = InitFormClass.DGrid.DataSource as DataSet;
                    //if (ds != null)
                    //{
                    //    if (ds.Tables.Contains(ApplicationConstraints.DetailTableName))
                    //    {
                    //        if (ds.Tables[ApplicationConstraints.DetailTableName].Rows.Count > 0)
                    //        {
                    //            ds.Tables[ApplicationConstraints.DetailTableName].Clear();
                    //        }
                    //    }
                    //}
                    return false;
                }
            }
            return true;
        }

        public void CheckSetoutRelation(object sender, ExternalMethodCallArgs args)
        {
            RefControl refControl = sender as RefControl;
            //�ж�ʵ�̵���Ӧ��ϵ
            //�ж�ϵͳ����ʵ�̵���Ӧ��ϵ�����Ϊһ��һʱ���������£�
            if (Tools.GetStringSysPara("CheckRelation") == "0")
            {
                refControl.ParentCondition = refControl.ParentCondition + " and fchrCheckSetoutID not in (select fchrCheckSetoutID from realstocks) ";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="el"></param>
        /// <param name="src"></param>
        public void ItemStocksMapped(object sender, ExternalMethodCallArgs args)
        {
            XmlElement el = args.ConfigNode as XmlElement;
            HandleEvent eventHandler = args.HandleEvent;
            Control src = sender as Control;
            string inXml = "";
            string ErrDesc = "";
            string strBackMsg = "";
            string strCondition = "";
            string strSQL = "";
            string strSelectButton = "";
            int j = 0;
            int intResult = 0;
            DataTable dt = new DataTable();
            SqlConnection sConn = null;
            XmlNodeList docChildNodes = null;
            XmlDocument doc = new XmlDocument();
            DataSet inDataSet = new DataSet();
            Type t = eventHandler.InitFormClass.ListGrid.GetType();
            sConn = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
            DataGrid ParentGrid = ((PageGrid)eventHandler.InitFormClass.ListGrid).DBGrid as DataGrid;
            DataSet ds = ParentGrid.DataSource as DataSet;

            if (ds != null)
            {
                if (ds.Tables.Contains(ApplicationConstraints.DetailTableName))
                {
                    if (ds.Tables[ApplicationConstraints.DetailTableName].Rows.Count > 0)
                    {
                        RetailMessageBox.ShowWarning("������������е���Ʒ�У�");
                        return;
                    }
                    else
                    {
                        //  ��������
                        eventHandler.SelectqueryBackReceipt(el, src, ref strBackMsg, ref strSelectButton);
                        if (strSelectButton != "OK")
                            return;
                        if (RetailMessageBox.ShowQuestion("��ȷ����ǰ�ĵ����������µģ��Ƿ������") == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
            }
            else
            {
                eventHandler.SelectqueryBackReceipt(el, src, ref strBackMsg, ref strSelectButton);
                if (strSelectButton != "OK")
                    return;
                if (RetailMessageBox.ShowQuestion("��ȷ����ǰ�ĵ����������µģ��Ƿ������") == DialogResult.No)
                {
                    return;
                }
            }

            //"<Where> <Condition Value=\"fchrItemType  like ' c001 %'\" /> <Condition Value=\"fchrItemName  = ' hp0101 '\" /></Where>"
            if (strBackMsg != "")
            {
                doc.LoadXml(strBackMsg);
                docChildNodes = doc.SelectNodes("Where/Condition");
                if (docChildNodes.Count > 0)
                {
                    strSQL = "Insert Into CheckSetoutItemList (fchrItemID,fchrFree1,fchrFree2,fchrFree3, fchrFree4,fchrFree5,fchrFree6, fchrFree7,fchrFree8,fchrFree9,fchrFree10, fchrBatchCode, fdtmProduceDate,fdtmInvalidDate)  SELECT distinct fchrItemID,fchrFree1,fchrFree2,fchrFree3, fchrFree4,fchrFree5,fchrFree6, fchrFree7,fchrFree8,fchrFree9,fchrFree10, fchrBatchCode, fdtmProduceDate,fdtmInvalidDate FROM viewItemStocks WHERE   ";
                    j = docChildNodes.Count;
                    for (int i = 0; i < j; i++)
                    {
                        XmlNode oN = docChildNodes[i];
                        strCondition = Tools.GetStringAttribute((XmlElement)oN, "Value");
                        if (i < j - 1)
                            strSQL = strSQL + strCondition + " AND ";
                        else
                            strSQL = strSQL + strCondition;
                    }
                }
                else
                {
                    strSQL = "Insert Into CheckSetoutItemList (fchrItemID,fchrFree1,fchrFree2,fchrFree3, fchrFree4,fchrFree5,fchrFree6, fchrFree7,fchrFree8,fchrFree9,fchrFree10, fchrBatchCode, fdtmProduceDate,fdtmInvalidDate)  SELECT distinct fchrItemID,fchrFree1,fchrFree2,fchrFree3, fchrFree4,fchrFree5,fchrFree6, fchrFree7,fchrFree8,fchrFree9,fchrFree10, fchrBatchCode, fdtmProduceDate,fdtmInvalidDate FROM viewItemStocks";
                }
            }
            else
            {
                strSQL = "Insert Into CheckSetoutItemList (fchrItemID,fchrFree1,fchrFree2,fchrFree3, fchrFree4,fchrFree5,fchrFree6, fchrFree7,fchrFree8,fchrFree9,fchrFree10, fchrBatchCode, fdtmProduceDate,fdtmInvalidDate)  SELECT distinct fchrItemID,fchrFree1,fchrFree2,fchrFree3, fchrFree4,fchrFree5,fchrFree6, fchrFree7,fchrFree8,fchrFree9,fchrFree10, fchrBatchCode, fdtmProduceDate,fdtmInvalidDate FROM viewItemStocks";
            }
            intResult = SqlAccess.ExecuteNonQuery(sConn, CommandType.Text, "TRUNCATE TABLE CheckSetoutItemList");
            intResult = SqlAccess.ExecuteNonQuery(sConn, CommandType.Text, strSQL);
            intResult = SqlAccess.ExecuteNonQuery(sConn, CommandType.Text, "DELETE FROM CheckSetoutItemList WHERE  fchrItemID IN (SELECT DISTINCT fchrItemID FROM CheckSetout,CheckSetoutDetail WHERE CheckSetout.fchrCheckSetoutID=CheckSetoutDetail.fchrCheckSetoutID AND ISNULL(CheckSetout.fbitCheck,0)=0)");
            if (intResult > 0)
            {
                RetailMessageBox.ShowWarning("�Ѵ���δ���˵��̵�׼�����е���Ʒ���ܼ��룡");
            }
            string pageNum = t.InvokeMember("CurrentPage", BindingFlags.GetProperty, null, eventHandler.InitFormClass.ListGrid, null).ToString();
            inXml = "<Data ParentCondition=' 1=1 ' PageSize=\"20\"  PageIndex=\"" + (pageNum == "0" || pageNum == "0" ? "1" : pageNum) + "\" TemplateName='CheckInventory' ><Where><Node Name='ftinItemModel' Value=\"1\"/></Where></Data>";
            doc.LoadXml(inXml);

            SQLSource Process = new SQLSource(SysPara.GetSysPara("SysConn").ToString());
            Process.GetReferData(doc.DocumentElement.OuterXml, inDataSet, out ErrDesc);
            //			//  ��ʾ�ϼ���
            dt = inDataSet.Tables[ApplicationConstraints.DetailTableName];
            eventHandler.CalGridTotal(dt);
            t.InvokeMember("DataSource", BindingFlags.SetProperty, null, eventHandler.InitFormClass.ListGrid, new object[] { inDataSet });
            t.InvokeMember("DataBind", BindingFlags.InvokeMethod, null, eventHandler.InitFormClass.ListGrid, null);

        }
        public void UpdateCheck(object sender, ExternalMethodCallArgs args)
        {
            XmlElement no = args.ConfigNode as XmlElement;
            Control src = sender as Control;
            HandleEvent eventHandler = args.HandleEvent;

            string ErrDesc = "";
            string sSQLTemplate = "";
            string sOperatorField = "";
            DataGrid ParentGrid = null;
            DataTable dt = null;
            DataRow dr = null;
            //��ȡ����������Ϣ
            int nRet = eventHandler.DealDelNode(no, src, ref sSQLTemplate, ref sOperatorField);
            if (nRet != 0)
            {
                RetailMessageBox.ShowWarning("���ݴ���:\n ���ܻ�ȡ��������ס����");
                return;
            }

            if (null == sSQLTemplate || sSQLTemplate.Length <= 0)
            {
                RetailMessageBox.ShowWarning("���ݴ���:\n �Ƿ����ݲ���ģ�塣 ");
                return;
            }

            //Type t = InitFormClass..GetType();
            System.Reflection.PropertyInfo p = eventHandler.GetPropertyInfo(eventHandler.InitFormClass.DGrid, "DataSource");
            DataSet ds = (DataSet)p.GetValue(eventHandler.InitFormClass.DGrid, null);//t.InvokeMember("DataSource",BindingFlags.GetProperty,null,InitFormClass.ListGrid,null);
            if (null == ds || ds.Tables.Count <= 0 || !ds.Tables.Contains(ApplicationConstraints.DetailTableName))
            {
                RetailMessageBox.ShowWarning("���ݴ���:\n û�пɹ����������");
                return;
            }

            ParentGrid = eventHandler.InitFormClass.DGrid;
            dt = ds.Tables[ApplicationConstraints.DetailTableName];

            bool isRealcheck = Tools.GetBoolSysPara("CheckType");
            if (isRealcheck)
            {
                if (dt.Rows.Count <= 0)
                {
                    RetailMessageBox.ShowWarning("���ݴ���:\n û�пɹ����������");
                    return;
                }
            }
            try
            {

                dr = eventHandler.GetCurrentRow(ParentGrid.CurrentRowIndex, dt);
                UpdateCheckData(dr, sSQLTemplate, no, eventHandler);
            }
            catch (Exception ex)
            {
                //���ʧ��
                ErrDesc = ex.Message;
                RetailMessageBox.ShowWarning("���ݴ���:\n" + ErrDesc);
                return;
            }

            //�����б�
            //this.RefreshWindow(no,src);
            if (eventHandler.SourceForm is IEditForm)
            {
                (eventHandler.SourceForm as IEditForm).HasChanged = false;
            }
            eventHandler.SourceForm.Close();
        }
        private void UpdateCheckData(DataRow oRow, string sDataSourceTemplate, XmlElement oN, HandleEvent eventHandler)
        {
            string strMessage1 = "";
            string strTitle1 = "";
            string strMessage2 = "";
            string strTitle2 = "";
            string strType = "";
            DataSet dsSave = new DataSet();
            DataTable dtMain = new DataTable("Main");

            XmlNodeList docChildNodes = null;
            docChildNodes = oN.SelectNodes("DataSourceLink");

            XmlNode no = docChildNodes[0];
            strType = Tools.GetStringAttribute((XmlElement)no, "Type");

            //��ȡ����ֵ�ؼ�
            ValueControls oiter = HandleEvent.GetValueControls(eventHandler.SourceForm);
            if (null == oiter)
                throw (new Exception("���ܷ�������ֵ�ؼ��б�"));

            //by pxc
            //����Ƿ���Խ���ָ���Ĳ���
            //ͨ�����ʽ�ж�
            string sDesc = "";
            if (!eventHandler.CanDoNextOperation(oRow, oN, ref sDesc))
            {
                RetailMessageBox.ShowWarning("���ܽ��в�����\nԭ����:" + sDesc);
                return;
            }
            // �ж��ǲ����Ѿ���ʾ�����Ժ���Ը���Ϊ����ѡʱ���ȷ��

            // �õ�ѯ�ʵ����
            strMessage1 = Tools.GetStringAttribute((XmlElement)no, "Message1");
            if (strMessage1 == "")
            {
                strMessage1 = "���潫�������ݣ��Ƿ������";
            }
            strTitle1 = Tools.GetStringAttribute((XmlElement)no, "Title1");
            if (strTitle1 == "")
            {
                strTitle1 = "��ʾ";
            }
            MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
            if (no.Attributes["MessageBoxDefaultButton"] != null)
            {
                if (no.Attributes["MessageBoxDefaultButton"].Value.ToUpper() == "NO")
                {
                    defaultButton = MessageBoxDefaultButton.Button2;
                }
            }
            DialogResult dr = RetailMessageBox.ShowQuestion(strMessage1, defaultButton);
            if (dr == DialogResult.No)
            {
                return;
            }

            dtMain = eventHandler.CreateMainTable();

            //Seaman Xiong 2006-5-26 �ų�������
            if (dsSave.Tables.Contains("Main"))
            {
                dsSave.Tables.Remove("Main");
            }
            dsSave.Tables.Add(dtMain);

            //Seaman Xiong 2006-5-26 �ų�������
            if (!dsSave.ExtendedProperties.ContainsKey("TemplateID"))
                dsSave.ExtendedProperties.Add("TemplateID", sDataSourceTemplate);

            Data process = new Data();
            string errDesc = "";
            string outXML = "";
            process.Save("<u/>", dsSave, ref outXML, ref errDesc);
            if (errDesc != "")
                throw (new Exception(errDesc));

            //  ��ɺ���ʾ��ɵ���Ϣ
            strMessage2 = Tools.GetStringAttribute((XmlElement)no, "Message2");
            if (strMessage2 == "")
            {
                strMessage2 = "�ɹ�������ݸ��£�";
            }
            strTitle2 = Tools.GetStringAttribute((XmlElement)no, "Title2");
            if (strTitle2 == "")
            {
                strTitle2 = "���µ���";
            }
            RetailMessageBox.ShowInformation(strMessage2);

        }
        public void RealStockUniteItem(object sender, ExternalMethodCallArgs args)
        {
            DataGrid objDataGrid = args.HandleEvent.GetDataGrid();
            DataTable objTable = args.HandleEvent.GetDetailTable();
            UniteItem(objTable);
        }
        private DataTable UniteItem(DataTable objSTable)
        {

            for (int i = 0; i < objSTable.Rows.Count; i++)
            {
                if (objSTable.Rows[i].RowState == DataRowState.Deleted
                    || objSTable.Rows[i].RowState == DataRowState.Detached) continue;

                if (objSTable.Rows[i]["fchrBatchCode"].ToString().Equals(""))
                    objSTable.Rows[i]["fchrBatchCode"] = "";
                if (objSTable.Columns["fdtmProduceDate"].DataType.Name == "String")
                {
                    if (objSTable.Rows[i]["fdtmProduceDate"].ToString().Equals(""))
                        objSTable.Rows[i]["fdtmProduceDate"] = "";
                }
                for (int j = 1; j <= 10; j++)
                {
                    if (objSTable.Rows[i]["fchrfree" + j.ToString()].ToString().Equals(""))
                        objSTable.Rows[i]["fchrfree" + j.ToString()] = "";
                }
            }
            double quantity = 0.0;
            int index = -1;
            for (int i = 0; i < objSTable.Rows.Count; i++)
            {
                if (objSTable.Rows[i].RowState == DataRowState.Deleted
                  || objSTable.Rows[i].RowState == DataRowState.Detached) continue;
                string fchrFilter = GetFilter(objSTable.Rows[i]);

                DataRow[] objRows = objSTable.Select(fchrFilter);
                if (objRows.Length == 0 || objRows.Length == 1) continue;
                quantity = 0.00;
                index = -1;
                for (int j = 0; j < objRows.Length; j++)
                {
                    if (objRows[j].RowState == DataRowState.Deleted
                 || objRows[j].RowState == DataRowState.Detached) continue;

                    quantity += Tools.GetDblColumnValue(objRows[j]["flotQuantity"]);
                    if (index != -1)
                    {
                        objRows[j].Delete();
                    }
                    else
                    {
                        index = j;
                    }
                }
                objRows[index]["flotQuantity"] = quantity;
            }
            return objSTable;
        }

        private string GetFilter(DataRow objTRow)
        {
            StringBuilder objFilter = new StringBuilder();
            objFilter.AppendFormat("(fchrItemID='{0}') AND ", objTRow["fchrItemID"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrBatchCode='{0}') AND ", objTRow["fchrBatchCode"].ToString().Replace("'", ""));
            string fdtmProduceDate = objTRow["fdtmProduceDate"].ToString().Replace("'", "");
            if (fdtmProduceDate.Equals(""))
            {
                if (objTRow.Table.Columns["fdtmProduceDate"].DataType.Name == "String")
                {
                    objFilter.Append("(fdtmProduceDate ='') AND ");
                }
                else
                {
                    objFilter.Append("(fdtmProduceDate is  Null) AND ");
                }
            }
            else
            {
                objFilter.AppendFormat("(fdtmProduceDate='{0}') AND ", objTRow["fdtmProduceDate"].ToString().Replace("'", ""));
            }
            //�ѡ���Ʒ+������+����+��������/��Ч����+��λ������ͬ���е������ͽ��ϲ���V8.91, libo, 2010-02-01
            //׷�ӻ�λID��V8.91, libo, 2010-02-01
            if (string.IsNullOrEmpty(objTRow["fchrPosID"].ToString()))
            {
                objFilter.AppendFormat("fchrPosID is Null AND ");
            }
            else
            {
                objFilter.AppendFormat("(fchrPosID='{0}') AND ", objTRow["fchrPosID"].ToString().Replace("'", ""));
            }
            objFilter.AppendFormat("(fchrfree1='{0}') AND ", objTRow["fchrfree1"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree2='{0}') AND ", objTRow["fchrfree2"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree3='{0}') AND ", objTRow["fchrfree3"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree4='{0}') AND ", objTRow["fchrfree4"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree5='{0}') AND ", objTRow["fchrfree5"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree6='{0}') AND ", objTRow["fchrfree6"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree7='{0}') AND ", objTRow["fchrfree7"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree8='{0}') AND ", objTRow["fchrfree8"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree9='{0}') AND ", objTRow["fchrfree9"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree10='{0}') ", objTRow["fchrfree10"].ToString().Replace("'", ""));
            return objFilter.ToString();
        }

         /// <summary>
        /// ���������Ƿ�����
        /// </summary>
        /// <returns></returns>
        public bool CheckIsReferencedVouch(object sender, ExternalMethodCallArgs args)
        {
            try
            {
                ExDataGridView dataGrid = args.HandleEvent.GetDataGrid() as ExDataGridView;

                if (dataGrid.CurrentRowIndex < 0)
                {
                    return true;
                }

                DataTable table = (dataGrid.DataSource as DataSet).Tables[dataGrid.DataMember];

                if (table != null)
                {
                    bool isTempReceipt = Convert.ToBoolean(table.Rows[dataGrid.CurrentRowIndex]["fbitReferenced"]);

                    //
                    if (isTempReceipt)
                    {
                        XmlElement ele = args.ConfigNode as XmlElement;
                        if (ele.HasAttribute("ErrorInfo"))
                        {
                            string errorInfo = "";
                            string[] errors = ele.Attributes["ErrorInfo"].Value.Split('#');
                            foreach (string e in errors)
                            {
                                errorInfo += e + "\n";
                            }

                            RetailMessageBox.ShowWarning(errorInfo);
                        }

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                //RetailMessageBox.ShowWarning(ex.Message);
                Logger.WriteLine(ex.Message);
            }

            return true;
        }


        /// <summary>
        /// �̵㸴��ʱ�����޸Ĺ������ݶ�Ӧ�Ľ��
        /// </summary>
        /// <returns></returns>
        public void UpdataRealStocksData(object sender, ExternalMethodCallArgs args)
        {
            try
            {
                HandleEvent eventHandler = args.HandleEvent;
                Init InitFormClass = eventHandler.InitFormClass;

                // �õ������е���Ʒ��Ϣ��ϸ
                HandleEvent.FilterEmptyRows(InitFormClass.DGrid);
                DataGrid ParentGrid = InitFormClass.DGrid;
                DataSet ds = ParentGrid.DataSource as DataSet;

                DataTable dt = ds.Tables["DTDetail"];

                if (!dt.Columns.Contains("fchrRealStocksDetailID") && !dt.Columns.Contains("flotQuantity"))
                {
                    return;
                }

                foreach (DataRow oRows in dt.Rows)
                {
                    if (oRows.RowState == DataRowState.Modified)
                    {
                        if (!string.IsNullOrEmpty(Tools.GetStringColumnValue(oRows["fchrRealStocksDetailID"])))
                        {
                            string strSQL = string.Format("UPDATE RealStocksDetail SET flotMoney = {0} * flotQuotePrice WHERE fchrRealStocksDetailID = '{1}'", Tools.GetDblColumnValue(oRows["flotQuantity"]), Tools.GetStringColumnValue(oRows["fchrRealStocksDetailID"]));

                            SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, strSQL);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
            }
        }
    }
}
