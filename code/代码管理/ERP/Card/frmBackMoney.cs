using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmBackMoney : BaseClass.frmBase
    {
        public frmBackMoney()
        {
            InitializeComponent();

            RealGrid.AutoGenerateColumns = false;

            string strSQL = "select * from t_Device";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsDevice = myHelper.GetDs(strSQL);

            lupDevice.Properties.DataSource = dsDevice.Tables[0];
        }

        private void DataBind()
        {
            string strSQL = @"select a.*,b.F_Name as F_EmpName,c.F_Name as F_Dept from t_BackMoney a
                              left join t_Emp b
                              on a.F_ID = b.F_ID
                              left join t_Class c
                              on c.F_ID = b.F_Type";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);

            RealGrid.DataSource = ds.Tables[0];

        }

        private void Del()
        {
            if (RealGrid.CurrentRow.Index < 0) return;
            if (MessageBox.Show(this, "真的要删除本卡记录吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            DataGridViewRow dr = RealGrid.CurrentRow;
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            if (myHelper.ExecuteSQL("delete from t_BackMoney where F_CardNo = '" + dr.Cells["F_CardNo"].Value.ToString() + "' and F_Date = '" + dr.Cells["F_Date"].Value.ToString() + "'") == 0)
                RealGrid.Rows.Remove(RealGrid.CurrentRow);
        }

        private void Pick(object sender, EventArgs e)
        {
            if (lupDevice.EditValue == null)
            {
                MessageBox.Show(this,"请先选择设备!","提示");
                lupDevice.Focus();
                return;
            }

            //DataLib.DataHelper myHelper = new DataLib.DataHelper();
            //myHelper.ExecuteSQL("delete from t_RealCard");

            DataRow dr = ((DataRowView)lupDevice.Properties.GetDataSourceRowByKeyValue(lupDevice.EditValue)).Row;
            int iDeviceID = Convert.ToInt32(dr["F_ID"]);
            int iPort = 1;
            switch (dr["F_Port"].ToString())
            {
                case "COM1":
                    iPort = 1;
                    break;
                case "COM2":
                    iPort = 2;
                    break;
                case "COM3":
                    iPort = 3;
                    break;
                case "COM4":
                    iPort = 4;
                    break;
                case "COM5":
                    iPort = 5;
                    break;
            }
            int iRate = Convert.ToInt32(dr["F_Rate"]);

            frmEditBackMoney F = new frmEditBackMoney();
            F.iDeviceID = iDeviceID;
            F.iPort = iPort;
            F.iRate = iRate;
            F.New();
            if (F.ShowDialog() == DialogResult.OK)
                DataBind();
            F.Dispose();

            /*
            string Data = "";
            Card.EastRiver.ReadData(iPort, iRate, iDeviceID, ref Data);
            if (Data == null) return;
            if (Data == "") return;
            Data = Data.Substring(0, Data.Length - 1);
            string[] sRecord = Data.Split(';');

            foreach (string s in sRecord)
            {

                string[] sData = s.Split('#');

                if (sData.Length > 0)
                {
                    string sCardNo = sData[1];
                    string sTime = sData[2];

                    int iYear = Convert.ToInt32(sTime.Substring(0, 4));
                    int iMonth = Convert.ToInt32(sTime.Substring(4, 2));
                    int iDay = Convert.ToInt32(sTime.Substring(6, 2));
                    int iHour = Convert.ToInt32(sTime.Substring(8, 2));
                    int iMinute = Convert.ToInt32(sTime.Substring(10, 2));
                    int iSencond = Convert.ToInt32(sTime.Substring(12, 2));

                    DateTime dt = new DateTime(iYear, iMonth, iDay, iHour, iMinute, iSencond);


                    myHelper.ExecuteSQL("insert into t_RealCard(F_CardNo,F_Time) values('"+sCardNo+"','"+dt.ToString()+"')");

                }
            }
            */
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Del();
        }

        private void frmBackCard_Load(object sender, EventArgs e)
        {

        }
    }
}
