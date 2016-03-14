using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UFIDA.Retail.Common;
using System.Data.SqlClient;
using UFIDA.Retail.Utility;
using Lixtech.Common;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmNoUsedVIPConsumerList : Form
    {
        public frmNoUsedVIPConsumerList()
        {
            InitializeComponent();
        }

        private string GetRealtion
        {
            get
            {
                string relation = string.Empty;

                //失效日期开始
                if (dtpBegin.Checked)
                {
                    relation += string.Format("Convert(varchar(10),vcct.fdtmEndDate,23) >= '{0}'", dtpBegin.Value.ToString("yyyy-MM-dd"));
                }

                //失效日期结束
                if (dtpEnd.Checked)
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("Convert(varchar(10),vcct.fdtmEndDate,23) <= '{0}'", dtpEnd.Value.ToString("yyyy-MM-dd"));
                }

                //VIP客户编码
                if (!string.IsNullOrEmpty(Convert.ToString(txtConsumerCode.txtText.Trim())))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("VipConsumer.fnarconsumercode like '%{0}%'", txtConsumerCode.txtText.Trim());
                }

                //VIP客户名称
                if (!string.IsNullOrEmpty(Convert.ToString(txtConsumerName.txtText.Trim())))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("VipConsumer.fnarconsumername like '%{0}%'", txtConsumerName.txtText.Trim());
                }

                //VIP卡号
                if (!string.IsNullOrEmpty(Convert.ToString(txtVIPCardCode.txtText.Trim())))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("fchrVIPCode like '%{0}%'", txtVIPCardCode.txtText.Trim());
                }

                //VIP卡级别
                if (txtVIPCardClass.txtTag != null)
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("S01_fchrVIPCardClassID = '{0}'", txtVIPCardClass.txtTag.ToString());
                }

                return relation;
            }
        }

        private void frmNoUsedVIPConsumerList_Load(object sender, EventArgs e)
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
            DataTable dt = new DataTable();
            SqlParameter[] param = { 
                                     new SqlParameter("@FilterString",GetRealtion)
                                   };

            dt = SqlAccess.ExecuteDataset(SysPara.ConnectionString, "sl_proc_GetNoUsedVIPList", param).Tables[0];

            if (dt.Rows.Count > 0)
            {
                dgv.DataSource = dt;
                dgv.AutoSizeCols();
            }
            else
            {
                MessageBox.Show("未查询到任何记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        /// <summary>
        /// VIP卡级别参照
        /// </summary>
        private void VIPCardClassRef()
        {
            string sql = @"select fchrVIPCardClassCode,fchrVIPCardClassName from VIPCardClass";
            string sqlheader = "VIP卡级别编码,VIP卡级别名称";
            string relation = string.Empty;
            if (!string.IsNullOrEmpty(txtVIPCardClass.txtText))
            {
                if (txtVIPCardClass.txtText.Contains(","))
                {
                    relation = string.Format("fchrVIPCardClassCode in ('{0}')", txtVIPCardClass.txtText.Replace(",", "','"));
                }
                else
                    relation = string.Format("(fchrVIPCardClassCode like '%{0}%' or fchrVIPCardClassName like '%{0}%')", txtVIPCardClass.txtText);
            }

            if (txtVIPCardClass.txtTag != null)
            {
                if (!string.IsNullOrEmpty(relation)) relation += " and ";
                relation += string.Format(" fchrVIPCardClassID = '{0}'", txtVIPCardClass.txtTag.ToString());
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

                txtVIPCardClass.txtTag = sl_RetailCommom.GetValues("fchrVIPCardClassID", "VIPCardClass", "fchrVIPCardClassCode", mm.Txt.Tag.ToString());
                txtVIPCardClass.txtText = mm.Txt.Text.Trim();
            }
        }

        private void txtVIPCardClass_Button_Click(object sender, EventArgs e)
        {
            VIPCardClassRef();
        }

        private void txtVIPCardClass_TextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                        if (export.FlexToExcel(dgv, ExcelFilePath, "已失效VIP客户列表" + DateTime.Now.ToString("yyyy-MM-dd")))
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
