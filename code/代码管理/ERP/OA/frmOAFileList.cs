using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OA
{
    public partial class frmOAFileList : OA.frmViewList
    {
        public frmOAFileList()
        {
            InitializeComponent();
        }

        protected override void New()
        {
            base.New();
            frmEditOAFile myEditOAFile = new frmEditOAFile();
            myEditOAFile.New();
            if (myEditOAFile.ShowDialog() == DialogResult.OK)
                BindData();
            myEditOAFile.Dispose();
        }

        protected override void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            base.Edit();
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            frmEditOAFile myEditOAFile = new frmEditOAFile();
            myEditOAFile.Edit(dr["Aid"].ToString());
            if (myEditOAFile.ShowDialog() == DialogResult.OK)
                BindData();
            myEditOAFile.Dispose();
        }

        /// <summary>
        /// 重写基类删除方法
        /// </summary>
        protected override void Del()
        {
            if (gvList.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_OAFile where Aid = " + dr["Aid"].ToString()) == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);


        }
    }
}
