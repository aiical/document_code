using System;
using System.Collections.Generic;
using System.Text;
using UFIDA.Retail.Components;
using System.Windows.Forms;
using UFIDA.Retail.Utility;
using UFIDA.Retail.Common;
using System.Data;
using System.Reflection;

namespace UFIDA.Retail.VIPCardControl
{
    public class VIPDoWithEx
    {
        private string s01_fchrApplicant = SysPara.GetString("操作员名称");
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
            frmEdit.Text = "VIP客户信息变更申请单(新增)";
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
                    frmEdit.Text = "VIP客户信息变更申请单(编辑)";
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
                        RetailMessageBox.ShowInformation("单据已上传，不能删除");
                        return;
                    }
                    else if (RetailMessageBox.ShowConfirm("您确定删除吗？") == DialogResult.OK)
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
                RetailMessageBox.ShowInformation("删除成功");
                return true;
            }
            else
            {
                RetailMessageBox.ShowInformation("删除失败");
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
    }
}
