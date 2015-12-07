using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OutProduct
{
    public partial class frmOutPayList : Common.frmBillList
    {
        public frmOutPayList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ����
        /// </summary>
        protected override void New()
        {
            frmOutPay myOutPay = new frmOutPay();
            myOutPay.ShowDialog();
            myOutPay.Dispose();
            base.New();
        }

        /// <summary>
        /// �༭����
        /// </summary>
        protected override void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            frmOutPay myOutPay = new frmOutPay();
            myOutPay.strBillID = dr["F_BillID"].ToString();
            myOutPay.ShowDialog();
            myOutPay.Dispose();
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
            if (Convert.ToBoolean(dr["F_Check"]) == true)
            {
                MessageBox.Show(this, "����ɾ������˵ĵ��ݣ���", "��ʾ");
                return;
            }
            if (MessageBox.Show(this, "���Ҫɾ��ѡ��������?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_OutPay where F_BillID = '"+dr["F_BillID"].ToString()+"'") == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);

        }
    }
}

