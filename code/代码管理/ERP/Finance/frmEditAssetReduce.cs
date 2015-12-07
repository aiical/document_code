using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmEditAssetReduce : Common.frmDialog
    {
        private string strSQL;
        public frmEditAssetReduce()
        {
            InitializeComponent();
        }

        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_Asset";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
            ds.Dispose();
        }

        public override void New()
        {
            base.New();
            strSQL = "select * from t_AssetReduce where Aid = 0";
            BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr["F_Date"] = DateTime.Today;
        }

        public override void Edit(string strID)
        {
            base.Edit(strID);
            strSQL = "select * from t_AssetReduce where Aid = '" + strID + "'";
            BindData();
        }

        protected override void BindData()
        {
            strSaveSlaverSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0].DefaultView;
            SetDropSource();
            base.BindData();
        }

        private void lupControl1_ValueChanged(object sender, EventArgs e)
        {
            editControl2.SetValue(lupControl1.GetValue().ToString());
        }

    }
}

