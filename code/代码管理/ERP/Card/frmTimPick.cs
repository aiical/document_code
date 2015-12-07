using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmTimPick : BaseClass.frmBase
    {
        public frmTimPick()
        {
            InitializeComponent();
            DataBind();
        }

        private void DataBind()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select * from t_SetTime");
            GridTime.DataSource = ds.Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddTime F = new frmAddTime();
            if (F.ShowDialog() == DialogResult.OK)
            {
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                if (myHelper.ExecuteSQL("insert into t_SetTime(F_Time) values('"+F.meTime.Text+"')") == 0)
                    DataBind();
            }
            F.Dispose();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (GridTime.CurrentRow == null) return;
            if (MessageBox.Show(this,"真的要删除选定行吗?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            object objAid = GridTime.CurrentRow.Cells["Aid"].Value;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_SetTime where Aid = " + objAid.ToString()) == 0)
                DataBind();
        }
    }
}
