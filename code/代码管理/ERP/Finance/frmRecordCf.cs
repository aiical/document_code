using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmRecordCf : BaseClass.frmBase
    {
        private int intYear, intMonth;
        public frmRecordCf()
        {
            InitializeComponent();
        }

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
            label2.Text = "当前会计年度:" + intYear.ToString();
            label3.Text = "当前会计月份:" + intMonth.ToString();
        }

        private void Record()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select top 1 * from t_Certificate where isnull(F_Check,0) = 0 and Year(F_Date) = " + intYear.ToString() + " and Month(F_Date) = " + intMonth.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(this, "本期存在未审核的凭证,请先审核,再进行此操作!", "提示");
                return;
            }

            if (MessageBox.Show(this, "真的要对当前期间进行会计登帐吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            
            if (myHelper.ExecuteSQL("update t_Certificate set F_Record =  1,F_reChecker = '"+DataLib.SysVar.strUName+"' where Year(F_Date) = " + intYear.ToString() + " and Month(F_Date) = " + intMonth.ToString()) == 0)
            {
                MessageBox.Show(this, "本期凭证登帐成功！！", "提示");
                Close();
            }
        }

        private void UnRecord()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_Period where F_Year = " + intYear.ToString() + " and F_Month = " + intMonth.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(this, "本期已结过帐,请对本期反结帐后再进行此操作!", "提示");
                return;
            }

            if (MessageBox.Show(this, "真的要对当前期间进行会计反登帐吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            
            if (myHelper.ExecuteSQL("update t_Certificate set F_Record =  0,F_reChecker = '' where Year(F_Date) = " + intYear.ToString() + " and Month(F_Date) = " + intMonth.ToString()) == 0)
            {
                MessageBox.Show(this, "本期凭证反登帐成功！！", "提示");
                Close();
            }
        }


        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmRecordCf_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
                GetPeriod();
        }

        private void cbRecord_Click(object sender, EventArgs e)
        {
            Record();
        }

        private void sbUnRecord_Click(object sender, EventArgs e)
        {
            UnRecord();
        }
    }
}

