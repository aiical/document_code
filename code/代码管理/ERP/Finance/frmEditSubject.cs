using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmEditSubject : Common.frmDialog
    {
        public string sUPID = "";
        private string strSQL = "";
        public frmEditSubject()
        {
            InitializeComponent();
            blnNew = true;
        }

        private void FillCurrency()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_Currency");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbControl3.AddItem(dr["F_Name"]);
            }
        }

        public override void New()
        {
            base.New();
            strSQL = "select * from t_Subject where F_ID = ''";

            if (blnBind == false)
                BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            dr["F_UPID"] = sUPID;
            dr["F_Direction"] = "借方";
            dr["F_Currency"] = "不核算外币";
            dr.EndEdit();
            binData.EndEdit();
            editControl1.Focus();
        }

        public override void Edit(string strID)
        {
            base.Edit(strID);
            strSQL = "select * from t_Subject where F_ID = '" + strID + "'";
            BindData();
        }

        protected override void BindData()
        {
            strSaveSlaverSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            ds.Tables[0].ColumnChanged += new DataColumnChangeEventHandler(ColumnChanged);
            binData.DataSource = ds.Tables[0].DefaultView;
            base.BindData();
            FillCurrency();
        }

        public virtual void ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            
        }

        private void cbControl2_SelectIndexChange(object sender, EventArgs e)
        {
            if (cbControl2.GetValue().ToString() == "不核算外币")
                cbControl3.Enabled = false;
            else
                cbControl3.Enabled = true;
            
        }
    }
}

