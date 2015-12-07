using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmEditLostCard : Common.frmDialog
    {

        public int iPort, iRate, iDeviceID;

        public string strType = "";
        private string strSQL;
        public frmEditLostCard()
        {
            InitializeComponent();
            string strSQL = "select * from t_Emp";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsEmp = myHelper.GetDs(strSQL);

            lupEmp.LookUpDataSource = dsEmp.Tables[0].DefaultView;
            lupEmp.LookUpDisplayField = "F_Name";
            lupEmp.LookUpKeyField = "F_ID";

        }


        public override void New()
        {
            base.New();
            strSQL = "select * from t_LostCard where Aid = 0";
            if (blnBind == false)
                BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            dr["F_Date"] = DateTime.Now;
            dr.EndEdit();
            binData.EndEdit();
            editControl1.Focus();
        }

        //public override void Edit(decimal decID)
        //{
        //    strSQL = "select * from t_BackCard where Aid = " + decID.ToString();
        //    BindData();
        //}

        protected override void BindData()
        {
            strSaveSlaverSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0].DefaultView;
            base.BindData();
        }

        /// <summary>
        /// 发卡
        /// </summary>
        /// <returns></returns>
        private bool SendCard()
        {
            return true;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        protected override bool Save()
        {
            if (SendCard() == false) return false;
            return base.Save();
        }

        private void sbReadCard_Click(object sender, EventArgs e)
        {

        }
       

    }
}
