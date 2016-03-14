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
    public partial class frmQueryForm : Form
    {
        public frmQueryForm()
        {
            InitializeComponent();
        }

        private string _VouchType;

        sl_RetailCommom RetailCommom = new sl_RetailCommom();

        public string VouchType
        {
            get { return _VouchType; }
            set { _VouchType = value; }
        }

        private C1.Win.C1FlexGrid.C1FlexGrid _dgv;

        public C1.Win.C1FlexGrid.C1FlexGrid Dgv
        {
            get { return _dgv; }
            set { _dgv = value; }
        }

        private bool _IsRef;

        public bool IsRef
        {
            get { return _IsRef; }
            set { _IsRef = value; }
        }

        private string _DefaultFilterStr;

        public string DefaultFilterStr
        {
            get { return _DefaultFilterStr; }
            set { _DefaultFilterStr = value; }
        }

        public frmQueryForm(string cVouchType,C1.Win.C1FlexGrid.C1FlexGrid dgvSouerce)
        {
            _VouchType = cVouchType;
            _dgv = dgvSouerce;
            InitializeComponent();
        }

        public frmQueryForm(string cVouchType, C1.Win.C1FlexGrid.C1FlexGrid dgvSouerce, bool bRef, string DefFilterString)
        {
            _VouchType = cVouchType;
            _dgv = dgvSouerce;
            _IsRef = bRef;
            _DefaultFilterStr = DefFilterString;
            InitializeComponent();
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        private string GetRealtion
        {
            get
            {
                string relation = string.Empty;

                //开始日期
                if (dtpBeginDate.Checked)
                {
                    relation += string.Format("Convert(varchar(10),m.fdtmDate,23) >= '{0}'", dtpBeginDate.Value.ToString("yyyy-MM-dd"));
                }

                //结束日期
                if (dtpEndDate.Checked)
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("Convert(varchar(10),m.fdtmDate,23) <= '{0}'", dtpEndDate.Value.ToString("yyyy-MM-dd"));
                }

                ////商品名称
                //if (!string.IsNullOrEmpty(txtItemName.txtText.ToString()))
                //{
                //    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                //    relation += string.Format("VipConsumer.fnarconsumercode like '%{0}%'", txtConsumerCode.txtText.Trim());
                //}

                //营业员名称
                if (!string.IsNullOrEmpty(txtEmployeeName.txtText.Trim()))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("m.fchrMaker like '%{0}%'", txtEmployeeName.txtText.Trim());
                }

                //单据编号
                if (!string.IsNullOrEmpty(txtVoucherCode.txtText.Trim()))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("m.fchrCode like '%{0}%'", txtVoucherCode.txtText.Trim());
                }

                //是否暂存
                if (cmbTmpSave.SelectedIndex == 1)  //是
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("isnull(fbitTempSave,0) = 1", cmbTmpSave.SelectedItem.ToString());
                }
                else if (cmbTmpSave.SelectedIndex == 2) //否
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("isnull(fbitTempSave,0) = 0", cmbTmpSave.SelectedItem.ToString());
                }

                //是否上传U8
                if (cmbTransferU8.SelectedIndex == 1)  //是
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("isnull(fbitTransferToU8,0) = 1", cmbTransferU8.SelectedItem.ToString());
                }
                else if (cmbTransferU8.SelectedIndex == 2)  //否
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("isnull(fbitTransferToU8,0) = 0", cmbTransferU8.SelectedItem.ToString());
                }

                //是否上传RM
                if (cmbTransferRM.SelectedIndex == 1)  //是
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("isnull(fbitTransferToRetail,0) = 1", cmbTransferRM.SelectedItem.ToString());
                }
                else if (cmbTransferRM.SelectedIndex == 2)  //否
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("isnull(fbitTransferToRetail,0) = 0", cmbTransferRM.SelectedItem.ToString());
                }

                return relation;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string fchrItemID = string.Empty;
            if (!string.IsNullOrEmpty(txtItemName.txtText.Trim()))
            {
                fchrItemID = sl_RetailCommom.GetDatas("fchrItemID", "Item", "fchrItemCode", txtItemName.txtTag.ToString());
            }

            if (_IsRef && !string.IsNullOrEmpty(_DefaultFilterStr))
            {
                string rel = string.Empty;
                rel = GetRealtion;
                if (!string.IsNullOrEmpty(GetRealtion))
                    rel += " And ";
                rel += _DefaultFilterStr;
                RetailCommom.DataRefresh(fchrItemID, _VouchType, _dgv, rel);
            }
            else
            {
                RetailCommom.DataRefresh(fchrItemID, _VouchType, _dgv, GetRealtion);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void frmQueryForm_Load(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            dtpBeginDate.Value = time.AddDays(1 - time.Day);
            dtpBeginDate.Checked = true;

            if (_IsRef && !string.IsNullOrEmpty(_DefaultFilterStr)) //参照列表
            {
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                cmbTmpSave.Visible = false;
                cmbTransferRM.Visible = false;
                cmbTransferU8.Visible = false;
                txtEmployeeName.Visible = false;
            }
        }

        private void txtItemName_Button_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            string sqlTlbName = string.Empty;
//            sql = string.Format(@"select 0 as sel,fchrItemCode as '商品编码',fchrItemName as '商品名称',fchrSpec as '规格型号',fchrUnitName as '计量单位',flotQuotePrice as '商品单价',ROW_NUMBER() over(order by fchrItemCode) as ID
//                                      from item where 1=1");

//            sql = string.Format(@"SELECT 0 as sel,fchrItemCode as '商品编码',fchrItemName as '商品名称',fchrSpec as '规格型号',fchrUnitName as '计量单位',flotQuotePrice as '商品单价',(select count(1) from item where fchrItemCode <= t.fchrItemCode) AS ID FROM  
//                                      item t where 1=1 ");

            sqlTlbName = string.Format(@"SELECT 0 as sel,fchrItemCode as '商品编码',fchrItemName as '商品名称',fchrSpec as '规格型号',fchrUnitName as '计量单位',flotQuotePrice as '商品单价' FROM  
                                             item where 1=1");

            sql = string.Format(@"SELECT Count(1) FROM item where 1=1 ");

            frmItemListRef ItemRef = new frmItemListRef(sql, sqlTlbName, txtItemName.txtTag != null ? txtItemName.txtTag.ToString() : "", false, "商品", "", "商品编码");
            if (ItemRef.ShowDialog() == DialogResult.OK)
            {
                txtItemName.txtTag = ItemRef.ItemInfoList[0].Itemcode.ToString();
                txtItemName.txtText = ItemRef.ItemInfoList[0].Itemname.ToString();               
            }
        }

        private void txtItemName_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtItemName_Button_Click(sender, null);
            }
        }

        private void txtEmployeeName_Button_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            string sqlTlbName = string.Empty;
