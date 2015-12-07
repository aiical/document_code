using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmEditDeviceRepair : Common.frmDialog
    {
        private string strSQL;
        public frmEditDeviceRepair()
        {
            InitializeComponent();
            blnNew = true;
            strNoCopyField = "Aid";
        }

        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_DeviceInfo";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsType = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = dsType.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";

            strSQL = "select F_ID,F_Name from t_Emp";
            DataSet dsEmp = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = dsEmp.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";
        }

        public override void New()
        {
            base.New();
            strSQL = "select * from t_DeviceRepair where Aid = 0";
            if (blnBind == false)
                BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            //dr["F_Type"] = strType;
            dr["F_Date"] = DataLib.SysVar.GetDate();
            //dr["F_Builder"] = DataLib.SysVar.strUName;
            dr.EndEdit();
            binData.EndEdit();
            editControl1.Focus();
        }

        public override void Edit(string strID)
        {
            //ckOption.Checked = false;
            base.Edit(strID);
            strSQL = "select * from t_DeviceRepair where Aid = " + strID;
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
    }
}
