using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace U8_Sale
{
    public partial class frmRefset : UserControl
    {
        public frmRefset()
        {
            InitializeComponent();
            gcView.Columns["nRate1"].Caption = Convert.ToString(Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "年";
            gcView.Columns["nRate2"].Caption = Convert.ToString(Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "年";
            gcView.Columns["nRate3"].Caption = Convert.ToString(Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "年";
            DataBind();
            //string StrSQL = "select cDepCode,cDepName from Department where cDepCode like '1___'";
            string StrSQL = "select  SD.cDepCode,D.cDepName FROM SL_P_DeptRef SD LEFT JOIN Department D ON SD.cDepCode=D.cDepCode";
            DataSet dschem = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL);
            lueDepartment.Properties.DataSource = dschem.Tables[0];
            gcView.OptionsBehavior.Editable = false;
            GetlueData();
        }


        # region 获得数据源

        private void DataBind()
        {

            string StrSQL = "SELECT * FROM SL_P_Refset WHERE iYear=(SELECT DATEPART(YEAR, GETDATE())) ";
            DataSet ds = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL);
            gcList.DataSource = ds.Tables[0];


        }


        private void GetlueData()
        {
            //string StrSQL = "select cRef1 AS cRefType FROM (SELECT SD.cDepCode,SB.cDataValue AS cRef1 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId UNION ALL SELECT SD.cDepCode,SB1.cDataValue AS cRef2 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId ) AS tmp GROUP BY cRef1";
            //string StrSQL = "select cRef1 AS cRefType FROM (SELECT SD.cDepCode,SB.cDataValue AS cRef1 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId UNION ALL SELECT SD.cDepCode,SB1.cDataValue AS cRef2 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId ) AS tmp WHERE tmp.cDepCode = '" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "cDepCode").ToString() + "'";
            string StrSQL = "SELECT d.cDepName,cRef1 AS cRefType FROM (SELECT SD.cDepCode,SB.cDataValue AS cRef1 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId UNION ALL SELECT SD.cDepCode,SB1.cDataValue AS cRef2 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId ) AS tmp LEFT JOIN Department d ON tmp.cDepCode=d.cDepCode ";
            DataSet ds = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL);
            luecRef.Properties.DataSource = ds.Tables[0];
        }

        # endregion


        #region 保存

        private DataTable GetTable(DevExpress.XtraGrid.Views.Grid.GridView dgv)
        {

            DataRow dr;
            DataTable dsshcem = new DataTable();
            dsshcem.Columns.Add("cId", typeof(Guid));
            dsshcem.Columns.Add("cDepCode", typeof(string));
            dsshcem.Columns.Add("iYear", typeof(int));
            dsshcem.Columns.Add("cRefType", typeof(string));
            dsshcem.Columns.Add("iMonth", typeof(int));
            dsshcem.Columns.Add("nRate1", typeof(decimal));
            dsshcem.Columns.Add("nRate2", typeof(decimal));
            dsshcem.Columns.Add("nRate3", typeof(decimal));
            if (gcView.RowCount > 0)
            {
                for (int i = 0; i < gcView.RowCount - 1; i++)
                {
                    dr = dsshcem.NewRow();
                    dr["cId"] = Guid.NewGuid().ToString();
                    dr["cDepCode"] = gcView.GetRowCellValue(i, "cDepCode").ToString();
                    dr["iYear"] = gcView.GetRowCellValue(i, "iYear").ToString();
                    //dr["iYear"] = DateTime.Now.Year.ToString();
                    dr["cRefType"] = gcView.GetRowCellValue(i, "cRefType").ToString();
                    dr["iMonth"] = gcView.GetRowCellValue(i, "iMonth").ToString();
                    dr["nRate1"] = gcView.GetRowCellValue(i, "nRate1").ToString();
                    dr["nRate2"] = gcView.GetRowCellValue(i, "nRate2").ToString();
                    dr["nRate3"] = gcView.GetRowCellValue(i, "nRate3").ToString();
                    dsshcem.Rows.Add(dr);
                    dsshcem.AcceptChanges();



                }
            }
            return dsshcem;


        }


        private void savadata(string msg)
        {
            DataRow dr;
            DataTable dtDetail = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("cId", typeof(Guid));
            dt.Columns.Add("cDepCode", typeof(string));
            dt.Columns.Add("iYear", typeof(int));
            dt.Columns.Add("cRefType", typeof(string));
            dt.Columns.Add("iMonth", typeof(int));
            dt.Columns.Add("nRate1", typeof(decimal));
            dt.Columns.Add("nRate2", typeof(decimal));
            dt.Columns.Add("nRate3", typeof(decimal));
            gcView.UpdateCurrentRow();
            dtDetail = GetTable(gcView).Copy();
            DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("delete from SL_P_Refset where iYear=(SELECT DATEPART(YEAR, GETDATE()))"));
            if (dtDetail.Rows.Count > 0)
            {
                for (int r = 0; r < dtDetail.Rows.Count; r++)
                {
                    dr = dtDetail.NewRow();
                    dr["cId"] = dtDetail.Rows[r]["cId"].ToString();
                    dr["cDepCode"] = dtDetail.Rows[r]["cDepCode"].ToString();
                    dr["iYear"] = dtDetail.Rows[r]["iYear"].ToString();
                    dr["cRefType"] = dtDetail.Rows[r]["cRefType"].ToString();
                    dr["iMonth"] = dtDetail.Rows[r]["iMonth"].ToString();
                    dr["nRate1"] = dtDetail.Rows[r]["nRate1"].ToString();
                    dr["nRate2"] = dtDetail.Rows[r]["nRate2"].ToString();
                    dr["nRate3"] = dtDetail.Rows[r]["nRate3"].ToString();
                    dt.Rows.Add(dr.ItemArray);
                    dt.AcceptChanges();
                }
            }
            DBHelper.SqlBulkCopyInsert("SL_P_Refset", dt, DBHelper.ConnString, msg);



        }

        private void sava()
        {
            gcView.PostEditor();
            string Msg = string.Empty;
            if (gcView.RowCount < 1)
            {
                MessageBox.Show("保存数据为空，不允许保存！");
                return;
            }
            savadata(Msg);

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

        # endregion

        # region 新增
        private void New()
        {
            gcView.AddNewRow();
            gcView.SetRowCellValue(gcView.FocusedRowHandle, "iYear", DateTime.Now.Year.ToString());
            
            


        }
        # endregion

        # region 删除

        private void del()
        {
            if (gcView.FocusedRowHandle < 0)
                return;
            int iselectindex = gcView.FocusedRowHandle;
            if (gcView.FocusedRowHandle < 0) return;
            if (MessageBox.Show(this, "真的要删除本卡记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("delete from SL_P_Refset  where cId='" + gcView.GetRowCellValue(iselectindex, "cId").ToString() + "'")) > 0)
            {

                DataBind();
            }
        }


        # endregion


        # region  检查是否存在相同数据

        /// <summary>
        /// 检查是否存在相同数据
        /// </summary>
        /// <param name="fchrItemCode"></param>
        /// <param name="fchrFree1"></param>
        /// <returns></returns>
        private bool Checkdata(string cDepCode)
        {
            bool bFlag = false;
            if (gcView.RowCount > 0)
            {
                for (int r = 0; r < gcView.RowCount - 1; r++)
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

        # endregion 

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
            sava();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            New();
            gcView.OptionsBehavior.Editable = true;
        }


        private void lueGrid_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboiMonth_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDepartment.Properties.ValueMember.ToString()=="")
            {
                MessageBox.Show("部门不能为空，请选择！", "系统提示");
                return;
            }
            //判断前三年是否有记录，没有的话就赋值给它
            if (gcView.GetRowCellValue(gcView.FocusedRowHandle, "cRefType").ToString() == "销售额")
            {
                if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("SELECT COUNT(*) FROM DispatchList WHERE MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND YEAR(dDate)=YEAR(GETDATE())-3 AND cDepcode='" + lueDepartment.Properties.ValueMember.ToString() + "'")) == 0)
                {
                    gcView.SetRowCellValue(gcView.FocusedRowHandle, "nRate1", 0);
                }
                if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("SELECT COUNT(*) FROM DispatchList WHERE MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND YEAR(dDate)=YEAR(GETDATE())-2 AND cDepcode='" + lueDepartment.Properties.ValueMember.ToString() + "'")) == 0)
                {
                    gcView.SetRowCellValue(gcView.FocusedRowHandle, "nRate2", 0);
                }
                if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("SELECT COUNT(*) FROM DispatchList WHERE MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND YEAR(dDate)=YEAR(GETDATE())-1 AND cDepcode='" + lueDepartment.Properties.ValueMember.ToString() + "'")) == 0)
                {
                    gcView.SetRowCellValue(gcView.FocusedRowHandle, "nRate3", 0);
                }
            }
            if (gcView.GetRowCellValue(gcView.FocusedRowHandle, "cRefType").ToString() == "开票额")
            {
                if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("SELECT COUNT(*) FROM SaleBillVouch WHERE MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND YEAR(dDate)=YEAR(GETDATE())-3 AND cDepcode='" + lueDepartment.Properties.ValueMember.ToString() + "'")) == 0)
                {
                    gcView.SetRowCellValue(gcView.FocusedRowHandle, "nRate1", 0);
                }

                if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("SELECT COUNT(*) FROM SaleBillVouch WHERE MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND YEAR(dDate)=YEAR(GETDATE())-2 AND cDepcode='" + lueDepartment.Properties.ValueMember.ToString() + "'")) == 0)
                {
                    gcView.SetRowCellValue(gcView.FocusedRowHandle, "nRate2", 0);
                }
                if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("SELECT COUNT(*) FROM SaleBillVouch WHERE MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND YEAR(dDate)=YEAR(GETDATE())-1 AND cDepcode='" + lueDepartment.Properties.ValueMember.ToString() + "'")) == 0)
                {
                    gcView.SetRowCellValue(gcView.FocusedRowHandle, "nRate3", 0);
                }
            }
            if (gcView.GetRowCellValue(gcView.FocusedRowHandle, "cRefType").ToString() == "汇款额")
            {
                if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("SELECT COUNT(*) FROM Ap_CloseBill WHERE MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND YEAR(dVouchDate)=YEAR(GETDATE())-3 AND cDepcode='" + lueDepartment.Properties.ValueMember.ToString() + "'")) == 0)
                {
                    gcView.SetRowCellValue(gcView.FocusedRowHandle, "nRate1", 0);
                }
                if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("SELECT COUNT(*) FROM Ap_CloseBill WHERE MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND YEAR(dVouchDate)=YEAR(GETDATE())-2 AND cDepcode='" + lueDepartment.Properties.ValueMember.ToString() + "'")) == 0)
                {
                    gcView.SetRowCellValue(gcView.FocusedRowHandle, "nRate2", 0);
                }
                if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("SELECT COUNT(*) FROM Ap_CloseBill WHERE MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND YEAR(dVouchDate)=YEAR(GETDATE())-1 AND cDepcode='" + lueDepartment.Properties.ValueMember.ToString() + "'")) == 0)
                {
                    gcView.SetRowCellValue(gcView.FocusedRowHandle, "nRate3", 0);
                }
            }
            if (gcView.GetRowCellValue(gcView.FocusedRowHandle, "cRefType").ToString() == "收款额")
            {
                if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("SELECT COUNT(*) FROM Ap_CloseBill WHERE MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND YEAR(dVouchDate)=YEAR(GETDATE())-3 AND cDepcode='" + lueDepartment.Properties.ValueMember.ToString() + "'")) == 0)
                {
                    gcView.SetRowCellValue(gcView.FocusedRowHandle, "nRate1", 0);
                }
                if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("SELECT COUNT(*) FROM Ap_CloseBill WHERE MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND YEAR(dVouchDate)=YEAR(GETDATE())-2 AND cDepcode='" + lueDepartment.Properties.ValueMember.ToString() + "'")) == 0)
                {
                    gcView.SetRowCellValue(gcView.FocusedRowHandle, "nRate2", 0);
                }
                if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("SELECT COUNT(*) FROM Ap_CloseBill WHERE MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND YEAR(dVouchDate)=YEAR(GETDATE())-1 AND cDepcode='" + lueDepartment.Properties.ValueMember.ToString() + "'")) == 0)
                {
                    gcView.SetRowCellValue(gcView.FocusedRowHandle, "nRate3", 0);
                }
            }
        }















    }
}
