using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmAddItemForm : Form
    {
        public frmAddItemForm()
        {
            InitializeComponent();
        }

        private C1.Win.C1FlexGrid.C1FlexGrid _dgv;

        public C1.Win.C1FlexGrid.C1FlexGrid Dgv
        {
            get { return _dgv; }
            set { _dgv = value; }
        }

        private int _rowIndex;

        public int RowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
        }

        public frmAddItemForm(C1.Win.C1FlexGrid.C1FlexGrid dgv,int CurIndex)
        {
            _dgv = dgv;
            _rowIndex = CurIndex;
            InitializeComponent();
        }

        private void txtItemName_Load(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            _dgv.Rows[RowIndex]["aa"] = "";
            _dgv.Rows.Add();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtItemName_Button_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            string sqlTlbName = string.Empty;
            //string rel = "";
//            sql = string.Format(@"select 0 as sel,fchrItemCode as '商品编码',fchrItemName as '商品名称',fchrSpec as '规格型号',fchrUnitName as '计量单位',flotQuotePrice as '商品单价',ROW_NUMBER() over(order by fchrItemCode) as ID
//                                      from item where 1=1");

//            sql = string.Format(@"SELECT 0 as sel,fchrItemCode as '商品编码',fchrItemName as '商品名称',fchrSpec as '规格型号',fchrUnitName as '计量单位',flotQuotePrice as '商品单价',(select count(1) from item where fchrItemCode <= t.fchrItemCode) AS ID FROM  
//                                  item t where 1=1 ");

            sqlTlbName = string.Format(@"SELECT 0 as sel,fchrItemCode as '商品编码',fchrItemName as '商品名称',fchrSpec as '规格型号',fchrUnitName as '计量单位',flotQuotePrice as '商品单价'
                                              FROM item where 1=1");

            sql = string.Format(@"SELECT Count(1) FROM item where 1=1");

            //if (!string.IsNullOrEmpty(txtItemName.txtText.Trim()))
            //    rel += " and (fchrItemCode like '%" + txtItemName.txtText.Trim() + "%' or fchrItemName like '%" + txtItemName.txtText.Trim() + "%')";

            frmItemListRef ItemRef = new frmItemListRef(sql, sqlTlbName, txtItemName.txtText.Trim(), false, "商品", "", "商品编码");
            ItemRef.ShowDialog();
        }

        private void txtItemName_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == Keys.Enter)
            //{
            //    txtItemName_Button_Click(sender, e);
            //}
        }
    }
}
