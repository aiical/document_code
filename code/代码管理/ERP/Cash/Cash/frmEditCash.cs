using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cash
{
    public partial class frmEditCash : BaseClass.frmBase
    {
        public DateTime dtDate = Convert.ToDateTime("1900-1-1");
        public decimal decID = 0;
        public bool bFlag = false;
        public frmEditCash()
        {
            InitializeComponent();
        }

        private void DataBind()
        {
            string strSQL = "select * from t_DayAccount where F_Date = '"+dtDate.ToString()+"' and F_DayOrder = "+decID.ToString();
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binEdit.DataSource = ds.Tables[0];
            //lupControl1.BindData();
            dateControl1.BindData();
            spinControl1.BindData();
            spinControl3.BindData();
            spinControl4.BindData();
            //spinControl5.BindData();
            editControl1.BindData();
            editControl2.BindData();
            if (bFlag == true)
            {
                New();
            }
        }

        private void New()
        {
            DataRow dr = ((DataRowView)binEdit.AddNew()).Row;
            dr["F_Date"] = DateTime.Today;
            dr["F_DayOrder"] = GetMaxID();
            dr["F_Opertor"] = DataLib.SysVar.strUName;
            dr.EndEdit();
            binEdit.EndEdit();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private bool Save()
        {
            if (Convert.ToDecimal(spinControl3.GetValue()) == 0 && Convert.ToDecimal(spinControl4.GetValue()) == 0)
            {
                MessageBox.Show(this, "借方金额与贷方金额不能同时为零！","提示");
                return false;
            }

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsSave = ((DataTable)binEdit.DataSource).DataSet;

            if (myHelper.SaveData(dsSave, "select * from t_DayAccount where F_Date = '" + dtDate.ToString() + "' and F_DayOrder = " + decID.ToString()) == 0)
            {
                dsSave.AcceptChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEditCash_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
                DataBind();
        }

        private decimal GetMaxID()
        {
            string strSQL = "select isnull(max(F_DayOrder),0)+1 from t_DayAccount where F_Date = '" + DateTime.Today.ToString()+ "'";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            return Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
        }

        private void btnSelMemo_Click(object sender, EventArgs e)
        {
            Finance.frmAbstract myAbstract = new Finance.frmAbstract();
            if (myAbstract.ShowDialog() == DialogResult.OK)
            {
                DataRow drSource = myAbstract.gvAbstract.GetDataRow(myAbstract.gvAbstract.FocusedRowHandle);

                DataRow dr = ((DataRowView)binEdit.Current).Row;
                dr.BeginEdit();
                dr["F_Remark"] = drSource["F_Remark"];
                dr.EndEdit();
                binEdit.EndEdit();
            }
            myAbstract.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Save() == true)
            {
                New();
            }
        }

    }
}

