using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmRealPick : BaseClass.frmBase
    {
        public frmRealPick()
        {
            InitializeComponent();

            RealGrid.AutoGenerateColumns = false;
            string strSQL = "select * from t_Device";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet dsDevice = myHelper.GetDs(strSQL);

            lupDevice.Properties.DataSource = dsDevice.Tables[0];

            DataBind();
        }

        private void DataBind()
        {
            string strSQL = @"select *,
                               case when CONVERT(varchar(10),F_Time,114) >= CONVERT(varchar(10),F_b1,114) and CONVERT(varchar(10),F_Time,114) <= CONVERT(varchar(10),F_e1,114) then F_Time else NULL end as F_s1, 
                               case when CONVERT(varchar(10),F_Time,114) >= CONVERT(varchar(10),F_t1,114) and CONVERT(varchar(10),F_Time,114) <= CONVERT(varchar(10),F_f1,114) then F_Time else NULL end as F_x1,
                               case when CONVERT(varchar(10),F_Time,114) >= CONVERT(varchar(10),F_b2,114) and CONVERT(varchar(10),F_Time,114) <= CONVERT(varchar(10),F_e2,114) then F_Time else NULL end as F_s2, 
                               case when CONVERT(varchar(10),F_Time,114) >= CONVERT(varchar(10),F_t2,114) and CONVERT(varchar(10),F_Time,114) <= CONVERT(varchar(10),F_f2,114) then F_Time else NULL end as F_x2,  
                               case when CONVERT(varchar(10),F_Time,114) >= CONVERT(varchar(10),F_b3,114) and CONVERT(varchar(10),F_Time,114) <= CONVERT(varchar(10),F_e3,114) then F_Time else NULL end as F_s3, 
                               case when CONVERT(varchar(10),F_Time,114) >= CONVERT(varchar(10),F_t3,114) and CONVERT(varchar(10),F_Time,114) <= CONVERT(varchar(10),F_f3,114) then F_Time else NULL end as F_x3,  
                               case when CONVERT(varchar(10),F_Time,114) >= CONVERT(varchar(10),F_b4,114) and CONVERT(varchar(10),F_Time,114) <= CONVERT(varchar(10),F_e4,114) then F_Time else NULL end as F_s4, 
                               case when CONVERT(varchar(10),F_Time,114) >= CONVERT(varchar(10),F_t4,114) and CONVERT(varchar(10),F_Time,114) <= CONVERT(varchar(10),F_f4,114) then F_Time else NULL end as F_x4,  
                               case when CONVERT(varchar(10),F_Time,114) >= CONVERT(varchar(10),F_b5,114) and CONVERT(varchar(10),F_Time,114) <= CONVERT(varchar(10),F_e5,114) then F_Time else NULL end as F_s5, 
                               case when CONVERT(varchar(10),F_Time,114) >= CONVERT(varchar(10),F_t5,114) and CONVERT(varchar(10),F_Time,114) <= CONVERT(varchar(10),F_f5,114) then F_Time else NULL end as F_x5
                             from 
                            (
                                select d.F_qd1,DATEADD(MI,-F_qq1,d.F_sb1) as F_b1,DATEADD(MI,F_qq1,d.F_sb1) as F_e1, 
                                       d.F_qt1,DATEADD(MI,-F_tc1,d.F_xb1) as F_t1,DATEADD(MI,F_tc1,d.F_xb1) as F_f1, 
                                       d.F_qd2,DATEADD(MI,-F_qq2,d.F_sb2) as F_b2,DATEADD(MI,F_qq2,d.F_sb2) as F_e2, 
                                       d.F_qt2,DATEADD(MI,-F_tc2,d.F_xb2) as F_t2,DATEADD(MI,F_tc2,d.F_xb2) as F_f2,
                                       d.F_qd3,DATEADD(MI,-F_qq3,d.F_sb3) as F_b3,DATEADD(MI,F_qq3,d.F_sb3) as F_e3, 
                                       d.F_qt3,DATEADD(MI,-F_tc3,d.F_xb3) as F_t3,DATEADD(MI,F_tc3,d.F_xb3) as F_f3,
                                       d.F_qd4,DATEADD(MI,-F_qq4,d.F_sb4) as F_b4,DATEADD(MI,F_qq4,d.F_sb4) as F_e4, 
                                       d.F_qt4,DATEADD(MI,-F_tc4,d.F_xb4) as F_t4,DATEADD(MI,F_tc4,d.F_xb4) as F_f4,
                                       d.F_qd5,DATEADD(MI,-F_qq5,d.F_sb5) as F_b5,DATEADD(MI,F_qq5,d.F_sb5) as F_e5, 
                                       d.F_qt5,DATEADD(MI,-F_tc5,d.F_xb5) as F_t5,DATEADD(MI,F_tc5,d.F_xb5) as F_f5,
                                  a.*,b.F_ID as F_EmpID,b.F_Name as F_EmpName,c.F_Name as F_Dept from t_RealCard a
                                  left join t_Emp b
                                  on a.F_CardNo = b.F_CardNo
                                  left join t_Class c
                                  on c.F_ID = b.F_Type
                                  left join t_SetClass d
                                  on b.F_KQClass = d.F_ID
                              ) as tp  
                              where F_Flag = 0 order by F_EmpID,F_Time";

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);

            RealGrid.DataSource = ds.Tables[0];

        }

        private void ChangeToKQ()
        {
            if (MessageBox.Show(this, "真的要将刷卡数据转入考勤以供分析吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataTable dt = (DataTable)RealGrid.DataSource;
            foreach (DataRow dr in dt.Rows)
            {      
                bool bqd1 = Convert.ToBoolean(dr["F_qd1"]);
                bool bqt1 = Convert.ToBoolean(dr["F_qt1"]);
                bool bqd2 = Convert.ToBoolean(dr["F_qd2"]);
                bool bqt2 = Convert.ToBoolean(dr["F_qt2"]);
                bool bqd3 = Convert.ToBoolean(dr["F_qd3"]);
                bool bqt3 = Convert.ToBoolean(dr["F_qt3"]);
                bool bqd4 = Convert.ToBoolean(dr["F_qd4"]);
                bool bqt4 = Convert.ToBoolean(dr["F_qt4"]);
                bool bqd5 = Convert.ToBoolean(dr["F_qd5"]);
                bool bqt5 = Convert.ToBoolean(dr["F_qt5"]);

                if (bqd1 == true && dr["F_s1"] != DBNull.Value)
                    DoKQ(dr, "F_Begin1","F_s1");

                if (bqt1 == true && dr["F_x1"] != DBNull.Value)
                    DoKQ(dr, "F_End1", "F_x1");

                if (bqd2 == true && dr["F_s2"] != DBNull.Value)
                    DoKQ(dr, "F_Begin2", "F_s2");

                if (bqt2 == true && dr["F_x2"] != DBNull.Value)
                    DoKQ(dr, "F_End2", "F_x2");

                if (bqd3 == true && dr["F_s3"] != DBNull.Value)
                    DoKQ(dr, "F_Begin3", "F_s3");

                if (bqt3 == true && dr["F_x3"] != DBNull.Value)
                    DoKQ(dr, "F_End3", "F_x3");

                if (bqd4 == true && dr["F_s4"] != DBNull.Value)
                    DoKQ(dr, "F_Begin4", "F_s4");

                if (bqt4 == true && dr["F_x4"] != DBNull.Value)
                    DoKQ(dr, "F_End4", "F_x4");

                if (bqd5 == true && dr["F_s5"] != DBNull.Value)
                    DoKQ(dr, "F_Begin5", "F_s5");

                if (bqt5 == true && dr["F_x5"] != DBNull.Value)
                    DoKQ(dr, "F_End5", "F_x5");

            }

            DataBind();

        }


        private void DoKQ(DataRow dr,string dField,string tField)
        {
            DateTime dtTime = Convert.ToDateTime(dr["F_Time"]);


            string strSQL = @" if not Exists (select * from t_CardRecord
                                    where YEAR(F_Date) = " + dtTime.Year.ToString() + @"
                                    and MONTH(F_Date) = " + dtTime.Month.ToString() + @"
                                    and DAY(F_Date) = " + dtTime.Day.ToString() + @"
                                    and F_ID = '" + dr["F_EmpID"].ToString() + @"')
                                   begin
                                     insert into t_CardRecord(F_Date,F_ID," + dField + ") values('" + dtTime.ToString() + "','" + dr["F_EmpID"].ToString() + "','" + dr[tField].ToString() + @"')
                                   end
                                   else
                                   begin
                                     update t_CardRecord set " + dField + " = '" + dr[tField].ToString() + "' where YEAR(F_Date) = " + dtTime.Year.ToString() + @"
                                     and MONTH(F_Date) = " + dtTime.Month.ToString() + @"
                                     and DAY(F_Date) = " + dtTime.Day.ToString() + @"
                                     and F_ID = '" + dr["F_EmpID"].ToString() + @"'
                                   end  

                                   update t_RealCard set F_Flag = 1 where Aid = " + dr["Aid"].ToString();

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            myHelper.ExecuteSQL(strSQL);
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

            DataLib.DataHelper myHelper = new DataLib.DataHelper();
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


                    myHelper.ExecuteSQL("insert into t_RealCard(F_CardNo,F_Time,F_DeviceID,F_Flag) values('" + sCardNo + "','" + dt.ToString() + "','" + iDeviceID.ToString()+ "',0)");

                }
            }

            DataBind();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            ChangeToKQ();
        }
    }
}
