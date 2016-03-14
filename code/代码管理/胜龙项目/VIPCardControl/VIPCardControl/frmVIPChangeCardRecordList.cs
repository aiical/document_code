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
using Lixtech.Common;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmVIPChangeCardRecordList : Form
    {
        public frmVIPChangeCardRecordList()
        {
            InitializeComponent();
        }

        private string GetRealtion
        {
            get
            {
                string relation = string.Empty;

                //换卡开始日期
                if (dtpBegin.Checked)
                {
                    relation += string.Format("Convert(varchar(10),S01_fdtmCardChangeTime,23) >= '{0}'", dtpBegin.Value.ToString("yyyy-MM-dd"));
                }

                //换卡结束日期
                if (dtpEnd.Checked)
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("Convert(varchar(10),S01_fdtmCardChangeTime,23) <= '{0}'", dtpEnd.Value.ToString("yyyy-MM-dd"));
                }

                //VIP客户编码
                if (!string.IsNullOrEmpty(Convert.ToString(txtConsumerCode.txtText.Trim())))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("fnarconsumercode like '%{0}%'", txtConsumerCode.txtText.Trim());
                }

                //VIP客户名称
                if (!string.IsNullOrEmpty(Convert.ToString(txtConsumerName.txtText.Trim())))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("fnarconsumername like '%{0}%'", txtConsumerName.txtText.Trim());
                }

                //VIP新卡卡号
                if (!string.IsNullOrEmpty(Convert.ToString(txtVIPNewCardCode.txtText.Trim())))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("fnarvipcardcode_new like '%{0}%'", txtVIPNewCardCode.txtText.Trim());
                }

                //VIP旧卡卡号
                if (!string.IsNullOrEmpty(Convert.ToString(txtVIPOldCardCode.txtText.Trim())))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("fnarvipcardcode_old like '%{0}%'", txtVIPOldCardCode.txtText.Trim());
                }

                //新卡级别
                if (txtVIPNewCardClass.txtTag != null)
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("fchrVIPCardClassID_new = '{0}'", txtVIPNewCardClass.txtTag.ToString());
                }

                //旧卡级别
                if (txtVIPOldCardClass.txtTag != null)
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("fchrVIPCardClassID_old = '{0}'", txtVIPOldCardClass.txtTag.ToString());
                }

                //是否审核
                if (chkIsAudit.Checked)
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("isnull(fbitVerify,0) = 1");
                }
                return relation;
            }
        }

        private void frmVIPChangeCardRecordList_Load(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            dtpBegin.Value = datetime.AddDays(1 - datetime.Day);
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshData()
        {
            sl_RetailCommom RetailCommom = new sl_RetailCommom();
            DataTable dt = new DataTable();
            string relation = GetRealtion;
            string ParamValue = Tools.GetStringSysPara("fchrVIPView"); //VIP晋级控制
            string selCmd = "select fchrSelectionString from sl_VipCardDueConfig where fchrType='RmWebService'";
            object objSelStr = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd);

            if (!RetailCommom.CheckNetIsConnected(objSelStr.ToString().Split('/')[2].Split(':')[0].ToString()))
            {
                //RetailMessageBox.ShowInformation("与总部服务器连接失败，请检查网络连接是否正常！");
                return;
            }

            selCmd = "select top 1 fchrStoreDefineID from storedefine";
            string fchrStoreDefineID = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd).ToString();
            if (Convert.IsDBNull(objSelStr) || string.IsNullOrEmpty(Convert.ToString(objSelStr)))
            {
                RetailMessageBox.ShowInformation("RMWebServiceURL不存在,请先日常下载!");
                return;
            }
            string url = Convert.ToString(objSelStr);
            object obj = null;
            string Err = "";
            try
            {
                object[] args = { fchrStoreDefineID, ParamValue, relation };
                obj = Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "GetVIPCardChangeRecords", args);
                dt = obj as DataTable;
                if (dt.Rows.Count > 0)
                {
                    dgv.DataSource = dt;
                    dgv.AutoSizeCols();
                }
                else
                {
                    RetailMessageBox.ShowInformation("没有查询到任何数据！");
                    if (dgv.Rows.Count > 1)
                    {
                        for (int i = dgv.Rows.Count - 1; i > 0; i--)
                        {
                            dgv.Rows.Remove(i);
                        }
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                selCmd = "select fchrSelectionString from sl_VipCardDueConfig where fchrType='RmService'";
                objSelStr = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd);

                if (!RetailCommom.CheckNetIsConnected(objSelStr.ToString().Split('/')[2].Split(':')[0].ToString()))
                {
                    //RetailMessageBox.ShowInformation("与总部服务器连接失败，请检查网络连接是否正常！");
                    return;
                }

                selCmd = "select top 1 fchrStoreDefineID from storedefine";
                fchrStoreDefineID = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd).ToString();

                if (Convert.IsDBNull(objSelStr) || string.IsNullOrEmpty(Convert.ToString(objSelStr)))
                {
                    RetailMessageBox.ShowInformation("RMWebServiceURL不存在,请先日常下载!");
                    return;
                }
                url = Convert.ToString(objSelStr);

                try
                {
                    object[] args = { fchrStoreDefineID, ParamValue, relation };
                    obj = Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "GetVIPCardChangeRecords", args);
                    dt = obj as DataTable;
                    if (dt.Rows.Count > 0)
                    {
                        dgv.DataSource = dt;
                        dgv.AutoSizeCols();
                    }
                    else
                    {
                        RetailMessageBox.ShowInformation("没有查询到任何数据！");
                        if (dgv.Rows.Count > 1)
                        {
                            for (int i = dgv.Rows.Count - 1; i > 0; i--)
                            {
                                dgv.Rows.Remove(i);
                            }
                        }
                        return;
                    }
                }
                catch (Exception exc)
                {
                    RetailMessageBox.ShowInformation("远程服务器无法连接,请检查网络!");
                    return;
                }
            }
        }

        private void txtVIPNewCardClass_Button_Click(object sender, EventArgs e)
        {
            VIPNewCardClassRef();
        }

        private void txtVIPOldCardClass_Button_Click(object sender, EventArgs e)
        {
            VIPOldCardClassRef();
        }

        private void txtVIPNewCardClass_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtVIPOldCardClass_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        /// <summary>
        /// VIP卡新卡级别参照
        /// </summary>
        private void VIPNewCardClassRef()
        {
            string sql = @"select fchrVIPCardClassCode,fchrVIPCardClassName from VIPCardClass";
            string sqlheader = "VIP卡级别编码,VIP卡级别名称";
            string relation = string.Empty;
            if (!string.IsNullOrEmpty(txtVIPNewCardClass.txtText))
            {
                if (txtVIPNewCardClass.txtText.Contains(","))
                {
                    relation = string.Format("fchrVIPCardClassCode in ('{0}')", txtVIPNewCardClass.txtText.Replace(",", "','"));
                }
                else
                    relation = string.Format("(fchrVIPCardClassCode like '%{0}%' or fchrVIPCardClassName like '%{0}%')", txtVIPNewCardClass.txtText);
            }

            if (txtVIPNewCardClass.txtTag != null)
            {
                if (!string.IsNullOrEmpty(relation)) relation += " and ";
                relation += string.Format(" fchrVIPCardClassID = '{0}'", txtVIPNewCardClass.txtTag.ToString());
            }

            frmConsult mm = new frmConsult(sql, sqlheader, "fchrVIPCardClassCode", "fchrVIPCardClassName", "VIP卡级别参照", relation, false, false, SysPara.ConnectionString, " Order by fchrVIPCardClassCode");
            if (mm.ShowDialog() == DialogResult.OK)
            {
                //string str = string.Empty;
                //foreach (string s in mm.RefText)
                //{
                //    str += s + ",";
                //}
                //if (!string.IsNullOrEmpty(str))
                //    this.txtProCardClass.txtText = str.Substring(0, str.Length - 1);
                //str = string.Empty;
                //foreach (string s in mm.RefValue)
                //{
                //    //str += s + ",";
                //    str += sl_RetailCommom.GetValues("fchrVIPCardClassID", "VIPCardClass", "fchrVIPCardClassCode", s) + ",";
                //}
                //if (!string.IsNullOrEmpty(str))
                //    txtProCardClass.txtTag = str.Substring(0, str.Length - 1);

                txtVIPNewCardClass.txtTag = sl_RetailCommom.GetValues("fchrVIPCardClassID", "VIPCardClass", "fchrVIPCardClassCode", mm.Txt.Tag.ToString());
                txtVIPNewCardClass.txtText = mm.Txt.Text.Trim();
            }
        }

        /// <summary>
        /// VIP卡旧卡级别参照
        /// </summary>
        private void VIPOldCardClassRef()
        {
            string sql = @"select fchrVIPCardClassCode,fchrVIPCardClassName from VIPCardClass";
            string sqlheader = "VIP卡级别编码,VIP卡级别名称";
            string relation = string.Empty;
            if (!string.IsNullOrEmpty(txtVIPOldCardClass.txtText))
            {
                if (txtVIPOldCardClass.txtText.Contains(","))
                {
                    relation = string.Format("fchrVIPCardClassCode in ('{0}')", txtVIPOldCardClass.txtText.Replace(",", "','"));
                }
                else
                    relation = string.Format("(fchrVIPCardClassCode like '%{0}%' or fchrVIPCardClassName like '%{0}%')", txtVIPOldCardClass.txtText);
            }

            if (txtVIPOldCardClass.txtTag != null)
            {
                if (!string.IsNullOrEmpty(relation)) relation += " and ";
                relation += string.Format(" fchrVIPCardClassID = '{0}'", txtVIPOldCardClass.txtTag.ToString());
            }

            frmConsult mm = new frmConsult(sql, sqlheader, "fchrVIPCardClassCode", "fchrVIPCardClassName", "VIP卡级别参照", relation, false, false, SysPara.ConnectionString, " Order by fchrVIPCardClassCode");
            if (mm.ShowDialog() == DialogResult.OK)
            {
                //string str = string.Empty;
                //foreach (string s in mm.RefText)
                //{
                //    str += s + ",";
                //}
                //if (!string.IsNullOrEmpty(str))
                //    this.txtProCardClass.txtText = str.Substring(0, str.Length - 1);
                //str = string.Empty;
                //foreach (string s in mm.RefValue)
                //{
                //    //str += s + ",";
                //    str += sl_RetailCommom.GetValues("fchrVIPCardClassID", "VIPCardClass", "fchrVIPCardClassCode", s) + ",";
                //}
                //if (!string.IsNullOrEmpty(str))
                //    txtProCardClass.txtTag = str.Substring(0, str.Length - 1);

                txtVIPOldCardClass.txtTag = sl_RetailCommom.GetValues("fchrVIPCardClassID", "VIPCardClass", "fchrVIPCardClassCode", mm.Txt.Tag.ToString());
                txtVIPOldCardClass.txtText = mm.Txt.Text.Trim();
            }
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
                        if (export.FlexToExcel(dgv, ExcelFilePath, "VIP客户换卡记录" + DateTime.Now.ToString("yyyy-MM-dd")))
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
    }
}
