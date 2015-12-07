using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class frmEditAssist : BaseClass.frmBase
    {
        public string strType = "";
        public string strID = "";
        public frmEditAssist()
        {
            InitializeComponent();
        }

        public void Edit(string strName)
        {
            txtID.Text = strID;
            txtName.Text = strName;
        }

        private void sbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Length == 0)
            {
                MessageBox.Show(this, "编码不能为空!!", "提示");
                txtID.Focus();
                return;
            }

            if (txtName.Text.Length == 0)
            {
                MessageBox.Show(this, "名称不能为空!!", "提示");
                txtName.Focus();
                return;
            }

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (strID == "")
            {
                myHelper.ExecuteSQL("insert into t_Assist values('" + strType + "','" + txtID.Text + "','"+txtName.Text+"')");
            }
            else
            {
                myHelper.ExecuteSQL("update t_Assist set F_Name = '" + txtName.Text + "' where F_Type = '" + strType + "' and F_ID = '" + strID + "'");
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}

