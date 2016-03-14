using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UFIDA.Retail.Utility;
using UFIDA.Retail.Common;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        sl_RetailCommom RetailCommom = new sl_RetailCommom();

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            frmCustomerAddForm AddForm = new frmCustomerAddForm(dgv, "Add");
            if (AddForm.ShowDialog() == DialogResult.OK)
            {
                RetailCommom.DataRefresh(dgv, "");
            }
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            RetailCommom.DataRefresh(dgv, "");
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {

        }

        private void tsbExport_Click(object sender, EventArgs e)
        {
            string ExcelFilePath = string.Empty;
            DataExport export = new DataExport();
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "Execel 97-2003工作簿(*.xls)|*.xls|Execel 工作簿(*.xlsx)|*.xlsx|所有文件(*.*)|*.*"
            };

            if (dgv.Rows.Count > 1)
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ExcelFilePath = dialog.FileName;

                    //System.Threading.Thread pthred = new System.Threading.Thread(new System.Threading.ThreadStart(Lixtech.Common.CommonClass.ShowWaitForm));
                    //pthred.Start();
                    try
                    {
                        if (export.FlexToExcel(dgv, ExcelFilePath, "展厅客户列表" + DateTime.Now.ToString("yyyy-MM-dd")))
                        {
                            //if (pthred != null)
                            //{
                            //    pthred.Abort();
                            //    pthred = null;
                            //}
                            //GC.Collect();

                            MessageBox.Show("数据导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        //pthred.Abort();
                        //pthred = null;
                        //GC.Collect();
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        //if (pthred != null)
                        //{
                        //    pthred.Abort();
                        //    pthred = null;
                        //}
                        GC.Collect();
                    }
                }
            }
            else
            {
                MessageBox.Show("导出前请先刷新数据！");
                return;
            }
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            frmCustomerQueryForm QueryForm = new frmCustomerQueryForm(dgv);
            if (QueryForm.ShowDialog() == DialogResult.OK)
            { 
               
            }
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            if (dgv.Row > 0)
            {
                frmCustomerAddForm ModifyForm = new frmCustomerAddForm(dgv, "Modify");
                if (ModifyForm.ShowDialog() == DialogResult.OK)
                {
                    RetailCommom.DataRefresh(dgv, "");
                }
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除当前客户吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgv.Row > 0)
                {
                    if (Convert.ToBoolean(dgv.Rows[dgv.Row]["是否上传"]))
                    {
                        RetailMessageBox.ShowInformation("已上传记录不允许删除！");
                        return;
                    }
                    else
                    {
                        if (CheckCusIsRef())
                        {
                            RetailMessageBox.ShowInformation("当前客户在零售单据中已使用，不允许删除！");
                            return;
                        }

                        SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, string.Format(@"delete from sl_ZT_Customer where ID = '{0}'", dgv.Rows[dgv.Row]["ID"].ToString()));
                        RetailMessageBox.ShowInformation("数据删除成功！");
                        dgv.Rows.Remove(dgv.Row);
                    }
                }
            }
            else
                return;
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1)
            {
                tsbModify_Click(sender, e);
            }
        }

        /// <summary>
        /// 检查当前客户是否被单据引用
        /// </summary>
        /// <returns></returns>
        private bool CheckCusIsRef()
        {
            string sql = string.Empty;
            bool bFlag = false;
            if (dgv.Row > 0)
            {
                sql = string.Format("select Count(*) from retailvouch where sl_ZT_CustomerCode = '{0}'", dgv.Rows[dgv.Row]["客户编码"].ToString());
                if (Convert.ToInt32(SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sql)) > 0)
                {
                    bFlag = true;
                }
            }

            return bFlag;
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RetailCommom.DataRefresh(dgv, "");
        }

        private void tsbUploadToRM_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1)
            {
                string sql = string.Empty;
                DataTable dt = new DataTable();
                DataSet DsRdVouch = new DataSet();
                int RowCount = 0;
                string AlterMsg = string.Empty;
                AlterMsg = "";
                sql = string.Format(@"select ID,fchrCusCode,fchrCusName from sl_ZT_Customer where isnull(fbitExport,0) = 0");
                if (SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql).Tables.Count > 0)
                {
                    dt = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql).Tables[0];
                    RowCount = dt.Rows.Count;
                    if (RowCount > 0)
                    {
                        if (MessageBox.Show(string.Format(@"存在【{0}】条未上传至零售系统的展厅客户信息，是否全部上传！", RowCount), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                DsRdVouch = RetailCommom.GetDsData(dt.Rows[i]["ID"].ToString(), "Customer");
                                if (DsRdVouch != null)
                                {
                                    //上传操作
                                    string ErrMsg = "";
                                    bool bFlag = false;

                                    string selCmd = "select fchrSelectionString from sl_VipCardDueConfig where fchrType='RmWebService'";
                                    object objSelStr = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd);

                                    if (!RetailCommom.CheckNetIsConnected(objSelStr.ToString().Split('/')[2].Split(':')[0].ToString()))
                                    {
                                        AlterMsg += "展厅客户【" + dt.Rows[i]["fchrCusName"].ToString() + "】上传零售系统失败，原因：与总部服务器连接失败，请检查网络连接是否正常！" + "\r\n";
                                        //RetailMessageBox.ShowInformation("与总部服务器连接失败，请检查网络连接是否正常！");
                                        break;
                                    }

                                    if (Convert.IsDBNull(objSelStr) || string.IsNullOrEmpty(Convert.ToString(objSelStr)))
                                    {
                                        //RetailMessageBox.ShowInformation("RMWebServiceURL不存在,请先日常下载!");
                                        AlterMsg += "展厅客户【" + dt.Rows[i]["fchrCusName"].ToString() + "】上传零售系统失败，原因：RMWebServiceURL不存在,请先日常下载!" + "\r\n";
                                        break;
                                    }

                                    string url = Convert.ToString(objSelStr);
                                    object obj = null;
                                    string Err = "";
                                    try
                                    {
                                        object[] args = { dt.Rows[i]["ID"].ToString(), DsRdVouch };
                                        //上传RM操作
                                        bFlag = Convert.ToBoolean(Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "sl_ZT_DataExchangeFromPosToRM", args));
                                        if (bFlag)
                                        {
                                            //MessageBox.Show("借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】已成功上传到零售系统！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            AlterMsg += "展厅客户【" + dt.Rows[i]["fchrCusName"].ToString() + "】已成功上传到零售系统！" + "\r\n";
                                            //更新借出单上传标志
                                            RetailCommom.SetUploadFlagForCustomer(dt.Rows[i]["ID"].ToString());
                                        }
                                        else
                                        {
                                            //MessageBox.Show("借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】上传到零售系统失败，请稍后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            AlterMsg += "展厅客户【" + dt.Rows[i]["fchrCusName"].ToString() + "】上传零售系统失败，请稍后再试！" + "\r\n";
                                            continue;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        selCmd = "select fchrSelectionString from sl_VipCardDueConfig where fchrType='RmService'";
                                        objSelStr = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd);

                                        if (!RetailCommom.CheckNetIsConnected(objSelStr.ToString().Split('/')[2].Split(':')[0].ToString()))
                                        {
                                            AlterMsg += "展厅客户【" + dt.Rows[i]["fchrCusName"].ToString() + "】上传零售系统失败，原因：与总部服务器连接失败，请检查网络连接是否正常！" + "\r\n";
                                            //RetailMessageBox.ShowInformation("与总部服务器连接失败，请检查网络连接是否正常！");
                                            break;
                                        }

                                        if (Convert.IsDBNull(objSelStr) || string.IsNullOrEmpty(Convert.ToString(objSelStr)))
                                        {
                                            //RetailMessageBox.ShowInformation("RMWebServiceURL不存在,请先日常下载!");
                                            AlterMsg += "展厅客户【" + dt.Rows[i]["fchrCusName"].ToString() + "】上传零售系统失败，原因：RMWebServiceURL不存在,请先日常下载!" + "\r\n";
                                            continue;
                                        }

                                        url = Convert.ToString(objSelStr);

                                        try
                                        {
                                            object[] args = { dt.Rows[i]["ID"].ToString(), DsRdVouch };
                                            //上传RM操作
                                            bFlag = Convert.ToBoolean(Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "sl_ZT_DataExchangeFromPosToRM", args));
                                            if (bFlag)
                                            {
                                                //MessageBox.Show("借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】已成功上传到零售系统！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                AlterMsg += "展厅客户【" + dt.Rows[i]["fchrCusName"].ToString() + "】已成功上传到零售系统！" + "\r\n";
                                                //更新借出单上传标志
                                                RetailCommom.SetUploadFlagForCustomer(dt.Rows[i]["ID"].ToString());
                                            }
                                            else
                                            {
                                                AlterMsg += "展厅客户【" + dt.Rows[i]["fchrCusName"].ToString() + "】上传零售系统失败，请稍后再试！" + "\r\n";
                                                //MessageBox.Show("借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】上传到零售系统失败，请稍后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                continue;
                                            }
                                        }
                                        catch
                                        {
                                            //RetailMessageBox.ShowInformation("远程服务器无法连接,请检查网络!");
                                            AlterMsg += "展厅客户【" + dt.Rows[i]["fchrCusName"].ToString() + "】上传零售系统失败，原因：远程服务器无法连接,请检查网络!" + "\r\n";
                                            continue;
                                        }
                                    }
                                }
                            }

                            if (!string.IsNullOrEmpty(AlterMsg))
                            {
                                RetailMessageBox.ShowInformation(AlterMsg);
                                tsbRefresh_Click(sender, e);
                            }
                        }
                        else
                            return;
                    }
                    else
                    {
                        RetailMessageBox.ShowInformation("没有可上传的归还单据！");
                        return;
                    }
                }
            }
            else
            {
                RetailMessageBox.ShowInformation("请先刷新列表再进行上传！");
                return;
            }
        }
    }
}
