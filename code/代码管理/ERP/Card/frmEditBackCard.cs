using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmEditBackCard : Common.frmDialog
    {

        public int iPort, iRate, iDeviceID;

        public string strType = "";
        private string strSQL;
        public frmEditBackCard()
        {
            InitializeComponent();

        }

        private void ReadCard()
        {
            StringBuilder CardNo = new StringBuilder();
            StringBuilder CardName = new StringBuilder();
            int Money = 0, Times = 0, Ver = 0;
            IntPtr hPort = EastRiver.OpenCommPort(iPort, iRate);
            if (EastRiver.ReadICCard(hPort, CardNo, CardName, ref Money, ref Times, ref Ver) == true)
            {
                editControl1.SetValue(CardNo.ToString());
                string sSQL = "select F_ID,F_Name from t_Emp where F_CardNo = '" + CardNo.ToString() + "'";
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                DataSet dsEmp = myHelper.GetDs(sSQL);
                if (dsEmp.Tables[0].Rows.Count > 0)
                {
                    editControl4.SetValue(dsEmp.Tables[0].Rows[0]["F_ID"].ToString());
                    editControl2.SetValue(dsEmp.Tables[0].Rows[0]["F_Name"].ToString());
                }
            }
            EastRiver.CloseCommPort(hPort);
        }

        public override void New()
        {
            base.New();
            strSQL = "select * from t_BackCard where Aid = 0";
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
            ReadCard();
        }
       

    }
}
