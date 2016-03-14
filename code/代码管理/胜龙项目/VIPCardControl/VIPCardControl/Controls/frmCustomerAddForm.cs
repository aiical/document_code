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
    public partial class frmCustomerAddForm : Form
    {
        public frmCustomerAddForm()
        {
            InitializeComponent();
        }


        private C1.Win.C1FlexGrid.C1FlexGrid _dgvSource;

        public C1.Win.C1FlexGrid.C1FlexGrid DgvSource
        {
            get { return _dgvSource; }
            set { _dgvSource = value; }
        }

        private string _CtrlType;

        public string CtrlType
        {
            get { return _CtrlType; }
            set { _CtrlType = value; }
        }

        public frmCustomerAddForm(C1.Win.C1FlexGrid.C1FlexGrid dgvSource,string ctrlType)
        {
            _dgvSource = dgvSource;
            _CtrlType = ctrlType;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConsumerCode.txtText))
            {
                RetailMessageBox.ShowInformation("客户编码不能为空，请重现输入！");
                return;
            }

            if (string.IsNullOrEmpty(txtConsumerName.txtText))
            {
                RetailMessageBox.ShowInformation("客户名称不能为空，请重现输入！");
                return;
            }

            if (string.IsNullOrEmpty(txtMobileNum.txtText))
            {
                RetailMessageBox.ShowInformation("手机号码不能为空，请重现输入！");
                return;
            }

            if (txtConsumerCode.txtText.Trim().Length < 8)
            {
                RetailMessageBox.ShowInformation("客户编码长度必须等于8位，请重现输入客户编码！");
                this.txtConsumerCode.Focus();
                return;
            }

            if (txtMobileNum.txtText.Trim().Length != 11)
            {
                RetailMessageBox.ShowInformation("手机号码长度必须等于11位，请重现输入手机号码！");
                this.txtMobileNum.Focus();
                return;
            }

            if (UpdateCusumerData())
            {
                RetailMessageBox.ShowInformation("展厅客户保存成功！");
                //_dgvSource.Rows.Add();
                //_dgvSource.Rows[_dgvSource.Rows.Count - 1]["客户编码"] = txtConsumerCode.txtText.Trim();
                //_dgvSource.Rows[_dgvSource.Rows.Count - 1]["客户名称"] = txtConsumerName.txtText.Trim();
                //_dgvSource.Rows[_dgvSource.Rows.Count - 1]["工作单位"] = txtWorkPlace.txtText.Trim();
                //_dgvSource.Rows[_dgvSource.Rows.Count - 1]["联系电话"] = txtMobileNum.txtText.Trim();
                //_dgvSource.Rows[_dgvSource.Rows.Count - 1]["联系地址"] = txtAddr.txtText.Trim();
                this.DialogResult = DialogResult.OK;
            }
            else
                return;
        }

        /// <summary>
        /// 检查当前所输入的新客户编码是否存在于系统中
        /// </summary>
        /// <param name="fchrZTCustomerCode"></param>
        /// <returns></returns>
        private bool CheckZTCustomerCodeIsExists(string fchrZTCustomerCode)
        { 
           string sql = string.Empty;
           bool bFlag = false;
           sql = string.Format(@"select Count(*) from sl_ZT_Customer where fchrCusCode = '{0}'", fchrZTCustomerCode);
           if (Convert.ToInt32(SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sql)) > 0)
           {
               bFlag = true;
           }

           return bFlag;
        }

        private void frmCustomerAddForm_Load(object sender, EventArgs e)
        {
            if (_CtrlType == "Modify")
            {
                this.Text = "展厅客户修改";
                txtConsumerCode.txtText = _dgvSource.Rows[_dgvSource.Row]["客户编码"] != null ? _dgvSource.Rows[_dgvSource.Row]["客户编码"].ToString() : "";
                txtConsumerName.txtText = _dgvSource.Rows[_dgvSource.Row]["客户名称"] != null ? _dgvSource.Rows[_dgvSource.Row]["客户名称"].ToString() : "";
                txtWorkPlace.txtText = _dgvSource.Rows[_dgvSource.Row]["工作单位"] != null ? _dgvSource.Rows[_dgvSource.Row]["工作单位"].ToString() : "";
                txtMobileNum.txtText = _dgvSource.Rows[_dgvSource.Row]["手机号码"] != null ? _dgvSource.Rows[_dgvSource.Row]["手机号码"].ToString() : "";
                txtPhoneNum.txtText = _dgvSource.Rows[_dgvSource.Row]["固定电话"] != null ? _dgvSource.Rows[_dgvSource.Row]["固定电话"].ToString() : "";
                txtFaxCode.txtText = _dgvSource.Rows[_dgvSource.Row]["传真"] != null ? _dgvSource.Rows[_dgvSource.Row]["传真"].ToString() : "";
                txtAddr.txtText = _dgvSource.Rows[_dgvSource.Row]["联系地址"] != null ? _dgvSource.Rows[_dgvSource.Row]["联系地址"].ToString() : "";

                txtConsumerCode.txtEnabled = false;
            }
            else if (_CtrlType == "Add")
            {
                this.Text = "展厅客户添加";
                txtConsumerCode.txtEnabled = true;
            }
        }

        /// <summary>
        /// 更新客户档案数据
        /// </summary>
        /// <returns></returns>
        private bool UpdateCusumerData()
        {
            string ErrMsg = string.Empty;
            bool bFlag = true;
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("fchrCusCode", typeof(string));
            dt.Columns.Add("fchrCusName", typeof(string));
            dt.Columns.Add("fchrMobileNum", typeof(string));
            dt.Columns.Add("fchrPhoneNum", typeof(string));
            dt.Columns.Add("fchrFax", typeof(string));
            dt.Columns.Add("fchrWorkPlace", typeof(string));
            dt.Columns.Add("fchrAddress", typeof(string));
            dt.Columns.Add("fchrCreatePerson", typeof(string));
            dt.Columns.Add("fchrStoreID", typeof(string));
            dt.Columns.Add("fdtmAddTime", typeof(DateTime));
            dt.Columns.Add("fdtmlastmodifytime", typeof(DateTime));
            dt.Columns.Add("fbitExport", typeof(bool));

            if (_CtrlType == "Modify")
            {
                //先删除旧记录
                SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, string.Format(@"delete from sl_ZT_Customer where ID = '{0}'", _dgvSource.Rows[_dgvSource.Row]["ID"].ToString()));
                dr = dt.NewRow();
                dr["ID"] = _dgvSource.Rows[_dgvSource.Row]["ID"].ToString();
                dr["fchrCusCode"] = txtConsumerCode.txtText.Trim();
                dr["fchrCusName"] = txtConsumerName.txtText.Trim();
                dr["fchrPhoneNum"] = txtPhoneNum.txtText.Trim();
                dr["fchrMobileNum"] = txtMobileNum.txtText.Trim();
                dr["fchrFax"] = txtFaxCode.txtText.Trim();
                dr["fchrWorkPlace"] = txtWorkPlace.txtText.Trim();
                dr["fchrAddress"] = txtAddr.txtText.Trim();
                dr["fdtmAddTime"] = _dgvSource.Rows[_dgvSource.Row]["创建日期"].ToString();
                dr["fdtmlastmodifytime"] = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                dr["fbitExport"] = false;
                dt.Rows.Add(dr);
                dr.AcceptChanges();

            }
            else if (_CtrlType == "Add")
            {
                if (CheckZTCustomerCodeIsExists(txtConsumerCode.txtText.ToString()))
                {
                    RetailMessageBox.ShowInformation("该客户编码在系统中已经存在，不允许重复输入！");
                    bFlag = false;
                }

                if (bFlag)
                {
                    dr = dt.NewRow();
                    dr["ID"] = Guid.NewGuid().ToString();
                    dr["fchrCusCode"] = txtConsumerCode.txtText.Trim();
                    dr["fchrCusName"] = txtConsumerName.txtText.Trim();
                    dr["fchrPhoneNum"] = txtPhoneNum.txtText.Trim();
                    dr["fchrMobileNum"] = txtMobileNum.txtText.Trim();
                    dr["fchrFax"] = txtFaxCode.txtText.Trim();
                    dr["fchrWorkPlace"] = txtWorkPlace.txtText.Trim();
                    dr["fchrAddress"] = txtAddr.txtText.Trim();
                    dr["fchrCreatePerson"] = SysPara.GetSysPara("操作员名称").ToString();
                    dr["fchrStoreID"] = SysPara.Parameters["StoreId"].ToString();
                    dr["fdtmAddTime"] = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    dr["fbitExport"] = false;
                    dt.Rows.Add(dr);
                    dr.AcceptChanges();
                }
            }

            if (bFlag)
            {
                //批量插入操作
                sl_RetailCommom.SqlBulkCopyInsert("sl_ZT_Customer", dt, SysPara.ConnectionString, ref ErrMsg);
                if (!string.IsNullOrEmpty(ErrMsg))
                {
                    bFlag = false;
                    RetailMessageBox.ShowInformation("单据保存操作发生异常：" + ErrMsg);
                }
            }

            return bFlag;
        }

        private void txtConsumerCode_textBox_TextChanged(object sender, EventArgs e)
        {
            if (_CtrlType == "Add")
            {
                if (this.txtConsumerCode.txtText.Trim().Length <= 3)
                {
                    this.txtConsumerCode.txtText = "POS";
                    this.txtConsumerCode.Focus();
                }
                else
                {
                    if (txtConsumerCode.txtText.Trim().Length > 8)
                    {
                        RetailMessageBox.ShowInformation("客户编码长度不能大于8位！");
                        this.txtConsumerCode.txtText = this.txtConsumerCode.txtText.Substring(0, 8);
                        this.txtConsumerCode.Focus();
                    }
                }
            }
        }

        private void txtConsumerCode_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
