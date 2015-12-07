using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class CopyReportForm : BaseClass.frmBase
    {
        public string sFormName = "";

        public CopyReportForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtNew.txtEdit.Text == "")
            {
                MessageBox.Show("新报表名称不能为空!!","提示");
                txtNew.Focus();
                return;
            }

            string sSQL = string.Format("insert into t_ReportFormat(F_FormName,F_ReportName,F_Stream,F_SQL) select F_FormName,'{0}',F_Stream,F_SQL from t_ReportFormat where F_FormName = '{1}' and F_ReportName = '{2}'", txtNew.txtEdit.Text, sFormName, txtOld.txtEdit.Text);

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL(sSQL) == 0)
                this.DialogResult = DialogResult.OK;
        }
    }
}
