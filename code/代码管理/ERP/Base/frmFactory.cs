using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmFactory : Common.frmBaseList
    {
        public frmFactory()
        {
            InitializeComponent();
            btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            strTable = "t_Factory";
            strKey = "F_ID";
            strQuerySQL = "select * from t_Factory";
        }

        protected override void New()
        {
            base.New();
            frmEditFactory myEditFactory = new frmEditFactory();
            myEditFactory.New();
            myEditFactory.ShowDialog();
            myEditFactory.Dispose();
        }

        protected override void Edit()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Edit();
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmEditFactory myEditFactory = new frmEditFactory();
            myEditFactory.Edit(dr["F_ID"].ToString());
            myEditFactory.ShowDialog();
            myEditFactory.Dispose();
        }

        protected override void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Factory where F_ID = '"+dr["F_ID"].ToString()+"'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);    
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            FillTv("12",null);
        }
    }
}

