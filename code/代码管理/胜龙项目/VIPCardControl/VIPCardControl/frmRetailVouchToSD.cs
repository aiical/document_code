using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UFIDA.Retail.Utility;
using UFIDA.Retail.Common;
using System.Data.SqlClient;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmRetailVouchToSD : Form
    {
        public frmRetailVouchToSD()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string sql;
            DataSet ds = new DataSet();
            DataTable retailvouch = new DataTable();
            DataTable retailvouchdetail = new DataTable();
            DataTable Origretailvouch = new DataTable();
            DataTable Origretailvouchdetail = new DataTable();
            string selCmd = "select fchrSelectionString from sl_VipCardDueConfig where fchrType='RmWebService'";
            object objSelStr = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd);
            selCmd = "select top 1 fchrStoreDefineID from storedefine";
            string fchrStoreDefineID = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd).ToString();

            if (dgv.Rows.Count <= 0)
            {
                MessageBox.Show("没有新数据需要上传！", "提示");
                return;
            }

            if (Convert.IsDBNull(objSelStr) || string.IsNullOrEmpty(Convert.ToString(objSelStr)))
            {
                MessageBox.Show("RMWebServiceURL不存在,请先日常下载!", "系统提示");
                return;
            }
            string url = Convert.ToString(objSelStr);
            object obj = null;
            try
            {
                Origretailvouch = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, "select *,'' as fdtmAddTime,'' as fchrStoreDefineID from retailvouch where 1=2").Tables[0];
                Origretailvouchdetail = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, "select * from retailvouchdetail where 1=2").Tables[0];
                sql = string.Format(@"select *,getdate() as fdtmAddTime,'{0}' as fchrStoreDefineID from retailvouch where fdtmMakeDate >'{1}';
                                    select * from retailvouchdetail where fchrRetailvouchid in(
                                    select fchrRetailvouchid from retailvouch where fdtmMakeDate >'{1}')", fchrStoreDefineID, txtAddTime.Text.Trim());
                ds = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    retailvouch = ConvertDataTypeToDataTable(Origretailvouch, ds.Tables[0]);
                    retailvouchdetail = ConvertDataTypeToDataTable(Origretailvouchdetail, ds.Tables[1]);
                    object[] args = { fchrStoreDefineID, retailvouch, retailvouchdetail };
                    try
                    {
                        Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "TransmitRetailReportToSD", args);
                        //SqlBulkCopyInsert("RetailVouch_SL", retailvouch, SysPara.ConnectionString);
                        //SqlBulkCopyInsert("RetailVouchDetail_SL", retailvouchdetail, SysPara.ConnectionString);
                        MessageBox.Show("销售日报上传成功！", "提示");
                        frmRetailVouchToSD_Load(sender, e);
                    }
                    catch (Exception ex) { MessageBox.Show("销售日报上传失败，原因是：" + ex.Message); }
                }
                else
                {
                    MessageBox.Show("没有新数据需要上传！", "提示");
                    return;
                }
            }
            catch (Exception ex)
            {
                selCmd = "select fchrSelectionString from sl_VipCardDueConfig where fchrType='RmService'";
                objSelStr = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd);
                if (Convert.IsDBNull(objSelStr) || string.IsNullOrEmpty(Convert.ToString(objSelStr)))
                {
                    MessageBox.Show("RMWebServiceURL不存在,请先日常下载!", "系统提示");
                    return;
                }
                url = Convert.ToString(objSelStr);
                Origretailvouch = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, "select *,'' as fdtmAddTime,'' as fchrStoreDefineID from retailvouch where 1=2").Tables[0];
                Origretailvouchdetail = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, "select * from retailvouchdetail where 1=2").Tables[0];
                sql = string.Format(@"select *,getdate() as fdtmAddTime,'{0}' as fchrStoreDefineID from retailvouch where fdtmMakeDate >'{1}';
                                    select * from retailvouchdetail where fchrRetailvouchid in(
                                    select fchrRetailvouchid from retailvouch where fdtmMakeDate >'{1}')", fchrStoreDefineID, txtAddTime.Text.Trim());
                ds = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    retailvouch = ConvertDataTypeToDataTable(Origretailvouch, ds.Tables[0]);
                    retailvouchdetail = ConvertDataTypeToDataTable(Origretailvouchdetail, ds.Tables[1]);
                    object[] arg = { fchrStoreDefineID, retailvouch, retailvouchdetail };
                    try
                    {
                        Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "TransmitRetailReportToSD", arg);
                        //SqlBulkCopyInsert("RetailVouch_SL", retailvouch, SysPara.ConnectionString);
                        //SqlBulkCopyInsert("RetailVouchDetail_SL", retailvouchdetail, SysPara.ConnectionString);
                        MessageBox.Show("销售日报上传成功！", "提示");
                        frmRetailVouchToSD_Load(sender, e);
                    }
                    catch (Exception exc) { MessageBox.Show("销售日报上传失败，原因是：" + exc.Message); }
                }
                else
                {
                    MessageBox.Show("没有新数据需要上传！", "提示");
                    return;
                }
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRetailVouchToSD_Load(object sender, EventArgs e)
        {
            string fdtmAddTime,sql;
            DataTable dt = new DataTable();
            string selCmd = "select fchrSelectionString from sl_VipCardDueConfig where fchrType='RmWebService'";
            object objSelStr = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd);
            selCmd = "select top 1 fchrStoreDefineID from storedefine";
            string fchrStoreDefineID = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd).ToString();

            if (Convert.IsDBNull(objSelStr) || string.IsNullOrEmpty(Convert.ToString(objSelStr)))
            {
                MessageBox.Show("RMWebServiceURL不存在,请先日常下载!", "系统提示");
                return;
            }
            string url = Convert.ToString(objSelStr);
            object obj = null;
            try
            {
                object[] argsTime = { fchrStoreDefineID };
                fdtmAddTime = Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "GetLastModifyTimeByRetailReport", argsTime).ToString();
            }
            catch (Exception ex)
            {
                selCmd = "select fchrSelectionString from sl_VipCardDueConfig where fchrType='RmService'";
                objSelStr = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd);
                if (Convert.IsDBNull(objSelStr) || string.IsNullOrEmpty(Convert.ToString(objSelStr)))
                {
                    MessageBox.Show("RMWebServiceURL不存在,请先日常下载!", "系统提示");
                    return;
                }
                url = Convert.ToString(objSelStr);
                object[] argTime = { fchrStoreDefineID };
                fdtmAddTime = Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "GetLastModifyTimeByRetailReport", argTime).ToString();
            }

            txtAddTime.Text = fdtmAddTime.Trim();

            string dgvHeadText = "fchrCode as '单据号',fdtmDate as '单据日期',fchrMaker as '制单人',flotGatheringMoney as '收款金额',flotSaleMoney as '销售金额',flotDiscountSum as '折扣金额'";
            sql = string.Format("select {0} from retailvouch where fdtmMakeDate > '{1}'", dgvHeadText, fdtmAddTime);
            dt = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, sql);
            if (dt.Rows.Count > 0)
            {
                dgv.DataSource = dt.DefaultView;
            }
        }

        /// <summary>
        /// 使用SqlBulkCopy将DataTable中的数据批量插入数据库中
        /// </summary>
        /// <param name="strTableName"></param>
        /// <param name="dtData"></param>
        /// <param name="ConnStr"></param>
        public static void SqlBulkCopyInsert(string strTableName, DataTable dtData, string ConnStr)
        {
            //BCP copy  
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
                throw ex;
            }
            finally
            {
                copy.Close();
                conn.Close();
            }
        }


        /// <summary>
        /// 将gGuid数据类型列转换为String数据类型列
        /// </summary>
        /// <param name="dtName"></param>
        public DataTable DataTypeConvert(DataTable dtName)
        {
            try
            {
                foreach (DataColumn dc in dtName.Columns)
                {
                    if (dc.DataType == Type.GetType("System.Guid"))
                    {
                        dc.DataType = Type.GetType("System.String");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("数据类型转换错误，原因是：" + ex.Message);}
            return dtName;
        }

        /// <summary>
        /// 将原始待转换的表转换成新的数据表
        /// </summary>
        /// <param name="OrigTableName"></param>
        /// <param name="NewTableName"></param>
        /// <returns></returns>
        public DataTable ConvertDataTypeToDataTable(DataTable OrigTableName,DataTable NewTableName)
        {
            int i,j;
            DataTable ConvertTable = DataTypeConvert(OrigTableName);
            DataRow dr = null;
            try
            {
                for (i = 0; i < NewTableName.Rows.Count; i++)
                {
                    dr = ConvertTable.NewRow();
                    for (j = 0; j < NewTableName.Columns.Count; j++)
                    {
                        dr[j] = NewTableName.Rows[i][j];
                    }
                    ConvertTable.Rows.Add(dr);
                }
            }
            catch (Exception ex) { MessageBox.Show("数据表转换错误，原因是：" + ex.Message);}
            return ConvertTable;
        }
    }
}
