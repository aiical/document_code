using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using UFIDA.Retail.Components;
using UFIDA.Retail.Common;
using UFIDA.Retail.Utility;
using System.IO;
using System.Data.SqlClient;
using UFIDA.Retail.RetailReceipt;

namespace UFIDA.Retail.VIPCardControl
{
    /// <summary>
    /// <modity>
    /// 071210 by tiger
    /// </modity>
    /// </summary>
    public partial class frmVIPConsumerInfoModify : Form
    {


        public frmVIPConsumerInfoModify()
        {
            InitializeComponent();
            //this.Shown += new EventHandler(frmVIPConsumerInfoModify_Shown);
        }

        //private void frmVIPConsumerInfoModify_Shown(object sender, EventArgs e)
        //{
        //    this.Location = new System.Drawing.Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, Screen.PrimaryScreen.WorkingArea.Height / 3);
        //}
        private string vipCode = "";
        public string VIPCode
        {
            set { vipCode = value; }
            get { return vipCode; }
        }
        private string fchrVIPCardClass = "";
        public string VIPCardClassName
        {
            set { fchrVIPCardClass = value; }
            get { return fchrVIPCardClass; }
        }
        private string fchrVipConsumerName = "";
        public string ConsumerName
        {
            set { fchrVipConsumerName = value; }
            get { return fchrVipConsumerName; }
        }

        private bool isAddConsumer = false;
        public bool IsAddConsumer
        {
            set { isAddConsumer = value; }
            get { return isAddConsumer; }
        }
        private DateTime billDate = DateTime.MinValue;
        public DateTime BillDate
        {
            set { billDate = value; }
            get { return billDate; }
        }
        private XmlDocument xmlDoc = new XmlDocument();
        private string NewVipConsumerID = "";
        private void VIPConsumerInfoModify_Load(object sender, EventArgs e)
        {
            if (vipCode.Equals("") && !isAddConsumer)
            {
                this.Close();
                return;
            }
            LoadControl();
            this.MinimumSize = new Size(this.Width, this.Height);
            this.Size = new Size(ucContainer.Width, ucContainer.Height + panel1.Height + 10);
            //--------------
            try
            {
                string templateFile = string.Format(@"{0}\xml\Receipt\单据_零售单模板.xml", Tools.GetStringSysPara("DataPath"));
                xmlDoc.Load(templateFile);
                XmlNode objNode = xmlDoc.SelectSingleNode(@"Root/VipConsumer");
                int editVIPConsumerFormWidth = Tools.GetIntAttribute((XmlElement)objNode, "EditVIPConsumerFormWidth");
                int editVIPConsumerFormHeight = Tools.GetIntAttribute((XmlElement)objNode, "EditVIPConsumerFormHeight");
                this.Size = new Size(editVIPConsumerFormWidth, editVIPConsumerFormHeight);
                //--872高丝
                int eitVIPConsumerFormLocationX = Tools.GetIntAttribute((XmlElement)objNode, "EditVIPConsumerFormLocationX");
                int editVIPConsumerFormLocationY = Tools.GetIntAttribute((XmlElement)objNode, "EditVIPConsumerFormLocationY");
                if (eitVIPConsumerFormLocationX == editVIPConsumerFormLocationY && editVIPConsumerFormLocationY == 0) return;
                this.Location = new System.Drawing.Point(eitVIPConsumerFormLocationX, editVIPConsumerFormLocationY);
                //--end
            }
            catch { }
        }
        private string strVipConsumerID;
        private void LoadControl()
        {
            DataRow ctlValue = null;
            #region---------- 20100919 Add by MZY 控制客户信息编辑，如果客户已经审核则不能再修改
            bool bitCheck = false;
            if (!isAddConsumer)
            {
                StringBuilder sqlVIPConsumer = new StringBuilder();
                sqlVIPConsumer.Append("select top 1  * from ViewVipConsumerList where fchrvipconsumerid in(");
                sqlVIPConsumer.Append("select  fchrvipconsumerid from VipCodeCollate where ");
                sqlVIPConsumer.AppendFormat("fchrVipCode='{0}')", vipCode);
                ctlValue = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, sqlVIPConsumer.ToString()).Tables[0].Rows[0];
                strVipConsumerID = ctlValue["fchrvipconsumerid"].ToString();
                if (ctlValue["fbitCheck"].ToString() == "True")
                    bitCheck = true;
            }
            if (bitCheck)
            {
                this.btnOk.Text = "已审核";
                this.btnOk.Enabled = false;
            }

