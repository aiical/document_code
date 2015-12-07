using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class EditReportForm : BaseClass.frmBase
    {
        public string sFormName = "";
        public string sReportName = "";

        public EditReportForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtReport.txtEdit.Text == "")
            {
                MessageBox.Show("报表名称不能为空!!","提示");
                txtReport.Focus();
                return;
            }

            string sSQL = "";
            if (sReportName == "")
                sSQL = string.Format("insert into t_ReportFormat(F_FormName,F_ReportName) values('{0}','{1}')", sFormName,txtReport.txtEdit.Text);
            else
                sSQL = string.Format("update t_ReportFormat set F_ReportName = '{0}' where F_FormName = '{1}' and F_ReportName = {2}", txtReport.txtEdit.Text, sFormName, sReportName);

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL(sSQL) == 0)
                this.DialogResult = DialogResult.OK;
        }
    }
}
