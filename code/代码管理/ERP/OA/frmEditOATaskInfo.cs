using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OA
{
    public partial class frmEditOATaskInfo : Common.frmDialog
    {
        private string strSQL;
        public frmEditOATaskInfo()
        {
            InitializeComponent();
        }

        private void SetDropDataSource()
        {
            string strSQL = "select F_ID,F_Name,(case isnull(F_Login,0) when 0 then '离线' else '在线' end) as F_Flag from t_User";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsType = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = dsType.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";

            strSQL = "select Aid,F_Title,F_ExeDate from t_OATask where F_Emp = '"+DataLib.SysVar.strUID+"'";
            DataSet dsTask = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = dsTask.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Title";
            lupControl2.LookUpKeyField = "Aid";
        }

        public override void New()
        {
            base.New();
            strSQL = "select * from t_OATaskInfo where Aid = 0";
            if (blnBind == false)
                BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            dr["F_Date"] = DataLib.SysVar.GetDate();
            dr["F_BuildMan"] = DataLib.SysVar.strUName;
            dr.EndEdit();
            binData.EndEdit();
            dateControl1.Focus();
        }

        public override void Edit(string sID)
        {
            strSQL = "select * from t_OATaskInfo where Aid = " + sID;
            BindData();
        }

        protected override void BindData()
        {
            strSaveSlaverSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0].DefaultView;
            base.BindData();
            SetDropDataSource();
            memoEdit1.DataBindings.Add("Text", binData, "F_Memo");
        }

       
    }
}