            string dataValue = "";
            //申请日期,如果是增加客户则申请日期取单据日期 modify by MZY 20100919,从主界面传入的参数，通过属性的方式来传递
            StringBuilder fdtmApplyTime = new StringBuilder();
            DateTime apllyDate = new DateTime();
            if (this.billDate != DateTime.MinValue)
                apllyDate = billDate;
            else
                apllyDate = DateTime.Now;
            fdtmApplyTime.AppendFormat(@"<ValueControl Assembly='1' ControlType='2' Format='T' Name='fdtmApplyTime' Caption='申请日期' ControlValue='{0}' />", isAddConsumer ? apllyDate.ToString() : ctlValue["fdtmApplyTime"].ToString());
            ucContainer.AddControl(GetConfigNode(fdtmApplyTime.ToString()));
            #endregion
            //VIP客户级别
            //StringBuilder fchrVIPCardClassID = new StringBuilder();
            //fchrVIPCardClassID.AppendFormat(@"<ValueControl Assembly='1' ControlType='9' Name='fchrVIPCardClassID' Caption='VIP客户级别' ControlValue='{0}' >", isAddConsumer ? "" : ctlValue["fchrVIPCardClassName"].ToString());
            //fchrVIPCardClassID.Append("<InitParams Type='SQL' Value='SELECT fchrVIPCardClassName as [Display],fchrVIPCardClassID as [Value] FROM VIPCardClass ORDER BY fchrVIPCardClassCode' /> </ValueControl>");


            StringBuilder fchrVIPCardClassID = new StringBuilder();

            fchrVIPCardClassID.AppendFormat(@"<ValueControl Assembly='1' ControlType='5' Name='fchrVIPCardClassID' Caption='VIP客户级别' ControlValue='{0}' RefName='{0}' RefID='{1}'>", isAddConsumer ? "" : ctlValue["fchrVIPCardClassName"].ToString(), isAddConsumer ? "" : ctlValue["fchrVIPCardClassID"].ToString());
            fchrVIPCardClassID.Append(@"<InitParams Value='查询模板' TextMaxLen='50' ><AutoTrim Value='False'/><Template Value='ref_VIPCardClassName' Returntype='ID' /><PageNumber Value='15'/></InitParams></ValueControl>");
            ucContainer.AddControl(GetConfigNode(fchrVIPCardClassID.ToString()));

            //客户名称
            StringBuilder fnarconsumername = new StringBuilder();
            fnarconsumername.AppendFormat(@"<ValueControl Assembly='1' ControlType='4' Name='fnarconsumername' Caption='客户名称' ControlValue='{0}' ><InitParams TextMaxLength='50' /></ValueControl>", isAddConsumer ? "" : ctlValue["fnarconsumername"].ToString());
            ucContainer.AddControl(GetConfigNode(fnarconsumername.ToString()));
            //VIP卡号
            if (isAddConsumer)
            {
                StringBuilder fchrVipCode = new StringBuilder();
                fchrVipCode.Append(@"<ValueControl Assembly='1' ControlType='5' Name='fchrVipCode' Caption='VIP卡号' ControlValue='' ><InitParams Value='查询模板' TextMaxLen='50' ><AutoTrim Value='False'/><UseTextValue Value='True'/><Template Value='Ref_VipCode'/><PageNumber Value='15'/></InitParams></ValueControl>");
                ucContainer.AddControl(GetConfigNode(fchrVipCode.ToString()));
            }
            else
            {//add by mzy 
                StringBuilder fchrVipCode = new StringBuilder();
                fchrVipCode.AppendFormat(@"<ValueControl Assembly='1'  ControlType='1' Name='fchrvipcards' Caption='VIP卡号' ControlValue='{0}' ></ValueControl>", ctlValue["fchrVipCode"].ToString());
                ucContainer.AddControl(GetConfigNode(fchrVipCode.ToString()));//end 
            }
            //性别
            StringBuilder fnarsex = new StringBuilder();
            fnarsex.AppendFormat(@"<ValueControl Assembly='1' ControlType='9' Name='fnarsex' Caption='性别' ControlValue='{0}' ><InitParams Type='ARRAY' Value='男,男 #女,女' NoAll='1' /></ValueControl>", isAddConsumer ? "女" : ctlValue["fnarsex"].ToString());
            ucContainer.AddControl(GetConfigNode(fnarsex.ToString()));

