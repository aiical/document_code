using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmCheckLoss : BaseClass.frmBase
    {
        private int intYear, intMonth;
        public frmCheckLoss()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 取得相应月份
        /// </summary>
        private void GetPeriod()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select top 1 * from t_Period order by AID Desc");
            if (ds.Tables[0].Rows.Count == 0)
            {
                ds = myHelper.GetDs("select F_cwInitDate from t_companyInfo");
                intYear = Convert.ToDateTime(ds.Tables[0].Rows[0]["F_cwInitDate"]).Year;
                intMonth = Convert.ToDateTime(ds.Tables[0].Rows[0]["F_cwInitDate"]).Month;
                return;
            }
            intYear = Convert.ToInt32(ds.Tables[0].Rows[0]["F_Year"]);
            intMonth = Convert.ToInt32(ds.Tables[0].Rows[0]["F_Month"]);
            intMonth = intMonth + 1;
            if (intMonth > 12)
            {
                intMonth = 1;
                intYear = intYear + 1;
            }
            //label1.Text = "当前会计年度:" + intYear.ToString();
            //label2.Text = "当前会计月份:" + intMonth.ToString();
        }

        /// <summary>
        /// 结转损益操作
        /// </summary>
        private void CheckLoss()
        {
            if (MessageBox.Show(this, "真的要对本期进行结转损益吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            string strSQL = "";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            strSQL = "insert into t_ProfitLoss(F_Year,F_Month,F_Subject,F_Debit,F_Credit) select " + intYear.ToString() + "," + intMonth.ToString() + ",b.F_Subject,sum(b.F_Debit),sum(b.F_Credit)";
            strSQL = strSQL + " from t_Certificate a,t_CertificateDetail b where a.F_ID = b.F_ID and Year(a.F_Date) = " + intYear.ToString() + " and Month(a.F_Date) = " + intMonth.ToString();
            strSQL = strSQL + " group by b.F_Subject";
            if (myHelper.ExecuteSQL(strSQL) == 0)
            {
                MessageBox.Show(this, "结转损益成功！！", "提示");
                Close();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CheckLoss();
        }
    }
}

