using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmEditCurrency : Common.frmDialog
    {
        public string strType = "";
        private string strSQL;
        public frmEditCurrency()
        {
            InitializeComponent();
            blnNew = true;
        }

        public override void New()
        {
            base.New();
            strSQL = "select * from t_Currency where F_Name = ''";
            if (blnBind == false)
                BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            dr["F_Rate"] = 1;
            dr.EndEdit();
            binData.EndEdit();
            editControl1.Focus();
        }

        public override void Edit(string strID)
        {
            ckOption.Checked = false;
            base.Edit(strID);
            strSQL = "select * from t_Currency where F_Name = '" + strID + "'";
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

        private void ckOption_CheckedChanged(object sender, EventArgs e)
        {
            blnNew = ckOption.Checked;
        }
    }
}

