using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Common
{
    public partial class frmPrintSQL : BaseClass.frmBase
    {
        public string sBillID = "";
        public frmPrintSQL()
        {
            InitializeComponent();
        }

        private DataSet GetQuery(string sSQL)
        {
            Hashtable htParm = new Hashtable();
            htParm.Add("@Value", sBillID);
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetOtherDs(sSQL, htParm);
            return ds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (meSQL.Text == "")
            {
                MessageBox.Show(this, "SQL语句不能为空!", "提示");
                meSQL.Focus();
                return;
            }
            if (GetQuery(meSQL.Text) != null)
                this.DialogResult = DialogResult.OK;
        }
    }
}
