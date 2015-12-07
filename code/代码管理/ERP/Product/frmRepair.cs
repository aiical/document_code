using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;

namespace Product
{
    public partial class frmRepair : Common.frmBill
    {
        public frmRepair()
        {
            InitializeComponent();
            btnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnUnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            Common.XtraChinese p = new Common.XtraChinese();
            p.chineseXtraGrid(this.gcItem);
            gcBill.Parent = PageGoods;
        }

        public override void NewBill()
        {
            base.NewBill();
            DataRow dr = ((DataRowView)binMaster.Current).Row;
            dr["F_Type"] = "配零件";
            binMaster.EndEdit();
        }


        protected virtual void ItemSlaverNewRow(object Sender, DataTableNewRowEventArgs e)
        {
            DataTable dt = e.Row.Table;
            DataRow dr = e.Row;
            if (dt.Columns.Contains("AID") != false)
                dr["AID"] = binItem.Count + 1;
        }

        private void SetDropSource()
        {
            string strSQL = "";
            DataSet ds = null;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            strSQL = strSQL = "select F_ID,F_Name from t_Client";
            ds = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";
            ds.Dispose();
        }


        private void frmStockOrder_Load(object sender, EventArgs e)
        {
           

        }

        private void ItemBtnClick1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Common.frmSelItem mySelItem = new Common.frmSelItem();

            if (mySelItem.ShowDialog() == DialogResult.OK)
            {
                if (mySelItem.gvMain.FocusedRowHandle >= 0)
                {
                    DataRow dr;

                    if (mySelItem.TabControl.SelectedTabPageIndex == 0)
                        dr = mySelItem.gvMain.GetDataRow(mySelItem.gvMain.FocusedRowHandle);
                    else
                        dr = mySelItem.gvStore.GetDataRow(mySelItem.gvStore.FocusedRowHandle);
                     DataLib.sysClass myClass = new DataLib.sysClass();                   
                     DataRow drTmp = myClass.FindItem(dr["F_ID"].ToString());

                     if (drTmp == null) return;

                     DataRow drItem = ((DataRowView)binItem.Current).Row;

                     drItem["F_ItemID"] = drTmp["F_ID"];
                     drItem["F_ItemName"] = drTmp["F_Name"];
                     drItem["F_Spec"] = drTmp["F_Spec"];
                     drItem["F_Brand"] = drTmp["F_Brand"];
                     drItem["F_Material"] = drTmp["F_Material"];
                     drItem["F_Type"] = drTmp["F_TypeName"];
                     drItem["F_Unit"] = drTmp["F_Unit"];
                     binItem.EndEdit();
                }
            }
            mySelItem.Dispose();
        }

        protected override void ViewKeyDown(object sender, KeyEventArgs e)
        {
            base.ViewKeyDown(sender, e);
            if (e.KeyCode == Keys.F5)
            {
                DataLib.sysClass.SaveGridToDB(gvItem, this.Name, 1);
                //this.SaveFieldFormat("1",gvItem);
            }

            if (e.KeyCode == Keys.F7)
            {
                if (gvItem.IsFocusedView)
                    this.SetFormat(gvItem);
            }
        }

        public override void BindData()
        {
            base.BindData();
            string strSQL = "";
            strSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Material,b.F_Brand,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
            strSQL = strSQL + "from t_RepairItem a,t_Item b ";
            strSQL = strSQL + "where a.F_ItemID = b.F_ID ";
            strSQL = strSQL + "and F_BillID = @Value";
     
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsItem = myHelper.GetOtherDs(strSQL, GetParm());
            dsItem.Tables[0].TableNewRow += new DataTableNewRowEventHandler(ItemSlaverNewRow);
            binItem.DataSource = dsItem.Tables[0].DefaultView;
            gcItem.DataSource = binItem;
            gvItem.OptionsBehavior.Editable = gvList.OptionsBehavior.Editable;
        }

         private void SetItemID()
        {
            int intCnt = gvItem.RowCount;
            gvItem.BeginUpdate();
            for (int i = 0; i < intCnt; i++)
            {
                gvItem.SetRowCellValue(i, "Aid", i + 1);
            }
            gvItem.EndUpdate();
            binItem.EndEdit();
        }

