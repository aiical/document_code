using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;

namespace Base
{
    public partial class frmStockPrice : Common.frmBaseList
    {
        public frmStockPrice()
        {
            InitializeComponent();
            Point Pos = new Point(checkEdit1.Left, 11);
            checkEdit1.Location = Pos;
            tvType.SendToBack();
            btnEdit.Caption = "保存";
            strTable = "t_PriceStock";
            strKey = "Aid";
            strQuerySQL = "select a.*,b.F_Name as F_Supplier,c.F_Name as F_ItemName,c.F_Spec ";
            strQuerySQL = strQuerySQL + "from t_PriceStock a ";
            strQuerySQL = strQuerySQL + "left join t_Supplier b ";
            strQuerySQL = strQuerySQL + "on a.F_SupplierID = b.F_ID ";
            strQuerySQL = strQuerySQL + "left join t_Item c ";
            strQuerySQL = strQuerySQL + "on a.F_ItemID = c.F_ID ";
            strQuerySQL = strQuerySQL + "where (a.F_SupplierID like @Value or @Value = '')";
            
        }

        private void SetFieldType()
        {
             GridColumn gcItem = gvBase.Columns.ColumnByFieldName("F_ItemID");
             if (gcItem != null)
             {
                 DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                 gcItem.ColumnEdit = btn;
                 btn.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(ItemBtnClick);
              }

             GridColumn gcSupplier = gvBase.Columns.ColumnByFieldName("F_SupplierID");
             if (gcSupplier != null)
             {
                 DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btn = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                 gcSupplier.ColumnEdit = btn;
                 btn.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(SupplierBtnClick);
              }
        }

        protected void ItemBtnClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Common.frmSelItem mySelItem = new Common.frmSelItem();
            if (mySelItem.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = mySelItem.gvMain.GetDataRow(mySelItem.gvMain.FocusedRowHandle);
                DataRow drDes = gvBase.GetDataRow(gvBase.FocusedRowHandle);
                drDes["F_ItemID"] = dr["F_ID"];
                drDes["F_ItemName"] = dr["F_Name"];
                drDes["F_Spec"] = dr["F_Spec"];
                drDes["F_Unit"] = dr["F_Unit"];
                drDes["F_Price"] = dr["F_StockPrice"];
                gvBase.UpdateCurrentRow();
            }
            mySelItem.Dispose();
        }

        protected void SupplierBtnClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {      
            string strSQL = "select F_ID,F_Name from t_Supplier";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
             
            myControl.frmDataList myDataList = new myControl.frmDataList();

            myDataList.gcQuery.DataSource = ds.Tables[0].DefaultView;
            myDataList.keyField = "F_ID";
            myDataList.DisplayField = "F_Name";
            myDataList.gvQuery.Columns.ColumnByFieldName("F_ID").Caption = "编码";
            myDataList.gvQuery.Columns.ColumnByFieldName("F_ID").Width = 100;
            myDataList.gvQuery.Columns.ColumnByFieldName("F_Name").Caption = "名称";
            myDataList.gvQuery.Columns.ColumnByFieldName("F_Name").Width = 150;
               
            if (myDataList.ShowDialog() == DialogResult.OK)
            {
                DataRow dr = myDataList.gvQuery.GetDataRow(myDataList.gvQuery.FocusedRowHandle);
                DataRow drDes = gvBase.GetDataRow(gvBase.FocusedRowHandle);
                drDes["F_SupplierID"] = dr["F_ID"];
                drDes["F_Supplier"] = dr["F_Name"];
                gvBase.UpdateCurrentRow();
            }
            myDataList.Dispose();
        }


