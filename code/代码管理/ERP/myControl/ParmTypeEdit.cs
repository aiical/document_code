using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms;

namespace myControl
{

    public class ParmTypeEdit : UITypeEditor
    {
        /// <summary>
        /// 覆盖此方法以返回编辑器的类型。
        /// </summary>
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return System.Drawing.Design.UITypeEditorEditStyle.Modal;
        }
        /// <summary>
        /// 覆盖此方法以显示版本信息
        /// </summary>
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            frmLinkField F = new frmLinkField();
            if (value != null)
                F.htFields = (Hashtable)value;
            if (F.ShowDialog() == DialogResult.OK)
            {
                value = F.htFields;
            }
            return value;
        }
    }
}
