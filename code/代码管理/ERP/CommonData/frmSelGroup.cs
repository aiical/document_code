using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommonData
{
    public partial class frmSelGroup : BaseClass.frmBase
    {
        public frmSelGroup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定工组资料
        /// </summary>
        private void DataBind()
        {
            string strSQL = "select a.*,b.F_Name as F_DeptName from t_WorkGroup a,t_Class b where a.F_DeptID = b.F_ID";
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

