using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmCfCehckOut : BaseClass.frmBase
    {
        private int intYear, intMonth;
        public frmCfCehckOut()
        {
            InitializeComponent();
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
            }
            else
            {
                intYear = Convert.ToInt32(ds.Tables[0].Rows[0]["F_Year"]);
                intMonth = Convert.ToInt32(ds.Tables[0].Rows[0]["F_Month"]);
                intMonth = intMonth + 1;
                if (intMonth > 12)
                {
                    intMonth = 1;
                    intYear = intYear + 1;
                }
            }
            label1.Text = "当前会计年度:" + intYear.ToString();
            label2.Text = "当前会计月份:" + intMonth.ToString();
        }

        /// <summary>
        /// 结帐操作
        /// </summary>
        private void CheckOut()
        {
            if (MessageBox.Show(this, "真的要对当前月份进行会计结帐吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            string strSQL = "";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            DataSet ds = myHelper.GetDs("select top 1 * from t_Certificate where isnull(F_Record,0) = 0 and Year(F_Date) = " + intYear.ToString() + " and Month(F_Date) = " + intMonth.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(this,"本期存在未登帐的凭证,请先登帐,再进行此操作!","提示");
                return;
            }

            ds = myHelper.GetDs("select isnull(max(Aid),0) + 1 as F_MaxID from t_Period");
            decimal decID = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
            if (myHelper.ExecuteSQL("insert into t_Period(Aid,F_Year,F_Month) values(" + decID .ToString() + "," + intYear.ToString() + "," + intMonth.ToString() + ")") == 0)
            {
                strSQL = "insert into t_cwCheckOut(F_Year,F_Month,F_Subject,F_Debit,F_Credit) select " + intYear.ToString() + "," + intMonth.ToString() + ",b.F_Subject,sum(b.F_Debit),sum(b.F_Credit)";
                strSQL = strSQL + " from t_Certificate a,t_CertificateDetail b where a.F_ID = b.F_ID and Year(a.F_Date) = " + intYear.ToString() + " and Month(a.F_Date) = " + intMonth.ToString();
                strSQL = strSQL + " group by b.F_Subject";
 
                if (myHelper.ExecuteSQL(strSQL) == 0)
                {
                    MessageBox.Show(this, "本月结帐帐成功！！", "提示");
                    Close();
                }
            }

        }

        /// <summary>
        /// 反结帐操作
        /// </summary>
        private void UnCheckOut()
        {
            string strSQL = "";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            DataSet ds = myHelper.GetDs("select * from t_Period where F_Year = " + intYear.ToString() + " and F_Month = " + intMonth.ToString());

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(this, "本期还没结帐，不能进行此操作!", "提示");
                return;
            }
            if (MessageBox.Show(this, "真的要对当前月份进行会计反结帐吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            ds = myHelper.GetDs("select isnull(max(Aid),0) + 1 as F_MaxID from t_Period");
            decimal decID = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
            if (myHelper.ExecuteSQL("delete from t_Period where F_Year = " + intYear.ToString() + " and F_Month = " + intMonth.ToString()) == 0)
            {
                strSQL = "delete from t_cwCheckOut where F_Year = " + intYear.ToString() + " and F_Month = " + intMonth.ToString();

                if (myHelper.ExecuteSQL(strSQL) == 0)
                {
                    MessageBox.Show(this, "本期反结帐帐成功！！", "提示");
                    Close();
                }
            }

        }


        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCfCehckOut_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
               GetPeriod();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            CheckOut();
        }

        private void sbUnOk_Click(object sender, EventArgs e)
        {
            UnCheckOut();
        }
    }
}

