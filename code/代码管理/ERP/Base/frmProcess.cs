using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmProcess : Common.frmBaseList
    {
        public frmProcess()
        {
            InitializeComponent();
            //btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            strTable = "t_Process";
            strKey = "F_ID";
            strQuerySQL = "select a.*,b.F_Name as F_DeptName from t_Process a,t_Class b where a.F_DeptID = b.F_ID and (a.F_DeptID like @Value or @Value = '')";
        }

        protected override void New()
        {
            base.New();
            frmEditProcess myEditProcess = new frmEditProcess();
            myEditProcess.strType = tvType.SelectedNode.Tag.ToString();
            myEditProcess.New();
            if (myEditProcess.ShowDialog() == DialogResult.OK)
                BindData();
            myEditProcess.Dispose();
        }

        protected override void Edit()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Edit();
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmEditProcess myEditProcess = new frmEditProcess();
            myEditProcess.Edit(dr["F_ID"].ToString());
            if (myEditProcess.ShowDialog() == DialogResult.OK)
                BindData();
            myEditProcess.Dispose();
        }

        protected override void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Process where F_ID = '"+dr["F_ID"].ToString()+"'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);
            
           
        }

        private void frmEmp_Load(object sender, EventArgs e)
        {
            tvType.SendToBack();
            FillTv("03", null);
        }
    }
}

