using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmArrangeClass : BaseClass.frmBase
    {
        public frmArrangeClass()
        {
            InitializeComponent();
            mkMonth.Text = DateTime.Today.ToString();
            SetDrop();
            CreateTable();
        }

        private void CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("F_ID", Type.GetType("System.String"));
            dt.Columns.Add("F_Name", Type.GetType("System.String"));
            dt.Columns.Add("F_Dept", Type.GetType("System.String"));

            gridEmp.DataSource = dt;
        }

        private void SetDrop()
        {
            string strSQL = "select F_ID,F_Name from t_SetClass";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupClass.LookUpDataSource = ds.Tables[0].DefaultView;
            lupClass.LookUpDisplayField = "F_Name";
            lupClass.LookUpKeyField = "F_ID";

            repositoryItemLookUpEdit1.DataSource = ds.Tables[0].DefaultView;
            repositoryItemLookUpEdit1.DisplayMember = "F_Name";
            repositoryItemLookUpEdit1.ValueMember = "F_ID";
        }

        private void DataBind(string sID)
        {
            string strSQL = "select * from t_ArrangeClass where F_Month = '" + mkMonth.Text + "' and F_ID = '"+sID+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            arrayGrid.DataSource = ds.Tables[0];
        }

        private void AutoGenClass()
        {
            if (lupClass.GetValue() == null)
            {
                MessageBox.Show(this,"请先选择班次!","提示");
                lupClass.Focus();
                return;
            }
            if (MessageBox.Show(this, "真的要重新生成排班吗，这将覆盖现在的结果,真的要这样做吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataTable dt = (DataTable)gridEmp.DataSource;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            foreach (DataRow dr in dt.Rows)
            {
                int iDays = DateTime.DaysInMonth(mkMonth.Value.Year, mkMonth.Value.Month);
                for (int i = 1; i <= iDays; i++)
                {
                    DateTime dtDate = new DateTime(mkMonth.Value.Year, mkMonth.Value.Month, i);
                    string strSQL = "insert into t_ArrangeClass(F_Month,F_ID,F_Day,F_Class) values('" + mkMonth.Text + "','" + dr["F_ID"].ToString() + "','" + dtDate.ToString() + "','" + lupClass.GetValue().ToString()+ "')";
                    myHelper.ExecuteSQL(strSQL);
                }
            }
            DataRow drm = viewEmp.GetDataRow(viewEmp.FocusedRowHandle);
            DataBind(drm["F_ID"].ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            AutoGenClass();
        }

        private void viewEmp_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
            DataRow dr = viewEmp.GetDataRow(e.FocusedRowHandle);
            DataBind(dr["F_ID"].ToString());
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private void SaveData()
        {
            arrayView.CloseEditor();
            DataSet ds = ((DataTable)arrayGrid.DataSource).DataSet;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.SaveData(ds, "select * from t_ArrangeClass") == 0)
            {
                MessageBox.Show(this, "数据保存成功！", "提示");
                ds.AcceptChanges();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            myControl.frmDataList myDataList = new myControl.frmDataList();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select a.F_ID,a.F_Name,b.F_Name as F_Dept,dbo.fn_GetPy(a.F_Name) as F_Spell from t_Emp a left join t_Class b on a.F_Type = b.F_ID");
            myDataList.gcQuery.DataSource = ds.Tables[0].DefaultView;
            myDataList.strDisplayCaption = "员工编号,员工名称,部门,拼音码";
            myDataList.keyField = "F_ID";
            myDataList.DisplayField = "F_Name";
            myDataList.sbNew.Visible = false;
            myDataList.gvQuery.OptionsSelection.MultiSelect = true;
            if (myDataList.ShowDialog() == DialogResult.OK)
            {
                int[] Rows = myDataList.gvQuery.GetSelectedRows();

                DataTable dt = (DataTable)gridEmp.DataSource;
                foreach (int i in Rows)
                {
                   DataRow dr = myDataList.gvQuery.GetDataRow(i);
                   if (dt.Select("F_ID = '" + dr["F_ID"].ToString() + "'").Length > 0) continue; 
                    DataRow drNew = dt.NewRow();
                   drNew["F_ID"] = dr["F_ID"];
                   drNew["F_Name"] = dr["F_Name"];
                   drNew["F_Dept"] = dr["F_Dept"];
                   dt.Rows.Add(drNew);
                }
            }
            myDataList.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
