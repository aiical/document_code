using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmItem : Common.frmBaseList
    {
        public frmItem()
        {
            InitializeComponent();
            intImport = 4;
            btnImport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            strTable = "t_Item";
            strKey = "F_ID";

            strQuerySQL = @"select a.*,d.F_Name as F_Unit,b.F_Name as F_TypeName,c.F_Name as F_StorageName 
                            from t_Item a 
                            left join t_Class b 
                            on a.F_Type = b.F_ID 
                            left join t_Storage c 
                            on a.F_StorageID = c.F_ID 
                            left join t_Unit d
                            on a.F_ID = d.F_ItemID
                            and d.F_Main = 1
                            where (a.F_Type like @Value or @Value = '')
                            and a.F_Attrib = '原材料'";
          
        }

        protected override void New()
        {
            base.New();
            frmEditItem myEditItem = new frmEditItem();
            myEditItem.strType = tvType.SelectedNode.Tag.ToString();
            myEditItem.New();
            if (myEditItem.ShowDialog() == DialogResult.OK)
                BindData();
            myEditItem.Dispose();
        }

        protected override void Edit()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Edit();
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmEditItem myEditItem = new frmEditItem();
            myEditItem.Edit(dr["F_ID"].ToString());
            if (myEditItem.ShowDialog() == DialogResult.OK)
                BindData();
            myEditItem.Dispose();
        }

        protected override void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Item where F_ID = '"+dr["F_ID"].ToString()+"'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);
            
           
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            tvType.SendToBack();
            FillTv("04",null);
        }
    }
}

