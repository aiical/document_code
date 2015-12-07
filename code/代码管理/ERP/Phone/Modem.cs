using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.Windows.Forms;

namespace Phone
{

    public class Modem : IModem
    {
        public event EventHandler<RingEventArgs> Ring;
        System.IO.Ports.SerialPort port = null;

        public Modem()
        {
            port = new System.IO.Ports.SerialPort();
            port.PortName = Settings.Instance.GetValue("PortName", "COM1");
            port.BaudRate = Settings.Instance.GetValue("BaudRate", 9600);
            port.DataBits = 8;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.ReadTimeout =
                port.WriteTimeout = 1000;//1S

            port.ReadBufferSize =
                port.WriteBufferSize = 1024;//1K

            port.Handshake = Handshake.None;
            port.ReceivedBytesThreshold = 2;
            port.RtsEnable = true;
            port.DtrEnable = true;
            port.NewLine = "\r";

            this.port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(port_DataReceived);
        }

        void port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            //Regex r = new Regex(@"DATE\s*=\s*[0-9]*");
            //Regex r = new Regex(@"TIME\s*=\s*[0-9]*");

            string phoneNumber = this.port.ReadExisting();
            Regex r = new Regex(@"NMBR\s*=\s*[0-9]*");
            Match m = r.Match(phoneNumber);

            string result = string.Empty;
            if (m != null && m.Success)
            {
                result = m.Value;
                result = result.Substring(result.IndexOf("=") + 1).Trim();
            }
            if (string.IsNullOrEmpty(result))
                return;
            if (Ring != null)
            {
                RingEventArgs eventArgs = new RingEventArgs();
                eventArgs.PhoneNumber = result;
                foreach (EventHandler<RingEventArgs> handler in Ring.GetInvocationList())
                {
                    handler.Invoke(this, eventArgs);
                    if (eventArgs.Handled)
                        break;
                }
            }
        }

        public void Open()
        {
            if (!this.port.IsOpen)
                this.port.Open();
            this.port.WriteLine("AT\r");
            System.Threading.Thread.Sleep(500);
            string[] commandList = Settings.Instance.SectionValues("CID");
            string result = string.Empty;
            foreach (string command in commandList)
            {
                this.port.WriteLine(command + "\r");
                System.Threading.Thread.Sleep(500);
            }
            //this.port.WriteLine("AT+VCID=1\r");
            //System.Threading.Thread.Sleep(500);
//            if (!SupportAT)
//                throw new Exception("设备不支持AT指令");
//            if (!SupportCID)
//                throw new Exception("设备不支持来显");
        }
        public void Close()
        {
            if (this.port.IsOpen)
                this.port.Close();
        }
        public bool SupportAT
        {
            get
            {
                this.port.WriteLine("AT\r");
                System.Threading.Thread.Sleep(500);
                string result = this.port.ReadExisting();
                return result.ToUpper().Contains("OK");
            }
        }
        public bool SupportCID
        {
            get
            {
                string[] commandList = Settings.Instance.SectionValues("CID");
                string result = string.Empty;
                foreach (string command in commandList)
                {
                    this.port.WriteLine(command+"\r");
                    System.Threading.Thread.Sleep(500);
                    result = this.port.ReadExisting();
                    if (result.ToUpper().Contains("OK"))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
