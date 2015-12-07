using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmReadEmpPic : BaseClass.frmBase
    {
        public frmReadEmpPic()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ReadEmpPic(textBox1.Text);
            }
        }

        private void ReadEmpPic(string sEmpID)
        {
            string sSQL = "select F_ID,F_Name,F_Pic from t_Emp where F_ID = '"+sEmpID+"'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataTable dt = myHelper.GetDs(sSQL).Tables[0];
            if (dt.Rows.Count > 0)
            {
                textBox2.Text = dt.Rows[0]["F_Name"].ToString();
                if (dt.Rows[0]["F_Pic"] != DBNull.Value)
                {
                    Image img = null;
                    ImageConverter imgCvt = new ImageConverter();

                    object obj = imgCvt.ConvertFrom((byte[])dt.Rows[0]["F_Pic"]);
                    img = (Image)obj;

                    pictureBox1.Image = img;
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            else
            {
                MessageBox.Show(this,"没此员工!","提示");
                textBox2.Text = "";
                pictureBox1.Image = null;
            }
        }
    }
}