            //出生年月日
            //StringBuilder fdtmbirthday = new StringBuilder();
            //dataValue = ctlValue["fdtmbirthday"].ToString();
            //fdtmbirthday.AppendFormat(@"<ValueControl Assembly='1' ControlType='2' Format='D' Name='fdtmbirthday' Caption='出生日期' ControlValue='{0}' ></ValueControl>", dataValue);
            //ucContainer.AddControl(GetConfigNode(fdtmbirthday.ToString()));
            //出生年
            StringBuilder fdtmbirthdayyear = new StringBuilder();
            dataValue = isAddConsumer ? "" : ctlValue["fintbirthdayyear"].ToString();
            fdtmbirthdayyear.AppendFormat(@"<ValueControl Assembly='1' ControlType='4'  Name='fintbirthdayyear' Caption='出生年' ControlValue='{0}' ></ValueControl>", dataValue);
            ucContainer.AddControl(GetConfigNode(fdtmbirthdayyear.ToString()));
            //出生月
            StringBuilder fdtmbirthdaymonth = new StringBuilder();
            dataValue = isAddConsumer ? "" : ctlValue["fintbirthdaymonth"].ToString();
            string monthValue = dataValue;
            fdtmbirthdaymonth.AppendFormat(@"<ValueControl Assembly='1' ControlType='9'  Name='fintbirthdaymonth' Caption='出生月' ControlValue='{0}' ><InitParams Type='ARRAY' Value='1,1#2,2#3,3#4,4#5,5#6,6#7,7#8,8#9,9#10,10#11,11#12,12' NoAll='0' /></ValueControl>", dataValue);
            ucContainer.AddControl(GetConfigNode(fdtmbirthdaymonth.ToString()));
            //出生日
            StringBuilder fdtmbirthdayday = new StringBuilder();
            dataValue = isAddConsumer ? "" : ctlValue["fintbirthdayday"].ToString();
            fdtmbirthdayday.AppendFormat(@"<ValueControl Assembly='1' ControlType='9'  Name='fintbirthdayday' Caption='出生日' ControlValue='{0}' ><InitParams Type='ARRAY' Value='", dataValue);
            int intCount = 31;
            switch (monthValue)
            {
                case "":
                case "1":
                case "3":
                case "5":
                case "7":
                case "8":
                case "10":
                case "12":
                    intCount = 31;
                    break;
                case "4":
                case "6":
                case "9":
                case "11":
                    intCount = 30;
                    break;
                case "2":
                    intCount = 29;
                    break;

            }
            for (int i = 1; i <= intCount; i++)
            {
                fdtmbirthdayday.AppendFormat("{0},{0}", i.ToString());
                if (i != intCount)
                {
                    fdtmbirthdayday.Append("#");
                }
            }
            fdtmbirthdayday.Append("' NoAll='0' /></ValueControl>");
            ucContainer.AddControl(GetConfigNode(fdtmbirthdayday.ToString()));
            //有效证件类型
            StringBuilder fnarcertificatetype = new StringBuilder();
            dataValue = isAddConsumer ? "身份证" : ctlValue["fnarcertificatetype"].ToString();
            fnarcertificatetype.AppendFormat(@"<ValueControl Assembly='1' ControlType='4' Name='fnarcertificatetype' Caption='有效证件类型' ControlValue='{0}' ><InitParams TextMaxLength='20' /></ValueControl>", dataValue);
            ucContainer.AddControl(GetConfigNode(fnarcertificatetype.ToString()));

            //有效证件号码
            dataValue = isAddConsumer ? "" : ctlValue["fnarcertificatecode"].ToString();
            StringBuilder fnarcertificatecode = new StringBuilder();
            fnarcertificatecode.AppendFormat(@"<ValueControl Assembly='1' ControlType='4' Name='fnarcertificatecode' Caption='有效证件号码' ControlValue='{0}' ><InitParams TextMaxLength='30' /></ValueControl>", dataValue);
            ucContainer.AddControl(GetConfigNode(fnarcertificatecode.ToString()));

            //固定电话
            StringBuilder fnarphone = new StringBuilder();
            dataValue = isAddConsumer ? "" : ctlValue["fnarphone"].ToString();
            //dataValue = DataDecrypt(dataValue);
            fnarphone.AppendFormat(@"<ValueControl Assembly='1' ControlType='4' Name='fnarphone' Caption='固定电话' ControlValue='{0}' ><InitParams TextMaxLength='30' /></ValueControl>", dataValue);
            ucContainer.AddControl(GetConfigNode(fnarphone.ToString()));

            //移动电话
            StringBuilder fnarmobilephone = new StringBuilder();
            dataValue = isAddConsumer ? "" : ctlValue["fnarmobilephone"].ToString();
            //dataValue = DataDecrypt(dataValue);
            fnarmobilephone.AppendFormat(@"<ValueControl Assembly='1' ControlType='4' Name='fnarmobilephone' Caption='移动电话' ControlValue='{0}' ><InitParams TextMaxLength='30' /></ValueControl>", dataValue);
            ucContainer.AddControl(GetConfigNode(fnarmobilephone.ToString()));

            //电子邮箱
            StringBuilder fnaremail = new StringBuilder();
            dataValue = isAddConsumer ? "" : ctlValue["fnaremail"].ToString();
            //dataValue = DataDecrypt(dataValue);
            fnaremail.AppendFormat(@"<ValueControl Assembly='1' ControlType='4' Name='fnaremail' Caption='电子邮箱' ControlValue='{0}' ><InitParams TextMaxLength='60' /></ValueControl>", dataValue);
            ucContainer.AddControl(GetConfigNode(fnaremail.ToString()));

            //邮政编码
            StringBuilder fnarpostalcode = new StringBuilder();
            dataValue = isAddConsumer ? "" : ctlValue["fnarpostalcode"].ToString();
            //dataValue = DataDecrypt(dataValue);
            fnarpostalcode.AppendFormat(@"<ValueControl Assembly='1' ControlType='4' Name='fnarpostalcode' Caption='邮政编码' ControlValue='{0}' ><InitParams TextMaxLength='10' /></ValueControl>", dataValue);
            ucContainer.AddControl(GetConfigNode(fnarpostalcode.ToString()));

