using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmDevice : Common.frmBaseList
    {
        public frmDevice()
        {
            InitializeComponent();
            intImport = 1;
            btnImport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            strTable = "t_DeviceInfo";
            strKey = "F_ID";
            strQuerySQL = "select a.*,b.F_Name as F_TypeName ";
            strQuerySQL = strQuerySQL + "from t_DeviceInfo a ";
            strQuerySQL = strQuerySQL + "left join t_Class b ";
            strQuerySQL = strQuerySQL + "on a.F_Type = b.F_ID ";
            strQuerySQL = strQuerySQL + "where (a.F_Type like @Value or @Value = '')";
        }

        protected override void New()
        {
            base.New();
            frmEditDevice myEditDevice = new frmEditDevice();
            myEditDevice.strType = tvType.SelectedNode.Tag.ToString();
            myEditDevice.New();
            if (myEditDevice.ShowDialog() == DialogResult.OK)
                BindData();
            myEditDevice.Dispose();
        }

        protected override void Edit()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Edit();
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmEditDevice myEditDevice = new frmEditDevice();
            myEditDevice.Edit(dr["F_ID"].ToString());
            if (myEditDevice.ShowDialog() == DialogResult.OK)
                BindData();
            myEditDevice.Dispose();
        }

        protected override void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_DeviceInfo where F_ID = '"+dr["F_ID"].ToString()+"'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            FillTv("12", null);
        }
    }
}

