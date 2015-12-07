using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmFinanceInit : BaseClass.frmBase
    {
        public frmFinanceInit()
        {
            InitializeComponent();
            TestcwInit();
        }

        /// <summary>
        /// 测试财务系统是否启用
        /// </summary>
        private void TestcwInit()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_cwInit from t_CompanyInfo");
            if (Convert.ToBoolean(ds.Tables[0].Rows[0][0]) == true)
                btnOK.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "真的要启用财务系统吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("update t_CompanyInfo set F_cwInit = 1,F_cwInitDate = '"+DateTime.Now+"'") == 0)
            {
                 MessageBox.Show(this, "财务系统启用成功！！", "提示");
            }
            btnOK.Enabled = false;
        }
    }
}
