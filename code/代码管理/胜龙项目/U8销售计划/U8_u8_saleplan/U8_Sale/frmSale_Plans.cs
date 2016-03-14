using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace U8_Sale
{
    public partial class frmSale_Plans : Form
    {
        public bool bFlag = false;

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

        private string _SalePlanId;

        public string SalePlanId
        {
            get { return _SalePlanId; }
            set { _SalePlanId = value; }
        }


        string cSalePlanId = string.Empty;
        public frmSale_Plans()
        {

            InitializeComponent();
        
        }


        #region 获取数据源

        private void GetBaseInfo()
        {
            //string StrSQL = "SELECT TOP 1* FROM SL_P_SalePlan ORDER BY iYear DESC";
            string StrSQL = "SELECT * FROM SL_P_SalePlan where cSalePlanId='"+this.SalePlanId+"'";
            DataTable dt = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL).Tables[0];

            txtcSalePlanNo.Text = dt.Rows[0]["cSalePlanNo"].ToString();
            dtdDate.Text = dt.Rows[0]["dDate"].ToString();
            txtcMaker.Text = dt.Rows[0]["dDate"].ToString();
            lueDepartment.EditValue = dt.Rows[0]["cDepCode"].ToString();
            txtiYear.Text = dt.Rows[0]["iYear"].ToString();
            cboiStatus.Text = dt.Rows[0]["iStatus"].ToString();
            dtdVerifyDate.Text = dt.Rows[0]["dVerifyDate"].ToString();
            txtcVerifier.Text = dt.Rows[0]["cVerifier"].ToString();
            txtcMemo.Text = dt.Rows[0]["cMemo"].ToString();


        }



        private void DataBind()
        {
            string StrSQL = "select  SD.cDepCode,D.cDepName FROM SL_P_DeptRef SD LEFT JOIN Department D ON SD.cDepCode=D.cDepCode";
            DataSet dschem = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL);
            lueDepartment.Properties.DataSource = dschem.Tables[0];
            lueDepartment.Properties.ValueMember = "cDepCode";
            luecCusCode.Properties.DataSource = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, string.Format("SELECT cCusCode,cCusName FROM Customer")).Tables[0];
            luecDepCode.Properties.DataSource = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, string.Format("SELECT cDepCode,cDepName FROM Department")).Tables[0];
            luecShopCode.Properties.DataSource = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, string.Format("SELECT cDepCode AS cShopCode,cDepName FROM  Department")).Tables[0];
            gdList.DataSource = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, string.Format(@"SELECT s1.cSalePlanId,s1.cCusCode,s1.cShopCode,s1.cDepCode,s1.cMemo,s1.cRefs1 AS cRefs11 ,s1.cRefs2 AS cRefs21,s1.nAmount AS nAmount1 ,s2.cRefs1 AS cRefs12,s2.cRefs2 AS cRefs22,s2.nAmount nAmount2,s3.cRefs1 AS cRefs13,s3.cRefs2 AS cRefs23,s3.nAmount AS nAmount3,s4.cRefs1 AS cRefs14,s4.cRefs2 AS cRefs24,s4.nAmount AS nAmount4,s5.cRefs1 AS cRefs15,s5.cRefs2 AS cRefs25,s5.nAmount AS nAmount5,s6.cRefs1 AS cRefs16,s6.cRefs2 AS cRefs26,s6.nAmount AS nAmount6,s7.cRefs1 AS cRefs17,s7.cRefs2 cRefs27,s7.nAmount AS nAmount7,s8.cRefs1 AS cRefs18,s8.cRefs2 AS cRefs28,s8.nAmount AS nAmount8,s9.cRefs1 AS cRefs19,s9.cRefs2 AS cRefs29,s9.nAmount AS nAmount9,s10.cRefs1 AS cRefs110,s10.cRefs2 AS cRefs210,s10.nAmount AS nAmount10,s11.cRefs1 AS cRefs111,s11.cRefs2 AS cRefs211,s11.nAmount AS nAmount11,s12.cRefs1 AS cRefs112,s12.cRefs2 AS cRefs212,s12.nAmount AS nAmount12 FROM (SELECT * FROM SL_P_SalePlan_Shop WHERE iMonth='1') s1 LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Shop WHERE iMonth='2') s2
ON s2.cSalePlanId = s1.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Shop WHERE iMonth='3') s3
ON s3.cSalePlanId = s2.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Shop WHERE iMonth='4') s4
ON s4.cSalePlanId = s3.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Shop WHERE iMonth='5') s5
ON s5.cSalePlanId = s4.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Shop WHERE iMonth='6') s6
ON s6.cSalePlanId = s5.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Shop WHERE iMonth='7') s7
ON s7.cSalePlanId = s6.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Shop WHERE iMonth='8') s8
ON s8.cSalePlanId = s7.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Shop WHERE iMonth='9') s9
ON s9.cSalePlanId = s8.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Shop WHERE iMonth='10') s10
ON s10.cSalePlanId = s9.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Shop WHERE iMonth='11') s11
ON s11.cSalePlanId = s10.cSalePlanId
LEFT JOIN 
(SELECT * FROM SL_P_SalePlan_Shop WHERE iMonth='12') s12
ON s12.cSalePlanId = s11.cSalePlanId ")).Tables[0];
            if (bFlag == false)
            {
                string StrSQL1 = "SELECT * FROM SL_P_SalePlan_Month where cSalePlanId='" + this.SalePlanId + "'ORDER BY iMonth ASC";
                DataSet ds = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL1);
                GetBaseInfo();
                gcList.DataSource = ds.Tables[0];

                
            }
            if (bFlag == true)
            {
                string StrSQL1 = "SELECT * FROM SL_P_SalePlan_Month";
                DataSet ds = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL1);
                //GetBaseInfo();
                gcList.DataSource = ds.Tables[0];
                NewVoucher();
            }

            
        }

        #endregion


        # region  工具栏控制

        private void ControlStatus()
        {
         
            ButtonStatus("btnNewVoucher");
             //窗体控件状态切换
            //this.txtcSalePlanNo.Properties.ReadOnly = !this.txtcSalePlanNo.Properties.ReadOnly;
            //this.dtdDate.Properties.ReadOnly = !this.dtdDate.Properties.ReadOnly;
            //this.txtcMaker.Properties.ReadOnly = !this.txtcMaker.Properties.ReadOnly;
            //this.lueDepartment.Properties.ReadOnly = !this.lueDepartment.Properties.ReadOnly;
            //this.txtiYear.Properties.ReadOnly = !this.txtiYear.Properties.ReadOnly;
            //this.cboiStatus.Properties.ReadOnly = !this.cboiStatus.Properties.ReadOnly;
            //this.dtdVerifyDate.Properties.ReadOnly = !this.dtdVerifyDate.Properties.ReadOnly;
            //this.txtcVerifier.Properties.ReadOnly = !this.txtcVerifier.Properties.ReadOnly;
            //this.txtcMemo.Properties.ReadOnly = !this.txtcMemo.Properties.ReadOnly;
            

        }

        # endregion

        # region  将控件恢复到原始状态

        /// <summary>
        /// 将控件恢复到原始状态
        /// </summary>
        private void ClearControls()
        {
            
            //清空表头数据并且赋值给相关字段
            this.txtcSalePlanNo.EditValue =BuildBillCode("SL_P_SalePlan", "cSalePlanNo", "dDate", DateTime.Now); ;
            this.txtcSalePlanNo.Tag = Guid.NewGuid().ToString();
            this.dtdDate.Text = DateTime.Now.ToString();
            this.txtcMaker.EditValue = "";
            this.lueDepartment.EditValue = "";
            this.txtiYear.EditValue = DateTime.Now.Year.ToString();
            this.cboiStatus.EditValue = "0";
            this.dtdVerifyDate.EditValue = DateTime.Now.ToString();
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


        # region  生成编码
        /// <summary>
        /// 生成编码
        /// </summary>
        /// <param name="strTable">数据表</param>
        /// <param name="strBillCodeColumn">数据表中表示代码的列</param>
        /// <param name="strBillDateColumn">数据表中表示日期的列</param>
        /// <param name="dtBillDate">生成单据的日期</param>
        /// <returns>单据的代码</returns>
        private string BuildBillCode(string strTable, string strBillCodeColumn, string strBillDateColumn, DateTime dtBillDate)
        {
            string strSql;
            //string strBillDate;
            string strMaxSeqNum;
            string strNewSeqNum;
            string strBillCode;

            try
            {
                //strBillDate = dtBillDate.ToString("yyyyMMdd");
                strSql = "SELECT  MAX(" + strBillCodeColumn +") FROM " + strTable + " ";
                strMaxSeqNum = DBHelper.ExecuteScalar(DBHelper.ConnString,CommandType.Text,strSql) as string;
                
                if (String.IsNullOrEmpty(strMaxSeqNum))
                {
                    strMaxSeqNum = "0000000";
                }

                strNewSeqNum = (Convert.ToInt32(strMaxSeqNum) + 1).ToString("0000000");
                //strBillCode = strBillDate + "-" + strNewSeqNum;

                strBillCode = strNewSeqNum;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }

            return strBillCode;
        }

        # endregion


        #region 删行
        private void del()
        {
           
            
                int iselectindex = gcView.FocusedRowHandle;
                if (gcView.FocusedRowHandle < 0) return;
                if (MessageBox.Show(this, "真的要删除本卡记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
                DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("delete from SL_P_SalePlan_Month where cSalePlanMId='" + gcView.GetRowCellValue(iselectindex, "cSalePlanMId").ToString() + "'"));
               
        }

        #endregion


        # region  删除
        private void Delall()
        {

            if (cboiStatus.Text.ToString() == "1")
            {
                MessageBox.Show("已审核的单据不能被删除!", "提示");
                return;

            }
            try
            {
                string strsql="delete from SL_P_SalePlan where cSalePlanId="+gcView.GetRowCellValue(gcView.FocusedRowHandle,"cSalePlanId").ToString()+"";
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

        # endregion



        #region 保存

        private DataTable GetTable(DevExpress.XtraGrid.Views.Grid.GridView dgv)
        {

            DataRow dr;
            DataTable dsshcem = new DataTable();
            dsshcem.Columns.Add("cSalePlanMId", typeof(Guid));
            //dsshcem.Columns.Add("cSalePlanId", typeof(Guid));
            dsshcem.Columns.Add("iMonth", typeof(int));
            dsshcem.Columns.Add("nAmount", typeof(decimal));
            dsshcem.Columns.Add("cRefs1", typeof(double));
            dsshcem.Columns.Add("cRefs2", typeof(double));
            //dsshcem.Columns.Add("cRef1", typeof(decimal));
            //dsshcem.Columns.Add("cRef2", typeof(decimal));
            dsshcem.Columns.Add("cMemo", typeof(string));
            if (gcView.RowCount > 0)
            {
                for (int i = 0; i < gcView.RowCount - 1; i++)
                {
                    dr = dsshcem.NewRow();
                    dr["cSalePlanMId"] = Guid.NewGuid().ToString();
                    dr["iMonth"] = gcView.GetRowCellValue(i, "iMonth").ToString();
                    dr["nAmount"] = gcView.GetRowCellValue(i, "nAmount").ToString();
                    dr["cRefs1"] = gcView.GetRowCellValue(i, "cRefs1").ToString();
                    dr["cRefs2"] = gcView.GetRowCellValue(i, "cRefs2").ToString();
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
            //构建细表结构
            DataTable dt = new DataTable();
            dt.Columns.Add("cSalePlanMId", typeof(Guid));
            dt.Columns.Add("cSalePlanId", typeof(Guid));
            dt.Columns.Add("iMonth", typeof(int));
            dt.Columns.Add("nAmount", typeof(decimal));
            dt.Columns.Add("cRefs1", typeof(double));
            dt.Columns.Add("cRefs2", typeof(double));
            //dt.Columns.Add("cRef1", typeof(decimal));
            //dt.Columns.Add("cRef2", typeof(decimal));
            dt.Columns.Add("cMemo", typeof(string));
            //构建主表结构
            dtMain.Columns.Add("cSalePlanId", typeof(Guid));
            dtMain.Columns.Add("cSalePlanNo", typeof(string));
            dtMain.Columns.Add("dDate", typeof(DateTime));
            dtMain.Columns.Add("cMaker", typeof(string));
            dtMain.Columns.Add("cDepCode", typeof(string));
            dtMain.Columns.Add("iYear", typeof(int));
            dtMain.Columns.Add("iStatus", typeof(int));
            dtMain.Columns.Add("dVerifyDate", typeof(DateTime));
            dtMain.Columns.Add("cVerifier", typeof(string));
            dtMain.Columns.Add("cMemo", typeof(string));
            //构建主表数据
            dr = dtMain.NewRow();
           
            dr["cSalePlanId"] = Guid.NewGuid().ToString();
            cSalePlanId = dr["cSalePlanId"].ToString();
            dr["cSalePlanNo"] = txtcSalePlanNo.Text.ToString();
            dr["dDate"] = dtdDate.Text.ToString();
            dr["cMaker"] = txtcMaker.Text.ToString();
            dr["cDepCode"] = lueDepartment.EditValue.ToString();
            dr["iYear"] = txtiYear.Text.ToString();
            dr["iStatus"] = cboiStatus.Text.ToString();
            dr["dVerifyDate"] = dtdVerifyDate.Text.ToString();
            dr["cVerifier"] = txtcVerifier.Text.ToString();
            dr["cMemo"] = txtcMemo.Text.ToString();
            dtMain.Rows.Add(dr);
            dtMain.AcceptChanges();

            gcView.UpdateCurrentRow();
            dtDetail = GetTable(gcView).Copy();
            
            if (dtDetail.Rows.Count > 0)
            {
                for (int r = 0; r < dtDetail.Rows.Count; r++)
                {
                    dt.NewRow();
                    if (!dtDetail.Columns.Contains("cSalePlanId"))
                    {
                        dtDetail.Columns.Add("cSalePlanId", typeof(Guid));
                        dtDetail.Rows[r]["cSalePlanId"] = cSalePlanId;
                    }
                    else
                    {
                        dtDetail.Rows[r]["cSalePlanId"] = dtMain.Rows[0]["cSalePlanId"].ToString();
                    }

                   
                    dtDetail.AcceptChanges();
                }
            }
            DBHelper.SqlBulkCopyInsert("SL_P_SalePlan", dtMain, DBHelper.ConnString, msg);
            DBHelper.SqlBulkCopyInsert("SL_P_SalePlan_Month", dtDetail, DBHelper.ConnString, msg);
            



        }

        private void sava()
        {
            if (tab.SelectedTab == tpMonth)
            {
                string Msg = string.Empty;

                string Department = DBHelper.GetDatas("cDepCode", "SL_P_SalePlan", "iYear", DateTime.Now.Year.ToString());
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
                }
                else
                {
                    MessageBox.Show("数据保存失败！" + Msg);
                    return;
                }

                gcView.RefreshData();
                ButtonStatus("LoadForm");
            }
            
            
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
                            tsbNewVoucher.Enabled = true;
                            tsbNew.Enabled = true;
                            tsbDel.Enabled = true;
                            tsbSave.Enabled = true;
                            tsbEmpty.Enabled = false;
                            tsbModify.Enabled = false;
                            tsbCheck.Enabled = true;
                            tsbUnCheck.Enabled = true;
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
                            tsbCheck.Enabled = false;
                            tsbUnCheck.Enabled = false;
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
                        tsbCheck.Enabled = false;
                        tsbUnCheck.Enabled = false;
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
                    tsbCheck.Enabled = false;
                    tsbUnCheck.Enabled = false;
                    tsbDelete.Enabled = false;
                    gcView.OptionsBehavior.Editable =false;
                    break;
                case "btnAllAdd":
                    tsbNewVoucher.Enabled = false;
                    tsbNew.Enabled = false;
                    tsbDel.Enabled = true;
                    tsbSave.Enabled = true;
                    tsbEmpty.Enabled = true;
                    tsbModify.Enabled = false;

                    tsbDelete.Enabled = false;
                    gcView.OptionsBehavior.Editable = true;
                    break;
                case "btnInsertRow":
                    tsbNewVoucher.Enabled = false;
                    tsbNew.Enabled = true;
                    tsbDel.Enabled = true;
                    tsbSave.Enabled = true;
                    tsbEmpty.Enabled = true;
                    tsbModify.Enabled = false;
                    tsbCheck.Enabled = false;
                    tsbUnCheck.Enabled = false;
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
                    tsbCheck.Enabled = false;
                    tsbUnCheck.Enabled = false;
                    tsbDelete.Enabled = false;
                    break;
                
                case "btnModify":
                    tsbNewVoucher.Enabled = false;
                    tsbNew.Enabled = true;
                    tsbDel.Enabled = true;
                    tsbSave.Enabled = true;
                    tsbEmpty.Enabled = true;
                    tsbModify.Enabled = false;
                    tsbCheck.Enabled = false;
                    tsbUnCheck.Enabled = false;
                    tsbDelete.Enabled = false;
                    break;
                  
            }
        }
        # endregion


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
            if (string.IsNullOrEmpty(txtcSalePlanNo.Text))
            {
                ErrMsg = "计划编号不允许为空！";
                bFlag = false;
            }

            //检查月份是否为空
            if (bFlag)
            {
                if (gcView.RowCount > 0)
                {
                    for (int r = 0; r < gcView.RowCount-1; r++)
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
                    for (int r = 0; r < gcView.RowCount-1; r++)
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
                if (lueDepartment.EditValue.ToString() == Department)
                {
                    ErrMsg = "该部门的销售计划已经制做了！";
                    bFlag = false;
                    
                    
                }

            }

            //检查明细表是否存在相同的月份
            if (bFlag)
            {
                if (gcView.RowCount > 0)
                {
                    for (int r = 0; r < gcView.RowCount-2; r++)
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

        private void New()
        {
            if (lueDepartment.EditValue.ToString() == "")
            {
                MessageBox.Show("部门不能为空，请选择！", "系统提示");
                return;
            }
            gcView.AddNewRow();
            

        }

        private void NewVoucher()
        {
            ControlStatus();
            ClearControls();
        }


        # region 事件区
        private void tsbNewVoucher_Click(object sender, EventArgs e)
        {
           
                NewVoucher();
            
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

        private void tsbModify_Click(object sender, EventArgs e)
        {
            ButtonStatus("btnModify");
     
            if (cboiStatus.Text.ToString() == "1")
            {
                MessageBox.Show("该单据已审核不能被修改!", "系统提示");
                return;
            }



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

        private void tsbCheck_Click(object sender, EventArgs e)
        {
            string strcSalePlanId = null;
            strcSalePlanId = DBHelper.GetDatas("cSalePlanId", "SL_P_SalePlan", "cSalePlanNo", txtcSalePlanNo.Text.ToString());
            if (cboiStatus.Text.ToString() == "1")
            {
                MessageBox.Show("该单据已审核过，不许再次审核！", "软件提示");
                return;
            }
            string StrSQL = "Update SL_P_SalePlan Set iStatus = '1' Where cSalePlanId = '" + strcSalePlanId + "'";

            if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text,StrSQL) > 0)
            {
                MessageBox.Show("审核成功！", "软件提示");
            }
            else
            {
                MessageBox.Show("审核失败！", "软件提示");
            }
        }

        private void tsbUnCheck_Click(object sender, EventArgs e)
        {
            string strcSalePlanId = null;
            strcSalePlanId = DBHelper.GetDatas("cSalePlanId", "SL_P_SalePlan", "cSalePlanNo", txtcSalePlanNo.Text.ToString());
            if (cboiStatus.Text.ToString() == "0")
            {
                MessageBox.Show("该单据未审核，无需弃审！", "软件提示");
                return;
            }
            string StrSQL = "Update SL_P_SalePlan Set iStatus = '0' Where cSalePlanId = '" + strcSalePlanId + "'";

            if (DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, StrSQL) > 0)
            {
                MessageBox.Show("弃审成功！", "软件提示");
            }
            else
            {
                MessageBox.Show("弃审失败！", "软件提示");
            }

        }

      

        # endregion

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            Delall();
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
                DataTable dt = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, string.Format("select * from SalePlan where iMonth='"+gcView.GetRowCellValue(gcView.FocusedRowHandle,"iMonth").ToString()+"' and cDepCode='"+lueDepartment.EditValue.ToString()+"' and iYear='"+txtiYear.Text.ToString()+"'")).Tables[0];
                gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs1", dt.Rows[0]["cRefs1"].ToString());
                gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs2", dt.Rows[0]["cRefs2"].ToString());
            }
            //else
            //{
            //    DataTable Newdt = new DataTable();
            //    DataTable r = new DataTable();
            //    DataSet ds = new DataSet();
            //    //string STRSQL = "SELECT SD.cDeptRefId,SD.cDepCode,SB.cDataValue AS cRef1,SB1.cDataValue AS cRef2 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId";
            //    string STRSQL="SELECT SD.cDepCode,SB.cDataValue AS cRef1,SB1.cDataValue AS cRef2 FROM SL_P_DeptRef SD LEFT JOIN  SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId";
            //    ds = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, STRSQL);
            //    r = ds.Tables[0];
            //    string condition="cDepCode='"+lueDepartment.EditValue.ToString()+"'";
            //    Newdt = GetNewDataTable(r, condition);
            //    for (int i = 0; i < Newdt.Rows.Count; i++)
            //    {

            //        if (Newdt.Rows[i]["cRef1"].ToString() == "销售额")
            //        {

            //            double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs1", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);

            //        }
            //        if (Newdt.Rows[i]["cRef1"].ToString() == "开票额")
            //        {
            //            double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM SaleBillVouch s  left join SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND s.cDepCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM SaleBillVouch s left join SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND s.cDepCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM SaleBillVouch s  left join SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND s.cDepCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='开票额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='开票额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='开票额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs1", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);

            //        }
            //        if (Newdt.Rows[i]["cRef1"].ToString() == "收款额")
            //        {
            //            double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='收款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='收款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='收款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs1", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);

            //        }
            //        if (Newdt.Rows[i]["cRef1"].ToString() == "汇款额")
            //        {
            //            double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='汇款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='汇款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='汇款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs1", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);

            //        }

            //        if (Newdt.Rows[i]["cRef2"].ToString() == "销售额")
            //        {

            //            double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM DispatchList d  left join DispatchLists ds on d.DLID=ds.DLID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND d.cDepCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='销售额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs2", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);

            //        }
            //        if (Newdt.Rows[i]["cRef2"].ToString() == "开票额")
            //        {
            //            double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM SaleBillVouch s  left join SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND s.cDepCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM SaleBillVouch s left join SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND s.cDepCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iSum,0)),0) FROM SaleBillVouch s  left join SaleBillVouchs ss on s.SBVID = ss.SBVID  WHERE Year(dDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND s.cDepCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='开票额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='开票额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='开票额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs2", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);

            //        }
            //        if (Newdt.Rows[i]["cRef2"].ToString() == "收款额")
            //        {
            //            double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='收款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='收款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='收款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs2", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);

            //        }
            //        if (Newdt.Rows[i]["cRef2"].ToString() == "汇款额")
            //        {
            //            double str1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 3) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 2) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double str3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("SELECT isnull(sum(isnull(iAmount_f,0)),0) FROM Ap_CloseBill a  left join Ap_CloseBills ass on a.iID = ass.iID  WHERE Year(dVouchDate)='" + (Convert.ToInt16(DateTime.Now.Year.ToString()) - 1) + "' and  MONTH(dVouchDate)='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "' AND a.cDeptCode LIKE '" + lueDepartment.EditValue.ToString() + "%'")));
            //            double nRat1 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate1 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='汇款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat2 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate2 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='汇款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            double nRat3 = Convert.ToDouble(DBHelper.ExecuteScalar(DBHelper.ConnString, CommandType.Text, string.Format("select nRate3 from SL_P_Refset where cDepCode='" + lueDepartment.EditValue.ToString() + "' and cRefType='汇款额' and iMonth='" + gcView.GetRowCellValue(gcView.FocusedRowHandle, "iMonth").ToString() + "'and iYear='" + txtiYear.EditValue.ToString() + "'"))) / 100;
            //            gcView.SetRowCellValue(gcView.FocusedRowHandle, "cRefs2", str1 * nRat1 + str2 * nRat2 + str3 * nRat3);

            //        }
            //    }
   
                gcView.CloseEditor();
                gcView.UpdateCurrentRow();
           // }
            

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cSalePlanId)) return;
            frmSalePlanShop frm = new frmSalePlanShop();
            frm.cDepCode = lueDepartment.EditValue.ToString();
            frm.bFlag = true;
            frm.cSalePlanId = cSalePlanId;
            frm.ShowDialog();
            frm.Dispose();
            DataBind();

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (gdView.FocusedRowHandle < 0) return;
            DataRow dr = gdView.GetDataRow(gdView.FocusedRowHandle);
            frmSalePlanShop frm = new frmSalePlanShop();
            frm.bFlag = false;
            frm.cSalePlanId = gdView.GetRowCellValue(gdView.FocusedRowHandle, "cSalePlanId").ToString();
            frm.cShopCode = gdView.GetRowCellValue(gdView.FocusedRowHandle, "cShopCode").ToString();
            frm.cDepCode = gdView.GetRowCellValue(gdView.FocusedRowHandle, "cDepCode").ToString();
            frm.cCusCode = gdView.GetRowCellValue(gdView.FocusedRowHandle, "cCusCode").ToString();
            frm.ShowDialog();
            frm.Dispose();
            DataBind();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gdView.FocusedRowHandle < 0) return;
            DataRow dr = gdView.GetDataRow(gdView.FocusedRowHandle);
            if (MessageBox.Show(this, "真的删除选定记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;


            DBHelper.ExecuteNonQuery(DBHelper.ConnString, CommandType.Text, string.Format("delete from SL_P_SalePlan_Shop where cCusCode='" + gcView.GetRowCellValue(gdView.FocusedRowHandle, "cCusCode").ToString() + "'"));
                DataBind();
        }

        private void btnAllAdd_Click(object sender, EventArgs e)
        {
            if (lueDepartment.EditValue.ToString() == "")
            {
                MessageBox.Show("部门不能为空，请选择！", "系统提示");
                return;
            }

            DataTable dt = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, string.Format("select * from SalePlan where cDepCode='" + lueDepartment.EditValue.ToString() + "' and iYear='" + txtiYear.Text.ToString() + "'ORDER BY iMonth ASC")).Tables[0];

            for (int i = gcView.RowCount; i < 13; i++)
            {
                
                gcView.AddNewRow();
                //DataTable dt = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text,string.Format("select * from SalePlan where iMonth='"+i+"' and cDepCode='"+lueDepartment.EditValue.ToString()+"' and iYear='"+txtiYear.Text.ToString()+"'")).Tables[0];
                gcView.SetRowCellValue(i-1, "iMonth", i);
                gcView.SetRowCellValue(i-1, "cRefs1", dt.Rows[i-1]["cRefs1"].ToString());
                gcView.SetRowCellValue(i-1, "cRefs2", dt.Rows[i-1]["cRefs2"].ToString());
                gcView.CloseEditor();
                gcView.UpdateCurrentRow();
                //SqlParameter[] pramer = new SqlParameter[]
                //{
                //    new SqlParameter("@iYear",txtiYear.Text.ToString()),
                //    new SqlParameter("@iMonth", i),
                //    new SqlParameter("@cDepCode",lueDepartment.EditValue.ToString())
                //};
                //DataTable dt = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.StoredProcedure, "ProcDispatchList", pramer).Tables[0];
                //gcView.SetRowCellValue(i-1, "iMonth", i);
                //gcView.SetRowCellValue(i-1, "cRefs1", dt.Rows[0]["cRefs1"].ToString());
                //gcView.SetRowCellValue(i-1, "cRefs2", dt.Rows[0]["cRefs2"].ToString());
            }

            ButtonStatus("btnAllAdd");
        }

        private void gcView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText =(e.RowHandle + 1).ToString();
            }
        }

        private void frmSale_Plans_Load(object sender, EventArgs e)
        {
            DataBind();
        }
    }
}
