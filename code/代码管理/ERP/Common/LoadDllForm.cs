using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class LoadDllForm : BaseClass.frmBase
    {
        public LoadDllForm()
        {
            InitializeComponent();
            FillGrade();
        }

        private void SelectFile()
        {
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = OpenDialog.FileName;
            }
        }

        private void FillGrade()
        {
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs("select F_Parent from t_UserModule");
            cbGrade.Items.Clear();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cbGrade.Items.Add(dr["F_Parent"].ToString());
            }
            ds.Dispose();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectFile();
        }

        private int SaveData()
        {


            if (txtModuleName.Text.Length == 0)
            {
                MessageBox.Show(this, "模块名称不能为空!!", "提示");
                txtModuleName.Focus();
                return -1;
            }

            if (cbGrade.Text.Length == 0)
            {
                MessageBox.Show(this, "所属级别不能为空!!", "提示");
                cbGrade.Focus();
                return -1;
            }
            
            if (txtFile.Text.Length == 0)
            {
                MessageBox.Show(this, "库文件不能为空!!", "提示");
                txtFile.Focus();
                return -1;
            }

            if (txtClassName.Text.Length == 0)
            {
                MessageBox.Show(this, "调用类名不能为空!!", "提示");
                txtClassName.Focus();
                return -1;
            }


            if (cbType.Text.Length == 0)
            {
                MessageBox.Show(this, "窗体类别不能为空!!", "提示");
                cbType.Focus();
                return -1;
            }

            string sSQL = string.Format("insert into t_UserModule(F_Parent,F_ModuleName,F_Class,F_FormName,F_Mdi) values('{0}','{1}','{2}','{3}',{4})", txtModuleName.Text, cbGrade.Text, txtFile.Text, txtClassName.Text,cbType.SelectedIndex);

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            return myHelper.ExecuteSQL(sSQL);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SaveData() != -1) this.Close();
        }
    }
}
