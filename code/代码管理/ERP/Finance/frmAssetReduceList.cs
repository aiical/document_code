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
        /// ����
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
        /// �༭����
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
            if (MessageBox.Show(this, "���Ҫɾ��ѡ����¼��?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_AssetReduce where Aid = '" + dr["Aid"].ToString() + "'") == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);

        }
    }
}

