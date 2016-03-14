using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using UFIDA.Retail.DataAccess;
using UFIDA.Retail.Common;
using UFIDA.Retail.Utility;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmVipInfoApllyDetail : Form
    {
        public frmVipInfoApllyDetail()
        {
            InitializeComponent();
        }
        #region---------------属性,字段
        private string s01_fchrApplyID = "";
        public string S01_fchrApplyID
        {
            set { s01_fchrApplyID = value; }
            get { return s01_fchrApplyID; }
        }
        private bool isAddConsumer = false;
        public bool IsAddConsumer
        {
            set { isAddConsumer = value; }
            get { return isAddConsumer; }
        }
        private DataRow drDetailData = null;
        public DataRow DrDetailData
        {
            set { drDetailData = value; }
            get { return drDetailData; }
        }
        private string s01_fchrStoreID = "";
        public string S01_fchrStoreID
        {
            set { s01_fchrStoreID = value; }
            get { return s01_fchrStoreID; }
        }

        private string s01_fchrApplicant = "";
        public string S01_fchrApplicant
        {
            set { s01_fchrApplicant = value; }
            get { return s01_fchrApplicant; }
        }
        private string S01_fchrReceiptNO = "";
        private string S01_fdtmDate = "";
        private string S01_fintApplyTypeNO = "";
        private string S01_fchrDepartmentID = "";
        private string S01_fchrVerifier = "";
        #endregion

        private void frmVipInfoApllyDetail_Load(object sender, EventArgs e)
        {
            LoadControl();
            SetData();

        }

        #region---------------------业务逻辑
        private void LoadControl()
        {
            StringBuilder S01_fchrReceiptNO = new StringBuilder();
            S01_fchrReceiptNO.AppendFormat(@"<ValueControl Assembly='1' ControlType='1' Name='S01_fchrReceiptNO' Caption='单据编号' ControlValue='{0}' ><InitParams TextMaxLength='30' /></ValueControl>", isAddConsumer ? "新开单据" : drDetailData["S01_fchrReceiptNO"].ToString());
            ucContainer.AddControl(GetConfigNode(S01_fchrReceiptNO.ToString()));

            StringBuilder S01_fdtmDate = new StringBuilder();
            S01_fdtmDate.AppendFormat(@"<ValueControl Assembly='1' ControlType='1' Name='S01_fdtmDate' Caption='单据日期' Format='D' ControlValue='{0}' ><InitParams TextMaxLength='30' /></ValueControl>", isAddConsumer ? DateTime.Now.ToString("yyyy-MM-dd") : ((DateTime)drDetailData["S01_fdtmDate"]).ToString("yyyy-MM-dd"));
            ucContainer.AddControl(GetConfigNode(S01_fdtmDate.ToString()));

            StringBuilder VIPInfoApplyTypeName = new StringBuilder();
            VIPInfoApplyTypeName.AppendFormat(@"<ValueControl Assembly='1' ControlType='5' Name='VIPInfoApplyTypeName' Caption='申请类型' ControlValue='{0}' RefName='{0}' RefID='{1}'>", isAddConsumer ? "" : drDetailData["VIPInfoApplyTypeName"].ToString(), isAddConsumer ? "" : drDetailData["S01_fintApplyTypeNO"].ToString());
            VIPInfoApplyTypeName.Append(@"<InitParams Value='查询模板' TextMaxLen='50' ><AutoTrim Value='False'/><Template Value='ref_ApplyType' Returntype='ID' /><PageNumber Value='15'/></InitParams></ValueControl>");
            ucContainer.AddControl(GetConfigNode(VIPInfoApplyTypeName.ToString()));

            StringBuilder fchrDepartmentName = new StringBuilder();
            fchrDepartmentName.AppendFormat(@"<ValueControl Assembly='1' ControlType='5' Name='fchrDepartmentName' Caption='上级部门' ControlValue='{0}' RefName='{0}' RefID='{1}'>", isAddConsumer ? "" : drDetailData["fchrDepartmentName"].ToString(), isAddConsumer ? "" : drDetailData["S01_fchrDepartmentID"].ToString());
            fchrDepartmentName.Append(@"<InitParams Value='查询模板' TextMaxLen='50' ><AutoTrim Value='False'/><Template Value='Ref_Department' Returntype='ID' /><PageNumber Value='15'/></InitParams></ValueControl>");
            ucContainer.AddControl(GetConfigNode(fchrDepartmentName.ToString()));

            StringBuilder S01_fchrVerifier = new StringBuilder();
            S01_fchrVerifier.AppendFormat(@"<ValueControl Assembly='1' ControlType='4' Name='S01_fchrVerifier' Caption='审核人' ControlValue='{0}' ><InitParams TextMaxLength='30' /></ValueControl>", isAddConsumer ? "" : drDetailData["S01_fchrVerifier"].ToString());
            ucContainer.AddControl(GetConfigNode(S01_fchrVerifier.ToString()));


        }

        private void SetData()
        {
            if (drDetailData != null)
            {
                rTxtRemark.Text = drDetailData["S01_fchrMemo"].ToString();
                this.s01_fchrApplyID = drDetailData["s01_fchrApplyID"].ToString();
            }
        }

        private bool UpdateData()
        {
            bool result = true;
            if (CollectData())
            {
                VIPDoWithEx vipDoWithEx = new VIPDoWithEx();
                if (vipDoWithEx.CheckExport(this.s01_fchrApplyID))
                {
                    RetailMessageBox.ShowInformation("单据已上传，不能修改");
                    return false;
                }
                StringBuilder updateSql = new StringBuilder();
                updateSql.Append("update S01_VIPInfoModify set ");
                updateSql.AppendFormat("S01_fintApplyTypeNO='{0}',S01_fchrDepartmentID=case when '{1}'<>'' then '{1}' else NULL end,S01_fchrVerifier='{2}',S01_fchrMemo='{3}' where S01_fchrApplyID='{4}'",
                    new object[] { this.S01_fintApplyTypeNO, this.S01_fchrDepartmentID, this.S01_fchrVerifier, this.rTxtRemark.Text.Trim().Replace("'", "''"), this.s01_fchrApplyID });
                int count = 0;
                count = SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, updateSql.ToString());
                if (count > 0)
                {
                    RetailMessageBox.ShowInformation("保存成功");
                }
                else
                {
                    RetailMessageBox.ShowInformation("保存失败");
                    return false;
                }
            }
            else
            {
                return false;
            }
            return result;
        }

        private bool InsertData()
        {
            bool result = true;
            if (CollectData())
            {
                this.s01_fchrApplyID = Guid.NewGuid().ToString();
                StringBuilder updateSql = new StringBuilder();
                updateSql.Append("insert into S01_VIPInfoModify( S01_fchrApplyID, S01_fchrReceiptNO, S01_fintApplyTypeNO, S01_fchrDepartmentID, S01_fchrVerifier, S01_fchrStoreID, S01_fchrApplicant, S01_fdtmDate, S01_fchrMemo) ");
                updateSql.AppendFormat("values('{0}','{1}','{2}',case when '{3}'<>'' then '{3}' else NULL end,'{4}','{5}','{6}','{7}','{8}')",
                    new object[] { this.s01_fchrApplyID, this.S01_fchrReceiptNO, this.S01_fintApplyTypeNO, this.S01_fchrDepartmentID, this.S01_fchrVerifier, this.s01_fchrStoreID, this.s01_fchrApplicant, this.S01_fdtmDate, this.rTxtRemark.Text.Trim().Replace("'", "''") });
                int count = 0;
                count = SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, updateSql.ToString());
                if (count > 0)
                {
                    RetailMessageBox.ShowInformation("保存成功");
                }
                else
                {
                    RetailMessageBox.ShowInformation("保存失败");
                    return false;
                }
            }
            else
            {
                return false;
            }
            return result;
        }

        private bool CollectData()
        {
            bool result = true;
            string dataValue = "";
            string columnName = "";
            foreach (Control ctl in ucContainer.Controls[0].Controls)
            {
                columnName = ctl.Name;
                dataValue = ucContainer.GetControlValue(ctl.Name).Trim();
                switch (columnName)
                {
                    case "S01_fchrReceiptNO":
                        if (dataValue != "新开单据")
                            this.S01_fchrReceiptNO = dataValue;
                        else
                        {
                            string erroStr = "";
                            this.S01_fchrReceiptNO = ReceiptNoRule.SetNewReceiptNo("VIP客户信息变更申请单", DateTime.Now, ref erroStr);
                        }
                        break;
                    case "S01_fdtmDate":
                        if (dataValue != "")
                            this.S01_fdtmDate = dataValue;
                        else
                            this.S01_fdtmDate = DateTime.Now.ToString("yyyy-MM-dd");
                        break;
                    case "VIPInfoApplyTypeName":
                        if (dataValue != "")
                            this.S01_fintApplyTypeNO = dataValue;
                        else
                        {
                            RetailMessageBox.ShowWarning(this, "申请类型不能为空");
                            return false;
                        }
                        break;
                    case "fchrDepartmentName":
                        if (dataValue != "")
                            this.S01_fchrDepartmentID = dataValue;
                        break;
                    case "S01_fchrVerifier":
                        if (dataValue != "")
                            this.S01_fchrVerifier = dataValue;
                        else
                        {
                            RetailMessageBox.ShowWarning(this, "审核人不能为空");
                            return false;
                        }
                        break;
                }
            }
            if (this.rTxtRemark.Text.Trim() == "")
            {
                RetailMessageBox.ShowWarning(this, "申请内容不能为空");
                return false;
            }
            return result;
        }

        private XmlElement GetConfigNode(string configString)
        {
            XmlDocument configDocument = new XmlDocument();
            configDocument.LoadXml(configString);
            return configDocument.DocumentElement;
        }
        #endregion

        #region------------------------控件事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool UpdateDataSucsess = true;
            if (isAddConsumer)
            {
                UpdateDataSucsess = InsertData();
            }
            else
            {
                UpdateDataSucsess = UpdateData();
            }

            if (UpdateDataSucsess)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void rTxtRemark_Enter(object sender, EventArgs e)
        {
            this.rTxtRemark.BackColor = SystemColors.Window;
        }

        private void rTxtRemark_Leave(object sender, EventArgs e)
        {
            this.rTxtRemark.BackColor = SystemColors.Control;
        }

        #endregion
    }
}