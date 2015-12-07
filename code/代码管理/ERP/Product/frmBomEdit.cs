using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Product
{
    public partial class frmBomEdit : Common.frmBill
    {
        public string strItemID = "";
        private string strMainItem = "";
        private bool bBreak = false;
        public frmBomEdit()
        {
            InitializeComponent();
        }

        public void CopyBom()
        {
            string strSQL = "";
            strSQL = @"select b.*,c.F_Name as F_ItemName,c.F_Spec,c.F_Brand,c.F_Color,c.F_Material,c.F_StockPrice as F_Price from t_Bom a,t_BomDetail b,t_Item c 
                       where a.F_BillID = b.F_BillID 
                       and b.F_ItemID = c.F_ID 
                       and a.F_ItemID = '"+strItemID+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DataRow drNew = ((DataRowView)binSlaver.AddNew()).Row;
                drNew["F_ItemID"] = dr["F_ItemID"];
                drNew["F_ItemName"] = dr["F_ItemName"];
                drNew["F_Spec"] = dr["F_Spec"];
                drNew["F_Unit"] = dr["F_Unit"];
                drNew["F_Brand"] = dr["F_Brand"];
                drNew["F_Color"] = dr["F_Color"];
                drNew["F_Qty"] = dr["F_Qty"];
                drNew["F_Waste"] = dr["F_Waste"];
                drNew["F_ActuQty"] = dr["F_ActuQty"];
                drNew["F_DeptID"] = dr["F_DeptID"];
                drNew["F_ProcessID"] = dr["F_ProcessID"];
                drNew["F_Remark"] = dr["F_Remark"];
                drNew["F_Price"] = dr["F_Price"];
            }
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
            
        }

        protected override bool SavePre()
        {
            if (base.SavePre() == false) return false;
            string strItemID = editControl6.GetValue().ToString();
            strMainItem = strItemID;
            DataTable dt = ((DataView)binSlaver.DataSource).Table;
            DataRow[] drTmp = dt.Select("F_ItemID = '"+strItemID+"'");
            if (drTmp.Length > 0)
            {
                MessageBox.Show(this,"主件不能存在于子件中!!","提示");
                return false;
            }

            string strSQL = "";
            bool bFlag = false;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            foreach (DataRow dr in dt.Rows)
            {
                strSQL = "select a.F_ItemID from t_Bom a,t_BomDetail b ";
                strSQL = strSQL + "where a.F_BillID = b.F_BillID ";
                strSQL = strSQL + "and a.F_ItemID = '" + dr["F_ItemID"].ToString() + "'";
                strSQL = strSQL + "and b.F_ItemID = '" + strItemID + "'";
                DataSet ds = myHelper.GetDs(strSQL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(this, "主件" + strItemID + "跟子件" + dr["F_ItemID"].ToString() + "将会导致死循环,请检查!!", "提示");
                    bFlag = true;
                    break;
                }
                ds.Dispose();
                bBreak = false;
                TestBomValid(dr["F_ItemID"].ToString());
                if (bBreak == true)
                {
                    bFlag = true;
                    break;
                }
            }

            if (bFlag == true)
                return false;
            else
                return true;
        }

        private void sbSelItem_Click(object sender, EventArgs e)
        {

            Common.frmSelItem mySelItem = new Common.frmSelItem();
            mySelItem.intTag = 1;
            if (mySelItem.ShowDialog() == DialogResult.OK)
            {
                if (mySelItem.TabControl.SelectedTabPageIndex == 0)
                {
                    if (mySelItem.gvMain.FocusedRowHandle >= 0)
                    {
                        DataRow dr = mySelItem.gvMain.GetDataRow(mySelItem.gvMain.FocusedRowHandle);
                        DataLib.sysClass myClass = new DataLib.sysClass();
                        DataRow drItem = myClass.FindItem(dr["F_ID"].ToString());
                        DataTable dt = ((DataView)binMaster.DataSource).Table;
                        DataRow drNew = dt.Rows[0];
                        drNew["F_ItemID"] = drItem["F_ID"];
                        editControl7.SetValue(drItem["F_Name"].ToString());
                        editControl8.SetValue(drItem["F_Spec"].ToString());
                        editControl9.SetValue(drItem["F_Unit"].ToString());
                        binMaster.EndEdit();
                    }
                }
                else
                {
                    if (mySelItem.gvStore.FocusedRowHandle >= 0)
                    {
                        DataRow dr = mySelItem.gvStore.GetDataRow(mySelItem.gvStore.FocusedRowHandle);
                        DataLib.sysClass myClass = new DataLib.sysClass();
                        DataRow drItem = myClass.FindItem(dr["F_ID"].ToString());
                        DataTable dt = ((DataView)binMaster.DataSource).Table;
                        DataRow drNew = dt.Rows[0];
                        drNew["F_ItemID"] = drItem["F_ID"];
                        editControl7.SetValue(drItem["F_Name"].ToString());
                        editControl8.SetValue(drItem["F_Spec"].ToString());
                        editControl9.SetValue(drItem["F_Unit"].ToString());
                        binMaster.EndEdit();
                    }
                }
            }
            mySelItem.Dispose();
        }

        protected override void SlaverNewRow(object Sender, DataTableNewRowEventArgs e)
        {
            base.SlaverNewRow(Sender, e);
            e.Row["F_Waste"] = 0;
        }

        protected override void CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            object objQty,objWaste;

            base.CellValueChanged(sender, e);
            if (e.Column.FieldName == "F_Waste")
            {
                objQty = gvList.GetRowCellValue(e.RowHandle,"F_Qty");
                objWaste = e.Value;

                if (objWaste != DBNull.Value && objQty != DBNull.Value)
                    gvList.SetRowCellValue(e.RowHandle,"F_ActuQty",Convert.ToDecimal(objQty) *  (1 + Convert.ToDecimal(objWaste)/100));
                else
                    gvList.SetRowCellValue(e.RowHandle,"F_ActuQty",0);
            }

            if (e.Column.FieldName == "F_Qty")
            {
                 objWaste = gvList.GetRowCellValue(e.RowHandle,"F_Waste");
                 objQty = e.Value;

                if (objWaste != DBNull.Value && objQty != DBNull.Value)
                    gvList.SetRowCellValue(e.RowHandle,"F_ActuQty",Convert.ToDecimal(objQty) * (1 + Convert.ToDecimal(objWaste)/100));
                else
                    gvList.SetRowCellValue(e.RowHandle,"F_ActuQty",0);
            }
        }

        /// <summary>
        /// 检查BOM是否死循环
        /// </summary>
        private bool TestBomValid(string strItemID)
        {
            string strSQL,strItem;
            bool bFlag = true;

            strSQL = "select b.F_ItemID from t_Bom a,t_BomDetail b ";
            strSQL = strSQL + "where a.F_BillID = b.F_BillID ";
            strSQL = strSQL + "and a.F_ItemID = '" + strItemID + "'";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                strItem = dr["F_ItemID"].ToString();
                if (strItem == strMainItem)
                {
                    MessageBox.Show(this,"子件"+strItem+"跟主件"+strMainItem+"将导致死循环,请检查!!", "提示");
                    bBreak = true;
                    break;
                }
                else
                {
                    TestBomValid(dr["F_ItemID"].ToString());
                }
            }

            return bFlag;
        }

        private void frmBomEdit_Shown(object sender, EventArgs e)
        {
            strBillFlag = "BM";
            strMTable = "t_Bom";
            strMasterSQL = "select * from t_Bom where F_BillID = @Value";

            strSlaverSQL = @"select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Brand,b.F_Color,b.F_StockPrice as F_Price 
                             from t_BomDetail a,t_Item b 
                             where a.F_ItemID = b.F_ID 
                             and F_BillID = '" + strBillID + @"' order by a.Aid";

            strSaveSlaverSQL = "select * from t_BomDetail where F_BillID = @Value";

            if (strBillID == "")
            {
                NewBill();
                if (strItemID != "")
                    CopyBom();
            }
            else
            {
                BindData();
                DataRow dr = ((DataRowView)binMaster.Current).Row;
                DataLib.sysClass myClass = new DataLib.sysClass();
                DataRow drItem = myClass.FindItem(dr["F_ItemID"].ToString());
                if (drItem != null)
                {
                    editControl7.SetValue(drItem["F_Name"].ToString());
                    editControl8.SetValue(drItem["F_Spec"].ToString());
                    editControl9.SetValue(drItem["F_Unit"].ToString());
                }
            }
        }

    }
}