            //通信地址
            StringBuilder fnaraddress = new StringBuilder();
            dataValue = isAddConsumer ? "" : ctlValue["fnaraddress"].ToString();
            //dataValue = DataDecrypt(dataValue);
            fnaraddress.AppendFormat(@"<ValueControl Assembly='1' ControlType='4' Name='fnaraddress' Caption='通信地址' ControlValue='{0}' ><InitParams TextMaxLength='200' /></ValueControl>", dataValue);
            ucContainer.AddControl(GetConfigNode(fnaraddress.ToString()));

            //经手营业员
            StringBuilder fchrEmployee = new StringBuilder();
            //fchrEmployee.AppendFormat(@"<ValueControl Assembly='1' ControlType='5' Name='fchrEmployee' Caption='经手营业员' ControlValue='{0}' ><InitParams Value='查询模板' TextMaxLen='50' ><UseTextValue Value='True'/><Template Value='ref_EmployeeName'/><PageNumber Value='15'/></InitParams></ValueControl>", isAddConsumer ? "" : ctlValue["fchrEmployee"].ToString());
            fchrEmployee.AppendFormat(@"<ValueControl Assembly='1' ControlType='9' Name='fchrEmployee' Caption='经手营业员' ControlValue='{0}' >", isAddConsumer ? "" : ctlValue["fchrEmployee"].ToString());
            fchrEmployee.Append("<InitParams Type='SQL' Value=\"SELECT fchrEmployeeName as [Value], fchrEmployeeName ");//'('+fchrEmployeeCode+')'+
            fchrEmployee.Append(" as Display  FROM employee as T1 INNER JOIN EmployeeSource ON T1.fintSource = EmployeeSource.fintSource ");
            fchrEmployee.Append(" left join department as T2 on T1.fchrDepartmentID=T2.fchrDepartmentID Order By fchrEmployeeCode \" /></ValueControl>");

            ucContainer.AddControl(GetConfigNode(fchrEmployee.ToString()));

            //自定义项
            LoadRMUserDefBaseCtl(ctlValue);
            SetBirthdayMonth();
            ExComboBox objCheckBox = ucContainer.GetControl("fintbirthdaymonth") as ExComboBox;
            objCheckBox.ComboBox.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBirthdayMonth();
        }
        private DataTable GetComboxData(int intEnd)
        {
            DataTable objTable = new DataTable();
            DataColumn objColumn = new DataColumn();
            objColumn.ColumnName = "Display";
            objColumn.Caption = "Display";
            objTable.Columns.Add(objColumn);

            objColumn = new DataColumn();
            objColumn.ColumnName = "Value";
            objColumn.Caption = "Value";
            objTable.Columns.Add(objColumn);

            DataRow objRow;
            objRow = objTable.NewRow();
            objRow["Display"] = "全部";
            objRow["Value"] = "";
            objTable.Rows.Add(objRow);
            for (int i = 1; i <= intEnd; i++)
            {
                objRow = objTable.NewRow();
                objRow["Display"] = i.ToString();
                objRow["Value"] = i.ToString();
                objTable.Rows.Add(objRow);
            }
            return objTable;
        }
        private void SetBirthdayMonth()
        {
            ExComboBox objCheckBox = ucContainer.GetControl("fintbirthdayday") as ExComboBox;
            if (objCheckBox == null) return;
            int tempValue = Tools.GetIntColumnValue(objCheckBox.ComboBox.SelectedIndex);
            string fintbirthdaymonth = (ucContainer.GetControl("fintbirthdaymonth") as ExComboBox).ControlValue;
            switch (fintbirthdaymonth)
            {
                case "1":
                case "3":
                case "5":
                case "7":
                case "8":
                case "10":
                case "12":
                    objCheckBox.ComboBox.DataSource = GetComboxData(31);
                    objCheckBox.ComboBox.SelectedIndex = tempValue;
                    break;
                case "4":
                case "6":
                case "9":
                case "11":
                    if (tempValue > 30) tempValue = 30;
                    objCheckBox.ComboBox.SelectedIndex = tempValue;
                    objCheckBox.ComboBox.DataSource = GetComboxData(30);
                    objCheckBox.ComboBox.SelectedIndex = tempValue;
                    break;
                case "2":
                    if (tempValue > 29) tempValue = 29;
                    objCheckBox.ComboBox.SelectedIndex = tempValue;
                    objCheckBox.ComboBox.DataSource = GetComboxData(29);
                    objCheckBox.ComboBox.SelectedIndex = tempValue;
                    break;
            }
        }

