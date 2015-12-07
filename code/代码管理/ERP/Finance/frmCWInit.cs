using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Localization;
using Common;

namespace Finance
{
    public partial class frmCWInit : BaseClass.frmBase
    {
        public frmCWInit()
        {
            InitializeComponent();
            if (this.DesignMode == false) DataBind();
        }

        private void FillSubject()
        {
            string strSQL = "select F_ID,F_Name,F_Direction from t_Subject";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
               DataRow drNew = ((DataRowView)binCW.AddNew()).Row;
               drNew["F_Init"] = true;
               drNew["F_Year"] = DateTime.Now.Year;
               drNew["F_Month"] = DateTime.Now.Month;
               drNew["F_Subject"] = dr["F_ID"];
               drNew["F_SubjectName"] = dr["F_Name"];
               drNew.EndEdit();
            }
        }

        private void DataBind()
        {
            string strSQL = "select a.*,b.F_Name as F_SubjectName from t_cwCheckOut a,t_Subject b where a.F_Subject = b.F_ID and a.F_Init = 1";
            
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binCW.DataSource = ds.Tables[0];
            if (binCW.Count == 0)
            {
                FillSubject();
            }
        }

        private void SaveData()
        {
            string strSQL = "select * from t_cwCheckOut where F_Init = 1";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            gridView1.CloseEditor();
            binCW.EndEdit();
            if (myHelper.SaveData(((DataTable)binCW.DataSource).DataSet, strSQL) == 0)
            {
                MessageBox.Show("数据保存成功!!", "提示");
                ((DataTable)binCW.DataSource).AcceptChanges();
            }
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            SaveData();
            
        }

        private void Export()
        {
            string strFile = DataLib.sysClass.ShowSaveFileDialog("Excel 文件", "Excel 文件|*.Xls");
            if (strFile != "")
                gridView1.ExportToExcelOld(strFile);
        }

        private void tsPreview_Click(object sender, EventArgs e)
        {
            PreviewLocalizer plZer = new XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPrint(this.Text, plZer, this.printingSystem);
        }

        private void tsPrint_Click(object sender, EventArgs e)
        {
            PreviewLocalizer plZer = new XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPreview(this.Text, plZer, this.printingSystem);
        }

        private void tsExport_Click(object sender, EventArgs e)
        {
            Export();
        }
    }
}

