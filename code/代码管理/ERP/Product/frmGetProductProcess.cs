using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Product
{
    public partial class frmGetProductProcess : BaseClass.frmBase
    {
        public BindingSource binDes;
        public frmGetProductProcess()
        {
            InitializeComponent();
        }

        public void DataBind(string strBill,string strTag)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("sp_GetProductProcess '"+strBill+"','"+strTag+"'");
            gcMain.DataSource = ds.Tables[0].DefaultView;
        }

        private void SetRow()
        {
            decimal decPrice;
            if (gvMain.FocusedRowHandle < 0) return;
            DataRow dr = gvMain.GetDataRow(gvMain.FocusedRowHandle);
            
            DataRow drItem = ((DataRowView)binDes.Current).Row;
            drItem["F_OrderBill"] = dr["F_LinkBill"];
            drItem["F_OrderID"] = dr["PAid"];
            drItem["F_ItemID"] = dr["F_ItemID"];
            drItem["F_ItemName"] = dr["F_ItemName"];
            drItem["F_Spec"] = dr["F_Spec"];
            drItem["F_Unit"] = dr["F_Unit"];
            drItem["F_DeptID"] = dr["F_DeptID"];
            drItem["F_ProcessID"] = dr["F_ProcessID"];
            drItem["F_Price"] = dr["F_WorkPrice"];
            drItem["F_Qty"] = dr["F_Qty"];
            drItem["F_ChangeQty"] = dr["F_Qty"];
            if (dr["F_WorkPrice"] == DBNull.Value)
                decPrice = 0;
            else
                decPrice = Convert.ToDecimal(dr["F_WorkPrice"]);
            drItem["F_Money"] = decPrice * Convert.ToDecimal(drItem["F_Qty"]);

            if (binDes.Position < binDes.Count)
                binDes.MoveNext();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            SetRow();
            this.DialogResult = DialogResult.OK;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SetRow();
        }
    }
}

