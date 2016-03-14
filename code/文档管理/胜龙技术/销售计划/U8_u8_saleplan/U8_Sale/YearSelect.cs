using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace U8_Sale
{
    public partial class YearSelect : Form
    {
        private string _iYear;
        public string iYear
        {
            get { return _iYear; }
            set { _iYear = value; }
        }
        public YearSelect()
        {
            InitializeComponent();
        }

        private void btnsure_Click(object sender, EventArgs e)
        {
            this.iYear = dteiYear.Text.ToString();

            this.DialogResult = DialogResult.OK;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
