using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UFIDA.Retail.Common;
using UFIDA.Retail.Utility;
using Lixtech.Common;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmVIPConsumerPromotion : Form
    {
        public frmVIPConsumerPromotion()
        {
            InitializeComponent();
        }

        sl_RetailCommom RetailCommom = new sl_RetailCommom();

        private DataTable dtSource;

        public DataTable DtSource
        {
            get { return dtSource; }
            set { dtSource = value; }
        }

        private string GetRealtion
        {
            get
            {
                string relation = string.Empty;

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

                //VIP卡号
                if (!string.IsNullOrEmpty(Convert.ToString(txtVIPCardCode.txtText.Trim())))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("fnarvipcardcode like '%{0}%'", txtVIPCardCode.txtText.Trim());
                }

                //当前客户级别
                if (txtVIPCardClass.txtTag != null)
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("fchrVIPCardClassID = '{0}'", txtVIPCardClass.txtTag.ToString());
                }

                //可晋升级别
                if (txtProCardClass.txtTag != null)
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("S01_VIPPromoteClassID = '{0}'", txtProCardClass.txtTag.ToString());
                }

                //归属门店
                if (!string.IsNullOrEmpty(Convert.ToString(txtStoreName.txtText.Trim())))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("fchrStoreName like '%{0}%'", txtStoreName.txtText.Trim());
                }
                return relation;
            }
        }

        /// <summary>
        /// VIP卡可晋升级别参照
        /// </summary>
        private void VIPProCardClassRef()
        {
            string sql = @"select fchrVIPCardClassCode,fchrVIPCardClassName from VIPCardClass";
            string sqlheader = "VIP卡级别编码,VIP卡级别名称";
            string relation = string.Empty;
            if (!string.IsNullOrEmpty(txtProCardClass.txtText))
            {
                if (txtProCardClass.txtText.Contains(","))
                {
                    relation = string.Format("fchrVIPCardClassCode in ('{0}')", txtProCardClass.txtText.Replace(",", "','"));
                }
                else
                    relation = string.Format("(fchrVIPCardClassCode like '%{0}%' or fchrVIPCardClassName like '%{0}%')", txtProCardClass.txtText);
            }

            if (txtProCardClass.txtTag != null)
            {
                if (!string.IsNullOrEmpty(relation)) relation += " and ";
                relation += string.Format(" fchrVIPCardClassID = '{0}'", txtProCardClass.txtTag.ToString());
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

                txtProCardClass.txtTag = sl_RetailCommom.GetValues("fchrVIPCardClassID", "VIPCardClass", "fchrVIPCardClassCode", mm.Txt.Tag.ToString());
                txtProCardClass.txtText = mm.Txt.Text.Trim();
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

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            string relation = GetRealtion;
            string ParamValue = Tools.GetStringSysPara("fchrVIPView"); //VIP晋级控制
            DataTable dt = new DataTable();
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
                obj = Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "GetVIPProList", args);
                dt = obj as DataTable;
                if (dt.Rows.Count > 0)
                {
                    RefreshData(dt);
                }
                else
                {
                    RetailMessageBox.ShowInformation("没有可晋级的VIP客户！");
                    ClearGrid(flexMain);
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
                    obj = Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "GetVIPProList", args);
                    dt = obj as DataTable;
                    if (dt.Rows.Count > 0)
                    {
                        RefreshData(dt);
                    }
                    else
                    {
                        RetailMessageBox.ShowInformation("没有可晋级的VIP客户！");
                        ClearGrid(flexMain);
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

        /// <summary>
        /// 刷新列表数据
        /// </summary>
        /// <param name="dt"></param>
        private void RefreshData(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                dtSource = dt.Copy();
                //清除所有行数据
                ClearGrid(flexMain);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    flexMain.Rows.Add();
                    flexMain.Rows[flexMain.Rows.Count - 1]["fchrvipconsumerid"] = dt.Rows[i]["fchrvipconsumerid"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["fchrConsumerCode"] = dt.Rows[i]["fnarconsumercode"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["fchrConsumerName"] = dt.Rows[i]["fnarconsumername"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["fchrOldCardCode"] = dt.Rows[i]["fnarvipcardcode"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["fchrOldCardClass"] = dt.Rows[i]["fchrCardName"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["S01_VIPPromoteClassID"] = dt.Rows[i]["S01_VIPPromoteClassID"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["fchrProCardClass"] = dt.Rows[i]["S01_VIPPromoteClass"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["flotProPoint"] = dt.Rows[i]["S01_CsmPromotePoints"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["flotRemainPoint"] = dt.Rows[i]["fintRemainPoint"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["flotTotalConsume"] = dt.Rows[i]["flotTotalConsume"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["flotRealMoney"] = dt.Rows[i]["flotRealMoney"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["flotMaxMoney"] = dt.Rows[i]["flotMaxMoney"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["flotMaxRealMoney"] = dt.Rows[i]["flotMaxRealMoney"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["flotOneYearPoint"] = dt.Rows[i]["fintoneyearpoints"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["flotTwoYearPoint"] = dt.Rows[i]["finttwoyearpoints"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["fintConsumeDays"] = dt.Rows[i]["fintLastConsumerDays"].ToString();
                    flexMain.Rows[flexMain.Rows.Count - 1]["fchrStoreName"] = dt.Rows[i]["fchrStoreName"].ToString();
                }
            }
        }

        private void tsbPromote_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            if (flexMain.Rows.Count > 0)
            {
                if (flexMain.RowSel > 0)
                {
                    //dt = flexMain.DataSource as DataTable;
                    dt = dtSource.Copy();
                    dr = dt.Select(string.Format(@"fchrvipconsumerid = '{0}' and S01_VIPPromoteClassID = '{1}'", flexMain.Rows[flexMain.RowSel]["fchrvipconsumerid"].ToString(), flexMain.Rows[flexMain.RowSel]["S01_VIPPromoteClassID"].ToString()))[0];
                    frmPromotionForm proForm = new frmPromotionForm(dr);
                    proForm.ShowDialog();
                }
                else
                {
                    RetailMessageBox.ShowInformation("请先选择要晋级的数据行！");
                    return;
                }
            }
        }

        /// <summary>
        /// 清除列表中的所有行
        /// </summary>
        /// <param name="flex"></param>
        private void ClearGrid(C1.Win.C1FlexGrid.C1FlexGrid flex)
        {
            //int i = 0;
            //if (flex.Rows.Count > 1)
            //{
            //    i = flex.Rows.Count - 1;
            //    while (i > 0)
            //    {
            //        flex.Rows.Remove(i);
            //        i -= 1;
            //    }
            //}
            flex.Rows.RemoveRange(1, flex.Rows.Count - 1);
        }

        private void frmVIPConsumerPromotion_Load(object sender, EventArgs e)
        {

        }

        private void txtVIPCardClass_Button_Click(object sender, EventArgs e)
        {
            VIPCardClassRef();
        }

        private void txtProCardClass_Button_Click(object sender, EventArgs e)
        {
            VIPProCardClassRef();
        }

        private void txtVIPCardClass_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtVIPCardClass_Button_Click(null, null);
            }
        }

        private void txtProCardClass_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtProCardClass_Button_Click(null, null);
            }
        }
    }
}
