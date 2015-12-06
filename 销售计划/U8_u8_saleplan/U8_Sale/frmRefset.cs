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
        public bool nflag=false;
        private string _CurrentStatus;

        private string _Selected;
        public string Selected
        {
            get { return _Selected; }
            set { _Selected = value; }
        }

        public string CurrentStatus
        {
            get { return _CurrentStatus; }
            set { _CurrentStatus = value; }
        }

        DataTable QueryTable = new DataTable();
        public frmRefset()
        {
            InitializeComponent();
            DataBind();
            //string StrSQL = "select cDepCode,cDepName from Department where cDepCode like '1___'";
            string StrSQL = string.Format("select  SD.cDepCode,D.cDepName FROM {0}..SL_P_DeptRef SD LEFT JOIN Department D ON SD.cDepCode=D.cDepCode ORDER BY SD.cDepCode ASC", DBHelper.SalePlanDB);
            DataSet dschem = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL);
            lueDepartment.Properties.DataSource = dschem.Tables[0];
            // gcView.OptionsBehavior.Editable = false;

            GetlueData();
            ButtonStatus("LoadForm");
        }


        # region 获得数据源

        private void DataBind()
        {

            string StrSQL = "SELECT * FROM SL_P_Refset WHERE iYear=(SELECT DATEPART(YEAR, GETDATE())) ORDER BY cDepCode,iMonth,cRefType asc ";
            DataSet ds = DBHelper.ExecuteDataset(DBHelper.ConnStrings, CommandType.Text, StrSQL);
            gcList.DataSource = ds.Tables[0];


        }


        private void GetlueData()
        {
            //string StrSQL = "select cRef1 AS cRefType FROM (SELECT SD.cDepCode,SB.cDataValue AS cRef1 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId UNION ALL SELECT SD.cDepCode,SB1.cDataValue AS cRef2 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId ) AS tmp GROUP BY cRef1";
            //string StrSQL = "select cRef1 AS cRefType FROM (SELECT SD.cDepCode,SB.cDataValue AS cRef1 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId UNION ALL SELECT SD.cDepCode,SB1.cDataValue AS cRef2 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId ) AS tmp WHERE tmp.cDepCode = '" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "cDepCode").ToString() + "'";
            string StrSQL = string.Format("SELECT d.cDepName,cRef1 AS cRefType FROM (SELECT SD.cDepCode,SB.cDataValue AS cRef1 FROM {0}..SL_P_DeptRef SD LEFT JOIN  {1}..SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN {2}..SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId UNION ALL SELECT SD.cDepCode,SB1.cDataValue AS cRef2 FROM {3}..SL_P_DeptRef SD LEFT JOIN  {4}..SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN {5}..SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId ) AS tmp LEFT JOIN Department d ON tmp.cDepCode=d.cDepCode ", DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB);
            DataSet ds = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL);
            luecRef.Properties.DataSource = ds.Tables[0];
        }

        # endregion

        # region 按钮控制

        /// <summary>
        /// 按钮状态控制
        /// </summary>
        /// <param name="strButtonName"></param>
        private void ButtonStatus(string strButtonName)
        {
            switch (strButtonName)
            {
                case "LoadForm":
                    if (!string.IsNullOrEmpty(_Selected))
                    {
                        if (_CurrentStatus == "Modify") //修改状态
                        {

                            tsbNew.Enabled = true;
                            tsbDel.Enabled = true;
                            tsbSave.Enabled = true;

                            tsbModify.Enabled = false;

                            gcView.OptionsBehavior.Editable = true;

                        }
                        else if (_CurrentStatus == "View") //查看状态
                        {

                            tsbNew.Enabled = false;
                            tsbDel.Enabled = false;
                            tsbSave.Enabled = false;

                            tsbModify.Enabled = false;

                            gcView.OptionsBehavior.Editable = false;

                        }
                    }
                    else //新增状态
                    {

                        tsbNew.Enabled = true;
                        tsbDel.Enabled = true;
                        tsbSave.Enabled = true;
                        tsbModify.Enabled = false;

                    }
                    break;
                case "btnInsertRow":

                    tsbNew.Enabled = true;
                    tsbDel.Enabled = true;
                    tsbSave.Enabled = true;

                    tsbModify.Enabled = false;

                    gcView.OptionsBehavior.Editable = true;
                    break;
                case "btnDelRow":

                    tsbNew.Enabled = true;
                    tsbDel.Enabled = true;
                    tsbSave.Enabled = true;
                    tsbModify.Enabled = false;

                    break;

                case "btnModify":

                    tsbNew.Enabled = true;
                    tsbDel.Enabled = true;
                    tsbSave.Enabled = true;

                    tsbModify.Enabled = false;

                    break;
                case "searth":

                    tsbNew.Enabled = true;
                    tsbDel.Enabled = true;
                    tsbSave.Enabled = false;
                    tspAllAdd.Enabled = false;
                    tsbModify.Enabled = false;
                    tsbAllModify.Enabled = true;

                    break;

            }
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
            dsshcem.Columns.Add("nRate1", typeof(double));
            dsshcem.Columns.Add("nRate2", typeof(double));
            dsshcem.Columns.Add("nRate3", typeof(double));

            if (gcView.RowCount > 0)
            {
                for (int i = 0; i < gcView.RowCount - 1; i++)
                {
                    dr = dsshcem.NewRow();
                    //dr["cId"] = Guid.NewGuid().ToString();
                    dr["cId"] = gcView.GetRowCellValue(i, "cId").ToString();
                    dr["cDepCode"] = gcView.GetRowCellValue(i, "cDepCode").ToString();
                    dr["iYear"] = gcView.GetRowCellValue(i, "iYear").ToString();
                    //dr["iYear"] = DateTime.Now.Year.ToString();
                    dr["cRefType"] = gcView.GetRowCellValue(i, "cRefType").ToString();
                    dr["iMonth"] = gcView.GetRowCellValue(i, "iMonth").ToString();
                    dr["nRate1"] = string.IsNullOrEmpty(gcView.GetRowCellValue(i, "nRate1").ToString()) ? "0" : gcView.GetRowCellValue(i, "nRate1").ToString();
                    dr["nRate2"] = string.IsNullOrEmpty(gcView.GetRowCellValue(i, "nRate2").ToString()) ? "0" : gcView.GetRowCellValue(i, "nRate2").ToString();
                    dr["nRate3"] = string.IsNullOrEmpty(gcView.GetRowCellValue(i, "nRate3").ToString()) ? "0" : gcView.GetRowCellValue(i, "nRate3").ToString();
                    dsshcem.Rows.Add(dr);
                    dsshcem.AcceptChanges();



                }
            }
            return dsshcem;


        }


        private void savadata(string msg)
        {
            //DataRow dr;
            DataTable dtDetail = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("cId", typeof(Guid));
            dt.Columns.Add("cDepCode", typeof(string));
            dt.Columns.Add("iYear", typeof(int));
            dt.Columns.Add("cRefType", typeof(string));
            dt.Columns.Add("iMonth", typeof(int));
            dt.Columns.Add("nRate1", typeof(double));
            dt.Columns.Add("nRate2", typeof(double));
            dt.Columns.Add("nRate3", typeof(double));

            gcView.UpdateCurrentRow();
            //dtDetail = GetTable(gcView).Copy();
            dt = GetTable(gcView).Copy();
            if (nflag == false)
            {
                DBHelper.ExecuteNonQuery(DBHelper.ConnStrings, CommandType.Text, string.Format("delete from SL_P_Refset where iYear=(SELECT DATEPART(YEAR, GETDATE()))"));
            }
            //if (dtDetail.Rows.Count > 0)
            //{
            //    for (int r = 0; r < dtDetail.Rows.Count; r++)
            //    {
            //        dr = dt.NewRow();
            //        dr["cId"] = dtDetail.Rows[r]["cId"].ToString();
            //        dr["cDepCode"] = dtDetail.Rows[r]["cDepCode"].ToString();
            //        dr["iYear"] = dtDetail.Rows[r]["iYear"].ToString();
            //        dr["cRefType"] = dtDetail.Rows[r]["cRefType"].ToString();
            //        dr["iMonth"] = dtDetail.Rows[r]["iMonth"].ToString();
            //        dr["nRate1"] = Convert.ToDouble(dtDetail.Rows[r]["nRate1"].ToString());
            //        dr["nRate2"] = Convert.ToDouble(dtDetail.Rows[r]["nRate2"].ToString());
            //        dr["nRate3"] = Convert.ToDouble(dtDetail.Rows[r]["nRate3"].ToString());

            //        //dr["nRate2"] = dtDetail.Rows[r]["nRate2"].ToString();
            //        //dr["nRate3"] = dtDetail.Rows[r]["nRate3"].ToString();

            //        dt.Rows.Add(dr.ItemArray);
            //        dt.AcceptChanges();
            //    }
            //}
            dt.AcceptChanges();
            DBHelper.SqlBulkCopyInsert("SL_P_Refset", dt, DBHelper.ConnStrings, msg);



        }

        private void sava()
        {
            gcView.PostEditor();
            gcView.CloseEditor();
            gcView.UpdateCurrentRow();
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
            //gcView.OptionsBehavior.Editable = false;
            ButtonStatus("LoadForm");
        }

        # endregion

        # region 新增
        private void New()
        {
            gcView.PostEditor();
            gcView.UpdateCurrentRow();
            gcView.AddNewRow();
            gcView.SetRowCellValue(gcView.FocusedRowHandle, "cId",Guid.NewGuid());
            gcView.SetRowCellValue(gcView.FocusedRowHandle, "iYear", DateTime.Now.Year.ToString());

            //gcView.OptionsBehavior.Editable = true;

        }
        # endregion

        # region 删除

        private void del()
        {

            
            if (gcView.FocusedRowHandle < 0) return;
            DataRow dr=gcView.GetDataRow(gcView.FocusedRowHandle);
            if (MessageBox.Show(this, "真的要删除本卡记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DBHelper.ExecuteNonQuery(DBHelper.ConnStrings, CommandType.Text, string.Format("delete from SL_P_Refset  where cId='" + dr["cId"].ToString() + "'"));
            gcView.DeleteRow(gcView.FocusedRowHandle);
                
           
        }


        # endregion


        //# region  检查是否存在相同数据

        ///// <summary>
        ///// 检查是否存在相同数据
        ///// </summary>
        ///// <param name="fchrItemCode"></param>
        ///// <param name="fchrFree1"></param>
        ///// <returns></returns>
        //private bool Checkdata(string cDepCode)
        //{
        //    bool bFlag = false;
        //    if (gcView.RowCount > 0)
        //    {
        //        for (int r = 0; r < gcView.RowCount - 1; r++)
        //        {
        //            if (gcView.GetRowCellValue(r, "cDepCode").ToString() == cDepCode)
        //            {
        //                bFlag = true;
        //                break;
        //            }
        //        }
        //    }

        //    return bFlag;
        //}

        //# endregion 

        private void tsbModify_Click(object sender, EventArgs e)
        {
            // gcView.OptionsBehavior.Editable = true;
            ButtonStatus("btnModify");
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            del();
            ButtonStatus("btnDelRow");

        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            sava();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            New();
            //gcView.OptionsBehavior.Editable = true;
            ButtonStatus("btnInsertRow");
        }




        private void cboiMonth_EditValueChanged(object sender, EventArgs e)
        {
            if (lueDepartment.Properties.ValueMember.ToString() == "")
            {
                MessageBox.Show("部门不能为空，请选择！", "系统提示");
                return;
            }
            
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            frmQueryRefset QueryForm = new frmQueryRefset();
            QueryForm.ShowDialog();
            if (QueryForm.DialogResult == DialogResult.OK)
            {
                //string StrSQL = "SELECT * FROM SL_P_Refset WHERE iYear=(SELECT DATEPART(YEAR, GETDATE())) ";
                //DataSet ds = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL);
                //gcList.DataSource = ds.Tables[0];
                gcList.DataSource = QueryForm.Dgv.Tables[0];
                QueryTable = QueryForm.Dgv.Tables[0];
                QueryForm.Close();
            }
            ButtonStatus("searth");
        }

        private void tspAllAdd_Click(object sender, EventArgs e)
        {
            YearSelect frm = new YearSelect();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                string iYear = frm.iYear;
                gcView.Columns["nRate1"].Caption = Convert.ToString(Convert.ToInt16(iYear) - 3) + "年";
                gcView.Columns["nRate2"].Caption = Convert.ToString(Convert.ToInt16(iYear) - 2) + "年";
                gcView.Columns["nRate3"].Caption = Convert.ToString(Convert.ToInt16(iYear) - 1) + "年";
                DataTable dt = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, string.Format(string.Format(@"SELECT tmp.cDepCode,d.cDepName,cRef1 AS cRefType FROM (SELECT SD.cDepCode,SB.cDataValue AS cRef1 FROM {0}..SL_P_DeptRef SD LEFT JOIN  {1}..SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN {2}..SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId UNION ALL SELECT SD.cDepCode,SB1.cDataValue AS cRef2 FROM {3}..SL_P_DeptRef SD LEFT JOIN  {4}..SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN {5}..SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId ) AS tmp LEFT JOIN Department d 
ON tmp.cDepCode=d.cDepCode ORDER BY tmp.cDepCode ASC", DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB))).Tables[0];



                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int month = 1; month < 13; month++)
                    {
                        for (int a = 0; a < 3; a++)
                        {
                            gcView.AddNewRow();
                            gcView.SetRowCellValue(gcView.FocusedRowHandle, "cId", Guid.NewGuid());
                            gcView.SetRowCellValue(gcView.FocusedRowHandle, "cDepCode", dt.Rows[i]["cDepCode"].ToString());
                            gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefType", dt.Rows[i]["cRefType"].ToString());
                            //gcView.SetRowCellValue(gcView.FocusedRowHandle, "iYear", DateTime.Now.Year.ToString());
                            gcView.SetRowCellValue(gcView.FocusedRowHandle, "iYear",iYear);
                            gcView.SetRowCellValue(gcView.FocusedRowHandle, "iMonth", month);

                        }
                    }
                }
            }

        }

        private void gcView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void tsbAllModify_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < QueryTable.Rows.Count; i++)
            {
                DBHelper.ExecuteNonQuery(DBHelper.ConnStrings, CommandType.Text, string.Format("delete from SL_P_Refset  where cId='" +QueryTable.Rows[i]["cId"].ToString()+"'"));
            }
            nflag = true;
            sava();

        }
    }
}
