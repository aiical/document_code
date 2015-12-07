using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace myControl
{
    //ö���ڼ��
    public enum DateFlag
    {
        ���� = 0,
        ���� = 1,
        ���� = 2,
        ���� = 3,
        ���� = 4,
        ���� = 5,
        ȫ�� = 6,
        �Զ��� = 7
    }

    /*
    //�¼������ඨ�壬����ͼ�����ʾ�ߴ�
    public class RefreshDateEventArgs : System.EventArgs
    {
        public int Width;
        public int Height;
        public RefreshDateEventArgs()
        {

        }
    }
     */ 

    //�¼����������RefreshDateEventArgs
    public delegate void RefreshDateEventHandler(object sender, System.EventArgs e);
    

    public partial class ucDate : UserControl
    {
        private event RefreshDateEventHandler eventHandler;//�¼�
        private DateFlag _DateTag;
        public DateTime dtStart;
        public DateTime dtEnd;

        public ucDate()
        {
            InitializeComponent();
            dtStart = DateTime.Today;
            dtEnd = DateTime.Today;  
        }

        private void ucDate_Load(object sender, EventArgs e)
        {
            cbxDate.SelectedIndex = DataLib.SysVar.intIndex;
            
            
            //dtpStart.Value = DateTime.Today;
            //dtpEnd.Value = DateTime.Today;
            
        }

        
        //�¼�����
        [
        Category("ImageZoomer"),
        Description("���ڼ�ı�ˢ��ʱ����")
        ]
        public event RefreshDateEventHandler RefreshDateChanged
        {
            add
            {
                eventHandler += value;
                btnRefresh.Click += new EventHandler(eventHandler);
                cbxDate.SelectedValueChanged += new EventHandler(eventHandler);
            }
            remove
            {
                eventHandler -= value;
            }
        }
        

        //[DefaultValue("����")]
        [Description("Ĭ���ڼ�"), Category("Behavior")]
        public DateFlag DateTag
        {
            get
            {
                return _DateTag;
            }
            set
            {
                _DateTag = value;
                this.cbxDate.SelectedIndex = (int)value;
                DateTime ldtStart, ldtEnd;
                int intYear, intMonth, intDay;

                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
                btnRefresh.Enabled = false;
                switch ((int)value)
                {
                    case 0:
                        dtpStart.Value = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 00:00:00");
                        dtpEnd.Value = Convert.ToDateTime(DateTime.Today.ToShortDateString() + " 23:59:59");
                        break;
                    case 1:
                        int intWeek = 0;
                        switch (DateTime.Today.DayOfWeek.ToString())
                        {
                            case "Monday":
                                intWeek = 0;
                                break;
                            case "Tuesday":
                                intWeek = 1;
                                break;
                            case "Wednesday":
                                intWeek = 2;
                                break;
                            case "Thursday":
                                intWeek = 3;
                                break;
                            case "Friday":
                                intWeek = 4;
                                break;
                            case "Saturday":
                                intWeek = 5;
                                break;
                            case "Sunday":
                                intWeek = 6;
                                break;
                        }
                        ldtStart = DateTime.Today.AddDays(-intWeek);
                        ldtEnd = ldtStart.AddDays(6);
                        dtpStart.Value = Convert.ToDateTime(ldtStart.ToShortDateString()+" 00:00:00");
                        dtpEnd.Value = Convert.ToDateTime(ldtEnd.ToShortDateString()+" 23:59:59");
                        break;
                    case 2:
                        dtpStart.Value = Convert.ToDateTime(DateTime.Now.AddDays(Convert.ToDouble((0 - Convert.ToInt16(DateTime.Now.DayOfWeek))) - 7).ToShortDateString() + " 00:00:00");
                        dtpEnd.Value = Convert.ToDateTime(DateTime.Now.AddDays(Convert.ToDouble((6 - Convert.ToInt16(DateTime.Now.DayOfWeek))) - 7).ToShortDateString() + " 23:59:59");
                        break;
                    case 3:
                        intYear = DateTime.Today.Year;
                        intMonth = DateTime.Today.Month;
                        intDay = DateTime.DaysInMonth(intYear, intMonth);
                        ldtStart = Convert.ToDateTime(intYear.ToString() + "-" + intMonth + "-" + "01");
                        ldtEnd = Convert.ToDateTime(intYear.ToString() + "-" + intMonth + "-" + intDay);  
                        dtpStart.Value = Convert.ToDateTime(ldtStart.ToShortDateString()+" 00:00:00");
                        dtpEnd.Value = Convert.ToDateTime(ldtEnd.ToShortDateString()+" 23:59:59");
                        break;
                    case 4:
                        intYear = DateTime.Today.AddMonths(-1).Year;
                        intMonth = DateTime.Today.AddMonths(-1).Month;
                        intDay = DateTime.DaysInMonth(intYear,intMonth);
                        ldtStart = Convert.ToDateTime(intYear.ToString() + "-" + intMonth + "-" + "01");
                        ldtEnd = Convert.ToDateTime(intYear.ToString() + "-" + intMonth + "-" + intDay);
                        dtpStart.Value = Convert.ToDateTime(ldtStart.ToShortDateString()+" 00:00:00");
                        dtpEnd.Value = Convert.ToDateTime(ldtEnd.ToShortDateString()+" 23:59:59");
                        break;
                    case 5:
                        intYear = DateTime.Today.Year;
                        ldtStart = Convert.ToDateTime(intYear.ToString() + "-01-01");
                        ldtEnd = Convert.ToDateTime(intYear.ToString() + "-12-31");
                        dtpStart.Value = Convert.ToDateTime(ldtStart.ToShortDateString()+" 00:00:00");
                        dtpEnd.Value = Convert.ToDateTime(ldtEnd.ToShortDateString()+" 23:59:59");
                        break;
                    case 6:
                        dtpStart.Value = Convert.ToDateTime("1900-01-01");
                        dtpEnd.Value = Convert.ToDateTime("2049-12-31");
                        break;
                    case 7:
                        dtpStart.Enabled = true;
                        dtpEnd.Enabled = true;
                        btnRefresh.Enabled = true;
                        break;            
                }
                dtStart = dtpStart.Value;
                dtEnd= dtpEnd.Value;
            }
        }

        private void cbxDate_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cbxDate.SelectedIndex)
            {
                case 0:
                    this.DateTag = DateFlag.����; 
                    break;
                case 1:
                    this.DateTag = DateFlag.����;
                    break;
                case 2:
                    this.DateTag = DateFlag.����;
                    break;
                case 3:
                    this.DateTag = DateFlag.����;
                    break;
                case 4:
                    this.DateTag = DateFlag.����;
                    break;
                case 5:
                    this.DateTag = DateFlag.����;
                    break;
                case 6:
                    this.DateTag = DateFlag.ȫ��;
                    break;
                case 7:
                    this.DateTag = DateFlag.�Զ���;
                    break;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dtStart = Convert.ToDateTime(dtpStart.Value.ToShortDateString() + " 00:00:00");
            dtEnd = Convert.ToDateTime(dtpEnd.Value.ToShortDateString() + " 23:59:59");
        }

    }
}
