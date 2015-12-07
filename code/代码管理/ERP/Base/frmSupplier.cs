using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmSupplier : Common.frmBaseList
    {
        public frmSupplier()
        {
            InitializeComponent();
            intImport = 1;
            btnImport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            strTable = "t_Supplier";
            strKey = "F_ID";
            strQuerySQL = "select a.*,b.F_Name as F_TypeName ";
            strQuerySQL = strQuerySQL + "from t_Supplier a ";
            strQuerySQL = strQuerySQL + "left join t_Class b ";
            strQuerySQL = strQuerySQL + "on a.F_Type = b.F_ID ";
            strQuerySQL = strQuerySQL + "where (a.F_Type like @Value or @Value = '')";
        }

        protected override void New()
        {
             if (TestRight("新增") == false) return;
            base.New();
            frmEditSupplier myEditSupplier = new frmEditSupplier();
            myEditSupplier.strType = tvType.SelectedNode.Tag.ToString();
            myEditSupplier.New();
            if (myEditSupplier.ShowDialog() == DialogResult.OK)
                BindData();
            myEditSupplier.Dispose();
        }

        protected override void Edit()
        {
            if (TestRight("编辑") == false) return;
            if (gvBase.FocusedRowHandle < 0) return;
            base.Edit();
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmEditSupplier myEditSupplier = new frmEditSupplier();
            myEditSupplier.Edit(dr["F_ID"].ToString());
            if (myEditSupplier.ShowDialog() == DialogResult.OK)
                BindData();
            myEditSupplier.Dispose();
        }

        protected override void Del()
        {
            if (TestRight("删除") == false) return;
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Supplier where F_ID = '"+dr["F_ID"].ToString()+"'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);
        }

        protected override void Export()
        {
            if (TestRight("引出") == false) return;
            base.Export();
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            FillTv("01", null);
        }
    }
}

