using System;
using System.Collections.Generic;
using System.Text;
using UFIDA.Retail.Components;
using System.Windows.Forms;
using UFIDA.Retail.Utility;
using UFIDA.Retail.Common;
using System.Data;
using System.Data.SqlClient
;
namespace UFIDA.Retail.VIPCardControl
{
    public class VoucherControl
    {

        private string sl_InVouchDate;

        public string Sl_InVouchDate
        {
            get { return sl_InVouchDate; }
            set { sl_InVouchDate = value; }
        }


        /// <summary>
        /// 要货申请单营业员默认为要货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void SetDefaultRequier(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent handleEvent = args.HandleEvent;
            string sql = string.Format("select fchrEmployeeID from dbo.Employee where fchrEmployeeName = '{0}'", (HandleEventHelper.FindControl("fchrEmployeeID", handleEvent.SourceForm) as RefControl).RefName);

            string fchrEmployeeID = Convert.ToString(SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sql, null));
            if (!string.IsNullOrEmpty(fchrEmployeeID))
            {
                (HandleEventHelper.FindControl("fchrEmployeeID", handleEvent.SourceForm) as RefControl).RefID = fchrEmployeeID;
            }
        }

        /// <summary>
        /// 新增VIP处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void VIPAdd(object sender, ExternalMethodCallArgs args)
        {
            frmVIPConsumerInfoModify objVIPAdd = new frmVIPConsumerInfoModify();
            objVIPAdd.IsAddConsumer = true;
            objVIPAdd.Text = "添加";
            if (objVIPAdd.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGrid(sender, args);
            }
        }

        /// <summary>
        /// 刷新网格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void RefreshDataGrid(object sender, ExternalMethodCallArgs args)
        {
            HandleEvent eventHandler = args.HandleEvent;
            try
            {
                DataGrid dataGrid = eventHandler.GetDataGrid();
                if (dataGrid.DataSource != null)
                {
                    eventHandler.InitFormClass.DGrid.DataSource = dataGrid.DataSource;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 店存入库单保存检查
        /// 补单时，检查单据日期与销售目标期间日期是否相符，如果不在期间内补单，给出提示并保存失败
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public bool SalesMonthlySaveCheck(object sender, ExternalMethodCallArgs args) {
            HandleEvent eventHandler = args.HandleEvent;
            Init InitFormClass = eventHandler.InitFormClass;
            string fdtmDate = string.Empty;
            Control controlSource = null;
            string err = "已月结不能补单，保存失败！";
            controlSource = HandleEvent.FindControl("fdtmDate", InitFormClass.MainForm);
            fdtmDate = HandleEventHelper.GetControlValues(controlSource, "ExDatePicker");
            return CheckVouchDate(fdtmDate,ref err);
        }

        /// <summary>
        /// 检查单据日期与销售目标期间是否相符
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static bool CheckVouchDate(string fdtmDate,ref string err) {
            
            int fchrYear = 0;
            string fdtmStartDate = string.Empty;
            string fdtmEndDate = string.Empty;
            int EffectRows = 0;
            bool bFlag = true;
            try {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat(@"select top 1 * from SalesTargetPeriodEachFront 
                            where fchrYear = Year('{0}') and fbitMonthly = 1
                            order by fchrPeriod desc", fdtmDate);
              
                SqlDataReader sdr = (SqlDataReader)SqlAccess.ExecuteReader(SysPara.ConnectionString, CommandType.Text, sb.ToString());
                if (sdr.HasRows) {
                    while (sdr.Read()) {
                        fchrYear = Convert.ToInt32(sdr["fchrYear"]);
                        fdtmStartDate = sdr["fdtmStartDate"].ToString();
                        fdtmEndDate = sdr["fdtmEndDate"].ToString();
                    }
                }

                if (!string.IsNullOrEmpty(fdtmDate) && !string.IsNullOrEmpty(fdtmStartDate)) {
                    if (Convert.ToDateTime(Convert.ToDateTime(fdtmDate).ToString("yyyy-MM-dd")) <= Convert.ToDateTime(fdtmEndDate)) {
                        RetailMessageBox.Show(err, "提示");
                        bFlag = false;
                    }
                }
            } catch (Exception ex) {
                Logger.WriteLine(ex.Message);
                bFlag = false;
            }
            return bFlag;
        }

        /// <summary>
        /// 处理入库单日期，店存入库单日期默认为入库通知单日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void InoutVoucherHandler(object sender, ExternalMethodCallArgs args)
        {
            Form objForm = (sender as Control).FindForm();
            objForm.Shown += new EventHandler(MainDetailEditInitialized_Shown);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainDetailEditInitialized_Shown(object sender, EventArgs e)
        {
            string sl_fchrCode = string.Empty;
            string sql = string.Empty;
            Control controlSource = null;
            Form objForm = (sender as Form);
            DataSet ds = (objForm as frmMain).init.DGrid.DataSource as DataSet;

            try
            {
                DataTable mainTable = ds.Tables[0];
                if (mainTable.Rows.Count > 0)
                {
                    sl_fchrCode = mainTable.Rows[0]["fchrcode"].ToString() == "" ? "" : mainTable.Rows[0]["fchrcode"].ToString();
                }
                if (sl_fchrCode != "")
                {
                    //获取所参照的入库通知单单据日期
                    sql = string.Format("select fdtmDate from inoutvouch where fchrcode = '{0}'", sl_fchrCode);
                    Sl_InVouchDate = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sql).ToString();
                    controlSource = HandleEventHelper.FindControl("fdtmDate", objForm);
                    (controlSource as ExDatePicker).ControlValue = Sl_InVouchDate;
                }
                else
                    return;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
