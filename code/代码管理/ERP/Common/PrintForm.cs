using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Common
{
    public partial class PrintForm : BaseClass.frmBase
    {
        private string sFormName = "";

        public string sBillID = "";

        private FastReport.Report r = null;

        public bool bPrint = false;

        public PrintForm(string sName)
        {
            sFormName = sName;
            InitializeComponent();
            DataBind();
        }

        private DataSet GetQuery()
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string sSQL = "select isnull(F_SQL,'') as F_SQL from t_ReportFormat where F_FormName = '" + sFormName + "' and F_ReportName = '" + dr["F_ReportName"].ToString() + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(sSQL);
            string sPrintSQL = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                sPrintSQL = ds.Tables[0].Rows[0][0].ToString();
            }

            if (sPrintSQL == "")
            {
                MessageBox.Show(this, "选定报表还没设置相应的SQL语句,请先设置!", "提示");
                return null;
            }

            Hashtable htParm = new Hashtable();
            htParm.Add("@Value",sBillID);
            DataSet dsResult = myHelper.GetOtherDs(sPrintSQL, htParm);
            return dsResult;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DataBind()
        {
            string sSQL = "select * from t_ReportFormat where F_FormName = '" + sFormName + " '";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(sSQL);
            gridReport.DataSource = ds.Tables[0];
        }

        private void AddReport(object sender, EventArgs e)
        {
            EditReportForm F = new EditReportForm();
            F.sFormName = sFormName;
            F.ShowDialog();
            F.Dispose();
            DataBind();
        }

        private void EditReport(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            EditReportForm F = new EditReportForm();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            F.sReportName = dr["F_ReportName"].ToString();
            F.sFormName = sFormName;
            F.ShowDialog();
            F.Dispose();
            DataBind();
        }


        private void DelReport(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            if (MessageBox.Show(this, "真的要删除选定报表吗?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_ReportFormat where F_FormName = '" + sFormName + "' and F_ReportName = '" + dr["F_ReportName"].ToString() + "'") == 0)
            {
                DataBind();
            }
        }

        private MemoryStream LoadStream()
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string sSQL = "select * from t_ReportFormat where F_FormName = '" + sFormName + "' and F_ReportName = '"+dr["F_ReportName"].ToString()+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(sSQL);
            if (ds.Tables[0].Rows.Count == 0) return null;
            if (ds.Tables[0].Rows[0]["F_Stream"] == DBNull.Value) return null;
            MemoryStream s = new MemoryStream((byte[])ds.Tables[0].Rows[0]["F_Stream"]);
            return s;
        }

        private void SaveStream()
        {
            DataRow drReport = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            MemoryStream s = new MemoryStream();
            r.Save(s);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_ReportFormat where F_FormName = '" + sFormName + "' and F_ReportName = '" + drReport["F_ReportName"].ToString() + "'");
            DataRow dr = null;
            if (ds.Tables[0].Rows.Count == 0)
            {
                dr = ds.Tables[0].NewRow();
                dr["F_FormName"] = sFormName;
                dr["F_ReportName"] = drReport["F_ReportName"].ToString();
                dr["F_Stream"] = s.ToArray();
                ds.Tables[0].Rows.Add(dr);
            }
            else
            {
                dr = ds.Tables[0].Rows[0];
                dr.BeginEdit();
                dr["F_Stream"] = s.ToArray();
                dr.EndEdit();
            }
            myHelper.SaveData(ds, "select * from t_ReportFormat");
        }


        private void SaveReport(object sender, EventArgs e)
        {
            SaveStream();
        }

        public void PreviewReport(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;

            DataSet ds = GetQuery();
            if (ds == null) return;
            MemoryStream s = LoadStream();
            if (s == null) return;
            r = new FastReport.Report();
            r.Load(s);
            r.RegisterData(ds);
            r.Show();
        }


        public void PrintReport(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            DataSet ds = GetQuery();
            if (ds == null) return;
            MemoryStream s = LoadStream();
            if (s == null) return;
            r = new FastReport.Report();
            r.Load(s);
            r.RegisterData(ds);
            r.Print();
            bPrint = true;
        }

        private void DesignReport(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;

            DataSet ds = GetQuery();
            if (ds == null) return;

            r = new FastReport.Report();
            MemoryStream s = LoadStream();
            if (s != null)
                r.Load(s);

            r.RegisterData(ds);
            if (r.Prepare() == true)
            {
                FastReport.Design.StandardDesigner.DesignerForm d = new FastReport.Design.StandardDesigner.DesignerForm();
                d.Designer.cmdSave.CustomAction += new EventHandler(SaveReport);
                d.Designer.AskSave = false;
                d.Designer.Report = r;
                d.ShowDialog();
                d.Dispose();
            }
        }

        private void PrintForm_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            CopyReportForm F = new CopyReportForm();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            F.sFormName = sFormName;
            F.txtOld.txtEdit.Text = dr["F_ReportName"].ToString();
            F.ShowDialog();
            F.Dispose();
            DataBind();
        }

        private void btnSQL_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string sSQL = "select isnull(F_SQL,'') as F_SQL from t_ReportFormat where F_FormName = '" + sFormName + "' and F_ReportName = '" + dr["F_ReportName"].ToString() + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(sSQL);
            string sPrintSQL = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                sPrintSQL = ds.Tables[0].Rows[0][0].ToString();
            }
            frmPrintSQL F = new frmPrintSQL();
            F.sBillID = this.sBillID;
            F.meSQL.Text = sPrintSQL;
            if (F.ShowDialog() == DialogResult.OK)
            {
                sSQL = string.Format("update t_ReportFormat set F_SQL = '{0}' where F_FormName = '{1}' and F_ReportName = '{2}'",F.meSQL.Text,sFormName,dr["F_ReportName"].ToString());
                myHelper.ExecuteSQL(sSQL);
            }
            F.Dispose();
        }

    }
}
