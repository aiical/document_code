using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Product
{
    public partial class frmProductPlan : Common.frmBill
    {
        private DataTable dtGen = null;
        private string strDept = "";

        public frmProductPlan()
        {
            InitializeComponent();
            if (DataLib.SysVar.GetParmValue("F_N31")) bMultCheck = true;
            btnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnUnCutOff.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        public frmProductPlan(DataTable dt,string Dept)
        {
            InitializeComponent();
            this.dtGen = dt;
            this.strDept = Dept;
        }


        /// <summary>
        /// 根据排程生成
        /// </summary>
        public void GenBill()
        {
            ((DataView)binSlaver.DataSource).Table.Clear();

            lupDept.SetValue(strDept);
            foreach (DataRow dr in dtGen.Rows)
            {
                DataTable dt = ((DataView)binSlaver.DataSource).Table;
                DataRow drNew = dt.NewRow();
                drNew["F_ItemID"] = dr["F_ItemID"];
                drNew["F_ItemName"] = dr["F_Name"];
                drNew["F_Spec"] = dr["F_Spec"];
                drNew["F_Unit"] = dr["F_Unit"];
                drNew["F_Qty"] = dr["F_Qty"];
                dt.Rows.Add(drNew);
            }
            DataLib.sysClass.LoadFormatFromDB(gvList, this.Name, Convert.ToInt32(strBillTag));
        }


        private void SetDropSource()
        {
            string strSQL = "";
            DataSet ds = null;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            strSQL = strSQL = "select F_ID,F_Name from t_Class where left(F_UPID,2) like '03%'";
            ds = myHelper.GetDs(strSQL);
            lupDept.LookUpDataSource = ds.Tables[0].DefaultView;
            lupDept.LookUpDisplayField = "F_Name";
            lupDept.LookUpKeyField = "F_ID";
            ds.Dispose();

        }

        private void frmStockOrder_Load(object sender, EventArgs e)
        {
           
        }


        //protected override bool SavePre()
        //{
        //    if (base.SavePre() == false) return false;
        //    DataTable dt = ((DataView)binSlaver.DataSource).Table;
        //    int intCnt = gvList.RowCount;
        //    for (int i = 0; i < intCnt; i++)
        //    {
        //        DataRow dr = gvList.GetDataRow(i);

        //        if (dr["F_Begin"] == DBNull.Value)
        //        {
        //            MessageBox.Show("开始日期不能为空!!", "提示");
        //            gcBill.Focus();
        //            gvList.FocusedColumn = gvList.Columns.ColumnByFieldName("F_Begin");
        //            gvList.FocusedRowHandle = i;
        //            return false;
        //        }

        //        if (dr["F_End"] == DBNull.Value)
        //        {
        //            MessageBox.Show("结束日期不能为空!!", "提示");
        //            gcBill.Focus();
        //            gvList.FocusedColumn = gvList.Columns.ColumnByFieldName("F_End");
        //            gvList.FocusedRowHandle = i;
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        private void frmProductPlan_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode == true) return;
            strBillFlag = "PP";
            strMTable = "t_ProductPlan";
            strMasterSQL = "select * from t_ProductPlan where F_BillID = @Value";

            strSlaverSQL = "select a.*,b.F_Name as F_ItemName,b.F_Spec,b.F_Material,b.F_Brand,(select F_Name from t_Class where F_ID = b.F_Type) as F_Type ";
            strSlaverSQL = strSlaverSQL + "from t_ProductPlanDetail a,t_Item b ";
            strSlaverSQL = strSlaverSQL + "where a.F_ItemID = b.F_ID ";
            strSlaverSQL = strSlaverSQL + "and F_BillID = @Value";

            strSaveSlaverSQL = "select * from t_ProductPlanDetail where F_BillID = @Value";

            SetDropSource();

            if (strBillID == "")
            {
                NewBill();
                if (dtGen != null) GenBill();
            }
            else
                BindData();
        }

    }
}

