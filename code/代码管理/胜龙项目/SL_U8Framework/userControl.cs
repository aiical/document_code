using System;
using System.Collections.Generic;
using System.Text;
using UFIDA.U8.Portal.Proxy.editors;
using UFSoft.U8.Framework.Login.UI;
using UFIDA.U8.Portal.Framework.MainFrames;
using U8Login;
using Donlim.Common;
using Donlim.Controls;
using Donlim.Data;
using Donlim.Forms.CommonForm;

namespace SL_U8Framework
{
    public class userControl : INetUserControl {
        private IEditorInput _editInput = null;
        private IEditorPart _editPart = null;
        private string _title;
        public static string connStr = "";
        public static string uMenuName = "";
        public static DateTime oCurTime;
        public static object oLogin;
        public static string DataBase;
        public static string Password;
        public static string Uid;
        public static string Server;
        public static int c = 0;
        public static string userName = "";
        public static string sSubId = "";
        public static string sAccID = "";
        public static string sYear = "";
        public static string sSerial = "";
        public static string cUserId = "";

        /// <summary>
        /// EditorInput
        /// </summary>
        public IEditorInput EditorInput {
            get {
                return _editInput;
            }
            set {
                _editInput = value;
            }
        }

        /// <summary>
        /// EditorPart
        /// </summary>
        public IEditorPart EditorPart {
            get {
                return _editPart;
            }
            set {
                _editPart = value;
            }
        }

        /// <summary>
        /// 页签标题
        /// </summary>
        public string Title {
            get {
                return this._title;
            }
            set {
                this._title = value;
            }
        }

        public bool CloseEvent() {
            return true;
        }

        #region CreateControl
        /// <summary>
        /// 建立要显示的control对象
        /// </summary>
        /// <param name="login">u8登陆对象</param>
        /// <param name="MenuID">菜单ID</param>
        /// <param name="Paramters">菜单参数</param>
        /// <returns>要显示的usercontrol</returns>
        public System.Windows.Forms.Control CreateControl(UFSoft.U8.Framework.Login.UI.clsLogin login, string MenuID, string Paramters) {
            U8Login.clsLogin u8login = new U8Login.clsLoginClass();
            oLogin = u8login;
            if (login != null) {
                u8login.ConstructLogin(login.userToken);
                connStr = u8login.UfDbName.ToString();
                oCurTime = u8login.CurDate;
                string[] conSplit = connStr.Split(";".ToCharArray());
                Server = conSplit[1].ToLower().Replace("data source=", "");
                Uid = conSplit[2].ToLower().Replace("user id=", "");
                Password = u8login.SysPassword;
                DataBase = conSplit[4].ToLower().Replace("initial catalog=", "");
                userName = u8login.cUserName;
                sSubId = u8login.cSub_Id;
                sAccID = u8login.get_cAcc_Id();
                sSerial = u8login.cSerial.ToString();
                sYear = u8login.cIYear;
                cUserId = u8login.cUserId;
                GlobalData.sysCon = Donlim.Data.DataAccess.GetSqlConnection(Server, DataBase, Uid, Password);
               
                Donlim.Common.Function.LoadPersonConfig();
            }
            switch (c) {
                case 1:
                    FrmBanXing uc1 = new FrmBanXing();
                    return uc1;
                case 2:
                    FrmNewInvClassRelation uc2 = new FrmNewInvClassRelation();
                    return uc2;
                    break;
                //case 3:
                //    frmGiftTokenReport uc3 = new frmGiftTokenReport();
                //    return uc3;
                //        break;
                //case 4:
                //        frmStockDataCompare uc4 = new frmStockDataCompare();
                //        return uc4;
                //        break;
                //case 5:
                //        frmStockDistribute uc5 = new frmStockDistribute();
                //        return uc5;
                //        break;
                default:
                    break;
            }
            return null;
        }
        #endregion

        public UFIDA.U8.Portal.Proxy.Actions.NetAction[] CreateToolbar(UFSoft.U8.Framework.Login.UI.clsLogin login) {
            return null;
        }
    }
}
