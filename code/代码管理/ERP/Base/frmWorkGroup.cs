using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmWorkGroup : Common.frmBaseList
    {
        public frmWorkGroup()
        {
            InitializeComponent();
            //btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            strQuerySQL = "select a.*,b.F_Name as F_DeptName from t_WorkGroup a,t_Class b where a.F_DeptID = b.F_ID and (a.F_DeptID like @Value or @Value = '')";
        }

        protected override void New()
        {
            base.New();
            frmEditWorkGroup myEditWorkGroup = new frmEditWorkGroup();
            myEditWorkGroup.strType = tvType.SelectedNode.Tag.ToString();
            myEditWorkGroup.New();
            if (myEditWorkGroup.ShowDialog() == DialogResult.OK)
                BindData();
            myEditWorkGroup.Dispose();
        }

        protected override void Edit()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Edit();
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmEditWorkGroup myEditWorkGroup = new frmEditWorkGroup();
            myEditWorkGroup.Edit(dr["F_ID"].ToString());
            if (myEditWorkGroup.ShowDialog() == DialogResult.OK)
                BindData();
            myEditWorkGroup.Dispose();
        }

        protected override void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_WorkGroup where F_ID = '"+dr["F_ID"].ToString()+"'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);
            
           
        }

        private void frmEmp_Load(object sender, EventArgs e)
        {
            tvType.SendToBack();
            FillTv("03", null);
        }
    }
}

