using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using System.Collections;


namespace Common
{
    public partial class frmSetField : BaseClass.frmBase
    {
        public DataTable dtSource, dtDes;
        public DataTable dtSource1, dtDes1;
        public string strType, strClass;

        public frmSetField()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取得已设置字段
        /// </summary>
        private void LoadField()
        {
            string strSQL = "select F_MasterField,F_SlaverField from t_BillImport where F_Type = '" + strType + "' and F_Class = '" + strClass + "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            if (ds.Tables[0].Rows.Count == 0) return;
            string strDes = ds.Tables[0].Rows[0]["F_MasterField"].ToString();
            string strDes1 = ds.Tables[0].Rows[0]["F_SlaverField"].ToString();
            string[] strMaster = strDes.Split(',');
            string[] strSlaver = strDes1.Split(',');
            for (int i = 0; i < strMaster.Length - 1; i++)
            {
                lbDes.Items.Add(strMaster[i]);
            }
            for (int i = 0; i < strSlaver.Length - 1; i++)
            {
                lbDes1.Items.Add(strSlaver[i]);
            }
            ds.Dispose();
        }

        /// <summary>
        /// 保存字段
        /// </summary>
        private int SaveField()
        {
            string strDes = "", strDes1 = "";
            
            foreach (Object Item in lbDes.Items)
            {
                strDes = strDes + Item.ToString() + ",";
            }

            foreach (Object Item1 in lbDes1.Items)
            {
                strDes1 = strDes1 + Item1.ToString() + ",";
            }

            string strSQL = "update t_BillImport set F_MasterField = '" + strDes + "',F_SlaverField = '" + strDes1 + "' where F_Type = '" + strType + "' and F_Class = '" + strClass + "'";
            DataLib.DataHelper myDataHelper = new DataLib.DataHelper();
            return (myDataHelper.ExecuteSQL(strSQL));
        }

        /// <summary>
        /// 取得数据集字段
        /// </summary>
        private void GetField()
        {
            foreach (DataColumn dc in dtSource.Columns)
            {
                lbLeft.Items.Add(dc.ColumnName);
            }
            
            foreach (DataColumn dc in dtDes.Columns)
            {
                lbRight.Items.Add(dc.ColumnName);
            }

            foreach (DataColumn dc in dtSource1.Columns)
            {
                lbLeft1.Items.Add(dc.ColumnName);
            }

            foreach (DataColumn dc in dtDes1.Columns)
            {
                lbRight1.Items.Add(dc.ColumnName);
            }      

        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSetField_Load(object sender, EventArgs e)
        {
            GetField();
            LoadField();
        }

        private void sbCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void sbAdd_Click(object sender, EventArgs e)
        {
            lbDes.Items.Add(lbLeft.SelectedItem.ToString()+"->"+lbRight.SelectedItem.ToString());
        }

        private void sbRemove_Click(object sender, EventArgs e)
        {
            if (lbDes.SelectedIndex < 0) return;
            lbDes.Items.Remove(lbDes.SelectedItem);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            lbDes1.Items.Add(lbLeft1.SelectedItem.ToString() + "->" + lbRight1.SelectedItem.ToString());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (lbDes1.SelectedIndex < 0) return;
            lbDes1.Items.Remove(lbDes1.SelectedItem);
        }

        private void sbOK_Click(object sender, EventArgs e)
        {
            if (SaveField() == 0)
                this.DialogResult = DialogResult.OK;
        }
    }
}

