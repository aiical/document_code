using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmEditClient : Common.frmDialog
    {
        public string strType = "";
        private string strSQL;
        public frmEditClient()
        {
            InitializeComponent();
            gbox.Parent = Page1;
            gbox.Dock = DockStyle.Fill;
            blnNew = true;
            strNoCopyField = "F_ID";
        }

        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_Class where left(F_ID,3) = '02.'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsType = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = dsType.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";

            strSQL = "select F_ID,F_Name from t_CarryCompany";
            DataSet dsSupplier = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = dsSupplier.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";

            strSQL = "select F_ID,F_Name from t_Emp where F_Opertor = 1";
            DataSet dsEmp = myHelper.GetDs(strSQL);
            lupControl3.LookUpDataSource = dsEmp.Tables[0].DefaultView;
            lupControl3.LookUpDisplayField = "F_Name";
            lupControl3.LookUpKeyField = "F_ID";
        }

        public override void New()
        {
            base.New();
            strSQL = "select * from t_Client where F_ID = ''";
            if (blnBind == false)
               BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            dr["F_ID"] = GetMaxCode("客户资料", "t_Client");
            dr["F_Type"] = strType;
            dr["F_BuildDate"] = DataLib.SysVar.GetDate();
            dr["F_Builder"] = DataLib.SysVar.strUName;
            dr.EndEdit();
            binData.EndEdit();
            editControl1.Focus();
        }

        public override void Edit(string strID)
        {
            ckOption.Checked = false;
            base.Edit(strID);
            strSQL = "select * from t_Client where F_ID = '" + strID + "'";
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
            picClient.DataBindings.Add("EditValue", binData, "F_Photo");
        }

        private void ckOption_CheckedChanged(object sender, EventArgs e)
        {
            blnNew = ckOption.Checked;
        }

        private void sbLoad_Click(object sender, EventArgs e)
        {
            string strFile = DataLib.sysClass.ShowOpenFileDialog("图片文件", "所有文件|*.*");
            if (strFile != "")
            {
                picClient.Image = Image.FromFile(strFile);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            picClient.Image = null;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}

