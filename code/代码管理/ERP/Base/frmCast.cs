using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmCast : Common.frmBaseList
    {
        public frmCast()
        {
            InitializeComponent();
            btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            Common.XtraChinese p = new Common.XtraChinese();
            p.chineseXtraGrid(this.gcDetail);
            gcDetail.SendToBack();
            strTable = "t_Cast";
            strKey = "F_ID";
            strQuerySQL = "select * from t_Cast";
        }

        private void RefreshDetail(string strID)
        {
            string strSQL;
            strSQL = @"select a.F_ID,a.Aid,a.F_ItemID,b.F_Name as F_ItemName
                        from t_CastDetail a,t_Item b
                        where a.F_ItemID = b.F_ID 
                        and a.F_ID = '" + strID + "'";

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
            frmEditCast myEditCast = new frmEditCast();
            myEditCast.New();
            myEditCast.ShowDialog();
            myEditCast.Dispose();
            BindData();
        }

        protected override void Edit()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Edit();
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmEditCast myEditCast = new frmEditCast();
            myEditCast.Edit(dr["F_ID"].ToString());
            myEditCast.ShowDialog();
            myEditCast.Dispose();
            BindData();
        }

        protected override void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Cast where F_ID = '" + dr["F_ID"].ToString() + "'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);    
        }
    }
}

