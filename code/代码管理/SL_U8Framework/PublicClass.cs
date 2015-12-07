using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SL_U8Framework
{
    class PublicClass
    {
        private static string hookControlList = "DataGridView;FpSpread;DBGrid";


        /// <summary>
        /// 对窗体控件进行遍历,找出当前焦点的控件
        /// </summary>
        private static  Control getControl(Control c)
        {
            Control grid = null;
            foreach (Control p in c.Controls)
            {
                if (p.HasChildren)
                {
                    if (hookControlList.IndexOf(p.GetType().Name, 0) != -1 && p.Focused)
                        grid = p;
                    else
                        grid = getControl(p);
                }
                if (grid != null)
                    break;
            }
            return grid;
        }

        public static Control GetActiveDBGrid(Control _ActiveControl)
        {
            Control dg = null;
            if (_ActiveControl != null)
                {
                    int i = hookControlList.IndexOf(_ActiveControl.GetType().Name);
                    //当前活动控件可能就是DataGridView的扩展类，直接进行基类检查
                    if (i != -1)
                        dg = _ActiveControl;
                    else
                        dg = getControl(_ActiveControl);

                    if (dg != null)
                    {
                        return dg;
                    }
                }
            
            return null;
        }
    }
}
