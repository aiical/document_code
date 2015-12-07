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
    public partial class frmFTotalReport : Common.frmReport
    {
        public frmFTotalReport()
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
            cbEnd.SelectedIndex = intMonth - 1;
        }

        protected override Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Year", spYear.Value);
            parm.Add("@Month", Convert.ToInt32(cbBegin.Text));
            //parm.Add("@End", Convert.ToInt32(cbEnd.Text));
            return parm;
        }

        protected override int BindData()
        {
            base.BindData();
            gvReport.OptionsSelection.EnableAppearanceFocusedCell = true;
            gvReport.OptionsView.AllowCellMerge = true;
            gvReport.Columns["F_ID"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            gvReport.Columns["F_Name"].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            return 0;
        }

        protected override void OnViewDbClick(object sender, EventArgs e)
        {
            base.OnViewDbClick(sender, e);
            if (gvReport.FocusedRowHandle < 0) return;
            DataRow dr = gvReport.GetDataRow(gvReport.FocusedRowHandle);
            if (dr["F_ID"] == DBNull.Value) return;
            frmFDetailReport F = new frmFDetailReport(dr["F_ID"].ToString(),Convert.ToInt32(spYear.Value),cbBegin.SelectedIndex);
            F.ShowDialog();
            F.Dispose();
        }

        private void frmFTotalReport_Load(object sender, EventArgs e)
        {
            if (DesignMode == false)
                GetPeriod();
        }

        private void spRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}