//            sql = string.Format(@"select 0 as sel,fchrEmployeeCode as '营业员编码',fchrEmployeeName as '营业员名称',ROW_NUMBER() over(order by fchrEmployeeCode) as ID
//                                  from Employee where 1=1 and fchrEmployeeName not in('要货','退货')");

//            sql = string.Format(@"SELECT 0 as sel,fchrEmployeeCode as '营业员编码',fchrEmployeeName as '营业员名称',(select count(1) from Employee where fchrEmployeeCode <= t.fchrEmployeeCode) AS ID FROM  
//                                  Employee t where 1=1 and fchrEmployeeName not in('要货','退货')");

            sqlTlbName = string.Format(@"SELECT 0 as sel,fchrEmployeeCode as '营业员编码',fchrEmployeeName as '营业员名称' FROM Employee where 1=1 and fchrEmployeeName not in('要货','退货')");

            sql = string.Format(@"SELECT Count(1) FROM Employee where 1=1 and fchrEmployeeName not in('要货','退货')");

            frmItemListRef ItemRef = new frmItemListRef(sql, sqlTlbName, txtEmployeeName.txtTag != null ? txtEmployeeName.txtTag.ToString() : "", false, "营业员", "fchrEmployeeCode,fchrEmployeeName", "营业员编码");
            if (ItemRef.ShowDialog() == DialogResult.OK)
            {
                txtEmployeeName.txtTag = ItemRef.SelValue;
                txtEmployeeName.txtText = ItemRef.SelText;
            }
        }

        private void txtEmployeeName_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEmployeeName_Button_Click(sender, e);
            }
        }
    }
}
