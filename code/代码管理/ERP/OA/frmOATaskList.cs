using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace OA
{
    public partial class frmOATaskList : OA.frmViewList
    {
        public frmOATaskList()
        {
            InitializeComponent();
        }

        protected override void New()
        {
            base.New();
            frmEditOATask myEditOATask = new frmEditOATask();
            myEditOATask.New();
            if (myEditOATask.ShowDialog() == DialogResult.OK)
                BindData();
            myEditOATask.Dispose();
        }

        protected override void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            base.Edit();
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            frmEditOATask myEditOATask = new frmEditOATask();
            myEditOATask.Edit(dr["Aid"].ToString());
            if (myEditOATask.ShowDialog() == DialogResult.OK)
                BindData();
            myEditOATask.Dispose();
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
            if (myHelper.ExecuteSQL("delete from t_OATask where Aid = " + dr["Aid"].ToString()) == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);


        }

        protected override System.Collections.Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Start", ucDate.dtStart);
            parm.Add("@End", ucDate.dtEnd);
            parm.Add("@Flag", cbFlag.SelectedIndex);
            return parm;
        }

        private void cbFlag_SelectIndexChange(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
