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
    /// Class1 的摘要说明。
    /// </summary>
    public class CheckDoWith
    {
        public CheckDoWith()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 判断商品的自由项是否正确
        /// </summary>
        /// <param name="strItemID">
        /// 商品ID
        /// </param>
        /// <param name="strFreeKey">
        /// 自由项名
        /// </param>
        /// <param name="strFreeValue">
        /// 自由项取值范围
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

            // 判断此自由项的值是否存在
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

            //如果是分销,是否存在这种商品的自由项取值范围
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
                // 如果是U8首先判断 这种商品的这种自由项取值范围是否存在

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

                // 如果存在就要和分销保持一致的算法  
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
        /// 检查入库单是否已经关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool CheckInOutVouchState(object sender, ExternalMethodCallArgs args)
        {
            string InOutVouchIDControlName = args.ConfigNode.Attributes["InOutVouchIDControlName"].Value;
            Control inoutVouchIDControl = HandleEventHelper.FindControlFromMainForm(InOutVouchIDControlName, args.HandleEvent.SourceForm);
            string inOutVouchID = HandleEventHelper.GetControlValue(inoutVouchIDControl);
            //如果inOutVouchID为空串，说明是新增，则不检查状态
            if (inOutVouchID == "")
            {
                return true;
            }
            string commandText = string.Format("select fintState from InOutVouch where fchrInOutVouchID = '{0}'", inOutVouchID);
            try
            {
                DataTable dtResult = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, commandText);
                string state = dtResult.Rows[0][0].ToString();
                //2表示已经关闭
                if (state == "2")
                {
                    RetailMessageBox.ShowWarning("当前单据不是最新状态，请重新进入！");
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
        /// 检查所解析出来的数据是否出现了错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool CheckFreeErrors(object sender, ExternalMethodCallArgs args)
        {
            string strItemIDControlName = "";                  //商品ID的控件名称
            string strItemIDControlType = "";                //商品ID的控件类型
            string strItemIDControlValue = "";                                                //商品ID的控件值

            string strFreeControlName = "";													 //商品自由项的控件名称
            string strFreeControlType = "";													 //商品自由项的控件类型
            string strFreeControlValue = "";													 //商品自由项的控件值

            string strFreeName = "";
            bool fbitFree = false;

            string sqlBuilder = "";

            Control controlSource = null;
            IDataReader readerTemp = null;
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;

            XmlNode configNode = args.ConfigNode;
            DataGrid dg = args.HandleEvent.InitFormClass.DGrid;

            //如果商品ID的控件名称属性不存在，则不检查
            if (configNode == null || configNode.Attributes["ItemIDControl"] == null)
            {
                return true;
            }

            strItemIDControlName = configNode.Attributes["ItemIDControl"].Value;

            //如果商品ID的控件类型不存在，则不检查
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
        /// 检查所解析出来的数据是否出现了错误
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool CheckFreeError(object sender, ExternalMethodCallArgs args)
        {
            string strItemIDControlName = "";                  //商品ID的控件名称
            string strItemIDControlType = "";                //商品ID的控件类型
            string strItemIDControlValue = "";                                                //商品ID的控件值

            string strFreeControlName = "";													 //商品自由项的控件名称
            string strFreeControlType = "";													 //商品自由项的控件类型
            string strFreeControlValue = "";													 //商品自由项的控件值

            string strFreeName = "";
            bool fbitFree = false;

            string sqlBuilder = "";

            Control controlSource = null;
            IDataReader readerTemp = null;
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;

            XmlNode configNode = args.ConfigNode;
            DataGrid dg = args.HandleEvent.InitFormClass.DGrid;

            //如果商品ID的控件名称属性不存在，则不检查
            if (configNode == null || configNode.Attributes["ItemIDControl"] == null)
            {
                return true;
            }

            strItemIDControlName = configNode.Attributes["ItemIDControl"].Value;

            //如果商品ID的控件类型不存在，则不检查
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
        /// 判断当前要删除的班次是否正在被使用着的
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
                RetailMessageBox.ShowExclamation("没有明细数据记录，无法删除！");
                return false;
            }

            // 删除哪条记录	
            intCurrentRowIndex = ParentGrid.CurrentRowIndex;
            dr = eventHandler.DetailRowsindex(dt, intCurrentRowIndex);
            if (HandleEvent.IsEmptyRow(dr))
            {
                return false;
            }
            strSquadID = Tools.GetStringColumnValue(Tools.GetStringSysPara("班次ID"));
            if (strSquadID != "")
            {
                if (Tools.GetStringColumnValue(dr["fchrSquadID"]) == strSquadID)
                {
                    RetailMessageBox.ShowExclamation("该档案已被使用，无法删除！");
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
            //得到原控件的名称
            if (configNode == null || configNode.Attributes["ControlSourceName"] == null)
            {
                return;
            }

            strControlSourceName = Tools.GetStringColumnValue(configNode.Attributes["ControlSourceName"].Value);

            //得到原控件的类型
            if (configNode == null || configNode.Attributes["ControlSourceType"] == null)
            {
                return;
            }

            strControlSourceType = Tools.GetStringColumnValue(configNode.Attributes["ControlSourceType"].Value);

            //得到目标控件的名称
            if (configNode == null || configNode.Attributes["ObjectiveSourceName"] == null)
            {
                return;
            }

            strObjectiveSourceName = Tools.GetStringColumnValue(configNode.Attributes["ObjectiveSourceName"].Value);

            //得到目标控件的付值类型
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
        /// 实盘单参照时,所参照的商品应为盘点准备单中的商品
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
                controlSource = HandleEvent.FindControl("条码", args.HandleEvent.GetDetailForm(sender));
                if (Tools.GetIntSysPara("CheckInputItemRange") == 1)
                {

                    strParentCondition = string.Format("item.ftinItemModel=1 AND IsNull(item.fbitNoUsed,0)=0 And item.fchrItemID IN (SELECT DISTINCT fchrItemID FROM CheckSetoutDetail WHERE fchrCheckSetoutID='{0}')", strCheckSetoutID);

                }
                else
                {
                    //零售实盘单录入时，不允许录入准备单上没有，但库存余额表上有的商品。V891二期补丁
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
            if (DialogResult.No == RetailMessageBox.ShowQuestion("您确定清空表体商品行吗？", MessageBoxDefaultButton.Button2))
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
                        //得到商品的ID
                        if (configNode == null || configNode.Attributes["ItemIDControl"] == null)
                        {
                            return false;
                        }

                        strControlName = Tools.GetStringColumnValue(configNode.Attributes["ItemIDControl"].Value);

                        strItemID = Tools.GetStringColumnValue(sRow[strControlName]);


                        strSQL = string.Format("SELECT COUNT(*) AS NoteNumber FROM ITEMSTOCKS WHERE fchrItemID='{0}' ", strItemID);

                        // 得到商品的编码

                        if (configNode == null || configNode.Attributes["ItemCodeControl"] == null)
                        {
                            return false;
                        }

                        strControlName = Tools.GetStringColumnValue(configNode.Attributes["ItemCodeControl"].Value);

                        strItemCode = Tools.GetStringColumnValue(sRow[strControlName]);

                        // 得到商品的名称

                        if (configNode == null || configNode.Attributes["ItemNameControl"] == null)
                        {
                            return false;
                        }

                        strControlName = Tools.GetStringColumnValue(configNode.Attributes["ItemNameControl"].Value);

                        strItemName = Tools.GetStringColumnValue(sRow[strControlName]);

                        //得到商品的批号
                        if (configNode == null || configNode.Attributes["BatchCodeControl"] == null)
                        {
                            return false;
                        }

                        strControlName = Tools.GetStringColumnValue(configNode.Attributes["BatchCodeControl"].Value);


                        strBatchCode = Tools.GetStringColumnValue(sRow[strControlName]);


                        strError = string.Format("商品（{0}）{1}请输入有效的批号！", strItemCode, strItemName);

                        //   判断商品是否是批次管理的
                        if (CheckItemBitFree(strItemID, "fbitBatch"))
                        {
                            bolISNotBatchCode = false;
                            //   如果是,没录批号  报错
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
                            //   不是录了批号  报错
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
                        //得到商品的生产日期
                        if (configNode == null || configNode.Attributes["ProduceDateControl"] == null)
                        {
                            return false;
                        }

                        strControlName = Tools.GetStringColumnValue(configNode.Attributes["ProduceDateControl"].Value);

                        if (Tools.GetStringColumnValue(sRow[strControlName]) != "")
                            strProduceDate = Convert.ToDateTime(Tools.GetStringColumnValue(sRow[strControlName])).ToString("yyyy-MM-dd");
                        else
                            strProduceDate = "";

                        strError = string.Format("商品（{0}）{1}，请输入有效的日期！", strItemCode, strItemName);

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
                        //得到商品的自由项信息
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
                            // 查询数据库，是否存在记录
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
                                    strError = string.Format("商品（{0}）{1}，请输入有效的批号和日期！", strItemCode, strItemName);
                                else
                                    strError = string.Format("商品（{0}）{1}，请输入有效的日期！", strItemCode, strItemName);
                            }
                            else
                                strError = string.Format("商品（{0}）{1}，请输入有效的批号！", strItemCode, strItemName);

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
                            //如果数量属性不存在，则不检查
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

                                //如果商品名称属性不存在，则不检查
                                if (configNode == null || configNode.Attributes["ItemNameControl"] == null)
                                {
                                    return false;
                                }

                                strControlName = Tools.GetStringColumnValue(configNode.Attributes["ItemNameControl"].Value);
                                strItemName = Tools.GetStringColumnValue(sRow[strControlName]);

                                //如果商品编码属性不存在，则不检查
                                if (configNode == null || configNode.Attributes["ItemCodeControl"] == null)
                                {
                                    return false;
                                }
                                strControlName = Tools.GetStringColumnValue(configNode.Attributes["ItemCodeControl"].Value);
                                strItemCode = Tools.GetStringColumnValue(sRow[strControlName]);


                                //如果商品ID属性不存在，则不检查
                                if (configNode == null || configNode.Attributes["ItemIDControl"] == null)
                                {
                                    return false;
                                }

                                strControlName = Tools.GetStringColumnValue(configNode.Attributes["ItemIDControl"].Value);

                                strItemID = Tools.GetStringColumnValue(sRow["fchritemid"]);

                                strTemp = string.Format("{0} ='{1}'", strControlName, strItemID);
                                strSQL3 = strTemp;


                                //如果商品批号属性不存在，则不检查
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


                                //如果商品有效期至属性不存在，则不检查
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

                                //追加货位。V8.91, libo, 2010-02-01
                                //取得货位
                                if (configNode != null && configNode.Attributes["PositionIDControl"] != null)
                                {
                                    strControlName = Tools.GetStringColumnValue(configNode.Attributes["PositionIDControl"].Value);

                                    strPositionID = "";
                                    if (sRow.Table.Columns.IndexOf(strControlName) != -1)
                                        strPositionID = Tools.GetStringColumnValue(sRow[strControlName]);

                                    //判断的商品行为“商品+自由项+批号+生产日期/有效期至+货位” V8.91, libo, 2010-02-01  
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

                                //取得货位名称
                                if (configNode != null && configNode.Attributes["PositionNameControl"] != null)
                                {
                                    strControlName = Tools.GetStringColumnValue(configNode.Attributes["PositionNameControl"].Value);
                                    strPositionName = Tools.GetStringColumnValue(sRow[strControlName]);
                                }

                                strSQL = string.Format("SELECT flotQuantity FROM ITEMSTOCKS WHERE fchrItemID='{0}'", strItemID);
                                //修改取得商品可用量.V891一期补丁
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

                                //判断的商品行为“商品+自由项+批号+生产日期/有效期至+货位” V8.91, libo, 2010-02-01  
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

                                //判断商品的自由项
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
                                                strError = string.Format("{0}、{1}", strError, strFreeValue);
                                            strTemp = string.Format("{0} ='{1}'", strName, strFreeValue);
                                            strSQL3 = string.Format("{0} AND {1}", strSQL3, strTemp);
                                        }
                                    }
                                }

                                foundRows = dt.Select(strSQL3);


                                // 将表中所有商品信息相同的数量会总起来
                                douQuantity = 0;
                                foreach (DataRow rRow in foundRows)
                                {
                                    if (rRow.RowState != DataRowState.Deleted)
                                    {
                                        douQuantity = douQuantity + Tools.GetDblColumnValue(rRow[strQuantityName]);
                                    }
                                }

                                // 单据是否是编辑的状态,如果是编辑的状态,就要将原来的数量抛除掉
                                if (bolIsEditBill)
                                {
                                    //得到单据的ID
                                    if (configNode == null || configNode.Attributes["BillIDControl"] == null)
                                    {
                                        return false;
                                    }

                                    strControlName = Tools.GetStringColumnValue(configNode.Attributes["BillIDControl"].Value);

                                    controlSource = HandleEvent.FindControl(strControlName, InitFormClass.MainForm);

                                    //如果商品有效期至属性不存在，则不检查
                                    if (configNode == null || configNode.Attributes["BillIDControlType"] == null)
                                    {
                                        return false;
                                    }

                                    strControlType = Tools.GetStringColumnValue(configNode.Attributes["BillIDControlType"].Value);


                                    strBillID = HandleEventHelper.GetControlValues(controlSource, strControlType);


                                    //如果解析不出来，首先查询是不是只是商品的条码
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
                                            strError = string.Format("（{0}）{1}（{2}）的可用量不足！", strItemCode, strItemName, strError);
                                        else
                                            strError = string.Format("（{0}）{1}的可用量不足！", strItemCode, strItemName);

                                        //启用货位管理时提示显示[货位名称]显示 。V8.91, libo, 2010-02-01
                                        if (SysPara.IsPosManage())
                                        {
                                            if (string.IsNullOrEmpty(strPositionID))
                                            {
                                                strError = string.Format("空货位上{1}", strPositionName, strError);
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
                                //修改取得商品可用量.V891一期补丁
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
                                        strError = string.Format("（{0}）{1}（{2}）的可用量不足！", strItemCode, strItemName, strError);
                                    else
                                        strError = string.Format("（{0}）{1}的可用量不足！", strItemCode, strItemName);

                                    //启用货位管理时提示显示[货位名称]显示 。V8.91, libo, 2010-02-01
                                    if (SysPara.IsPosManage())
                                    {
                                        if (string.IsNullOrEmpty(strPositionID))
                                        {
                                            strError = string.Format("空货位上{1}", strPositionName, strError);
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
        /// 检查数量列，判断是否有小于0的值
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
            //如果QuantityColumnName属性不存在，则不检查
            if (configNode == null || configNode.Attributes["QuantityColumnName"] == null)
            {
                return true;
            }
            quantityColumnName = configNode.Attributes["QuantityColumnName"].Value;

            //如果ItemCodeColumnName属性不存在，则不检查
            if (configNode == null || configNode.Attributes["ItemCodeColumnName"] == null)
            {
                return true;
            }
            ItemCodeColumnName = configNode.Attributes["ItemCodeColumnName"].Value;

            //如果ItemNameColumnName属性不存在，则不检查
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
                            strError = string.Format("（{0}）{1}的实盘数量小于0，不能保存！ ", ItemCodeValue, ItemNameValue);
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
        /// 返回盘点准备单所对应的实盘单的商品数量
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

            //   得到盘店准备单的ID
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
        /// 检查商品复核中是否会有空的记录
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
                    RetailMessageBox.ShowExclamation(strError + "号实盘单中存在数量为空的商品行，请录入实盘数！");
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
        /// 检查出入库单的单据明细中是否是装箱方式的记录
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
        /// 得到实盘单的日期
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
        /// 判断盘点准备单是否已经被复核过
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
                        RetailMessageBox.ShowExclamation("对应的盘点准备单已被复核，不允许保存！");
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
        /// 判断一张盘点准备单是否已经存在一张或多张的实盘单,
        /// 如果一张盘点准备单是否已经存在多张的实盘单,那就不让再保存了
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
                    RetailMessageBox.ShowExclamation("所选盘点准备单已存在多张对应的实盘单，不允许保存！");
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
                    RetailMessageBox.ShowInformation("原单据被删除，新单据保存成功！");
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// 判断一张盘点准备单是否仅有一张所对应的实盘单
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
        /// 判断一张盘点准备单是否没有所对应的实盘单
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
        ///  判断一张盘点准备单是否已经存在多张的实盘单
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
        /// 判断一张盘点准备单是否已经存在一张或多张的实盘单,如果不存在,就将此实盘单保存
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
                RetailMessageBox.ShowExclamation("所选盘点准备单已存在多张对应的实盘单，不允许参照！");

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

                //过滤掉空行 by ylc 
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
        /// 检测店存出入库单的商品是否在商品档案中存在
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
                //得到单据的明细
                DataTable dt = ds.Tables["DTDetail"];

                if (dt.Rows.Count > 0)
                {
                    oRows = dt.Rows[intCurrentRowIndex];
                    if (oRows.RowState != DataRowState.Deleted)
                    {
                        string strColumnName = args.ConfigNode.Attributes["InOutVouchID"].Value;
                        if (string.IsNullOrEmpty(strColumnName))
                        {
                            strColumnName = "待入出库单ID";
                        }
                        strInOutVouchID = Tools.GetStringColumnValue(oRows[strColumnName]);
                        try
                        {
                            //  查找  单据中没有商品档案的记录的条数
                            bolExistError = false;

                            //修改错误信息，信息中含有商品编码。V8.91, libo, 2010-03-15
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
                                            strTemp = strTemp + "，\r\n" + dr["fchrItemCode"].ToString();
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
        /// 记录实盘单的数据,在实盘差异复核时可以保存实盘单的数量
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
                // 得到网格中的商品信息明细
                HandleEvent.FilterEmptyRows(InitFormClass.DGrid);
                DataGrid ParentGrid = InitFormClass.DGrid;
                DataSet ds = ParentGrid.DataSource as DataSet;
                //得到参照的盘点准备单的ID
                Control controlSource = HandleEvent.FindControl("fchrCheckSetoutID", InitFormClass.MainForm);
                strCheckSetoutID = HandleEventHelper.GetControlValues(controlSource, "ExLabel");
                //网格中的商品信息明细是否为空
                if (ds != null)
                {

                    DataTable dt = ds.Tables["DTDetail"];

                    if (dt.Rows.Count == 0)
                    {
                        RetailMessageBox.ShowExclamation("没有明细数据记录，无法保存！");
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
                        RetailMessageBox.ShowExclamation("没有明细数据记录，无法保存！");
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
                        RetailMessageBox.ShowExclamation("保存时发生错误：\n" + errDesc);
                        return;
                    }
                    Control saveButton = sender as Control;
                    Form sourceForm = saveButton.FindForm();
                    if (sourceForm is IEditForm)
                    {
                        ((IEditForm)sourceForm).HasChanged = false;
                    }
                    RetailMessageBox.ShowInformation("数据保存成功！");
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
        /// 用小票打印机打印单据
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

            //如果单据ID属性不存在，则不检查
            if (configNode == null || configNode.Attributes["BillControlName"] == null)
            {
                return;
            }
            strBillControlName = configNode.Attributes["BillControlName"].Value;

            //如果单据ID属性不存在，则不检查
            if (configNode == null || configNode.Attributes["BillControlType"] == null)
            {
                return;
            }
            strBillControlType = configNode.Attributes["BillControlType"].Value;

            //如果单据ID属性不存在，则不检查
            if (configNode == null || configNode.Attributes["TemplateName"] == null)
            {
                return;
            }
            strTemplateName = configNode.Attributes["TemplateName"].Value;

            //单据是否不存在
            if (configNode == null || configNode.Attributes["IsExistBill"] == null)
            {
                return;
            }
            bolIsExistBill = Tools.GetBoolColumnValue(configNode.Attributes["IsExistBill"].Value);
            // 如果单据是已经保存的
            if (bolIsExistBill)
            {
                // 得到  所要打印的单据的ID
                controlSource = HandleEvent.FindControl(strBillControlName, args.HandleEvent.GetMainForm(sender));
                strBillValue = HandleEventHelper.GetControlValues(controlSource, strBillControlType);

                int nPrinterType = Tools.GetIntSysPara("PrinterType");     //打印机类型 0 POS打印 1 普通
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
                //得到参照的盘点准备单的ID

                //得到参照的盘点准备单的ID
                controlSource = HandleEvent.FindControl("fchrCode", InitFormClass.MainForm);
                strCheckSetoutCode = HandleEventHelper.GetControlValues(controlSource, "ExLabel");
                //得到参照的盘点准备单的日期
                controlSource = HandleEvent.FindControl("fdtmDate", InitFormClass.MainForm);
                strCheckSetoutDate = HandleEventHelper.GetControlValues(controlSource, "ExDatePicker");
                //得到参照的盘点准备单的制单人
                controlSource = HandleEvent.FindControl("fchrMaker", InitFormClass.MainForm);
                strMaker = HandleEventHelper.GetControlValues(controlSource, "ExLabel");
                //得到参照的盘点准备单的营业员
                controlSource = HandleEvent.FindControl("fchrEmployeeID", InitFormClass.MainForm);
                strEmployee = HandleEventHelper.GetControlValues(controlSource, "ExComboBox");
                //得到参照的盘点准备单的备注
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
        /// 保存价格变更的记录
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
                // 得到  所更该商品的ID
                controlSource = HandleEventHelper.GetControlByName("存货id", modifyForm);
                strItemID = HandleEventHelper.GetControlValues(controlSource, "ExLabel");
                // 得到  所更该商品的建议零售价
                controlSource = HandleEventHelper.GetControlByName("零售价", modifyForm);

                douQuotePrice = Tools.GetDblColumnValue(((ExNumbericText)controlSource).ControlValue);
                // 得到  所更该商品的VIP一级价
                controlSource = HandleEventHelper.GetControlByName("VIP一级价", modifyForm);
                douVipPrice1 = Tools.GetDblColumnValue(((ExNumbericText)controlSource).ControlValue);
                // 得到  所更该商品的VIP二级价
                controlSource = HandleEventHelper.GetControlByName("VIP二级价", modifyForm);
                douVipPrice2 = Tools.GetDblColumnValue(((ExNumbericText)controlSource).ControlValue);
                // 得到  所更该商品的VIP三级价
                controlSource = HandleEventHelper.GetControlByName("VIP三级价", modifyForm);
                douVipPrice3 = Tools.GetDblColumnValue(((ExNumbericText)controlSource).ControlValue);
                // 得到  所更该商品的VIP四级价
                controlSource = HandleEventHelper.GetControlByName("VIP四级价", modifyForm);
                douVipPrice4 = Tools.GetDblColumnValue(((ExNumbericText)controlSource).ControlValue);
                // 得到  所更该商品的VIP五级价
                controlSource = HandleEventHelper.GetControlByName("VIP五级价", modifyForm);
                douVipPrice5 = Tools.GetDblColumnValue(((ExNumbericText)controlSource).ControlValue);
                // 得到  所更该商品的VIP六级价
                controlSource = HandleEventHelper.GetControlByName("VIP六级价", modifyForm);
                douVipPrice6 = Tools.GetDblColumnValue(((ExNumbericText)controlSource).ControlValue);

                //调用存储过程,如果价格变化就将此变化记录下来

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
        /// 参照条件查询 (取控件FreeItemXml控件的值当参数)
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
                //获取值控件
                strFilterCondition = configNode.Attributes["FilterCondition"].Value;
                //修改的控件
                strOwnerControl = configNode.Attributes["OwnerControl"].Value;
                //控件获取的值对应的sql变量名
                para = configNode.Attributes["Para"].Value;
                //保存自由项xml的控件
                strFreeItemXmlControl = configNode.Attributes["FreeItemXmlControl"].Value;
                //是否启用自由项的控件的值
                strfbitFree = configNode.Attributes["strfbitFree"].Value;
                //是否需要调用其他模版
                strOtherRefSource = configNode.Attributes["OtherRefSource"].Value;

                if (strFilterCondition == "" || strOwnerControl == "")
                    return false;
                //获取itemid
                control = HandleEvent.FindControl(strFilterCondition, InitFormClass.DetailForm);
                strControlID = HandleEventHelper.GetControlValue(control);
                //获取自由项字符串
                control = HandleEvent.FindControl(strFreeItemXmlControl, InitFormClass.DetailForm);
                strFreeXml = HandleEventHelper.GetControlValue(control);
                //获取是否启用自由项
                control = HandleEvent.FindControl(strfbitFree, InitFormClass.DetailForm);
                fbitFree = Convert.ToBoolean(HandleEventHelper.GetControlValue(control));

                strSQL = string.Format("{0}='{1}'", para, strControlID);
                //启用自由项，则把自由项内容加到字符串内
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
                //是否起用有效期
                //日期过滤
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
        /// 参照条件查询(修改时,取fchrfree1-10控件内自由项的值来做判断，同时可取FreeItemXml控件内容
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
                //获取值控件
                strFilterCondition = configNode.Attributes["FilterCondition"].Value;
                //修改的控件
                strOwnerControl = configNode.Attributes["OwnerControl"].Value;
                //控件获取的值对应的sql变量名
                para = configNode.Attributes["Para"].Value;
                //是否启用自由项的控件的值
                strfbitFree = configNode.Attributes["strfbitFree"].Value;
                //保存自由项xml的控件
                strFreeItemXmlControl = configNode.Attributes["FreeItemXmlControl"].Value;
                //是否需要调用其他模版
                strOtherRefSource = configNode.Attributes["OtherRefSource"].Value;

                if (strFilterCondition == "" || strOwnerControl == "")
                    return false;
                //获取itemid
                control = HandleEvent.FindControl(strFilterCondition, InitFormClass.DetailForm);
                strControlID = HandleEventHelper.GetControlValue(control);
                //获取是否启用自由项
                control = HandleEvent.FindControl(strfbitFree, InitFormClass.DetailForm);
                fbitFree = Convert.ToBoolean(HandleEventHelper.GetControlValue(control));
                //获取自由项字符串
                control = HandleEvent.FindControl(strFreeItemXmlControl, InitFormClass.DetailForm);
                strFreeXml = HandleEventHelper.GetControlValue(control);
                //拼接sql
                strSQL = string.Format("{0}='{1}'", para, strControlID);

                //strFreeItemXmlControl不空的情况是编辑时新增的情况
                //空为直接选中商品进行编辑
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
                { //启用自由项，则把自由项内容加到字符串内
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
                //是否起用有效期
                //日期过滤
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
        /// 入库单输入批号时有效期的控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// 若录入的批号在店存数据中不存在，则可随意录入生产日期/有效期至；
        /// 若录入的批号在店存数据中存在，则生产日期/有效期至不能随意录入，应自动带出批次所对应的“生产日期/有效期至”，且不能手工修改。
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
            control = HandleEvent.FindControl("是否有效期管理", InitFormClass.DetailForm);
            strIsProduceDate = HandleEventHelper.GetControlValue(control);
            if (strIsProduceDate == "False")
                return true;

            //批号控件
            string strBatchControl = "";
            strBatchControl = configNode.Attributes["BatchControl"].Value;
            //有效期控件
            string strDateControl = "";
            strDateControl = configNode.Attributes["ProduceDateControl"].Value;

            //是否启用自由项的控件的值
            string strfbitFree = "";
            strfbitFree = configNode.Attributes["strfbitFree"].Value;


            //获取itemid
            string strItemID = "";
            control = HandleEvent.FindControl("存货id", InitFormClass.DetailForm);
            strItemID = HandleEventHelper.GetControlValue(control);
            //自由项字符串控件
            string strFreeItemXmlControl = "";
            strFreeItemXmlControl = configNode.Attributes["FreeItemXmlControl"].Value;
            //获取自由项字符串
            string strFreeXml = "";
            control = HandleEvent.FindControl(strFreeItemXmlControl, InitFormClass.DetailForm);
            strFreeXml = HandleEventHelper.GetControlValue(control);
            //获取是否启用自由项
            bool fbitFree;
            control = HandleEvent.FindControl(strfbitFree, InitFormClass.DetailForm);
            fbitFree = Convert.ToBoolean(HandleEventHelper.GetControlValue(control));

            //
            string strSqlCondition = "";
            strSqlCondition = string.Format("fchrItemID='{0}'", strItemID);
            //如果只有1个商品根据自由项和批号判断有效期，则为1，根据商品数递增
            object objResult = null;
            if (fbitFree)
                //拼写sql
                CheckItemFree(strFreeXml, strSqlCondition, out objResult, args);
            OperateDateControlByBatch(objResult, strDateControl, args);
            return true;
        }
        /// <summary>
        /// 根据批号控件，对有效期控件做操作
        /// </summary>
        /// <param name="strBatchControl">批号控件名称</param>
        /// <param name="strDateControl">有效期控件名称</param>
        /// <param name="strSqlCondition">sql语句条件</param>
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

        //根据批号取有效期
        public void GetDateByBatch(string strSqlCondition, ref string objResult, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            XmlNode configNode = args.ConfigNode;

            Control control;
            //取批号控件的值
            string strBatch = "";
            //批号控件
            string strBatchControl = "";
            strBatchControl = configNode.Attributes["BatchControl"].Value;
            control = HandleEvent.FindControl(strBatchControl, InitFormClass.DetailForm);
            strBatch = HandleEventHelper.GetControlValue(control);
            //拼写sql
            string strSQL = "";
            strSQL = string.Format("select COUNT(DISTINCT fdtmProduceDate) as count from dbo.ItemStocks where {0} AND fchrBatchCode='{1}'", strSqlCondition, strBatch);
            //读取有效期的值
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
        //根据批号取有效期
        public void GetDateByBatch(string strSqlCondition, ref ArrayList objResult, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            XmlNode configNode = args.ConfigNode;

            Control control;
            //取批号控件的值
            string strBatch = "";
            //批号控件
            string strBatchControl = "";
            strBatchControl = configNode.Attributes["BatchControl"].Value;
            control = HandleEvent.FindControl(strBatchControl, InitFormClass.DetailForm);
            strBatch = HandleEventHelper.GetControlValue(control);
            //拼写sql
            string strSQL = "";
            strSQL = string.Format("select COUNT(DISTINCT fdtmProduceDate) as count from dbo.ItemStocks where {0} AND fchrBatchCode='{1}'", strSqlCondition, strBatch);
            //读取有效期的值
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
        /// 检查是否存在各自由项，拼接SQL
        /// </summary>
        /// <param name="strFreeXml">自由项控件xml</param>
        /// <param name="strSQL">sql条件</param>
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
                    //获取freexml节点
                    xmlDoc.LoadXml(strFreeXml);
                    xmlNode = xmlDoc.SelectSingleNode("Root");
                    //自由项节点数量
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
        /// 批号或有效期为空时提示信息
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
                //获取商品是否批号，有效期管理
                string strIsBatchManage;
                control = HandleEvent.FindControl("是否批次管理", InitFormClass.DetailForm);
                strIsBatchManage = HandleEventHelper.GetControlValue(control);
                string strIsProduceDateManage;
                control = HandleEvent.FindControl("是否有效期管理", InitFormClass.DetailForm);
                strIsProduceDateManage = HandleEventHelper.GetControlValue(control);

                //取批号控件的值
                string strBatchControl = "";
                string strBatch = "";
                strBatchControl = configNode.Attributes["BatchControl"].Value;
                control = HandleEvent.FindControl(strBatchControl, InitFormClass.DetailForm);
                strBatch = HandleEventHelper.GetControlValue(control);
                //取有效期控件的值
                string strDateControl = "";
                string strDate = "";
                strDateControl = configNode.Attributes["ProduceDateControl"].Value;
                control = HandleEvent.FindControl(strDateControl, InitFormClass.DetailForm);
                strDate = HandleEventHelper.GetControlValue(control);
                //取商品名称
                string strItemName;
                string strItemNameControl;
                strItemNameControl = configNode.Attributes["ItemNameControl"].Value;
                control = HandleEvent.FindControl(strItemNameControl, InitFormClass.DetailForm);
                strItemName = ((RefControl)control).RefName;
                //取商品编码
                string strItemCode;
                string strItemCodeControl;
                strItemCodeControl = configNode.Attributes["ItemCodeControl"].Value;
                control = HandleEvent.FindControl(strItemCodeControl, InitFormClass.DetailForm);
                strItemCode = HandleEventHelper.GetControlValue(control);

                string strTemp;
                strTemp = string.Format("商品[{0} {1}]的批号、生产日期/有效期至都不能为空！", strItemCode, strItemName);

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
        /// 批次严格管理时，对有效期控件的操作
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

            //取批号
            string strBatchControl;
            string strBatch;
            strBatchControl = configNode.Attributes["BatchControl"].Value;
            control = HandleEvent.FindControl(strBatchControl, InitFormClass.DetailForm);
            strBatch = HandleEventHelper.GetControlValue(control);
            //取有效期
            string strProductDateControl;
            string strProductDate;
            strProductDateControl = configNode.Attributes["ProduceDateControl"].Value;
            control = HandleEvent.FindControl(strProductDateControl, InitFormClass.DetailForm);
            strProductDate = HandleEventHelper.GetControlValue(control);

            if (strBatch == string.Empty || strProductDate == string.Empty)
                return true;

            //取商品ID
            string strItemID;
            control = HandleEvent.FindControl("存货id", InitFormClass.DetailForm);
            strItemID = HandleEventHelper.GetControlValue(control);

            //拼写sql
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
        /// 完成前检测自由项和批号、有效期是否对应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// add by wq 2007.11.28
        /// 完成前检测面板里输入的ITEMID 和批号，有效期是否对应
        /// 只有在新增的时候才判断
        public bool CheckBatchDateFreeError(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            Control control;
            XmlNode configNode = args.ConfigNode;

            //是否启用自由项
            string strfbitFreeControl;
            bool fbitFree;
            strfbitFreeControl = configNode.Attributes["fbitFreeControl"].Value;
            control = HandleEvent.FindControl(strfbitFreeControl, InitFormClass.DetailForm);
            fbitFree = Convert.ToBoolean(HandleEventHelper.GetControlValue(control));

            //自由项字符串控件
            string strFreeItemXmlControl = "";
            strFreeItemXmlControl = configNode.Attributes["FreeItemXmlControl"].Value;
            //获取自由项字符串
            string strFreeXml = "";
            control = HandleEvent.FindControl(strFreeItemXmlControl, InitFormClass.DetailForm);
            strFreeXml = HandleEventHelper.GetControlValue(control);

            if (!fbitFree)
                return true;
            else
            //存在自由项，判断
            {
                //获取itemid
                string strItemID = "";
                control = HandleEvent.FindControl("存货id", InitFormClass.DetailForm);
                strItemID = HandleEventHelper.GetControlValue(control);
                //ITEMID的数据查询条件
                string strSqlCondition;
                strSqlCondition = string.Format(" WHERE fchrItemID = '{0}' ", strItemID);

                if (strFreeXml == string.Empty)
                    return CheckBatchDateFreeByFreeControl(args, strItemID, strSqlCondition);
                else
                    return CheckBatchDateFreeByFreeItemControl(args, strItemID, strFreeXml, strSqlCondition);
            }

        }
        /// <summary>
        /// 根据FREEITEM控件的值判断
        /// </summary>
        /// <param name="args"></param>
        /// <param name="strItemID"></param>
        /// <param name="strFreeXml">freeitem控件的字符传</param>
        /// <param name="strSqlCondition"></param>
        /// <returns></returns>
        /// add by wq 2007.11.28
        /// 完成前检测面板里输入的ITEMID 和批号，有效期是否对应
        private bool CheckBatchDateFreeByFreeItemControl(ExternalMethodCallArgs args, string strItemID, string strFreeXml, string strSqlCondition)
        {

            //获取自由项字符串
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
        /// 根据10个自由项控件来判断
        /// </summary>
        /// <param name="args"></param>
        /// <param name="strItemID"></param>
        /// <param name="strSqlCondition"></param>
        /// <returns></returns>
        /// add by wq 2007.11.28
        /// 完成前检测面板里输入的ITEMID 和批号，有效期是否对应
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
        /// 数据库查询，判断批号、有效期是否与itemid对应起来 
        /// </summary>
        /// <param name="strSqlCondition">数据库查询的条件</param>
        /// <returns></returns>
        /// add by wq 2007.11.28
        /// 完成前检测面板里输入的ITEMID 和批号，有效期是否对应
        private void CheckBatchDateFreeDeal(string strSqlCondition, ExternalMethodCallArgs args, out bool sign)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            Control control;
            XmlNode configNode = args.ConfigNode;

            string strSql;
            strSql = string.Format("SELECT COUNT(DISTINCT fchrBatchCode) from dbo.ItemStocks {0}", strSqlCondition);

            //取批号
            string strBatchControl;
            string strBatch;
            strBatchControl = configNode.Attributes["BatchControl"].Value;
            control = HandleEvent.FindControl(strBatchControl, InitFormClass.DetailForm);
            strBatch = HandleEventHelper.GetControlValue(control);
            //取有效期
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
                    RetailMessageBox.ShowExclamation("所输入的批号或效期不正确！");
                }
                else
                    sign = true;
            }

        }
        /// <summary>
        /// 非原单退货商品模式检测
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

            //商品模式控件的值
            string strItemModelControl = "";
            int ftinItemModel;

            if (configNode.Attributes["ItemModelControl"] == null)
                strItemModelControl = "ftinItemModel";
            else
                strItemModelControl = configNode.Attributes["ItemModelControl"].Value;
            control = HandleEvent.FindControl(strItemModelControl, InitFormClass.DetailForm);
            ftinItemModel = Convert.ToInt32(HandleEventHelper.GetControlValue(control));

            //错误提示信息
            string strErrorInfo = "";
            string strErrorInfoOpp = "";
            strErrorInfo = configNode.Attributes["ErrorInfo"].Value;
            strErrorInfoOpp = configNode.Attributes["ErrorInfoOpp"].Value;

            //取表体数据
            DataSet ds;
            ds = (DataSet)InitFormClass.DGrid.DataSource;
            DataTable dt = new DataTable();
            dt = ds.Tables["DTDetail"];

            //没有数据的情况
            if (dt.Rows.Count <= 1)
                return true;
            else
            {
                return CheckItemModel(dt, ftinItemModel, strErrorInfo, strErrorInfoOpp);
            }
        }
        /// <summary>
        /// 判断录入商品的商品模式，是否跟表体中第1行一样
        /// </summary>
        /// <param name="dt">mainform中的数据表</param>
        /// <param name="ftinItemModel">detail中选定的商品的itemmodel</param>
        /// <param name="strErrorInfo">错误信息</param>
        /// <param name="strErrorInfoOpp">错误信息</param>
        /// <returns></returns>
        /// add by wq 2007-12.19
        private bool CheckItemModel(DataTable dt, int ftinItemModel, string strErrorInfo, string strErrorInfoOpp)
        {
            //取第1行进行比较
            int ftinTemp = Convert.ToInt32(dt.Rows[0]["ftinItemModel"]);
            //相同返回，不同按不同情况提示信息
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
        /// 原单退货商品模式检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// 已注释
        /// 现有客户没有使用联营商品
        /// 现在开单已经控制，原单退货就不可能出现同时存在联营商品和非联营商品的情况
        /// add by wq 2007.12.25
        /*  public bool CheckItemModelInExistBill(object sender, ExternalMethodCallArgs args)
          {
              HandleEvent eventHandler = args.HandleEvent;
              Init InitFormClass = eventHandler.InitFormClass;
              XmlNode configNode = args.ConfigNode;

              //List窗体数据
              if (!eventHandler.SourceForm.GetType().Equals(typeof(frmList)))
                  return false;
              frmList oList=eventHandler.SourceForm as frmList;

              if (null == oList || null == oList.FormEngine || null == oList.FormEngine.sourceForm)
                  return false;
            
              //main窗体数据
              DataGrid oReferGrid = ((PageGrid)oList.FormEngine.ListGrid).DBGrid as DataGrid;
              DataSet dsRefer = oReferGrid.DataSource as DataSet;
              DataTable dtRefer = dsRefer.Tables["DTDetail"];
              string standardItemModel = "";

              //注释掉部分是处理已有单据存在联营和非联营商品的
              //但目前没有客户使用联营商品，所以判断没必要
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

              //取勾选单据第1行的itemmodel
              standardItemModel = dtRefer.Select("UFSoft_Retail_Select = True")[0]["ftinItemModel"].ToString();

              //错误提示信息
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

              //错误信息
              strErrorInfo = configNode.Attributes["ErrorInfo"].Value;
              strErrorInfoOpp = configNode.Attributes["ErrorInfoOpp"].Value;
              //当前列表窗口的父窗口为frmMain,转换为frmMain
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
        /// 清除数据
        /// 清除ControlRequireClean节点定义的控件的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// 功能：单据复制
        /// 可用于清除主子表id用，向数据库插入新数据，而不是保存
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

            //需要清空的控件
            //main窗体跟detail窗体分开
            string strControlRC;
            string strDetailControlRC;
            string[] arrayControlRC;
            string[] arrayDetailControlRC;
            //main窗体部分
            if (configNode.Attributes["ControlRequireClean"] != null)
            {
                strControlRC = configNode.Attributes["ControlRequireClean"].Value;
                arrayControlRC = strControlRC.Split(',');
                //表体内容
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
            //detail窗体部分
            if (configNode.Attributes["DetailControlRequireClean"] != null)
            {
                strDetailControlRC = configNode.Attributes["DetailControlRequireClean"].Value;
                arrayDetailControlRC = strDetailControlRC.Split(',');
                //表体内容
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
        /// 清除上传标记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// 功能：单据复制
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
        /// 修改列上的日期到当前日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// add by wq 2007.12.25
        public void ModifyDateToNow(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            XmlNode configNode = args.ConfigNode;

            //要修改的列名
            string strDateColumnName = configNode.Attributes["DateColumnName"].Value;

            DataSet ds = InitFormClass.DGrid.DataSource as DataSet;
            DataTable dtDetail = ds.Tables["DTDetail"];
            //修改时间到当前时间
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
        /// 判断grid是否有数据数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// add by wq 2007.12.25
        /// 有数据返回true
        public bool CheckDataIsEmpty(object sender, ExternalMethodCallArgs args)
        {
            return !CheckDataIsOrNotEmpty(args);
        }
        /// <summary>
        /// 判断grid是否有数据数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// 有数据返回false
        public bool CheckDataIsNotEmpty(object sender, ExternalMethodCallArgs args)
        {
            return CheckDataIsOrNotEmpty(args);
        }
        //判断grid中数据是否为空
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
        /// 根据条码录入    ssy
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
                        RetailMessageBox.ShowWarning("请选择盘点准备单！");
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
            RefControl refControl = HandleEventHelper.FindControl("条码", args.HandleEvent.SourceForm) as RefControl;
            frmAddDetail frm = new frmAddDetail();
            frm.DataGrid = args.HandleEvent.GetDataGrid();
            frm.CheckBarCode(refControl.TextBox.Text);
        }
        public bool CheckItemRangeForAddButton(object sender, ExternalMethodCallArgs args)
        {
            //零售实盘单录入时，不允许录入准备单上没有，但库存余额表上有的商品。V891二期补丁
            //if (Tools.GetIntSysPara("CheckInputItemRange") == 1)
            //{
                RefControl objRefControl = HandleEventHelper.FindControl("fchrCheckSetoutCode", args.HandleEvent.GetMainForm(sender)) as RefControl;
                string fchrCheckSetoutCode = objRefControl.TextBox.Text.Trim();
                if (string.IsNullOrEmpty(fchrCheckSetoutCode))
                {
                    RetailMessageBox.ShowExclamation("请先选择盘点准备单！");
                    return false;
                }

                RefControl refControl = HandleEventHelper.FindControl("条码", args.HandleEvent.SourceForm) as RefControl;
                if (string.IsNullOrEmpty(refControl.RefID))
                    return false;
                if (refControl.RefID.IndexOf(',') != -1)
                    return true;//所选为多条的情况不考虑，在参照里可能已经做过处理。

                //StringBuilder objSql = new StringBuilder();
                string fchrItemID = refControl.RefID;
                //objSql.Append("select [fchrItemID]");
                //objSql.Append(" from [CheckSetoutDetail] Where fchrCheckSetoutID in ");
                //objSql.AppendFormat(" (Select top 1 fchrCheckSetoutID From CheckSetout Where fchrCode='{0}') AND fchrItemID='{1}'", fchrCheckSetoutCode, fchrItemID);

                //DataTable objTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, objSql.ToString()).Tables[0];
                //if (objTable.Rows.Count < 1)
                //{
                //    RetailMessageBox.ShowExclamation("输入的商品不在当前盘点准备单内！");
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
            //零售实盘单录入时，不允许录入准备单上没有，但库存余额表上有的商品。V891二期补丁
            //if (Tools.GetIntSysPara("CheckInputItemRange") == 1)
            //{
                ExLabel objRefControl = HandleEventHelper.FindControl("fchrCheckSetoutCode", args.HandleEvent.GetMainForm(sender)) as ExLabel;
                string fchrCheckSetoutCode = objRefControl.ControlValue.Trim();
                if (string.IsNullOrEmpty(fchrCheckSetoutCode))
                {
                    RetailMessageBox.ShowExclamation("请先选择盘点准备单！");
                    return false;
                }

                RefControl refControl = HandleEventHelper.FindControl("条码", args.HandleEvent.SourceForm) as RefControl;
                if (string.IsNullOrEmpty(refControl.RefID))
                    return false;
                if (refControl.RefID.IndexOf(',') != -1)
                    return true;//所选为多条的情况不考虑，在参照里可能已经做过处理。

                //StringBuilder objSql = new StringBuilder();
                string fchrItemID = refControl.RefID;
                //objSql.Append("select [fchrItemID]");
                //objSql.Append(" from [CheckSetoutDetail] Where fchrCheckSetoutID in ");
                //objSql.AppendFormat(" (Select top 1 fchrCheckSetoutID From CheckSetout Where fchrCode='{0}') AND fchrItemID='{1}'", fchrCheckSetoutCode, fchrItemID);

                //DataTable objTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, objSql.ToString()).Tables[0];
                //if (objTable.Rows.Count < 1)
                //{
                //    RetailMessageBox.ShowExclamation("输入的商品不在当前盘点准备单内！");
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
        /// 打开盘点准备单参照
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
            //        RetailMessageBox.ShowWarning(args.HandleEvent.InitFormClass.MainForm, "清空商品行后才能参照！");
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
                        RetailMessageBox.ShowWarning(args.HandleEvent.InitFormClass.MainForm, "清空商品行后才能参照！");
                        return;
                    }
                }
            }
            //判断系统参数实盘单对应关系，如果为一对一时，条件如下：
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

            //填充主键 
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

            //过滤掉空行 by ylc 
            HandleEvent.FilterEmptyRows(oSourceGrid);
            foreach (DataRow oRow in dtRefer.Rows)
            {
                oRow[ApplicationConstraints.SelectColumnName] = true;
                //显示金额列
                try
                {
                    //判断金额是否为空
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
        /// 往Grid上添加行
        /// </summary>
        /// <param name="fromRow">源</param>
        /// <param name="destRow">目标</param>
        /// <param name="columnNames">要添加的列</param>
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
            string _SelectionColumnTitle = "选择";
            string _SelectionColumnName = ApplicationConstraints.SelectColumnName;
            if (!boolShowCheckBox)
                return;

            if (null == grid || null == inDataSet)
                return;

            //为数据增加选择列
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
                //实盘单录入界面，当在表头的“盘点准备单”中选中某个盘点准备单时，不再弹出提示框“是否添加该盘点准备单的所有商品？”，
                //也不添加准备单中的商品到表体行上。
                //872 chb 2008-09-10
                if (RetailMessageBox.ShowQuestion("是否添加该盘点准备单的所有商品？") == DialogResult.Yes)
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
                                if (RetailMessageBox.ShowQuestion("是否清空原有商品行？") == DialogResult.Yes)
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

                    //过滤掉空行 by ylc 
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
        /// 检查实盘单保存时的数量
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
                    RetailMessageBox.ShowWarning("明细数据的数量不能为空。\n不能执行保存操作！");
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
            //判断实盘单对应关系
            //判断系统参数实盘单对应关系，如果为一对一时，条件如下：
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
                        RetailMessageBox.ShowWarning("请首先清空已有的商品行！");
                        return;
                    }
                    else
                    {
                        //  弹出条件
                        eventHandler.SelectqueryBackReceipt(el, src, ref strBackMsg, ref strSelectButton);
                        if (strSelectButton != "OK")
                            return;
                        if (RetailMessageBox.ShowQuestion("请确保当前的店存余额是最新的！是否继续？") == DialogResult.No)
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
                if (RetailMessageBox.ShowQuestion("请确保当前的店存余额是最新的！是否继续？") == DialogResult.No)
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
                RetailMessageBox.ShowWarning("已存于未复核的盘点准备单中的商品不能加入！");
            }
            string pageNum = t.InvokeMember("CurrentPage", BindingFlags.GetProperty, null, eventHandler.InitFormClass.ListGrid, null).ToString();
            inXml = "<Data ParentCondition=' 1=1 ' PageSize=\"20\"  PageIndex=\"" + (pageNum == "0" || pageNum == "0" ? "1" : pageNum) + "\" TemplateName='CheckInventory' ><Where><Node Name='ftinItemModel' Value=\"1\"/></Where></Data>";
            doc.LoadXml(inXml);

            SQLSource Process = new SQLSource(SysPara.GetSysPara("SysConn").ToString());
            Process.GetReferData(doc.DocumentElement.OuterXml, inDataSet, out ErrDesc);
            //			//  显示合计行
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
            //获取操作配置信息
            int nRet = eventHandler.DealDelNode(no, src, ref sSQLTemplate, ref sOperatorField);
            if (nRet != 0)
            {
                RetailMessageBox.ShowWarning("单据错误:\n 不能获取操作配置住处。");
                return;
            }

            if (null == sSQLTemplate || sSQLTemplate.Length <= 0)
            {
                RetailMessageBox.ShowWarning("单据错误:\n 非法数据操作模板。 ");
                return;
            }

            //Type t = InitFormClass..GetType();
            System.Reflection.PropertyInfo p = eventHandler.GetPropertyInfo(eventHandler.InitFormClass.DGrid, "DataSource");
            DataSet ds = (DataSet)p.GetValue(eventHandler.InitFormClass.DGrid, null);//t.InvokeMember("DataSource",BindingFlags.GetProperty,null,InitFormClass.ListGrid,null);
            if (null == ds || ds.Tables.Count <= 0 || !ds.Tables.Contains(ApplicationConstraints.DetailTableName))
            {
                RetailMessageBox.ShowWarning("单据错误:\n 没有可供处理的数据");
                return;
            }

            ParentGrid = eventHandler.InitFormClass.DGrid;
            dt = ds.Tables[ApplicationConstraints.DetailTableName];

            bool isRealcheck = Tools.GetBoolSysPara("CheckType");
            if (isRealcheck)
            {
                if (dt.Rows.Count <= 0)
                {
                    RetailMessageBox.ShowWarning("单据错误:\n 没有可供处理的数据");
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
                //如果失败
                ErrDesc = ex.Message;
                RetailMessageBox.ShowWarning("单据错误:\n" + ErrDesc);
                return;
            }

            //更新列表
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

            //获取主表值控件
            ValueControls oiter = HandleEvent.GetValueControls(eventHandler.SourceForm);
            if (null == oiter)
                throw (new Exception("不能访问主表值控件列表"));

            //by pxc
            //检查是否可以进行指定的操作
            //通过表达式判断
            string sDesc = "";
            if (!eventHandler.CanDoNextOperation(oRow, oN, ref sDesc))
            {
                RetailMessageBox.ShowWarning("不能进行操作。\n原因是:" + sDesc);
                return;
            }
            // 判断是不是已经提示过！以后可以更改为，多选时逐个确认

            // 得到询问的语句
            strMessage1 = Tools.GetStringAttribute((XmlElement)no, "Message1");
            if (strMessage1 == "")
            {
                strMessage1 = "下面将更新数据，是否继续？";
            }
            strTitle1 = Tools.GetStringAttribute((XmlElement)no, "Title1");
            if (strTitle1 == "")
            {
                strTitle1 = "提示";
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

            //Seaman Xiong 2006-5-26 排除批处理
            if (dsSave.Tables.Contains("Main"))
            {
                dsSave.Tables.Remove("Main");
            }
            dsSave.Tables.Add(dtMain);

            //Seaman Xiong 2006-5-26 排除批处理
            if (!dsSave.ExtendedProperties.ContainsKey("TemplateID"))
                dsSave.ExtendedProperties.Add("TemplateID", sDataSourceTemplate);

            Data process = new Data();
            string errDesc = "";
            string outXML = "";
            process.Save("<u/>", dsSave, ref outXML, ref errDesc);
            if (errDesc != "")
                throw (new Exception(errDesc));

            //  完成后提示完成的信息
            strMessage2 = Tools.GetStringAttribute((XmlElement)no, "Message2");
            if (strMessage2 == "")
            {
                strMessage2 = "成功完成数据更新！";
            }
            strTitle2 = Tools.GetStringAttribute((XmlElement)no, "Title2");
            if (strTitle2 == "")
            {
                strTitle2 = "更新单据";
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
            //把“商品+自由项+批号+生产日期/有效期至+货位”都相同的行的数量和金额合并。V8.91, libo, 2010-02-01
            //追加货位ID。V8.91, libo, 2010-02-01
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
        /// 检查出单据是否出入库
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
        /// 盘点复核时更新修改过的数据对应的金额
        /// </summary>
        /// <returns></returns>
        public void UpdataRealStocksData(object sender, ExternalMethodCallArgs args)
        {
            try
            {
                HandleEvent eventHandler = args.HandleEvent;
                Init InitFormClass = eventHandler.InitFormClass;

                // 得到网格中的商品信息明细
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
