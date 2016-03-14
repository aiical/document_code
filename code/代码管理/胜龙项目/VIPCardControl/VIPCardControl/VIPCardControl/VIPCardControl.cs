using System;
using System.Collections.Generic;
using System.Text;
using UFIDA.Retail.VipDoWith;
using UFIDA.Retail.Components;
using UFIDA.Retail.Utility;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using UFIDA.Retail.Common;
using UFIDA.Retail.DataAccess;

namespace UFIDA.Retail.VIPCardControl
{
    public class VIPCardInventoryManage : VipDoWith.VipDoWith
    {
        #region VIP卡库存管理
        public void SaveVipCardInventoryMuti(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent handleEvent = args.HandleEvent;
            Init initFormClass = handleEvent.InitFormClass;
            string VipCode = "";
            try
            {
                DataSet dataSource = initFormClass.DGrid.DataSource as DataSet;
                string strVIPConsumerID = HandleEventHelper.GetControlValues(HandleEvent.FindControl("fchrvipconsumerid", initFormClass.MainForm), "ExLabel");
                if (dataSource != null)
                {
                    DataTable table = dataSource.Tables["DTDetail"];
                    if (table.Rows.Count == 0)
                    {
                        return;
                    }
                    else
                    {
                        if (table.Rows.Count > 1)
                        {
                            RetailMessageBox.ShowError("一个客户只能分配一张卡！如需要请向相关部门申请");
                            return;
                        }
                        else
                        {
                            VipCode = table.Rows[0]["fchrVipCode"].ToString();
                            VIPCardControl vipCardControl = new VIPCardControl();
                            if (vipCardControl.checkVipCardToConsumer(VipCode))
                                CreateDataVipCardInventory(VipCode, strVIPConsumerID, 0);
                        }

                    }
                }

            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message);
                return;
            }
        }
        public void SaveVipCardInventorySingle(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent handleEvent = args.HandleEvent;
            Init initFormClass = handleEvent.InitFormClass;
            try
            {
                DataGrid dataGrid = handleEvent.GetDataGrid();
                DataTable detailTable = handleEvent.GetDetailTable();
                if ((((dataGrid != null) && (dataGrid.CurrentRowIndex >= 0)) && ((detailTable != null) && (detailTable.Rows.Count != 0))) && ((detailTable.Rows.Count - 2) >= 0))
                {
                    string str = detailTable.Rows[detailTable.Rows.Count - 2]["fchrvipconsumerid"].ToString();
                    //string str2 = detailTable.Rows[detailTable.Rows.Count - 2]["fnarconsumername"].ToString();
                    string strVipCode = detailTable.Rows[detailTable.Rows.Count - 2]["fchrVipCode"].ToString();
                    if (str != "" && strVipCode != "")
                        CreateDataVipCardInventory(strVipCode, str, 0);
                }
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message);
            }

        }
        public void CreateDataVipCardInventory(string VIPCode, string VIPConsumerID, int RetailMark)
        {
            if (VIPCode == "" || VIPConsumerID == "")
                return;
            //门店发卡的才进行库存管理
            //获取系统参数
            object DepartmentID = Tools.GetStringSysPara("部门ID");//部门ID
            object SquadID = SysPara.GetString("班次ID");
            string Maker = SysPara.GetString("操作员名称");
            string EmployeeID = SysPara.GetString("操作员ID");
            string RetailVouchID = Guid.NewGuid().ToString();//零售单ID
            string RetailDetailVouchID = Guid.NewGuid().ToString();//零售单子表ID
            string ErroMes = "";
            string RetailCode = ReceiptNoRule.SetNewReceiptNo("零售单", DateTime.Now, ref ErroMes);//零售单CODE

            string GatheringVouchID = Guid.NewGuid().ToString();//收款单ID
            string GatheringDetailVouchID = Guid.NewGuid().ToString();//收款单子表ID
            string GatheringCode = ReceiptNoRule.SetNewReceiptNo("收款单", DateTime.Now, ref ErroMes);//收款单CODE

            //组织SQL插入数据
            //零售单主表
            string RetailVouchSql = string.Format("insert into RetailVouch(fchrRetailVouchID,fchrDepartmentID,fdtmDate,fchrSquadID,fchrCode,fchrMaker,flotGatheringMoney,fdtmMakeDate,ftinState,ftinPayment,fchrGatheringVouchID,fchrMainEmployeeID,fnarvipcardcode,fchrVipConsumerID,ftinItemModel,fbitNegative)  select '{0}',case when '{1}'<>'' then '{1}' else NULL end,'{2}',case when '{3}'<>'' then '{3}' else NULL end,'{4}','{5}',0,'{2}',1,2,'{6}','{7}','{8}','{9}',1,'{10}'"
                , new object[] { RetailVouchID, DepartmentID.ToString() == "" ? DBNull.Value : DepartmentID, DateTime.Now, SquadID.ToString() == "" ? DBNull.Value : SquadID, RetailCode, Maker, GatheringVouchID, EmployeeID, VIPCode, VIPConsumerID, RetailMark });
            //零售单子表
            string RetailVouchDetailSql = string.Format("insert into RetailVouchDetail(fchrRetailVouchDetailId,fchrRetailVouchID,fchrItemID,flotQuantity,flotMoney,flotPrice,ftinOrder,fchrEmployeeID,fbitUse,ftinItemModel) " +
                              " select '{0}','{1}',(select S01_fchritemID from VipCodeCollate inner join VIPCardClass on VipCodeCollate.S01_fchrVIPCardClassID=VIPCardClass.fchrVIPCardClassID where fchrVipCode='{2}'),1,0,0,0,'{3}',0,1"
             , new object[] { RetailDetailVouchID, RetailVouchID, VIPCode, EmployeeID });
            //收款单主表
            string GatheringVouchSql = string.Format("insert into GatheringVouch(fchrGatheringVouchID,fdtmDate,fchrSquadID,fchrCode,flotChangeMoney,fchrMaker,fchrRetailVouchID,fbitHaveGiftToken,fbitNegative) values('{0}','{1}',case when '{2}'<>'' then '{2}' else NULL end,'{3}',0,'{4}','{5}',0,'{6}')",
                new object[] { GatheringVouchID, DateTime.Now, SquadID, GatheringCode, Maker, RetailVouchID, RetailMark });
            //收款单子表
            string GatheringDetailVouchSql = string.Format("insert into GatheringVouchDetail(fchrGatheringVouchDetailID,fchrSettleID,fchrGatheringVouchID,flotMoney,ftinOrder,fbitIsStoredCard) select '{0}',(select top 1 (fchrSettleID) from  SettleStyle where fbitDefault=1),'{1}',0,0,0"
                , new object[] { GatheringDetailVouchID, GatheringVouchID });
            //扣减库存
            string invSql = string.Format("exec sp_ModifyStocksWhilePayment @ReceiptID='{0}'"
               , new object[] { GatheringVouchID });

            SqlConnection connection = null;
            IDbTransaction transaction = null;
            try
            {

                try
                {
                    connection = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
                    SqlAccess.Open(connection);
                }
                catch
                {
                    SqlAccess.Close(connection);
                    return;
                }
                transaction = SqlAccess.BeginTransaction(connection);
                SqlAccess.ExecuteNonQuery(transaction, CommandType.Text, RetailVouchSql);
                SqlAccess.ExecuteNonQuery(transaction, CommandType.Text, RetailVouchDetailSql);
                SqlAccess.ExecuteNonQuery(transaction, CommandType.Text, GatheringVouchSql);
                SqlAccess.ExecuteNonQuery(transaction, CommandType.Text, GatheringDetailVouchSql);
                SqlAccess.ExecuteNonQuery(transaction, CommandType.Text, invSql);
                transaction.Commit();
                SqlAccess.Close(connection);
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                SqlAccess.Close(connection);
                string message = exception.Message;
            }
        }
        public void DeleteVipCardInventory(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent handleEvent = args.HandleEvent;
            //Init initFormClass = handleEvent.InitFormClass;
            DataGrid dataGrid = handleEvent.GetDataGrid();
            DataTable table = (dataGrid.DataSource as DataSet).Tables[dataGrid.DataMember];
            string VIPConsumerID = table.Rows[dataGrid.CurrentRowIndex]["fchrvipconsumerid"].ToString();
            string VIPCodes = table.Rows[dataGrid.CurrentRowIndex]["fchrVipCode"].ToString();
            string[] VipCodesArr = VIPCodes.Split(',');
            foreach (string VipCode in VipCodesArr)
            {
                DeleteVipCunsumerData(VipCode, VIPConsumerID);
            }
        }

        private void DeleteVipCunsumerData(string VipCardCode, string VipCunsumerID)
        {
            if (VipCardCode == "" || VipCunsumerID == "")
                return;
            //先生成一个退货单，算店存余额
            CreateDataVipCardInventory(VipCardCode, VipCunsumerID, 1);
            SqlConnection connection = null;
            IDbTransaction transaction = null;
            try
            {
                try
                {
                    connection = new SqlConnection(SysPara.GetSysPara("SysConn").ToString());
                    SqlAccess.Open(connection);
                }
                catch
                {
                    SqlAccess.Close(connection);
                    return;
                }
                transaction = SqlAccess.BeginTransaction(connection);
                //判断是否已日结，日结的单据不能删除
                if (!checkVouchExport(VipCardCode, VipCunsumerID))
                {
                    //删除收款单子表
                    string GatheringDetailVouchSql = string.Format("delete  from GatheringVouchDetail where fchrGatheringVouchID in (select fchrGatheringVouchID from RetailVouch where fnarvipcardcode='{0}' and fchrVipConsumerID='{1}' and flotGatheringMoney=0)"
                        , new object[] { VipCardCode, VipCunsumerID });
                    //删除收款单主表
                    string GatheringVouchSql = string.Format("delete  from GatheringVouch where fchrGatheringVouchID in (select fchrGatheringVouchID from RetailVouch where fnarvipcardcode='{0}' and fchrVipConsumerID='{1}' and flotGatheringMoney=0)"
                        , new object[] { VipCardCode, VipCunsumerID });
                    //删除零售单子表
                    string RetailVouchDetailSql = string.Format("delete  from RetailVouchDetail where fchrRetailVouchID in (select fchrRetailVouchID from RetailVouch where fnarvipcardcode='{0}' and fchrVipConsumerID='{1}' and flotGatheringMoney=0)"
                        , new object[] { VipCardCode, VipCunsumerID });
                    //删除零售单主表
                    string RetailVouchSql = string.Format("delete  from RetailVouch where fchrRetailVouchID in (select fchrRetailVouchID from RetailVouch where fnarvipcardcode='{0}' and fchrVipConsumerID='{1}' and flotGatheringMoney=0)"
                        , new object[] { VipCardCode, VipCunsumerID });
                    SqlAccess.ExecuteNonQuery(transaction, CommandType.Text, GatheringDetailVouchSql);
                    SqlAccess.ExecuteNonQuery(transaction, CommandType.Text, GatheringVouchSql);
                    SqlAccess.ExecuteNonQuery(transaction, CommandType.Text, RetailVouchDetailSql);
                    SqlAccess.ExecuteNonQuery(transaction, CommandType.Text, RetailVouchSql);
                }
                //记录删除的客户ID
                string VipConsumerDeleLogSql = string.Format("insert into S01_VIPConsumerDelete(S01_VIPConsumerID) values('{0}')", VipCunsumerID);
                SqlAccess.ExecuteNonQuery(transaction, CommandType.Text, VipConsumerDeleLogSql);

                transaction.Commit();
                SqlAccess.Close(connection);
            }
            catch (Exception exception)
            {
                transaction.Rollback();
                SqlAccess.Close(connection);
                string message = exception.Message;
            }

        }


        private bool checkVouchExport(string VipCardCode, string VipCunsumerID)
        {
            bool result = false;
            ///////检查单据是否已经日结
            string strcmd = string.Format("select * from RetailVouch where fchrRetailVouchID = (select fchrRetailVouchID from RetailVouch where fnarvipcardcode='{0}' and fchrVipConsumerID='{1}' and flotGatheringMoney=0 and fbitNegative=0)", VipCardCode, VipCunsumerID);
            DataTable resultTable = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, strcmd);
            if (resultTable != null && resultTable.Rows.Count > 0)
            {
                if (resultTable.Rows[0]["fchrRetailReportID"].ToString() != "")
                    result = true;
            }
            return result;
        }
        #endregion
    }

    public class VIPCardControl : VipDoWith.VipDoWith
    {
        #region --------VIP卡的控制
        public bool CheckVIPCardInventoryAddMuti(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent handleEvent = args.HandleEvent;
            Init initFormClass = handleEvent.InitFormClass;
            bool checkResult = true;
            try
            {
                //HandleEvent.FilterEmptyRows(initFormClass.DGrid);
                DataSet dataSource = initFormClass.DGrid.DataSource as DataSet;
                string strVIPConsumerID = HandleEventHelper.GetControlValues(HandleEvent.FindControl("fchrvipconsumerid", initFormClass.MainForm), "ExLabel");
                if (dataSource != null)
                {
                    DataTable table = dataSource.Tables["DTDetail"];
                    if (table.Rows.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        if (table.Rows.Count > 1)
                        {
                            RetailMessageBox.ShowError("一个客户只能分配一张卡！如需要请向相关部门申请");
                            return false;
                        }
                        foreach (DataRow row in table.Rows)
                        {
                            if (row.RowState == DataRowState.Added)
                            {
                                string vipCardCode = row["fchrVipCode"].ToString();
                                if (checkVipCardToConsumer(vipCardCode))
                                {
                                    RetailMessageBox.ShowError("您所选择的VIP卡已经分配客户，请重新选择！");
                                    return false;
                                }
                                if (!checkVipCardClass(vipCardCode, strVIPConsumerID))
                                {
                                    RetailMessageBox.ShowError("您选择的卡级别和客户级别不匹配，请重新选择！");
                                    return false;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message);
            }
            return checkResult;
        }

        public bool CheckVIPCardToConsumerSingle(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent handleEvent = args.HandleEvent;
            Init initFormClass = handleEvent.InitFormClass;
            Form findForm = (sender as Control).FindForm();
            bool result = false;
            try
            {
                string VipCode = "";
                RefControl refVipCard = HandleEventHelper.FindControl("fchrVipCode", findForm) as RefControl;
                if (refVipCard != null)
                {
                    VipCode = refVipCard.RefName.Trim();
                }
                if (checkVipCardToConsumer(VipCode))
                {
                    RetailMessageBox.ShowWarning("您所选择的VIP卡已经分配客户，请重新选择！");
                    refVipCard.Clear();
                }
                else
                {
                    result = true;
                }

            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message);
                return false;
            }
            return result;
        }
        public bool CheckVIPCardClass(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent handleEvent = args.HandleEvent;
            Init initFormClass = handleEvent.InitFormClass;
            Form findForm = (sender as Control).FindForm();
            bool result = false;
            try
            {
                string VipCode = "";
                string VipCardClassID = "";
                string VipConsumerClassID = "";
                Control VipCard = HandleEventHelper.FindControl("fchrVipCode", findForm);
                if (VipCard is RefControl)
                {
                    RefControl refVipCard = (RefControl)VipCard;
                    if (refVipCard != null)
                    {
                        VipCode = refVipCard.RefName.Trim();
                    }
                }
                if (VipCard is ExTextBox)
                {
                    ExTextBox VipCardExtext = (ExTextBox)VipCard;
                    if (VipCardExtext != null)
                    {
                        VipCode = VipCardExtext.ControlValue.Trim();
                    }
                }
                if (VipCard is ExLabel)
                {
                    ExLabel VipCardExlable = (ExLabel)VipCard;
                    if (VipCardExlable != null)
                    {
                        VipCode = VipCardExlable.ControlValue.Trim();
                    }
                }
                RefControl refVipClass = HandleEventHelper.FindControl("fchrVIPCardClassName", findForm) as RefControl;
                if (refVipClass != null)
                    VipConsumerClassID = refVipClass.RefID.Trim();
                VipCardClassID = GetVipCardClassID(VipCode);

                if (VipCode != "" && VipConsumerClassID != "" && VipConsumerClassID != VipCardClassID)
                {
                    RetailMessageBox.ShowWarning("您选择的卡级别和客户级别不匹配，请重新选择！");
                    RefControl refVipCard = (RefControl)VipCard;
                    if (refVipCard != null)
                    {
                        refVipCard.Clear();
                    }
                }
                else
                {
                    result = true;
                }

            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message);
                return false;
            }
            return result;
        }
        public bool CheckVipCunsumerExport(object sender, ExternalMethodCallArgs args)
        {
            ///////检查客户信息是否上传
            HandleEvent handleEvent = args.HandleEvent;
            try
            {
                DataGrid dataGrid = handleEvent.GetDataGrid();
                DataTable table = (dataGrid.DataSource as DataSet).Tables[dataGrid.DataMember];
                if ((dataGrid == null) || (dataGrid.CurrentRowIndex < 0))
                {
                    return false;
                }
                if ((table == null) || (table.Rows.Count == 0))
                {
                    return false;
                }
                if (CheckVipCunsumerExportByID(table.Rows[dataGrid.CurrentRowIndex]["fchrvipconsumerid"].ToString()))
                {
                    RetailMessageBox.ShowInformation("已上传，不能删除！");
                    return false;
                }
                return (RetailMessageBox.ShowConfirm("您确定删除吗？") == DialogResult.OK);
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message);
                return false;
            }
        }
        public bool checkVipCardToConsumer(string vipCardCode)
        {
            bool result = false;
            ///////检查VIP卡是否已经有关联客户
            string strcmd = string.Format("select * from viewVipCode where fchrVipCode='{0}'", vipCardCode);
            DataTable resultTable = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, strcmd);
            if (resultTable != null && resultTable.Rows.Count > 0)
            {
                if (resultTable.Rows[0]["fnarconsumername"].ToString() != "")
                    result = true;
            }
            return result;
        }
        public bool checkVipCardClass(string vipCardCode, string VipConsumerID)
        {
            bool result = false;
            ///////检查VIP卡级别是否与客户的级别相同
            string strcmd = string.Format("select S01_fchrVIPCardClassID as fchrVIPCardClassID  from VipCodeCollate where fchrVipCode='{0}' union all select fchrVIPCardClassID from VipConsumer where fchrvipconsumerid='{1}'", vipCardCode, VipConsumerID);
            DataTable resultTable = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, strcmd);
            if (resultTable != null && resultTable.Rows.Count == 2)
            {
                if ((resultTable.Rows[0]["fchrVIPCardClassID"].ToString() == resultTable.Rows[1]["fchrVIPCardClassID"].ToString()) || vipCardCode == "")
                    result = true;
            }
            return result;
        }
        public string GetVipCardClassID(string vipCardCode)
        {
            string VipCardClass = "";
            string strcmd = string.Format("select S01_fchrVIPCardClassID as fchrVIPCardClassID  from VipCodeCollate where fchrVipCode='{0}'", vipCardCode);
            DataTable resultTable = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, strcmd);
            if (resultTable != null && resultTable.Rows.Count > 0)
            {
                VipCardClass = resultTable.Rows[0]["fchrVIPCardClassID"].ToString();
            }
            return VipCardClass;
        }
        public bool CheckVipCunsumerExists(string VipConsumerID)
        {
            bool result = false;
            string strcmd = string.Format("select * from VipConsumer where fchrvipconsumerid='{0}'", VipConsumerID);
            DataTable resultTable = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, strcmd);
            if (resultTable != null && resultTable.Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }
        public bool CheckVipCunsumerStoreExport(object sender, ExternalMethodCallArgs args)
        {
            ///////检查客户的级别是否门店发卡
            HandleEvent handleEvent = args.HandleEvent;
            try
            {
                DataGrid dataGrid = handleEvent.GetDataGrid();
                DataTable table = (dataGrid.DataSource as DataSet).Tables[dataGrid.DataMember];
                if ((dataGrid == null) || (dataGrid.CurrentRowIndex < 0))
                {
                    return false;
                }
                if ((table == null) || (table.Rows.Count == 0))
                {
                    return false;
                }
                if (!CheckVipCunsumerStoreExportByID(table.Rows[dataGrid.CurrentRowIndex]["fchrvipconsumerid"].ToString()))
                {
                    RetailMessageBox.ShowInformation("此客户级别不能在门店发卡！");
                    return false;
                }
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message);
                return false;
            }
            return true;
        }
        public bool CheckVipCunsumerCheck(object sender, ExternalMethodCallArgs args)
        {
            ///////检查客户信息是否审核
            HandleEvent handleEvent = args.HandleEvent;
            try
            {
                DataGrid dataGrid = handleEvent.GetDataGrid();
                DataTable table = (dataGrid.DataSource as DataSet).Tables[dataGrid.DataMember];
                if ((dataGrid == null) || (dataGrid.CurrentRowIndex < 0))
                {
                    return false;
                }
                if ((table == null) || (table.Rows.Count == 0))
                {
                    return false;
                }
                if (CheckVipCunsumerCheckByID(table.Rows[dataGrid.CurrentRowIndex]["fchrvipconsumerid"].ToString()))
                {
                    RetailMessageBox.ShowInformation("VIP客户信息已审核，不能修改，如需修改请提申请变更单！");
                    return false;
                }
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message);
                return false;
            }
            return true;
        }
        public bool CheckVipCunsumerExportByID(string VipConsumerID)
        {
            bool result = false;
            string strcmd = string.Format("select * from VipConsumer where fchrvipconsumerid='{0}'", VipConsumerID);
            DataTable resultTable = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, strcmd);
            if (resultTable != null && resultTable.Rows.Count > 0)
            {
                if (resultTable.Rows[0]["fbitExport"].ToString() != "" && (bool)resultTable.Rows[0]["fbitExport"])
                    result = true;
            }
            return result;
        }
        public bool CheckVipCunsumerCheckByID(string VipConsumerID)
        {
            bool result = false;
            string strcmd = string.Format("select * from VipConsumer where fchrvipconsumerid='{0}'", VipConsumerID);
            DataTable resultTable = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, strcmd);
            if (resultTable != null && resultTable.Rows.Count > 0)
            {
                if (resultTable.Rows[0]["fbitCheck"].ToString() != "" && (bool)resultTable.Rows[0]["fbitCheck"])
                    result = true;
            }
            return result;
        }
        public bool CheckVipCunsumerStoreExportByID(string VipConsumerID)
        {
            bool result = false;
            string strcmd = string.Format("select * from VipConsumer a left join VIPCardClass b on a.fchrVIPCardClassID=b.fchrVIPCardClassID where a.fchrvipconsumerid='{0}'", VipConsumerID);
            DataTable resultTable = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, strcmd);
            if (resultTable != null && resultTable.Rows.Count > 0)
            {
                if (resultTable.Rows[0]["S01_fbitStoreCardExport"].ToString() != "" && (bool)resultTable.Rows[0]["S01_fbitStoreCardExport"])
                    result = true;
            }
            return result;
        }
        #endregion -------
    }

    public class VIPCardMinusControl : VipDoWith.VipPointCash
    {
        #region VIP积分兑付限制
        public bool CheckVipCardsEnable(object sender, ExternalMethodCallArgs args)
        {
            bool blag = false;
            KeyEventArgs sourceArgs = args.HandleEvent.SourceArgs as KeyEventArgs;
            if (sourceArgs.KeyValue == 13)
            {
                try
                {
                    ExLabel label2 = HandleEvent.FindControl("fchrVipConsumerID", args.HandleEvent.SourceForm) as ExLabel;
                    string VipConsumerID = label2.ControlValue.Trim();
                    if (VipConsumerID == "")
                        return false;
                    string strcmd = string.Format("select count(*) VIPEnableCardCount from VipCodeCollate  where fbitUse <>'False' and (getDate()<=fdtmEndDate or fdtmEndDate is null )" +
                                   "and  exists (select 0 from vipconsumer where ','+fchrVipCards+',' like '%,'+fchrVipCode+',%' and fchrVipConsumerID='{0}') ", VipConsumerID);
                    DataTable resultTable = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, strcmd);
                    bool checkResult = false;
                    if (resultTable != null && resultTable.Rows.Count > 0)
                    {
                        //判断此客户是否有可用的卡：卡在启用状态并且没有过期
                        if ((int)resultTable.Rows[0][0] > 0)
                        {
                            checkResult = true;
                        }
                    }
                    if (!checkResult)
                    {
                        RetailMessageBox.ShowWarning(" 此客户没有有效的VIP卡,请确认客户所有的卡有效！");
                    }
                    else
                        blag = true;

                }
                catch (Exception exception)
                {
                    RetailMessageBox.ShowError(exception.Message + " 客户积分兑付状态校验失败！");
                }

                if (!blag)
                {
                    ClearControlValue(args);
                }
            }
            return blag;
        }

        private void ClearControlValue(ExternalMethodCallArgs args)
        {
            ExTextBox box = HandleEvent.FindControl("fnarConsumerName", args.HandleEvent.SourceForm) as ExTextBox;
            box.ControlValue = "";
            ExLabel label = HandleEvent.FindControl("fchrVipConsumerID", args.HandleEvent.SourceForm) as ExLabel;
            label.ControlValue = "";
            ExNumbericText text = HandleEvent.FindControl("fintMinusTotal", args.HandleEvent.SourceForm) as ExNumbericText;
            text.ControlValue = "";
            ExNumbericText text2 = HandleEvent.FindControl("fintMinus", args.HandleEvent.SourceForm) as ExNumbericText;
            text2.ControlValue = "";
            RefControl control = HandleEvent.FindControl("fintStandard", args.HandleEvent.SourceForm) as RefControl;
            control.SelectedDataSet = null;
            control.RefID = string.Empty;
            control.RefName = string.Empty;
            control.RefNo = string.Empty;
            control.TextBox.Text = string.Empty;
        }

        #endregion
    }
}
