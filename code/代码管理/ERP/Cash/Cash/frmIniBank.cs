using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cash
{
    public partial class frmIniBank : BaseClass.frmBase
    {
        public frmIniBank()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TestIni()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_Bank,F_BankIni from t_CashInit");
            spinEdit1.Value = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
            if (Convert.ToBoolean(ds.Tables[0].Rows[0][0]) == true)
            {
                spinEdit1.Enabled = false;
                sbOK.Enabled = false;
            }

        }

        private void BankIni()
        {
            if (MessageBox.Show(this, "启用期初后将不能再修改，真的要启用银行期初吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("update t_CashInit set F_BankIni = "+spinEdit1.Value.ToString()+",F_Bank = 1") == 0)
            {
                spinEdit1.Enabled = false;
                sbOK.Enabled = false;
                MessageBox.Show(this, "银行期初启用成功!!", "提示");
            }
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            BankIni();
        }

        private void frmIniBank_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
                TestIni();
        }
    }
}

