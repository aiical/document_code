using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class frmEditAssetType : BaseClass.frmBase
    {
        private string strSaveSQL;
        public frmEditAssetType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        public void DataBind(string strID)
        {
            string strSQL = "select * from t_AssetType where F_Name = '" + strID + "'";
            strSaveSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds == null) return;
            binUser.DataSource = ds.Tables[0].DefaultView;
            textEdit2.DataBindings.Add("EditValue", binUser, "F_Name");
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
                MessageBox.Show("资产名称不能为空!!", "提示");
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

