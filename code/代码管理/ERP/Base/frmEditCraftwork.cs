using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmEditCraftwork : Common.frmDialog
    {
        private string strSQL,strSlaverSQL;
        private string strCraftworkID = "";

        public frmEditCraftwork()
        {
            InitializeComponent();
        }

        private void SetDropSource()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsDept = myHelper.GetDs("select F_ID,F_Name from t_Class where F_ID like '03.%'");
            lupDept.DataSource = dsDept.Tables[0].DefaultView;
            lupDept.ValueMember = "F_ID";
            lupDept.DisplayMember = "F_Name";

            DataSet dsProcess = myHelper.GetDs("select F_ID,F_Name from t_Process");
            lupProcess.DataSource = dsProcess.Tables[0].DefaultView;
            lupProcess.ValueMember = "F_ID";
            lupProcess.DisplayMember = "F_Name";
        }

        public override void New()
        {
            base.New();
            strSQL = "select * from t_Craftwork where F_ID = ''";
            BindData();
            binData.AddNew();
        }

        public override void Edit(string strID)
        {
            strCraftworkID = strID;
            base.Edit(strID);
            strSQL = "select * from t_Craftwork where F_ID = '" + strID + "'";
            BindData();
        }

        protected override void BindData()
        {
            SetDropSource();
            strSaveSlaverSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0].DefaultView;
            base.BindData();
            strSlaverSQL = "select * from t_CraftworkDetail where F_ID = '" + strCraftworkID + "'";
            DataSet dsSlaver = myHelper.GetDs(strSlaverSQL);
            gcDetail.DataSource = dsSlaver.Tables[0].DefaultView;
            
        }

        private void sbAddRow_Click(object sender, EventArgs e)
        {
            gvDetail.AddNewRow();
        }

        private void sbDelRow_Click(object sender, EventArgs e)
        {
            if (gvDetail.FocusedRowHandle < 0) return;
            gvDetail.DeleteRow(gvDetail.FocusedRowHandle);
            SetAutoID();
        }

        private void gvDetail_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvDetail.SetRowCellValue(e.RowHandle, "Aid", gvDetail.RowCount);
        }

        /// <summary>
        /// 设置序号
        /// </summary>
        private void SetAutoID()
        {
            int intCnt = gvDetail.RowCount;
            gvDetail.BeginUpdate();
            for (int i = 0; i < intCnt; i++)
            {
                gvDetail.SetRowCellValue(i, "Aid", i + 1);
            }
            gvDetail.EndUpdate();
        }

        protected override bool SavePre()
        {
            if (base.SavePre() == false) return false;
            DataTable dt = ((DataView)gcDetail.DataSource).Table;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("本单必须存在一条以上分录!!", "提示");
                return false;
            }
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["F_DeptID"] == DBNull.Value)
                {
                    MessageBox.Show("部门不能为空!!","提示");
                    return false;
                }

                if (dr["F_ProcessID"] == DBNull.Value)
                {
                    MessageBox.Show("工序不能为空!!","提示");
                    return false;
                }
            }

            return true;
        }

        protected override bool Save()
        {
            binData.EndEdit();
            if (SavePre() == false) return false;
            DataSet dsMaster = ((DataView)binData.DataSource).Table.DataSet;
            DataSet dsSlaver = ((DataView)gcDetail.DataSource).Table.DataSet;

            foreach (DataRow dr in dsSlaver.Tables[0].Rows)
            {
                dr["F_ID"] = editControl1.GetValue().ToString();
            }

            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            DataSet[] dsData = new DataSet[2];
            dsData[0] = dsMaster;
            dsData[1] = dsSlaver;

            string[] strMSQL = new string[2];
            strMSQL[0] = strSQL;
            strMSQL[1] = strSlaverSQL;

            if (myHelper.SaveMuteData(dsData, strMSQL).Length == 0)
                return true;
            else
                return false;
        }

        private void gvDetail_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            /*
            if (e.Column.FieldName == "Aid")
            {
                gvDetail.BeginUpdate();
                gvDetail.SetRowCellValue(e.RowHandle, "Aid", e.RowHandle + 1);
                gvDetail.EndUpdate();
            }
             */ 
        }
    }
}

