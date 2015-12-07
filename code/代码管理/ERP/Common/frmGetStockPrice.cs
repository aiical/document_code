using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class frmGetStockPrice : BaseClass.frmBase
    {
        public int intFlag = 0;
        public frmGetStockPrice()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            if (gvPrice.FocusedRowHandle < 0) return;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 设置单据相应列的价格
        /// </summary>
        /// <param name="strItemID"></param>
        public void SetPrice(string strItemID)
        {

            DataTable dt = new DataTable();
            
            DataColumn dc1 = new DataColumn("F_Name",Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("F_Price",Type.GetType("System.Decimal"));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);

            string strSQL = "select * from t_Item where F_ID = '" + strItemID + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);

            if (intFlag == 0)
            {
                DataRow dr = dt.NewRow();
                dr["F_Name"] = "默认进价";
                dr["F_Price"] = ds.Tables[0].Rows[0]["F_StockPrice"];
                dt.Rows.Add(dr);

                DataRow dr1 = dt.NewRow();
                dr1["F_Name"] = "进价1";
                dr1["F_Price"] = ds.Tables[0].Rows[0]["F_StockPrice1"];
                dt.Rows.Add(dr1);

                DataRow dr2 = dt.NewRow();
                dr2["F_Name"] = "进价2";
                dr2["F_Price"] = ds.Tables[0].Rows[0]["F_StockPrice2"];
                dt.Rows.Add(dr2);

                DataRow dr3 = dt.NewRow();
                dr3["F_Name"] = "进价3";
                dr3["F_Price"] = ds.Tables[0].Rows[0]["F_StockPrice3"];
                dt.Rows.Add(dr3);

                DataRow dr4 = dt.NewRow();
                dr4["F_Name"] = "进价4";
                dr4["F_Price"] = ds.Tables[0].Rows[0]["F_StockPrice4"];
                dt.Rows.Add(dr4);
            }
            else
            {
                DataRow dr = dt.NewRow();
                dr["F_Name"] = "默认售价";
                dr["F_Price"] = ds.Tables[0].Rows[0]["F_SellPrice"];
                dt.Rows.Add(dr);

                DataRow dr1 = dt.NewRow();
                dr1["F_Name"] = "售价1";
                dr1["F_Price"] = ds.Tables[0].Rows[0]["F_SellPrice1"];
                dt.Rows.Add(dr1);

                DataRow dr2 = dt.NewRow();
                dr2["F_Name"] = "售价2";
                dr2["F_Price"] = ds.Tables[0].Rows[0]["F_SellPrice2"];
                dt.Rows.Add(dr2);

                DataRow dr3 = dt.NewRow();
                dr3["F_Name"] = "售价3";
                dr3["F_Price"] = ds.Tables[0].Rows[0]["F_SellPrice3"];
                dt.Rows.Add(dr3);

                DataRow dr4 = dt.NewRow();
                dr4["F_Name"] = "售价4";
                dr4["F_Price"] = ds.Tables[0].Rows[0]["F_SellPrice4"];
                dt.Rows.Add(dr4);
            }

            gcPrice.DataSource = dt.DefaultView;
        }

        private void gcPrice_DoubleClick(object sender, EventArgs e)
        {
            sbOK_Click(null, null);
        }
    }
}

