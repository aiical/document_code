using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommonData
{
    public partial class frmSelItem : BaseClass.frmBase
    {
        public frmSelItem()
        {
            InitializeComponent();
        }

        private void BindData()
        {
            
            string strSQL = "";
            strSQL = "select a.*,b.F_Name as F_Storage,c.F_Name as F_Unit ";
            strSQL = strSQL + "from t_Item a ";
            strSQL = strSQL + "left join t_Storage b ";
            strSQL = strSQL + "on a.F_StorageID = b.F_ID ";
            strSQL = strSQL + "left join t_Unit c ";
            strSQL = strSQL + "on a.F_ID = c.F_ItemID ";
            strSQL = strSQL + "and c.F_Main = 1 ";
            strSQL = strSQL + "where a.F_Kind = '" + cbKind.Text + "'";

            if (lupType.Text.Length > 0)
            {
                if (lupType.EditValue.ToString().Length > 0)
                {
                    strSQL = strSQL + "and a.F_Type = '" + lupType.EditValue.ToString() + "'";
                }
            }

            if (txtValue.Text.Length > 0)
            {
                strSQL = strSQL + "and ((a.F_ID = '" + txtValue.Text + "') or (a.F_Name like '%" + txtValue.Text + "%') or (a.F_Spec like '%" + txtValue.Text + "%'))";
            }


            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcMain.DataSource = ds.Tables[0].DefaultView;
        }

        private void BindStore()
        {
            string strSQL = "";
            strSQL = "select b.F_Name as F_Storage,c.F_ID,c.F_Name,c.F_Spec,";
            strSQL = strSQL + "a.F_Unit,a.F_BatchNo,a.F_Grade,a.F_ColorNum as F_Color,a.F_Qty,c.F_Price ";
            strSQL = strSQL + "from t_StorageQty a,t_Storage b,t_Item c ";
            strSQL = strSQL + "where a.F_StorageID = b.F_ID ";
            strSQL = strSQL + "and a.F_ItemID = c.F_ID ";
            strSQL = strSQL + "and c.F_Kind = '" + cbKind.Text + "'";

            if (lupType.Text.Length > 0)
            {
                if (lupType.EditValue.ToString().Length > 0)
                {
                    strSQL = strSQL + "and c.F_Type = '" + lupType.EditValue.ToString() + "'";
                }
            }
            
            if (txtValue.Text.Length > 0)
            {
                strSQL = strSQL + "and ((c.F_ID = '"+txtValue.Text+"') or (c.F_Name like '%"+txtValue.Text+"%') or (c.F_Spec like '%"+txtValue.Text+"%'))";
            }
             

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcStore.DataSource = ds.Tables[0].DefaultView;
        }

        private void frmSelItem_Load(object sender, EventArgs e)
        {

            string strSQL = "select F_ID,F_Name from t_Class where left(F_ID,2) = '04'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupType.Properties.DataSource = ds.Tables[0].DefaultView;
            lupType.Properties.DisplayMember = "F_Name";
            lupType.Properties.ValueMember = "F_ID";

            //BindData();
            //BindStore();
        }

        /*
        private void SetItem(int intFlag)
        {
            if (binDes == null) return;
            DataRow drDes = null;
            if (intFlag == 1)
                drDes = ((DataRowView)binDes.AddNew()).Row;
            else
                drDes = ((DataRowView)binDes.Current).Row;
            DataRow drSource = gvMain.GetDataRow(gvMain.FocusedRowHandle);
            drDes["F_ItemID"] = drSource["F_ID"];
            drDes["F_ItemName"] = drSource["F_Name"];
            drDes["F_Spec"] = drSource["F_Spec"];
            binDes.EndEdit();
        }
         */ 

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            //SetItem(1);
        }

        private void gvMain_DoubleClick(object sender, EventArgs e)
        {
            sbOK_Click(null, null);
        }

        private void TabControl_TabIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedTabPageIndex == 0)
                BindData();
            else
                BindStore();
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            TabControl_TabIndexChanged(null, null);
        }

       
    }
}

