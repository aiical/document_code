using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmAddType : BaseClass.frmBase
    {
        public frmAddType()
        {
            InitializeComponent();
        }

        private void DataBind()
        {
            string strSQL = "select * from t_AddType";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds == null) return;
            gcMain.DataSource = ds.Tables[0].DefaultView;

        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            DataBind();
        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            frmEditAddType myEditAddType = new frmEditAddType();
            myEditAddType.DataBind("");
            if (myEditAddType.ShowDialog() == DialogResult.OK)
                DataBind();
            myEditAddType.Dispose();
        }

        private void sbEdit_Click(object sender, EventArgs e)
        {
            if (gvMain.FocusedRowHandle < 0) return;
            DataRow dr = gvMain.GetDataRow(gvMain.FocusedRowHandle);
            frmEditAddType myEditAddType = new frmEditAddType();
            myEditAddType.DataBind(dr["F_Name"].ToString());
            if (myEditAddType.ShowDialog() == DialogResult.OK)
                DataBind();
            myEditAddType.Dispose();
        }

        private void sbDel_Click(object sender, EventArgs e)
        {
            if (gvMain.FocusedRowHandle < 0) return;
            if (MessageBox.Show(this, "真的要删除选定用户吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_AddType where F_Name = '" + gvMain.GetRowCellValue(gvMain.FocusedRowHandle, "F_Name").ToString() + "'") == 0)
               gvMain.DeleteRow(gvMain.FocusedRowHandle);
       }
    }
}

