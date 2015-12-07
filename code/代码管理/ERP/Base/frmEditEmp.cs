using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmEditEmp : Common.frmDialog
    {
        public string strType = "";
        private string strSQL;
        public frmEditEmp()
        {
            InitializeComponent();
            blnNew = true;
            strNoCopyField = "F_ID";
        }

        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_Class where left(F_ID,3) = '03.'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";

            strSQL = "select F_ID,F_Name from t_WorkGroup";
            DataSet dsGroup = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = dsGroup.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";
        }

        public override void New()
        {
            base.New();
            strSQL = "select * from t_Emp where F_ID = ''";
            if (blnBind == false)
                BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            dr["F_ID"] = GetMaxCode("员工资料", "t_Emp");
            dr["F_Type"] = strType;
            dr["F_BornDate"] = "1900-1-1";
            dr["F_OutDate"] = "1900-1-1";
            dr["F_Out"] = false;
            dr["F_BuildDate"] = DataLib.SysVar.GetDate();
            dr["F_Builder"] = DataLib.SysVar.strUName;
            dr["F_Opertor"] = false;
            dr.EndEdit();
            binData.EndEdit();
            editControl1.Focus();
        }

        public override void Edit(string strID)
        {
            ckOption.Checked = false;
            base.Edit(strID);
            strSQL = "select * from t_Emp where F_ID = '" + strID + "'";
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
            ckOPer.DataBindings.Clear();
            ckOPer.DataBindings.Add("EditValue", binData, "F_Opertor");
            meRemark.DataBindings.Clear();
            meRemark.DataBindings.Add("Text", binData, "F_Remark");
            picMan.DataBindings.Clear();
            picMan.DataBindings.Add("EditValue", binData, "F_Pic");
        }

        private void ckOption_CheckedChanged(object sender, EventArgs e)
        {
            blnNew = ckOption.Checked;
        }
    }
}

