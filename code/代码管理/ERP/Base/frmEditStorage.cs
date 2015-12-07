using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmEditStorage : Common.frmDialog
    {
        private string strSQL;
        public frmEditStorage()
        {
            InitializeComponent();
            strNoCopyField = "F_ID";
        }

        /*
        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_Class where left(F_ID,2) = '05'";
            Common.DataHelper myHelper = new Common.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
        }
         */ 

        public override void New()
        {
            base.New();
            strSQL = "select * from t_Storage where F_ID = ''";
            BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            dr["F_ID"] = GetMaxCode("仓库资料", "t_Storage");
            dr["F_Kind"] = "正常仓";
            dr.EndEdit();
        }

        public override void Edit(string strID)
        {
            base.Edit(strID);
            strSQL = "select * from t_Storage where F_ID = '" + strID + "'";
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
    }
}

