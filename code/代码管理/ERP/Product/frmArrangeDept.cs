using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Product
{
    public partial class frmArrangeDept : BaseClass.frmBase
    {
        public frmArrangeDept()
        {
            InitializeComponent();
        }

        private void BindData()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select a.Aid,a.F_DeptID,b.F_Name as F_Dept from t_ArrangeDept a,t_Class b where a.F_DeptID = b.F_ID");
            gcMain.DataSource = ds.Tables[0].DefaultView;
        }

        private Decimal GetMaxID()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select isnull(max(Aid),0)+1 as MaxID from t_ArrangeDept");
            return Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
        }

        private void AddDept()
        {
            string strSQL = "";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            CommonData.frmSelDept mySelDept = new CommonData.frmSelDept();
            if (mySelDept.ShowDialog() == DialogResult.OK)
            {
                int[] intCnt = mySelDept.gvMain.GetSelectedRows();
                for (int i = 0; i < intCnt.Length; i++)
                {
                    DataRow dr = mySelDept.gvMain.GetDataRow(intCnt[i]);

                    strSQL = "if not exists(select * from t_ArrangeDept where F_DeptID = '" + dr["F_ID"].ToString() + "') insert into t_ArrangeDept values(" + GetMaxID().ToString() + ",'" + dr["F_ID"].ToString() + "')";
                    myHelper.ExecuteSQL(strSQL);
                }
                BindData();
            }
            mySelDept.Dispose();   
        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            AddDept();
        }

        private void sbRemove_Click(object sender, EventArgs e)
        {
            if (gvMain.FocusedRowHandle < 0) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select top 1 F_OrderBill from t_ProductArrange");
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("已存在生产排程资料，不能删除排程部门!!");
                return;
            }
            ds.Dispose();
            DataRow dr = gvMain.GetDataRow(gvMain.FocusedRowHandle);
            if (myHelper.ExecuteSQL("delete from t_ArrangeDept where F_DeptID = '"+dr["F_DeptID"].ToString()+"'") == 0)
                BindData();
        }

        private void frmArrangeDept_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

