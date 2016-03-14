using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace U8_Sale
{
    public partial class frmSalePlanSdaily : Form
    {
        public bool bFlag = false;

        private string _cShopCode;
        public string cShopCode
        {
            get { return _cShopCode; }
            set { _cShopCode = value; }
        }

        private string _cDepCode;
        public string cDepCode
        {
            get { return _cDepCode; }
            set { _cDepCode = value; }
        }

        private string _nAmount;
        public string nAmount
        {
            get { return _nAmount; }
            set { _nAmount = value; }
        }

        private string _cSalePlanSId;
        public string cSalePlanSId
        {
            get { return _cSalePlanSId; }
            set { _cSalePlanSId = value; }
        }

        private string _iMonth;
        public string iMonth
        {
            get { return _iMonth; }
            set { _iMonth = value; }
        }

        
        

        private string _Selected;
        public string Selected
        {
            get { return _Selected; }
            set { _Selected = value; }
        }

        private string _CurrentStatus;

        public string CurrentStatus
        {
            get { return _CurrentStatus; }
            set { _CurrentStatus = value; }
        }

        public frmSalePlanSdaily()
        {
            InitializeComponent();
            ButtonStatus("LoadForm");
            luecDepCode.Properties.DataSource = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, string.Format("SELECT cDepCode,cDepName FROM Department")).Tables[0];
            luecShopCode.Properties.DataSource = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, string.Format("SELECT cDepCode AS cShopCode,cDepName FROM  Department")).Tables[0];
        }

   

        #region 获取数据源
        private void DataBind()
        {
            string StrSQL = "SELECT * FROM SL_P_SalePlanS_daily where cSalePlanSId='" + this.cSalePlanSId + "'ORDER BY dDate ASC";
            DataSet ds = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL);
            //if (!ds.Tables[0].Columns.Contains("cRefs1"))
            //{
            //    ds.Tables[0].Columns.Add("cRefs1", typeof(int));

            //}
            //if (!ds.Tables[0].Columns.Contains("cRefs2"))
            //{
            //    ds.Tables[0].Columns.Add("cRefs2", typeof(int));

            //}
            if (!ds.Tables[0].Columns.Contains("jjr"))
            {
                ds.Tables[0].Columns.Add("jjr", typeof(DateTime));
            }
            gcList.DataSource = ds.Tables[0];

           
        }

        #endregion

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
                            tsbEmpty.Enabled = false;
                            tsbModify.Enabled = false;

                            tsbDelete.Enabled = true;
                            gdView.OptionsBehavior.Editable = true;

                        }
                        else if (_CurrentStatus == "View") //查看状态
                        {
                            
                            tsbNew.Enabled = false;
                            tsbDel.Enabled = false;
                            tsbSave.Enabled = false;
                            tsbEmpty.Enabled = false;
                            tsbModify.Enabled = false;

                            tsbDelete.Enabled = false;
                            gdView.OptionsBehavior.Editable = false;

                        }
                    }
                    else //新增状态
                    {
                        
                        tsbNew.Enabled = true;
                        tsbDel.Enabled = true;
                        tsbSave.Enabled = true;
                        tsbEmpty.Enabled = false;
                        tsbModify.Enabled = false;

                        tsbDelete.Enabled = false;

                    }
                    break;
                case "btnNewVoucher":
                    
                    tsbNew.Enabled = true;
                    tsbDel.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbEmpty.Enabled = false;
                    tsbModify.Enabled = false;

                    tsbDelete.Enabled = false;
                    gdView.OptionsBehavior.Editable = false;
                    break;
                case "btnInsertRow":
                    
                    tsbNew.Enabled = true;
                    tsbDel.Enabled = true;
                    tsbSave.Enabled = true;
                    tsbEmpty.Enabled = true;
                    tsbModify.Enabled = false;

                    tsbDelete.Enabled = false;
                    gdView.OptionsBehavior.Editable = true;
                    break;
                case "btnDelRow":
                    
                    tsbNew.Enabled = true;
                    tsbDel.Enabled = true;
                    tsbSave.Enabled = true;
                    tsbModify.Enabled = false;
                    if (gdView.RowCount > 0)
                    {
                        tsbEmpty.Enabled = true;
                    }
                    else
                    {
                        tsbEmpty.Enabled = false;
                    }

                    tsbDelete.Enabled = false;
                    break;

                case "btnModify":
                    
                    tsbNew.Enabled = true;
                    tsbDel.Enabled = true;
                    tsbSave.Enabled = true;
                    tsbEmpty.Enabled = true;
                    tsbModify.Enabled = false;

                    tsbDelete.Enabled = false;
                    break;

            }
        }
        # endregion

        private void New()
        {
            
            
            gdView.AddNewRow();


        }

        #region 删行
        private void del()
        {


            int iselectindex = gdView.FocusedRowHandle;
            if (gdView.FocusedRowHandle < 0) return;
            if (MessageBox.Show(this, "真的要删除本卡记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("delete from SL_P_SalePlanS_daily where cDailyId='" + gdView.GetRowCellValue(iselectindex, "cDailyId").ToString() + "'"));

        }

        #endregion

        # region 保存
        private DataTable GetTable(DevExpress.XtraGrid.Views.Grid.GridView dgv)
        {

            DataRow dr;
            DataTable dsshcem = new DataTable();
            dsshcem.Columns.Add("cDailyId", typeof(Guid));
            dsshcem.Columns.Add("dDate", typeof(int));
            dsshcem.Columns.Add("nAmount", typeof(decimal));
            dsshcem.Columns.Add("cRefs1", typeof(double));
            dsshcem.Columns.Add("cRefs1", typeof(double));
            dsshcem.Columns.Add("cMemo", typeof(string));
            if (gdView.RowCount > 0)
            {
                for (int i = 0; i < gdView.RowCount - 1; i++)
                {
                    dr = dsshcem.NewRow();
                    dr["cDailyId"] = Guid.NewGuid().ToString();
                    dr["dDate"] = gdView.GetRowCellValue(i, "dDate").ToString();
                    dr["nAmount"] = gdView.GetRowCellValue(i, "nAmount").ToString();
                    dr["cRefs1"] = gdView.GetRowCellValue(i, "cRefs1").ToString();
                    dr["cRefs2"] = gdView.GetRowCellValue(i, "cRefs2").ToString();
                    dr["cMemo"] = gdView.GetRowCellValue(i, "cMemo").ToString();
                    dsshcem.Rows.Add(dr);
                    dsshcem.AcceptChanges();

                }

            }
            return dsshcem;


        }

        private void savadata(string msg)
        {
          
            DataTable dtDetail = new DataTable();
            gdView.PostEditor();
            gdView.UpdateCurrentRow();
            dtDetail = GetTable(gdView).Copy();
            //构建细表数据
            if (dtDetail.Rows.Count > 0)
            {
                for (int r = 0; r < dtDetail.Rows.Count; r++)
                {

                    if (!dtDetail.Columns.Contains("cSalePlanSId"))
                    {
                        dtDetail.Columns.Add("cSalePlanSId", typeof(Guid));
                        dtDetail.Rows[r]["cSalePlanSId"] = this.cSalePlanSId;
                    }
                    else
                    {
                        dtDetail.Rows[r]["cSalePlanSId"] = this.cSalePlanSId;
                    }
                 
                    

                    dtDetail.AcceptChanges();
                }
            }
            DBHelper.SqlBulkCopyInsert("SL_P_SalePlan_Shop", dtDetail, DBHelper.ConnString, msg);




        }

        private void sava()
        {
            string Msg = string.Empty;

            //string Department = DBHelper.GetDatas("cShopCode", "SL_P_SalePlan_Shop", "iYear", DateTime.Now.Year.ToString());
            gdView.PostEditor();
            gdView.CloseEditor();
            gdView.UpdateCurrentRow();
            if (gdView.RowCount < 1)
            {
                MessageBox.Show("保存数据为空，不允许保存！");
                return;
            }
            //if (!CheckDataIsValid(gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString(), Department, ref Msg))
           // {
               // MessageBox.Show(Msg);
               // return;
            //}


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

            gdView.RefreshData();
            ButtonStatus("LoadForm");

        }
        #endregion

        private void tsbModify_Click(object sender, EventArgs e)
        {
            ButtonStatus("btnModify");
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            New();
            ButtonStatus("btnInsertRow");
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

        private DataTable GetNewDataTable(DataTable dt, string condition)
        {
            DataTable newdt = new DataTable();
            newdt = dt.Clone();
            DataRow[] dr = dt.Select(condition);
            for (int i = 0; i < dr.Length; i++)
            {
                newdt.ImportRow((DataRow)dr[i]);
            }
            return newdt;//返回的查询结果
        }

        private void cbodDate_EditValueChanged(object sender, EventArgs e)
        {
            gdView.PostEditor();
            if (gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() == "")
            {
                MessageBox.Show("月份为空，请选择！", "系统提示");
                return;

            }
           
            else
            {
                DataTable Newdt = new DataTable();
                DataTable r = new DataTable();
                DataSet ds = new DataSet();
                //string STRSQL = "SELECT SD.cDeptRefId,SD.cDepCode,SB.cDataValue AS cRef1,SB1.cDataValue AS cRef2 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId";
                string STRSQL = "SELECT SD.cDepCode,SB.cDataValue AS cRef1,SB1.cDataValue AS cRef2 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId";
                ds = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, STRSQL);
                r = ds.Tables[0];
                string condition = "cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)";
                Newdt = GetNewDataTable(r, condition);
                for (int i = 0; i < Newdt.Rows.Count; i++)
                {

                    if (Newdt.Rows[i]["cRef1"].ToString() == "销售额")
                    {

                        double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "'and Day(dDate)='Day('"+gdView.GetRowCellValue(gdView.FocusedRowHandle, "dDate").ToString()+"')' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and Day(dDate)='Day('" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "dDate").ToString() + "')' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and Day(dDate)='Day('" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "dDate").ToString() + "')' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        gdView.SetRowCellValue(gdView.FocusedRowHandle, "cRefs1", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);

                    }
                    if (Newdt.Rows[i]["cRef1"].ToString() == "开票额")
                    {
                        //double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "'and Day(dDate)='Day('" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "dDate").ToString() + "')' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and Day(dDate)='Day('" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "dDate").ToString() + "')' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and Day(dDate)='Day('" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "dDate").ToString() + "')' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        gdView.SetRowCellValue(gdView.FocusedRowHandle, "cRefs1", 0);

                    }
                    if (Newdt.Rows[i]["cRef1"].ToString() == "收款额")
                    {
                        //double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "'and Day(dDate)='Day('" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "dDate").ToString() + "')' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and Day(dDate)='Day('" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "dDate").ToString() + "')' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and Day(dDate)='Day('" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "dDate").ToString() + "')' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        gdView.SetRowCellValue(gdView.FocusedRowHandle, "cRefs1", 0);

                    }
                    if (Newdt.Rows[i]["cRef1"].ToString() == "汇款额")
                    {
                        //double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "'and Day(dDate)='Day('" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "dDate").ToString() + "')' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and Day(dDate)='Day('" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "dDate").ToString() + "')' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and Day(dDate)='Day('" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "dDate").ToString() + "')' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        gdView.SetRowCellValue(gdView.FocusedRowHandle, "cRefs1", 0);

                    }

                    if (Newdt.Rows[i]["cRef2"].ToString() == "销售额")
                    {
                        double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "'and Day(dDate)='Day('" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "dDate").ToString() + "')' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and Day(dDate)='Day('" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "dDate").ToString() + "')' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and Day(dDate)='Day('" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "dDate").ToString() + "')' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        gdView.SetRowCellValue(gdView.FocusedRowHandle, "cRefs2", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);

                    }
                    if (Newdt.Rows[i]["cRef2"].ToString() == "开票额")
                    {
                        //double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM SaleBillVouch s  left join SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM SaleBillVouch s left join SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM SaleBillVouch s  left join SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='开票额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='开票额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='开票额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        gdView.SetRowCellValue(gdView.FocusedRowHandle, "cRefs2", 0);

                    }
                    if (Newdt.Rows[i]["cRef2"].ToString() == "收款额")
                    {
                        //double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='收款额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='收款额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='收款额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        gdView.SetRowCellValue(gdView.FocusedRowHandle, "cRefs2", 0);

                    }
                    if (Newdt.Rows[i]["cRef2"].ToString() == "汇款额")
                    {
                        //double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dVouchDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dVouchDate)='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='汇款额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='汇款额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='汇款额' and iMonth='" + gdView.GetRowCellValue(gdView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        gdView.SetRowCellValue(gdView.FocusedRowHandle, "cRefs2", 0);

                    }
                }
                gdView.CloseEditor();
                gdView.UpdateCurrentRow();
            }
        }

        private void frmSalePlanSdaily_Load(object sender, EventArgs e)
        {
            luecShopCode.EditValue = this.cShopCode;
            luecDepCode.EditValue = this.cDepCode;
            txtnAmount.Text = this.nAmount;
            cboiMonth.Text = this.iMonth;
            DataBind();

        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string strsql = "delete from SL_P_SalePlanS_daily where cSalePlanSId=" + this.cSalePlanSId + "";
                if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, strsql) > 0)
                {
                    MessageBox.Show("删除成功!", "系统提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除发生异常： " + ex.Message, "提示");

            }

        }

    }
}
