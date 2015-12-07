using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmEditAsset : Common.frmDialog
    {
        private string strSQL;
        public frmEditAsset()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置下拉框数据源
        /// </summary>
        private void SetDropSource()
        {
            string strSQL = "select * from t_AssetType";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_Name";
            ds.Dispose();

            strSQL = "select F_ID,F_Name from t_Class where left(F_UPID,2) like '03%'";
            ds = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = "select F_Name from t_AddType";
            ds = myHelper.GetDs(strSQL);
            lupControl3.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl3.LookUpDisplayField = "F_Name";
            lupControl3.LookUpKeyField = "F_Name";
            ds.Dispose();

            strSQL = "select F_Name from t_UseInfo";
            ds = myHelper.GetDs(strSQL);
            lupControl4.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl4.LookUpDisplayField = "F_Name";
            lupControl4.LookUpKeyField = "F_Name";
            ds.Dispose();
        }
          

        public override void New()
        {
            base.New();
            strSQL = "select * from t_Asset where F_ID = ''";
            BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr["F_Date"] = DateTime.Today;
        }

        public override void Edit(string strID)
        {
            base.Edit(strID);
            strSQL = "select * from t_Asset where F_ID = '" + strID + "'";
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

        private void lupControl6_ButtonClick(object sender, EventArgs e)
        {
            frmSubject mySubject = new frmSubject();
            mySubject.bFlag = true;
            if (mySubject.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = ((DataRowView)binData.Current).Row;
                dr.BeginEdit();
                dr["F_Subject"] = mySubject.GetSubject();
                dr.EndEdit();
                binData.EndEdit();
            }
            mySubject.Dispose();
        }
    }
}

