using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmAbstractType : BaseClass.frmBase
    {
        public bool bFlag = false;
        public string sName = "";
        public frmAbstractType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ±£´æÊý¾Ý
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            string strSQL = "";
            if (bFlag == false)
                strSQL = "insert into t_AbstractType(F_Name) values('" + txtRemark.Text + "')";
            else
                strSQL = "update t_AbstractType set F_Name = '" + txtRemark.Text + "' where F_Name = '"+sName+"'";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL(strSQL) == 0)
                return true;
            else
                return false;
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            if (Save() == true)
                this.DialogResult = DialogResult.OK;
        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            if (Save() == true)
            {
                txtRemark.Text = "";
                txtRemark.Focus();
            }
        }

        private void frmAbstractType_Load(object sender, EventArgs e)
        {
            if (bFlag == true)
            {
                txtRemark.Text = sName;
            }
        }
    }
}

