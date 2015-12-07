using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmNetDevice : BaseClass.frmBase
    {
        private int iClockID = 1, iRate = 9600, iPort = 1;
        public int iFlag = 0;
        public frmNetDevice()
        {
            InitializeComponent();
            gridDevice.AutoGenerateColumns = false;
            DataBind();
        }

        private void DataBind()
        {
            string strSQL = @"select * from t_Device";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);
            gridDevice.DataSource = ds.Tables[0];
        }

        private void frmNetDevice_Shown(object sender, EventArgs e)
        {
            if (iFlag == 1)
            {
                tabControl1.SelectedIndex = 3;
            }
        }

        /// <summary>
        /// 读数据
        /// </summary>
        private void ReadData(object sender, EventArgs e)
        {
            Boolean Flag;
            ulong Rst;
            uint Count = 0,action;
            string Records;
            action = 0;
            Flag = true;
            IntPtr hPort = EastRiver.OpenCommPort(iPort,iRate);
            EastRiver.CallClock(hPort,iClockID);
            while (Flag == true)
            {
                Application.DoEvents();
                Rst = EastRiver.BatchReadRecordEx(hPort, action, 16, out Count, out Records);
                if (Rst != 0)
                    Flag = false;
                else
                {
                    /*
                    格式：卡号+TAB制表符+日期+TAB制表符+状态+TAB制表符+标志+','
                    Style: CardNo+TAB+DateTime+TAB+State+TAB+Flag(Flag=0 for OK)
                    */
                    if (Count > 0)
                    {
                        //lb_1.additem(Records);
                        action = 1; //如果确认记录保存成功时就=1，否则=0重读上一批,注意：每读完一批后就会删除这一批
                    }
                    else
                        Flag = false;
                }

            }
            EastRiver.ClosePortHandle(hPort);
            //Beep(2500,100)
        }

        private void ReadDeviceTime(object sender,EventArgs e)
        {
            IntPtr hPort;
            String TimeString = "";
            Boolean Right;
            hPort = EastRiver.OpenCommPort(1,9600);
            EastRiver.CallClock(hPort, 1);
            Right=EastRiver.ReadClockTimeString(hPort,out TimeString);
           if (Right == true)
           {
               tsMsg.Text = "设备时间:"+"20"+TimeString.Substring(1,2) + "年"+TimeString.Substring(3,2)+
               TimeString.Substring(5,2)+"月"+TimeString.Substring(5,2)+"日"+
               TimeString.Substring(7,2)+"时"+TimeString.Substring(9,2)+"分"+
               TimeString.Substring(9,2)+"秒";
           }

           EastRiver.ClosePortHandle(hPort);
        }

        private void SetDeviceTime(object sender, EventArgs e)
        {
            IntPtr hPort;
            String TimeString;
            Boolean Right;

            TimeString = DateTime.Now.Year.ToString() +
            DateTime.Now.Month.ToString().PadLeft(2, '0') +
            DateTime.Now.Day.ToString().PadLeft(2, '0') +
            DateTime.Now.Hour.ToString().PadLeft(2, '0') +
            DateTime.Now.Minute.ToString().PadLeft(2, '0') +
            DateTime.Now.Second.ToString().PadLeft(2, '0');
            hPort = EastRiver.OpenCommPort(1, 9600);
            EastRiver.CallClock(hPort, 1);
            Right = EastRiver.SetClockTimeString(hPort, TimeString);
            if (Right == true)
                tsMsg.Text = "设备时间设置成功";
            else
                tsMsg.Text = "设备时间设置失败";

            EastRiver.ClosePortHandle(hPort);
        }

        /// <summary>
        /// 设置管理卡
        /// </summary>
        private void SetSysCard(object sender, EventArgs e)
        {
            IntPtr hPort;
            Boolean Right;
            hPort = EastRiver.OpenCommPort(iPort, iRate);
            EastRiver.CallClock(hPort, iClockID);
            Right = EastRiver.SetManagerCard(hPort, "");
            if (Right == true)
                tsMsg.Text = "设置设备管理卡号成功";
            else
                tsMsg.Text = "设置设备管理卡号失败";
            EastRiver.ClosePortHandle(hPort);
        }

        private void SetDeviceNo(object sender, EventArgs e)
        {
            IntPtr hPort;
            hPort = EastRiver.OpenCommPort(iPort, iRate);
            EastRiver.CallClock(hPort, iClockID);

            int Clock_ID = EastRiver.GetClockID(hPort, iRate);

            frmSetDeviceNo F = new frmSetDeviceNo();
            F.textBox1.Text = Clock_ID.ToString();
            if (F.ShowDialog() == DialogResult.OK)
            {
                EastRiver.SetClockID(hPort, Convert.ToInt32(F.textBox1.Text));
            }
            F.Dispose();

        }

        private void SetDevicePsw(object sender, EventArgs e)
        {

            frmSetDevicePsw F = new frmSetDevicePsw();
            F.ShowDialog();
            F.Dispose();

        }

        private void gridDevice_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = gridDevice.CurrentRow;
            iClockID = Convert.ToInt32(row.Cells["F_ID"].Value.ToString());
            if (row.Cells["F_Port"].Value.ToString() == "COM1")
                iPort = 1;

            if (row.Cells["F_Port"].Value.ToString() == "COM2")
                iPort = 2;

            if (row.Cells["F_Port"].Value.ToString() == "COM3")
                iPort = 3;

            iRate = Convert.ToInt32(row.Cells["F_Rate"].Value);

        }
    }
}
