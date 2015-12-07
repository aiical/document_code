using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmEditAddType : BaseClass.frmBase
    {
        private string strSaveSQL;
        public frmEditAddType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        public void DataBind(string strID)
        {
            string strSQL = "select * from t_AddType where F_Name = '" + strID + "'";
            strSaveSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds == null) return;
            binUser.DataSource = ds.Tables[0].DefaultView;
            textEdit2.DataBindings.Add("EditValue", binUser, "F_Name");
            radioGroup1.DataBindings.Add("EditValue", binUser, "F_Way");
            if (strID == "")
            {
                DataRow dr = ((DataRowView)binUser.AddNew()).Row;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            binUser.EndEdit();

            if (textEdit2.Text.Length == 0)
            {
                MessageBox.Show("名称不能为空!!", "提示");
                textEdit2.Focus();
                return;
            }

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = ((DataView)binUser.DataSource).Table.DataSet;
            if (myHelper.SaveData(ds,strSaveSQL) == 0)
                this.DialogResult = DialogResult.OK;
        }
    }
}

