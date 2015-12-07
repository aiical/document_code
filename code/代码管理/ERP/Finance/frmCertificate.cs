using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmCertificate : BaseClass.frmBase
    {
        private string strSaveSlaverSQL = "";
        public decimal decID = 0;
        public DataTable dtDes = null;
        public frmCertificate()
        {
            InitializeComponent();
            strSaveSlaverSQL = "select * from t_CertificateDetail where F_ID = @Value";
        }

        /// <summary>
        /// 取得科目名称
        /// </summary>
        /// <param name="sID"></param>
        /// <returns></returns>
        private string GetSubjectName(string sID)
        {
            string strSQL = "";
            strSQL = "select F_ID + '-' + F_Name as F_Name from t_Subject where F_ID = '" + sID + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0]["F_Name"].ToString();
            else
                return "";
        }

        /// <summary>
        /// 取系统参数设定的对应科目
        /// </summary>
        /// <param name="intFlag"></param>
        public void GenCertificate(int intFlag)
        {
            decimal decMoney = 0;
            DataRow dr, dr1;
            NewBill();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsParm = myHelper.GetDs("select * from t_Parm");
            switch (intFlag)
            {
                case 1:            //采购进货
                    decMoney = Convert.ToDecimal(dtDes.Rows[0]["F_Money"]);
                    dr = ((DataRowView)binSlaver.AddNew()).Row;
                    dr["F_Memo"] = "第"+dtDes.Rows[0]["F_BillID"].ToString()+"号采购进货单";
                    dr["F_Subject"] = dsParm.Tables[0].Rows[0]["F_Debit1"].ToString();
                    dr["F_SubjectName"] = GetSubjectName(dsParm.Tables[0].Rows[0]["F_Debit1"].ToString());
                    dr["F_Debit"] = decMoney;
                    dr["F_Credit"] = 0;

                    dr1 = ((DataRowView)binSlaver.AddNew()).Row;
                    dr1["F_Memo"] = "第" + dtDes.Rows[0]["F_BillID"].ToString() + "号采购进货单";
                    dr1["F_Subject"] = dsParm.Tables[0].Rows[0]["F_Credit1"].ToString();
                    dr1["F_SubjectName"] = GetSubjectName(dsParm.Tables[0].Rows[0]["F_Credit1"].ToString());
                    dr1["F_Debit"] = 0;
                    dr1["F_Credit"] = decMoney;
                    binSlaver.EndEdit();
                    break;
                case 2:             //采购退货
                    decMoney = Convert.ToDecimal(dtDes.Rows[0]["F_Money"]);
                    dr = ((DataRowView)binSlaver.AddNew()).Row;
                    dr["F_Memo"] = "第" + dtDes.Rows[0]["F_BillID"].ToString() + "号采购退货单";
                    dr["F_Subject"] = dsParm.Tables[0].Rows[0]["F_Debit2"].ToString();
                    dr["F_SubjectName"] = GetSubjectName(dsParm.Tables[0].Rows[0]["F_Debit2"].ToString());
                    dr["F_Debit"] = decMoney;
                    dr["F_Credit"] = 0;

                    dr1 = ((DataRowView)binSlaver.AddNew()).Row;
                    dr1["F_Memo"] = "第" + dtDes.Rows[0]["F_BillID"].ToString() + "号采购退货单";
                    dr1["F_Subject"] = dsParm.Tables[0].Rows[0]["F_Credit2"].ToString();
                    dr1["F_SubjectName"] = GetSubjectName(dsParm.Tables[0].Rows[0]["F_Credit2"].ToString());
                    dr1["F_Debit"] = 0;
                    dr1["F_Credit"] = decMoney;
                    break;
                case 3:
                    decMoney = Convert.ToDecimal(dtDes.Rows[0]["F_Money"]);
                    dr = ((DataRowView)binSlaver.AddNew()).Row;
                    dr["F_Memo"] = "第" + dtDes.Rows[0]["F_BillID"].ToString() + "号采购付款单";
                    dr["F_Subject"] = dsParm.Tables[0].Rows[0]["F_Debit3"].ToString();
                    dr["F_SubjectName"] = GetSubjectName(dsParm.Tables[0].Rows[0]["F_Debit3"].ToString());
                    dr["F_Debit"] = decMoney;
                    dr["F_Credit"] = 0;

                    dr1 = ((DataRowView)binSlaver.AddNew()).Row;
                    dr1["F_Memo"] = "第" + dtDes.Rows[0]["F_BillID"].ToString() + "号采购付款单";
                    dr1["F_Subject"] = dsParm.Tables[0].Rows[0]["F_Credit3"].ToString();
                    dr1["F_SubjectName"] = GetSubjectName(dsParm.Tables[0].Rows[0]["F_Credit3"].ToString());
                    dr1["F_Debit"] = 0;
                    dr1["F_Credit"] = decMoney;
                    break;
                case 4:
                    decMoney = Convert.ToDecimal(dtDes.Rows[0]["F_Money"]);
                    dr = ((DataRowView)binSlaver.AddNew()).Row;
                    dr["F_Memo"] = "第" + dtDes.Rows[0]["F_BillID"].ToString() + "号销售发货单";
                    dr["F_Subject"] = dsParm.Tables[0].Rows[0]["F_Debit4"].ToString();
                    dr["F_SubjectName"] = GetSubjectName(dsParm.Tables[0].Rows[0]["F_Debit4"].ToString());
                    dr["F_Debit"] = decMoney;
                    dr["F_Credit"] = 0;

                    dr1 = ((DataRowView)binSlaver.AddNew()).Row;
                    dr1["F_Memo"] = "第" + dtDes.Rows[0]["F_BillID"].ToString() + "号销售发货单";
                    dr1["F_Subject"] = dsParm.Tables[0].Rows[0]["F_Credit4"].ToString();
                    dr1["F_SubjectName"] = GetSubjectName(dsParm.Tables[0].Rows[0]["F_Credit4"].ToString());
                    dr1["F_Debit"] = 0;
                    dr1["F_Credit"] = decMoney;
                    break;
                case 5:
                    decMoney = Convert.ToDecimal(dtDes.Rows[0]["F_Money"]);
                    dr = ((DataRowView)binSlaver.AddNew()).Row;
                    dr["F_Memo"] = "第" + dtDes.Rows[0]["F_BillID"].ToString() + "号销售退货单"; 
                    dr["F_Subject"] = dsParm.Tables[0].Rows[0]["F_Debit5"].ToString();
                    dr["F_SubjectName"] = GetSubjectName(dsParm.Tables[0].Rows[0]["F_Debit5"].ToString());
                    dr["F_Debit"] = decMoney;
                    dr["F_Credit"] = 0;

                    dr1 = ((DataRowView)binSlaver.AddNew()).Row;
                    dr1["F_Memo"] = "第" + dtDes.Rows[0]["F_BillID"].ToString() + "号销售退货单";
                    dr1["F_Subject"] = dsParm.Tables[0].Rows[0]["F_Credit5"].ToString();
                    dr1["F_SubjectName"] = GetSubjectName(dsParm.Tables[0].Rows[0]["F_Credit5"].ToString());
                    dr1["F_Debit"] = 0;
                    dr1["F_Credit"] = decMoney;
                    break;
                case 6:
                    decMoney = Convert.ToDecimal(dtDes.Rows[0]["F_Money"]);
                    dr = ((DataRowView)binSlaver.AddNew()).Row;
                    dr["F_Memo"] = "第" + dtDes.Rows[0]["F_BillID"].ToString() + "号销售收款单";
                    dr["F_Subject"] = dsParm.Tables[0].Rows[0]["F_Debit6"].ToString();
                    dr["F_SubjectName"] = GetSubjectName(dsParm.Tables[0].Rows[0]["F_Debit6"].ToString());
                    dr["F_Debit"] = decMoney;
                    dr["F_Credit"] = 0;

                    dr1 = ((DataRowView)binSlaver.AddNew()).Row;
                    dr1["F_Memo"] = "第" + dtDes.Rows[0]["F_BillID"].ToString() + "号销售收款单";
                    dr1["F_Subject"] = dsParm.Tables[0].Rows[0]["F_Credit6"].ToString();
                    dr1["F_SubjectName"] = GetSubjectName(dsParm.Tables[0].Rows[0]["F_Credit6"].ToString());
                    dr1["F_Debit"] = 0;
                    dr1["F_Credit"] = decMoney;
                    break;
                case 7:
                    decMoney = Convert.ToDecimal(dtDes.Rows[0]["F_Money"]);
                    dr = ((DataRowView)binSlaver.AddNew()).Row;
                    dr["F_Memo"] = "第" + dtDes.Rows[0]["F_BillID"].ToString() + "号委外付款单";
                    dr["F_Subject"] = dsParm.Tables[0].Rows[0]["F_Debit7"].ToString();
                    dr["F_SubjectName"] = GetSubjectName(dsParm.Tables[0].Rows[0]["F_Debit7"].ToString());
                    dr["F_Debit"] = decMoney;
                    dr["F_Credit"] = 0;

                    dr1 = ((DataRowView)binSlaver.AddNew()).Row;
                    dr1["F_Memo"] = "第" + dtDes.Rows[0]["F_BillID"].ToString() + "号委外付款单";
                    dr1["F_Subject"] = dsParm.Tables[0].Rows[0]["F_Credit7"].ToString();
                    dr1["F_SubjectName"] = GetSubjectName(dsParm.Tables[0].Rows[0]["F_Credit7"].ToString());
                    dr1["F_Debit"] = 0;
                    dr1["F_Credit"] = decMoney;
                    break;
            }

        }

        /// <summary>
        /// 测试权限
        /// </summary>
        /// <returns></returns>
        protected bool TestRight(string strName)
        {
            if (DataLib.SysVar.strUGroup == "超级用户") return true;
            string strSQL = "select * from t_RightDetail where F_Group = '" + DataLib.SysVar.strUGroup + "' and F_Class = '" + this.Name + "List" + "' and F_Name = '" + strName + "' and F_Enable = 1";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("对不起，你无权限!!", "提示");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// 打印设计
        /// </summary>
        protected void PrintDesign()
        {
            /*
            if (TestRight("打印") == false) return;
            if (DataLib.SysVar.GetParmValue("F_N8") == true)
            {
                if (picCheck.Visible == false)
                {
                    MessageBox.Show(this, "单据须审核后才能打印!!", "提示");
                    return;
                }
            }
             */
            string strBill = decID.ToString();
            DataLib.SysVar.RMDesigner(IntPtr.Zero, DataLib.SysVar.strCon, this.Name, "Bill", strBill);
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        protected void PrintPreview()
        {
            /*
            if (TestRight("打印") == false) return;
            if (DataLib.SysVar.GetParmValue("F_N8") == true)
            {
                if (picCheck.Visible == false)
                {
                    MessageBox.Show(this, "单据须审核后才能打印!!", "提示");
                    return;
                }
            }
             */

            string strBill = decID.ToString();
            DataLib.SysVar.RMPreview(IntPtr.Zero, DataLib.SysVar.strCon, this.Name, "Bill", strBill);

        }

        /// <summary>
        /// 打印
        /// </summary>
        protected void PrintDialog()
        {
            /*
            if (TestRight("打印") == false) return;
            if (DataLib.SysVar.GetParmValue("F_N8") == true)
            {
                if (picCheck.Visible == false)
                {
                    MessageBox.Show(this, "单据须审核后才能打印!!", "提示");
                    return;
                }
            }
              */
            string strBill = decID.ToString();
            DataLib.SysVar.RMPrint(IntPtr.Zero, DataLib.SysVar.strCon, this.Name, "Bill", strBill,1);
        }

        /// <summary>
        /// 单号参数
        /// </summary>
        /// <returns></returns>
        private Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Value", decID);
            return parm;
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int GetMaxOrder(DateTime dt)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select isnull(Max(F_Order),0)+1 as F_Order from t_Certificate where Year(F_Date) = "+dt.Year.ToString()+" and Month(F_Date) = "+dt.Month.ToString());
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        private void Status(int intFlag)
        {
            switch (intFlag)
            {
                case 0:
                    tsSave.Enabled = true;
                    tsCheck.Enabled = false;
                    tsUnCheck.Enabled = false;
                    break;
                case 1:
                    tsSave.Enabled = false;
                    tsCheck.Enabled = false;
                    tsUnCheck.Enabled = true;
                    break;
                case 2:
                    tsSave.Enabled = true;
                    tsCheck.Enabled = true;
                    tsUnCheck.Enabled = false;
                    break;
            }
        }

        private void SlaverColumnChanged(object sender,DataColumnChangeEventArgs e)
        {
            //gvMain.UpdateCurrentRow();
            //gvMain.CloseEditor();
        }

        public void DataBind()
        {
            string strMasterSQL = "select * from t_Certificate where F_ID = "+decID;
            string strSlaverSQL = "select a.*,b.F_ID + '-' + b.F_Name as  F_SubjectName from t_CertificateDetail a,t_Subject b where a.F_Subject = b.F_ID and a.F_ID = " + decID;

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsMaster = myHelper.GetDs(strMasterSQL);
            binMaster.DataSource = dsMaster.Tables[0].DefaultView;

            if (dsMaster.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToBoolean(dsMaster.Tables[0].Rows[0]["F_Check"]) == true)
                {
                    Status(1);
                }
                else
                {
                    Status(2);
                }
            }
            DataSet dsSlaver = myHelper.GetDs(strSlaverSQL);
            dsSlaver.Tables[0].ColumnChanged += new DataColumnChangeEventHandler(SlaverColumnChanged);
            binSlaver.DataSource = dsSlaver.Tables[0].DefaultView;

            int iCnt = 20 - binSlaver.Count;
            if (iCnt > 0)
            {
                for (int i = 0; i < iCnt; i++)
                {
                    dsSlaver.Tables[0].Rows.Add(dsSlaver.Tables[0].NewRow());
                }
            }


            //if (bAssignFlag == false)
            //{
                foreach (Control uCon in this.Controls)
                {
                    if (uCon is myControl.EditControl)
                    {
                        (uCon as myControl.EditControl).DataSource = binMaster;
                        (uCon as myControl.EditControl).BindData();
                    }

                    if (uCon is myControl.lupControl)
                    {
                        (uCon as myControl.lupControl).DataSource = binMaster;
                        (uCon as myControl.lupControl).BindData();
                    }

                    if (uCon is myControl.cbControl)
                    {
                        (uCon as myControl.cbControl).DataSource = binMaster;
                        (uCon as myControl.cbControl).BindData();
                    }

                    if (uCon is myControl.DateControl)
                    {
                        (uCon as myControl.DateControl).DataSource = binMaster;
                        (uCon as myControl.DateControl).BindData();
                    }

                    if (uCon is myControl.SpinControl)
                    {
                        (uCon as myControl.SpinControl).DataSource = binMaster;
                        (uCon as myControl.SpinControl).BindData();
                    }
                }
               // bAssignFlag = true;
            //}

            if (decID == 0 && dtDes == null) NewBill();
        }

        public void NewBill()
        {
            //DataTable dt = ((DataView)binMaster.DataSource).Table;

            DataRow dr = ((DataRowView)binMaster.AddNew()).Row;
            DataLib.sysClass myClass = new DataLib.sysClass();
            //dr["F_BillID"] = myClass.GetMaxCode(strBillFlag);
            dr["F_Date"] = DataLib.SysVar.GetDate();
            dr["F_BillMan"] = DataLib.SysVar.strUName;
            dr["F_Checker"] = "";
            dr["F_Order"] = GetMaxOrder(DataLib.SysVar.GetDate());
            dr["F_Annex"] = GetMaxOrder(DataLib.SysVar.GetDate());
            //dr["F_CheckDate"] = "1900-1-1";
            dr["F_Check"] = false;
            dr["F_Record"] = false;

            dr["F_Key"] = "转";
            //DataLib.SysVar.SetLog(this.Text, "新增", "单号为" + dr["F_BillID"].ToString());
            binMaster.EndEdit();
            Status(0);
        }


        private void CheckBill()
        {
            if (tsSave.Enabled == false)
            {
                MessageBox.Show(this, "本单已被审核过!!", "提示");
                return;
            }
            if (MessageBox.Show(this, "真的要审核本单吗!!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("update t_Certificate set F_Check = 1,F_Checker = '" + DataLib.SysVar.strUName + "',F_CheckDate = '" + DateTime.Today.ToString() + "' where F_ID = "+decID.ToString()) == 0)
            {
                MessageBox.Show(this, "单据审核成功!!", "提示");
                editControl2.SetValue(DataLib.SysVar.strUName);
                Status(1);
            }
        }

        private void UnCheckBill()
        {
            if (tsCheck.Enabled == true)
            {
                MessageBox.Show(this, "本单还没被审核!!", "提示");
                return;
            }
            if (MessageBox.Show(this, "真的要反审核本单吗!!", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("update t_Certificate set F_Check = 0,F_Checker = '',F_CheckDate = '1900-1-1' where F_ID = " + decID.ToString()) == 0)
            {
                MessageBox.Show(this, "单据反审核成功!!", "提示");
                editControl2.SetValue("");
                Status(2);
            }
        }

        private void AddRow()
        {
            binSlaver.AddNew();
        }

        private void DelRow()
        {
            binSlaver.RemoveCurrent();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmSubject mySubject = new frmSubject();
            mySubject.bFlag = true;
            if (mySubject.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = ((DataRowView)binSlaver.Current).Row;
                dr.BeginEdit();
                dr["F_Subject"] = mySubject.GetSubject();
                dr["F_SubjectName"] = mySubject.GetSubjectInfo();
                dr.EndEdit();
                binSlaver.EndEdit();
                gvMain.UpdateCurrentRow();
            }
            mySubject.Dispose();
        }

        private void frmCertificate_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == false && dtDes == null)
            {
                DataBind();
            }
        }

        private void tsInsert_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        private void tsDel_Click(object sender, EventArgs e)
        {
            DelRow();
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmAbstract myAbstract = new frmAbstract();
            if (myAbstract.ShowDialog() == DialogResult.OK)
            {
                DataRow drSource = myAbstract.gvAbstract.GetDataRow(myAbstract.gvAbstract.FocusedRowHandle);

                DataRow dr = ((DataRowView)binSlaver.Current).Row;
                dr.BeginEdit();
                dr["F_Memo"] = drSource["F_Remark"];
                dr.EndEdit();
                binSlaver.EndEdit();
                gvMain.UpdateCurrentRow();
            }
            myAbstract.Dispose();
        }

        /// <summary>
        /// 保存前检查
        /// </summary>
        private bool SavePre()
        {
            if (gvMain.RowCount == 0)
            {
                MessageBox.Show(this, "本单必须存在一条以上的分录!!", "提示");
                return false;
            }


            DataTable dtMaster = ((DataView)binMaster.DataSource).Table;
            int iYear = Convert.ToDateTime(dtMaster.Rows[0]["F_Date"]).Year;
            int iMonth = Convert.ToDateTime(dtMaster.Rows[0]["F_Date"]).Month;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select top 1 * from t_Period where F_Year = " + iYear.ToString() + " and F_Month = " + iMonth.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(this, "该月已结帐，不能对该月开凭证!!", "提示");
                return false;
            }

            DataTable dt = ((DataView)binSlaver.DataSource).Table;

            foreach (DataRow dr in dt.Rows)
            {
                if (dr.RowState == DataRowState.Deleted) continue;
                //if (dr["F_Subject"] == DBNull.Value)
                //{
                //    MessageBox.Show(this, "科目不能为空!!", "提示");
                //    return false;
                //}

                /*
                if (dr["F_Debit"] == DBNull.Value)
                {
                    MessageBox.Show(this, "借方金额不能为空!!", "提示");
                    return false;
                }

                if (dr["F_Credit"] == DBNull.Value)
                {
                    MessageBox.Show(this, "贷方金额不能为空!!", "提示");
                    return false;
                }
                 */ 
            }


            object objDebit = gvMain.Columns.ColumnByFieldName("F_Debit").SummaryItem.SummaryValue;
            object objCredit = gvMain.Columns.ColumnByFieldName("F_Credit").SummaryItem.SummaryValue;


            if (Convert.ToDecimal(objDebit) != Convert.ToDecimal(objCredit))
            {
                MessageBox.Show(this, "本单借贷不平衡,请检查!!", "提示");
                return false;
            }
            else
            {
                if (Convert.ToDecimal(objDebit) == 0)
                {
                    MessageBox.Show(this,"借方金额及贷方金额不能同时为零！","提示");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 保存
        /// </summary>
        private bool SaveBill()
        {
            int intCnt = 0;
            gvMain.UpdateSummary();
            if (SavePre() == false) return false;
            
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            binSlaver.EndEdit();
            binMaster.EndEdit();
         
            DataSet dsMaster = ((DataView)binMaster.DataSource).Table.DataSet;
            DataSet dsSlaver = ((DataView)binSlaver.DataSource).Table.DataSet;

            if (decID == 0)
            {
                decID = GetMaxID();
                dsMaster.Tables[0].Rows[0].BeginEdit();
                dsMaster.Tables[0].Rows[0]["F_ID"] = decID;
                dsMaster.Tables[0].Rows[0].EndEdit();
            }
            binSlaver.EndEdit();
            binMaster.EndEdit();


            DataSet dsUpdateSlaver = myHelper.GetOtherDs(strSaveSlaverSQL, GetParm());


            foreach (DataRow dr in dsUpdateSlaver.Tables[0].Rows)
            {
                dr.Delete();
            }

            DataTable dt = dsSlaver.Tables[0];
            dt.AcceptChanges();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr.RowState == DataRowState.Deleted) continue;
                string sID = dr["F_Subject"] == DBNull.Value ? "" :dr["F_Subject"].ToString();
                if (sID == "") continue;
                DataRow drNew = dsUpdateSlaver.Tables[0].NewRow();
                intCnt = dt.Columns.Count;
                for (int i = 0; i < intCnt; i++)
                {

                    if (dt.Columns[i].ColumnName == "F_ID")
                    {
                        drNew["F_ID"] = dsMaster.Tables[0].Rows[0]["F_ID"];
                    }
                    else
                    {
                        if (dsUpdateSlaver.Tables[0].Columns.IndexOf(dt.Columns[i].ColumnName) > 0)
                        {
                            drNew[dt.Columns[i].ColumnName] = dr[dt.Columns[i].ColumnName];
                        }
                    }
                }

                dsUpdateSlaver.Tables[0].Rows.Add(drNew);

            }

            return Save(dsMaster, dsSlaver, dsUpdateSlaver);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="dsMaster"></param>
        /// <param name="dsSlaver"></param>
        /// <param name="dsUpdateSlaver"></param>
        /// <returns></returns>
        private bool Save(DataSet dsMaster, DataSet dsSlaver, DataSet dsUpdateSlaver)
        {
            DataSet[] dsData = new DataSet[2];
            dsData[0] = dsMaster;
            dsData[1] = dsUpdateSlaver;

            string[] strSQL = new string[2];
            strSQL[0] = "select * from t_Certificate where F_ID = " + decID.ToString();
            strSQL[1] = "select * from t_CertificateDetail where F_ID = " + decID.ToString();

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.SaveMuteData1(dsData, strSQL, GetParm()).Length == 0)
            {
                //DataLib.SysVar.SetLog(this.Text, "保存", "保存" + editControl1.GetValue().ToString());
                MessageBox.Show("数据保存成功!!", "提示");
                //DataBind();
                //strBillID = editControl1.GetValue().ToString();
                //decID = 
                dsMaster.AcceptChanges();
                dsSlaver.AcceptChanges();
                Status(2);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 取最大凭证号
        /// </summary>
        /// <returns></returns>
        private decimal GetMaxID()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select isnull(max(F_ID),0)+1 as F_MaxID from t_Certificate");
            return Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            SaveBill();
        }

        private void tsCheck_Click(object sender, EventArgs e)
        {
            CheckBill();
        }

        private void tsCal_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void tsPrint_Click(object sender, EventArgs e)
        {
            PrintDesign();
        }

        private void tsUnCheck_Click(object sender, EventArgs e)
        {
            UnCheckBill();
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            decID = 0;
            DataBind();
        }
    }
}

