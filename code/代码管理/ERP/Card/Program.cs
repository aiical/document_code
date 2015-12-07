using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Card
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
            DataLib.SysVar.strServer = "127.0.0.1";
            DataLib.SysVar.strDB = "tsJXC";
            DataLib.SysVar.strUGroup = "超级用户";
            Application.Run(new Form1());
        }
    }
}
