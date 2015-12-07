using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmAssetReduceList : Common.frmBillList
    {
        public frmAssetReduceList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 新增
        /// </summary>
        protected override void New()
        {
            frmEditAssetReduce myEditAssetReduce = new frmEditAssetReduce();
            myEditAssetReduce.New();
            myEditAssetReduce.ShowDialog();
            myEditAssetReduce.Dispose();
           
            base.New();
        }

        /// <summary>
        /// 编辑　　
        /// </summary>
        protected override void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            frmEditAssetReduce myEditAssetReduce = new frmEditAssetReduce();
            myEditAssetReduce.Edit(dr["Aid"].ToString());
            myEditAssetReduce.ShowDialog();
            myEditAssetReduce.Dispose();
             
            base.Edit();
        }

        /// <summary>
        /// 删除
        /// </summary>
        protected override void Del()
        {
            base.Del();
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            /*
            if (Convert.ToBoolean(dr["F_Check"]) == true)
            {
                MessageBox.Show(this, "不能删除已审核的记录！！", "提示");
                return;
            }
             */ 
            if (MessageBox.Show(this, "真的要删除选定记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_AssetReduce where Aid = '" + dr["Aid"].ToString() + "'") == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);

        }
    }
}

