using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmAbstract : BaseClass.frmBase
    {
        public frmAbstract()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 刷新摘要类别
        /// </summary>
        private void RefreshType()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_AbstractType");
            gcType.DataSource = ds.Tables[0].DefaultView;
        }

        private void sbAddType_Click(object sender, EventArgs e)
        {
            frmAbstractType myAbstractType = new frmAbstractType();
            myAbstractType.ShowDialog();
            myAbstractType.Dispose();
            RefreshType();
        }

        private void sbModiType_Click(object sender, EventArgs e)
        {
            if (gvType.FocusedRowHandle < 0) return;
            DataRow dr = gvType.GetDataRow(gvType.FocusedRowHandle);
            frmAbstractType myAbstractType = new frmAbstractType();
            myAbstractType.bFlag = true;
            myAbstractType.sName = dr["F_Name"].ToString();
            myAbstractType.ShowDialog();
            myAbstractType.Dispose();
            RefreshType();
        }

        private void frmAbstract_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
            {
                RefreshType();
            }
        }

        private void sbDelType_Click(object sender, EventArgs e)
        {
            if (gvType.FocusedRowHandle < 0) return;
            DataRow dr = gvType.GetDataRow(gvType.FocusedRowHandle);
            if (MessageBox.Show(this, "真的要删除选定类别吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_AbstractType where F_Name = '" + dr["F_Name"].ToString() + "'") == 0)
                gvType.DeleteRow(gvType.FocusedRowHandle);
        }

        /// <summary>
        /// 绑定摘要信息
        /// </summary>
        /// <param name="sType"></param>
        private void BindSlaver(string sType)
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_Abstract where (F_Type = '"+sType+"' or '"+sType + "' = '《所有类别》')");
            gcAbstract.DataSource = ds.Tables[0].DefaultView;
        }

        private void gvType_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0) return;
            DataRow dr = gvType.GetDataRow(e.FocusedRowHandle);
            if (dr["F_Name"].ToString() == "《所有类别》")
            {
                sbModiType.Enabled = false;
                sbDelType.Enabled = false;
                BindSlaver("《所有类别》");
            }
            else
            {
                sbModiType.Enabled = true;
                sbDelType.Enabled = true;
                DataRow drTmp = gvType.GetDataRow(e.FocusedRowHandle);
                BindSlaver(drTmp["F_Name"].ToString());
            }
        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            frmEditAbstract myEditAbstract = new frmEditAbstract();
            if (myEditAbstract.ShowDialog() == DialogResult.OK)
            {
                DataRow drTmp = gvType.GetDataRow(gvType.FocusedRowHandle);
                BindSlaver(drTmp["F_Name"].ToString());
            }
            myEditAbstract.Dispose();
        }

        private void sbModi_Click(object sender, EventArgs e)
        {
            if (gvAbstract.FocusedRowHandle < 0) return;
            DataRow dr = gvAbstract.GetDataRow(gvAbstract.FocusedRowHandle);
            frmEditAbstract myEditAbstract = new frmEditAbstract();
            myEditAbstract.bFlag = true;
            myEditAbstract.sName = dr["F_Remark"].ToString();
            myEditAbstract.sType = dr["F_Type"].ToString();
            myEditAbstract.Aid = Convert.ToDecimal(dr["Aid"]);
            if (myEditAbstract.ShowDialog() == DialogResult.OK)
            {
                DataRow drTmp = gvType.GetDataRow(gvType.FocusedRowHandle);
                BindSlaver(drTmp["F_Name"].ToString());
            }
            myEditAbstract.Dispose();
        }

        private void sbDel_Click(object sender, EventArgs e)
        {
            if (gvAbstract.FocusedRowHandle < 0) return;
            DataRow dr = gvAbstract.GetDataRow(gvAbstract.FocusedRowHandle);
            if (MessageBox.Show(this, "真的要删除选定类别吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Abstract where Aid = " + dr["Aid"].ToString()) == 0)
                gvAbstract.DeleteRow(gvType.FocusedRowHandle);
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void gcAbstract_DoubleClick(object sender, EventArgs e)
        {
            if (gvAbstract.FocusedRowHandle < 0) return;
            sbOK_Click(null, null);
        }
    }
}

