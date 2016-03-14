using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid;

namespace U8_Sale
{
    public partial class frmDeptRef : UserControl
    {
        public frmDeptRef()
        {
            InitializeComponent();
            DataBind();
            string StrSQL = "select cDepCode,cDepName from Department where cDepCode like '1___'";
            DataSet dschem = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL);
            string str = "select * from SL_P_BaseData ";
            DataSet dschem1 = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, str);
            lueDepartment.Properties.DataSource = dschem.Tables[0];
            luecRef1.Properties.DataSource = dschem1.Tables[0];
            luecRef2.Properties.DataSource = dschem1.Tables[0];
            gcView.OptionsBehavior.Editable = false;
        }

        #region 获取数据源
        private void DataBind()
        {
            string StrSQL = "SELECT SD.cDeptRefId,SD.cDepCode,SB.cDataValue AS cRef1,SB1.cDataValue AS cRef2 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId";
            DataSet ds = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL);
            gcList.DataSource = ds.Tables[0];

            //this.lueDepartment.Properties.ValueMember = "cDepName";
        }

        #endregion

        #region 删除
        private void del()
        {
            if (gcView.RowCount < 1)
            {
                MessageBox.Show("没有数据可以删除");
                return;
            }
            else
            {
                int iselectindex = gcView.FocusedRowHandle;
                if (gcView.FocusedRowHandle < 0) return;
                if (MessageBox.Show(this, "真的要删除本卡记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("delete from SL_P_DeptRef where cDeptRefId='" + gcView.GetRowCellValue(iselectindex, "cDeptRefId").ToString() + "'")) > 0)
                {

                    DataBind();
                }
            }

        }

        #endregion


        #region 保存


        public DataTable GetDataTable(DevExpress.XtraGrid.Views.Grid.GridView dgv)
        {


            DataRow dr;
            //创建临时表
            DataTable dt = new DataTable();
            dt.Columns.Add("cDeptRefId", typeof(Guid));
            dt.Columns.Add("cDepCode", typeof(string));
            dt.Columns.Add("cRef1", typeof(string));
            dt.Columns.Add("cRef2", typeof(string));

            if (gcView.RowCount > 0)
            {
                for (int i = 0; i < gcView.RowCount - 1; i++)
                {
                    dr = dt.NewRow();
                    dr["cDeptRefId"] = Guid.NewGuid().ToString();

                    dr["cDepCode"] = gcView.GetRowCellValue(i, "cDepCode").ToString();

                    dr["cRef1"] = DBHelper.GetDatas("cDataId", "SL_P_BaseData", "cDataValue", gcView.GetRowCellValue(i, "cRef1").ToString());
                    //dr["cRef1"] = gcView.GetRowCellValue(i, "cRef1").ToString();
                    dr["cRef2"] = DBHelper.GetDatas("cDataId", "SL_P_BaseData", "cDataValue", gcView.GetRowCellValue(i, "cRef2").ToString());
                    // dr["cRef2"] = gcView.GetRowCellValue(i, "cRef2").ToString();
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                    if (Checkdata(gcView.GetRowCellValue(gcView.FocusedRowHandle, "cDepCode").ToString()))
                    {
                        MessageBox.Show("已存在" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "cDepCode").ToString() + "");
                        //return;


                    }

                }
            }

            return dt;

        }

        private void savedata(string msg)
        {

            DataRow dr;
            //DataTable dtDetail = new DataTable();
            DataTable dtTemp = new DataTable();

            DataTable dt = new DataTable();
            dt.Columns.Add("cDeptRefId", typeof(Guid));
            dt.Columns.Add("cDepCode", typeof(string));
            dt.Columns.Add("cRef1", typeof(string));
            dt.Columns.Add("cRef2", typeof(string));
            gcView.UpdateCurrentRow();


            //DataTable dt = gcList.DataSource as DataTable;
            //if (gcView.RowCount > 1)
            //{
            //    for (int i = gcView.RowCount - 1; i > 0; i--)
            //    {
            //        if (gcView.GetRowCellValue(i, "cDeptRefId").ToString() == null)
            //        {
            //            gcView.DeleteRow(i);
            //        }

            //    }

            //}
            dtTemp = GetDataTable(gcView).Copy();
            DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("delete from SL_P_DeptRef"));


            //for (int i = 0; i < gcView.RowCount - 1; i++)
            //{
            //    if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("delete from SL_P_DeptRef where cDeptRefId='" + gcView.GetRowCellValue(i, "cDeptRefId").ToString() + "'")) > 0)
            //        continue;
            //}
            if (dtTemp.Rows.Count > 0)
            {

                for (int r = 0; r < dtTemp.Rows.Count; r++)
                {
                    dr = dt.NewRow();
                    dr["cDeptRefId"] = dtTemp.Rows[r]["cDeptRefId"].ToString();
                    dr["cDepCode"] = dtTemp.Rows[r]["cDepCode"].ToString();
                    dr["cRef1"] = dtTemp.Rows[r]["cRef1"].ToString();
                    dr["cRef2"] = dtTemp.Rows[r]["cRef2"].ToString();
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }

            }

            //数据插入处理

            DBHelper.SqlBulkCopyInsert("SL_P_DeptRef", dt, DBHelper.ConnString, msg);



        }

        private void save()
        {

            string Msg = string.Empty;
            if (gcView.RowCount < 1)
            {
                MessageBox.Show("保存数据为空，不允许保存！");
                return;
            }

            //for (int t = 0; t < gcView.RowCount - 2; t++)
            //{
            //    int iselect=gcView.FocusedRowHandle;
            //    string cDepCode = DBHelper.GetDatas("cDepCode", "SL_P_DeptRef", "cDepCode", gcView.GetRowCellValue(t, "cRef1").ToString());
            //    string cDeptRefId = DBHelper.GetDatas("cDeptRefId", "SL_P_DeptRef", "cDeptRefId", gcView.GetRowCellValue(t, "cRef1").ToString());
            //    if (Checkdata(gcView.GetRowCellValue(iselect, "cDepCode").ToString()))


            //}
            savedata(Msg);

            if (string.IsNullOrEmpty(Msg))
            {
                MessageBox.Show("数据保存成功！");
            }
            else
            {
                MessageBox.Show("数据保存失败！" + Msg);
                return;
            }

            gcView.RefreshData();
            DataBind();
            gcView.OptionsBehavior.Editable = false;

        }



        #endregion






        private void tsbModify_Click(object sender, EventArgs e)
        {
            gcView.OptionsBehavior.Editable = true;
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            del();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            gcView.AddNewRow();
            gcView.OptionsBehavior.Editable = true;
        }


        /// <summary>
        /// 检查是否存在相同部门以及编码是否为空
        /// </summary>
        /// <param name="fchrItemCode"></param>
        /// <param name="fchrFree1"></param>
        /// <returns></returns>
        private bool Checkdata(string cDepCode)
        {
            bool bFlag = false;
            if (gcView.RowCount > 0)
            {
                for (int r = 0; r < gcView.RowCount - 2; r++)
                {
                    if (gcView.GetRowCellValue(r, "cDepCode").ToString() == cDepCode)
                    {
                        bFlag = true;
                        break;
                    }
                }
            }

            return bFlag;
        }

        private void lueGrid_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit lue = sender as DevExpress.XtraEditors.LookUpEdit;
            if (lue == null)
                return;
            if (lue.Tag == null)
                return;
            gcView.CloseEditor();

        }
    }
}