        protected override void DelRow()
        {
            //base.DelRow();

            if (this.TabControl.SelectedTabPage == this.PageGoods)
            {
               if (gvList.FocusedRowHandle < 0) return;
                  binSlaver.RemoveCurrent();
               SetAutoID();
            }
            else
            {
               if (gvList.FocusedRowHandle < 0) return;
                  binSlaver.RemoveCurrent();
                SetItemID();
            }
            
        }

        protected override void AddRow()
        {
            //base.AddRow();
            if (this.TabControl.SelectedTabPage == this.PageGoods)
            {
                binSlaver.AddNew();
                DataTable dt = ((DataView)binSlaver.DataSource).Table;
                if (dt.Columns.Contains("F_ItemID")  != false)
                    gvList.FocusedColumn = gvList.Columns.ColumnByFieldName("F_ItemID");
            }
            else
            {
                binItem.AddNew();
                DataTable dt = ((DataView)binItem.DataSource).Table;
                if (dt.Columns.Contains("F_ItemID")  != false)
                    gvItem.FocusedColumn = gvItem.Columns.ColumnByFieldName("F_ItemID");
            }   

        }

        protected override bool Save(DataSet dsMaster, DataSet dsSlaver, DataSet dsUpdateSlaver)
        {
            //return base.Save(dsMaster, dsSlaver, dsUpdateSlaver);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            string strItemSQL = "select * from t_RepairItem where F_BillID = @Value";
            DataSet dsUpdateItem = myHelper.GetOtherDs(strItemSQL,GetParm());

            foreach (DataRow dr in dsUpdateItem.Tables[0].Rows)
            {
                dr.Delete();
            }

            DataSet dsItem = ((DataView)binItem.DataSource).Table.DataSet;
 
            DataTable dt = dsItem.Tables[0];

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


         DataSet[] dsData = new DataSet[3];
         dsData[0] = dsMaster;
         dsData[1] = dsUpdateSlaver;
         dsData[2] = dsUpdateItem;

         string[] strSQL = new string[3];
         strSQL[0] = strMasterSQL;
         strSQL[1] = strSaveSlaverSQL;
         strSQL[2] = strItemSQL;

         
         if (myHelper.SaveMuteData1(dsData, strSQL, GetParm()).Length == 0)
         {
             MessageBox.Show("数据保存成功!!", "提示");
             strBillID = editControl1.GetValue().ToString();
             dsMaster.AcceptChanges();
             dsSlaver.AcceptChanges();
             dsItem.AcceptChanges();
             SetStatus(2);
             return true;
         }
         else
         {
             return false;
         }
        }

        private void frmOutBill_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode == true) return;
            strBillFlag = "RP";
            strMTable = "t_Repair";
            strMasterSQL = "select * from t_Repair where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Material,b.F_Brand,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
            strSlaverSQL = strSlaverSQL + "from t_RepairDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_RepairDetail where F_BillID = @Value";

            SetDropSource();


            if (strBillID == "")
                NewBill();
            else
                BindData();

            //DataLib.sysClass.LoadFormatFromDB(gvItem, this.Name, 1);
        }

        private void FillItem()
        {
            
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbItem = null;
            GridColumn gcItem = gvItem.Columns.ColumnByFieldName("F_PItemID");
            if (gcItem.ColumnEdit == null)
            {
                cbItem = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                gcItem.ColumnEdit = cbItem;
            }
            else
                cbItem = (DevExpress.XtraEditors.Repository.RepositoryItemComboBox)gcItem.ColumnEdit;

            cbItem.Items.Clear();
            int iCnt = gvList.RowCount;
            for (int i = 0; i < iCnt; i++)
            {
                if (gvList.GetRowCellValue(i, "F_ItemID") != DBNull.Value)
                   cbItem.Items.Add(gvList.GetRowCellValue(i, "F_ItemID"));
            }
            
        }

        private void TabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == PageItem && gvItem.Tag == null)
            {

                GridColumn gcItem = gvItem.Columns.ColumnByFieldName("F_ItemID");
                if (gcItem != null)
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                    gcItem.ColumnEdit = btn;
                    btn.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(ItemBtnClick1);
                }
                
                gvItem.Tag = "1";
                DataLib.sysClass.LoadFormatFromDB(gvItem, this.Name, 1);
                SetFieldType(binItem, gvItem);
            }
            FillItem();
        }

        private void dateControl1_Load(object sender, EventArgs e)
        {

        }

    }
}

