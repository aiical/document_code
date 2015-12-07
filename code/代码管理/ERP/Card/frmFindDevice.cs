using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Card
{
    public partial class frmFindDevice : BaseClass.frmBase
    {
        public DataRow drDevice;

        public frmFindDevice()
        {
            InitializeComponent();
        }

        private void FindDevice()
        {

            int iPort = cbPort.SelectedIndex + 1;

            int iClockID = 0;

            int iModel = 0,cls = 0;

            double ver = 0;

            IntPtr hPort = EastRiver.OpenCommPort(iPort, Convert.ToInt32(cbRate.Text));

            int iBegin = Convert.ToInt32(txtBegin.Text), iEnd = Convert.ToInt32(txtEnd.Text),iCnt = 0;

            for (int i = iBegin; i < iEnd; i++)
            {
                if (EastRiver.CallClock(hPort, Convert.ToInt32(i)) == true)
                {
                    EastRiver.GetClockModel(hPort, ref iModel, ref ver, ref cls);
                    iClockID = i;
                    iCnt++;
                }
            }

            MessageBox.Show("搜索到"+iCnt.ToString()+"台设备!", "提示");

            if (drDevice != null && iCnt > 0)
            {
                if (cls == 0)
                    drDevice["F_Model"] = "ER-" + iModel.ToString() + "D";
                else
                    drDevice["F_Model"] = "ER-" + iModel.ToString() + "C";
                drDevice["F_Port"] = cbPort.Text;
                
                drDevice["F_Rate"] = Convert.ToInt32(cbRate.Text);
                drDevice["F_ID"] = iClockID.ToString().PadLeft(2,'0');
            }
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            lbFlag.Visible = true;
            btnOK.Enabled = false;
            this.Update();
            try
            {
                FindDevice();
            }
            finally
            {
                btnOK.Enabled = true;
                lbFlag.Visible = false;
            }
        }
    }
}
