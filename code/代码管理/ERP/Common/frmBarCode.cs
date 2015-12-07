using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class frmBarCode : BaseClass.frmBase
    {
        public frmBill myBill;
        public frmBarCode()
        {
            InitializeComponent();
        }

        private void frmBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataLib.sysClass myClass = new DataLib.sysClass();
                DataRow dr = null;
                if (myBill.binSlaver.Count == 0)
                    dr = ((DataRowView)myBill.binSlaver.AddNew()).Row;
                else
                    dr = ((DataRowView)myBill.binSlaver.Current).Row;
                if (myClass.GetItem(txtBarCode.Text, 1, dr, myBill.Name) == false)
                    txtBarCode.SelectAll();
                else
                    txtBarCode.Text = "";
            }
        }
    }
}

