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
    public partial class frmAssetDepreReport : Common.frmReport
    {
        public frmAssetDepreReport()
        {
            InitializeComponent();
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
        }

        protected override Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Year", spYear.Value);
            parm.Add("@Begin", Convert.ToInt32(cbBegin.Text));
            return parm;
        }

        private void spRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void frmFDayReport_Load(object sender, EventArgs e)
        {
            if (DesignMode == false)
                GetPeriod();
        }
    }
}

