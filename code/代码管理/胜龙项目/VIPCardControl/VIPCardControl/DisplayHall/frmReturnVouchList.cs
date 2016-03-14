using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UFIDA.Retail.Common;
using UFIDA.Retail.Utility;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmReturnVouchList : Form
    {
        public frmReturnVouchList()
        {
            InitializeComponent();
        }

        sl_RetailCommom RetailCommom = new sl_RetailCommom();

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            frmQueryForm frm = frm = new frmQueryForm("GH", dgv);
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1)
            {
                frmReturnVouch frm = new frmReturnVouch(dgv.Rows[dgv.Row]["单据编号"].ToString(), "View");
                TabPagesUtility.TabPageShow(this.Parent, frm.Name, frm);
            }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            if (dgv.Row > 0)
            {
                tsbView_Click(sender, e);
            }
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RetailCommom.DataRefresh("", "GH", dgv, "1=1");
        }

        private void tsbModify_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1)
            {
                if (dgv.Rows[dgv.Row]["是否暂存"].ToString() == "是")
                {
                    frmReturnVouch frm = new frmReturnVouch(dgv.Rows[dgv.Row]["单据编号"].ToString(), "Modify");
                    TabPagesUtility.TabPageShow(this.Parent, frm.Name, frm);
                }
                else
                {
                    RetailMessageBox.ShowInformation("已保存的单据不允许进行修改！");
                    return;
                }
            }
        }

        private void frmReturnVouchList_Load(object sender, EventArgs e)
        {
            
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            if (dgv.Rows.Count > 1)
            {
                if (dgv.Rows[dgv.Row]["是否暂存"].ToString() == "是")
                {
                    if (MessageBox.Show("您确定要删除该单据吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //删除操作
                        sql = string.Format(@"delete from sl_t_RdVouchDetail where Mainid in(select top 1 MainID from sl_t_RdVouchMain where fchrCode = '{0}' and fchrVouchType = 'GH');
                                              delete from sl_t_RdVouchMain where fchrCode = '{0}' and fchrVouchType = 'GH'", dgv.Rows[dgv.Row]["单据编号"].ToString());
                        SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, sql);
                        RetailMessageBox.ShowInformation("单据删除成功！");
                        tsbRefresh_Click(sender, e);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    RetailMessageBox.ShowInformation("已保存的单据不允许删除！");
                    return;
                }
            }
        }

        private void tsbExport_Click(object sender, EventArgs e)
        {

        }

        private void tsbUpload_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1)
            {
                string sql = string.Empty;
                DataTable dt = new DataTable();
                DataSet DsRdVouch = new DataSet();
                int RowCount = 0;
                string AlterMsg = string.Empty;
                AlterMsg = "";
                sql = string.Format(@"select MainId,fchrCode from sl_t_RdVouchMain where fchrVouchType = 'GH' and isnull(fbitTransferToRetail,0) = 0 and isnull(fbitTempSave,0) = 0");
                if (SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql).Tables.Count > 0)
                {
                    dt = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql).Tables[0];
                    RowCount = dt.Rows.Count;
                    if (RowCount > 0)
                    {
                        if (MessageBox.Show(string.Format(@"存在【{0}】张未上传至零售系统的归还单，是否全部上传！", RowCount), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Threading.Thread pthred = new System.Threading.Thread(new System.Threading.ThreadStart(Lixtech.Common.CommonClass.ShowWaitForm));
                            pthred.Start();
                            try
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    DsRdVouch = RetailCommom.GetDsData(dt.Rows[i]["MainId"].ToString(), "GH");
                                    if (DsRdVouch != null)
                                    {
                                        //上传操作
                                        string ErrMsg = "";
                                        bool bFlag = false;

                                        string selCmd = "select fchrSelectionString from sl_VipCardDueConfig where fchrType='RmWebService'";
                                        object objSelStr = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd);

                                        if (!RetailCommom.CheckNetIsConnected(objSelStr.ToString().Split('/')[2].Split(':')[0].ToString()))
                                        {
                                            AlterMsg += "借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】上传零售系统失败，原因：与总部服务器连接失败，请检查网络连接是否正常！" + "\r\n";
                                            //RetailMessageBox.ShowInformation("与总部服务器连接失败，请检查网络连接是否正常！");
                                            break;
                                        }

                                        if (Convert.IsDBNull(objSelStr) || string.IsNullOrEmpty(Convert.ToString(objSelStr)))
                                        {
                                            //RetailMessageBox.ShowInformation("RMWebServiceURL不存在,请先日常下载!");
                                            AlterMsg += "借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】上传零售系统失败，原因：RMWebServiceURL不存在,请先日常下载!" + "\r\n";
                                            break;
                                        }

                                        string url = Convert.ToString(objSelStr);
                                        object obj = null;
                                        string Err = "";
                                        try
                                        {
                                            object[] args = { dt.Rows[i]["MainId"].ToString(), DsRdVouch };
                                            //上传RM操作
                                            bFlag = Convert.ToBoolean(Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "sl_ZT_DataExchangeFromPosToRM", args));
                                            if (bFlag)
                                            {
                                                //MessageBox.Show("借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】已成功上传到零售系统！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                AlterMsg += "借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】已成功上传到零售系统！" + "\r\n";
                                                //更新借出单上传标志
                                                RetailCommom.SetUploadFlag(dt.Rows[i]["MainId"].ToString(), "RM");
                                            }
                                            else
                                            {
                                                //MessageBox.Show("借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】上传到零售系统失败，请稍后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                AlterMsg += "借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】上传零售系统失败，请稍后再试！" + "\r\n";
                                                continue;
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            selCmd = "select fchrSelectionString from sl_VipCardDueConfig where fchrType='RmService'";
                                            objSelStr = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd);

                                            if (!RetailCommom.CheckNetIsConnected(objSelStr.ToString().Split('/')[2].Split(':')[0].ToString()))
                                            {
                                                AlterMsg += "借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】上传零售系统失败，原因：与总部服务器连接失败，请检查网络连接是否正常！" + "\r\n";
                                                //RetailMessageBox.ShowInformation("与总部服务器连接失败，请检查网络连接是否正常！");
                                                break;
                                            }

                                            if (Convert.IsDBNull(objSelStr) || string.IsNullOrEmpty(Convert.ToString(objSelStr)))
                                            {
                                                //RetailMessageBox.ShowInformation("RMWebServiceURL不存在,请先日常下载!");
                                                AlterMsg += "借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】上传零售系统失败，原因：RMWebServiceURL不存在,请先日常下载!" + "\r\n";
                                                continue;
                                            }

                                            url = Convert.ToString(objSelStr);

                                            try
                                            {
                                                object[] args = { dt.Rows[i]["MainId"].ToString(), DsRdVouch };
                                                //上传RM操作
                                                bFlag = Convert.ToBoolean(Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "sl_ZT_DataExchangeFromPosToRM", args));
                                                if (bFlag)
                                                {
                                                    //MessageBox.Show("借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】已成功上传到零售系统！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    AlterMsg += "借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】已成功上传到零售系统！" + "\r\n";
                                                    //更新借出单上传标志
                                                    RetailCommom.SetUploadFlag(dt.Rows[i]["MainId"].ToString(), "RM");
                                                }
                                                else
                                                {
                                                    AlterMsg += "借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】上传零售系统失败，请稍后再试！" + "\r\n";
                                                    //MessageBox.Show("借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】上传到零售系统失败，请稍后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    continue;
                                                }
                                            }
                                            catch
                                            {
                                                //RetailMessageBox.ShowInformation("远程服务器无法连接,请检查网络!");
                                                AlterMsg += "借出单【" + dt.Rows[i]["fchrCode"].ToString() + "】上传零售系统失败，原因：远程服务器无法连接,请检查网络!" + "\r\n";
                                                continue;
                                            }
                                        }
                                    }
                                }

                                if (pthred != null)
                                {
                                    pthred.Abort();
                                    pthred = null;
                                }
                                GC.Collect();
                            }
                            catch (Exception ex)
                            {
                                pthred.Abort();
                                pthred = null;
                                GC.Collect();
                                RetailMessageBox.ShowInformation(ex.Message);
                            }
                            //finally
                            //{
                            //    if (pthred != null)
                            //    {
                            //        pthred.Abort();
                            //        pthred = null;
                            //    }
                            //    GC.Collect();
                            //}

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

        private void tsbUploadToU8_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1)
            {
                string ErrMsg = string.Empty;
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                DataTable dtMain = new DataTable();
                DataTable dtDetail = new DataTable();
                int RowCount = 0;
                string AlterMsg = string.Empty;
                AlterMsg = "";
                //AssamblyWLWeb.Service ser = new AssamblyWLWeb.Service();
                WebTest.Service ser = new UFIDA.Retail.VIPCardControl.WebTest.Service();
                string sql = string.Format(@"select MainId,fchrCode from sl_t_RdVouchMain where fchrVouchType = 'GH' and isnull(fbitTransferToU8,0) = 0 and isnull(fbitTempSave,0) = 0");
                if (SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql).Tables.Count > 0)
                {
                    dt = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sql).Tables[0];
                    RowCount = dt.Rows.Count;
                    if (RowCount > 0)
                    {
                        if (MessageBox.Show(string.Format(@"存在【{0}】张未上传至U8系统的归还单，是否全部上传！", RowCount), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Threading.Thread pthred = new System.Threading.Thread(new System.Threading.ThreadStart(Lixtech.Common.CommonClass.ShowWaitForm));
                            pthred.Start();
                            try
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    ds = RetailCommom.GetDsDataToU8(dt.Rows[i]["MainId"].ToString());
                                    if (ds != null)
                                    {
                                        byte[] DsBytes = sl_RetailCommom.Serialize(ds, ref ErrMsg);
                                        //ser.RMGenOtherInVouch(DsBytes, ref ErrMsg)
                                        if (ser.GenU8VoucherFromRM(DsBytes, "08", ref ErrMsg))
                                        {
                                            RetailCommom.SetUploadFlag(dt.Rows[i]["MainId"].ToString(), "U8");
                                        }
                                        else
                                        {
                                            if (!string.IsNullOrEmpty(ErrMsg))
                                            {
                                                AlterMsg += "归还单【" + dt.Rows[i]["fchrCode"].ToString() + "】生成U8【其他入库单】失败！" + "\r\n" + ErrMsg + "\r\n";
                                                //RetailMessageBox.ShowInformation("【其他入库单】生成失败，原因：" + ErrMsg);
                                                continue;
                                            }
                                        }
                                    }
                                }

                                if (pthred != null)
                                {
                                    pthred.Abort();
                                    pthred = null;
                                }
                                GC.Collect();
                            }
                            catch (Exception ex)
                            {
                                pthred.Abort();
                                pthred = null;
                                GC.Collect();
                                RetailMessageBox.ShowInformation(ex.Message);
                            }
                            //finally
                            //{
                            //    if (pthred != null)
                            //    {
                            //        pthred.Abort();
                            //        pthred = null;
                            //    }
                            //    GC.Collect();
                            //}

                            if (!string.IsNullOrEmpty(AlterMsg))
                            {
                                RetailMessageBox.ShowInformation(AlterMsg);
                                tsbRefresh_Click(sender, e);
                            }
                        }
                    }
                }
                else
                    return;
            }
            else
            {
                RetailMessageBox.ShowInformation("请先刷新列表再进行上传！");
                return;
            }
        }
    }
}
