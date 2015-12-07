using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmProductProcessList : Common.frmBaseList
    {
        public frmProductProcessList()
        {
            InitializeComponent();
            splitContainer1.Panel1Collapsed = true;
            btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            Common.XtraChinese p = new Common.XtraChinese();
            p.chineseXtraGrid(this.gcDetail);
            strTable = "t_ProductProcess";
            strKey = "F_BillID";
            strQuerySQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec from t_ProductProcess a,t_Item b where a.F_ItemID = b.F_ID";
        }

        private void RefreshDetail(string strID)
        {
            string strSQL;
            strSQL = "select a.F_BillID,a.Aid,b.F_Name as F_Dept,c.F_Name as F_Process,a.F_Remark,a.F_WorkHour,a.F_WorkPrice,a.F_LastProcess ";
            strSQL = strSQL + "from t_ProductProcessDetail a,t_Class b,t_Process c ";
            strSQL = strSQL + "where a.F_DeptID = b.F_ID ";
            strSQL = strSQL + "and a.F_ProcessID = c.F_ID ";
            strSQL = strSQL + "and a.F_BillID = '" + strID + "'";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcDetail.DataSource = ds.Tables[0].DefaultView;
        }

        protected override void FocusedRowChange(object Sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            base.FocusedRowChange(Sender, e);
            if (e.FocusedRowHandle < 0) return;
            DataRow dr = gvBase.GetDataRow(e.FocusedRowHandle);
            RefreshDetail(dr["F_BillID"].ToString());
        }


        protected override void New()
        {
            base.New();
            frmProductProcess myProductProcess = new frmProductProcess();
            myProductProcess.ShowDialog();
            myProductProcess.Dispose();
            BindData();
        }

        protected override void Edit()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Edit();
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmProductProcess myProductProcess = new frmProductProcess();
            myProductProcess.strBillID = dr["F_BillID"].ToString();
            myProductProcess.ShowDialog();
            myProductProcess.Dispose();
            BindData();
        }

        protected override void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_ProductProcess where F_BillID = '" + dr["F_BillID"].ToString() + "'") == 0)
                BindData();
        }
    }
}

