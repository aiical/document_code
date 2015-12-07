using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

namespace Product
{
    public partial class frmTask : Common.frmBill
    {
        private string strPItemID;
        private decimal decGID;

        public frmTask()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N32")) bMultCheck = true;
            btnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnUnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            Common.XtraChinese p = new Common.XtraChinese();
            p.chineseXtraGrid(this.gcHalf);
            p.chineseXtraGrid(this.gcItem);
            gcBill.Parent = TabProduct; 
            gcDept.SendToBack();
            gvList.OptionsSelection.EnableAppearanceFocusedRow = true;
        }

        /// <summary>
        /// 增行
        /// </summary>
        protected override void AddRow()
        {
            if (TabControl.SelectedTabPageIndex == 0)
            {
                if (gvDept.IsFocusedView == true)
                {
                    binDept.AddNew();
                    gvDept.UpdateCurrentRow();
                }
                else
                    base.AddRow();
            }


            if (TabControl.SelectedTabPageIndex == 1)
            {
                binHalf.AddNew();
                gvHalf.UpdateCurrentRow();
            }

            if (TabControl.SelectedTabPageIndex == 2)
            {
                binItem.AddNew();
                gvItem.UpdateCurrentRow();
            }
   
        }

        /// <summary>
        /// 删行
        /// </summary>
        protected override void DelRow()
        {

            if (TabControl.SelectedTabPageIndex == 0)
            {
                if (gvDept.IsFocusedView == true)
                {
                    if (gvDept.FocusedRowHandle < 0) return;
                    binDept.RemoveCurrent();
                }
                else
                {
                    if (gvList.FocusedRowHandle < 0) return;
                    binSlaver.RemoveCurrent();
                    SetAutoID();
                }
            }

            if (TabControl.SelectedTabPageIndex == 1)
            {
                if (gvHalf.FocusedRowHandle < 0) return;
                binHalf.RemoveCurrent();
                SetAutoID();
            }

            if (TabControl.SelectedTabPageIndex == 2)
            {
                if (gvItem.FocusedRowHandle < 0) return;
                binItem.RemoveCurrent();
                SetAutoID();
            }
   
        }

        protected override void SetAutoID()
        {
            int intCnt;
            if (TabControl.SelectedTabPageIndex == 0)
            {
                base.SetAutoID();
            }

            if (TabControl.SelectedTabPageIndex == 1)
            {
                intCnt = gvHalf.RowCount;
                gvHalf.BeginUpdate();
                for (int i = 0; i < intCnt; i++)
                {
                    gvHalf.SetRowCellValue(i, "Aid", i + 1);
                }
                gvHalf.EndUpdate();
                binHalf.EndEdit();
            }

            if (TabControl.SelectedTabPageIndex == 2)
            {
                intCnt = gvItem.RowCount;
                gvItem.BeginUpdate();
                for (int i = 0; i < intCnt; i++)
                {
                    gvItem.SetRowCellValue(i, "Aid", i + 1);
                }
                gvItem.EndUpdate();
                binHalf.EndEdit();
            }
        }

        private void ExpandAll()
        {
            while (binHalf.Count > 0)
            {
                binHalf.RemoveCurrent();
            }

            while (binItem.Count > 0)
            {
                binItem.RemoveCurrent();
            }

            gvList.PostEditor();
            gvList.CloseEditor();

            int intCnt = gvList.RowCount;

            for(int i = 0;i < intCnt; i ++)
            {
                if (gvList.GetRowCellValue(i, "F_Qty") == DBNull.Value && gvList.GetRowCellValue(i, "F_ItemID") != DBNull.Value)
                {
                    MessageBox.Show(this,"产品数量不能为空!!","提示");
                    return;
                }
            }

            for(int i = 0;i < intCnt; i ++)
            {
                if (gvList.GetRowCellValue(i, "F_ItemID") == DBNull.Value || gvList.GetRowCellValue(i, "F_Qty") == DBNull.Value) continue;
                string strID = gvList.GetRowCellValue(i,"F_ItemID").ToString();
                strPItemID = strID;
                decGID = Convert.ToDecimal(gvList.GetRowCellValue(i,"Aid"));
                decimal decQty = Convert.ToDecimal(gvList.GetRowCellValue(i,"F_Qty"));
                Expand(strID,decQty);
            }
        }

