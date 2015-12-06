using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace U8_Sale
{
    public partial class frmQueryRefset : Form
    {
        //private DevExpress.XtraGrid.Views.Grid.GridView _dgv;

        //public DevExpress.XtraGrid.Views.Grid.GridView Dgv
        //{
           // get { return _dgv; }
           // set { _dgv = value; }
       // }
        private DataSet _dgv;

        public DataSet Dgv
        {
         get { return _dgv; }
         set { _dgv = value; }
        }

        public frmQueryRefset()
        {
            InitializeComponent();
            

        }
        private void Bindata()
        {
            string StrSQL = string.Format("select  SD.cDepCode,D.cDepName FROM {0}..SL_P_DeptRef SD LEFT JOIN Department D ON SD.cDepCode=D.cDepCode ORDER BY SD.cDepCode ASC", DBHelper.SalePlanDB);
            DataSet dschem = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, StrSQL);
            lueDepartment.Properties.DataSource = dschem.Tables[0];
            DataSet ds = DBHelper.ExecuteDataset(DBHelper.ConnString, CommandType.Text, string.Format(string.Format("SELECT d.cDepName,cRef1 AS cRefType FROM (SELECT SD.cDepCode,SB.cDataValue AS cRef1 FROM {0}..SL_P_DeptRef SD LEFT JOIN  {1}..SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN {2}..SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId UNION ALL SELECT SD.cDepCode,SB1.cDataValue AS cRef2 FROM {3}..SL_P_DeptRef SD LEFT JOIN  {4}..SL_P_BaseData SB ON  SD.cRef1=SB.cDataId LEFT JOIN {5}..SL_P_BaseData SB1 ON SD.cRef2=SB1.cDataId ) AS tmp LEFT JOIN Department d ON tmp.cDepCode=d.cDepCode ", DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB, DBHelper.SalePlanDB)));
            luecRef.Properties.DataSource = ds.Tables[0];
        }
        
        private void checkdata()
        {
            if (string.IsNullOrEmpty(lueDepartment.EditValue.ToString()))
            {
                MessageBox.Show("部门为空，请选择部门");
                return;
            }
            if (string.IsNullOrEmpty(luecRef.EditValue.ToString()))
            {
                MessageBox.Show("参考值为空，请选择参考值");
                return;
            }
            if (string.IsNullOrEmpty(txtiYear.Text.ToString()))
            {
                MessageBox.Show("年份为空，请输入年份");
                return;
            }
            if (string.IsNullOrEmpty(cboiMonth.Text.ToString()))
            {
                MessageBox.Show("月份为空，请选择月份");
                return;
            }
        }

        private DataSet GetDataTable()
        {
            string StrSQL = "SELECT * FROM SL_P_Refset WHERE iYear='" + txtiYear.Text.ToString() + "'and cDepCode='" + lueDepartment.EditValue.ToString() + "'and iMonth between '" + cboiMonth.Text.ToString() + "' and '" + cboEndiMonth.Text.ToString() + "'and cRefType='" + luecRef.EditValue.ToString() + "'ORDER BY iMonth ASC ";
            DataSet ds = DBHelper.ExecuteDataset(DBHelper.ConnStrings, CommandType.Text, StrSQL);
            return ds;
        }


        private void btnsure_Click(object sender, EventArgs e)
        {
            checkdata();
            this.Dgv = GetDataTable();
            this.DialogResult = DialogResult.OK;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void frmQueryRefset_Load(object sender, EventArgs e)
        {
            Bindata();
           
        }


    }
}
