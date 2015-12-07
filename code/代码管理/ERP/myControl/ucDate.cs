using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace myControl
{
    //枚举期间段
    public enum DateFlag
    {
        当天 = 0,
        本周 = 1,
        上周 = 2,
        本月 = 3,
        上月 = 4,
        本年 = 5,
        全部 = 6,
        自定义 = 7
    }

    /*
    //事件数据类定义，报告图象的显示尺寸
    public class RefreshDateEventArgs : System.EventArgs
    {
        public int Width;
        public int Height;
        public RefreshDateEventArgs()
        {

        }
    }
     */ 

    //事件代表的声明RefreshDateEventArgs
    public delegate void RefreshDateEventHandler(object sender, System.EventArgs e);
    

    public partial class ucDate : UserControl
    {
        private event RefreshDateEventHandler eventHandler;//事件
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

        
        //事件属性
        [
        Category("ImageZoomer"),
        Description("当期间改变刷新时发生")
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
        

        //[DefaultValue("当天")]
        [Description("默认期间"), Category("Behavior")]
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
                    this.DateTag = DateFlag.当天; 
                    break;
                case 1:
                    this.DateTag = DateFlag.本周;
                    break;
                case 2:
                    this.DateTag = DateFlag.上周;
                    break;
                case 3:
                    this.DateTag = DateFlag.本月;
                    break;
                case 4:
                    this.DateTag = DateFlag.上月;
                    break;
                case 5:
                    this.DateTag = DateFlag.本年;
                    break;
                case 6:
                    this.DateTag = DateFlag.全部;
                    break;
                case 7:
                    this.DateTag = DateFlag.自定义;
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
