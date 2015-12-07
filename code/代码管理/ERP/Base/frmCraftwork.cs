using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmCraftwork : Common.frmBaseList
    {
        public frmCraftwork()
        {
            InitializeComponent();
            splitContainer1.Panel1Collapsed = true;
            btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            Common.XtraChinese p = new Common.XtraChinese();
            p.chineseXtraGrid(this.gcDetail);
            strTable = "t_Craftwork";
            strKey = "F_ID";
            strQuerySQL = "select * from t_Craftwork";
        }

        private void RefreshDetail(string strID)
        {
            string strSQL;
            strSQL = "select a.F_ID,a.Aid,b.F_Name as F_Dept,c.F_Name as F_Process,a.F_Remark ";
            strSQL = strSQL + "from t_CraftworkDetail a,t_Class b,t_Process c ";
            strSQL = strSQL + "where a.F_DeptID = b.F_ID ";
            strSQL = strSQL + "and a.F_ProcessID = c.F_ID ";
            strSQL = strSQL + "and a.F_ID = '" + strID + "'";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcDetail.DataSource = ds.Tables[0].DefaultView;
        }

        protected override void FocusedRowChange(object Sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            base.FocusedRowChange(Sender, e);
            if (e.FocusedRowHandle < 0) return;
            DataRow dr = gvBase.GetDataRow(e.FocusedRowHandle);
            RefreshDetail(dr["F_ID"].ToString());
        }


        protected override void New()
        {
            base.New();
            frmEditCraftwork myEditCraftwork = new frmEditCraftwork();
            myEditCraftwork.New();
            myEditCraftwork.ShowDialog();
            myEditCraftwork.Dispose();
            BindData();
        }

        protected override void Edit()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Edit();
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmEditCraftwork myEditCraftwork = new frmEditCraftwork();
            myEditCraftwork.Edit(dr["F_ID"].ToString());
            myEditCraftwork.ShowDialog();
            myEditCraftwork.Dispose();
            BindData();
        }

        protected override void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Craftwork where F_ID = '" + dr["F_ID"].ToString() + "'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);    
        }
    }
}

