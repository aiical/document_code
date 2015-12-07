using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class frmGraphi : BaseClass.frmBase
    {
        public DataTable dtGraphi = null;
        public string ArgField;
        public string ValueField;
        public string TitleText = "";
        public frmGraphi()
        {
            InitializeComponent();
        }

        private void BindChart()
        {
            DevExpress.XtraCharts.ChartTitle Title = new DevExpress.XtraCharts.ChartTitle();
            Title.Text = TitleText;
            Chart.Titles.Add(Title);
            Chart.DataSource = dtGraphi;
            Chart.SeriesDataMember = ArgField;
            Chart.SeriesTemplate.ArgumentDataMember = ArgField;
            Chart.SeriesTemplate.ValueDataMembers.AddRange(new string[]{ValueField});
        }

        private void sbExport_Click(object sender, EventArgs e)
        {
            if (DataLib.SysVar.strUGroup != "超级用户")
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                DataSet ds = myHelper.GetDs("select F_Export from t_UserGroup where F_Group = '" + DataLib.SysVar.strUGroup + "'");
                if (Convert.ToBoolean(ds.Tables[0].Rows[0][0]) == false)
                {
                    MessageBox.Show(this, "你没有权限!", "提示");
                    return;
                }
            }
            string strFile = DataLib.sysClass.ShowSaveFileDialog("Excel 文件", "Excel 文件|*.Xls");
            if (strFile != "")
                Chart.ExportToXls(strFile);
        }

        private void sbPrint_Click(object sender, EventArgs e)
        {
            if (DataLib.SysVar.strUGroup != "超级用户")
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                DataSet ds = myHelper.GetDs("select isnull(F_Print,0) as F_Print from t_UserGroup where F_Group = '" + DataLib.SysVar.strUGroup + "'");
                if (Convert.ToBoolean(ds.Tables[0].Rows[0][0]) == false)
                {
                    MessageBox.Show(this, "你没有权限!", "提示");
                    return;
                }
            }
            Chart.Print();
        }

        private void frmGraphi_Load(object sender, EventArgs e)
        {
            BindChart();
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
