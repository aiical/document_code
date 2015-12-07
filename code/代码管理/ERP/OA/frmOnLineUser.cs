using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OA
{
    public partial class frmOnLineUser : BaseClass.frmBase
    {
        public frmOnLineUser()
        {
            InitializeComponent();
            DataBind();
        }

        private void DataBind()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_ID,F_Name,F_Group from t_User where F_Login = 1");
            gcUser.DataSource = ds.Tables[0];
        }
    }
}