        /// <summary>
        /// 根据BOM展开
        /// </summary>
        private void Expand(string strItemID,decimal decQty)
        {
            string strSQL;
            decimal decMQty = 0;
            DataSet dsTmp = null;
            strSQL = "select c.F_ID,c.F_Name,c.F_Spec,b.F_Unit,b.F_Qty,b.F_Waste,b.F_ActuQty,c.F_Price,b.F_DeptID,b.F_ProcessID ";
            strSQL = strSQL + "from t_Bom a,t_BomDetail b,t_Item c ";
            strSQL = strSQL + "where a.F_BillID = b.F_BillID ";
            strSQL = strSQL + "and b.F_ItemID = c.F_ID ";
            strSQL = strSQL + "and a.F_ItemID = '" + strItemID + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dsTmp = myHelper.GetDs("select F_ItemID from t_Bom where F_ItemID = '"+dr["F_ID"].ToString()+"'");
                if (dsTmp.Tables[0].Rows.Count > 0)
                {
                    DataRow drHalf = ((DataRowView)binHalf.AddNew()).Row;
                    drHalf["PAid"] = decGID;
                    drHalf["F_PItemID"] = strItemID; 
                    drHalf["F_ItemID"] = dr["F_ID"]; 
                    drHalf["F_ItemName"] = dr["F_Name"];
                    drHalf["F_Spec"] = dr["F_Spec"];
                    drHalf["F_Unit"] = dr["F_Unit"];
                    drHalf["F_DeptID"] = dr["F_DeptID"];
                    drHalf["F_ProcessID"] = dr["F_ProcessID"];
                    if (dr["F_ActuQty"] == DBNull.Value)
                        decMQty = 0;
                    else
                        decMQty = Convert.ToDecimal(dr["F_ActuQty"]) * decQty;

                    drHalf["F_Qty"] = decMQty;
                    Expand(dr["F_ID"].ToString(), decMQty);
                }
                else
                {
                    DataRow drItem = null;
                    DataTable dtTmp = ((DataView)binItem.DataSource).Table;
                    if (dtTmp.Select("(F_PItemID = '"+strPItemID+"') and F_ItemID = ('"+dr["F_ID"].ToString()+"')").Length > 0)
                    {
                        drItem = ((DataRowView)binItem.Current).Row;
                        if (dr["F_ActuQty"] == DBNull.Value)
                           decMQty = Convert.ToDecimal(dr["F_ActuQty"]) * decQty;
                        else
                           decMQty = 0;

                        drItem["F_Qty"] = decMQty;
                    }
                    else
                    {
                       drItem = ((DataRowView)binItem.AddNew()).Row;
                       drItem["PAid"] = decGID;
                       drItem["F_PItemID"] = strItemID; 
                       drItem["F_ItemID"] = dr["F_ID"]; 
                       drItem["F_ItemName"] = dr["F_Name"];
                       drItem["F_Spec"] = dr["F_Spec"];
                       drItem["F_Unit"] = dr["F_Unit"];
                       drItem["F_DeptID"] = dr["F_DeptID"];
                       drItem["F_ProcessID"] = dr["F_ProcessID"];
                       if (dr["F_ActuQty"] == DBNull.Value)
                          decMQty = 0;
                       else
                          decMQty = Convert.ToDecimal(dr["F_ActuQty"]) * decQty;

                       drItem["F_Qty"] = decMQty;
                    }

                   Expand(dr["F_ID"].ToString(),decMQty);
                }
            }
        }

        protected override void ViewKeyDown(object sender, KeyEventArgs e)
        {
            base.ViewKeyDown(sender, e);
            if (e.KeyCode == Keys.F5)
            {
                //DataLib.sysClass.SaveGridToDB(gvDept, this.Name, 1);
                DataLib.sysClass.SaveGridToDB(gvHalf, this.Name, 1);
                DataLib.sysClass.SaveGridToDB(gvItem, this.Name, 2);
                //this.SaveFieldFormat("1",gvHalf);
                //this.SaveFieldFormat("2",gvItem);
            }

            if (e.KeyCode == Keys.F7)
            {
                if (gvHalf.IsFocusedView)
                    this.SetFormat(gvHalf);

                if (gvItem.IsFocusedView)
                    this.SetFormat(gvItem);
            }
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
           
        }

        private void HalfBtnClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Common.frmSelItem mySelItem = new Common.frmSelItem();
            mySelItem.intTag = 1;
            mySelItem.myBill = this;
            if (mySelItem.ShowDialog() == DialogResult.OK)
            {
                DataRow dr;
                DataRow drCurrent = ((DataRowView)binHalf.Current).Row;
                DataLib.sysClass myClass = new DataLib.sysClass();

                if (mySelItem.TabControl.SelectedTabPageIndex == 0)
                {
                    dr = mySelItem.gvMain.GetDataRow(mySelItem.gvMain.FocusedRowHandle);
                    myClass.GetItem(dr["F_ID"].ToString(), 0, drCurrent, this.Name);
                    gvHalf.UpdateCurrentRow();

                }
                else
                {
                    dr = mySelItem.gvStore.GetDataRow(mySelItem.gvStore.FocusedRowHandle);
                    myClass.GetStoreItem(dr, 0, drCurrent, this.Name);
                    gvHalf.UpdateCurrentRow();
                }
            }
            mySelItem.Dispose();
        }

        private void SlaverBtnClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Common.frmSelItem mySelItem = new Common.frmSelItem();
            mySelItem.myBill = this;
            if (mySelItem.ShowDialog() == DialogResult.OK)
            {
                DataRow dr;
                DataRow drCurrent = ((DataRowView)binItem.Current).Row;
                DataLib.sysClass myClass = new DataLib.sysClass();

                if (mySelItem.TabControl.SelectedTabPageIndex == 0)
                {
                    dr = mySelItem.gvMain.GetDataRow(mySelItem.gvMain.FocusedRowHandle);
                    myClass.GetItem(dr["F_ID"].ToString(), 0, drCurrent, this.Name);
                    gvItem.UpdateCurrentRow();

                }
                else
                {
                    dr = mySelItem.gvStore.GetDataRow(mySelItem.gvStore.FocusedRowHandle);
                    myClass.GetStoreItem(dr, 0, drCurrent, this.Name);
                    gvItem.UpdateCurrentRow();
                }
            }
            mySelItem.Dispose();
        }

        public override void NewBill()
        {
            base.NewBill();
            DataRow dr = ((DataRowView)binMaster.Current).Row;
            dr["F_PatchFinish"] = false;
            dr["F_BackFinish"] = false;
            dr["F_Finish"] = false;
            binMaster.EndEdit();
        }

        public override void BindData()
        {
            base.BindData();
            lbDept.DataBindings.Clear();
            lbDept.DataBindings.Add("Text", binMaster, "F_Dept");

            string strSQL = "";
            
            strSQL = "select * from t_TaskDept where F_BillID = @Value";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsDept = myHelper.GetOtherDs(strSQL, GetParm());
            dsDept.Tables[0].TableNewRow += new DataTableNewRowEventHandler(ItemDeptNewRow);
            dsDept.Tables[0].RowDeleted += new DataRowChangeEventHandler(ItemDeptDelRow);
            binDept.DataSource = dsDept.Tables[0].DefaultView; 
            
            strSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec ";
            strSQL = strSQL + "from t_TaskHalf a,t_Item b ";
            strSQL = strSQL + "where a.F_ItemID = b.F_ID ";
            strSQL = strSQL + "and F_BillID = @Value";

            DataSet dsHalf = myHelper.GetOtherDs(strSQL, GetParm());
            dsHalf.Tables[0].TableNewRow += new DataTableNewRowEventHandler(ItemSlaverNewRow1);
            binHalf.DataSource = dsHalf.Tables[0].DefaultView;
            //DataLib.sysClass.LoadFormatFromDB(gvHalf, this.Name, 1);
            //this.AssignField("1",gvHalf);
            /*
            ds.Tables[0].TableNewRow += new DataTableNewRowEventHandler(SlaverNewRow);
            ds.Tables[0].ColumnChanging += new DataColumnChangeEventHandler(ColumnChanging);
            ds.Tables[0].ColumnChanged += new DataColumnChangeEventHandler(ColumnChanged);
            */

            strSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec ";
            strSQL = strSQL + "from t_TaskItem a,t_Item b ";
            strSQL = strSQL + "where a.F_ItemID = b.F_ID ";
            strSQL = strSQL + "and F_BillID = @Value";

            DataSet dsItem = myHelper.GetOtherDs(strSQL, GetParm());
            binItem.DataSource = dsItem.Tables[0].DefaultView; 
            dsItem.Tables[0].TableNewRow += new DataTableNewRowEventHandler(ItemSlaverNewRow2);
            //DataLib.sysClass.LoadFormatFromDB(gvItem, this.Name, 2);
            //this.AssignField("2",gvItem);
            /*
            ds.Tables[0].TableNewRow += new DataTableNewRowEventHandler(SlaverNewRow);
            ds.Tables[0].ColumnChanging += new DataColumnChangeEventHandler(ColumnChanging);
            ds.Tables[0].ColumnChanged += new DataColumnChangeEventHandler(ColumnChanged);
            */

            DataSet dsDropDept = myHelper.GetDs("select F_ID,F_Name from t_Class where F_ID like '03.%'");
            this.lupDept.DataSource = dsDropDept.Tables[0].DefaultView;
            this.lupDept.DisplayMember = "F_Name";
            this.lupDept.ValueMember = "F_ID";

            FocusedRowChanged(null, null);
        }


        private void ItemDeptNewRow(object Sender, DataTableNewRowEventArgs e)
        {
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            e.Row["F_ItemID"] = dr["F_ItemID"];
        }

        private void ItemDeptDelRow(object Sender,DataRowChangeEventArgs e)
        {

        }
        
        protected virtual void ItemSlaverNewRow1(object Sender, DataTableNewRowEventArgs e)
        {
            DataTable dt = e.Row.Table;
            DataRow dr = e.Row;
            if (dt.Columns.Contains("AID") != false)
                dr["AID"] = binHalf.Count + 1;
        }

        protected virtual void ItemSlaverNewRow2(object Sender, DataTableNewRowEventArgs e)
        {
            DataTable dt = e.Row.Table;
            DataRow dr = e.Row;
            if (dt.Columns.Contains("AID") != false)
                dr["AID"] = binItem.Count + 1;
        }

        private void sbSelDept_Click(object sender, EventArgs e)
        {
            string strID = "", strName = "";
            CommonData.frmSelDept mySelDept = new CommonData.frmSelDept();
            if (mySelDept.ShowDialog() == DialogResult.OK)
            {
                int[] intCnt = mySelDept.gvMain.GetSelectedRows();
                for (int i = 0;i < intCnt.Length;i++)
                {
                    DataRow dr = mySelDept.gvMain.GetDataRow(intCnt[i]);
                    strID = strID + dr["F_ID"].ToString() + ",";
                    strName = strName + dr["F_Name"].ToString() + ",";    
                }
                strID = strID.Remove(strID.Length - 1);
                strName = strName.Remove(strName.Length - 1);
                editDept.SetValue(strID);
                lbDept.Text = strName;
            }
            mySelDept.Dispose();
        }


        protected override void FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvList.FocusedRowHandle < 0) return;
            base.FocusedRowChanged(sender, e);

            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);

            DataView dv = (DataView)binDept.DataSource;
            dv.RowFilter = "F_ItemID = '"+dr["F_ItemID"]+"'";
        }

        private void sbExpand_Click(object sender, EventArgs e)
        {
            if (gvList.RowCount < 0)
            {
                MessageBox.Show(this, "本单不存在产品，不能展开!!", "提示");
                return;
            }

            if (MessageBox.Show(this,"将根据物料清单展开产品用料，耗时取决于产品条目数，你确定进行本步操作吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                ExpandAll();
        }

        private void sbLoadDept_Click(object sender, EventArgs e)
        {
            if (gvList.FocusedRowHandle < 0)
            {
                MessageBox.Show(this,"请选择对应产品!!","提示");
                return;
            }
            if (gvDept.RowCount > 0)
            {
                if (MessageBox.Show(this,"展开将覆盖当前的结果，真的进行此操作吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) return;
            }

            while (binDept.Count > 0)
            {
                binDept.RemoveCurrent();
            }

            string strDept = editDept.GetValue().ToString();
            if (strDept.Length == 0) return;
            string[] aDept = strDept.Split(',');
            foreach(string cDept in aDept)
            {
                DataRow dr = ((DataRowView)binDept.AddNew()).Row;
                dr["F_DeptID"] = cDept;
            }
        }

        protected override bool SavePre()
        {
            if (base.SavePre() == false) return false;

            gvDept.CloseEditor(); 
            int intCnt = gvDept.RowCount;
            for (int i = 0; i < intCnt; i++)
            {
                DataRow dr = gvDept.GetDataRow(i);
                if (dr["F_Begindate"] == DBNull.Value)
                {
                    MessageBox.Show("开始日期不能为空!!", "提示");
                    TabControl.SelectedTabPageIndex = 0;
                    gcDept.Focus();
                    gvDept.FocusedColumn = gvList.Columns.ColumnByFieldName("F_Begindate");
                    gvDept.FocusedRowHandle = i;
                    return false;
                }

                if (dr["F_Enddate"] == DBNull.Value)
                {
                    MessageBox.Show("结束日期不能为空!!", "提示");
                    TabControl.SelectedTabPageIndex = 0;
                    gcDept.Focus();
                    gvDept.FocusedColumn = gvList.Columns.ColumnByFieldName("F_Enddate");
                    gvDept.FocusedRowHandle = i;
                    return false;
                }
            }

            gvHalf.PostEditor();
            gvHalf.CloseEditor();
            intCnt = gvHalf.RowCount;
            for (int i = 0; i < intCnt; i++)
            {
                DataRow dr = gvHalf.GetDataRow(i);
                if (dr["PAid"] == DBNull.Value)
                {
                    MessageBox.Show("半成品页面产品序号不能为空!!", "提示");
                    TabControl.SelectedTabPageIndex = 1;
                    gcHalf.Focus();
                    gvHalf.FocusedColumn = gvList.Columns.ColumnByFieldName("PAid");
                    gvHalf.FocusedRowHandle = i;
                    return false;
                }

                if (dr["F_PItemID"] == DBNull.Value)
                {
                    MessageBox.Show("半成品页面产品编码不能为空!!", "提示");
                    TabControl.SelectedTabPageIndex = 1;
                    gcHalf.Focus();
                    gvHalf.FocusedColumn = gvList.Columns.ColumnByFieldName("F_PItemID");
                    gvHalf.FocusedRowHandle = i;
                    return false;
                }

                if (dr["F_ItemID"] == DBNull.Value)
                {
                    MessageBox.Show("半成品页面半成品编码不能为空!!", "提示");
                    TabControl.SelectedTabPageIndex = 1;
                    gcHalf.Focus();
                    gvHalf.FocusedColumn = gvList.Columns.ColumnByFieldName("F_ItemID");
                    gvHalf.FocusedRowHandle = i;
                    return false;
                }

                if (dr["F_DeptID"] == DBNull.Value)
                {
                    MessageBox.Show("半成品页面部门不能为空!!", "提示");
                    TabControl.SelectedTabPageIndex = 1;
                    gcHalf.Focus();
                    gvHalf.FocusedColumn = gvList.Columns.ColumnByFieldName("F_DeptID");
                    gvHalf.FocusedRowHandle = i;
                    return false;
                }

                if (dr["F_ProcessID"] == DBNull.Value)
                {
                    MessageBox.Show("半成品页面工序不能为空!!", "提示");
                    TabControl.SelectedTabPageIndex = 1;
                    gcHalf.Focus();
                    gvHalf.FocusedColumn = gvList.Columns.ColumnByFieldName("F_ProcessID");
                    gvHalf.FocusedRowHandle = i;
                    return false;
                }

                if (dr["F_Qty"] == DBNull.Value)
                {
                    MessageBox.Show("半成品页面数量不能为空!!", "提示");
                    TabControl.SelectedTabPageIndex = 1;
                    gcHalf.Focus();
                    gvHalf.FocusedColumn = gvList.Columns.ColumnByFieldName("F_Qty");
                    gvHalf.FocusedRowHandle = i;
                    return false;
                }
            }

            intCnt = gvItem.RowCount;
            for (int i = 0; i < intCnt; i++)
            {
                DataRow dr = gvItem.GetDataRow(i);
                if (dr["PAid"] == DBNull.Value)
                {
                    MessageBox.Show("原材料页面产品序号不能为空!!", "提示");
                    TabControl.SelectedTabPageIndex = 2;
                    gcItem.Focus();
                    gvItem.FocusedColumn = gvList.Columns.ColumnByFieldName("PAid");
                    gvItem.FocusedRowHandle = i;
                    return false;
                }

                if (dr["F_PItemID"] == DBNull.Value)
                {
                    MessageBox.Show("原材料页面产品编码不能为空!!", "提示");
                    TabControl.SelectedTabPageIndex = 2;
                    gcItem.Focus();
                    gvItem.FocusedColumn = gvList.Columns.ColumnByFieldName("F_PItemID");
                    gvItem.FocusedRowHandle = i;
                    return false;
                }

                if (dr["F_ItemID"] == DBNull.Value)
                {
                    MessageBox.Show("原材料页面物料编码不能为空!!", "提示");
                    TabControl.SelectedTabPageIndex = 2;
                    gcItem.Focus();
                    gvItem.FocusedColumn = gvList.Columns.ColumnByFieldName("F_ItemID");
                    gvItem.FocusedRowHandle = i;
                    return false;
                }

                if (dr["F_DeptID"] == DBNull.Value)
                {
                    MessageBox.Show("原材料页面部门不能为空!!", "提示");
                    TabControl.SelectedTabPageIndex = 2;
                    gcItem.Focus();
                    gvItem.FocusedColumn = gvList.Columns.ColumnByFieldName("F_DeptID");
                    gvItem.FocusedRowHandle = i;
                    return false;
                }

                if (dr["F_ProcessID"] == DBNull.Value)
                {
                    MessageBox.Show("原材料页面工序不能为空!!", "提示");
                    TabControl.SelectedTabPageIndex = 2;
                    gcItem.Focus();
                    gvItem.FocusedColumn = gvList.Columns.ColumnByFieldName("F_ProcessID");
                    gvItem.FocusedRowHandle = i;
                    return false;
                }

                if (dr["F_Qty"] == DBNull.Value)
                {
                    MessageBox.Show("原材料页面数量不能为空!!", "提示");
                    TabControl.SelectedTabPageIndex = 2;
                    gcItem.Focus();
                    gvItem.FocusedColumn = gvList.Columns.ColumnByFieldName("F_Qty");
                    gvItem.FocusedRowHandle = i;
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 保存半成品
        /// </summary>
        private DataSet SaveHalf(DataSet dsMaster, DataSet dsSlaver, DataSet dsUpdateSlaver,ref string strHalfSQL)
        {
            binHalf.EndEdit();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            strHalfSQL = "select * from t_TaskHalf where F_BillID = @Value";
            DataSet dsUpdateHalf = myHelper.GetOtherDs(strHalfSQL,GetParm());

            foreach (DataRow dr in dsUpdateHalf.Tables[0].Rows)
            {
                dr.Delete();
            }

            DataSet dsHalf = ((DataView)binHalf.DataSource).Table.DataSet;
 
            DataTable dt = dsHalf.Tables[0];

            dt.AcceptChanges();

            foreach (DataRow dr in dt.Rows)
            {
                DataRow drNew = dsUpdateHalf.Tables[0].NewRow();
                int intCnt = dt.Columns.Count;
                for (int i = 0; i < intCnt; i++)
                {
                    
                    if (dt.Columns[i].ColumnName == "F_BillID")
                    {
                        drNew["F_BillID"] = dsMaster.Tables[0].Rows[0]["F_BillID"].ToString();
                    }
                    else
                    {
                        if (dsUpdateHalf.Tables[0].Columns.IndexOf(dt.Columns[i].ColumnName) > 0)
                        {
                            drNew[dt.Columns[i].ColumnName] = dr[dt.Columns[i].ColumnName];
                        }
                    }
                }

                dsUpdateHalf.Tables[0].Rows.Add(drNew);
            }
            return dsUpdateHalf;
        }


        /// <summary>
        /// 保存原材料
        /// </summary>
        private DataSet SaveItem(DataSet dsMaster, DataSet dsSlaver, DataSet dsUpdateSlaver,ref string strItemSQL)
        {

            binItem.EndEdit();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            strItemSQL = "select * from t_TaskItem where F_BillID = @Value";
            DataSet dsUpdateItem = myHelper.GetOtherDs(strItemSQL,GetParm());

            foreach (DataRow dr in dsUpdateItem.Tables[0].Rows)
            {
                dr.Delete();
            }

            DataSet dsItem = ((DataView)binItem.DataSource).Table.DataSet;
 
            DataTable dt = dsItem.Tables[0];
            dt.AcceptChanges();

            foreach (DataRow dr in dt.Rows)
            {
                DataRow drNew = dsUpdateItem.Tables[0].NewRow();
                int intCnt = dt.Columns.Count;
                for (int i = 0; i < intCnt; i++)
                {
                    
                    if (dt.Columns[i].ColumnName == "F_BillID")
                    {
                        drNew["F_BillID"] = dsMaster.Tables[0].Rows[0]["F_BillID"].ToString();
                    }
                    else
                    {
                        if (dsUpdateItem.Tables[0].Columns.IndexOf(dt.Columns[i].ColumnName) > 0)
                        {
                            drNew[dt.Columns[i].ColumnName] = dr[dt.Columns[i].ColumnName];
                        }
                    }
                }

                dsUpdateItem.Tables[0].Rows.Add(drNew);
             }
            return dsUpdateItem;
        }


        /// <summary>
        /// 保存部门
        /// </summary>
        private DataSet SaveDept(DataSet dsMaster, DataSet dsSlaver, DataSet dsUpdateSlaver, ref string strDeptSQL)
        {
            gvDept.PostEditor();
            binDept.EndEdit();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            strDeptSQL = "select * from t_TaskDept where F_BillID = @Value";
            DataSet dsUpdateDept = myHelper.GetOtherDs(strDeptSQL, GetParm());

            foreach (DataRow dr in dsUpdateDept.Tables[0].Rows)
            {
                dr.Delete();
            }

            DataSet dsDept = ((DataView)binDept.DataSource).Table.DataSet;

            DataTable dt = dsDept.Tables[0];
            dt.AcceptChanges();
            foreach (DataRow dr in dt.Rows)
            {
                DataRow drNew = dsUpdateDept.Tables[0].NewRow();
                int intCnt = dt.Columns.Count;
                for (int i = 0; i < intCnt; i++)
                {

                    if (dt.Columns[i].ColumnName == "F_BillID")
                    {
                        drNew["F_BillID"] = dsMaster.Tables[0].Rows[0]["F_BillID"].ToString();
                    }
                    else
                    {
                        if (dsUpdateDept.Tables[0].Columns.IndexOf(dt.Columns[i].ColumnName) > 0)
                        {
                            drNew[dt.Columns[i].ColumnName] = dr[dt.Columns[i].ColumnName];
                        }
                    }
                }

                dsUpdateDept.Tables[0].Rows.Add(drNew);
            }
            return dsUpdateDept;
        }

        protected override bool Save(DataSet dsMaster, DataSet dsSlaver, DataSet dsUpdateSlaver)
        {

            //return base.Save(dsMaster, dsSlaver, dsUpdateSlaver);
            string strHalfSQL = "", strItemSQL = "", strDeptSQL = "";
            DataSet dsUpdateHalf = SaveHalf(dsMaster, dsSlaver, dsUpdateSlaver,ref strHalfSQL);
            DataSet dsUpdateItem = SaveItem(dsMaster, dsSlaver, dsUpdateSlaver,ref strItemSQL);
            DataSet dsUpdateDept = SaveDept(dsMaster, dsSlaver, dsUpdateSlaver, ref strDeptSQL);

            DataSet[] dsData = new DataSet[5];
            dsData[0] = dsMaster;
            dsData[1] = dsUpdateSlaver;
            dsData[2] = dsUpdateHalf;
            dsData[3] = dsUpdateItem;
            dsData[4] = dsUpdateDept;

            string[] strSQL = new string[5];
            strSQL[0] = strMasterSQL;
            strSQL[1] = strSaveSlaverSQL;
            strSQL[2] = strHalfSQL;
            strSQL[3] = strItemSQL;
            strSQL[4] = strDeptSQL;

         
            DataLib.DataHelper myHelper = new DataLib.DataHelper();

            if (myHelper.SaveMuteData1(dsData, strSQL, GetParm()).Length == 0)
            {
                MessageBox.Show("数据保存成功!!", "提示");
                strBillID = editControl1.GetValue().ToString();
                dsMaster.AcceptChanges();
                dsSlaver.AcceptChanges();
                ((DataView)binHalf.DataSource).Table.AcceptChanges();
                ((DataView)binItem.DataSource).Table.AcceptChanges();
                ((DataView)binDept.DataSource).Table.AcceptChanges();
                SetStatus(2);
                return true;
            }
            else
            {
                return false;
            }
         
        }

        private void frmTask_Shown(object sender, EventArgs e)
        {
            strBillFlag = "TK";
            strMTable = "t_Task";
            strMasterSQL = "select * from t_Task where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Material,b.F_Brand,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
            strSlaverSQL = strSlaverSQL + "from t_TaskGoods a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_TaskGoods where F_BillID = @Value";

            if (strBillID == "")
                NewBill();
            else
                BindData();

            //DataLib.sysClass.LoadFormatFromDB(gvDept, this.Name, 1);
            //DataLib.sysClass.LoadFormatFromDB(gvHalf, this.Name, 2);
            //DataLib.sysClass.LoadFormatFromDB(gvItem, this.Name, 3);
            //// SetFieldType(binHalf, gvHalf);
            //// SetFieldType(binItem, gvItem);

            //GridColumn gcHalf = gvHalf.Columns.ColumnByFieldName("F_ItemID");
            //if (gcHalf != null)
            //{
            //    DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            //    gcHalf.ColumnEdit = btn;
            //    btn.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(HalfBtnClick);
            //}

            //GridColumn gcItem = gvItem.Columns.ColumnByFieldName("F_ItemID");
            //if (gcHalf != null)
            //{
            //    DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            //    gcItem.ColumnEdit = btn;
            //    btn.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(SlaverBtnClick);
            //}
        }

        private void TabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == TabHalf && gvHalf.Tag == null)
            {
                GridColumn gcHalf = gvHalf.Columns.ColumnByFieldName("F_ItemID");
                if (gcHalf != null)
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                    gcHalf.ColumnEdit = btn;
                    btn.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(HalfBtnClick);
                }

                gvHalf.Tag = "1";
                
                DataLib.sysClass.LoadFormatFromDB(gvHalf, this.Name, 1);
                SetFieldType(binHalf, gvHalf);
            }

            if (e.Page == TabItem && gvItem.Tag == null)
            {
                GridColumn gcItem = gvItem.Columns.ColumnByFieldName("F_ItemID");
                if (gcItem != null)
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                    gcItem.ColumnEdit = btn;
                    btn.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(SlaverBtnClick);
                }

                gvItem.Tag = "1";
                DataLib.sysClass.LoadFormatFromDB(gvItem, this.Name, 2);
                SetFieldType(binItem, gvItem);
            }

        }

        

    }
}

