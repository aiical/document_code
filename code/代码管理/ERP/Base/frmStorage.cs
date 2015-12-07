using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmStorage : Common.frmBaseList
    {
        public frmStorage()
        {
            InitializeComponent();
            splitContainer1.Panel1Collapsed = true;
            btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.tvType.ContextMenuStrip = null;
            strTable = "t_Storage";
            strKey = "F_ID";
            strQuerySQL = "select * from t_Storage";
        }

        protected override void New()
        {
            base.New();
            frmEditStorage myEditStorage = new frmEditStorage();
            myEditStorage.New();
            myEditStorage.ShowDialog();
            myEditStorage.Dispose();
            BindData();
        }

        protected override void Edit()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Edit();
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmEditStorage myEditStorage = new frmEditStorage();
            myEditStorage.Edit(dr["F_ID"].ToString());
            myEditStorage.ShowDialog();
            myEditStorage.Dispose();
            BindData();
        }

        protected override void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Storage where F_ID = '"+dr["F_ID"].ToString()+"'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);    
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            FillTv("05",null);
        }
    }
}

