using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UFIDA.Retail.Discount;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmZTSaleControlForm : Form
    {
        private bool bCanClose = false;
        private bool mustReferReturn = false;
        public string returnType;

        public frmZTSaleControlForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            //bCanClose=true;
            this.Close();
        }

        private void btnZTReturn_Click(object sender, EventArgs e)
        {
            returnType = "冲单";
            this.DialogResult = DialogResult.OK;
            //bCanClose = true;
            this.Close();
        }

        private void btnZTRepairBill_Click(object sender, EventArgs e)
        {
            returnType = "补单";
            this.DialogResult = DialogResult.OK;
            //bCanClose = true;
            this.Close();
        }
    }
}
