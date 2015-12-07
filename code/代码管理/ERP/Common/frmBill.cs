using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace Common
{
    public partial class frmBill : BaseClass.frmBase
    {
        protected string strMasterSQL = "";
        protected string strSlaverSQL = "";
        protected string strSaveSlaverSQL = "";
        protected string strMTable;
        protected string strSTable;
        public string strBillID = "";
        protected string strBillFlag;
        protected string strBillTag = "0";
        protected string strValue = "";
        protected bool blnSlaverFlag = false;
        protected bool blnBarCode = true;
        protected string sPrintTag = "";
        protected string strBillText = "";
        protected string strOtherTag = "";
        protected int intBillIndex = 0;

        protected bool bMultCheck = false;

        private bool bAssignFlag = false;
        private List<string> RequestField;

        public frmBill()
        {
            InitializeComponent();
            
            blnLog = false;
            panelControl1.BackColor = Color.FromArgb(242, 243, 226);
            panelControl2.BackColor = Color.FromArgb(242, 243, 226);
            //XtraChinese p = new XtraChinese();
            //p.chineseXtraGrid(this.gcBill);
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            lbTitle.Text = this.Text;
            strOtherTag = this.Name;
            if (this.DesignMode == false)
            {
                if (DataLib.SysVar.GetParmValue("F_N3") == false)
                    editControl1.Enabled = false;
            }
        }

        /// <summary>
        /// 测试权限
        /// </summary>
        /// <returns></returns>
        protected bool TestRight(string strName)
        {
            if (DataLib.SysVar.strUGroup == "超级用户") return true;
            string strNameTag = this.Name+"List";
            if (this.Name == "frmBomEdit") strNameTag = "frmBom";
            string strSQL = "select * from t_RightDetail where F_Group = '" + DataLib.SysVar.strUGroup + "' and F_Class = '" + strNameTag + "' and F_Name = '" + strName + "' and F_Enable = 1";
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
        /// 测试权限
        /// </summary>
        /// <returns></returns>
        protected bool TestRight1(string strName)
        {
            if (DataLib.SysVar.strUGroup == "超级用户") return true;
            string strNameTag = this.Name + "List";
            if (this.Name == "frmBomEdit") strNameTag = "frmBom";
            string strSQL = "select * from t_RightDetail where F_Group = '" + DataLib.SysVar.strUGroup + "' and F_Class = '" + strNameTag + "' and F_Name = '" + strName + "' and F_Enable = 1";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0)
            {
                //MessageBox.Show("对不起，你无权限!!", "提示");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// 判断多级审核
        /// </summary>
        protected bool TestMultCheck()
        {
            string strSQL = "select F_CheckLevel,F_CheckMan from t_MultCheck where F_BillType = '" + this.Text + "' order by F_CheckLevel";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ((DataRowView)binMaster.Current).Row;
                int intCheck = dr["F_CheckFlag"] == DBNull.Value ? 0 : Convert.ToInt32(dr["F_CheckFlag"]);

                DataRow[] drCheckMan = ds.Tables[0].Select("F_CheckMan = '" + DataLib.SysVar.strUID + "'");
                if (drCheckMan.Length > 0)
                {
                    if (Convert.ToInt32(drCheckMan[0]["F_CheckLevel"]) <= intCheck)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return false;
        }

        /// <summary>
        /// 根据相关单据生成凭证
        /// </summary>
        protected virtual bool GenBalance()
        {
            if (TestModify() == true)
            {
                MessageBox.Show(this, "请先保存单据！", "提示");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 打印设计
        /// </summary>
        protected void PrintDesign()
        {
            if (TestRight("打印") == false) return;
            if (DataLib.SysVar.GetParmValue("F_N8") == true)
            {
                if (picCheck.Visible == false)
                {
                    MessageBox.Show(this, "单据须审核后才能打印!!", "提示");
                    return;
                }
            }

            if (sPrintTag == "") sPrintTag = this.Name;
            if (DataLib.SysVar.iReportType == 0)
            {
                string strBill = "'" + editControl1.GetValue().ToString() + "'";
                DataLib.SysVar.RMDesigner(IntPtr.Zero, DataLib.SysVar.strCon, sPrintTag, "Bill", strBill);
                DataLib.SysVar.SetLog(this.Text, "打印设计", "单号为" + editControl1.GetValue().ToString());
            }
            else
            {
                PrintForm F = new PrintForm(sPrintTag);
                F.sBillID = editControl1.GetValue().ToString();
                F.ShowDialog();
                F.Dispose();
            }
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        protected void PrintPreview()
        {
            if (TestRight("打印") == false) return;
            if (DataLib.SysVar.GetParmValue("F_N8") == true)
            {
                if (picCheck.Visible == false)
                {
                    MessageBox.Show(this, "单据须审核后才能打印!!", "提示");
                    return;
                }
            }

            if (sPrintTag == "") sPrintTag = this.Name;
            if (DataLib.SysVar.iReportType == 0)
            {
                string strBill = "'" + editControl1.GetValue().ToString() + "'";
                DataLib.SysVar.RMPreview(this.Handle, DataLib.SysVar.strCon, sPrintTag, "Bill", strBill);
                DataLib.SysVar.SetLog(this.Text, "打印预览", "单号为" + editControl1.GetValue().ToString());
            }
            else
            {
                PrintForm F = new PrintForm(sPrintTag);
                F.sBillID = editControl1.GetValue().ToString();
                F.PreviewReport(null, null);
                F.Dispose();
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        protected void PrintDialog()
        {
            if (TestRight("打印") == false) return;
            if (DataLib.SysVar.GetParmValue("F_N8") == true)
            {
                if (picCheck.Visible == false)
                {
                    MessageBox.Show(this, "单据须审核后才能打印!!", "提示");
                    return;
                }
            }

            if (sPrintTag == "") sPrintTag = this.Name;
            if (DataLib.SysVar.iReportType == 0)
            {
                string strBill = "'" + editControl1.GetValue().ToString() + "'";
                DataLib.SysVar.RMPrint(this.Handle, DataLib.SysVar.strCon, sPrintTag, "Bill", strBill, 1);
                DataLib.SysVar.SetLog(this.Text, "打印", "单号为" + editControl1.GetValue().ToString());
            }
            else
            {
                PrintForm F = new PrintForm(sPrintTag);
                F.sBillID = editControl1.GetValue().ToString();
                F.PrintReport(null, null);
                F.Dispose();
            }
        }

        /// <summary>
        /// 单据引出
        /// </summary>
        protected virtual void BillExport()
        {
            DataSet dsExport = new DataSet();
            DataTable dtMaster = new DataTable();
            dtMaster = ((DataView)binMaster.DataSource).Table.Copy();
            dtMaster.TableName = "Master";
            DataTable dtSlaver = new DataTable();
            dtSlaver = ((DataView)binSlaver.DataSource).Table.Copy();
            dtSlaver.TableName = "Slaver";

            dsExport.Tables.Add(dtMaster);
            dsExport.Tables.Add(dtSlaver);
            dsExport.WriteXml("c:\\tmp.xml");
        }

        /// <summary>
        /// 单据引入
        /// </summary>
        protected virtual void BillImport()
        {
            DataSet dsImport = new DataSet();
            dsImport.ReadXml("c:\\tmp.xml");

            binMaster.DataSource = dsImport.Tables["Master"].Copy().DefaultView;
            binSlaver.DataSource = dsImport.Tables["Slaver"].Copy().DefaultView;
        }

        /// <summary>
        /// 判断该月是否结帐
        /// </summary>
        /// <returns></returns>
        private bool TestCheckOut()
        {
            DateTime dtBill = Convert.ToDateTime(dateControl1.GetValue());
            string strMonth = dtBill.Year.ToString() + dtBill.Month.ToString().PadLeft(2, '0');
            string strSQL = "select F_Month from t_CheckMonth where F_Month = '"+strMonth+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;

        }

        /// <summary>
        /// 单号参数
        /// </summary>
        /// <returns></returns>
        protected Hashtable GetParm()
        {
            Hashtable parm = new Hashtable();
            parm.Add("@Value", strBillID);
 
            /*
            DataLib.JxcService.SqlParameter[] parm =
                    {     
                       new   DataLib.JxcService.SqlParameter()
                    };

            parm[0].ParameterName = "@Value";
            parm[0].SqlDbType = DataLib.JxcService.SqlDbType.VarChar;
            parm[0].Size = 30;
            parm[0].Value = strBillID;
            */
            return parm;
        }

        /// <summary>
        /// 检测是否有关联单据
        /// </summary>
        private bool TestImport()
        {
            string strSQL = "select F_Type from t_BillImport where F_Type = '"+this.Text+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 调单
        /// </summary>
        protected virtual void LoadBill()
        {
            if (TestRight("调单") == false) return;
            frmBillImport myBillImport = new frmBillImport();
            myBillImport.strValue = strValue;
            myBillImport.blnFlag = blnSlaverFlag;
            myBillImport.iIndex = intBillIndex;
            myBillImport.GetBill(this.Text);
            myBillImport.dtMaster = ((DataView)binMaster.DataSource).Table;
            myBillImport.dtSlaver = ((DataView)binSlaver.DataSource).Table;
            myBillImport.ShowDialog();
            myBillImport.Dispose();
        }

        /// <summary>
        /// 设置序号
        /// </summary>
        protected virtual void SetAutoID()
        {
            int intCnt = gvList.RowCount;
            gvList.BeginUpdate();
            for (int i = 0; i < intCnt; i++)
            {
                gvList.SetRowCellValue(i, "Aid", i + 1);
            }
            gvList.EndUpdate();
            binSlaver.EndEdit();
        }

        /// <summary>
        /// 设置单据状态
        /// </summary>
        /// <param name="intFlag"></param>
        protected virtual void SetStatus(int intFlag)
        {
            switch (intFlag)
            {
                case 1:    //新增
                    btnNew.Enabled = true;
                    btnSave.Enabled = true;
                    btnCopy.Enabled = true;
                    btnAddRow.Enabled = true;
                    btnDelRow.Enabled = true;
                    btnCheck.Enabled = false;
                    btnUnCheck.Enabled = false;
                    btnCutOff.Enabled = false;
                    btnOther.Enabled = false;
                    btnLoadBill.Enabled = true;
                    btnUnCutOff.Enabled = false;
                    panelControl1.Enabled = true;
                    gvList.OptionsBehavior.Editable = true;
                    picCheck.Visible = false;
                    picCutOff.Visible = false;
                    picFinish.Visible = false;
                    picInvalid.Visible = false;
                    break;
                case 2:
                    btnNew.Enabled = true;
                    btnSave.Enabled = true;
                    btnCopy.Enabled = true;
                    btnAddRow.Enabled = true;
                    btnDelRow.Enabled = true;
                    btnCheck.Enabled = true;
                    btnUnCheck.Enabled = false;
                    btnCutOff.Enabled = false;
                    btnUnCutOff.Enabled = false;
                    btnOther.Enabled = true;
                    barInvalid.Enabled = true;
                    barUnValid.Enabled = false;
                    btnLoadBill.Enabled = true;
                    panelControl1.Enabled = true;
                    gvList.OptionsBehavior.Editable = true;
                    picCheck.Visible = false;
                    picCutOff.Visible = false;
                    picFinish.Visible = false;
                    picInvalid.Visible = false;
                    break;
                case 3: //审核后
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;
                    btnCopy.Enabled = false;
                    btnAddRow.Enabled = false;
                    btnDelRow.Enabled = false;
                    btnCheck.Enabled = false;
                    btnUnCheck.Enabled = true;
                    btnCutOff.Enabled = true;
                    btnUnCutOff.Enabled = false;
                    btnOther.Enabled = false;
                    btnLoadBill.Enabled = false;
                    picCheck.Visible = true;
                    panelControl1.Enabled = false;
                    gvList.OptionsBehavior.Editable = false;
                    picCheck.Visible = true;
                    picCutOff.Visible = false;
                    picFinish.Visible = false;
                    picInvalid.Visible = false;

                    DataLib.DataHelper myHelper = new DataLib.DataHelper();
                    DataSet ds = myHelper.GetDs("select F_ModiPrice from t_UserGroup where F_Group = '" + DataLib.SysVar.strUGroup + "' and F_ModiPrice = 1");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvList.OptionsBehavior.Editable = true;
                        btnSave.Enabled = true;
                    }

                    //foreach (GridColumn gc in gvList.Columns)
                    //{
                    //    if (gc.FieldName == "F_Price" && bModiPrice == true)
                    //    {
                    //        gvList.OptionsBehavior.Editable = true;
                    //        gc.OptionsColumn.AllowEdit = true;
                    //        gc.OptionsColumn.AllowFocus = true;
                    //    }
                    //    else
                    //    {
                    //        gvList.OptionsBehavior.Editable = false;
                    //    }
                    //}

                  
                    break;
                case 4: //中止后
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;
                    btnCopy.Enabled = false;
                    btnAddRow.Enabled = false;
                    btnDelRow.Enabled = false;
                    btnCheck.Enabled = false;
                    btnUnCheck.Enabled = false;
                    btnCutOff.Enabled = false;
                    btnUnCutOff.Enabled = true;
                    btnOther.Enabled = false;
                    picCheck.Visible = true;
                    picCutOff.Visible = true;
                    btnLoadBill.Enabled = false;
                    panelControl1.Enabled = false;
                    gvList.OptionsBehavior.Editable = false;
                    picFinish.Visible = false;
                    picInvalid.Visible = false;
                    break;
                case 5: //作废后
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;
                    btnCopy.Enabled = false;
                    btnAddRow.Enabled = false;
                    btnDelRow.Enabled = false;
                    btnCheck.Enabled = false;
                    btnUnCheck.Enabled = false;
                    btnCutOff.Enabled = false;
                    btnUnCutOff.Enabled = false;
                    btnOther.Enabled = true;
                    barInvalid.Enabled = false;
                    barUnValid.Enabled = true;
                    picCheck.Visible = false;
                    picCutOff.Visible = false;
                    btnLoadBill.Enabled = false;
                    panelControl1.Enabled = false;
                    gvList.OptionsBehavior.Editable = false;
                    picFinish.Visible = false;
                    picInvalid.Visible = true;
                    break;
            }
        }

       
        /// <summary>
        /// 设置字段类别
        /// </summary>
        protected void SetFieldType(BindingSource binSource, GridView gv)
        {

            DataTable dt = ((DataView)binSource.DataSource).Table;
            if (dt.Columns.Contains("F_ItemID") == true)
            {
                GridColumn gcItem = gvList.Columns.ColumnByFieldName("F_ItemID");
                if (gcItem != null)
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                    gcItem.ColumnEdit = btn;
                    btn.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(ItemBtnClick);
                }
            }

            if (dt.Columns.Contains("F_StorageID") == true)
            {
                GridColumn gcStore = gv.Columns.ColumnByFieldName("F_StorageID");
                if (gcStore != null)
                {
                    DataLib.DataHelper myHelper = new DataLib.DataHelper();
                    DataSet ds = myHelper.GetDs("select F_ID,F_Name from t_Storage");
                    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lupEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                    lupEdit.DataSource = ds.Tables[0].DefaultView;
                    lupEdit.ValueMember = "F_ID";
                    lupEdit.DisplayMember = "F_Name";
                    lupEdit.ShowFooter = false;
                    lupEdit.ShowHeader = false;
                    lupEdit.NullText = "";
                    gcStore.ColumnEdit = lupEdit;
                }
            }

            if (this.Name == "frmApplyStock" || this.Name == "frmStockOrder"
                || this.Name == "frmStockIn" || this.Name == "frmStockBack"
                || this.Name == "frmSellPrice" || this.Name == "frmAskPrice"
                || this.Name == "frmSellOrder" || this.Name == "frmSellPre"
                || this.Name == "frmSellOut" || this.Name == "frmSellBack")
            {

                if (dt.Columns.Contains("F_Price") == true)
                {
                    GridColumn gcPrice = gvList.Columns.ColumnByFieldName("F_Price");
                    if (gcPrice != null)
                    {
                        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnPrice = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                        gcPrice.ColumnEdit = btnPrice;
                        btnPrice.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(PriceBtnClick);
                    }
                }

            }

            if (dt.Columns.Contains("F_DeptID") == true)
            {
                GridColumn gcDept = gv.Columns.ColumnByFieldName("F_DeptID");
                if (gcDept != null)
                {
                    DataLib.DataHelper myHelper = new DataLib.DataHelper();
                    DataSet ds = myHelper.GetDs("select F_ID,F_Name from t_Class where F_ID like '03.%'");
                    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lupEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                    lupEdit.DataSource = ds.Tables[0].DefaultView;
                    lupEdit.ValueMember = "F_ID";
                    lupEdit.DisplayMember = "F_Name";
                    lupEdit.ShowFooter = false;
                    lupEdit.ShowHeader = false;
                    lupEdit.NullText = "";
                    gcDept.ColumnEdit = lupEdit;
                }
            }

            if (dt.Columns.Contains("F_SupplierID") == true)
            {
                GridColumn gcSupplier = gv.Columns.ColumnByFieldName("F_SupplierID");
                if (gcSupplier != null)
                {
                    DataLib.DataHelper myHelper = new DataLib.DataHelper();
                    DataSet ds = myHelper.GetDs("select F_ID,F_Name from t_Supplier");
                    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lupEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                    lupEdit.DataSource = ds.Tables[0].DefaultView;
                    lupEdit.ValueMember = "F_ID";
                    lupEdit.DisplayMember = "F_Name";
                    lupEdit.ShowFooter = false;
                    lupEdit.ShowHeader = false;
                    lupEdit.NullText = "";
                    gcSupplier.ColumnEdit = lupEdit;
                }
            }

            if (dt.Columns.Contains("F_ClientName") == true)
            {
                GridColumn gcClient = gv.Columns.ColumnByFieldName("F_ClientName");
                if (gcClient != null)
                {
                    DataLib.DataHelper myHelper = new DataLib.DataHelper();
                    DataSet ds = myHelper.GetDs("select F_ID,F_Name from t_Client");
                    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lupEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                    lupEdit.DataSource = ds.Tables[0].DefaultView;
                    lupEdit.ValueMember = "F_Name";
                    lupEdit.DisplayMember = "F_Name";
                    lupEdit.ShowFooter = false;
                    lupEdit.ShowHeader = false;
                    lupEdit.NullText = "";
                    gcClient.ColumnEdit = lupEdit;
                }
            }

            if (dt.Columns.Contains("F_ProcessID") == true)
            {
                GridColumn gcProcess = gv.Columns.ColumnByFieldName("F_ProcessID");
                if (gcProcess != null)
                {
                    DataLib.DataHelper myHelper = new DataLib.DataHelper();
                    DataSet ds = myHelper.GetDs("select F_ID,F_Name from t_Process");
                    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lupEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
                    lupEdit.DataSource = ds.Tables[0].DefaultView;
                    lupEdit.ValueMember = "F_ID";
                    lupEdit.DisplayMember = "F_Name";
                    lupEdit.ShowFooter = false;
                    lupEdit.ShowHeader = false;
                    lupEdit.NullText = "";
                    gcProcess.ColumnEdit = lupEdit;
                }
            }

            if (dt.Columns.Contains("F_Unit") == true)
            {
                GridColumn gcUnit = gv.Columns.ColumnByFieldName("F_Unit");
                if (gcUnit != null)
                {
                    DataLib.DataHelper myHelper = new DataLib.DataHelper();
                    DataSet ds = myHelper.GetDs("select F_Name from t_Unit");
                    RepositoryItemComboBox cbEdit = new RepositoryItemComboBox();
                    cbEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    //cbEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(UnitBtnClick);
                    gcUnit.ColumnEdit = cbEdit;
                }
            }


            Hashtable htField = new Hashtable();
            htField.Add("Aid", "Aid");
            htField.Add("F_ItemName", "F_ItemName");
            htField.Add("F_Spec", "F_Spec");
            htField.Add("F_Material", "F_Material");
            htField.Add("F_Type", "F_Type");
            htField.Add("F_Brand", "F_Brand");
            htField.Add("F_LinkBill", "F_LinkBill");
            htField.Add("PAid", "PAid");
            htField.Add("F_BQty", "F_BQty");
            htField.Add("F_Color", "F_Color");
            htField.Add("F_Grade", "F_Grade");
            htField.Add("F_Money", "F_Money");
            htField.Add("F_LinkQty", "F_LinkQty");
            htField.Add("F_InQty", "F_InQty");
            htField.Add("F_OutQty", "F_OutQty");

            foreach (GridColumn gc in gv.Columns)
            {
                if (htField.Contains(gc.FieldName))
                {
                    gc.AppearanceCell.BackColor = Color.FromArgb(192, 255, 192);
                    gc.OptionsColumn.AllowFocus = false;
                    gc.OptionsColumn.AllowEdit = false;
                }
                gc.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                if (gc.FieldName == "Aid")
                {
                    gc.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
            }
        }

        /// <summary>
        /// 根据物料编码设置单位　
        /// </summary>
        /// <param name="strItemID"></param>
        private void SetUnit(string strItemID)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_Name from t_Unit where F_ItemID = '" + strItemID + "'");
            
            RepositoryItemComboBox cbEdit = (RepositoryItemComboBox)gvList.Columns.ColumnByFieldName("F_Unit").ColumnEdit;
            cbEdit.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbEdit.Items.Add(dr["F_Name"]);
            }
        }

        /// <summary>
        /// 选取价格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PriceBtnClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            if (dr["F_ItemID"] == DBNull.Value)
            {
                MessageBox.Show(this, "请先选取物料!!", "提示");
                return;
            }
            
            frmGetStockPrice myGetStockPrice = new frmGetStockPrice();

            if (this.Name == "frmApplyStock" || this.Name == "frmStockOrder"
                || this.Name == "frmStockIn" || this.Name == "frmStockBack")
            {
                myGetStockPrice.intFlag = 0;
            }

            if (this.Name == "frmSellPrice" || this.Name == "frmAskPrice"
               || this.Name == "frmSellOrder" || this.Name == "frmSellPre"
               || this.Name == "frmSellOut" || this.Name == "frmSellBack")
            {
                myGetStockPrice.intFlag = 1;
            }

            myGetStockPrice.SetPrice(dr["F_ItemID"].ToString());
            if (myGetStockPrice.ShowDialog() == DialogResult.OK)
            {
                gvList.SetRowCellValue(gvList.FocusedRowHandle, "F_Price", myGetStockPrice.gvPrice.GetRowCellValue(myGetStockPrice.gvPrice.FocusedRowHandle, "F_Price"));
                gvList.UpdateCurrentRow();
            }
            myGetStockPrice.Dispose();
        }

        protected virtual void ItemBtnClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            frmSelItem mySelItem = new frmSelItem();
            mySelItem.myBill = this;

            if (this.Name == "frmAskPrice" || this.Name == "frmSellPrice" || this.Name == "frmProductIn" ||
                 this.Name == "frmProductPlan" || this.Name == "frmTask" )
                mySelItem.intTag = 1;

            if (this.Name == "frmSellBack" || this.Name == "frmSellPre" || this.Name == "frmSellOrder" 
                || this.Name == "frmSellOut" || this.Name == "frmOtherIn" || this.Name == "frmCheck" ||
                this.Name == "frmExchange" || this.Name == "frmOutBill" || this.Name == "frmOtherOut")
                mySelItem.intTag = 4;

            if (this.Name == "frmBomEdit")
                mySelItem.intTag = 0;

            

            if (mySelItem.ShowDialog() == DialogResult.OK)
            {
                    DataRow dr = null;
                    DataRow drCurrent = ((DataRowView)binSlaver.Current).Row;
                    DataLib.sysClass myClass = new DataLib.sysClass();

                    if (mySelItem.TabControl.SelectedTabPageIndex == 0)
                    {
                        int[] intRow = mySelItem.gvMain.GetSelectedRows();
                        for (int i = 0; i < intRow.Length; i++)
                        {
                            dr = mySelItem.gvMain.GetDataRow(intRow[i]);
                            if (intRow.Length == 1)
                               myClass.GetItem(dr["F_ID"].ToString(), 0, drCurrent, this.Name);
                            else
                               myClass.GetItem(dr["F_ID"].ToString(), 1, drCurrent, this.Name);
                        }

                        //dr = mySelItem.gvMain.GetDataRow(mySelItem.gvMain.FocusedRowHandle);
                        //myClass.GetItem(dr["F_ID"].ToString(),0,drCurrent,this.Name);
                        gvList.UpdateCurrentRow();
                        
                    }
                    else
                    {
                        int[] intRow = mySelItem.gvStore.GetSelectedRows();
                        for (int i = 0; i < intRow.Length; i++)
                        {
                            dr = mySelItem.gvStore.GetDataRow(intRow[i]);
                            if (intRow.Length == 1)
                                myClass.GetStoreItem(dr, 0, drCurrent, strOtherTag);
                            else
                                myClass.GetStoreItem(dr, 1, drCurrent, strOtherTag);
                        }

                        //dr = mySelItem.gvStore.GetDataRow(mySelItem.gvStore.FocusedRowHandle);
                       // myClass.GetStoreItem(dr,0,drCurrent,this.Name);
                        gvList.UpdateCurrentRow();
                    }
                    this.SetUnit(dr["F_ID"].ToString());
            }
            mySelItem.Dispose();
        }

        /// <summary>
        /// 保存前检查
        /// </summary>
        protected virtual bool SavePre()
        {
            if (BindClass.RequestInput(panelControl1) == false) return false;
            
            //gvList.UpdateCurrentRow();
            //gvList.UpdateSummary();
            gvList.CloseEditor();

            DataTable dt = ((DataView)binSlaver.DataSource).Table;
            dt.AcceptChanges();
            int intCnt = gvList.RowCount;

            bool bNotNullRow = false;

            for (int i = 0; i < intCnt; i++)
            {
                DataRow dr = gvList.GetDataRow(i);

                if (dt.Columns.Contains("F_ItemID") == true)
                {
                    if (dr["F_ItemID"] != DBNull.Value) bNotNullRow = true;
                }

                foreach(DataColumn dc in dt.Columns)
                {
                    if (dc.ColumnName == "F_ItemID") continue;
                    if (dc.ColumnName == "F_BillID") continue;
                    if (dc.ColumnName == "Aid") continue;
                    if (RequestField.Contains(dc.ColumnName))
                    {
                        if (dt.Columns.Contains("F_ItemID") == true)
                        {
                            if (dr[dc.ColumnName] == DBNull.Value)
                            {
                                if (dr["F_ItemID"] != DBNull.Value)
                                {
                                    //if (dc.ColumnName == "F_Qty" && (this.Name == "frmSellOut" || this.Name == "frmStockIn")) continue;

                                    //if (dc.ColumnName == "F_Price" && DataLib.SysVar.GetParmValue("F_NeedPrice") == false) continue;

                                    GridColumn gc = gvList.Columns.ColumnByFieldName(dc.ColumnName);
                                    if (gc != null)
                                    {
                                        MessageBox.Show(gc.Caption + "不能为空!!", "提示");
                                        gcBill.Focus();
                                        gvList.FocusedColumn = gc;
                                        gvList.FocusedRowHandle = i;
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                if (dc.ColumnName == "F_Price" || dc.ColumnName == "F_Qty")
                                {
                                    if (dr["F_ItemID"] != DBNull.Value)
                                    {
                                        if (Convert.ToDecimal(dr[dc.ColumnName]) == 0)
                                        {
                                            GridColumn gc = gvList.Columns.ColumnByFieldName(dc.ColumnName);
                                            if (gc != null)
                                            {
                                                MessageBox.Show(gc.Caption + "不能为空!!", "提示");
                                                gcBill.Focus();
                                                gvList.FocusedColumn = gc;
                                                gvList.FocusedRowHandle = i;
                                                return false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }  
                
            }

            if (bNotNullRow == false && this.Name != "frmSellAccept" && this.Name != "frmStockPay"
                && this.Name != "frmOutPay" && this.Name != "frmProductProcess")
            {
                MessageBox.Show("本单必须存在一条以上分录!!", "提示");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 主表增行事件
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected virtual void MasterNewRow(object Sender, DataTableNewRowEventArgs e)
        {
            
        }

        /// <summary>
        /// 从表增行事件
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected virtual void SlaverNewRow(object Sender, DataTableNewRowEventArgs e)
        {
            DataTable dt = e.Row.Table;
            DataRow dr = e.Row;
            if (dt.Columns.Contains("F_Discount") != false)
                dr["F_Discount"] = 100;
            if (dt.Columns.Contains("AID") != false)
                dr["AID"] = binSlaver.Count + 1;
        }

        /// <summary>
        /// 从表列值正在改变发生
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected virtual void ColumnChanging(object Sender, DataColumnChangeEventArgs e)
        {
        }

        /// <summary>
        /// 从表列值改变后发生
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected virtual void ColumnChanged(object Sender, DataColumnChangeEventArgs e)
        {
            //if (e.Column.ColumnName == "F_ItemID")
            //{
            //    DataLib.sysClass myClass = new DataLib.sysClass();

            //    if (myClass.FindItem(e.ProposedValue.ToString()) != null)
            //    {
            //        if (e.ProposedValue == DBNull.Value)
            //        {
            //            myClass.GetItem(e.ProposedValue.ToString(), 0, e.Row, this.Name);
            //        }
            //    }
            //}

            if (this.Name == "frmBomEdit" || this.Name == "frmProductProcess" || this.Name == "frmTask" || this.Name == "frmProductPlan") return;
            if (e.Column.ColumnName == "F_Price" || e.Column.ColumnName == "F_Qty" ||
                e.Column.ColumnName == "F_Discount" || e.Column.ColumnName == "F_TaxRate")
            {
                
                object decPrice, decQty, decDis, decTaxRate;
                DataTable dt = e.Row.Table;

                if (dt.Columns.Contains("F_Price") == true)
                    decPrice = e.Row["F_Price"];
                else
                    decPrice = 0;

                if (dt.Columns.Contains("F_Qty") == true)
                    decQty = e.Row["F_Qty"];
                else
                    decQty = 0;

                if (dt.Columns.Contains("F_Discount") == true)
                    decDis = e.Row["F_Discount"];
                else
                    decDis = 100;

                if (dt.Columns.Contains("F_TaxRate") == true)
                {
                    decTaxRate = e.Row["F_TaxRate"];
                    if (decTaxRate == DBNull.Value) decTaxRate = 0;
                }
                else
                    decTaxRate = 0;

                if (decPrice == DBNull.Value)
                    decPrice = 0;

                if (decQty == DBNull.Value)
                    decQty = 0;

                if (decDis == DBNull.Value)
                    decDis = 100;

                decimal decRateMoney = Convert.ToDecimal(decPrice) * Convert.ToDecimal(decQty) * Convert.ToDecimal(decTaxRate) / 100;
                decimal decMoney = Convert.ToDecimal(decPrice) * Convert.ToDecimal(decQty) * Convert.ToDecimal(decDis) / 100;
                e.Row.BeginEdit();
                if (dt.Columns.Contains("F_Money") == true)
                   e.Row["F_Money"] = decMoney + decRateMoney;
                e.Row.EndEdit();
                //gvList.SetRowCellValue(e.RowHandle, "F_Money", decMoney + decRateMoney);
                //gvList.CloseEditor();
            }
        }

        /// <summary>
        /// 主表列值改变后发生
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected virtual void MasterColumnChanged(object Sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == "")
            {

            }
        }

        /// <summary>
        /// 主表列值改变时发生
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected virtual void MasterColumnChanging(object Sender, DataColumnChangeEventArgs e)
        {

        }

        /// <summary>
        /// 新增
        /// </summary>
        public virtual void BindData()
        { 
            if (strMasterSQL == "") return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetOtherDs(strMasterSQL, GetParm());
            DataLib.sysClass myClass = new DataLib.sysClass();
            
            myClass.SetColumnInfo(null,strMTable, ds.Tables[0]);
            binMaster.DataSource = ds.Tables[0].DefaultView;
            ds.Tables[0].TableNewRow += new DataTableNewRowEventHandler(MasterNewRow);
            ds.Tables[0].ColumnChanged += new DataColumnChangeEventHandler(MasterColumnChanged);
            ds.Tables[0].ColumnChanging += new DataColumnChangeEventHandler(MasterColumnChanging);

            BindSlaver();
            //if (bAssignFlag == false)
            //{   
                //AssignField("", gvList);
                DataLib.sysClass.LoadFormatFromDB(gvList, this.Name, Convert.ToInt32(strBillTag));
                SetFieldType(binSlaver, gvList);
               
                DataLib.SysVar.TestColumnRight(gvList, this.Name + "List");
                
                BindClass.BindControl(panelControl1, binMaster);
                BindClass.BindControl(panelControl2, binMaster);
            //}

            if (ds.Tables[0].Rows.Count == 0)
            {
                SetStatus(2);
            }
            else
            {
                DataRow dr = ds.Tables[0].Rows[0];
               
                if (ds.Tables[0].Columns.Contains("F_CutOff") == false)
                {
                    if (DataLib.SysVar.GetParmValue("F_N15") == true && bMultCheck == true)
                    {
                        if (TestMultCheck() == true)
                        {
                            SetStatus(3);
                        }
                        else
                        {
                            SetStatus(2);
                        }
                    }
                    else
                    {
                        if (Convert.ToBoolean(dr["F_Check"]) == true)
                            SetStatus(3);
                        else
                            SetStatus(2);
                    }
                }
                else
                {
                    bool blnCutOff = dr["F_CutOff"] == DBNull.Value ? false : Convert.ToBoolean(dr["F_CutOff"]);


                    if (blnCutOff == true)
                        SetStatus(4);
                    else
                    {
                        if (DataLib.SysVar.GetParmValue("F_N15") == true && bMultCheck == true)
                        {
                            if (TestMultCheck() == true)
                            {
                                SetStatus(3);
                            }
                            else
                            {
                                SetStatus(2);
                            }
                        }
                        else
                        {
                            if (Convert.ToBoolean(dr["F_Check"]) == true)
                                SetStatus(3);
                            else
                                SetStatus(2);
                        }
                    }
                }

                if (ds.Tables[0].Columns.Contains("F_Finish") == true)
                {
                    if (Convert.ToBoolean(dr["F_Finish"]) == true)
                        picFinish.Visible = true;
                }

                if (ds.Tables[0].Columns.Contains("F_Invalid") == true)
                {
                    if (dr["F_Invalid"] != DBNull.Value)
                    {
                        if (Convert.ToBoolean(dr["F_Invalid"]) == true)
                            SetStatus(5);
                    }
                }
            }
        }


        
        /// <summary>
        /// 新增
        /// </summary>
        public virtual void NewBill()
        {
            if (TestModify() == true)
            {
                if (MessageBox.Show(this, "是否放弃所作的修改?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;   
            }
            strBillID = "";
            
            BindData(); 
            
            DataTable dt = ((DataView)binMaster.DataSource).Table;
            
            DataRow dr = ((DataRowView)binMaster.AddNew()).Row;
            DataLib.sysClass myClass = new DataLib.sysClass();

            if (strBillText == "") strBillText = this.Text;
            dr["F_BillID"] = myClass.GetMaxCode(strBillText,"F_BillID",strMTable);
            dr["F_Date"] = DataLib.SysVar.GetDate();
            dr["F_BillMan"] = DataLib.SysVar.strUName;
            dr["F_CheckMan"] = "";
            dr["F_CheckDate"] = "1900-1-1";
            dr["F_Check"] = false;
            if (dt.Columns.Contains("F_Finish") == true)
               dr["F_Finish"] = false;
           if (dt.Columns.Contains("F_CutOff") == true)
               dr["F_CutOff"] = false;

           if (dt.Columns.Contains("F_Invalid") == true)
               dr["F_Invalid"] = false;

           DataLib.SysVar.SetLog(this.Text, "新增", "单号为"+dr["F_BillID"].ToString());
           binMaster.EndEdit();
           SetStatus(1);
        }

        /// <summary>
        /// 检查单据是否被更新
        /// </summary>
        /// <returns></returns>
        private bool TestModify()
        {

            if (binMaster.DataSource == null) return false;
            if (binSlaver.DataSource == null) return false;

            gvList.UpdateCurrentRow();

            binMaster.EndEdit();
            binSlaver.EndEdit();

            DataTable dtMaster = ((DataView)binMaster.DataSource).Table;
            DataTable dtSlaver = ((DataView)binSlaver.DataSource).Table;

            DataTable dtMasterAdd = dtMaster.GetChanges(DataRowState.Added);
            DataTable dtMasterModify = dtMaster.GetChanges(DataRowState.Modified);
            DataTable dtDetailAdd = dtSlaver.GetChanges(DataRowState.Added);
            DataTable dtDetailModify = dtSlaver.GetChanges(DataRowState.Modified);
            DataTable dtDetailDel = dtSlaver.GetChanges(DataRowState.Deleted);
            if (dtMasterAdd != null || dtMasterModify != null || dtDetailAdd != null &&
                dtDetailModify != null || dtDetailDel != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        public virtual void EditBill()
        {
        }

        /// <summary>
        /// 保存单据
        /// </summary>
        protected virtual bool SaveBill()
        {
            int intCnt = 0;
            if (SavePre() == false) return false;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            binSlaver.EndEdit();
            binMaster.EndEdit();
            if (this.Name != "frmBomEdit" && this.Name != "frmProductProcess")
            {
                if (TestCheckOut() == true)
                {
                    MessageBox.Show(this, "该月已结帐，不能对该月开单!!", "提示");
                    return false;
                }
            }
            DataSet dsMaster = ((DataView)binMaster.DataSource).Table.DataSet;
            DataSet dsSlaver = ((DataView)binSlaver.DataSource).Table.DataSet;

            object objMoney = DBNull.Value;

            if (dsSlaver.Tables[0].Columns.Contains("F_Money") == true)
            {
                objMoney = gvList.Columns.ColumnByFieldName("F_Money").SummaryItem.SummaryValue;
                if (dsMaster.Tables[0].Columns.Contains("F_Money") == true)
                {
                    dsMaster.Tables[0].Rows[0]["F_Money"] = objMoney;
                }
            }


            if (this.Name == "frmSellOrder" || this.Name == "frmSellPre" || this.Name == "frmSellOut")
            {
                //DataLib.DataHelper myHelper = new DataLib.DataHelper();
                string sClient = ((DataRowView)binMaster.Current).Row["F_ClientID"].ToString();
                DataSet ds = myHelper.GetDs("select isnull(F_ClientXinyong,0) as F_XinYong from t_Client where F_ID = '" + sClient + "'");
                decimal DecXinYong = 0;
                if (ds.Tables[0].Rows.Count > 0)
                    DecXinYong = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);

                if (Convert.ToDecimal(objMoney) > DecXinYong && DecXinYong > 0)
                {
                    MessageBox.Show(this, "本单金额超出客户信用额度,不能保存!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            binSlaver.EndEdit();
            binMaster.EndEdit();


            DataSet dsUpdateSlaver = myHelper.GetOtherDs(strSaveSlaverSQL, GetParm());


            foreach (DataRow dr in dsUpdateSlaver.Tables[0].Rows)
            {
                dr.Delete();
            }

            DataTable dt = dsSlaver.Tables[0];
            //dt.AcceptChanges();

            int m = 1;
            foreach (DataRow dr in dt.Rows)
            {
                if (dt.Columns.Contains("F_ItemID") == true)
                {
                    if (dr["F_ItemID"] == DBNull.Value)
                        continue;
                    else
                    {
                        if (dr["F_ItemID"].ToString().Length == 0) continue;
                    }
                }

                if (this.Name == "frmSellAccept" || this.Name == "frmStockPay" || this.Name == "frmOutPay")
                {
                    if (dr["F_LinkBill"].ToString().Length == 0) continue;
                }

                if (this.Name == "frmProductProcess")
                {
                    if (dr["F_DeptID"].ToString().Length == 0) continue;
                }

                DataRow drNew = dsUpdateSlaver.Tables[0].NewRow();

                if (dt.Columns.Contains("Aid") == true)
                {
                    drNew["Aid"] = m;
                }

                intCnt = dt.Columns.Count;
                for (int i = 0; i < intCnt; i++)
                {
                    if (dt.Columns[i].ColumnName == "Aid") continue;

                    if (dt.Columns[i].ColumnName == "F_BillID")
                    {
                        drNew["F_BillID"] = dsMaster.Tables[0].Rows[0]["F_BillID"].ToString();
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
                m = m + 1;

            }

            if (Save(dsMaster, dsSlaver, dsUpdateSlaver) == true)
            {
                //BindData();
                return true;
            }

            return false;
            
        }

        /// <summary>
        /// 保存数据方法(虚拟方法，可供子类重写)
        /// </summary>
        /// <param name="dsMaster">主表数据集</param>
        /// <param name="dsSlaver">从表数据集</param>
        /// <param name="dsUpdateSlaver">要更新的数据集</param>
        /// <returns></returns>
        protected virtual bool Save(DataSet dsMaster,DataSet dsSlaver,DataSet dsUpdateSlaver)
        {
            DataSet[] dsData = new DataSet[2];
            dsData[0] = dsMaster;
            dsData[1] = dsUpdateSlaver;

            string[] strSQL = new string[2];
            strSQL[0] = strMasterSQL;
            strSQL[1] = strSaveSlaverSQL;

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.SaveMuteData1(dsData, strSQL, GetParm()).Length == 0)
            {
                DataLib.SysVar.SetLog(this.Text, "保存", "保存单据" + editControl1.GetValue().ToString());
                MessageBox.Show("数据保存成功!!", "提示");
                strBillID = editControl1.GetValue().ToString();
                dsMaster.AcceptChanges();
                dsSlaver.AcceptChanges();
                SetStatus(2);
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 复制单据
        /// </summary>
        protected virtual void CopyBill()
        {
            if (TestModify() == true)
            {
                if (MessageBox.Show(this, "复制单据前请先保存本单?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            }

            if (MessageBox.Show(this, "真的要将本单复制成另一张新单吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            
            DataRow drMaster = ((DataRowView)binMaster.Current).Row;
            DataTable dtSlaver = ((DataView)binSlaver.DataSource).Table.Copy();
            NewBill();
            DataRow drNewMaster = ((DataRowView)binMaster.Current).Row;
            foreach (DataColumn dcMaster in drMaster.Table.Columns)
            {
                if (dcMaster.ColumnName == "F_BillID" || dcMaster.ColumnName == "F_Date"
                    || dcMaster.ColumnName == "F_BillMan" || dcMaster.ColumnName == "F_Check"
                    || dcMaster.ColumnName == "F_CheckDate" || dcMaster.ColumnName == "F_CheckMan"
                    || dcMaster.ColumnName == "F_Finish" || dcMaster.ColumnName == "F_CutOff") continue;
                drNewMaster[dcMaster.ColumnName] = drMaster[dcMaster.ColumnName];
            }

            DataTable dtNewSlaver = ((DataView)binSlaver.DataSource).Table;
            dtNewSlaver.Rows.Clear();
            foreach (DataRow drSlaver in dtSlaver.Rows)
            {
                DataRow drNewSlaver = dtNewSlaver.NewRow();
                foreach (DataColumn dcSlaver in dtSlaver.Columns)
                {
                    drNewSlaver[dcSlaver.ColumnName] = drSlaver[dcSlaver.ColumnName];
                }
                dtNewSlaver.Rows.Add(drNewSlaver);
            }
            binSlaver.Position = 0;
        }

        /// <summary>
        /// 增行
        /// </summary>
        protected virtual void AddRow()
        {
            if (TestRight("增行") == false) return;
            binSlaver.AddNew();
            DataTable dt = ((DataView)binSlaver.DataSource).Table;
            if (dt.Columns.Contains("F_ItemID")  != false)
                gvList.FocusedColumn = gvList.Columns.ColumnByFieldName("F_ItemID");
        }

        /// <summary>
        /// 删行
        /// </summary>
        protected virtual void DelRow()
        {
            if (TestRight("删行") == false) return;
            if (gvList.FocusedRowHandle < 0) return;
            binSlaver.RemoveCurrent();
            SetAutoID();
        }

        /// <summary>
        /// 审核
        /// </summary>
        protected virtual void CheckBill()
        {
            if (TestRight("审核") == false) return;
            if (MessageBox.Show(this, "真的要审核本单吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            if (DataLib.SysVar.GetParmValue("F_N15") == true && bMultCheck == true)
            {
                string strSQL = "select isnull(F_CheckLevel,0) as F_CheckLevel,isnull(F_NextLevel,0) as F_NextLevel from t_MultCheck where F_BillType = '"+this.Text+"' and F_CheckMan = '"+DataLib.SysVar.strUID+"'";
                
                DataTable dt = myHelper.GetDs(strSQL).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(this,"该用户没有设置多级审核权，不能审核","提示");
                    return;
                }
                int intCheck = Convert.ToInt32(dt.Rows[0]["F_CheckLevel"]);

                int intNextCheck = Convert.ToInt32(dt.Rows[0]["F_NextLevel"]);

                if (myHelper.ExecuteSQL("update " + strMTable + " set F_CheckFlag = " + intCheck.ToString() + ",F_CheckMan" + intCheck.ToString() + " = '" + DataLib.SysVar.strUName + "',F_CheckDate = '" + DataLib.SysVar.GetDate().ToString() + "' where F_BillID = '" + editControl1.GetValue().ToString() + "'") == 0)
                {
                    if (intNextCheck == -1)
                    {
                        if (myHelper.ExecuteSQL("update " + strMTable + " set F_Check = 1,F_CheckMan = '" + DataLib.SysVar.strUName + "',F_CheckDate = '" + DataLib.SysVar.GetDate().ToString() + "' where F_BillID = '" + editControl1.GetValue().ToString() + "'") == 0)
                        {
                            DataLib.SysVar.SetLog(this.Text, "审核", "审核单据" + editControl1.GetValue().ToString());
                            SetStatus(3);
                        }
                    }
                    else
                    {
                        DataLib.SysVar.SetLog(this.Text, "审核", "审核单据" + editControl1.GetValue().ToString());
                        SetStatus(3);
                    }
                }
            }
            else
            {
                if (myHelper.ExecuteSQL("update " + strMTable + " set F_Check = 1,F_CheckMan = '" + DataLib.SysVar.strUName + "',F_CheckDate = '" + DataLib.SysVar.GetDate().ToString() + "' where F_BillID = '" + editControl1.GetValue().ToString() + "'") == 0)
                {
                    DataLib.SysVar.SetLog(this.Text, "审核", "审核单据" + editControl1.GetValue().ToString());
                    SetStatus(3);
                }
            }
        }

        /// <summary>
        /// 反审核
        /// </summary>
        protected virtual void UnCheckBill()
        {
            if (TestRight("反审核") == false) return;
            if (this.Name != "frmBomEdit" && this.Name != "frmProductProcess")
            {
                if (TestCheckOut() == true)
                {
                    MessageBox.Show(this, "该月已结帐，不能反审该月单据!!", "提示");
                    return;
                }
            }
            if (MessageBox.Show(this, "真的要反审核本单吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            if (DataLib.SysVar.GetParmValue("F_N15") == true && bMultCheck == true)
            {
                DataRow dr = ((DataRowView)binMaster.Current).Row;
                int intCheck = Convert.ToInt32(dr["F_CheckFlag"]);


                DataTable dt = myHelper.GetDs("select top 1 isnull(F_NextLevel,0) as F_NextLevel from t_MultCheck where F_BillType = '" + this.Text + "' and F_CheckMan = '" + DataLib.SysVar.strUID + "'").Tables[0];

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["F_NextLevel"].ToString() != "-1")
                    {
                        string sCheckMan = dr["F_CheckMan" + dt.Rows[0]["F_NextLevel"]] == DBNull.Value ? "" : dr["F_CheckMan" + dt.Rows[0]["F_NextLevel"]].ToString();
                        if (sCheckMan != "")
                        {
                            MessageBox.Show(this, "该单下级已审核过，你不能反审!");
                            return;
                        }
                    }

                    DataTable dtTmp = myHelper.GetDs("select top 1 isnull(F_CheckLevel,0) as F_CheckLevel from t_MultCheck where F_BillType = '" + this.Text + "' and F_NextLevel = " + intCheck.ToString()).Tables[0];
                    int iPreCheck = 0;
                    if (dtTmp.Rows.Count > 0)
                    {
                        iPreCheck = Convert.ToInt32(dtTmp.Rows[0]["F_CheckLevel"]);
                    }

                    //if (Convert.ToInt32(dt.Rows[0]["F_NextLevel"]) != -1)
                    //{


                    if (myHelper.ExecuteSQL("update " + strMTable + " set F_CheckFlag = " + iPreCheck.ToString() + ",F_CheckMan" + intCheck.ToString() + " = '',F_CheckDate = '1900-1-1' where F_BillID = '" + editControl1.GetValue().ToString() + "'") == 0)
                    {
                    }
                    //}

                    if (Convert.ToInt32(dt.Rows[0]["F_NextLevel"]) == -1)
                    {
                        if (myHelper.ExecuteSQL("update " + strMTable + " set F_Check = 0,F_CheckMan = '',F_CheckDate = '1900-1-1' where F_BillID = '" + editControl1.GetValue().ToString() + "'") == 0)
                        {
                            DataLib.SysVar.SetLog(this.Text, "反审核", "反审核单据" + editControl1.GetValue().ToString());
                        }
                    }

                }
                BindData();

             
            }
            else
            {
                if (myHelper.ExecuteSQL("update " + strMTable + " set F_Check = 0,F_CheckMan = '',F_CheckDate = '1900-1-1' where F_BillID = '" + editControl1.GetValue().ToString() + "'") == 0)
                {
                    DataLib.SysVar.SetLog(this.Text, "反审核", "反审核单据" + editControl1.GetValue().ToString());
                    //SetStatus(2);
                    BindData();
                }
            }
        }

         /// <summary>
        /// 作废
        /// </summary>
        protected virtual void InValid()
        {
            if (TestRight("作废") == false) return;
            if (MessageBox.Show(this, "真的要作废本单吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("update " + strMTable + " set F_Invalid = 1 where F_BillID = '" + editControl1.GetValue().ToString() + "'") == 0)
            {
                DataLib.SysVar.SetLog(this.Text, "作废", "作废单据" + editControl1.GetValue().ToString());
                SetStatus(5);
            }
        }


        /// <summary>
        /// 反作废
        /// </summary>
        protected virtual void UnInValid()
        {
            if (TestRight("反作废") == false) return;
            if (MessageBox.Show(this, "真的要作废本单吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("update " + strMTable + " set F_Invalid = 0 where F_BillID = '" + editControl1.GetValue().ToString() + "'") == 0)
            {
                DataLib.SysVar.SetLog(this.Text, "反作废", "反作废单据" + editControl1.GetValue().ToString());
                SetStatus(2);
            }
        }


        /// <summary>
        /// 中止
        /// </summary>
        protected virtual void CutOff()
        {

            if (TestRight("中止") == false) return;
            //if (this.Name != "frmBomEdit" && this.Name != "frmProductProcess")
            //{
            //    if (TestCheckOut() == true)
            //    {
            //        MessageBox.Show(this, "该月已结帐，不能中止该月单据!!", "提示");
            //        return;
            //    }
            //}

            DataTable dt = ((DataView)binMaster.DataSource).Table;

            if (dt.Columns.Contains("F_Finish") == true)
            {
                if (Convert.ToBoolean(dt.Rows[0]["F_Finish"]) == true)
                {
                    MessageBox.Show(this, "本单已完成，不能中止!!", "提示");
                    return;
                }
            }

            if (MessageBox.Show(this, "真的要中止本单吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("update " + strMTable + " set F_CutOff = 1 where F_BillID = '" + editControl1.GetValue().ToString() + "'") == 0)
            {
                DataLib.SysVar.SetLog(this.Text, "中止", "中止单据" + editControl1.GetValue().ToString());
                SetStatus(4);
            }
        }

        /// <summary>
        /// 反中止
        /// </summary>
        protected virtual void UnCutOff()
        {
            if (TestRight("反中止") == false) return;
            if (this.Name != "frmBomEdit" && this.Name != "frmProductProcess")
            {
                if (TestCheckOut() == true)
                {
                    MessageBox.Show(this, "该月已结帐，不能反中止该月单据!!", "提示");
                    return;
                }
            }
            if (MessageBox.Show(this, "真的要反中止本单吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("update " + strMTable + " set F_CutOff = 0 where F_BillID = '" + editControl1.GetValue().ToString() + "'") == 0)
            {
                DataLib.SysVar.SetLog(this.Text, "反中止", "反中止单据" + editControl1.GetValue().ToString());
                SetStatus(3);
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 用数据集绑定从表
        /// </summary>
        public virtual void BindSlaver()
        {
            if (strSlaverSQL == "") return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            DataSet ds = myHelper.GetOtherDs(strSlaverSQL, GetParm());
            DataLib.sysClass myClass = new DataLib.sysClass();
            binSlaver.DataSource = ds.Tables[0].DefaultView;
            if (RequestField != null) RequestField.Clear();
            RequestField = myClass.SetColumnInfo(gvList, strMTable + "Detail", ds.Tables[0]);

            ds.Tables[0].TableNewRow += new DataTableNewRowEventHandler(SlaverNewRow);
            ds.Tables[0].ColumnChanging += new DataColumnChangeEventHandler(ColumnChanging);
            ds.Tables[0].ColumnChanged += new DataColumnChangeEventHandler(ColumnChanged);
            //myClass.SetColumnDrop(strMTable,gvList);

            if (TestRight1("增行") == true)
            {
                int intAdd = 20 - ds.Tables[0].Rows.Count;
                for (int i = 0; i < intAdd; i++)
                {
                    binSlaver.AddNew();
                }
                binSlaver.Position = 0;
                ((DataView)binSlaver.DataSource).Table.AcceptChanges();
            }
            
        }

        private void binMaster_PositionChanged(object sender, EventArgs e)
        {

        }

        private void btnAddRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddRow();
        }

        private void btnDelRow_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DelRow();
        }

        private void binMaster_AddingNew(object sender, AddingNewEventArgs e)
        {

        }

        private void frmBill_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TestModify() == true)
            {
                if (MessageBox.Show(this,"是否放弃所作的修改?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.No)
                   e.Cancel = true;
            }
        }

        /// <summary>
        /// KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void ViewKeyDown(object sender, KeyEventArgs e)
        {

        }

        /// <summary>
        /// 表格格式设置
        /// </summary>
        /// <param name="gv"></param>
        protected void SetFormat(GridView gv)
        {
             frmSetGrid myGrid = new frmSetGrid();
             myGrid.intFlag = 1;
             myGrid.gvSource = gv;
             myGrid.ShowDialog();
             myGrid.Dispose();
        }

        private void frmBill_KeyDown(object sender, KeyEventArgs e)
        {
            //关闭窗体
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

            //表格字段设置
            if (e.KeyCode == Keys.F7 && DataLib.SysVar.strUGroup == "超级用户")
            {
                if (gvList.IsFocusedView)
                   SetFormat(gvList);
            }

            //保存表格格式
            if (e.KeyCode == Keys.F5 && DataLib.SysVar.strUGroup == "超级用户")
            {
                DataLib.sysClass.SaveGridToDB(gvList, this.Name, Convert.ToInt32(this.strBillTag));
                //SaveFieldFormat("", gvList);
            }

            //物料Bom库存情况
            if (e.KeyCode == Keys.F6)
            {
                if (gvList.FocusedRowHandle < 0) return;
                DataTable dt = ((DataView)binSlaver.DataSource).Table;
                if (dt.Columns.Contains("F_ItemID") == false) return;
                DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
                if (dr["F_ItemID"] == DBNull.Value) return;
                Common.frmBomStoreQty F = new frmBomStoreQty(dr["F_ItemID"].ToString());
                F.ShowDialog();
                F.Dispose();
            }

            //物料库存情况
            if (e.KeyCode == Keys.F9)
            {
                if (gvList.FocusedRowHandle < 0) return;
                DataTable dt = ((DataView)binSlaver.DataSource).Table;
                if (dt.Columns.Contains("F_ItemID") == false) return;
                DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
                if (dr["F_ItemID"] == DBNull.Value) return;
                CommonData.frmStorageInfo myStorageInfo = new CommonData.frmStorageInfo();
                myStorageInfo.strItemID = dr["F_ItemID"].ToString();
                myStorageInfo.ShowDialog();
                myStorageInfo.Dispose();
            }

            //物料库存情况（多物料）
            if (e.KeyCode == Keys.F8)
            {
                if (gvList.RowCount == 0) return;
                DataTable dt = ((DataView)binSlaver.DataSource).Table;
                if (dt.Columns.Contains("F_ItemID") == false) return;

                string strItemID = "";
                for (int i = 0; i < gvList.RowCount; i++)
                {
                    DataRow dr = gvList.GetDataRow(i);
                    if (dr["F_ItemID"] == DBNull.Value) continue;
                    strItemID = strItemID + "'" + dr["F_ItemID"].ToString() + "',";
                }

                if (strItemID == "") return;
                strItemID = strItemID.Substring(0,strItemID.Length - 1);

                CommonData.frmStorageInfoEx myStorageInfoEx = new CommonData.frmStorageInfoEx();
                myStorageInfoEx.strItemID = strItemID;
                myStorageInfoEx.ShowDialog();
                myStorageInfoEx.Dispose();
            }

            if (e.Control == true && e.KeyCode == Keys.B && blnBarCode == true)
            {
                frmBarCode myBarCode = new frmBarCode();
                myBarCode.myBill = this;
                myBarCode.ShowDialog();
                myBarCode.Dispose();
            }

            if (e.Control == true && e.KeyCode == Keys.E)
            {
                BillExport();
            }

            if (e.Control == true && e.KeyCode == Keys.M)
            {
                BillImport();
            }

            ViewKeyDown(sender,e);
        }

        public void SetItem(DataRow dr,int intFlag)
        {
             DataLib.sysClass myClass = new DataLib.sysClass();
             myClass.GetItem(dr["F_ID"].ToString(),intFlag,((DataRowView)binSlaver.Current).Row,this.Name);
             gvList.UpdateCurrentRow();
             if (binSlaver.Position < binSlaver.Count)
                binSlaver.MoveNext();
        }

        public void SetStore(DataRow dr,int intFlag)
        {
             DataLib.sysClass myClass = new DataLib.sysClass();
             myClass.GetStoreItem(dr,intFlag,((DataRowView)binSlaver.Current).Row,this.Name);
             gvList.UpdateCurrentRow();
             if (binSlaver.Position < binSlaver.Count)
                 binSlaver.MoveNext();
        }

        protected virtual void CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "F_ItemID")
            {
                DataLib.sysClass myClass = new DataLib.sysClass();

                myClass.GetItem(e.Value.ToString(), 0, ((DataRowView)binSlaver.Current).Row, this.Name);
            }
        }

        private void gvList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CellValueChanged(sender,e);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveBill();
        }

        private void btnCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CheckBill();
        }

        private void btnCutOff_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CutOff();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewBill();
        }

        private void btnUnCheck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UnCheckBill();
        }

        private void btnUnCutOff_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UnCutOff();
        }

        private void gvList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && gvList.OptionsBehavior.Editable == true)
            {
                if (gvList.FocusedRowHandle == gvList.RowCount - 1)
                    AddRow();
            }

            if (e.KeyCode == Keys.F9 && gvList.OptionsBehavior.Editable == true)
            {
                ItemBtnClick(null,null);
            }
        }

        private void gvList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(e.FocusedRowHandle);

            DataTable dt = ((DataView)binSlaver.DataSource).Table;
            if (dt.Columns.Contains("F_ItemID") == true)
            {
                if (dr["F_ItemID"] == DBNull.Value) return;
                SetUnit(dr["F_ItemID"].ToString());
            }
            FocusedRowChanged(sender,e);
        }

        protected virtual void FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }

        private void btnLoadBill_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadBill();
        }

        private void biDesign_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintDesign();
        }

        private void biPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintPreview();
        }

        private void biPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintDialog();
        }

        private void gvList_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CellValueChanging(sender,e);
        }

        protected virtual void CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void frmBill_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
            {
                if (DataLib.SysVar.strUID != "" && DataLib.SysVar.blnDesignForm == false)
                {
                    LoadLayout r = new LoadLayout(this, this.Name);
                    r.SetLayout();
                }

                if (TestImport() == true)
                    btnLoadBill.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                BindClass.SetControlRight(panelControl1, this.Name);
            }
        }

        private void btnBalance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TestRight("凭证") == false) return;
            GenBalance();
        }

        private void btnCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CopyBill();
        }

        private void barInvalid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InValid();
        }

        private void barUnValid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UnInValid();
        }

        private void gcBill_DoubleClick(object sender, EventArgs e)
        {
            GridDbClick();
        }

        protected virtual void GridDbClick()
        {

        }

    }
}

