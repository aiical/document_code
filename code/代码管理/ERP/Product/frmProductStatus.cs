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
    public partial class frmProductStatus : Common.frmBill
    {
        public frmProductStatus()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N33")) bMultCheck = true;
        }

        private void SetDropSource()
        {
            string strSQL = "";
            DataSet ds = null;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            strSQL = strSQL = "select F_BillID,F_Date,F_BillMan,F_CheckMan,F_CheckDate from t_Task";
            ds = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_BillID";
            lupControl2.LookUpKeyField = "F_BillID";
            ds.Dispose();

        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
           
        }

        private void GroupBtnClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CommonData.frmSelGroup mySelGroup = new CommonData.frmSelGroup();
            if (mySelGroup.ShowDialog() == DialogResult.OK)
            {
                DataRow drDes = gvList.GetDataRow(gvList.FocusedRowHandle);
                DataRow drSource = mySelGroup.gvMain.GetDataRow(mySelGroup.gvMain.FocusedRowHandle);
                drDes["F_GroupID"] = drSource["F_ID"];
                gvList.UpdateCurrentRow();
            }
            mySelGroup.Dispose();
        }

        private void ManBtnClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            CommonData.frmSelEmp mySelEmp = new CommonData.frmSelEmp();
            DataRow drDes = gvList.GetDataRow(gvList.FocusedRowHandle);
            mySelEmp.strDept = drDes["F_DeptID"].ToString();
            if (mySelEmp.ShowDialog() == DialogResult.OK)
            {
                
                DataRow drSource = mySelEmp.gvMain.GetDataRow(mySelEmp.gvMain.FocusedRowHandle);
                drDes["F_Man"] = drSource["F_ID"];
                gvList.UpdateCurrentRow();
            }
            mySelEmp.Dispose();
        }

        public override void NewBill()
        {
            base.NewBill();
            DataRow dr = ((DataRowView)binMaster.Current).Row;
            dr["F_Type"] = "Õý³£µ¥";
            binMaster.EndEdit();
        }

        private void sbFetch_Click(object sender, EventArgs e)
        {
            if (lupControl2.GetValue() == DBNull.Value) return;
            frmGetProductProcess myGetProductProcess = new frmGetProductProcess();
            myGetProductProcess.binDes = this.binSlaver;
            myGetProductProcess.DataBind(lupControl2.GetValue().ToString(),cbControl1.GetValue().ToString());
            myGetProductProcess.ShowDialog();
            myGetProductProcess.Dispose();
        }

        private void frmProductStatus_Shown(object sender, EventArgs e)
        {
            strBillFlag = "PS";
            strMTable = "t_ProductStatus";
            strMasterSQL = "select * from t_ProductStatus where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Brand,b.F_Material ";
            strSlaverSQL = strSlaverSQL + "from t_ProductStatusDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_ProductStatusDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
                BindData();

            GridColumn gcGroup = gvList.Columns.ColumnByFieldName("F_GroupID");
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnGroup = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            gcGroup.ColumnEdit = btnGroup;
            btnGroup.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(GroupBtnClick);

            GridColumn gcEmp = gvList.Columns.ColumnByFieldName("F_Man");
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnMan = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            gcEmp.ColumnEdit = btnMan;
            btnMan.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(ManBtnClick);
        }

    }
}

