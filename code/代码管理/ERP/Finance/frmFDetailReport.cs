using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmFDetailReport : Common.frmReport
    {
        public frmFDetailReport()
        {
            InitializeComponent();
        }

        public frmFDetailReport(string strSubject,int intYear,int intMonth)
        {
            InitializeComponent();
            spYear.Value = intYear;
            cbBegin.SelectedIndex = intMonth;
            edSubject.SetValue(strSubject);
        }


        private void GetPeriod()
        {
            int intYear, intMonth;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select top 1 * from t_Period order by AID Desc");
            if (ds.Tables[0].Rows.Count == 0) return;
            intYear = Convert.ToInt32(ds.Tables[0].Rows[0]["F_Year"]);
            intMonth = Convert.ToInt32(ds.Tables[0].Rows[0]["F_Month"]);
            intMonth = intMonth + 1;
            if (intMonth > 12)
            {
                intMonth = 1;
                intYear = intYear + 1;
            }
            spYear.Value = intYear;
            cbBegin.SelectedIndex = intMonth - 1;
            cbEnd.SelectedIndex = intMonth - 1;
        }

        protected override Hashtable GetParm()
        {
            string strValue = "";
            if (edSubject.GetValue() != null)
                strValue = edSubject.GetValue().ToString();
            Hashtable parm = new Hashtable();
            parm.Add("@Year", spYear.Value);
            parm.Add("@Month", Convert.ToInt32(cbBegin.Text));
            parm.Add("@Value", strValue);
            return parm;
        }

        private void spRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void frmFDetailReport_Load(object sender, EventArgs e)
        {
            if (DesignMode == false && cbBegin.SelectedIndex == -1)
                GetPeriod();
        }

        private void sbSelItem_Click(object sender, EventArgs e)
        {
            frmSubject F = new frmSubject();
            F.bFlag = true;
            if (F.ShowDialog() == DialogResult.OK)
            {
                edSubject.SetValue(F.GetSubject());
            }
            F.Dispose();
        }

    }
}

