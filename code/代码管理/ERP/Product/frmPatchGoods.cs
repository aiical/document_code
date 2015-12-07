using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Product
{
    public partial class frmPatchGoods : Common.frmBill
    {
        public frmPatchGoods()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N35")) bMultCheck = true;
        }

        
        protected override void LoadBill()
        {
            if (lupControl2.GetValue() == DBNull.Value)
            {
                MessageBox.Show("请选择部门!!", "提示");
                lupControl2.Focus();
                return;
            }
            this.blnSlaverFlag = true;
            this.strValue = lupControl2.GetValue().ToString();
            base.LoadBill();
        }

        private void SetDropSource()
        {
            string strSQL = "";
            DataSet ds = null;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            strSQL = strSQL = "select F_ID,F_Name from t_Class where left(F_UPID,2) like '03%'";
            ds = myHelper.GetDs(strSQL);
            lupControl2.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl2.LookUpDisplayField = "F_Name";
            lupControl2.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = strSQL = "select F_ID,F_Name from t_Emp";
            ds = myHelper.GetDs(strSQL);
            lupControl3.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl3.LookUpDisplayField = "F_Name";
            lupControl3.LookUpKeyField = "F_ID";
            ds.Dispose();
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
           
        }


        public override void NewBill()
        {
            base.NewBill();
            DataRow dr = ((DataRowView)binMaster.Current).Row;
            dr["F_Kind"] = "正常补料";
            binMaster.EndEdit();
        }

        private void frmPatchGoods_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode == true) return;
            strBillFlag = "PG";
            strMTable = "t_PatchGoods";
            strMasterSQL = "select * from t_PatchGoods where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Material,b.F_Brand,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
            strSlaverSQL = strSlaverSQL + "from t_PatchGoodsDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_PatchGoodsDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
                BindData();
        }

    }
}

