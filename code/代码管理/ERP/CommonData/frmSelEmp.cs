using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CommonData
{
    public partial class frmSelEmp : BaseClass.frmBase
    {
        public string strDept = "";
        public string strGroup = "";
        public frmSelEmp()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 绑定员工资料
        /// </summary>
        private void DataBind()
        {
            string strSQL = "";
            if (strDept == "")
                strSQL = "select a.*,b.F_Name as F_GroupName from t_Emp a,t_WorkGroup b where a.F_Group = b.F_ID";
            else
                strSQL = "select a.*,b.F_Name as F_GroupName from t_Emp a,t_WorkGroup b where a.F_Group = b.F_ID and a.F_Type = '"+strDept+"'";
            
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

