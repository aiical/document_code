using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmAssetList : Common.frmBillList
    {
        public frmAssetList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ����
        /// </summary>
        protected override void New()
        {
            frmEditAsset myEditAsset = new frmEditAsset();
            myEditAsset.New();
            myEditAsset.ShowDialog();
            myEditAsset.Dispose();
           
            base.New();
        }

        /// <summary>
        /// �༭����
        /// </summary>
        protected override void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            frmEditAsset myEditAsset = new frmEditAsset();
            myEditAsset.Edit(dr["F_ID"].ToString());
            myEditAsset.ShowDialog();
            myEditAsset.Dispose();
             
            base.Edit();
        }

        /// <summary>
        /// ɾ��
        /// </summary>
        protected override void Del()
        {
            base.Del();
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            /*
            if (Convert.ToBoolean(dr["F_Check"]) == true)
            {
                MessageBox.Show(this, "����ɾ������˵ļ�¼����", "��ʾ");
                return;
            }
             */ 
            if (MessageBox.Show(this, "���Ҫɾ��ѡ���̶��ʲ���?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_Asset where F_ID = '" + dr["F_ID"].ToString() + "'") == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);

        }
    }
}

