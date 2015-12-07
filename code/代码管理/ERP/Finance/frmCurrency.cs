using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmCurrency : Common.frmBaseList
    {
        public frmCurrency()
        {
            InitializeComponent();
            btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            strTable = "t_Currency";
            strKey = "F_Name";
            strQuerySQL = "select * from t_Currency";
        }

        protected override void New()
        {
            base.New();

            frmEditCurrency myEditCurrency = new frmEditCurrency();
            myEditCurrency.New();
            if (myEditCurrency.ShowDialog() == DialogResult.OK)
                BindData();
            myEditCurrency.Dispose();
              
        }

        protected override void Edit()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Edit();
            
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmEditCurrency myEditCurrency = new frmEditCurrency();
            myEditCurrency.Edit(dr["F_Name"].ToString());
            if (myEditCurrency.ShowDialog() == DialogResult.OK)
                BindData();
            myEditCurrency.Dispose();       
        }

        protected override void Del()
        {
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Currency where F_Name = '"+dr["F_Name"].ToString()+"'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);
            
           
        }

        private void frmEmp_Load(object sender, EventArgs e)
        {
            tvType.SendToBack();
        }
    }
}

