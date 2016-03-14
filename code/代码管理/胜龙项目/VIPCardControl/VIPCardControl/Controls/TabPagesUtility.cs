using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Crownwood.DotNetMagic.Controls;
using System.Windows.Forms;

namespace UFIDA.Retail.VIPCardControl
{
    public class TabPagesUtility
    {
        public interface ICalledBack
        {
            // Methods
            void CallBackMethod(object obj);
        }

        public interface IWillCallBack
        {
            // Properties
            ICalledBack FormCalledBack { get; set; }
        }

        // Methods
        public static void TabPageRemove(Form frm)
        {
            Crownwood.DotNetMagic.Controls.TabControl parent = frm.Parent as Crownwood.DotNetMagic.Controls.TabControl;
            if (parent == null)
            {
                frm.Close();
                frm.Dispose();
                frm = null;
            }
            else
            {
                for (int i = parent.TabPages.Count - 1; i >= 0; i--)
                {
                    Crownwood.DotNetMagic.Controls.TabPage page = parent.TabPages[i];
                    if (page.Control == frm)
                    {
                        parent.TabPages.Remove(page);
                        frm.Close();
                        frm.Dispose();
                        frm = null;
                        if (page.Tag != null)
                        {
                            PropertyInfo property = page.Tag.GetType().GetProperty("DataItem");
                            if (property != null)
                            {
                                property.SetValue(page.Tag, null, null);
                            }
                        }
                        page.Dispose();
                        page = null;
                        break;
                    }
                }
            }
        }

        public static void TabPageRemvoeWithCallBack(IWillCallBack frm, bool callMethod, object callbackMethodParam)
        {
            ICalledBack formCalledBack = frm.FormCalledBack;
            Crownwood.DotNetMagic.Controls.TabControl parent = (frm.FormCalledBack as Form).Parent as Crownwood.DotNetMagic.Controls.TabControl;
            Form form = frm as Form;
            for (int i = parent.TabPages.Count - 1; i >= 0; i--)
            {
                Crownwood.DotNetMagic.Controls.TabPage page = parent.TabPages[i];
                if (page.Control == form)
                {
                    parent.TabPages.Remove(page);
                    if (page.Tag != null)
                    {
                        PropertyInfo property = page.Tag.GetType().GetProperty("DataItem");
                        if (property != null)
                        {
                            property.SetValue(page.Tag, null, null);
                        }
                    }
                    page.Dispose();
                    page = null;
                    break;
                }
            }
            form.Close();
            form.Dispose();
            form = null;
            foreach (Crownwood.DotNetMagic.Controls.TabPage page in parent.TabPages)
            {
                if (page.Control == formCalledBack)
                {
                    page.Selected = true;
                    break;
                }
            }
            if (callMethod)
            {
                formCalledBack.CallBackMethod(callbackMethodParam);
            }
        }

        public static void TabPageShow(Control container, string strTag, Form ctrl)
        {
            Crownwood.DotNetMagic.Controls.TabControl control = container as Crownwood.DotNetMagic.Controls.TabControl;
            if (control != null)
            {
                Crownwood.DotNetMagic.Controls.TabPage page = null;
                foreach (Crownwood.DotNetMagic.Controls.TabPage page2 in control.TabPages)
                {
                    if ((page2.Tag != null) && page2.Tag.ToString().Equals(strTag))
                    {
                        page = page2;
                        break;
                    }
                }
                if (page == null)
                {
                    page = new Crownwood.DotNetMagic.Controls.TabPage(ctrl.Text, ctrl, ctrl.Icon);  
                    page.Tag = strTag;
                    control.TabPages.Add(page);
                }
                page.Selected = true;
            }
        }
    }
}
