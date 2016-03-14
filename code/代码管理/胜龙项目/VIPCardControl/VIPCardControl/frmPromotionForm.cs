using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UFIDA.Retail.Utility;
using UFIDA.Retail.Common;
using Lixtech.Common;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmPromotionForm : Form
    {
        private DataRow _dr;

        public DataRow Dr
        {
            get { return _dr; }
            set { _dr = value; }
        }

        public frmPromotionForm(DataRow dr)
        {
            _dr = dr;
            InitializeComponent();
        }

        sl_RetailCommom RetailCommom = new sl_RetailCommom();

        private void frmPromotionForm_Load(object sender, EventArgs e)
        {
            if (_dr != null)
            {
                txtConsumerCode.txtText = _dr["fnarconsumercode"].ToString();
                txtConsumerName.txtText = _dr["fnarconsumername"].ToString();
                txtOldCardCode.txtText = _dr["fnarvipcardcode"].ToString();
                txtOldCardClass.txtText = _dr["fchrCardName"].ToString();
                txtProCardClass.txtText = _dr["S01_VIPPromoteClass"].ToString();
                txtProPoint.txtText = _dr["S01_CsmPromotePoints"].ToString();
                txtRemainPoint.txtText = _dr["fintTotal"].ToString();
                txtMaxMoney.txtText = _dr["flotMaxMoney"].ToString();
                txtOneYearPoint.txtText = _dr["fintoneyearpoints"].ToString();
                txtTwoYearPoint.txtText = _dr["finttwoyearpoints"].ToString();
                txtConsumeDays.txtText = _dr["fintLastConsumerDays"].ToString();
                txtStoreName.txtText = _dr["fchrStoreName"].ToString();
                txtProCardClass.txtTag = _dr["S01_VIPPromoteClassID"].ToString();
            }
        }

        private void btnPromote_Click(object sender, EventArgs e)
        {
            string ErrMsg = "";
            string ConsumerID = string.Empty;
            string Old_CardID = string.Empty;
            string New_CardID = string.Empty;
            string OrgName = string.Empty;
            string Old_CardClassID = string.Empty;
            string New_CardClassID = string.Empty;
            string New_CardCode = string.Empty;
            string Old_CardCode = string.Empty;
            string fchrProStoreID = string.Empty;
            string fchrProEmployeeID = string.Empty;
            sl_RetailCommom Retail = new sl_RetailCommom();
            VIPCardInventoryManage cardManager = new VIPCardInventoryManage();

            //必须输字段晋级前处理
            if (string.IsNullOrEmpty(txtNewCardCode.txtText))
            {
                RetailMessageBox.ShowInformation("新VIP卡号不能为空，请重新选择新卡卡号！");
                return;
            }

            if (string.IsNullOrEmpty(txtProCardClass.txtText))
            {
                RetailMessageBox.ShowInformation("可晋升级别不能为空，请重新选择晋升级别！");
                return;
            }

            //判断该客户是否已上传并且已核对
            string strSQL = string.Format("select top 1 fbitExport,fbitCheck,fbitVerify_DQ from vipconsumer where fchrvipconsumerid = '{0}'", _dr["fchrvipconsumerid"].ToString());
            DataSet dsCheck = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, strSQL);
            if (dsCheck.Tables[0].Rows.Count > 0)
            {
                if ((!(bool)dsCheck.Tables[0].Rows[0]["fbitExport"] && dsCheck.Tables[0].Rows[0]["fbitVerify_DQ"].ToString() == "") || dsCheck.Tables[0].Rows[0]["fbitVerify_DQ"].ToString() == "0")
                {
                    RetailMessageBox.ShowExclamation("VIP客户资料未核对，不能继续晋级或换卡！");
                    return;
                }
            }

            ConsumerID = _dr["fchrvipconsumerid"].ToString();
            Old_CardID = _dr["fchrvipcardsid"].ToString();
            New_CardID = txtNewCardCode.txtTag.ToString();
            OrgName = SysPara.GetSysPara("操作员名称").ToString();
            Old_CardClassID = _dr["fchrVIPCardClassID"].ToString();
            New_CardClassID = !string.IsNullOrEmpty(txtProCardClass.txtTag.ToString()) ? txtProCardClass.txtTag.ToString() : _dr["S01_VIPPromoteClassID"].ToString();
            New_CardCode = txtNewCardCode.txtText.Trim();
            Old_CardCode = txtOldCardCode.txtText.Trim();
            fchrProStoreID = SysPara.Parameters["StoreId"].ToString();
            fchrProEmployeeID = SysPara.Parameters["OperatorID"].ToString().Replace("{", "").Replace("}", "");

            if (!Retail.CheckVIPCardInventoryAddMuti(New_CardCode, ConsumerID))
            {
                return;
            }

            string selCmd = "select fchrSelectionString from sl_VipCardDueConfig where fchrType='RmWebService'";
            object objSelStr = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, selCmd);

            if (!RetailCommom.CheckNetIsConnected(objSelStr.ToString().Split('/')[2].Split(':')[0].ToString()))
            {
                //RetailMessageBox.ShowInformation("与总部服务器连接失败，请检查网络连接是否正常！");
                return;
            }

            string url = Convert.ToString(objSelStr);
            object obj = null;
            string Err = "";
            try
            {
                object[] args = { ConsumerID, Old_CardID, New_CardID, OrgName, Old_CardClassID, New_CardClassID, fchrProStoreID, fchrProEmployeeID};
                //VIP卡晋级处理
                Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "VIPConsumerPromote", args);
                if (MessageBox.Show("VIP客户晋级成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {   
                    //判断指定级别的VIP卡是否有足够的库存进行扣减
                    if (Retail.CheckVIPCardsItemStocks(New_CardClassID))
                    {
                        try
                        {
                            //关联新VIP卡/处理旧VIP卡/处理对应的储值卡
                            Retail.SaveVipConsumerRelation(ConsumerID, New_CardClassID, New_CardCode, Old_CardCode, ref ErrMsg);
                            //新VIP卡扣减库存，新增零售单及收款单
                            cardManager.CreateDataVipCardInventory(New_CardCode, ConsumerID, 0);
                            if (string.IsNullOrEmpty(ErrMsg))
                            {
                                MessageBox.Show("VIP卡信息更新成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("VIP晋级出现异常：" + ErrMsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        catch (Exception exx) {
                            MessageBox.Show(exx.InnerException.Message);
                            return;
                        }
                    }
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

                if (Convert.IsDBNull(objSelStr) || string.IsNullOrEmpty(Convert.ToString(objSelStr)))
                {
                    RetailMessageBox.ShowInformation("RMWebServiceURL不存在,请先日常下载!");
                    return;
                }
                url = Convert.ToString(objSelStr);

                try
                {
                    object[] args = { ConsumerID, Old_CardID, New_CardID, OrgName, Old_CardClassID, New_CardClassID, fchrProStoreID, fchrProEmployeeID };
                    //VIP卡晋级处理
                    Lixtech.WebService.WebServiceHelper.InvokeWebService(url, "VIPConsumerPromote", args);
                    if (MessageBox.Show("VIP客户晋级成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        //判断指定级别的VIP卡是否有足够的库存进行扣减
                        if (Retail.CheckVIPCardsItemStocks(New_CardClassID))
                        {
                            try
                            {
                                //关联新VIP卡/处理旧VIP卡/处理对应的储值卡
                                Retail.SaveVipConsumerRelation(ConsumerID, New_CardClassID, New_CardCode, Old_CardCode, ref ErrMsg);
                                //新VIP卡扣减库存，新增零售单及收款单
                                cardManager.CreateDataVipCardInventory(New_CardCode, ConsumerID, 0);
                                if (string.IsNullOrEmpty(ErrMsg))
                                {
                                    MessageBox.Show("VIP卡信息更新成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("VIP晋级出现异常：" + ErrMsg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            catch (Exception exx)
                            {
                                MessageBox.Show(exx.InnerException.Message);
                                return;
                            }
                        }
                    }
                }
                catch
                {
                    RetailMessageBox.ShowInformation("远程服务器无法连接,请检查网络!");
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        /// <summary>
        /// VIP卡参照
        /// </summary>
        private void VIPCardsRef()
        {
            string sql = @"select fchrVipCode,fchrVIPCardClassName from dbo.VipCodeCollate vc
                           left join vipcardclass vcc on vc.S01_fchrVIPCardClassID = vcc.fchrVIPCardClassID
                           where fbitUse = 1 and isnull(fdtmStopDate,'') = '' and fchrvipconsumerid is null";
            string sqlheader = "VIP卡号,VIP卡级别";
            string relation = string.Empty;
            if (!string.IsNullOrEmpty(txtNewCardCode.txtText))
            {
                if (txtNewCardCode.txtText.Contains(","))
                {
                    relation = string.Format("fchrVipCode in ('{0}')", txtNewCardCode.txtText.Replace(",", "','"));
                }
                else
                    relation = string.Format("(fchrVipCode like '%{0}%')", txtNewCardCode.txtText);
            }

            if (txtProCardClass.txtTag != null)
            {
                if (!string.IsNullOrEmpty(relation)) relation += " and ";
                relation += string.Format(" S01_fchrVIPCardClassID = '{0}'", txtProCardClass.txtTag.ToString());
            }

            frmConsult mm = new frmConsult(sql, sqlheader, "fchrVipCode", "fchrVIPCardClassName", "VIP卡档案参照", relation, false, false, SysPara.ConnectionString, " Order by fchrVipCode");
            if (mm.ShowDialog() == DialogResult.OK)
            {
                //string str = string.Empty;
                //foreach (string s in mm.RefText)
                //{
                //    str += s + ",";
                //}
                //if (!string.IsNullOrEmpty(str))
                //    this.txtNewCardCode.txtText = str.Substring(0, str.Length - 1);
                //str = string.Empty;
                //foreach (string s in mm.RefValue)
                //{
                //    str += s + ",";
                //}
                //if (!string.IsNullOrEmpty(str))
                //    txtNewCardCode.txtTag = str.Substring(0, str.Length - 1);

                txtNewCardCode.txtTag = sl_RetailCommom.GetValues("vipcardsid", "VipCodeCollate", "fchrVIPCode", mm.Txt.Tag.ToString());
                txtNewCardCode.txtText = mm.Txt.Tag.ToString();
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
            if (!string.IsNullOrEmpty(txtProCardClass.txtText))
            {
                if (txtNewCardCode.txtText.Contains(","))
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

        private void txtNewCardCode_Button_Click(object sender, EventArgs e)
        {
            VIPCardsRef();
        }

        private void txtNewCardCode_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtNewCardCode_Button_Click(null, null);
            }
        }

        private void txtProCardClass_Button_Click(object sender, EventArgs e)
        {
            VIPCardClassRef();
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
