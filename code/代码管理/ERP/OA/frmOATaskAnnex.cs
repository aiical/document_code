using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OA
{
    public partial class frmOATaskAnnex : BaseClass.frmBase
    {
        public BindingSource binSource = null;
        public frmOATaskAnnex()
        {
            InitializeComponent();
        }

        private void TestFileStatus()
        {
            DataRow dr = ((DataRowView)binSource.Current).Row;
            if (dr["F_File1"] != DBNull.Value)
                groupBox1.ForeColor = Color.Red;
            else
                groupBox1.ForeColor = Color.Black;

            if (dr["F_File2"] != DBNull.Value)
                groupBox2.ForeColor = Color.Red;
            else
                groupBox2.ForeColor = Color.Black;

            if (dr["F_File3"] != DBNull.Value)
                groupBox3.ForeColor = Color.Red;
            else
                groupBox3.ForeColor = Color.Black;

            if (dr["F_File4"] != DBNull.Value)
                groupBox4.ForeColor = Color.Red;
            else
                groupBox4.ForeColor = Color.Black;
        }

        /// <summary>
        /// 大二进制文件处理
        /// </summary>
        /// <param name="intFlag"></param>
        /// <param name="intTag"></param>
        private void SaveOrOpenFile(int intFlag,int intTag)
        {
            DataRow dr = ((DataRowView)binSource.Current).Row;
            DataLib.sysClass myClass = new DataLib.sysClass();
            if (intFlag == 0)
            {
                myClass.SaveFileToDr(dr, intTag);
            }
            else
            {
                myClass.LoadFileFromDr(dr, intTag);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(0, 1);
            groupBox1.ForeColor = Color.Red;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(0, 2);
            groupBox2.ForeColor = Color.Red;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(0, 3);
            groupBox3.ForeColor = Color.Red;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(0, 4);
            groupBox4.ForeColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(1, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(1, 2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(1, 3);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveOrOpenFile(1, 4);
        }

        private void frmOATaskAnnex_Shown(object sender, EventArgs e)
        {
            TestFileStatus();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataRow dr = ((DataRowView)binSource.Current).Row;
            dr.BeginEdit();
            dr["F_FileName1"] = "";
            dr["F_File1"] = DBNull.Value;
            dr.EndEdit();
            groupBox1.ForeColor = Color.Black;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataRow dr = ((DataRowView)binSource.Current).Row;
            dr.BeginEdit();
            dr["F_FileName2"] = "";
            dr["F_File2"] = DBNull.Value;
            dr.EndEdit();
            groupBox2.ForeColor = Color.Black;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DataRow dr = ((DataRowView)binSource.Current).Row;
            dr.BeginEdit();
            dr["F_FileName3"] = "";
            dr["F_File3"] = DBNull.Value;
            dr.EndEdit();
            groupBox3.ForeColor = Color.Black;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DataRow dr = ((DataRowView)binSource.Current).Row;
            dr.BeginEdit();
            dr["F_FileName4"] = "";
            dr["F_File4"] = DBNull.Value;
            dr.EndEdit();
            groupBox4.ForeColor = Color.Black;
        }
    }
}

