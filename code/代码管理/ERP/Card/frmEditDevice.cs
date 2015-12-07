using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmEditDevice : Common.frmDialog
    {
        public string strType = "";
        private string strSQL;
        public frmEditDevice()
        {
            InitializeComponent();
        }

        public override void New()
        {
            base.New();
            strSQL = "select * from t_Device where F_ID = ''";
            if (blnBind == false)
                BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            dr["F_Port"] = "COM1";
            dr["F_Rate"] = "9600";
            dr["F_Uses"] = strType;
            dr.EndEdit();
            binData.EndEdit();
            editControl1.Focus();
        }

        public override void Edit(string strID)
        {
            base.Edit(strID);
            strSQL = "select * from t_Device where F_ID = '" + strID + "'";
            BindData();
        }

        protected override void BindData()
        {
            strSaveSlaverSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0].DefaultView;
            base.BindData();
        }

        private void btnAutoFind_Click(object sender, EventArgs e)
        {
            frmFindDevice F = new frmFindDevice();
            F.drDevice = ((DataRowView)binData.Current).Row;
            F.ShowDialog();
            F.Dispose();
        }

    }
}
