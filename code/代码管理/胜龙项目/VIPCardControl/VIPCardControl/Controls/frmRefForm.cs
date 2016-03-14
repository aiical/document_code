using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmRefForm : Form
    {
        public frmRefForm()
        {
            InitializeComponent();
        }

        private string _cFormName;

        public string cFormName
        {
            get { return _cFormName; }
            set { _cFormName = value; }
        }

        private string _cRefName;

        public string cRefName
        {
            get { return _cRefName; }
            set { _cRefName = value; }
        }

        private string _cRefSQL;

        public string cRefSQL
        {
            get { return _cRefSQL; }
            set { _cRefSQL = value; }
        }

        private string _cRefTxt;

        public string CRefTxt
        {
            get { return _cRefTxt; }
            set { _cRefTxt = value; }
        }

        private string _cRefValue;

        public string CRefValue
        {
            get { return _cRefValue; }
            set { _cRefValue = value; }
        }

        private string _FilterFields;

        public string FilterFields
        {
            get { return _FilterFields; }
            set { _FilterFields = value; }
        }


        private string _OrderByStr;

        public string OrderByStr
        {
            get { return _OrderByStr; }
            set { _OrderByStr = value; }
        }

        private string _TlbName;

        public string TlbName
        {
            get { return _TlbName; }
            set { _TlbName = value; }
        }

        public frmRefForm(string FormName,string RefName,string RefSQL,string RefFilterStr,string TableName,string orderbyStr)
        {
            _cFormName = FormName;
            _cRefName = RefName;
            _cRefSQL = RefSQL;
            _FilterFields = RefFilterStr;
            _OrderByStr = orderbyStr;
            _TlbName = TableName;
            InitializeComponent();
        }

        private void frmRefForm_Load(object sender, EventArgs e)
        {
            this.Text = _cFormName;
            txtRef.lblText = _cRefName;

            string RefText = string.Empty;
            string RefValue = string.Empty;

            if (_cFormName == "销售类别")
            {
                RefText = sl_RetailCommom.GetPrivateProfileString(@".\SL_ZT_RefInfo.ini", "SaleType", "SaleTypeText", ""); //获取销售类别名称
                if (!string.IsNullOrEmpty(RefText))
                {
                    RefValue = sl_RetailCommom.GetPrivateProfileString(@".\SL_ZT_RefInfo.ini", "SaleType", "SaleTypeValue", ""); //获取销售类别值/编码
                    txtRef.txtText = RefText;
                    txtRef.txtTag = RefValue;
                    this._cRefTxt = RefText;
                    this._cRefValue = RefValue;
                }
                else
                {
                    //填写默认值
                    txtRef.txtText = "一般销售";
                    txtRef.txtTag = "01";
                    this._cRefTxt = "一般销售";
                    this._cRefValue = "01";
                }
            }
            else if (_cFormName == "销售方式")
            {
                RefText = sl_RetailCommom.GetPrivateProfileString(@".\SL_ZT_RefInfo.ini", "SaleStyle", "SaleStyleText", ""); //获取销售方式名称
                if (!string.IsNullOrEmpty(RefText))
                {
                    RefValue = sl_RetailCommom.GetPrivateProfileString(@".\SL_ZT_RefInfo.ini", "SaleStyle", "SaleStyleValue", ""); //获取销售方式值/编码
                    txtRef.txtText = RefText;
                    txtRef.txtTag = RefValue;
                    this._cRefTxt = RefText;
                    this._cRefValue = RefValue;
                }
                else
                {
                    //填写默认值
                    txtRef.txtText = "销售";
                    txtRef.txtTag = "01";
                    this._cRefTxt = "销售";
                    this._cRefValue = "01";
                }
            }
            else if (_cFormName == "展厅客户")
            {
                RefText = sl_RetailCommom.GetPrivateProfileString(@".\SL_ZT_RefInfo.ini", "ZTCustomer", "ZTCustomerText", ""); //获取展厅客户名称
                if (!string.IsNullOrEmpty(RefText))
                {
                    RefValue = sl_RetailCommom.GetPrivateProfileString(@".\SL_ZT_RefInfo.ini", "ZTCustomer", "ZTCustomerValue", ""); //获取展厅客户值/编码
                    txtRef.txtText = RefText;
                    txtRef.txtTag = RefValue;
                    this._cRefTxt = RefText;
                    this._cRefValue = RefValue;
                }
                //else
                //{
                //    //填写默认值
                //    txtRef.txtText = "销售";
                //    txtRef.txtTag = "01";
                //}
            }
        }

        private void txtRef_Button_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            sql = _cRefSQL;
            frmItemListRef ItemRef = new frmItemListRef(sql,_TlbName, txtRef.txtTag != null ? txtRef.txtTag.ToString() : "", false, _cFormName, _FilterFields, _OrderByStr);
            if (ItemRef.ShowDialog() == DialogResult.OK)
            {
                txtRef.txtTag = ItemRef.SelValue.ToString();
                txtRef.txtText = ItemRef.SelText.ToString();
                _cRefValue = ItemRef.SelValue.ToString();
                _cRefTxt = ItemRef.SelText.ToString();
            }
        }

        private void txtRef_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtRef_Button_Click(sender, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
