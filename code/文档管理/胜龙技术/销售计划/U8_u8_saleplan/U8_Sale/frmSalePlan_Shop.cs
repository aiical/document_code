﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace U8_Sale
{
    public partial class frmSalePlan_Shop : UserControl
    {
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

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

       
        public frmSalePlan_Shop()
        {
            InitializeComponent();
            DataBind();
            ButtonStatus("LoadForm");
            string StrSQL1 = "SELECT cCusCode,cCusName FROM Customer WHERE cCusCode LIKE 'MD%'";
            DataSet dschem1 = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL1);
            luecCusCode.Properties.DataSource = dschem1.Tables[0];
            string StrSQL2 = "SELECT cDepCode,cDepName FROM Department WHERE cDepCode LIKE '100____'";
            DataSet dschem2 = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL2);
            luecDepCode.Properties.DataSource = dschem2.Tables[0];
            string StrSQL3 = "SELECT cDepCode AS cShopCode,cDepName FROM Department WHERE cDepCode LIKE '100_______'";
            DataSet dschem3 = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL3);
            luecShopCode.Properties.DataSource = dschem3.Tables[0];
               
           
        }

        #region 获取数据源
        private void DataBind()
        {
            string StrSQL = "SELECT * FROM SL_P_SalePlan_Shop";
            DataSet ds = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL);
            if (!ds.Tables[0].Columns.Contains("cRefs1"))
            {
                ds.Tables[0].Columns.Add("cRefs1", typeof(int));

            }
            if (!ds.Tables[0].Columns.Contains("cRefs2"))
            {
                ds.Tables[0].Columns.Add("cRefs2", typeof(int));

            }
            gcList.DataSource = ds.Tables[0];

            //this.lueDepartment.Properties.ValueMember = "cDepName";
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
                            tsbNewVoucher.Enabled = true;
                            tsbNew.Enabled = true;
                            tsbDel.Enabled = true;
                            tsbSave.Enabled = true;
                            tsbEmpty.Enabled = false;
                            tsbModify.Enabled = false;
                           
                            tsbDelete.Enabled = true;
                            gcView.OptionsBehavior.Editable = true;

                        }
                        else if (_CurrentStatus == "View") //查看状态
                        {
                            tsbNewVoucher.Enabled = false;
                            tsbNew.Enabled = false;
                            tsbDel.Enabled = false;
                            tsbSave.Enabled = false;
                            tsbEmpty.Enabled = false;
                            tsbModify.Enabled = false;
                            
                            tsbDelete.Enabled = false;
                            gcView.OptionsBehavior.Editable = false;

                        }
                    }
                    else //新增状态
                    {
                        tsbNewVoucher.Enabled = true;
                        tsbNew.Enabled = false;
                        tsbDel.Enabled = false;
                        tsbSave.Enabled = false;
                        tsbEmpty.Enabled = false;
                        tsbModify.Enabled = false;
                       
                        tsbDelete.Enabled = false;
                        

                    }
                    break;
                case "btnNewVoucher":
                    tsbNewVoucher.Enabled = false;
                    tsbNew.Enabled = true;
                    tsbDel.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbEmpty.Enabled = false;
                    tsbModify.Enabled = false;
                    
                    tsbDelete.Enabled = false;
                    gcView.OptionsBehavior.Editable = false;
                    break;
                case "btnInsertRow":
                    tsbNewVoucher.Enabled = false;
                    tsbNew.Enabled = true;
                    tsbDel.Enabled = true;
                    tsbSave.Enabled = true;
                    tsbEmpty.Enabled = true;
                    tsbModify.Enabled = false;
                    
                    tsbDelete.Enabled = false;
                    gcView.OptionsBehavior.Editable = true;
                    break;
                case "btnDelRow":
                    tsbNewVoucher.Enabled = false;
                    tsbNew.Enabled = true;
                    tsbDel.Enabled = true;
                    tsbSave.Enabled = true;
                    tsbModify.Enabled = false;
                    if (gcView.RowCount > 0)
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
                    tsbNewVoucher.Enabled = false;
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

        # region  将控件恢复到原始状态

        /// <summary>
        /// 将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {

            //清空表头数据并且赋值给相关字段


            luecDepCode.EditValue = "";
            luecCusCode.EditValue = "";
            luecShopCode.EditValue = "";
            this.txtcMemo.EditValue = "";
            //清空表体数据
            if (gcView.RowCount > 1)
            {
                for (int i = 0; i < gcView.RowCount - 1; i++)
                {

                    gcView.DeleteRow(i);
                }
            }
        }

        # endregion

        private void New()
        {
            if (luecDepCode.EditValue.ToString() == "")
            {
                MessageBox.Show("办事处不能为空，请选择！", "系统提示");
                return;
            }
            //if (luecCusCode.EditValue.ToString() == "")
            //{
            //    MessageBox.Show("客户不能为空，请选择！", "系统提示");
            //    return;
            //}
            if (luecShopCode.EditValue.ToString() == "")
            {
                MessageBox.Show("门店不能为空，请选择！", "系统提示");
                return;
            }
            gcView.AddNewRow();


        }

        #region 删行
        private void del()
        {


            int iselectindex = gcView.FocusedRowHandle;
            if (gcView.FocusedRowHandle < 0) return;
            if (MessageBox.Show(this, "真的要删除本卡记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("delete from SL_P_SalePlan_Shop where cSalePlanSId='" + gcView.GetRowCellValue(iselectindex, "cSalePlanSId").ToString() + "'"));

        }

        #endregion

        # region 保存
        private DataTable GetTable(DevExpress.XtraGrid.Views.Grid.GridView dgv)
        {

            DataRow dr;
            DataTable dsshcem = new DataTable();
            dsshcem.Columns.Add("cSalePlanSId", typeof(Guid));
            dsshcem.Columns.Add("iMonth", typeof(int));
            dsshcem.Columns.Add("nAmount", typeof(decimal));
            dsshcem.Columns.Add("cMemo", typeof(string));
            if (gcView.RowCount > 0)
            {
                for (int i = 0; i < gcView.RowCount - 1; i++)
                {
                    dr = dsshcem.NewRow();
                    dr["cSalePlanSId"] = Guid.NewGuid().ToString();
                    dr["iMonth"] = gcView.GetRowCellValue(i, "iMonth").ToString();
                    dr["nAmount"] = gcView.GetRowCellValue(i, "nAmount").ToString();
                    dr["cMemo"] = gcView.GetRowCellValue(i, "cMemo").ToString();
                    dsshcem.Rows.Add(dr);
                    dsshcem.AcceptChanges();

                }

            }
            return dsshcem;


        }

        private void savadata(string msg)
        {
            DataRow dr;
            DataTable dtMain = new DataTable();
            DataTable dtDetail = new DataTable();
            //构建表结构
            dtMain.Columns.Add("cSalePlanId", typeof(Guid));
            dr = dtMain.NewRow();
           //构建表数据
            dr["cSalePlanId"] = Guid.NewGuid().ToString();
            string cSalePlanId = dr["cSalePlanId"].ToString();
            dtMain.Rows.Add(dr);
            dtMain.AcceptChanges();
            gcView.UpdateCurrentRow();
            dtDetail = GetTable(gcView).Copy();
            //构建细表数据
            if (dtDetail.Rows.Count > 0)
            {
                for (int r = 0; r < dtDetail.Rows.Count; r++)
                {
                    
                    if (!dtDetail.Columns.Contains("cSalePlanId"))
                    {
                        dtDetail.Columns.Add("cSalePlanId", typeof(Guid));
                        dtDetail.Rows[r]["cSalePlanId"] = cSalePlanId;
                    }
                    else
                    {
                        dtDetail.Rows[r]["cSalePlanId"] = cSalePlanId;
                    }
                    if (!dtDetail.Columns.Contains("cCusCode"))
                    {
                        dtDetail.Columns.Add("cCusCode", typeof(string));
                        dtDetail.Rows[r]["cCusCode"] = luecCusCode.EditValue.ToString();

                    }
                    else
                    {
                        dtDetail.Rows[r]["cCusCode"] = luecCusCode.EditValue.ToString();
                    }
                    if (!dtDetail.Columns.Contains("cShopCode"))
                    {
                        dtDetail.Columns.Add("cShopCode", typeof(string));
                        dtDetail.Rows[r]["cShopCode"] = luecShopCode.EditValue.ToString();

                    }
                    else
                    {
                        dtDetail.Rows[r]["cShopCode"] = luecShopCode.EditValue.ToString();
                    }
                    if (!dtDetail.Columns.Contains("cDepCode"))
                    {
                        dtDetail.Columns.Add("cDepCode", typeof(string));
                        dtDetail.Rows[r]["cDepCode"] = luecDepCode.EditValue.ToString();

                    }
                    else
                    {
                        dtDetail.Rows[r]["cDepCode"] = luecDepCode.EditValue.ToString();
                    }


                    dtDetail.AcceptChanges();
                }
            }
            DBHelper.SqlBulkCopyInsert("SL_P_SalePlan_Shop", dtDetail, DBHelper.ConnString, msg);




        }

        private void sava()
        {
            string Msg = string.Empty;

            string Department = DBHelper.GetDatas("cShopCode", "SL_P_SalePlan_Shop", "iYear", DateTime.Now.Year.ToString());
            gcView.PostEditor();
            gcView.CloseEditor();
            gcView.UpdateCurrentRow();
            if (gcView.RowCount < 1)
            {
                MessageBox.Show("保存数据为空，不允许保存！");
                return;
            }
            if (!CheckDataIsValid(gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString(), Department, ref Msg))
            {
                MessageBox.Show(Msg);
                return;
            }


            savadata(Msg);



            if (string.IsNullOrEmpty(Msg))
            {
                MessageBox.Show("数据保存成功！");
                btndailyAdd.Enabled = true;
            }
            else
            {
                MessageBox.Show("数据保存失败！" + Msg);
                return;
            }

            gcView.RefreshData();
            ButtonStatus("LoadForm");

        }
        #endregion


        # region   检查数据
        /// <summary>
        /// 检查数据
        /// </summary>
        /// <param name="ErrMsg"></param>
        /// <returns></returns>
        private bool CheckDataIsValid(string iMonth, string Department, ref string ErrMsg)
        {

            bool bFlag = true;

            //检查单据编号是否为空
            if (string.IsNullOrEmpty(luecDepCode.EditValue.ToString()))
            {
                ErrMsg = "办事处不允许为空！";
                bFlag = false;
            }

            //检查月份是否为空
            if (bFlag)
            {
                if (gcView.RowCount > 0)
                {
                    for (int r = 0; r < gcView.RowCount - 1; r++)
                    {
                        if (string.IsNullOrEmpty(gcView.GetRowCellValue(r, "iMonth").ToString()))
                        {
                            ErrMsg = "第" + r + "行月份不允许为空！";
                            bFlag = false;
                            break;
                        }
                    }
                }
            }

            //检查计划值是否为空
            if (bFlag)
            {
                if (gcView.RowCount > 0)
                {
                    for (int r = 0; r < gcView.RowCount - 1; r++)
                    {
                        if (gcView.GetRowCellValue(r, "nAmount").ToString() == null)
                        {
                            ErrMsg = "第" + r + "行计划值不允许为空！";
                            bFlag = false;
                            break;
                        }


                    }
                }
            }
            //检查是否已经制定过选择部门的销售计划

            if (bFlag)
            {
                if (luecShopCode.EditValue.ToString() == Department)
                {
                    ErrMsg = "该门店的销售计划已经制做了！";
                    bFlag = false;


                }

            }

            //检查明细表是否存在相同的月份
            if (bFlag)
            {
                if (gcView.RowCount > 0)
                {
                    for (int r = 0; r < gcView.RowCount - 2; r++)
                    {
                        if (gcView.GetRowCellValue(r, "iMonth").ToString() == iMonth)
                        {
                            ErrMsg = "该月份已经选择过了，请重新选择";
                            bFlag = false;
                            break;
                        }


                    }
                }
            }


            return bFlag;
        }

        # endregion


        private void tsbNewVoucher_Click(object sender, EventArgs e)
        {
            ButtonStatus("btnNewVoucher");
            ClearControls();
        }

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

        private void tsbEmpty_Click(object sender, EventArgs e)
        {
            if (gcView.RowCount > 1)
            {
                for (int i = 0; i < gcView.RowCount - 1; i++)
                {

                    gcView.DeleteRow(i);
                }
            }
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

        private void cboiMonth_EditValueChanged(object sender, EventArgs e)
        {
            gcView.PostEditor();
            if (gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() == "")
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
                string STRSQL="SELECT SD.cDepCode,SB.cDataValue AS cRef1,SB1.cDataValue AS cRef2 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId";
                ds = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, STRSQL);
                r = ds.Tables[0];
                string condition = "cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString()+ "',1,4)";
                Newdt = GetNewDataTable(r, condition);
                for (int i = 0; i < Newdt.Rows.Count; i++)
                {

                    if (Newdt.Rows[i]["cRef1"].ToString() == "销售额")
                    {

                        //double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString()+ "',1,4)")));
                        //double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs1", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);
                        double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;

                        gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs1", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);
                    
                    
                    }
                    if (Newdt.Rows[i]["cRef1"].ToString() == "开票额")
                    {
                        //double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM SaleBillVouch s  left join SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM SaleBillVouch s left join SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM SaleBillVouch s  left join SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='开票额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='开票额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='开票额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs1", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);
                        double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;

                        gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs1", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);
                    }
                    if (Newdt.Rows[i]["cRef1"].ToString() == "收款额")
                    {
                        //double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='收款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='收款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='收款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs1", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);
                        double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;

                        gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs1", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);

                    }
                    if (Newdt.Rows[i]["cRef1"].ToString() == "汇款额")
                    {
                        //double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='汇款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='汇款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='汇款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs1", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);
                        double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;

                        gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs1", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);
                    }

                    if (Newdt.Rows[i]["cRef2"].ToString() == "销售额")
                    {

                        //double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        
                        gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs2", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);

                    }
                    if (Newdt.Rows[i]["cRef2"].ToString() == "开票额")
                    {
                        //double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM SaleBillVouch s  left join SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM SaleBillVouch s left join SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM SaleBillVouch s  left join SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='开票额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='开票额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='开票额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs2", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);
                        double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;

                        gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs2", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);
                    }
                    if (Newdt.Rows[i]["cRef2"].ToString() == "收款额")
                    {
                        //double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='收款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='收款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='收款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs2", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);
                        double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;

                        gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs2", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);
                    }
                    if (Newdt.Rows[i]["cRef2"].ToString() == "汇款额")
                    {
                        //double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4)")));
                        //double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='汇款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='"+DateTime.Now.Year.ToString()+"'"))) / 100;
                        //double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='汇款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='汇款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        //gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs2", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);
                        double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode='" + luecShopCode.EditValue.ToString() + "'")));
                        double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;
                        double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode=SUBSTRING('" + luecShopCode.EditValue.ToString() + "',1,4) and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + DateTime.Now.Year.ToString() + "'"))) / 100;

                        gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs2", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);
                    }
                }
                gcView.CloseEditor();
                gcView.UpdateCurrentRow();
            }
            
        }

        private void btndaily_Click(object sender, EventArgs e)
        {

            frmSalePlanSdaily frm = new frmSalePlanSdaily();
            frm.cShopCode = luecShopCode.EditValue.ToString();
            frm.cDepCode = luecDepCode.EditValue.ToString();
            frm.nAmount = gcView.GetRowCellValue(gcView.FocusedRowHandle, "nAmount").ToString();
            frm.cSalePlanSId = gcView.GetRowCellValue(gcView.FocusedRowHandle, "cSalePlanSId").ToString();
            frm.iMonth = gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString();
            frm.ShowDialog();
            

        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string strsql = "delete from SL_P_SalePlan_Shop where cSalePlanId=" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "cSalePlanId").ToString() + "";
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
