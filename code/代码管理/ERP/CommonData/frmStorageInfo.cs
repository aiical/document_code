using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace CommonData
{
    public partial class frmStorageInfo : BaseClass.frmBase
    {
        public string strItemID;

        public frmStorageInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定库存信息
        /// </summary>
        private void BindData()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds;
            string strSQL = "select * from t_Item where F_ID = '"+strItemID+"'";
            ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count > 0)
            {
                label1.Text = "物料编码:"+ds.Tables[0].Rows[0]["F_ID"].ToString();
                label2.Text = "物料名称:"+ds.Tables[0].Rows[0]["F_Name"].ToString();
                if (ds.Tables[0].Rows[0]["F_Spec"] == DBNull.Value)
                    label3.Text = "规格:";
                else
                    label3.Text = "规格:" + ds.Tables[0].Rows[0]["F_Spec"].ToString();

                if (ds.Tables[0].Rows[0]["F_SafeQty"] == DBNull.Value)
                    label4.Text = "安全库存:";
                else
                    label4.Text = "安全库存:" + ds.Tables[0].Rows[0]["F_SafeQty"].ToString();

                if (ds.Tables[0].Rows[0]["F_UpLimit"] == DBNull.Value)
                    label5.Text = "库存上限:";
                else
                    label5.Text = "库存上限:" + ds.Tables[0].Rows[0]["F_UpLimit"].ToString();

                if (ds.Tables[0].Rows[0]["F_DownLimit"] == DBNull.Value)
                    label6.Text = "库存下限:";
                else
                    label6.Text = "库存下限:" + ds.Tables[0].Rows[0]["F_DownLimit"].ToString();
            }
            ds.Dispose();
            strSQL = @"select c.F_Name as F_StorageName,b.F_ID,b.F_Name,b.F_Spec,a.F_Unit,
                       a.F_Grade,a.F_BatchNo,a.F_Color,b.F_Brand,a.F_Qty,d.F_StockQty,d.F_TaskQty,d.F_SellQty 
                       from t_StorageQty a
                       left join t_Item b
                       on a.F_ItemID = b.F_ID 
                       left join t_Storage c 
                       on a.F_StorageID = c.F_ID 
                       left join v_ItemOtherStore d
                       on a.F_ItemID = d.F_ItemID
                       and a.F_Unit = d.F_Unit
                       where a.F_ItemID = '" + strItemID+"'";
            myHelper = new DataLib.DataHelper();
            ds = myHelper.GetDs(strSQL);
            gcMain.DataSource = ds.Tables[0].DefaultView;
            //AssignField("", gvMain);
            DataLib.sysClass.LoadFormatFromDB(gvMain, this.Name, 0);
        }

        private void frmStorageInfo_Shown(object sender, EventArgs e)
        {
            BindData();
        }

        private void spOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 表格格式设置
        /// </summary>
        /// <param name="gv"></param>
        protected void SetFormat(GridView gv)
        {
            frmSetGrid myGrid = new frmSetGrid();
            myGrid.intFlag = 1;
            myGrid.gvSource = gv;
            myGrid.ShowDialog();
            myGrid.Dispose();
        }


        private void frmStorageInfo_KeyDown(object sender, KeyEventArgs e)
        {
            //表格字段设置
            if (e.KeyCode == Keys.F7 && DataLib.SysVar.strUGroup == "超级用户")
            {
                 SetFormat(gvMain);
            }

            //保存表格格式
            if (e.KeyCode == Keys.F5 && DataLib.SysVar.strUGroup == "超级用户")
                DataLib.sysClass.SaveGridToDB(gvMain, this.Name, 0);
        }
    }
}

