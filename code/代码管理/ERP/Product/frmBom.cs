using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Product
{
    public partial class frmBom : Common.frmBaseList
    {
        public frmBom()
        {
            InitializeComponent();
            splitContainer1.Panel1Collapsed = true;
            btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnImport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            strTable = "t_Bom";
            strKey = "F_BillID";
            strQuerySQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Color,b.F_Material ";
            strQuerySQL = strQuerySQL + "from t_Bom a ";
            strQuerySQL = strQuerySQL + "left join t_Item b ";
            strQuerySQL = strQuerySQL + "on a.F_ItemID = b.F_ID ";
            gcBase.BringToFront();
            tvItem.SendToBack();
        }

        protected override void refresh()
        {
            BindData();
        }

        protected override void CopyData()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.CopyData();
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmBomEdit myBomEdit = new frmBomEdit();
            myBomEdit.strItemID = dr["F_ItemID"].ToString();
            myBomEdit.ShowDialog();
            myBomEdit.Dispose();
        }

        protected override void New()
        {
            frmBomEdit myBomEdit = new frmBomEdit();
            myBomEdit.ShowDialog();
            myBomEdit.Dispose();
            BindData();
            base.New();
        }

        protected override void Edit()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmBomEdit myBomEdit = new frmBomEdit();
            myBomEdit.strBillID = dr["F_BillID"].ToString();
            myBomEdit.ShowDialog();
            myBomEdit.Dispose();
            BindData();
            base.Edit();
        }

        protected override void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Bom where F_BillID = '" + dr["F_BillID"].ToString() + "'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);
        }

        protected override void FocusedRowChange(object Sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
            base.FocusedRowChange(Sender, e);
            DataRow dr = gvBase.GetDataRow(e.FocusedRowHandle);
            tvItem.Nodes.Clear();
            TreeNode Node = tvItem.Nodes.Add(dr["F_ItemID"].ToString()+" "+dr["F_ItemName"].ToString());
            ExpandBom(Node, dr["F_ItemID"].ToString());
            tvItem.TopNode.Expand();
        }

        /// <summary>
        /// 展开Bom单
        /// </summary>
        protected void ExpandBom(TreeNode Node,string strItemID)
        {
            string strSQL,strItem;
            strSQL = "select c.F_ID,c.F_Name,c.F_Spec,b.F_Unit,b.F_Qty,b.F_Waste,b.F_ActuQty,c.F_Price ";
            strSQL = strSQL + "from t_Bom a,t_BomDetail b,t_Item c ";
            strSQL = strSQL + "where a.F_BillID = b.F_BillID ";
            strSQL = strSQL + "and b.F_ItemID = c.F_ID ";
            strSQL = strSQL + "and a.F_ItemID = '" + strItemID + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strItem = dr["F_ID"].ToString() + " " + dr["F_Name"].ToString() + " ";
                strItem = strItem + dr["F_Spec"].ToString() + " " + dr["F_Qty"].ToString();
                strItem = strItem + " " + dr["F_Unit"].ToString();
                TreeNode cNode = Node.Nodes.Add(strItem);
                ExpandBom(cNode, dr["F_ID"].ToString());
            }
        }
    }
}

