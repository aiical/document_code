using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmEditAbstract : BaseClass.frmBase
    {
        public bool bFlag = false;
        public string sType = "";
        public string sName = "";
        public decimal Aid = 0;
        public frmEditAbstract()
        {
            InitializeComponent();
        }

        private void BindType()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_AbstractType");
            lupType.Properties.DataSource = ds.Tables[0];
            lupType.Properties.DisplayMember = "F_Name";
            lupType.Properties.ValueMember = "F_Name";
        }

        private bool Save()
        {
            string strSQL = "";
            if (bFlag == false)
                strSQL = "insert into t_Abstract(F_Type,F_Remark) values('" +lupType.Text.ToString()+"','"+ txtRemark.Text + "')";
            else
                strSQL = "update t_Abstract set F_Remark = '" + txtRemark.Text + "',F_Type = '" + lupType.Text.ToString() + "' where Aid = " + Aid.ToString();

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

        private void frmEditAbstract_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
            {
                BindType();
                if (bFlag == true)
                {
                    lupType.EditValue = sType;
                    txtRemark.Text = sName;
                }
            }
        }

    }
}

