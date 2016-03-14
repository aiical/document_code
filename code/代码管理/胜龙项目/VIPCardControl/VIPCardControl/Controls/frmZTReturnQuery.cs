using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using UFIDA.Retail.Utility;
using UFIDA.Retail.Common;
using UFIDA.Retail.Discount;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmZTReturnQuery : Form
    {
        public frmZTReturnQuery()
        {
            InitializeComponent();
        }

        C1.Win.C1FlexGrid.C1FlexGrid _dgvMain;

        public C1.Win.C1FlexGrid.C1FlexGrid DgvMain
        {
            get { return _dgvMain; }
            set { _dgvMain = value; }
        }

        private C1.Win.C1FlexGrid.C1FlexGrid _dgvDetail;

        public C1.Win.C1FlexGrid.C1FlexGrid DgvDetail
        {
            get { return _dgvDetail; }
            set { _dgvDetail = value; }
        }

        public frmZTReturnQuery(C1.Win.C1FlexGrid.C1FlexGrid _dgvmain,C1.Win.C1FlexGrid.C1FlexGrid _dgvdetail)
        {
            _dgvMain = _dgvmain;
            _dgvDetail = _dgvdetail;
            InitializeComponent();
        }

        private void frmZTReturnQuery_Load(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            dtpBeginDate.Value = time.AddDays(1 - time.Day);
            dtpBeginDate.Checked = true;
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
                    relation += string.Format("Convert(varchar(10),fdtmDate,23) >= '{0}'", dtpBeginDate.Value.ToString("yyyy-MM-dd"));
                }

                //结束日期
                if (dtpEndDate.Checked)
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("Convert(varchar(10),fdtmDate,23) <= '{0}'", dtpEndDate.Value.ToString("yyyy-MM-dd"));
                }

                //销售类别
                if (!string.IsNullOrEmpty(txtSaleType.txtText.ToString()))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("sl_ZT_SaleType like '%{0}%'", txtSaleType.txtText.Trim());
                }

                //销售方式
                //if (!string.IsNullOrEmpty(txtSaleStyle.txtText.Trim()))
                //{
                //    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                //    relation += string.Format("sl_ZT_SaleStyle like '%{0}%'", txtSaleStyle.txtText.Trim());
                //}

                //展厅客户
                if (!string.IsNullOrEmpty(txtZTCustomer.txtText.Trim()))
                {
                    if (!string.IsNullOrEmpty(relation)) relation += " and ";
                    relation += string.Format("sl_ZT_Customer in ({0})", sl_RetailCommom.GetFilterStr(txtZTCustomer.txtText.Trim()));
                }

                return relation;
            }
        }

        private void txtSaleType_Button_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            string sqlTlbName = string.Empty;
//            sql = string.Format(@"select 0 as sel,fchrSaleTypeCode as '销售类型编码',fchrSaleTypeName as '销售类型名称',ROW_NUMBER() over(order by fchrSaleTypeCode) as ID
//                                  from SL_ZT_SaleType where 1=1");

//            sql = string.Format(@"SELECT 0 as sel,fchrSaleTypeCode as '销售类型编码',fchrSaleTypeName as '销售类型名称',(select count(1) from SL_ZT_SaleType where Convert(int,fchrSaleTypeCode) <=Convert(int,t.fchrSaleTypeCode)) AS ID FROM  
//                                  SL_ZT_SaleType t where 1=1 ");

            sqlTlbName = string.Format(@"SELECT 0 as sel,fchrSaleTypeCode as '销售类型编码',fchrSaleTypeName as '销售类型名称'
                                              FROM SL_ZT_SaleType where 1=1");

            sql = string.Format(@"SELECT Count(1) FROM SL_ZT_SaleType where 1=1");

            frmItemListRef ItemRef = new frmItemListRef(sql, sqlTlbName, txtSaleType.txtTag != null ? txtSaleType.txtTag.ToString() : "", false, "销售类别", "fchrSaleTypeCode,fchrSaleTypeName", "销售类型编码");
            if (ItemRef.ShowDialog() == DialogResult.OK)
            {
                txtSaleType.txtTag = ItemRef.SelValue.ToString();
                txtSaleType.txtText = ItemRef.SelText.ToString();
            }
        }

//        private void txtSaleStyle_Button_Click(object sender, EventArgs e)
//        {
//            string sql = string.Empty;
//            sql = string.Format(@"select 0 as sel,fchrSaleStyleCode as '销售方式编码',fchrSaleStyleName as '销售方式名称',ROW_NUMBER() over(order by fchrSaleStyleCode) as ID
//                                  from SL_ZT_SaleStyle where 1=1");
//            frmItemListRef ItemRef = new frmItemListRef(sql, txtSaleStyle.txtTag != null ? txtSaleStyle.txtTag.ToString() : "", false, "销售方式");
//            if (ItemRef.ShowDialog() == DialogResult.OK)
//            {
//                txtSaleStyle.txtTag = ItemRef.SelValue.ToString();
//                txtSaleStyle.txtText = ItemRef.SelText.ToString();
//            }
//        }

        private void txtZTCustomer_Button_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            string sqlTlbName = string.Empty;
