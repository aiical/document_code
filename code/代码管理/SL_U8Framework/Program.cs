using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Donlim.Common;
using Donlim.Controls;
using Donlim.Data;
using Donlim.Forms.CommonForm;
using System.Data.SqlClient;

namespace SL_U8Framework
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //GlobalData.sysCon = new SqlConnection(@"data source=192.168.10.8;initial catalog=u8_attend;user id=erpuser;password=2mod92k2&^*;persist security info=True;Connect Timeout=180;Application Name=MOD信息管理平台");
            GlobalData.sysCon = new SqlConnection(@"Data Source=X220i;Initial Catalog=master;Integrated Security=True");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Donlim.Common.Function.LoadPersonConfig();
            Application.Run(new FrmNewInvClassRelation());
        }
    }
}
