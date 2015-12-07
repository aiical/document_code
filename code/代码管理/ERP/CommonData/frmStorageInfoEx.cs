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
    public partial class frmStorageInfoEx : BaseClass.frmBase
    {
        public string strItemID;

        public frmStorageInfoEx()
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
        
            string strSQL = @"select c.F_Name as F_StorageName,b.F_ID,b.F_Name,b.F_Spec,a.F_Unit,
                       a.F_Grade,a.F_BatchNo,a.F_Color,b.F_Brand,b.F_Material,a.F_Qty,case when isnull(d.F_StockQty,0) < 0 then 0 else d.F_StockQty end as F_StockQty,d.F_TaskQty,d.F_SellQty,
                       (case when isnull(a.F_Qty,0) - isnull(d.F_SellQty,0) < 0 then 0 else isnull(a.F_Qty,0) - isnull(d.F_SellQty,0) end) as F_EvaQty,
                       b.F_Price
                       from t_StorageQty a
                       left join t_Item b
                       on a.F_ItemID = b.F_ID 
                       left join t_Storage c 
                       on a.F_StorageID = c.F_ID 
                       left join v_ItemOtherStore d
                       on a.F_ItemID = d.F_ItemID
                       and a.F_Unit = d.F_Unit
                       where a.F_ItemID in (" + strItemID+")";
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

