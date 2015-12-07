using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Card
{
    public class EastRiver
    {
        //打开串行端口
        [DllImport("EastRiver")]
        public static extern IntPtr OpenCommPort(int Port, int BaudRate);

        //关闭已经打开的端口号
        [DllImport("EastRiver")]
        public static extern bool CloseCommPort(IntPtr Port);

        //关闭设置
        [DllImport("EastRiver")]
        public static extern bool ClosePortHandle(IntPtr hPort);

        // 初始化端口设置, 在打开端口和联机时自动调用, 除非需要修改端口参数
        // 一般不需要自己调用
        [DllImport("EastRiver")]
        public static extern bool InitCommPort(IntPtr hPort, Double BaudRate, Byte Parity);

        //设置校验方式
        [DllImport("EastRiver")]
        public static extern bool SetPortParity(IntPtr hPort, Byte Parity);

        //设置设备号
        [DllImport("EastRiver")]
        public static extern bool SetClockID(IntPtr hPort, Int32 new_id);

        //获取设备号
        [DllImport("EastRiver")]
        public static extern int GetClockID(IntPtr Port, Int32 BaudRate);

         //获取机具型号
        [DllImport("EastRiver")]
        public static extern bool GetClockModel(IntPtr hPort,ref int Model,ref double Ver,ref int cls);

        //打开端口及联接设备(包含 OpenCommPort )
        [DllImport("EastRiver")]
        public static extern IntPtr ConnectClock(Int32 hPort, Int32 BaudRate, Int32 clock_id);

        /// <summary>
        /// 打开设置窗口
        /// </summary>
        /// <param name="strCon"></param>
        /// <returns></returns>
        [DllImport("CardLib")]
        public static extern bool ShowForm(IntPtr handle, string strCon,int Flag);

        //断开联接及关闭端口句柄
        [DllImport("EastRiver")]
        public static extern bool DisConnectClock(IntPtr hPort);

        //设置机号长度字节数，默认值是1，只能设为1或2，表示一个字节(机号从0到255),二个字节(机号从0到65535)
        [DllImport("EastRiver")]
        public static extern bool SetClockIDLen(Int32 Len);

        //检查指定的机器是否在联机状态
        [DllImport("EastRiver")]
        public static extern bool CheckConnectClock(IntPtr hPort, Int32 clock_id);

        //显式联机命令
        [DllImport("EastRiver")]
        public static extern bool CallClock(IntPtr hPort, Int32 clock_id);

        //      读IC卡序列号
        [DllImport("EastRiver")]
        public static extern bool ReadICCardSerialNo(IntPtr hPort, ref Int64 SerialNo, bool LongSn);

        //读记录
        [DllImport("CardLib")]
        public static extern int ReadData(int Port, int BaudRate, int Clock_id, ref string Data);

        //读IC卡信息
        [DllImport("EastRiver")]
        public static extern bool ReadICCard(IntPtr hPort, StringBuilder CardNo, StringBuilder CardName, ref int Money, ref int Times, ref int Ver);

        //读IC卡信息包含卡分组标识
        [DllImport("EastRiver")]
        public static extern bool ReadAllICCard(IntPtr hPort, string CardNo, string CardName, out UInt32 Money, out UInt32 Times, out Int32 GroupStation, out Int32 GroupId, Int32 Ver);

        //写IC卡信息
        [DllImport("EastRiver")]
        public static extern bool WriteICCard(IntPtr hPort, string CardNo, string CardName, out UInt32 Money, out UInt32 Times, Int32 Ver);

        //写IC卡信息包含卡分组标识
        [DllImport("EastRiver")]
        public static extern bool WriteAllICCard(IntPtr hPort, string CardNo, string CardName, out UInt32 Money, out UInt32 Times, out Int32 GroupStation, out Int32 GroupId, Int32 Ver, bool MatchCard);

        //扩展读IC卡信息包含卡分组标识(ER-690卡)
        [DllImport("EastRiver")]
        public static extern bool ReadICCardEx(IntPtr hPort, string CardNo, string CardName, string pwd, ref int Money, ref int Times,
                      ref int day_consumed, ref int day_times, ref int c_month, ref int c_day, ref int c_flag, ref int GroupStation, ref int GroupId, int CardStyle);

        //扩展写IC卡信息包含卡分组标识(ER-690卡)
        [DllImport("EastRiver")]
        public static extern bool WriteICCardEx(IntPtr hPort, string CardNo, string CardName, string pwd, Int32 Money, Int32 Times,
                      Int32 day_consumed, Int32 day_times, Int32 c_month, Int32 c_day, Int32 c_flag, Int32 GroupStation, Int32 GroupId, Int32 CardStyle, bool MatchCard);

        //写指定卡号的卡信息
        [DllImport("EastRiver")]
        public static extern bool WriteMatchICCard(IntPtr hPort, string CardNo, string CardName, Int32 Money, Int32 Times, Int32 Ver, bool blank);

        //清除卡上内容(包含指定Block的整个扇区清除)
        [DllImport("EastRiver")]
        public static extern bool ClearICCard(IntPtr hPort, Int32 block);

        //设置设备的允许考勤卡(白名单卡带6个字符工号或姓名)
        [DllImport("EastRiver")]
        public static extern bool SetAllowedCard(IntPtr hPort,string card, string empid, string EmpName);

        //删除设备的允许考勤卡(白名单卡)
        [DllImport("EastRiver")]
        public static extern bool DeleteAllowedCard(IntPtr hPort,string card);

        //设置定值消费金额
        [DllImport("EastRiver")]
        public static extern bool SetFixPrice(IntPtr hPort, UInt32 Value);

        //读取定值消费金额
        [DllImport("EastRiver")]
        public static extern bool ReadFixPrice(IntPtr hPort, out UInt32 Value);

        //读取日最大消费限额
        [DllImport("EastRiver")]
        public static extern bool ReadDayMaxExpenditure(IntPtr hPort, out UInt32 Value);

        //设置日最大消费限额
        [DllImport("EastRiver")]
        public static extern bool SetDayMaxExpenditure(IntPtr hPort, out UInt32 Value);

        //读取日最大消费次数
        [DllImport("EastRiver")]
        public static extern bool ReadDayMaxConsumeTimes(IntPtr hPort, out UInt32 Value);

        //设置日最大消费次数限制
        [DllImport("EastRiver")]
        public static extern bool SetDayMaxConsumeTimes(IntPtr hPort, out UInt32 Value);

        //设置设备的黑名单
        [DllImport("EastRiver")]
        public static extern bool SetBlackCard(IntPtr hPort, string card);

        //删除设备的黑名单
        [DllImport("EastRiver")]
        public static extern bool DeleteBlackCard(IntPtr hPort, string card);

        //删除设备的所有黑名单
        [DllImport("EastRiver")]
        public static extern bool DeleteAllBlackCard(IntPtr hPort, string card);

        //批量读记录
        [DllImport("EastRiver")]
        public static extern ulong BatchReadRecordEx(IntPtr hPort, uint Action, uint Bytes, out uint Count, out string Data);

        //读设备字符串时间
        [DllImport("EastRiver")]
        public static extern bool ReadClockTimeString(IntPtr hPort, out string TimeString);

        //用字符串设置设备时间
        [DllImport("EastRiver")]
        public static extern bool SetClockTimeString(IntPtr hPort, string TimeString);

        //读设备当前管理卡号码
        [DllImport("EastRiver")]
        public static extern bool ReadManagerCard(IntPtr hPort, out string CardNo);

        //修改设备管理卡(ALL)
        [DllImport("EastRiver")]
        public static extern bool SetManagerCard(IntPtr hPort, string CardNo);
        

        //读取机具工作模式
        [DllImport("EastRiver")]
        public static extern bool ReadClockMode(IntPtr hPort,out uint Mode,out uint ExtraMode,out uint SystemMode);

        //设置设备工作模式
        [DllImport("EastRiver")]
        public static extern bool SetClockMode(IntPtr hPort, uint Mode, uint ExtraMode, uint SystemMode);

        //扩展读取机具工作模式(890,兼容2G)
        [DllImport("EastRiver")]
        public static extern bool ReadClockModeEx(IntPtr hPort, out uint Mode, out uint ExtraMode, out uint SystemMode, out uint RingMode);

        //扩展设置设备工作模式
        [DllImport("EastRiver")]
        public static extern bool SetClockModeEx(IntPtr hPort, uint Mode, uint ExtraMode, uint SystemMode, uint RingMode);
    }
}
