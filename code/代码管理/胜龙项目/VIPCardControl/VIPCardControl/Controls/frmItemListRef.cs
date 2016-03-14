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
using System.Collections;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmItemListRef : Form
    {
        sl_RetailCommom Retail = new sl_RetailCommom();

        public frmItemListRef()
        {
            InitializeComponent();
        }

        private string _ItemNameText;

        public string ItemNameText
        {
            get { return _ItemNameText; }
            set { _ItemNameText = value; }
        }

        private string _DataSourceString;

        public string DataSourceString
        {
            get { return _DataSourceString; }
            set { _DataSourceString = value; }
        }

        private C1.Win.C1FlexGrid.C1FlexGrid _maindgv;

        public C1.Win.C1FlexGrid.C1FlexGrid Maindgv
        {
            get { return _maindgv; }
            set { _maindgv = value; }
        }

        private bool _IsMulSel;

        public bool IsMulSel
        {
            get { return _IsMulSel; }
            set { _IsMulSel = value; }
        }

        private string _SelText;

        public string SelText
        {
            get { return _SelText; }
            set { _SelText = value; }
        }

        private string _SelValue;

        public string SelValue
        {
            get { return _SelValue; }
            set { _SelValue = value; }
        }

        private List<string> _SelTextList;

        public List<string> SelTextList
        {
            get { return _SelTextList; }
            set { _SelTextList = value; }
        }

        private List<string> _SelValueList;

        public List<string> SelValueList
        {
            get { return _SelValueList; }
            set { _SelValueList = value; }
        }

        private string _RType;

        public string RType
        {
            get { return _RType; }
            set { _RType = value; }
        }

        private string _FilterFields;

        public string FilterFields
        {
            get { return _FilterFields; }
            set { _FilterFields = value; }
        }

        private string _OrderByFieldName;

        public string OrderByFieldName
        {
            get { return _OrderByFieldName; }
            set { _OrderByFieldName = value; }
        }

        private string _TlbName;

        public string TlbName
        {
            get { return _TlbName; }
            set { _TlbName = value; }
        }

        public frmItemListRef(string sql,string TableName,string TxtValue,C1.Win.C1FlexGrid.C1FlexGrid MainDgv,bool bIsMulSel,string RefType,string orderbyField)
        {
            _ItemNameText = TxtValue;
            _maindgv = MainDgv;
            _DataSourceString = sql;
            _IsMulSel = bIsMulSel;
            _RType = RefType;
            _OrderByFieldName = orderbyField;
            _TlbName = TableName;
            InitializeComponent();
        }

        public frmItemListRef(string sql, string TableName, string TxtValue, bool bIsMulSel, string RefType, string RefFilterStr, string orderbyField)
        {
            _ItemNameText = TxtValue;
            _DataSourceString = sql;
            _IsMulSel = bIsMulSel;
            _RType = RefType;
            _OrderByFieldName = orderbyField;
            _FilterFields = RefFilterStr;
            _TlbName = TableName;
            InitializeComponent();
        }

        //public frmItemListRef(string sql, string TxtValue, bool bIsMulSel, string RefType)
        //{
        //    _ItemNameText = TxtValue;
        //    _DataSourceString = sql;
        //    _IsMulSel = bIsMulSel;
        //    _RType = RefType;
        //    _FilterFields = RefFilterStr;
        //    InitializeComponent();
        //}

        int PageSize = 20;
        int CurPages = 1;
        int TotalPages = 0;
        int TotalRows = 0;

        public ArrayList arrSelList = new ArrayList();

        public List<ItemInfoClass> ItemInfoList = new List<ItemInfoClass>();

        private void frmItemListRef_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string relation = "";
            CurPages = 1;

            if (_RType == "商品")
                this.Text = "商品查询";
            else
                this.Text = _RType + "查询";

            if (!string.IsNullOrEmpty(_ItemNameText))
            {
                this.txtItemInfo.Text = _ItemNameText;
                if (_RType == "商品")
                    relation += " (fchrItemCode like '%" + _ItemNameText + "%' or fchrItemName like '%" + _ItemNameText + "%')";
                else
                {
                    if (!string.IsNullOrEmpty(_FilterFields))
                    {
                        relation += string.Format(@" ({0} like '%" + txtItemInfo.Text.Trim() + "%' or {1} like '%" + txtItemInfo.Text.Trim() + "%')", _FilterFields.Split(',')[0], _FilterFields.Split(',')[1]);
                    }
                }
            }

            RefreshData(relation);

            if (dgv.Rows.Count > 1)
            {
                dgv.Rows[1].Selected = true;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            dgv_DoubleClick(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ItemInfoList.Clear();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtItemInfo.Text = "";
        }

        private void dgv_Click(object sender, EventArgs e)
        {
            if (dgv.Row > 0)
            {
                if (Convert.ToBoolean(dgv.Rows[dgv.Row]["sel"]))
                    dgv.Rows[dgv.Row]["sel"] = false;
                else
                    dgv.Rows[dgv.Row]["sel"] = true;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            string relation = "";
            CurPages = 1;

            if (!string.IsNullOrEmpty(txtItemInfo.Text.Trim()))
            {
                if (_RType == "商品")
                {
                    relation += " (fchrItemCode like '%" + txtItemInfo.Text.Trim() + "%' or fchrItemName like '%" + txtItemInfo.Text.Trim() + "%')";
                }
                else
                {
                    if (!string.IsNullOrEmpty(_FilterFields))
                    {
                        //relation += string.Format(@" ({0} like '%" + txtItemInfo.Text.Trim() + "%' or {1} like '%" + txtItemInfo.Text.Trim() + "%')", _FilterFields.Split(',')[0], _FilterFields.Split(',')[1]);

                        if (_FilterFields.Split(',').Length > 0)
                        {
                            for (int t = 0; t < _FilterFields.Split(',').Length; t++)
                            {
                                if (_FilterFields.Split(',')[t] != null)
                                {
                                    if (!string.IsNullOrEmpty(relation)) relation += " or ";
                                    relation += string.Format(@" ({0} like '%" + txtItemInfo.Text.Trim() + "%')", _FilterFields.Split(',')[t].ToString());
                                }
                            }
                        }
                    }
                }
            }

            RefreshData(relation);
        }

        /// <summary>
        /// 刷新列表数据
        /// </summary>
        /// <param name="relation"></param>
        /// <returns></returns>
        private void RefreshData(string relation)
        {
            DataTable dt = new DataTable();

            dt = Retail.GetItemList(_DataSourceString,_TlbName, PageSize, CurPages, relation, _OrderByFieldName, ref TotalRows);

            if (dt.Rows.Count > 0)
            {
                dgv.DataSource = dt;
                dgv.Cols["sel"].Name = "sel";
                dgv.Cols["sel"].Caption = "选择";
                dgv.Cols["sel"].DataType = typeof(bool);

                TotalPages = Convert.ToInt32(Math.Floor(Convert.ToDouble(TotalRows / PageSize)));
                if (TotalPages <= 0) TotalPages = 1;
                lblCurPages.Text = "当前第" + CurPages.ToString() + "页";
                lblTotalPages.Text = "共" + TotalPages.ToString() + "页";
                lblTotalRows.Text = "总记录" + TotalRows.ToString() + "条";

                if (!_IsMulSel)
                {
                    dgv.Cols["sel"].Visible = false;
                    chkSelAll.Visible = false;
                }
            }
            else
            {
                //清空数据
                for (int r = dgv.Rows.Count - 1; r > 0 ; r--)
                {
                    dgv.Rows.Remove(r);
                }

                lblCurPages.Text = "当前第1页";
                lblTotalPages.Text = "共1页";
                lblTotalRows.Text = "总记录0条";
            }

            dgv.AutoSizeCols();
        }

        private void chkSelAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSelAll.Checked)
            {
                for (int i = 1; i < dgv.Rows.Count; i++)
                {
                    if (!Convert.ToBoolean(dgv.Rows[i]["sel"]))
                        dgv.Rows[i]["sel"] = true;
                }
            }
            else
            {
                for (int i = 1; i < dgv.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgv.Rows[i]["sel"]))
                        dgv.Rows[i]["sel"] = false;
                }
            }
        }

        private void ptbFirstPage_Click(object sender, EventArgs e)
        {
            CurPages = 1;
            RefreshData("");
            //Retail.GetItemList(PageSize, CurPages, "", ref TotalRows);
        }

        private void ptbPreviewPage_Click(object sender, EventArgs e)
        {
            if (CurPages > 1)
            {
                CurPages -= 1;
                RefreshData("");
                //Retail.GetItemList(PageSize, CurPages - 1, "", ref TotalRows);
            }
            else
            {
                MessageBox.Show("当前页是第一页", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void ptbNextPage_Click(object sender, EventArgs e)
        {
            if (CurPages < TotalPages)
            {
                CurPages += 1;
                //Retail.GetItemList(PageSize, CurPages + 1, "", ref TotalRows);
                RefreshData("");
            }
            else
            {
                MessageBox.Show("当前页是最后一页", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void ptbLastPage_Click(object sender, EventArgs e)
        {
            //Retail.GetItemList(PageSize, Convert.ToInt32(TotalRows), "", ref TotalRows);
            CurPages = TotalPages;
            RefreshData("");
        }

        private void txtItemInfo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnFilter_Click(sender, e);
            }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            ItemInfoClass ItemInfoCls = new ItemInfoClass();
            ItemInfoList.Clear();
            string seltext = string.Empty;
            string selvalue = string.Empty;

            if (_IsMulSel)  //多选
            {
                _SelValueList = new List<string>();
                _SelTextList = new List<string>();

                for (int r = 1; r < dgv.Rows.Count; r++)
                {
                    if (Convert.ToBoolean(dgv.Rows[r]["sel"]))
                    {
                        if (_RType == "商品")
                        {
                            ItemInfoCls.Itemcode = dgv.Rows[r]["商品编码"].ToString();
                            ItemInfoCls.Itemname = dgv.Rows[r]["商品名称"].ToString();
                            ItemInfoCls.Itemunitname = dgv.Rows[r]["计量单位"].ToString();
                            ItemInfoList.Add(ItemInfoCls);
                        }
                        else
                        {
                            _SelValueList.Add(dgv.Rows[r][2].ToString());
                            _SelTextList.Add(dgv.Rows[r][3].ToString());
                        }
                    }
                }
            }
            else  //单选
            {
                if (_RType == "商品")
                {
                    ItemInfoCls.Itemcode = dgv.Rows[dgv.Row]["商品编码"].ToString();
                    ItemInfoCls.Itemname = dgv.Rows[dgv.Row]["商品名称"].ToString();
                    ItemInfoCls.Itemunitname = dgv.Rows[dgv.Row]["计量单位"].ToString();
                    ItemInfoList.Add(ItemInfoCls);

                    this._SelValue = dgv.Rows[dgv.Row][2].ToString();
                    this._SelText = dgv.Rows[dgv.Row][3].ToString();
                }
                else
                {
                    this._SelValue = dgv.Rows[dgv.Row][2].ToString();
                    this._SelText = dgv.Rows[dgv.Row][3].ToString();
                }
            }

            //if (ItemInfoList.Count > 0)
            //{
            //    for (int r = 0; r < ItemInfoList.Count; r++)
            //    {
            //        _maindgv.Rows[_maindgv.Row]["fchrItemCode"] = ItemInfoList[r].Itemcode.ToString();
            //        _maindgv.Rows[_maindgv.Row]["fchrItemName"] = ItemInfoList[r].Itemname.ToString();
            //        _maindgv.Rows[_maindgv.Row]["fchrUnitName"] = ItemInfoList[r].Itemunitname.ToString();
            //    }
            //}

            this.DialogResult = DialogResult.OK;
        }

        private void dgv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgv_DoubleClick(sender, null);
            }
        }
    }
}
