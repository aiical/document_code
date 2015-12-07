using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmSetDevice : BaseClass.frmBase
    {
        public frmSetDevice()
        {
            InitializeComponent();
            BindDevice();
        }

        private void BindDevice()
        {
            string sSQL = "select * from t_Device";
            DataLib.DataHelper myHelper = new DataLib.DataHelper();
            DataSet ds = myHelper.GetDs(sSQL);
            gridDevice.DataSource = ds.Tables[0];
        }

        /// <summary>
        /// 读取设备参数
        /// </summary>
        private void ReadDeviceParm(int iPort,int iRate,int iClockID)
        {
            uint Mode, ExtraMode, SystemMode, RingMode;

            IntPtr hPort = EastRiver.OpenCommPort(iPort, iRate);
            EastRiver.CallClock(hPort, iClockID);

            EastRiver.ReadClockModeEx(hPort, out Mode, out ExtraMode, out SystemMode, out RingMode);

            switch (Mode)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
            }

            switch (ExtraMode)
            {
                case 1:
                    break;
            }

            switch (SystemMode)
            {
                case 1:
                    break;
            }

            switch (RingMode)
            {
                case 1:
                    break;
            }
        }

        /// <summary>
        /// 设置设备参数
        /// </summary>
        private void SetDeviceParm()
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            BindDevice();
        }

        private void viewDevice_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = viewDevice.GetDataRow(e.FocusedRowHandle);
            int iPort = Convert.ToInt32(dr["F_Port"].ToString().Replace("COM", ""));
            int iRate = Convert.ToInt32(dr["F_Rate"]);
            int iClockID = Convert.ToInt32(dr["F_ID"]);
            ReadDeviceParm(iPort, iRate, iClockID);
        }

    
    }
}