        private void SetDispTitle(int intType)
        {
            if (intType == 0)
            {
                this.gvBase.Columns.ColumnByFieldName("Aid").Visible = false;
                this.gvBase.Columns.ColumnByFieldName("f_EvaBeginDate").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("f_EvaBeginDate").VisibleIndex = 1;
                this.gvBase.Columns.ColumnByFieldName("f_EvaBeginDate").OptionsColumn.AllowEdit = true;
                this.gvBase.Columns.ColumnByFieldName("f_EvaEndDate").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("f_EvaEndDate").VisibleIndex = 2;
                this.gvBase.Columns.ColumnByFieldName("f_EvaEndDate").OptionsColumn.AllowEdit = true;
                this.gvBase.Columns.ColumnByFieldName("F_SupplierID").Visible = false;
                this.gvBase.Columns.ColumnByFieldName("F_Supplier").Visible = false;
                this.gvBase.Columns.ColumnByFieldName("F_ItemID").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_ItemID").VisibleIndex = 3;
                this.gvBase.Columns.ColumnByFieldName("F_ItemID").OptionsColumn.AllowEdit = true;
                this.gvBase.Columns.ColumnByFieldName("F_ItemName").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_ItemName").VisibleIndex = 4;
                this.gvBase.Columns.ColumnByFieldName("F_Spec").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_Spec").VisibleIndex = 5;
                this.gvBase.Columns.ColumnByFieldName("F_Unit").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_Unit").VisibleIndex = 6;
                this.gvBase.Columns.ColumnByFieldName("F_Price").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_Price").VisibleIndex = 7;
                this.gvBase.Columns.ColumnByFieldName("F_Price").OptionsColumn.AllowEdit = true;
                this.gvBase.Columns.ColumnByFieldName("F_QtyMin").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_QtyMin").VisibleIndex = 8;
                this.gvBase.Columns.ColumnByFieldName("F_QtyMin").OptionsColumn.AllowEdit = true;
                this.gvBase.Columns.ColumnByFieldName("F_QtyMax").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_QtyMin").VisibleIndex = 9;
                this.gvBase.Columns.ColumnByFieldName("F_QtyMax").OptionsColumn.AllowEdit = true;
                this.gvBase.Columns.ColumnByFieldName("F_Flag").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_Flag").VisibleIndex = 10;
                this.gvBase.Columns.ColumnByFieldName("F_Flag").OptionsColumn.AllowEdit = true;
                this.gvBase.Columns.ColumnByFieldName("F_Remark").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_Remark").VisibleIndex = 11;
                this.gvBase.Columns.ColumnByFieldName("F_Remark").OptionsColumn.AllowEdit = true;
            }
            else
            {
                this.gvBase.Columns.ColumnByFieldName("Aid").Visible = false;
                this.gvBase.Columns.ColumnByFieldName("f_EvaBeginDate").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("f_EvaBeginDate").OptionsColumn.AllowEdit = true;
                this.gvBase.Columns.ColumnByFieldName("f_EvaEndDate").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("f_EvaEndDate").OptionsColumn.AllowEdit = true;
                this.gvBase.Columns.ColumnByFieldName("F_SupplierID").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_SupplierID").OptionsColumn.AllowEdit = true;
                this.gvBase.Columns.ColumnByFieldName("F_Supplier").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_ItemID").Visible = false;
                this.gvBase.Columns.ColumnByFieldName("F_ItemName").Visible = false;
                this.gvBase.Columns.ColumnByFieldName("F_Spec").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_Unit").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_Price").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_Price").OptionsColumn.AllowEdit = true;
                this.gvBase.Columns.ColumnByFieldName("F_QtyMin").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_QtyMin").OptionsColumn.AllowEdit = true;
                this.gvBase.Columns.ColumnByFieldName("F_QtyMax").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_QtyMax").OptionsColumn.AllowEdit = true;
                this.gvBase.Columns.ColumnByFieldName("F_Flag").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_Flag").OptionsColumn.AllowEdit = true;
                this.gvBase.Columns.ColumnByFieldName("F_Remark").Visible = true;
                this.gvBase.Columns.ColumnByFieldName("F_Remark").OptionsColumn.AllowEdit = true;
            }
        }

        protected override void New()
        {
            base.New();
            DataSet ds = null;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (cbType.SelectedIndex == 0)
            {
                ds = myHelper.GetDs("select F_ID,F_Name from t_Supplier where F_ID = '" + tvType.SelectedNode.Tag + "'");
            }
            else
            {
                ds = myHelper.GetDs("select F_ID,F_Name from t_Item where F_ID = '" + tvType.SelectedNode.Tag + "'");
            }
            
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(this,"不能在本级增加明细!!","提示");
                return;
            }
            this.gvBase.AddNewRow();
        }

        protected override void Edit()
        {
            //if (gvBase.FocusedRowHandle < 0) return;
            //base.Edit();
            gvBase.PostEditor();
            DataSet ds = ((DataView)gcBase.DataSource).Table.DataSet;
            //ds.AcceptChanges();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["F_EvaBeginDate"] == DBNull.Value)
                {
                    MessageBox.Show(this, "有效开始日期不能为空!!", "提示");
                    return;
                }

                if (dr["F_EvaEndDate"] == DBNull.Value)
                {
                    MessageBox.Show(this, "有效结束日期不能为空!!", "提示");
                    return;
                }


                if (dr["F_SupplierID"] == DBNull.Value)
                {
                    MessageBox.Show(this, "供应商不能为空!!", "提示");
                    return;
                }


                if (dr["F_ItemID"] == DBNull.Value)
                {
                    MessageBox.Show(this, "物料不能为空!!", "提示");
                    return;
                }


                if (dr["F_QtyMin"] == DBNull.Value)
                {
                    MessageBox.Show(this, "开始数量不能为空!!", "提示");
                    return;
                }

                if (dr["F_QtyMax"] == DBNull.Value)
                {
                    MessageBox.Show(this, "结束数量不能为空!!", "提示");
                    return;
                }

                if (Convert.ToDecimal(dr["F_QtyMin"]) < Convert.ToDecimal(dr["F_QtyMin"]))
                {
                    MessageBox.Show(this, "开始数量不能大于结束数量!!", "提示");
                    return;
                }
            }

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            
            if (myHelper.SaveData(ds, "select * from t_PriceStock") == 0)
            {
                MessageBox.Show(this,"数据保存成功!!","提示");
                ds.AcceptChanges();
            }

        }

        protected override void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_PriceStock where Aid = '"+dr["Aid"].ToString()+"'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);
                   
        }


        /// <summary>
        /// 展开供应商
        /// </summary>
        protected void FillSupplier(string strType,TreeNode ParentNode)
        {
            TreeNode Node = null;
            if (ParentNode == null)
            {
                ParentNode = tvType.Nodes.Add("", "所有类别", 0);
                ParentNode.Tag = strType;
            }

            string strSQL = "select F_ID,F_Name from t_Class where F_UPID = '" + strType + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Node = ParentNode.Nodes.Add(dr["F_ID"].ToString(), dr["F_ID"].ToString()+" ("+dr["F_Name"].ToString()+")", 0);
                Node.Tag = dr["F_ID"].ToString();

                string strCSQL = "select F_ID,F_Name from t_Supplier where F_Type = '"+dr["F_ID"].ToString()+"'";
                DataSet dsChild = myHelper.GetDs(strCSQL);
                foreach (DataRow drChild in dsChild.Tables[0].Rows)
                {
                    TreeNode CNode = Node.Nodes.Add(drChild["F_ID"].ToString(),drChild["F_ID"].ToString()+" ("+drChild["F_Name"].ToString()+")", 0);
                    CNode.Tag = drChild["F_ID"].ToString();
                }

                FillSupplier(dr["F_ID"].ToString(), Node);
            }
        }


        /// <summary>
        /// 展开物料
        /// </summary>
        protected void FillItem(string strType,TreeNode ParentNode)
        {
           
            TreeNode Node = null;
            if (ParentNode == null)
            {
                ParentNode = tvType.Nodes.Add("", "所有类别", 0);
                ParentNode.Tag = strType;
            }
            string strSQL = "select F_ID,F_Name from t_Class where F_UPID = '" + strType + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Node = ParentNode.Nodes.Add(dr["F_ID"].ToString(), dr["F_ID"].ToString()+" ("+dr["F_Name"].ToString()+")", 0);
                Node.Tag = dr["F_ID"].ToString();
                string strCSQL = "select F_ID,F_Name from t_Item where F_Type = '"+dr["F_ID"].ToString()+"'";
                DataSet dsChild = myHelper.GetDs(strCSQL);
                foreach (DataRow drChild in dsChild.Tables[0].Rows)
                {
                    TreeNode CNode = Node.Nodes.Add(drChild["F_ID"].ToString(),drChild["F_ID"].ToString()+" ("+drChild["F_Name"].ToString()+")", 0);
                    CNode.Tag = drChild["F_ID"].ToString();
                }
                FillItem(dr["F_ID"].ToString(), Node);
            }
        }

       
        private void frmClient_Load(object sender, EventArgs e)
        {
            gvBase.OptionsBehavior.Editable = true;
            gvBase.OptionsSelection.EnableAppearanceFocusedCell = true;
            gvBase.OptionsNavigation.EnterMoveNextColumn = true;
            FillSupplier("01", null);
            tvType.TopNode.Expand();
            tvType.SelectedNode = tvType.TopNode;
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tvType.Nodes.Clear();
            if(cbType.SelectedIndex == 0)
            {
                FillSupplier("01", null);
                strQuerySQL = "select a.*,b.F_Name as F_Supplier,c.F_Name as F_ItemName,c.F_Spec ";
                strQuerySQL = strQuerySQL + "from t_PriceStock a ";
                strQuerySQL = strQuerySQL + "left join t_Supplier b ";
                strQuerySQL = strQuerySQL + "on a.F_SupplierID = b.F_ID ";
                strQuerySQL = strQuerySQL + "left join t_Item c ";
                strQuerySQL = strQuerySQL + "on a.F_ItemID = c.F_ID ";
                strQuerySQL = strQuerySQL + "where (a.F_SupplierID = @Value or @Value = '')";
            }
            else
            {
                FillItem("04", null);
                strQuerySQL = "select a.*,b.F_Name as F_Supplier,c.F_Name as F_ItemName,c.F_Spec ";
                strQuerySQL = strQuerySQL + "from t_PriceStock a ";
                strQuerySQL = strQuerySQL + "left join t_Supplier b ";
                strQuerySQL = strQuerySQL + "on a.F_SupplierID = b.F_ID ";
                strQuerySQL = strQuerySQL + "left join t_Item c ";
                strQuerySQL = strQuerySQL + "on a.F_ItemID = c.F_ID ";
                strQuerySQL = strQuerySQL + "where (a.F_ItemID = @Value or @Value = '')";
            }
            tvType.TopNode.Expand();
            tvType.SelectedNode = tvType.TopNode;
            SetDispTitle(cbType.SelectedIndex);
            
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
               tvType.ExpandAll();
        }

        private void frmStockPrice_Shown(object sender, EventArgs e)
        {
            SetDispTitle(cbType.SelectedIndex);
            SetFieldType();
        }

        /// <summary>
        /// 增行事件
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected virtual void SlaverNewRow(object Sender, DataTableNewRowEventArgs e)
        {

            DataSet ds;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            //DataSet dsMax = myHelper.GetDs("select isnull(max(Aid),0)+1 as MaxID from t_PriceStock");

            //e.Row["Aid"] = Convert.ToDecimal(dsMax.Tables[0].Rows[0][0]);
            e.Row["F_Flag"] = true;
            if (cbType.SelectedIndex == 0)
            {
               
                ds = myHelper.GetDs("select F_ID,F_Name from t_Supplier where F_ID = '"+tvType.SelectedNode.Tag+"'");
                e.Row["F_SupplierID"] = ds.Tables[0].Rows[0]["F_ID"];
                e.Row["F_Supplier"] = ds.Tables[0].Rows[0]["F_Name"];
            }
            else
            {
                ds = myHelper.GetDs("select a.F_ID,a.F_Name,a.F_Spec,b.F_Name as F_Unit,F_StockPrice from t_Item a,t_Unit b where a.F_ID = b.F_ItemID and b.F_Main = 1 and a.F_ID = '"+tvType.SelectedNode.Tag+"'");
                e.Row["F_ItemID"] = ds.Tables[0].Rows[0]["F_ID"];
                e.Row["F_ItemName"] = ds.Tables[0].Rows[0]["F_Name"];
                e.Row["F_Spec"] = ds.Tables[0].Rows[0]["F_Spec"];
                e.Row["F_Unit"] = ds.Tables[0].Rows[0]["F_Unit"];
                e.Row["F_Price"] = ds.Tables[0].Rows[0]["F_StockPrice"];
            }
        }

        private void tvType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DataTable dt = ((DataView)this.gcBase.DataSource).Table;
            dt.TableNewRow += new DataTableNewRowEventHandler(SlaverNewRow);
            //dt.ColumnChanging += new DataColumnChangeEventHandler(ColumnChanging);
            //dt.ColumnChanged += new DataColumnChangeEventHandler(ColumnChanged);
        }
    }
}

