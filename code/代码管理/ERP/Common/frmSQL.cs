using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class frmSQL : BaseClass.frmBase
    {
        public frmSQL()
        {
            InitializeComponent();
        }

        private void spCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void spOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

