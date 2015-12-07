using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class frmTypeEdit : BaseClass.frmBase
    {
        public string strPID = "",strCID = "",strTable,strKey;

        public frmTypeEdit()
        {
            InitializeComponent();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmTypeEdit_Load(object sender, EventArgs e)
        {
            textEdit1.Text = strPID + ".";
            if (strCID != "")
            {
                textEdit2.Text = strCID.Substring(strPID.Length + 1);
                textEdit2.Enabled = false;
            }

        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            if (textEdit2.Text.Length == 0)
            {
                MessageBox.Show("请输入类别编码!!", "揭示");
                textEdit2.Focus();
                return;
            }

            if (textEdit3.Text.Length == 0)
            {
                MessageBox.Show("请输入类别名称!!", "揭示");
                textEdit3.Focus();
                return;
            }
            string strID = textEdit1.Text + textEdit2.Text;
            string strSQL = "";
            if (strCID == "")
                strSQL = "insert into t_Class(F_UPID,F_ID,F_Name,F_Tag,F_Table,F_Key) values('" + strPID + "','" + strID + "','" + textEdit3.Text + "','0','" + strTable + "','" + strKey + "')";
            else
                strSQL = "update t_Class set F_Name = '" + textEdit3.Text + "' where F_ID = '" + strCID + "'";


            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL(strSQL) == 0)
                this.DialogResult = DialogResult.OK;

        }
    }
}

