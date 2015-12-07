using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Base
{
    public partial class frmEditCast : Common.frmDialog
    {
        private string strSQL,strSlaverSQL;
        private string strCraftworkID = "";

        public frmEditCast()
        {
            InitializeComponent();
        }


        public override void New()
        {
            base.New();
            strSQL = "select * from t_Cast where F_ID = ''";
            BindData();
            binData.AddNew();
        }

        public override void Edit(string strID)
        {
            strCraftworkID = strID;
            base.Edit(strID);
            strSQL = "select * from t_Cast where F_ID = '" + strID + "'";
            BindData();
        }

        protected override void BindData()
        {
            strSaveSlaverSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0].DefaultView;
            base.BindData();
            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Color,b.F_Brand,b.F_Material from t_CastDetail a left join t_Item b on a.F_ItemID = b.F_ID where a.F_ID = '" + strCraftworkID + "'";
            DataSet dsSlaver = myHelper.GetDs(strSlaverSQL);
            gcDetail.DataSource = dsSlaver.Tables[0].DefaultView;
            
        }

        private void sbAddRow_Click(object sender, EventArgs e)
        {
            Common.frmSelItem F = new Common.frmSelItem();
            F.sbAdd.Visible = false;
            if (F.ShowDialog() == DialogResult.OK)
            {
                if (F.TabControl.SelectedTabPageIndex == 0)
                {
                    DataTable dt = ((DataView)gcDetail.DataSource).Table;
                    int[] intRow = F.gvMain.GetSelectedRows();
                    if (intRow.Length <= 0) return;
                    for (int i = 0; i < intRow.Length; i++)
                    {
                        DataRow dr = F.gvMain.GetDataRow(intRow[i]);

                        DataRow drNew = dt.NewRow();
                        drNew["Aid"] = dt.Rows.Count + 1;
                        drNew["F_ItemID"] = dr["F_ID"];
                        drNew["F_ItemName"] = dr["F_Name"];
                        drNew["F_Spec"] = dr["F_Spec"];
                        drNew["F_Color"] = dr["F_Color"];
                        drNew["F_Brand"] = dr["F_Brand"];
                        drNew["F_Material"] = dr["F_Material"];
                        dt.Rows.Add(drNew);
                    }
                }
                else
                {
                    DataTable dt = ((DataView)gcDetail.DataSource).Table;
                    int[] intRow = F.gvStore.GetSelectedRows();
                    if (intRow.Length <= 0) return;
                    for (int i = 0; i < intRow.Length; i++)
                    {
                        DataRow dr = F.gvStore.GetDataRow(intRow[i]);

                        DataRow drNew = dt.NewRow();
                        drNew["Aid"] = dt.Rows.Count + 1;
                        drNew["F_ItemID"] = dr["F_ID"];
                        drNew["F_ItemName"] = dr["F_Name"];
                        drNew["F_Spec"] = dr["F_Spec"];
                        drNew["F_Color"] = dr["F_Color"];
                        drNew["F_Brand"] = dr["F_Brand"];
                        drNew["F_Material"] = dr["F_Material"];
                        dt.Rows.Add(drNew);
                    }
                }
            }
            F.Dispose();
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
                if (dr.RowState == DataRowState.Deleted) continue;
                dr["F_ID"] = editControl1.GetValue().ToString();
            }

            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            DataSet[] dsData = new DataSet[2];
            dsData[0] = dsMaster;
            dsData[1] = dsSlaver;

            string[] strMSQL = new string[2];
            strMSQL[0] = strSQL;
            strMSQL[1] = "select * from t_CastDetail where F_ID = ''";

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

        /// <summary>
        /// 大二进制文件处理
        /// </summary>
        /// <param name="intFlag"></param>
        /// <param name="intTag"></param>
        private void SaveOrOpenFile(int intFlag, int intTag)
        {
            DataRow dr = ((DataRowView)binData.Current).Row;
            DataLib.sysClass myClass = new DataLib.sysClass();
            if (intFlag == 0)
            {
                myClass.SaveFileToDr(dr, intTag);
            }
            else
            {
                myClass.LoadFileFromDr(dr, intTag);
            }
        }

        private void sbLoadFile_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(0, 1);         
        }

       

        private void sbViewFile_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(1, 1);       
        }
    }
}