        /// <summary>
        /// 加载自定义项控件
        /// </summary>
        /// <param name="ctlValue">控件值</param>
        private void LoadRMUserDefBaseCtl(DataRow ctlValue)
        {
            DataSet RMUserDefBaseDs = new DataSet();
            RMUserDefBaseDs = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, "select * from RMUserDefBase where fbitUsed='1' AND fchrClass='VIP客户' order by fchruid ");
            foreach (DataRow row in RMUserDefBaseDs.Tables[0].Rows)
            {
                StringBuilder ctlXml = new StringBuilder();
                string ctlType;

                ctlType = ControlType(row);
                ctlXml.Append("<ValueControl Assembly='1'");
                ctlXml.AppendFormat(" ControlType='{0}'", ctlType);
                ctlXml.AppendFormat(" Name='{0}'", row["fchrDicDbName"].ToString());
                ctlXml.AppendFormat(" Caption='{0}'", row["fchrItem"].ToString());
                if (ctlType.Equals("9"))
                {
                    ctlXml.AppendFormat(" ControlValue='{0}'", IsAddConsumer ? "" : ctlValue[row["fchrDicDbName"].ToString() + "Name"].ToString().Replace("'", ""));
                }
                else
                {
                    ctlXml.AppendFormat(" ControlValue='{0}'", IsAddConsumer ? "" : ctlValue[row["fchrDicDbName"].ToString()].ToString().Replace("'", ""));
                }
                if (ctlType.Equals("8"))
                {
                    if (row["fchrType"].ToString().Equals("数字"))
                    {
                        //ctlXml.Append(" Format='P'");
                        ctlXml.AppendFormat(" Format='{0}'", DecimalToFormat(row["ftinDecimalDigits"].ToString()));
                    }
                    else
                    {
                        ctlXml.Append(" Format='#0'");
                    }
                }
                if (ctlType.Equals("2"))
                {
                    ctlXml.AppendFormat(" Format='{0}'", "D");
                }
                ctlXml.Append(">");
                if (ctlType.Equals("16"))
                {
                    ctlXml.Append("<InitParams DataSourceType='SQL' MaxValueLength='200'");
                    ctlXml.AppendFormat(" CommandText=\"select fchrValue,fintAutoID from RMUserDefine where fchrUserDefBasePKID='{0}' Order by fchrAlias \" ValueColumnName='fchrValue' KeyColumnName='fintAutoID' LeftMark=',' RightMark=',' Separator=',' />/", row["fchrUserDefBasePKID"]);
                }
                else if (ctlType.Equals("9"))
                {
                    ctlXml.Append("<InitParams Type='SQL' ");
                    ctlXml.AppendFormat("Value=\"select fchrValue as Display,fintAutoID as [Value] from RMUserDefine Where fchrUserDefBasePKID='{0}' Order by fchrAlias \" DefaultProperty='ControlValue' />", row["fchrUserDefBasePKID"]);
                }
                else if (ctlType.Equals("2"))
                {
                    ctlXml.AppendFormat("<DateFormat Value='{0}' />", "D");
                }
                else if (ctlType.Equals("4"))
                {
                    ctlXml.AppendFormat("<InitParams TextMaxLength='{0}' />", row["fintLength"].ToString());
                }
                else if (ctlType.Equals("8"))
                {
                    if (row["fchrType"].Equals("整型"))
                    {
                        ctlXml.Append("<InitParams TextMaxLength='9' MaxValue='1000000000' MinValue='-1000000000' ");
                        ctlXml.Append(" Format='#0'/>");
                    }
                    else
                    {
                        //int textMaxLength;
                        //textMaxLength = row["ftinDecimalDigits"].ToString() == "" ? 19 : 19 - Convert.ToInt32(row["ftinDecimalDigits"]);
                        //ctlXml.AppendFormat("<InitParams TextMaxLength='{0}' />", Convert.ToString(textMaxLength));
                        ctlXml.Append("<InitParams TextMaxLength='19' MaxValue='1000000000' MinValue='-1000000000' ");
                        ctlXml.AppendFormat(" Format='{0}' />", DecimalToFormat(row["ftinDecimalDigits"].ToString()));
                    }

                }
                ctlXml.Append("</ValueControl>");

                ucContainer.AddControl(GetConfigNode(ctlXml.ToString()));
                ucContainer.Size = new Size(ucContainer.Width, ucContainer.Height + ucContainer.Controls[0].Controls[0].Height * 3 / 5);
            }
        }

        private string ControlType(DataRow row)
        {
            if (row["fchrType"].Equals("文本"))
            {
                if (row["fintDataSource"].ToString().Equals("1"))
                {
                    //复选参照
                    if ((bool)row["fbitMultiInput"])
                    {
                        return "16";

                    }
                    //单选，用下拉列表
                    else
                    {
                        return "9";
                    }
                }
                //普通文本
                else
                {
                    return "4";
                }

            }
            //日期型控件
            else if (row["fchrType"].ToString().Equals("日期"))
            {
                return "2";
            }
            else if (row["fchrType"].ToString().Equals("数字"))
            {
                return "8";
            }
            else if (row["fchrType"].ToString().Equals("整型"))
            {
                return "8";
            }
            else
            {
                return "4";
            }
        }

        private XmlElement GetConfigNode(string configString)
        {
            XmlDocument configDocument = new XmlDocument();
            configDocument.LoadXml(configString);
            return configDocument.DocumentElement;
        }

        /// <summary>
        /// 修改VIP客户档案
        /// </summary>
        /// <returns></returns>
        private bool VipConsumerModify()
        {
            int count = 0;
            string dataValue = "";
            string columnName = "";
            StringBuilder updateSql = new StringBuilder();
            updateSql.Append("update VipConsumer set ");
            foreach (Control ctl in ucContainer.Controls[0].Controls)
            {
                columnName = ctl.Name.ToLower();
                dataValue = ucContainer.GetControlValue(ctl.Name).Trim();
                if ((columnName.Equals("fintbirthdayyear") || columnName.Equals("fintbirthdaymonth") || columnName.Equals("fintbirthdayday")) && (dataValue == ""))
                {
                    dataValue = "null";
                    updateSql.AppendFormat("{0}={1},", columnName, dataValue);
                }
                else
                {
                    updateSql.AppendFormat("{0}='{1}',", columnName, dataValue);
                }
            }
            updateSql.Append("fbitexport='0'");
            updateSql.Append(" where fchrvipconsumerid in(");
            updateSql.Append("select  fchrvipconsumerid from VipCodeCollate where ");
            updateSql.AppendFormat("fchrVipCode='{0}')", vipCode);

            count = SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, updateSql.ToString());
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool isCardUsed = false;
            string fchrvipcardclassid = ucContainer.GetControlValue("fchrVIPCardClassID").Trim();
            if (fchrvipcardclassid.Equals(""))
            {
                (ucContainer.GetControl("fchrVIPCardClassID") as Control).Focus();
                RetailMessageBox.ShowWarning("VIP客户级别不能为空！");
                return;
            }
            if (ucContainer.GetControlValue("fnarconsumername").Trim().Equals(""))
            {
                (ucContainer.GetControl("fnarconsumername") as Control).Focus();
                RetailMessageBox.ShowWarning("客户名称不能为空");
                return;
            }
            string fdtmbirthdayyear = ucContainer.GetControlValue("fintbirthdayyear").Trim();
            int result = 0;
            if (!fdtmbirthdayyear.Equals(""))
            {
                if (Int32.TryParse(fdtmbirthdayyear, out result))
                {
                    if (!(result >= 1900 && result <= 2099))
                    {
                        (ucContainer.GetControl("fintbirthdayyear") as Control).Focus();
                        RetailMessageBox.ShowWarning("出生年只能录入1900-2099之间！");
                        return;
                    }
                }
                else
                {
                    (ucContainer.GetControl("fintbirthdayyear") as Control).Focus();
                    RetailMessageBox.ShowWarning("出生年只能录入数字！");
                    return;
                }
            }
            string fdtmbirthdaymonth = ucContainer.GetControlValue("fintbirthdaymonth").Trim();
            if (!fdtmbirthdaymonth.Equals(""))
            {
                if (Int32.TryParse(fdtmbirthdaymonth, out result))
                {
                    if (!(result > 0 && result < 13))
                    {
                        (ucContainer.GetControl("fintbirthdaymonth") as Control).Focus();
                        RetailMessageBox.ShowWarning("出生月只能录入1-12之间！");
                        return;
                    }
                }
                else
                {
                    (ucContainer.GetControl("fintbirthdaymonth") as Control).Focus();
                    RetailMessageBox.ShowWarning("出生月只能录入数字！");
                    return;
                }
            }
            string fdtmbirthdayday = ucContainer.GetControlValue("fintbirthdayday").Trim();
            if (!fdtmbirthdayday.Equals(""))
            {
                if (Int32.TryParse(fdtmbirthdayday, out result))
                {
                    if (!(result > 0 && result < 32))
                    {
                        (ucContainer.GetControl("fintbirthdayday") as Control).Focus();
                        RetailMessageBox.ShowWarning("出生日只能录入1-31之间！");
                        return;
                    }
                }
                else
                {
                    (ucContainer.GetControl("fintbirthdayday") as Control).Focus();
                    RetailMessageBox.ShowWarning("出生日只能录入数字！");
                    return;
                }
            }
            IDbTransaction tran = null;
            if (isAddConsumer)
            {
                string fchrVipCode = ucContainer.GetControlValue("fchrVipCode").Trim();
                if (fchrVipCode.Equals(""))
                {
                    (ucContainer.GetControl("fchrVipCode") as Control).Focus();
                    RetailMessageBox.ShowWarning("VIP卡号不能为空！");
                    return;
                }
                else
                {
                    ////CheckVipPhoneUsed(string strPhone)
                    //VipDoWith.VipDoWith vipClass = new UFIDA.Retail.VipDoWith.VipDoWith();
                    //string fchrPhone = ucContainer.GetControlValue("fnarmobilephone").Trim();

                    //bool resultTmp = vipClass.CheckVipPhoneUsed22(fchrPhone, strVipConsumerID);
                    //if (!resultTmp)
                    //    return;

                    //因界面控件太多，如果用存储过程会导致要用太多参数，还是考虑把SQL写在C#代码中
                    //事务中将已经给其他客户的卡截掉，同样这段也放在代码中，存储过程中不可避免要用游标，因为要考虑卡号部分匹配的情况。
                    SqlConnection sqlconnection = new SqlConnection(SysPara.ConnectionString);
                    SqlAccess.Open(sqlconnection);
                    tran = SqlAccess.BeginTransaction(sqlconnection);
                    string strSQL = "";
                    string strCardUserName = "";
                    string strCardConsumerID = "";
                    string strVipCards = "";
                    string strNewVipCards = "";

                    strSQL = string.Format("SELECT fchrvipconsumerid,fchrvipcards,fnarconsumername FROM Vipconsumer WHERE CHARINDEX('{0}',fchrVipCards)>0", fchrVipCode);
                    DataTable dtTmp = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, strSQL);
                    if (dtTmp != null && dtTmp.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtTmp.Rows)
                        {
                            strVipCards = dr["fchrvipcards"].ToString();
                            string[] strCards = strVipCards.Split(',');
                            strNewVipCards = "";
                            for (int i = 0; i < strCards.Length; i++)
                            {
                                if (strCards[i] == fchrVipCode)
                                {
                                    isCardUsed = true;
                                    strCardUserName = dr["fnarconsumername"].ToString();
                                    strCardConsumerID = dr["fchrvipconsumerid"].ToString();
                                }
                                else
                                {
                                    if (strNewVipCards.Length > 0)
                                        strNewVipCards += "," + strCards[i];
                                    else
                                        strNewVipCards += strCards[i];
                                }
                            }
                            if (isCardUsed)
                                break;
                        }
                    }
                    #region ----------------20100919修改
                    if (isCardUsed)
                    {
                        string strMessage = string.Format("该卡号已被客户[{0}]使用，不能保存！", strCardUserName);
                        ///////////20100919修改by MZY：卡号被使用则不能保存
                        RetailMessageBox.ShowWarning(strMessage);
                        return;
                        //string strMessage = string.Format("该卡号已被客户[{0}]使用，是否继续？", strCardUserName);
                        //if (RetailMessageBox.ShowQuestion(strMessage, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
                        //strSQL = string.Format("UPDATE  Vipconsumer SET fchrvipcards='{0}' WHERE fchrvipconsumerid='{1}'", strNewVipCards, strCardConsumerID);
                        //SqlAccess.ExecuteNonQuery(tran, CommandType.Text, strSQL);
                    }
                    vipCode = fchrVipCode;
                    //////////20100919 add by MZY 增加对卡级别和客户级别的判断
                    string VipConsumerClassID = "", VipCardClassID = "";
                    RefControl refVipClass = ucContainer.GetControl("fchrVIPCardClassID") as RefControl;
                    if (refVipClass != null)
                        VipConsumerClassID = refVipClass.RefID.Trim();
                    VIPCardControl vipCardControl = new VIPCardControl();
                    VipCardClassID = vipCardControl.GetVipCardClassID(vipCode);

                    if (VipConsumerClassID != VipCardClassID)
                    {
                        RetailMessageBox.ShowWarning("您选择的卡级别和客户级别不匹配，请重新选择！");
                        RefControl refVipCard = ucContainer.GetControl("fchrVipCode") as RefControl;
                        refVipCard.Clear();
                        return;
                    }
                    #endregion---------------
                }
            }
            else
            {
                //add by mzy 当修改VIP客户信息时判断卡级别和客户级别
                string VipConsumerClassID = "", VipCardClassID = "";
                RefControl refVipClass = ucContainer.GetControl("fchrVIPCardClassID") as RefControl;
                if (refVipClass != null)
                    VipConsumerClassID = refVipClass.RefID.Trim();
                vipCode = ucContainer.GetControlValue("fchrvipcards").Trim();

                VIPCardControl vipCardControl = new VIPCardControl();
                VipCardClassID = vipCardControl.GetVipCardClassID(vipCode);

                if (VipConsumerClassID != VipCardClassID)
                {
                    RetailMessageBox.ShowWarning("您选择的卡级别和客户级别不匹配，请重新选择！");
                    //refVipClass.Clear();
                    return;
                }
                //end
            }
            if (IsAddConsumer)
            {
                try
                {
                    if (VipConsumerAdd(tran))
                    {
                        fchrVipConsumerName = ucContainer.GetControlValue("fnarconsumername").Trim();
                        this.fchrVIPCardClass = (ucContainer.GetControl("fchrVIPCardClassID") as RefControl).RefName.Trim();
                        this.DialogResult = DialogResult.OK;
                        RetailMessageBox.ShowInformation(this, "保存成功");
                        tran.Commit();
                        //增加零售单和收款单  add by mzy 20100920
                        if (this.NewVipConsumerID != "" && this.vipCode != "")
                        {
                            VIPCardInventoryManage vipContrl = new VIPCardInventoryManage();
                            vipContrl.CreateDataVipCardInventory(this.vipCode, this.NewVipConsumerID, 0);
                        }
                    }
                    else
                    {
                        btnOk.DialogResult = DialogResult.No;
                    }
                }
                catch (Exception ex)
                {
                    RetailMessageBox.ShowInformation(this, ex.Message);
                    tran.Rollback();
                    btnOk.DialogResult = DialogResult.No;
                }
            }
            else
            {
                if (VipConsumerModify())
                {
                    RetailMessageBox.ShowInformation(this, "保存成功");
                    //872回写VIP显示信息
                    objFormRetail.SaveNote();
                    VipOperate objVipOperate = new VipOperate();
                    objVipOperate.FormRetail = objFormRetail;
                    objVipOperate.VipCode = vipCode;
                    objVipOperate.Init();

                    btnOk.DialogResult = DialogResult.OK;
                }
                else
                {
                    btnOk.DialogResult = DialogResult.No;
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 将小数位数转化为format形式
        /// </summary>
        /// <param name="decimalDigits"></param>
        /// <returns></returns>
        private string DecimalToFormat(string decimalDigits)
        {
            if (decimalDigits == null || decimalDigits == "")
            {
                return "#0";
            }
            else
            {
                string ret = "#0.";
                int Digits = Convert.ToInt32(decimalDigits);
                for (int i = 0; i < Digits; i++)
                {
                    ret += "0";
                }
                return ret;
            }
        }
        private void frmVIPConsumerInfoModify_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }
        private FormRetail objFormRetail = new FormRetail();
        /// <summary>
        /// 872chb
        /// </summary>
        public FormRetail FormRetail
        {
            set
            {
                objFormRetail = value;
                vipCode = objFormRetail.VipConsumeList.vipCode;
            }
        }
        //private FormNewRetail objFormNewRetail = new FormNewRetail();
        ///// <summary>
        ///// 872chb
        ///// </summary>
        //public FormNewRetail FormNewRetail
        //{
        //    set
        //    {
        //        objFormNewRetail = value;
        //        vipCode = objFormNewRetail.VipConsumeList.vipCode;
        //    }
        //}
        /// <summary>
        /// 添加VIP客户档案
        /// </summary>
        /// <returns></returns>
        private bool VipConsumerAdd(IDbTransaction tran)
        {
            int count = 0;
            string dataValue = "";
            string columnName = "";
            StringBuilder objBody = new StringBuilder();
            StringBuilder objHead = new StringBuilder();
            StringBuilder objSQL = new StringBuilder();
            string fchrVipCode = "";
            foreach (Control ctl in ucContainer.Controls[0].Controls)
            {
                columnName = ctl.Name.ToLower();
                dataValue = ucContainer.GetControlValue(ctl.Name).Trim();
                if (dataValue.Equals("")) continue;
                if (columnName.Equals("fchrvipcode"))
                {
                    fchrVipCode = dataValue;
                    continue;
                }
                objBody.AppendFormat("'{0}',", dataValue);
                objHead.AppendFormat("{0},", columnName);
            }

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.Append("");
            string fchrvipconsumerid = Guid.NewGuid().ToString();
            this.NewVipConsumerID = fchrvipconsumerid;
            objSQL.Append("Insert Into vipconsumer(");
            objSQL.Append(objHead.ToString());
            objSQL.Append("fbitexport,");
            objSQL.Append("fchrvipconsumerid,");
            objSQL.Append("fchrStoreid,fchrVipCards");
            objSQL.Append(")Values(");
            objSQL.Append(objBody.ToString());
            objSQL.Append("'0',");
            objSQL.AppendFormat("'{0}',", fchrvipconsumerid);
            objSQL.AppendFormat("'{0}',", SysPara.GetString("StoreId"));
            objSQL.AppendFormat("'{0}'", fchrVipCode);
            objSQL.Append(");");
            objSQL.Append("UPDATE VipCodeCollate SET fchrvipconsumerid =");
            objSQL.AppendFormat(" '{0}' ", fchrvipconsumerid);
            objSQL.AppendFormat(" Where fchrVipCode='{0}';", fchrVipCode);
            count = SqlAccess.ExecuteNonQuery(tran, CommandType.Text, objSQL.ToString());
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void frmVIPConsumerInfoModify_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                XmlNode objNode = xmlDoc.SelectSingleNode(@"Root/VipConsumer");
                objNode.Attributes["EditVIPConsumerFormHeight"].Value = this.Height.ToString();
                objNode.Attributes["EditVIPConsumerFormWidth"].Value = this.Width.ToString();
                //--872高丝
                ((XmlElement)objNode).SetAttribute("EditVIPConsumerFormLocationX", Location.X.ToString());
                ((XmlElement)objNode).SetAttribute("EditVIPConsumerFormLocationY", Location.Y.ToString());
                //--end
                string templateFile = string.Format(@"{0}\xml\Receipt\单据_零售单模板.xml", Tools.GetStringSysPara("DataPath"));
                xmlDoc.Save(templateFile);
            }
            catch { }
        }
    }
}