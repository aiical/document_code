using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmProductProcess : Common.frmBill
    {
        public frmProductProcess()
        {
            InitializeComponent();
        }

        private void SetDropSource()
        {
            string strSQL = "";
            DataSet ds = null;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            strSQL = strSQL = "select F_ID,F_Name from t_Craftwork";
            ds = myHelper.GetDs(strSQL);
            lupControl1.LookUpDataSource = ds.Tables[0].DefaultView;
            lupControl1.LookUpDisplayField = "F_Name";
            lupControl1.LookUpKeyField = "F_ID";
            ds.Dispose();
        }
        protected override void SlaverNewRow(object Sender, DataTableNewRowEventArgs e)
        {
            base.SlaverNewRow(Sender, e);
            DataRow dr = e.Row;
            dr["F_LastProcess"] = false;
        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
            
        }

        private void sbSelItem_Click(object sender, EventArgs e)
        {
            Common.frmSelItem mySelItem = new Common.frmSelItem();
            mySelItem.intTag = 1;
            if (mySelItem.ShowDialog() == DialogResult.OK)
            {
                if (mySelItem.gvMain.FocusedRowHandle >= 0)
                {
                    DataRow dr = mySelItem.gvMain.GetDataRow(mySelItem.gvMain.FocusedRowHandle);
                    DataLib.sysClass myClass = new DataLib.sysClass();
                    DataRow drItem = myClass.FindItem(dr["F_ID"].ToString());
                    DataTable dt = ((DataView)binMaster.DataSource).Table;
                    DataRow drNew = dt.Rows[0];
                    drNew["F_ItemID"] = drItem["F_ID"];
                    editControl7.SetValue(drItem["F_Name"].ToString());
                    editControl8.SetValue(drItem["F_Spec"].ToString());
                    editControl9.SetValue(drItem["F_Unit"].ToString());
                    binMaster.EndEdit();
                }
            }
            mySelItem.Dispose();
        }

        private void frmProductProcess_Shown(object sender, EventArgs e)
        {
            strBillFlag = "PS";
            strMTable = "t_ProductProcess";
            strMasterSQL = "select * from t_ProductProcess where F_BillID = @Value";

            strSlaverSQL = "select * from t_ProductProcessDetail where F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_ProductProcessDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
                NewBill();
            else
            {
                BindData();
                DataRow dr = ((DataRowView)binMaster.Current).Row;
                DataLib.sysClass myClass = new DataLib.sysClass();
                DataRow drItem = myClass.FindItem(dr["F_ItemID"].ToString());
                if (drItem != null)
                {
                    editControl7.SetValue(drItem["F_Name"].ToString());
                    editControl8.SetValue(drItem["F_Spec"].ToString());
                    editControl9.SetValue(drItem["F_Unit"].ToString());
                }
            }
        }

    }
}

