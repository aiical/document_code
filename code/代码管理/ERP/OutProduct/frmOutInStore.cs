using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OutProduct
{
    public partial class frmOutInStore : Common.frmBill
    {
        public frmOutInStore()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N41")) bMultCheck = true;
            btnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnUnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        protected override void LoadBill()
        {
            if (DataLib.SysVar.GetParmValue("F_N44"))
            {
                if (lupControl1.GetValue() == DBNull.Value)
                {
                    MessageBox.Show("请选择委外厂商!!", "提示");
                    lupControl1.Focus();
                    return;
                }
                this.strValue = lupControl1.GetValue().ToString();
            }
            base.LoadBill();
        }

        private void SetDropSource()
        {
            string strSQL = "";
            DataSet ds = null;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            strSQL = strSQL = "select F_ID,F_Name from t_OutSupplier";
            ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
            ds.Dispose();
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
           
        }

        private void frmOutInStore_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode == true) return;
            strBillFlag = "OS";
            strMTable = "t_OutInStore";
            strMasterSQL = "select * from t_OutInStore where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Material,b.F_Brand,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
            strSlaverSQL = strSlaverSQL + "from t_OutInStoreDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = '" + strBillID + "'";

            strSaveSlaverSQL = "select * from t_OutInStoreDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
                BindData();
        }


    }
}

