using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmMulCon : BaseClass.frmBase
    {
        public frmMulCon()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void sbSubject_Click(object sender, EventArgs e)
        {
            frmSubject mySubject = new frmSubject();
            if (mySubject.ShowDialog() == DialogResult.OK)
            {
                txtSubjectID.Text = mySubject.GetSubject();
                txtSubjectName.Text = mySubject.GetSubjectName() + "Ã÷Ï¸ÕÊ";
            }
            mySubject.Dispose();
        }

        private void SetDetail(string strSubject)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_Subject where F_UPID = '"+strSubject+"'");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                //dr["F_Direction"].ToString();
                //dr["F_ID"].ToString();
                //dr["F_Name"].ToString();
            }

            ds.Dispose();
        }
    }
}

