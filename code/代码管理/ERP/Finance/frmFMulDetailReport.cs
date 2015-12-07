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
    public partial class frmFMulDetailReport : Common.frmReport
    {
        private decimal decYear, decBegin, decEnd;

        public frmFMulDetailReport()
        {
            InitializeComponent();
            btnFilter.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
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
            //cbEnd.SelectedIndex = intMonth - 1;
        }

        protected override int BindData()
        {
            if (edSubject.GetValue() == null) return -1;
            if (strQuerySQL.Length == 0) return -1;

            BaseClass.frmFlag myFlag = new BaseClass.frmFlag();
            myFlag.Show();
            myFlag.Update();

            try
            {
                try
                {
                    DataLib.DataHelper myHelper = new DataLib.DataHelper();
                    DataSet ds;

                    ds = myHelper.GetOtherDs(strQuerySQL, GetParm());
                  

                    if (ds == null) return -1;
                    gvReport.Columns.Clear();
                    gcReport.DataSource = ds.Tables[0].DefaultView;
                    
                    gvReport.Columns["F_Date"].Caption = "日期";
                    gvReport.Columns["F_Key"].Caption = "凭证字";
                    gvReport.Columns["F_Tag"].Caption = "摘要";
                    gvReport.Columns["F_Money"].Caption = "合计";
                    //gvReport.Columns["F_Rest"].Caption = "余额";
                    //AssignField();
                    return 0;
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message, "错误");
                    return -1;
                }
            }
            finally
            {
                myFlag.Dispose();
            }
        }

        protected override void DataFilter()
        {
            //base.DataFilter();
            frmMulSet myMulSet = new frmMulSet();
            if (myMulSet.ShowDialog() == DialogResult.OK)
            {
                decYear = myMulSet.spYear.Value;
                decBegin = Convert.ToDecimal(myMulSet.cbBegin.Text);
                decEnd = Convert.ToDecimal(myMulSet.cbEnd.SelectedIndex);
            }
            myMulSet.Dispose();
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

        protected override void SelectIndexChange()
        {
            if (gvReport.FocusedRowHandle < 0) return;
            if (rgOption.SelectedIndex == 1)
            {
                DataRow dr = gvReport.GetDataRow(gvReport.FocusedRowHandle);
                strValue = dr["F_ID"].ToString();
            }
            
            base.SelectIndexChange();
        }

        private void sbSelItem_Click(object sender, EventArgs e)
        {
            frmSubject F = new frmSubject();
            F.bFlag = true;
            F.bChildFlag = true;
            if (F.ShowDialog() == DialogResult.OK)
            {
                edSubject.SetValue(F.GetSubject());
            }
            F.Dispose();
        }

        private void spRefresh_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void frmFMulDetailReport_Load(object sender, EventArgs e)
        {
            if (DesignMode == false)
                GetPeriod();
        }
    }
}

