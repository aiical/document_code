using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class frmViewFile : BaseClass.frmBase
    {
        public string sItemID, sItemName;
        public frmViewFile()
        {
            InitializeComponent();
        }

        private void frmViewFile_Load(object sender, EventArgs e)
        {
            label1.Text = "产品编码:" + sItemID;
            label2.Text = "产品名称:" + sItemName;
        }

        /// <summary>
        /// 从大二进制字段获取文件信息
        /// </summary>
        /// <param name="intFlag"></param>
        private void ViewFile(int intFlag)
        {
            string strSQL = "select F_File1,F_File2,F_File3,F_File4 from t_Item where F_ID = '" + sItemID + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0) return;
            Process p = new Process();
            switch (intFlag)
            {
                case 1:
                    p.StartInfo.FileName = ds.Tables[0].Rows[0]["F_File1"].ToString();
                    break;
                case 2:
                    p.StartInfo.FileName = ds.Tables[0].Rows[0]["F_File2"].ToString();
                    break;
                case 3:
                    p.StartInfo.FileName = ds.Tables[0].Rows[0]["F_File3"].ToString();
                    break;
                case 4:
                    p.StartInfo.FileName = ds.Tables[0].Rows[0]["F_File4"].ToString();
                    break;
            }

            try
            {
                p.Start();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message, "错误");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewFile(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewFile(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewFile(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewFile(4);
        }
    }
}

