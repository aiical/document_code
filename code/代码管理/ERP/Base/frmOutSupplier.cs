using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmOutSupplier : Common.frmBaseList
    {
        public frmOutSupplier()
        {
            InitializeComponent();
            intImport = 6;
            btnImport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            strTable = "t_OutSupplier";
            strKey = "F_ID";
            tvType.SendToBack();
            strQuerySQL = "select a.*,b.F_Name as F_TypeName ";
            strQuerySQL = strQuerySQL + "from t_OutSupplier a ";
            strQuerySQL = strQuerySQL + "left join t_Class b ";
            strQuerySQL = strQuerySQL + "on a.F_Type = b.F_ID ";
            strQuerySQL = strQuerySQL + "where (a.F_Type like @Value or @Value = '')";
        }

        protected override void New()
        {
            base.New();
            frmEditOutSupplier myEditOutSupplier = new frmEditOutSupplier();
            myEditOutSupplier.strType = tvType.SelectedNode.Tag.ToString();
            myEditOutSupplier.New();
            if (myEditOutSupplier.ShowDialog() == DialogResult.OK)
                BindData();
            myEditOutSupplier.Dispose();
        }

        protected override void Edit()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Edit();
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmEditOutSupplier myEditOutSupplier = new frmEditOutSupplier();
            myEditOutSupplier.Edit(dr["F_ID"].ToString());
            if (myEditOutSupplier.ShowDialog() == DialogResult.OK)
                BindData();
            myEditOutSupplier.Dispose();
        }

        protected override void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_OutSupplier where F_ID = '"+dr["F_ID"].ToString()+"'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            FillTv("09", null);
        }
    }
}

