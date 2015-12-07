using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmAssist : BaseClass.frmBase
    {
        public frmAssist()
        {
            InitializeComponent();
        }

        private void DataBind(string strType)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_Assist where F_Type = '" + strType + "'");
            gcAssist.DataSource = ds.Tables[0].DefaultView; 
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            frmEditAssist myEditAssist = new frmEditAssist();
            myEditAssist.strType = cbType.Text;
            if (myEditAssist.ShowDialog() == DialogResult.OK)
                DataBind(cbType.Text);
            myEditAssist.Dispose();
        }

        private void sbEdit_Click(object sender, EventArgs e)
        {
            if (gvAssist.FocusedRowHandle < 0) return;
            frmEditAssist myEditAssist = new frmEditAssist();
            myEditAssist.strType = cbType.Text;
            myEditAssist.strID = gvAssist.GetRowCellValue(gvAssist.FocusedRowHandle, "F_ID").ToString();
            myEditAssist.Edit(gvAssist.GetRowCellValue(gvAssist.FocusedRowHandle, "F_Name").ToString());
            if (myEditAssist.ShowDialog() == DialogResult.OK)
                DataBind(cbType.Text);
            myEditAssist.Dispose();
        }

        private void frmAssist_Load(object sender, EventArgs e)
        {
            DataBind(cbType.Text);
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBind(cbType.Text);
        }

        private void gvAssist_DoubleClick(object sender, EventArgs e)
        {
            sbEdit_Click(null, null);
        }

        private void sbDel_Click(object sender, EventArgs e)
        {
            if (gvAssist.FocusedRowHandle < 0) return;
            if (MessageBox.Show(this, "真的要删除选定记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataRow dr = gvAssist.GetDataRow(gvAssist.FocusedRowHandle);
            if (myHelper.ExecuteSQL("delete from t_Assist where F_Type = '" + dr["F_Type"].ToString() + "' and F_ID = '" + dr["F_ID"].ToString() + "'") == 0)
                gvAssist.DeleteRow(gvAssist.FocusedRowHandle);
        }
    }
}

