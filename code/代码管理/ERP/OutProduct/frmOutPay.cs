using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OutProduct
{
    public partial class frmOutPay : Common.frmBill
    {
        public frmOutPay()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N43")) bMultCheck = true;
            blnBarCode = false;
            barMemo.Caption = "";
            this.btnLoadBill.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.btnAddRow.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnBalance.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        public override void NewBill()
        {
            base.NewBill();
            DataRow dr = ((DataRowView)binMaster.Current).Row;
            dr["F_PayMode"] = "现金";
            binMaster.EndEdit();
        }

        protected override bool GenBalance()
        {
            if (base.GenBalance() == false) return false;
            Finance.frmCertificate myCertificate = new Finance.frmCertificate();
            myCertificate.dtDes = ((DataView)binMaster.DataSource).Table;
            myCertificate.DataBind();
            myCertificate.GenCertificate(7);
            myCertificate.ShowDialog();
            myCertificate.Dispose();
            return true;
        }

        protected override void LoadBill()
        {
            if (lupControl1.GetValue() == DBNull.Value)
            {
                MessageBox.Show("请选择厂商!!", "提示");
                lupControl1.Focus();
                return;
            }
            this.strValue = lupControl1.GetValue().ToString();
            frmOutPayImport myOutPayImport = new frmOutPayImport();
            myOutPayImport.dtDes = ((DataView)binSlaver.DataSource).Table;
            myOutPayImport.strValue = this.strValue;
            myOutPayImport.ShowDialog();
            myOutPayImport.Dispose();
            //base.LoadBill();
        }

        private void SetDropSource()
        {
            string strSQL = "select F_ID,F_Name from t_OutSupplier";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
            ds.Dispose();

            strSQL = "select * from t_assist where F_Type = '收付款方式'";
            ds = myHelper.GetDs(strSQL);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbControl2.AddItem(dr["F_Name"]);
            }
            ds.Dispose();
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
           
        }


        /// <summary>
        /// 自动付款 
        /// </summary>
        private void Auto()
        {
            int intCnt = gvList.RowCount;
            for (int i = 0; i < intCnt; i++)
            {
                DataRow dr = gvList.GetDataRow(i);
                dr["F_ThisMoney"] = dr["F_NoMoney"];
                dr["F_Flag"] = true;
                dr.EndEdit();
            }
        }


        protected override void CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.CellValueChanging(sender, e);
            if (e.Column.FieldName == "F_Flag")
            {
                DataRow dr = gvList.GetDataRow(e.RowHandle);
                dr.BeginEdit();
                if (Convert.ToBoolean(e.Value) == true)
                    dr["F_ThisMoney"] = gvList.GetRowCellValue(e.RowHandle, "F_NoMoney");
                else
                    dr["F_ThisMoney"] = 0;
                dr.EndEdit();
                gvList.PostEditor();
            }
        }

        protected override void CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            base.CellValueChanged(sender, e);
            
            if (e.Column.FieldName == "F_ThisMoney")
            {

                DataRow dr = gvList.GetDataRow(e.RowHandle);
                dr.BeginEdit();

                if (e.Value == DBNull.Value)
                    dr["F_Flag"] = false;
                else
                    if (Convert.ToDecimal(e.Value) == 0)
                        dr["F_Flag"] = false;
                    else
                        dr["F_Flag"] = true;
                dr.EndEdit();
            }     
        }

        private void sbAuto_Click(object sender, EventArgs e)
        {
            Auto();
        }

        private void frmOutPay_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode == true) return;
            strBillFlag = "OP";
            strMTable = "t_OutPay";
            strMasterSQL = "select * from t_OutPay where F_BillID = @Value";

            strSlaverSQL = "select * from t_OutPayDetail ";
            strSlaverSQL = strSlaverSQL + "where F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_OutPayDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
                BindData();
        }

    }
}

