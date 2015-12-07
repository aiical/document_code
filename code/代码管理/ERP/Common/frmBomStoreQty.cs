using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Localization;

namespace Common
{
    public partial class frmBomStoreQty : BaseClass.frmBase
    {
        private string strItemID = "";
        public frmBomStoreQty(string ItemID)
        {
            InitializeComponent();
            this.strItemID = ItemID;
            GetBomInfo();
        }

        private void GetBomInfo()
        {
            string strSQL = "select F_ID,F_Name,F_Spec from t_Item where F_ID = '"+strItemID+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            edtItemID.SetValue(ds.Tables[0].Rows[0]["F_ID"].ToString());
            edtItemName.SetValue(ds.Tables[0].Rows[0]["F_Name"].ToString());
            edtSpec.SetValue(ds.Tables[0].Rows[0]["F_Spec"].ToString());

            strSQL = @"select c.F_Name as F_StorageName,F_BatchNo,F_ItemID,b.F_Name as F_ItemName,
                       b.F_Spec,a.F_Unit,F_Qty,b.F_Price from t_StorageQty a
                       left join t_Item b
                       on a.F_ItemID = b.F_ID
                       left join t_Storage c
                       on a.F_StorageID = c.F_ID
                       where a.F_ItemID in (
                       select b.F_ItemID
                       from t_Bom a
                       left join t_BomDetail b 
                       on a.F_BillID = b.F_BillID 
                       where a.F_ItemID = '"+strItemID+"')";

            ds = myHelper.GetDs(strSQL);

            gridStore.DataSource = ds.Tables[0];

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //if (TestRight("引出", this.Name) == false) return;
            string strFile = DataLib.sysClass.ShowSaveFileDialog("Excel 文件", "Excel 文件|*.Xls");
            if (strFile != "")
                viewStore.ExportToExcelOld(strFile);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PreviewLocalizer plZer = new XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPrint(this.Text, plZer, this.printingSystem);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PreviewLocalizer plZer = new XtraChinese.DxperienceXtraPrintingLocalizationCHS();
            DataLib.sysClass myClass = new DataLib.sysClass();
            myClass.DoPreview(this.Text, plZer, this.printingSystem);
        }

    }
}
