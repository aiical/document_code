using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using UFIDA.Retail.Common;
using UFIDA.Retail.Utility;
using UFIDA.Retail.Discount;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmZTReturnForm : Form
    {
        public frmZTReturnForm()
        {
            InitializeComponent();
        }

        private string CaptionText;

        public frmZTReturnForm(string FormName)
        {
            CaptionText = FormName;
            InitializeComponent();
        }

        ArrayList list = new ArrayList();
        List<string> MultSelList = new List<string>();

        private string _selDetailRel;

        public string SelDetailRel
        {
            get { return _selDetailRel; }
            set { _selDetailRel = value; }
        }


        private void btnQuery_Click(object sender, EventArgs e)
        {
            frmZTReturnQuery frm = new frmZTReturnQuery(dgvMain, dgvDetail);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (dgvMain.Rows.Count == 1)
                {
                    list.Clear();
                    MultSelList.Clear();
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool bFlag = false;
            if (dgvDetail.Rows.Count > 1)
            {
                for (int r = 1; r < dgvDetail.Rows.Count; r++)
                {
                    if (ItemData.Sl_ZT_ZTSaleVouchFlag == "冲单")
                    {
                        if (Convert.ToBoolean(dgvDetail.Rows[r]["sel"].ToString()))
                        {
                            bFlag = true;
                            _selDetailRel = string.Format(@"id in({0})", sl_RetailCommom.GetFilterStr(sl_RetailCommom.GetMulValueString(MultSelList)));
                        }
                    }
                    else if (ItemData.Sl_ZT_ZTSaleVouchFlag == "补单")
                    {
                        bFlag = true;
                        _selDetailRel = string.Format(@"id in({0})", sl_RetailCommom.GetFilterStr(sl_RetailCommom.GetMulValueString(MultSelList)));
                    }
                }

                if (!bFlag)
                {
                    RetailMessageBox.ShowInformation(ItemData.Sl_ZT_ZTSaleVouchFlag == "冲单" ? "请先选择冲单明细数据！" : "单据明细为空，不允许参照生单！");
                    return;
                }

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                RetailMessageBox.ShowInformation("没有选择任何明细数据行！");
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ItemData.IsSaleState = true;
            ItemData.Sl_ZT_ZTSaleVouchFlag = "";
            sl_RetailCommom.FrmReturnFormRelation = "";
            list.Clear();
            MultSelList.Clear();
            this.Close();
        }

        private void dgvMain_Click(object sender, EventArgs e)
        {
            if (dgvMain.Rows.Count > 1)
            {
                if (ItemData.Sl_ZT_ZTSaleVouchFlag == "冲单")
                {
                    if (Convert.ToBoolean(dgvMain.Rows[dgvMain.RowSel][1]))
                    {
                        dgvMain.Rows[dgvMain.RowSel][1] = false;
                        for (int r = dgvDetail.Rows.Count - 1; r > 0; r--)
                        {
                            if (dgvMain.Rows[dgvMain.RowSel]["零售单编号"].ToString() == dgvDetail.Rows[r]["fchrcode"].ToString())
                            {
                                list.Remove(dgvMain.Rows[dgvMain.RowSel]["零售单编号"].ToString() + '-' + dgvDetail.Rows[r]["id"].ToString());
                                dgvDetail.Rows.Remove(r);
                            }
                        }

                        if (dgvDetail.Rows.Count == 1 && chkSelAllDetail.Checked)
                        {
                            chkSelAllDetail.Checked = false;
                        }
                    }
                    else
                    {
                        dgvMain.Rows[dgvMain.RowSel][1] = true;
                        GetDetailsTable(dgvMain.Rows[dgvMain.RowSel]["零售单编号"].ToString());
                    }
                }
                else if (ItemData.Sl_ZT_ZTSaleVouchFlag == "补单")
                {
                    list.Clear();
                    MultSelList.Clear();
                    dgvDetail.Rows.RemoveRange(1, dgvDetail.Rows.Count - 1);
                    GetDetailsTable(dgvMain.Rows[dgvMain.RowSel]["零售单编号"].ToString());
                    if (dgvDetail.Rows.Count > 1)
                    {
                        for (int r = 1; r < dgvDetail.Rows.Count; r++)
                        {
                            if (!MultSelList.Contains(dgvDetail.Rows[r]["id"].ToString()))
                                MultSelList.Add(dgvDetail.Rows[r]["id"].ToString());
                        }
                    }
                }
            }
        }

        private void chkSelAllMain_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSelAllMain.Checked)
            {
                for (int i = 1; i < dgvMain.Rows.Count; i++)
                {
                    if (!Convert.ToBoolean(dgvMain.Rows[i][1]))
                    {
                        //dgvMain.Rows[i][1] = true;
                        dgvMain.RowSel = i;
                        dgvMain_Click(sender, e);
                    }
                }
            }
            else
            {   
                for (int i = 1; i < dgvMain.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvMain.Rows[i][1]))
                    {
                        //dgvMain.Rows[i][1] = false;
                        dgvMain.RowSel = i;
                        dgvMain_Click(sender, e);
                    }
                }
            }
        }

        private void chkSelAllDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSelAllDetail.Checked)
            {
                for (int i = 1; i < dgvDetail.Rows.Count; i++)
                {
                    if (!Convert.ToBoolean(dgvDetail.Rows[i][1]))
                    {
                        //dgvDetail.Rows[i][1] = true;
                        dgvDetail.RowSel = i;
                        dgvDetail_Click(sender, e);
                    }
                }
            }
            else
            {
                for (int i = 1; i < dgvDetail.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvDetail.Rows[i][1]))
                    {
                        //dgvDetail.Rows[i][1] = false;
                        dgvDetail.RowSel = i;
                        dgvDetail_Click(sender, e);
                    }
                }
            }
        }

        /// <summary>
        /// 获取单据明细列表
        /// </summary>
        /// <param name="fchrCode"></param>
        private void GetDetailsTable(string fchrCode)
        {
            string DispString = string.Empty;
            DispString = string.Format(@" fchrcode,fchritemcode,fchritemname,fchrSpec,fchrfree1,fchrfree2,fchrunitname,flotquantity,
                                         flotquoteprice,flotprice,flotrealmoney,Convert(decimal(18,2),flotdiscountrate) as flotdiscountrate,Convert(decimal(18,2),flotdiscount) as flotdiscount,fchremployeename,id ");

            SqlParameter[] param = { 
                                      new SqlParameter("@FilterString",string.Format(@"fchrcode = '{0}'",fchrCode)),
                                      new SqlParameter("@DisplayFileds",DispString),
                                      new SqlParameter("@fchrZTSaleVouchFlag",ItemData.Sl_ZT_ZTSaleVouchFlag)
                                   };

            DataTable objTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, "sl_ZT_proc_GetValidReturnDetailList", param).Tables[0];
            if (objTable.Rows.Count > 0)
            {
                for (int r = 0; r < objTable.Rows.Count; r++)
                {
                    if (!list.Contains(dgvMain.Rows[dgvMain.RowSel]["零售单编号"].ToString() + '-' + objTable.Rows[r]["id"].ToString()))
                    {
                        list.Add(dgvMain.Rows[dgvMain.RowSel]["零售单编号"].ToString() + '-' + objTable.Rows[r]["id"].ToString());
                        dgvDetail.Rows.Add();
                        for (int c = 1; c < dgvDetail.Cols.Count; c++)
                        {
                            dgvDetail.Rows[dgvDetail.Rows.Count - 1][dgvDetail.Cols[c].Name] = objTable.Rows[r][dgvDetail.Cols[c].Name].ToString();
                        }
                    }
                }

                dgvDetail.Cols[1].DataType = typeof(bool);
                dgvDetail.AutoSizeCols();
            }
            else
            {
                RetailMessageBox.ShowInformation("获取明细数据失败，请联系系统管理员！");
            }
        }

        private void dgvDetail_Click(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count > 1)
            {
                if (ItemData.Sl_ZT_ZTSaleVouchFlag == "冲单")
                {
                    if (Convert.ToBoolean(dgvDetail.Rows[dgvDetail.RowSel][1]))
                    {
                        dgvDetail.Rows[dgvDetail.RowSel][1] = false;
                        if (MultSelList.Contains(dgvDetail.Rows[dgvDetail.RowSel]["id"].ToString()))
                            MultSelList.Remove(dgvDetail.Rows[dgvDetail.RowSel]["id"].ToString());
                    }
                    else
                    {
                        dgvDetail.Rows[dgvDetail.RowSel][1] = true;
                        if (!MultSelList.Contains(dgvDetail.Rows[dgvDetail.RowSel]["id"].ToString()))
                            MultSelList.Add(dgvDetail.Rows[dgvDetail.RowSel]["id"].ToString());
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtItemInfo.Text = "";
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string filterStr = string.Empty;
            if (!string.IsNullOrEmpty(txtItemInfo.Text))
            {
                if (!string.IsNullOrEmpty(sl_RetailCommom.FrmReturnFormRelation))
                    filterStr = sl_RetailCommom.FrmReturnFormRelation +" and "+ string.Format(@" fchrcode like '%{0}%'", txtItemInfo.Text.Trim());
                else
                    filterStr = string.Format(@" fchrcode like '%{0}%'", txtItemInfo.Text.Trim());
            }
            else
            {
                if (!string.IsNullOrEmpty(sl_RetailCommom.FrmReturnFormRelation))
                    filterStr = sl_RetailCommom.FrmReturnFormRelation + " and (1=1)";
                else
                    filterStr = "(1=1)";
            }

            SqlParameter[] param = { 
                                      new SqlParameter("@FilterString",filterStr),
                                      new SqlParameter("@DisplayFileds",string.Format(@"fchrCode as '零售单编号',fdtmDate as '单据日期',fchrMaker as '制单人',flotmoney as '单据金额',sl_ZT_SaleType as '销售类别',sl_ZT_SaleStyle as '销售方式',sl_ZT_Customer as '展厅客户'")),
                                      new SqlParameter("@fchrZTSaleVouchFlag",ItemData.Sl_ZT_ZTSaleVouchFlag)
                                   };
            if (SqlAccess.ExecuteDataset(SysPara.ConnectionString, "sl_ZT_proc_GetValidReturnList", param).Tables.Count > 0)
            {
                DataTable objTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, "sl_ZT_proc_GetValidReturnList", param).Tables[0];

                if (objTable.Rows.Count > 0)
                {
                    if (chkSelAllDetail.Checked) chkSelAllDetail.Checked = false;
                    dgvDetail.Rows.RemoveRange(1, dgvDetail.Rows.Count - 1);
                    list.Clear();
                    MultSelList.Clear();
                    dgvMain.DataSource = objTable;
                    if (ItemData.Sl_ZT_ZTSaleVouchFlag == "冲单")
                    {
                        dgvMain.Cols[1].DataType = typeof(bool);
                        dgvMain.Cols[1].AllowEditing = true;
                    }
                }
                else
                {
                    RetailMessageBox.ShowInformation("没找到任何数据！");
                    if (dgvMain.Rows.Count > 1)
                    {
                        for (int r = dgvMain.Rows.Count - 1; r > 0; r--)
                        {
                            dgvMain.Rows.Remove(r);
                        }                        
                        if (dgvDetail.Rows.Count > 1)
                        {
                            dgvDetail.Rows.RemoveRange(1, dgvDetail.Rows.Count - 1);
                        }
                        this.MultSelList.Clear();
                        this.list.Clear();
                    }
                }
            }
            else
            {
                RetailMessageBox.ShowInformation("未查询到符合条件的数据！");
                if (dgvMain.Rows.Count > 1)
                {
                    for (int r = dgvMain.Rows.Count - 1; r > 0; r--)
                    {
                        dgvMain.Rows.Remove(r);
                    }                    
                    if (dgvDetail.Rows.Count > 1)
                    {
                        dgvDetail.Rows.RemoveRange(1, dgvDetail.Rows.Count - 1);
                    }
                    this.MultSelList.Clear();
                    this.list.Clear();
                }
            }
        }

        private void frmZTReturnForm_Load(object sender, EventArgs e)
        {
            this.Text = CaptionText;
            if (ItemData.Sl_ZT_ZTSaleVouchFlag == "补单")
            {
                chkSelAllMain.Enabled = false;
                chkSelAllDetail.Enabled = false;
                this.dgvDetail.AllowEditing = false;
                //dgvDetail.Cols.Remove(dgvDetail.Cols["sel"]);
                dgvDetail.Cols["sel"].Visible = false;
            }
        }
    }
}
