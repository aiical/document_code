using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommonData
{
    public partial class frmSelDept : BaseClass.frmBase
    {
        public frmSelDept()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ∞Û∂®≤ø√≈
        /// </summary>
        private void DataBind()
        {
            string strSQL = "select F_ID,F_Name from t_Class where F_ID like '03.%'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gcMain.DataSource = ds.Tables[0].DefaultView;
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void gvMain_DoubleClick(object sender, EventArgs e)
        {
            sbOK_Click(null, null);
        }

        private void frmSelDept_Load(object sender, EventArgs e)
        {
            DataBind();
        }
    }
}

