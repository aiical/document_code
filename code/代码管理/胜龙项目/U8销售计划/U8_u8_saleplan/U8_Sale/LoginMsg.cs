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
                case "ST131009":
                    INetUserControl in1 = new userControl();
                    in1.Title = "版型维护";
                    userControl.c = 1;
                    base.ShowEmbedControl(in1, cMenuId, true);
                    break;
                case "ST131010":
                    INetUserControl in2 = new userControl();
                    in2.Title = "存货分类及价格段维护";
                    userControl.c = 2;
                    base.ShowEmbedControl(in2, cMenuId, true);
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
