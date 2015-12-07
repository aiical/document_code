using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmSubject : BaseClass.frmBase
    {
        public bool bFlag = false;
        public bool bChildFlag = false;

        public frmSubject()
        {
            InitializeComponent();
        }

        private DevExpress.XtraTreeList.TreeList GetTv()
        {
            DevExpress.XtraTreeList.TreeList tvDes = null;
            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    tvDes = tvAsset;
                    break;
                case 1:
                    tvDes = tvDebt;
                    break;
                case 2:
                    tvDes = tvRights;
                    break;
                case 3:
                    tvDes = tvCost;
                    break;
                case 4:
                    tvDes = tvLoss;
                    break;
                case 5:
                    tvDes = tvOut;
                    break;

            }
            return tvDes;
        }

        public string GetSubject()
        {
            DevExpress.XtraTreeList.TreeList tvDes = GetTv();

            if (tvDes.FocusedNode == null) return "";

            return tvDes.FocusedNode.GetValue("F_ID").ToString();
        }

        public string GetSubjectName()
        {
            DevExpress.XtraTreeList.TreeList tvDes = GetTv();

            if (tvDes.FocusedNode == null) return "";
            return tvDes.FocusedNode.GetValue("F_Name").ToString();
        }

        public string GetSubjectInfo()
        {
            DevExpress.XtraTreeList.TreeList tvDes = GetTv();

            if (tvDes.FocusedNode == null) return "";
            return tvDes.FocusedNode.GetValue("F_ID").ToString() + "-" + tvDes.FocusedNode.GetValue("F_Name").ToString();
        }

        private void BindData()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsAsset = myHelper.GetDs("select * from t_Subject where left(F_ID,1) = '1'");
            tvAsset.DataSource = dsAsset.Tables[0];

            DataSet dsDebt = myHelper.GetDs("select * from t_Subject where left(F_ID,1) = '2'");
            tvDebt.DataSource = dsDebt.Tables[0];

            DataSet dsRights = myHelper.GetDs("select * from t_Subject where left(F_ID,1) = '3'");
            tvRights.DataSource = dsRights.Tables[0];

            DataSet dsCost = myHelper.GetDs("select * from t_Subject where left(F_ID,1) = '4'");
            tvCost.DataSource = dsCost.Tables[0];

            DataSet dsLoss = myHelper.GetDs("select * from t_Subject where left(F_ID,1) = '5'");
            tvLoss.DataSource = dsLoss.Tables[0];


            DataSet dsOut = myHelper.GetDs("select * from t_Subject where left(F_ID,1) = '6'");
            tvOut.DataSource = dsOut.Tables[0];
        }

        private void sbCloe_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSubject_Shown(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
            {
                BindData();
            }
        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tvDes = GetTv();

            frmEditSubject myEditSubject = new frmEditSubject();

            if (tvDes.FocusedNode == null)
            {
                myEditSubject.sUPID = "";
            }
            else
            {
                if (tvDes.FocusedNode.Level == 0)
                    myEditSubject.sUPID = "";
                else
                    myEditSubject.sUPID = tvDes.FocusedNode.ParentNode.GetValue("F_ID").ToString();
            }
            myEditSubject.New();
            if (myEditSubject.ShowDialog() == DialogResult.OK)
                BindData();
            myEditSubject.Dispose();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tvDes = GetTv();
            if (tvDes.FocusedNode == null) return;
            frmEditSubject myEditSubject = new frmEditSubject();
            if (tvDes.FocusedNode == null)
                myEditSubject.sUPID = "";
            else
                myEditSubject.sUPID = tvDes.FocusedNode.GetValue("F_ID").ToString();
            myEditSubject.New();
            if (myEditSubject.ShowDialog() == DialogResult.OK)
                BindData();
            myEditSubject.Dispose();
        }

        private void tvAsset_DoubleClick(object sender, EventArgs e)
        {
            if (bFlag == true)
            {
                DevExpress.XtraTreeList.TreeList tvDes = GetTv();

                if (tvDes.FocusedNode.HasChildren == false && bChildFlag == true)
                {
                    MessageBox.Show("此科目没有下级科目，不能选择!", "提示");
                    return;
                }

                if (tvDes.FocusedNode != null)
                   this.DialogResult = DialogResult.OK;
            }
        }

        private void sbDel_Click(object sender, EventArgs e)
        {
            string sSubject = GetSubject();
            if (sSubject == "") return;
            if (MessageBox.Show(this, "真的删除选定科目吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Subject where F_ID = '" + sSubject + "'") == 0)
            {
                BindData();
            }
        }

        private void sbEdit_Click(object sender, EventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tvDes = GetTv();
            if (tvDes.FocusedNode == null) return;
            frmEditSubject myEditSubject = new frmEditSubject();
            myEditSubject.Edit(tvDes.FocusedNode.GetValue("F_ID").ToString());
            if (myEditSubject.ShowDialog() == DialogResult.OK)
                BindData();
            myEditSubject.Dispose();
        }
    }
}