//            sql = string.Format(@"select 0 as sel,fchrCusCode as '客户编码',fchrCusName as '客户名称',fchrMobileNum as '手机号码',fchrPhoneNum as '固定电话',fchrFax as '传真',fchrWorkPlace as '工作单位',ROW_NUMBER() over(order by fchrCusCode) as ID
//                                  from sl_ZT_Customer where 1=1");

//            sql = string.Format(@"SELECT 0 as sel,fchrCusCode as '客户编码',fchrCusName as '客户名称',fchrMobileNum as '手机号码',fchrPhoneNum as '固定电话',fchrFax as '传真',fchrWorkPlace as '工作单位',(select count(1) from sl_ZT_Customer where fdtmAddTime <= t.fdtmAddTime) AS ID FROM  
//                                  sl_ZT_Customer t where 1=1 ");

            sqlTlbName = string.Format(@"SELECT 0 as sel,fchrCusCode as '客户编码',fchrCusName as '客户名称',fchrMobileNum as '手机号码',fchrPhoneNum as '固定电话',fchrFax as '传真',fchrWorkPlace as '工作单位'
                                              FROM sl_ZT_Customer where 1=1");

            sql = string.Format(@"SELECT Count(1) FROM sl_ZT_Customer where 1=1");
            //,手机号码,固定电话,传真,工作单位
            frmItemListRef ItemRef = new frmItemListRef(sql, sqlTlbName, txtZTCustomer.txtTag != null ? txtZTCustomer.txtTag.ToString() : "", true, "展厅客户", "fchrCusCode,fchrCusName,fchrMobileNum,fchrPhoneNum,fchrFax,fchrWorkPlace", "客户编码");
            if (ItemRef.ShowDialog() == DialogResult.OK)
            {
                txtZTCustomer.txtTag = sl_RetailCommom.GetMulValueString(ItemRef.SelValueList);
                txtZTCustomer.txtText = sl_RetailCommom.GetMulValueString(ItemRef.SelTextList);
            }
        }

        private void txtSaleType_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSaleType_Button_Click(sender, null);
            }
        }

        //private void txtSaleStyle_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        txtSaleStyle_Button_Click(sender, null);
        //    }
        //}

        private void txtZTCustomer_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtZTCustomer_Button_Click(sender, null);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            sl_RetailCommom.FrmReturnFormRelation = string.IsNullOrEmpty(GetRealtion) ? "(1=1)" : GetRealtion;
            SqlParameter[] param = { 
                                      new SqlParameter("@FilterString",sl_RetailCommom.FrmReturnFormRelation),
                                      new SqlParameter("@DisplayFileds",string.Format(@"fchrCode as '零售单编号',fdtmDate as '单据日期',fchrMaker as '制单人',flotmoney as '单据金额',sl_ZT_SaleType as '销售类别',sl_ZT_SaleStyle as '销售方式',sl_ZT_Customer as '展厅客户'")),
                                      new SqlParameter("@fchrZTSaleVouchFlag",ItemData.Sl_ZT_ZTSaleVouchFlag)
                                   };
            if (SqlAccess.ExecuteDataset(SysPara.ConnectionString, "sl_ZT_proc_GetValidReturnList", param).Tables.Count > 0)
            {
                DataTable objTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, "sl_ZT_proc_GetValidReturnList", param).Tables[0];

                if (objTable.Rows.Count > 0)
                {
                    _dgvMain.DataSource = objTable;
                    if (ItemData.Sl_ZT_ZTSaleVouchFlag == "冲单")
                    {
                        _dgvMain.Cols[1].DataType = typeof(bool);
                        _dgvMain.Cols[1].AllowEditing = true;
                    }
                }
                else
                {
                    RetailMessageBox.ShowInformation("没找到任何数据！");
                    if (_dgvMain.Rows.Count > 1)
                    {
                        for (int r = _dgvMain.Rows.Count - 1; r > 0; r--)
                        {
                            _dgvMain.Rows.Remove(r);
                        }
                        if (_dgvDetail.Rows.Count > 1)
                        {
                            _dgvDetail.Rows.RemoveRange(1, _dgvDetail.Rows.Count - 1);
                        }
                    }
                }
            }
            else
            {
                RetailMessageBox.ShowInformation("未查询到符合条件的数据！");
                if (_dgvMain.Rows.Count > 1)
                {
                    for (int r = _dgvMain.Rows.Count - 1; r > 0; r--)
                    {
                        _dgvMain.Rows.Remove(r);
                    }
                    if (_dgvDetail.Rows.Count > 1)
                    {
                        _dgvDetail.Rows.RemoveRange(1, _dgvDetail.Rows.Count - 1);
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
