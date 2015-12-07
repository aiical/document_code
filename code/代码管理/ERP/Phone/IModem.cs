using System;
using System.Collections.Generic;
using System.Text;

namespace Phone
{
    public interface IModem
    {
        void Open();
        void Close();
        bool SupportAT
        {
            get;
        }
        bool SupportCID
        {
            get;
        }
        event EventHandler<RingEventArgs> Ring;
    }
    public class RingEventArgs : EventArgs
    {
        private string phoneNumber = string.Empty;
        private DateTime phoneTime = Convert.ToDateTime("1900-1-1");
        private bool handled = false;

        public bool Handled
        {
            get { return handled; }
            set { handled = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public DateTime PhoneTime
        {
            get { return phoneTime; }
            set { phoneTime = value; }
        }
    }
}
