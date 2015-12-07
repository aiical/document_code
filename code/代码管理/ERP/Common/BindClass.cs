using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DataLib;
using System.Data;

namespace Common
{
    class BindClass
    {
         /// <summary>
        /// 绑定控件
        /// </summary>
        /// <param name="c"></param>
        /// <param name="BindDS"></param>
        public static void BindControl(Control c, object BindDS)
        {
            foreach (Control uCon in c.Controls)
            {
                if (uCon is myControl.EditControl)
                {
                    if ((uCon as myControl.EditControl).DataField != "")
                    {
                        (uCon as myControl.EditControl).DataSource = BindDS;
                        (uCon as myControl.EditControl).BindData();
                    }
                }

                if (uCon is myControl.lupControl)
                {
                    if ((uCon as myControl.lupControl).DataField != "")
                    {
                        (uCon as myControl.lupControl).DataSource = BindDS;
                        (uCon as myControl.lupControl).BindData();
                    }
                }

                if (uCon is myControl.cbControl)
                {
                    if ((uCon as myControl.cbControl).DataField != "")
                    {
                        (uCon as myControl.cbControl).DataSource = BindDS;
                        (uCon as myControl.cbControl).BindData();
                    }
                }

                if (uCon is myControl.DateControl)
                {
                    if ((uCon as myControl.DateControl).DataField != "")
                    {
                        (uCon as myControl.DateControl).DataSource = BindDS;
                        (uCon as myControl.DateControl).BindData();
                    }
                }

                if (uCon is myControl.SpinControl)
                {
                    if ((uCon as myControl.SpinControl).DataField != "")
                    {
                        (uCon as myControl.SpinControl).DataSource = BindDS;
                        (uCon as myControl.SpinControl).BindData();
                    }
                }

                if (uCon is myControl.ckControl)
                {
                    if ((uCon as myControl.ckControl).DataField != "")
                    {
                        (uCon as myControl.ckControl).DataSource = BindDS;
                        (uCon as myControl.ckControl).BindData();
                    }
                }
            }
        }

        public static void SetControlRight(Control cParent, string strModule)
        {
            string strSQL = "select * from t_DetailRight where F_UID = '" + DataLib.SysVar.strUID + "' and F_Module = '" + strModule + "List'";
            DataHelper myHelper = new DataHelper();
            DataSet ds = myHelper.GetDs(strSQL);

            string sFiled = "";
            foreach (Control uCon in cParent.Controls)
            {

                if (uCon is myControl.EditControl)
                {
                    sFiled = (uCon as myControl.EditControl).DataField;
                }

                if (uCon is myControl.lupControl)
                {
                    sFiled = (uCon as myControl.lupControl).DataField;
                }

                if (uCon is myControl.cbControl)
                {
                    sFiled = (uCon as myControl.cbControl).DataField;
                }

                if (uCon is myControl.DateControl)
                {
                    sFiled = (uCon as myControl.DateControl).DataField;
                }

                if (uCon is myControl.SpinControl)
                {
                     sFiled = (uCon as myControl.SpinControl).DataField;
                }

                if (uCon is myControl.ckControl)
                {
                    sFiled = (uCon as myControl.ckControl).DataField;
                }

                
                DataRow[] drField = ds.Tables[0].Select("F_Field = '" + sFiled + "'");
                 if (drField.Length > 0)
                {
                    if (Convert.ToBoolean(drField[0]["F_Visible"]) == false)
                    {
                        uCon.Visible = false;
                    }
                    else
                    {
                        uCon.Visible = true;
                    }
                }
            }
        }

        public static bool RequestInput(Control c)
        {
            foreach (Control uCon in c.Controls)
            {
                if (uCon is myControl.EditControl)
                {
                    if ((uCon as myControl.EditControl).Request == true)
                    {
                        if ((uCon as myControl.EditControl).GetValue() == DBNull.Value)
                        {
                            MessageBox.Show((uCon as myControl.EditControl).EditLabel + "不能为空!!", "提示");
                            (uCon as myControl.EditControl).Focus();
                            return false;
                        }
                        else if ((uCon as myControl.EditControl).GetValue().ToString() == "")
                        {
                             MessageBox.Show((uCon as myControl.EditControl).EditLabel + "不能为空!!", "提示");
                            (uCon as myControl.EditControl).Focus();
                            return false;
                        }

                    }
                }

                if (uCon is myControl.lupControl)
                {
                    if ((uCon as myControl.lupControl).Request == true)
                    {
                        if ((uCon as myControl.lupControl).GetValue() == DBNull.Value)
                        {
                            MessageBox.Show((uCon as myControl.lupControl).EditLabel + "不能为空!!", "提示");
                            (uCon as myControl.lupControl).Focus();
                            return false;
                        }
                    }
                }

                if (uCon is myControl.DateControl)
                {
                    if ((uCon as myControl.DateControl).Request == true)
                    {
                        if ((uCon as myControl.DateControl).GetValue() == DBNull.Value)
                        {
                            MessageBox.Show((uCon as myControl.DateControl).EditLabel + "不能为空!!", "提示");
                            (uCon as myControl.DateControl).Focus();
                            return false;
                        }
                    }
                }
               
            }
            return true;
        }
    }
}
