using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmCertificateList : Common.frmBillList
    {
        public frmCertificateList()
        {
            InitializeComponent();
        }

        protected override void New()
        {
            //base.New();
            Finance.frmCertificate myCertificate = new Finance.frmCertificate();
            myCertificate.decID = 0;
            myCertificate.ShowDialog();
            myCertificate.Dispose();
            BindData();
        }

        protected override void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            //base.Edit();
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            Finance.frmCertificate myCertificate = new Finance.frmCertificate();
            myCertificate.decID = Convert.ToDecimal(dr["F_ID"]);
            myCertificate.ShowDialog();
            myCertificate.Dispose();
            BindData();
        }

        /// <summary>
        /// 删除
        /// </summary>
        protected override void Del()
        {
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            if (Convert.ToBoolean(dr["F_Check"]) == true)
            {
                MessageBox.Show(this, "不能删除已审核的单据！！", "提示");
                return;
            }
            if (MessageBox.Show(this, "真的要删除选定单据吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Certificate where F_ID = " + dr["F_ID"].ToString()) == 0)
                BindData();

            base.Del();
        }
    }
}

