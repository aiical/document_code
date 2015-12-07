using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmEditSendCard : Common.frmDialog
    {

        public int iPort, iRate, iDeviceID;

        public string strType = "";
        private string strSQL;
        public frmEditSendCard()
        {
            InitializeComponent();

            string strSQL = "select F_ID,F_Name,dbo.fn_GetPy(F_Name) as F_Spell from t_Emp";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsEmp = myHelper.GetDs(strSQL);

            lupEmp.LookUpDataSource = dsEmp.Tables[0].DefaultView;
            lupEmp.LookUpDisplayField = "F_ID";
            lupEmp.LookUpKeyField = "F_ID";

            lupEmp.LookUpControl.Properties.AutoSearchColumnIndex = 2;
            lupEmp.LookUpControl.Properties.SortColumnIndex = 2;
            lupEmp.LookUpControl.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
        }

        public override void New()
        {
            base.New();
            strSQL = "select * from t_SendCard where F_ID = ''";
            if (blnBind == false)
                BindData();
            DataRow dr = ((DataRowView)binData.AddNew()).Row;
            dr.BeginEdit();
            dr["F_Date"] = DateTime.Now;
            dr["F_Format"] = "标准IC卡格式";
            dr.EndEdit();
            binData.EndEdit();
            editControl1.Focus();
        }

        public override void Edit(string strID)
        {
            base.Edit(strID);
            strSQL = "select * from t_SendCard where F_ID = '" + strID + "'";
            BindData();
        }

        protected override void BindData()
        {
            strSaveSlaverSQL = strSQL;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            binData.DataSource = ds.Tables[0].DefaultView;
            base.BindData();
        }

        protected override void SaveData()
        {
            if (SendCard() == true)
               base.SaveData();
        }

        /// <summary>
        /// 发卡
        /// </summary>
        /// <returns></returns>
        private bool SendCard()
        {
            if (lupEmp.GetValue() == DBNull.Value)
            {
                MessageBox.Show(this,"工号不能为空!","提示");
                lupEmp.Focus();
                return false;
            }

            if (editControl1.GetValue() == DBNull.Value)
            {
                MessageBox.Show(this,"卡号不能为空!","提示");
                editControl1.Focus();
                return false;
            }

            IntPtr hPort = EastRiver.OpenCommPort(iPort, iRate);
            if (EastRiver.SetAllowedCard(hPort, editControl1.GetValue().ToString(), lupEmp.GetValue().ToString(), editControl1.GetValue().ToString()) == true)
            {
                string strSQL = "update t_Emp set F_CardNo = '" + editControl1.GetValue().ToString() + "' where F_ID = '" + lupEmp.GetValue().ToString() + "'";
                DataLib.DataHelper myHelper = new DataLib.DataHelper();
                if (myHelper.ExecuteSQL(strSQL) == 0)
                    return true;
                else
                    return false;
            }
            else
                return false;

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

        private void btnRead_Click(object sender, EventArgs e)
        {
            //Int64 iSerialNo = 0;
            StringBuilder CardNo = new StringBuilder();
            StringBuilder CardName = new StringBuilder();
            int money = 0,Times = 0,Ver = 2;
            IntPtr hPort = EastRiver.OpenCommPort(iPort, iRate);
            EastRiver.ReadICCard(hPort, CardNo, CardName, ref money, ref Times, ref Ver);
            //EastRiver.ReadICCardEx(hPort, sCardNo, sCardName, sPwd, ref money, ref Times, ref day_con, ref day_times, ref c_month,
             //                      ref c_day, ref c_flag, ref groupstation, ref groupid, 0);
            //if (EastRiver.ReadICCardSerialNo(hPort, ref iSerialNo, true) == true)
            //{
            editControl1.SetValue(CardNo.ToString());
            //}
            EastRiver.CloseCommPort(hPort);

        }

        private void lupEmp_ValueChanged(object sender, EventArgs e)
        {
            if (lupEmp.GetValue() == DBNull.Value) return;
            DataRow dr = ((DataRowView)lupEmp.lupEdit.Properties.GetDataSourceRowByKeyValue(lupEmp.lupEdit.Text)).Row;
            editControl2.SetValue(dr["F_Name"].ToString());
        }
       

    }
}
