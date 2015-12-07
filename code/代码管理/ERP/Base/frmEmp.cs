using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmEmp : Common.frmBaseList
    {
        public frmEmp()
        {
            InitializeComponent();
            intImport = 3;
            btnImport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            strTable = "t_Emp";
            strKey = "F_ID";
            strQuerySQL = "select a.*,b.F_Name as F_TypeName ";
            strQuerySQL = strQuerySQL + "from t_Emp a ";
            strQuerySQL = strQuerySQL + "left join t_Class b ";
            strQuerySQL = strQuerySQL + "on a.F_Type = b.F_ID ";
            strQuerySQL = strQuerySQL + "where (a.F_Type like @Value or @Value = '')";
        }

        protected override void New()
        {
            base.New();
            frmEditEmp myEditEmp = new frmEditEmp();
            myEditEmp.strType = tvType.SelectedNode.Tag.ToString();
            myEditEmp.New();
            if (myEditEmp.ShowDialog() == DialogResult.OK)
                BindData();
            myEditEmp.Dispose();
        }

        protected override void Edit()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Edit();
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmEditEmp myEditEmp = new frmEditEmp();
            myEditEmp.Edit(dr["F_ID"].ToString());
            if (myEditEmp.ShowDialog() == DialogResult.OK)
                BindData();
            myEditEmp.Dispose();
        }

        protected override void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Emp where F_ID = '"+dr["F_ID"].ToString()+"'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);
            
           
        }

        private void frmEmp_Load(object sender, EventArgs e)
        {
            FillTv("03", null);
        }
    }
}

