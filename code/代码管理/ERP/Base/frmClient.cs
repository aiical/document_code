using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmClient : Common.frmBaseList
    {
        public frmClient()
        {
            InitializeComponent();
            intImport = 2;
            btnImport.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            strTable = "t_Client";
            strKey = "F_ID";
            strQuerySQL = "select a.*,b.F_Name as F_TypeName,c.F_Name as F_OpertorName ";
            strQuerySQL = strQuerySQL + "from t_Client a ";
            strQuerySQL = strQuerySQL + "left join t_Class b ";
            strQuerySQL = strQuerySQL + "on a.F_Type = b.F_ID ";
            strQuerySQL = strQuerySQL + "left join t_Emp c ";
            strQuerySQL = strQuerySQL + "on a.F_Opertor = c.F_ID ";
            strQuerySQL = strQuerySQL + "where (a.F_Type like @Value or @Value = '')";
            if (DataLib.SysVar.blnView == false)
                strQuerySQL = strQuerySQL + " and a.F_Builder = '" + DataLib.SysVar.strUName + "'";
        }

        /// <summary>
        /// 重写基类新增方法
        /// </summary>
        protected override void New()
        {
            if (TestRight("新增") == false) return;
            base.New();
            frmEditClient myEditClient = new frmEditClient();
            myEditClient.strType = tvType.SelectedNode.Tag.ToString();
            myEditClient.New();
            if (myEditClient.ShowDialog() == DialogResult.OK)
                BindData();
            myEditClient.Dispose();
        }

        /// <summary>
        /// 重写基类编辑方法
        /// </summary>
        protected override void Edit()
        {
            if (TestRight("编辑") == false) return;
            if (gvBase.FocusedRowHandle < 0) return;
            base.Edit();
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            frmEditClient myEditClient = new frmEditClient();
            myEditClient.Edit(dr["F_ID"].ToString());
            if (myEditClient.ShowDialog() == DialogResult.OK)
                BindData();
            myEditClient.Dispose();
        }

        /// <summary>
        /// 重写基类删除方法
        /// </summary>
        protected override void Del()
        {
            
            if (TestRight("删除") == false) return;
            if (gvBase.FocusedRowHandle < 0) return;
            base.Del();
            if (MessageBox.Show(this, "真的要删除本记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataRow dr = gvBase.GetDataRow(gvBase.FocusedRowHandle);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Client where F_ID = '"+dr["F_ID"].ToString()+"'") == 0)
                gvBase.DeleteRow(gvBase.FocusedRowHandle);
            
           
        }

        protected override void Export()
        {
            if (TestRight("引出") == false) return;
            base.Export();
        }


        private void frmClient_Load(object sender, EventArgs e)
        {
            FillTv("02",null);
        }
    }
}

