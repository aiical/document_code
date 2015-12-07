using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cash
{
    public partial class frmCashCheckOut : BaseClass.frmBase
    {
        public frmCashCheckOut()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void spinEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmCashCheckOut_Load(object sender, EventArgs e)
        {
            spYear.Value = DateTime.Today.Year;
            spMonth.Value = DateTime.Today.Month;
        }

        private void CheckOut()
        {
            if (MessageBox.Show(this, "真的要对本期间进行结帐吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_User where F_ID = '"+DataLib.SysVar.strUID+"' and F_Psw = '"+textBox1.Text+"'");
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(this, "用户密码错误，请检查!!", "提示");
                return;
            }
            if (myHelper.ExecuteSQL("exec sp_CashCheckOut " + spYear.Value.ToString() + "," + spMonth.Value.ToString()) == 0)
            {
                MessageBox.Show(this, "出纳结帐成功!!", "提示");
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            CheckOut();
        }
    }
}

