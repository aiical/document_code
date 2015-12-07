using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OA
{
    public partial class frmEditOANotice : Common.frmDialog
    {
        private string sAid = "0";
        private string strSQL;
        public frmEditOANotice()
        {
            InitializeComponent();
        }

        private decimal GetMaxID()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select isnull(max(Aid),0)+1 as F_MaxID from t_OANotice");
            return Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
        }

        public override void New()
        {
            base.New();
            strSQL = "select * from t_OANotice where Aid = 0";
            if (blnBind == false)
                BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            dr["Aid"] = GetMaxID();
            dr["F_Date"] = DataLib.SysVar.GetDate();
            dr["F_ExeDate"] = DataLib.SysVar.GetDate();
            dr["F_BuildMan"] = DataLib.SysVar.strUName;
            dr.EndEdit();
            binData.EndEdit();
            dateControl1.Focus();
        }

        public override void Edit(string sID)
        {
            sAid = sID;
            strSQL = "select * from t_OANotice where Aid = " + sID;
            BindData();
        }

        protected override bool Save()
        {
            binData.EndEdit();
            if (SavePre() == false) return false;
            gvEmp.CloseEditor();

            DataSet[] dsSave = new DataSet[2];
 
            DataSet ds = ((DataView)binData.DataSource).Table.DataSet;

            dsSave[0] = ds;
            dsSave[1] = ((DataTable)binEmp.DataSource).DataSet;

            string[] SQL = new string[2];
            SQL[0] = "select * from t_OANotice";
            SQL[1] = "select * from t_OANoticeEmp";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.SaveMuteData(dsSave, SQL).Length == 0)
            {
                ds.AcceptChanges();
                ((DataTable)binEmp.DataSource).DataSet.AcceptChanges();
                return true;
            }
            else
                return false;
        }

        protected override void BindData()
        {
            strSaveSlaverSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0].DefaultView;
            base.BindData();
            memoEdit1.DataBindings.Add("Text", binData, "F_Memo");

            DataSet dsEmp = myHelper.GetDs("select a.*,b.F_Name as F_EmpName from t_OANoticeEmp a,t_Emp b where a.F_EmpID = b.F_ID and a.Aid = " + sAid);
            binEmp.DataSource = dsEmp.Tables[0];
        }

        private void sbSel_Click(object sender, EventArgs e)
        {
            myControl.frmDataList F = new myControl.frmDataList();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_ID,F_Name,(case isnull(F_Login,0) when 0 then '离线' else '在线' end) as F_Flag from t_User");
            F.gcQuery.DataSource = ds.Tables[0].DefaultView;
            F.keyField = "F_ID";
            F.DisplayField = "F_Name";
            F.gvQuery.Columns["F_ID"].Caption = "用户编码";
            F.gvQuery.Columns["F_Name"].Caption = "用户名称";
            F.gvQuery.Columns["F_Flag"].Caption = "状态";
            F.gvQuery.OptionsSelection.MultiSelect = true;
            if (F.ShowDialog() == DialogResult.OK)
            {
                int[] iRows = F.gvQuery.GetSelectedRows();

                foreach (int i in iRows)
                {
                    DataRow dr = F.gvQuery.GetDataRow(i);
                    DataRow drEmp = ((DataRowView)binEmp.AddNew()).Row;
                    drEmp["Aid"] = ((DataRowView)binData.Current).Row["Aid"];
                    drEmp["F_EmpID"] = dr["F_ID"];
                    drEmp["F_EmpName"] = dr["F_Name"];
                }
                binEmp.EndEdit();
            }
            F.Dispose();
        }

        private void sbRemove_Click(object sender, EventArgs e)
        {
            gvEmp.DeleteRow(gvEmp.FocusedRowHandle);
        }
    }
}
