using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OutProduct
{
    public partial class frmOutBillList : Common.frmBillList
    {
        public frmOutBillList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ����
        /// </summary>
        protected override void New()
        {
            frmOutBill myOutBill = new frmOutBill();
            myOutBill.ShowDialog();
            myOutBill.Dispose();
            base.New();
        }

        /// <summary>
        /// �༭����
        /// </summary>
        protected override void Edit()
        {
            if (gvList.FocusedRowHandle < 0) return;
            DataRow dr = gvList.GetDataRow(gvList.FocusedRowHandle);
            frmOutBill myOutBill = new frmOutBill();
            myOutBill.strBillID = dr["F_BillID"].ToString();
            myOutBill.ShowDialog();
            myOutBill.Dispose();
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
            if (myHelper.ExecuteSQL("delete from t_OutBill where F_BillID = '"+dr["F_BillID"].ToString()+"'") == 0)
                gvList.DeleteRow(gvList.FocusedRowHandle);

        }
    }
}

