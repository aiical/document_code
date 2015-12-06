using System;
using System.Collections.Generic;
using System.Text;
using UFIDA.U8.Portal.Proxy.supports;
using UFIDA.U8.Portal.Proxy.editors;
using UFIDA.U8.Portal.Proxy.Actions;
using System.Windows.Forms;
using UFIDA.U8.Portal.Framework.Actions;

namespace U8_Sale
{
    public class LoginMsg : NetLoginable {
        public override object CallFunction(string cMenuId, string cMenuName, string cAuthId, string cCmdLine) {
            switch (cMenuId) {
                case "SAM031105":
                    INetUserControl in1 = new userControl();
                    in1.Title = "系统参数设置";
                    userControl.c = 1;
                    base.ShowEmbedControl(in1, cMenuId, true);
                    break;
                case "SAM031106":
                    INetUserControl in2 = new userControl();
                    in2.Title = "参考值指数录入";
                    userControl.c = 2;
                    base.ShowEmbedControl(in2, cMenuId, true);
                    break;
                case "SAM031107":
                    INetUserControl in3 = new userControl();
                    in3.Title = "销售计划管理";
                    userControl.c = 3;
                    base.ShowEmbedControl(in3, cMenuId, true);
                    break;
                case "SAM031108":
                    INetUserControl in4 = new userControl();
                    in4.Title = "销售计划执行统计分析";
                    userControl.c = 4;
                    base.ShowEmbedControl(in4, cMenuId, true);
                    break;
                //case "ST0822":
                //    INetUserControl uc3 = new userControl();
                //    uc3.Title = "门店礼券消费统计表";
                //    userControl.c = 3;
                //    base.ShowEmbedControl(uc3, cMenuId, true);
                //    break;
                //case "ST0823":
                //    INetUserControl uc4 = new userControl();
                //    uc4.Title = "U8实达库存对比表";
                //    userControl.c = 4;
                //    base.ShowEmbedControl(uc4, cMenuId, true);
                //    break;
                //case "ST0824":
                //    INetUserControl uc5 = new userControl();
                //    uc5.Title = "库存分配情况表";
                //    userControl.c = 5;
                //    base.ShowEmbedControl(uc5, cMenuId, true);
                //    break;
                default:
                    break;
            }
            return null;
        }

        public override bool SubSysLogin() {
            return true;
        }
    }
}
