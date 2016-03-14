using UFIDA.Retail.Common;
using System.Windows.Forms;
using System;
using System.Xml;
using System.Data;
using System.Collections;
using UFIDA.Retail.Discount;
using UFIDA.Retail.RetailReceipt;
using System.Reflection;
using System.ComponentModel;
using System.Text;
using UFIDA.Retail.Utility;
using System.Data.SqlClient;
using UFIDA.Retail.Components;

namespace UFIDA.Retail.VIPCardControl
{
    /// <summary>
    /// VIPDiscount 的摘要说明。
    /// </summary>
    public class VIPDiscount : IDiscount, IRetailReceipt
    {

        private ItemData objItemData = null;
        public ItemData ItemData
        {
            get { return objItemData; }
            set { objItemData = value; }
        }
        private ModelItem objModelItem = null;
        public ModelItem ModelItem
        {
            get { return objModelItem; }
            set { objModelItem = value; }
        }
        private FormRetail objFormRetail = null;
        public FormRetail FormRetail
        {
            get { return objFormRetail; }
            set { objFormRetail = value; }
        }
        public bool IsZheKouKa;
        public bool IsPointForSP;
        public bool IsPointForSD;
        
        public void VIPCardClick()
        {
            clearBtnClick();
            objFormRetail.btUpdate1.Click += new EventHandler(btUpdate_Click);
            //WWobjFormRetail.ModelDisInfo.SetDisNodeAttributeValue();
            ModelDiscountInfo objMdlDisInfo = objFormRetail.ModelDisInfo;
            
            this.objModelItem.modelRetailVouch = objFormRetail.ModelRetailVouch;
            ItemDiscount(ref this.objModelItem, ref objMdlDisInfo);
        }

        private void clearBtnClick()
        {
            FieldInfo keyfi = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
            object eventkey = keyfi.GetValue(objFormRetail.btUpdate1);
            // Get the protected Events property
            PropertyInfo evtpi = typeof(Control).GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
            EventHandlerList evts = (EventHandlerList)evtpi.GetValue(objFormRetail.btUpdate1, null);
            // Obtain the value of the delegate and remove it
            Delegate dlg = evts[eventkey];
            evts.RemoveHandler(eventkey, dlg);
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            frmVIPConsumerInfoModify modify = new frmVIPConsumerInfoModify();
            modify.FormRetail = this.objFormRetail;
            
            modify.ShowDialog();
        }

        /// <summary>
        /// VIP单品计算
        /// </summary>
        /// <param name="objModelItem"></param>
        /// <param name="MdlDisInfo"></param>
        /// <returns></returns>
        public bool ItemDiscount(ref ModelItem objModelItem, ref ModelDiscountInfo objMdlDisInfo)
        {
            //不修改原单退货行的VIP信息
            if (objModelItem.IsReferData)
                return true;
            string strVipCode = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP折扣", "VIP卡号"));
            bool IsNewItem = Tools.GetBoolColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP折扣", "是新商品"));

            //VIP折扣判断处理
            if (!ExecuteDistinguish(ref objModelItem, ref objMdlDisInfo))
            {
                return false;
            }
            if (strVipCode.Trim().Equals("") || (!IsNewItem))
            {
                //显示VIP窗体资源是否存在
                if (objMdlDisInfo.FrmVIPDisplay != null)
                {
                    if (!objMdlDisInfo.FrmVIPDisplay.IsDisposed)
                    {
                        return false;
                    }
                }
                bool isSuccee = false;
                isSuccee = GetVIPDiscountParameter(ref objMdlDisInfo, ref objModelItem);
                if (!isSuccee) return false;
                //VIP整单计算
                ItemData objItemData = objModelItem.ItemData;
                return ItemDiscount(ref  objItemData, ref objMdlDisInfo);
            }
            //VIP折扣算法
            return ItemVIPDiscount(ref objModelItem, ref objMdlDisInfo);
        }

        /// <summary>
        /// VIP整单计算
        /// </summary>
        /// <param name="objItemData"></param>
        /// <param name="objModelDiscountInfo"></param>
        /// <returns></returns>
        public bool ItemDiscount(ref ItemData objItemData, ref ModelDiscountInfo objMdlDisInfo)
        {
            ModelItem objModelItem = new ModelItem();
            for (int i = 0; i < objItemData.Count; i++)
            {
                objModelItem = objItemData[i];
                //不修改原单退货行的VIP信息
                if (objModelItem.IsReferData)
                    continue;
                //VIP折扣算法
                ItemVIPDiscount(ref objModelItem, ref objMdlDisInfo);
            }
            return true;
        }
        /// <summary>
        /// VIP折扣算法
        /// </summary>
        /// <param name="objModelItem">商品信息</param>
        /// <param name="objMdlDisInfo">折扣信息</param>
        /// <returns>返回折扣是否正确</returns>
        private bool ItemVIPDiscount(ref ModelItem objModelItem, ref ModelDiscountInfo objMdlDisInfo)
        {
            //二、取VIP单价
            string VipDiscountLevelID = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP折扣", "折扣等级"));
            string strVipCode = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP折扣", "VIP卡号"));
            objModelItem.ModelVIP.VipDiscountLevelID = VipDiscountLevelID;
            objModelItem.ModelVIP.VIPCode = strVipCode;
            if (objModelItem.IsSalesPromotion)
            {
                return false;
            }
            if (!(objModelItem.Quantity > 0))
            {
                return false;
            }
            //一、商品是否能使用VIP卡
            if (!objModelItem.ModelVIP.IsCanBeVIP)
            {
                return false;
            }
            if (objModelItem.IsPromotionGroup)
            {
                return false;
            }
            if (objModelItem.IsLargess)
            {
                return false;
            }
            

            objModelItem.AccountReceivable = objModelItem.Quantity * objModelItem.QuotePrice;     //应销价

            objModelItem.DisUnitPrice = objModelItem.ModelVIP.VIPUnitPrice;


            objModelItem.FactSellMoney = objModelItem.Quantity * objModelItem.DisUnitPrice;       //实销价
            objModelItem.DiscountRate = ItemData.Mod(objModelItem.FactSellMoney, objModelItem.AccountReceivable) * 100;

            objModelItem.ModelVIP.VipDiscountMoney = objModelItem.AccountReceivable - objModelItem.FactSellMoney;//VIP折扣额
            objModelItem.ModelVIP.VipDiscountRate = ItemData.Mod((objModelItem.AccountReceivable - objModelItem.ModelVIP.VipDiscountMoney), objModelItem.AccountReceivable) * 100;
            objModelItem.ModelVIP.IsVIP = true;
            //五、计算卡类折扣处理
            objModelItem.CardTypeDisMoney = objModelItem.ModelVIP.VipDiscountMoney;
            objModelItem.CardTypeDisRate = ItemData.Mod((objModelItem.AccountReceivable - objModelItem.CardTypeDisMoney), objModelItem.AccountReceivable) * 100;
            objModelItem.DiscountMoney = objModelItem.AccountReceivable - objModelItem.FactSellMoney;
            objModelItem.SalesPromotionPrice = objModelItem.DisUnitPrice;
            objModelItem.ItemData.Update(objModelItem, objModelItem.RowIndex);
            return true;
        }
        /// <summary>
        /// 获取VIP折扣参数处理
        /// </summary>
        /// <returns>返回参数信息</returns>
        private bool GetVIPDiscountParameter(ref ModelDiscountInfo objMdlDisInfo, ref ModelItem objModelItem) {
            XmlDocument doc = new XmlDocument();
            XmlNode xmlNode;
            System.Reflection.Assembly objAss;
            object obj;
            string OutXML = "";

            //设置参数
            string dir = Application.StartupPath;
            string strComName = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP折扣", "组件名称"));
            string strClassName = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP折扣", "类名称"));
            dir += "\\" + strComName;
            objAss = System.Reflection.Assembly.LoadFile(dir);
            obj = objAss.CreateInstance(strClassName);
            string strVipCardCode = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP折扣", "VIP卡号"));
            string VipDiscountType = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP折扣", "折扣等级"));

            System.Text.StringBuilder objXML = new System.Text.StringBuilder();
            //--------------------------------
            //礼券结算时允许VIP折扣的相关判断
            //--------------------------------
            int IsGiftTokenVIPDiscount = objModelItem.ItemData.IsGiftTokenVIPDiscount;
            int IsCardVIPDiscount = objModelItem.ItemData.IsGiftTokenVIPDiscount;
            int IsAllowGiftToken = objModelItem.modelRetailVouch.IsAllowGiftToken;
            int IsAllowStoreCard = objModelItem.modelRetailVouch.IsAllowStoreCard;

            GiftTokenSetVIPDiscount(ref objModelItem);
            CardSetVIPDiscount(ref objModelItem);
            frmVipCardCode objForm = new frmVipCardCode();
            DateTime RepairBillDate = FormRetail.ItemData.RepairBillDate;
            objForm.RepairBillDate = RepairBillDate;

            objForm.chIsZheKouKa.Checked = IsZheKouKa;
            ArrayList objVIPList = new ArrayList();
            objVIPList.Add(strVipCardCode);
            objVIPList.Add(objModelItem.ItemData.RepairBillDate.ToString());
            objForm.Tag = objVIPList;
            //SWC 开单界面VIP窗体确定之后的效率问题，窗体frmVipCardCode中的strVipConsumerID的值不延续到此，此处只延续strVipCardCode的值，strVipCardCode的查询按理不会有查询效率的问题。
            //延续strVipConsumerID的话需要修改一些数据接口以延续其值。且在窗体再次打开时要传递进去。
            objForm.ShowDialog();
            IsZheKouKa = objForm.chIsZheKouKa.Checked;    //是否使用折扣卡
            IsPointForSP = objForm.chbIsPointForSP.Checked;  //是否允许促销活动只积分不打折 
            IsPointForSD = objForm.chbIsPointForSD.Checked;  //是否允许现场折扣只积分不打折
            OutXML = (string)objForm.Tag;
            if (OutXML.Equals(""))//VIP界面点取消后，还原礼券结算和储值卡结算对VIP折扣的控制。
            {
                objModelItem.ItemData.IsGiftTokenVIPDiscount = IsGiftTokenVIPDiscount;
                objModelItem.ItemData.IsCardVIPDiscount = IsCardVIPDiscount;
                objModelItem.modelRetailVouch.IsAllowGiftToken = IsAllowGiftToken;
                objModelItem.modelRetailVouch.IsAllowStoreCard = IsAllowStoreCard;
                return false;
            }
            else
            {
                doc.LoadXml(OutXML);
                xmlNode = doc.DocumentElement;
                objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "折扣状态", "True");
                objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "VIP卡号", xmlNode.Attributes["VipCardCode"].Value);

                try
                {
                    //胜龙二开，改变折扣换算折扣率
                    objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "VIP等级", "0");
                    String vIPCardCode = xmlNode.Attributes["VipCardCode"].Value;
                    StringBuilder objSQL2 = new StringBuilder();
                    objSQL2.AppendFormat("SELECT COUNT(*) as Num FROM dbo.RetailVouch rv WHERE rv.fchrvipconsumerid =(select v.fchrvipconsumerid from vipconsumer v LEFT JOIN VipCodeCollate vcc ON v.fchrvipconsumerid = vcc.fchrvipconsumerid where vcc.fchrVipCode = '{0}') and flotGatheringMoney <> 0;", vIPCardCode);  //判断是否首次消费
                    objSQL2.Append("SELECT * FROM dbo.vipcardtype WHERE fnarcardtypename='蓝卡';");  //默认为蓝卡
                    //objSQL2.AppendFormat("SELECT TOP 1 flotPointBalance,fintTotalPoints,fchrVIPCardClassName,fbitCheck FROM ViewVipConsumerList WHERE fchrVipCode = '{0}';", vIPCardCode);
//                    objSQL2.AppendFormat(@"SELECT TOP 1 flotPointBalance,fintTotalPoints,fchrVIPCardClassName,fbitCheck FROM ViewVipConsumerList WHERE fchrVipCode =(select top 1 fchrVipCards from vipconsumer
//                                                                                                                                                                     where fchrvipconsumerid = (select top 1 fchrvipconsumerid from vipcodecollate 
//                                                                                                                                                                                                where fchrvipcode = '{0}'));", vIPCardCode);
                    objSQL2.AppendFormat(@"select convert(int,(ISNULL(v.fintMinusTotal, 0) + ISNULL(v.fintReturnTotal, 0) + ISNULL(v.flotInitialTotal, 0) 
                                         + ISNULL(v.fintTotal, 0)+IsNull(fintInitTotal,0))) as flotPointBalance,Convert(int,ISNULL(v.fintReturnTotal, 0) +Isnull(v.fintInitTotal,0)+ ISNULL(v.fintTotal, 0) + ISNULL(v.flotInitialTotal, 0)) as fintTotalPoints,
                                         vcc.fchrVIPCardClassName,Convert(bit,isnull(v.fbitCheck,0)) as fbitCheck from vipconsumer v 
                                         left join vipcodecollate vct on vct.fchrvipconsumerid = v.fchrvipconsumerid
                                         left join VIPCardClass vcc on vcc.fchrVIPCardClassId = vct.S01_fchrVIPCardClassID
                                         where vct.fchrVipCode = '{0}'", vIPCardCode);
                    objSQL2.AppendFormat("select * from VipCodeCollate vcc left join VIPCardClass vc on vc.fchrVIPCardClassId = vcc.S01_fchrVIPCardClassID where fchrVipCode = '{0}';", vIPCardCode);  //获取卡级别信息 by pj 20120815
                    SqlParameter[] param = {
                                                 new SqlParameter("@fchrVipCardCode",vIPCardCode),
                                                 new SqlParameter("@fchrVIPCardClassName",SqlDbType.VarChar,30)
                                               };
                    param[1].Direction = ParameterDirection.Output;
                    bool IsBirthDayFlag = Convert.ToBoolean(SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.StoredProcedure, "sl_proc_CheckCusIsBirthDay", param));  //根据管理端预置的生日正负天数判断是否满足享受生日折扣的条件 by pj
                    //更新VIP客户档案上的生日折扣标志 add by pj 20140219
                    UpdateBirFlag(vIPCardCode);
                    string fchrCurrentCardClassName = param[1].Value.ToString();
                    DataSet objDes3 = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, objSQL2.ToString());
                    if (Convert.ToInt32(objDes3.Tables[0].Rows[0]["Num"].ToString()) == 0 && (Convert.ToInt32(objDes3.Tables[2].Rows[0]["flotPointBalance"]) == 0 && Convert.ToInt32(objDes3.Tables[2].Rows[0]["fintTotalPoints"]) == 0) && (objDes3.Tables[3].Rows[0]["fbitDisCountforFirstConsume"].ToString() == "False"))  //首次消费不打折
                    {
                        if (objDes3.Tables[1].Rows.Count > 0)
                        {
                            objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "折扣等级", objDes3.Tables[1].Rows[0]["fchrvipcardtypeid"].ToString());
                        }
                    }
                    else if (IsPointForSP)  //促销活动是否只积分不打折
                    {
                        if (objDes3.Tables[1].Rows.Count > 0)
                        {
                            objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "折扣等级", objDes3.Tables[1].Rows[0]["fchrvipcardtypeid"].ToString());
                        }
                    }
                    else if (IsPointForSD)   //现场折扣是否只积分不打折
                    {
                        if (objDes3.Tables[1].Rows.Count > 0)
                        {
                            objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "折扣等级", objDes3.Tables[1].Rows[0]["fchrvipcardtypeid"].ToString());
                        }
                    }
                    //else if (Convert.ToInt32(objDes3.Tables[2].Rows[0]["Num"].ToString()) > 0 &&Convert.ToInt32(objDes3.Tables[0].Rows[0]["Num"].ToString()) > 0)
                    else if (IsBirthDayFlag && GetBirthDiscountCount(vIPCardCode))  //判断是否享受生日折扣 by pj 20120221 //判断当前消费VIP客户是否本月享有生日折扣次数是否大于等于1 by pj 20131106
                    {
                        if (MessageBox.Show("该客户本月享有一次生日折扣，是否使用生日折扣？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            StringBuilder objSQL = new StringBuilder();
                            objSQL.Append("SELECT top 1  fchrvipcardtypeid FROM dbo.vipcardtype WHERE ISNULL(fnarmemo, '') =");
                            if (fchrCurrentCardClassName.IndexOf("申办") != -1 && Convert.ToInt32(objDes3.Tables[2].Rows[0]["fbitCheck"]) == 1)
                            {
                                objSQL.AppendFormat(" RIGHT('{0}',2)", fchrCurrentCardClassName);
                            }
                            else
                            {
                                objSQL.AppendFormat(" ISNULL(( SELECT  fnarcardtypename FROM dbo.vipcardtype t LEFT JOIN dbo.VIPCardClass c ON t.fchrvipcardtypeid = c.fchrVIPCardTypeid LEFT JOIN dbo.VipConsumer s ON c.fchrVIPCardClassID = s.fchrVIPCardClassID WHERE  s.fchrVipCards = '{0}'), '')", vIPCardCode);
                            }
                            string strCardTypeId = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, objSQL.ToString()).ToString();  //获取折扣等级ID
                            if (strCardTypeId != "")
                            {
                                if (objModelItem.IsSpecial)
                                {
                                    objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "折扣等级", strCardTypeId.ToString());
                                    //特价为 VIP等级为一级
                                    objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "VIP等级", "1");
                                }
                                else
                                {
                                    objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "折扣等级", strCardTypeId.ToString());
                                }
                            }
                            StringBuilder sbInsertTmp = new StringBuilder();
                            //Modify by pj 20130121
                            CreateTmpTable(GetComputerInfo() + "_" + SysPara.GetSysPara("操作员名称").ToString() + "_Temp1");  //创建临时表
                            sbInsertTmp.AppendFormat("insert into [{0}](fchrVipCardCode,fbitBirDiscMonth)", GetComputerInfo() + "_" + SysPara.GetSysPara("操作员名称").ToString() + "_Temp1".Replace("-", "_").Replace("-", "_"));
                            sbInsertTmp.AppendFormat(" values('{0}',1)", vIPCardCode);
                            SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, sbInsertTmp.ToString(), null);  //将数据插入到临时表中
                        }
                        else
                        {
                            if (fchrCurrentCardClassName.IndexOf("申办") != -1 && Convert.ToInt32(objDes3.Tables[2].Rows[0]["fbitCheck"]) == 1)
                            {
                                SBdiscount(objMdlDisInfo, objDes3);
                            }
                            else
                            {
                                objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "折扣等级", xmlNode.Attributes["VipDiscountLevelID"].Value);
                            }
                        }
                    }
                    else if (objDes3.Tables[2].Rows[0]["fchrVIPCardClassName"].ToString().IndexOf("申办") != -1 && !string.IsNullOrEmpty(Convert.ToString(objDes3.Tables[2].Rows[0]["fbitCheck"])))  //判断是否为申办卡
                    {
                        if (Convert.ToInt32(objDes3.Tables[2].Rows[0]["fbitCheck"]) == 1)
                            SBdiscount(objMdlDisInfo, objDes3);
                        else
                            objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "折扣等级", xmlNode.Attributes["VipDiscountLevelID"].Value);
                    }
                    else
                    {
                        string S01_VipDiscountLevelID = string.Empty;
                        string S01_NewVipCardCode = string.Empty;
                        //如果当前使用的卡号是旧卡卡号并且新晋级的VIP已经审核通过则使用新卡级别的折扣
                        if (Convert.ToInt32(SqlAccess.ExecuteScalar(SysPara.ConnectionString,CommandType.Text,string.Format(@"select Count(1) from S01_VIPCardChangeRecord where S01_fchrOldCardCode = '{0}' and isnull(fbitVerify,0) = 1",vIPCardCode))) > 0)
                        {
                            S01_NewVipCardCode = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, string.Format(@"select top 1 S01_fchrNewCardCode from S01_VIPCardChangeRecord where S01_fchrOldCardCode = '{0}' and isnull(fbitVerify,0) = 1", vIPCardCode)).ToString();
                            S01_VipDiscountLevelID = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, string.Format(@"select fchrVIPCardTypeid from vipcardclass vcc
                                                                                                                                         left join vipcodecollate vc on vcc.fchrvipcardclassid = vc.S01_fchrvipcardclassid
                                                                                                                                         where fchrVipCode = '{0}'", S01_NewVipCardCode)).ToString();
                            if(!string.IsNullOrEmpty(S01_VipDiscountLevelID))
                                objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "折扣等级", S01_VipDiscountLevelID);
                        }
                        else
                        {
                            objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "折扣等级", xmlNode.Attributes["VipDiscountLevelID"].Value);
                        }
                    }

                    if (IsZheKouKa)  //判断是否使用折扣卡
                    {
                        if (objDes3.Tables[1].Rows.Count > 0)
                        {
                            objMdlDisInfo.Isvipused = "false";
                            objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "折扣等级", objDes3.Tables[1].Rows[0]["fchrvipcardtypeid"].ToString());
                        }
                    }
                    else
                        objMdlDisInfo.Isvipused = "true";

                    strVipCardCode = xmlNode.Attributes["VipCardCode"].Value;
                    InitVipInfo(strVipCardCode);
                }
                catch (Exception ex) { RetailMessageBox.ShowException(ex.Message); }
            }
            objAss = null;
            obj = null;
            bool isDisplayList = Tools.GetBoolColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP折扣", "是否显示祥细"));
            if (!isDisplayList) return true;
            dir = Application.StartupPath;
            strComName = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP折扣", "显示组件名"));
            strClassName = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP折扣", "显示类名"));
            dir += "\\" + strComName;
            return true;
        }

        /// <summary>
        /// 更新VIP客户档案上的生日折扣标志
        /// </summary>
        /// <param name="fchrvipconsumerid"></param>
        private void UpdateBirFlag(string vIPCardCode)
        {
            int fintBirthdayMonth = 0;
            fintBirthdayMonth = Convert.ToInt32(SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, string.Format(@"select top 1 isnull(fintBirthdayMonth,0) as fintBirthdayMonth from vipconsumer where fchrvipconsumerid = (select top 1 fchrvipconsumerid from vipcodecollate where fchrvipcode = '{0}')", vIPCardCode)));
            if (fintBirthdayMonth != DateTime.Now.Month)
            {
                SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, string.Format(@"update vipconsumer set fbitIsUseBirDisCount = 0,fbitExport = 0 where fchrvipconsumerid = (select top 1 fchrvipconsumerid from vipcodecollate where fchrvipcode = '{0}') and isnull(fbitIsUseBirDisCount,0) = 1", vIPCardCode));
            }
        }

        /// <summary>
        /// 获取当前消费VIP客户在当月享受生日折扣次数，当月消费不允许大于1 by pj 20131106
        /// </summary>
        /// <returns></returns>
        private bool GetBirthDiscountCount(string strVIPCardCode)
        {
            bool flag = true;
            object obj = null;
            int Count = 0;
            string sql = string.Format(@"select Count(*) from retailvouch where fnarvipcardcode = '{0}' and Month(fdtmDate) = Month(getDate()) and Isnull(fbitIsBirConsume,0) = 1", strVIPCardCode);
            obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sql);
            if (obj != null)
            {
                Count = Convert.ToInt32(obj.ToString());
            }

            if (Count >= 1)
                flag = false;

            return flag;
        }

        /// <summary>
        /// 申办卡在审核通过的情况下允许享受折扣 by pj
        /// </summary>
        /// <param name="objMdlDisInfo"></param>
        /// <param name="objDes3"></param>
        private void SBdiscount(ModelDiscountInfo objMdlDisInfo, DataSet objDes3) {
            StringBuilder sbDisType = new StringBuilder();
            sbDisType.AppendFormat(@"SELECT top 1 vct.fchrvipcardtypeid FROM dbo.vipcardtype vct
		                                   LEFT JOIN dbo.VIPCardTypeDetail vctd ON vct.fchrvipcardtypeid = vctd.fchrVIPCardTypeID
		                                   WHERE vct.fnarcardtypename = RIGHT('{0}',2)", objDes3.Tables[2].Rows[0]["fchrVIPCardClassName"].ToString());
            string fchrvipcardtypeid = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, sbDisType.ToString()).Rows[0][0].ToString();

            objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "折扣等级", fchrvipcardtypeid);   //新增申办卡在已审核状态下能够享受VIP折扣
        }

        /// <summary>
        /// 获取计算机名
        /// </summary>
        /// <param name="sValueType"></param>
        /// <returns></returns>
        private string GetComputerInfo() {
            string MachineName = string.Empty;
            MachineName = Environment.MachineName.Replace('-', '_');
            return MachineName;
        }

        /// <summary>
        /// 创建临时表 by pj
        /// </summary>
        /// <param name="tableName"></param>
        private void CreateTmpTable(string tableName) { 
           StringBuilder sbTblCreate = new StringBuilder();
           tableName = tableName.Replace("-", "_");
           sbTblCreate.AppendFormat("if exists (select 1 from sysobjects where id = object_id(N'{0}') and type='U')", tableName);
           sbTblCreate.AppendFormat(" drop table [{0}]", tableName);
           sbTblCreate.Append("\r\n");
           //sbTblCreate.Append("GO");
           //sbTblCreate.Append("\r\n");
           sbTblCreate.AppendFormat(" create table [{0}](", tableName);
           sbTblCreate.Append("ID uniqueidentifier default newid() not null,");
           sbTblCreate.Append("fchrVipCardCode varchar(30) null,");
           sbTblCreate.Append("fbitBirDiscMonth bit default 0");
           sbTblCreate.Append(")");
           SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, sbTblCreate.ToString());
        }

        private void InitVipInfo(string strVipCardCode)
        {
            VipOperate objVipOperate = new VipOperate();
            objVipOperate.FormRetail = objFormRetail;
            
            objVipOperate.VipCode = strVipCardCode;
            objVipOperate.Init();
        }
        /// <summary>
        /// 礼券设置折扣处理
        /// </summary>
        private void GiftTokenSetVIPDiscount(ref ModelItem objModelItem)
        {
            bool IsGiftToken = SysPara.GetBoolean("IsGiftToken");//是否启用礼券
            bool SettleByVIP = SysPara.GetBoolean("SettleByVIP");//礼券结算时允许VIP折扣
            bool IsExistSettleStyleByGiftToken = DiscountData.IsExistSettleStyleByGiftToken();//是否存礼券的结算方式
            if (IsGiftToken && !SettleByVIP && IsExistSettleStyleByGiftToken)
            {
                if (ItemData.MessageBox("VIP折扣", "VIP0025") == DialogResult.Yes)
                {
                    objModelItem.ItemData.IsGiftTokenVIPDiscount = 0;// false;
                    if (objModelItem.modelRetailVouch != null)
                    {
                        objModelItem.modelRetailVouch.IsAllowGiftToken = 1;
                    }
                }
                else
                {
                    objModelItem.ItemData.IsGiftTokenVIPDiscount = 1;// true;
                    if (objModelItem.modelRetailVouch != null)
                    {
                        objModelItem.modelRetailVouch.IsAllowGiftToken = 0;
                    }
                }
            }
        }
        /// <summary>
        /// 储值卡设置折扣处理
        /// </summary>
        private void CardSetVIPDiscount(ref ModelItem objModelItem)
        {
            bool IsGiftToken = SysPara.GetBoolean("IsStoredCard");//是否启用储值卡
            bool SettleByVIP = SysPara.GetBoolean("StoredCardAllowVIPDiscount");//储值卡结算时允许VIP折扣
            bool IsExistSettleStyleByGiftToken = DiscountData.IsExistSettleStyleByCard();//是否存在储值卡的结算方式
            if (IsGiftToken && !SettleByVIP && IsExistSettleStyleByGiftToken)
            {
                if (ItemData.MessageBox("VIP折扣", "VIP0026") == DialogResult.Yes)
                {
                    objModelItem.ItemData.IsCardVIPDiscount = 0;// false;
                    if (objModelItem.modelRetailVouch != null)
                    {
                        objModelItem.modelRetailVouch.IsAllowStoreCard = 1;
                    }
                }
                else
                {
                    objModelItem.ItemData.IsCardVIPDiscount = 1;// true;
                    if (objModelItem.modelRetailVouch != null)
                    {
                        objModelItem.modelRetailVouch.IsAllowStoreCard = 0;
                    }
                }
            }
        }
        /// <summary>
        /// VIP折扣判断处理
        /// </summary>
        /// <param name="objModelItem">商品信息</param>
        /// <param name="objMdlDisInfo">折扣信息</param>
        /// <returns>返回判断处理结果</returns>
        public bool ExecuteDistinguish(ref ModelItem objModelItem, ref ModelDiscountInfo objMdlDisInfo)
        {
            bool IsNewItem = Tools.GetBoolColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP折扣", "是新商品"));
            objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "是新商品", "False"); //设置为非新商品
            ItemData objItemData = objModelItem.ItemData;
            string strVipCode = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP折扣", "VIP卡号"));

            if (objItemData.PresellState == 4 || objItemData.PresellState == 3)
            {
                if (strVipCode.Equals(""))
                {
                    ItemData.MessageBox("预订", "YD0023");
                }
                else
                {
                    ItemData.MessageBox("预订", "YD0041");
                }
                return false;
            }
            if (objItemData.PresellState == 5 || objItemData.PresellState == 6)
            {
                if (strVipCode.Equals(""))
                {
                    ItemData.MessageBox("预订", "YD0024");
                }
                else
                {
                    ItemData.MessageBox("预订", "YD0042");
                }
                return false;
            }
            //四、退货状态
            //if (!ItemData.IsSaleState)
            //{
            //    ItemData.MessageBox("VIP折扣", "VIP0005");
            //    return false;
            //}
            //一、促销活动
            bool IsSalesPromotionExecuteState = Tools.GetBoolColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("促销活动", "折扣状态"));
            if (IsSalesPromotionExecuteState && (!IsNewItem))
            {
                //放开选择并执行促销活动后不允许再使用VIP卡的限制 by pj 20130709
                //ItemData.MessageBox("VIP折扣", "VIP0001");
                //return false;
            }
            //二、促销组合
            bool IsSalesPromotionGroupExecuteState = Tools.GetBoolColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("促销组合", "折扣状态"));
            if (IsSalesPromotionGroupExecuteState && (!IsNewItem))
            {
                string salesPromotionGroupID = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("促销组合", "促销组合ID"));
                if ((!objModelItem.ItemData.IsEndPromotionGroup(objModelItem.ItemData.Count - 1) && objModelItem.ItemData[objModelItem.ItemData.Count - 1].IsPromotionGroup) || !salesPromotionGroupID.Equals(""))
                {
                    ItemData.MessageBox("VIP折扣", "VIP0006");
                    return false;
                }
                else
                {
                    if (!IsNewItem)
                    {
                        ItemData.MessageBox("VIP折扣", "VIP0002");
                        return false;
                    }
                }
            }
            //三、折扣卡
            bool IsDiscountCardExecuteState = Tools.GetBoolColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("折扣卡", "折扣状态"));
            if (IsDiscountCardExecuteState && (!IsNewItem))
            {
                ItemData.MessageBox("VIP折扣", "VIP0003");
                return false;
            }
            //四、现场折扣
            bool IsSceneDiscountExecuteState = Tools.GetBoolColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("现场折扣", "折扣状态"));
            if (IsSceneDiscountExecuteState && (!IsNewItem))
            {
                //放开执行现场折扣后不允许再使用VIP卡的限制 by pj 20130709
                //ItemData.MessageBox("VIP折扣", "VIP0004");
                //return false;
            }

            return true;
        }

        /// <summary>
        /// 退还货状态 add by pj 20140225
        /// </summary>
        public void ChangeStatus()
        {
            if (objFormRetail.ItemData.PresellState == 4 || objFormRetail.ItemData.PresellState == 3)
            {
                ItemData.MessageBox("预订", "YD0031");
                return;
            }
            if (objFormRetail.ItemData.PresellState == 5 || objFormRetail.ItemData.PresellState == 6)
            {
                ItemData.MessageBox("预订", "YD0032");
                return;
            }
            if (objFormRetail.ItemData.PresellState == 1 || objFormRetail.ItemData.PresellState == 2)
            {
                ItemData.MessageBox("预订", "YD0038");
                return;
            }
            string SalesPromotionGroupID = objFormRetail.ModelDisInfo.GetDisNodeAttributeValue("促销组合", "促销组合ID").ToString();
            bool IsSalesPromotion = Tools.GetBoolColumnValue(objFormRetail.ModelDisInfo.GetDisNodeAttributeValue("促销活动", "折扣状态"));
            if (ItemData.IsSaleState)//退货
            {
                if (SalesPromotionGroupID != string.Empty)
                {
                    ItemData.MessageBox("退换货", "THH0002");//当前状态为促销操作，按【F11】结束后才能启用退货状态切换。
                    return;
                }
                if (IsSalesPromotion)
                {
                    ItemData.MessageBox("退换货", "THH0001");//当前已经执行了促销活动，按【F10】结束后才能启用退货状态切换。
                    return;
                }
            }
            //CheckStateChange();
            CheckStateChange891();
        }

        //private int DeleteExistReferData()
        //{
        //    bool isExistReferData = false;
        //    foreach (DataRow dr in objFormRetail.ItemData.Rows)
        //    {
        //        if (Tools.GetDblColumnValue(dr["flotQuantity"]) < 0)
        //        {
        //            if (dr["fchrCoRetailDetailID"] != System.DBNull.Value &&
        //                dr["fchrCoRetailDetailID"].ToString().Length > 0)
        //            {
        //                isExistReferData = true; //已经存在原单退货数据
        //                break;
        //            }
        //        }
        //    }

        //    if (isExistReferData)
        //    {
        //        DialogResult result = MessageBox.Show(null, "是否清除已录入的原单退货商品行？", "用友连锁零售管理系统", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        //        if (result == DialogResult.No)
        //            return 1;
        //        else if (result == DialogResult.Cancel)
        //            return 0;
        //        //if (DialogResult.Yes != ItemData.MessageBox("退换货", "THH0013"))//是否删除已录入的原单数据
        //        //{
        //        //    return true;
        //        //}
        //        //删除
        //        for (int i = 0; i < objFormRetail.ItemData.Rows.Count; i++)
        //        {
        //            if (Tools.GetDblColumnValue(objFormRetail.ItemData.Rows[i]["flotQuantity"]) < 0)
        //            {
        //                if (objFormRetail.ItemData.Rows[i]["fchrCoRetailDetailID"] != System.DBNull.Value &&
        //                    objFormRetail.ItemData.Rows[i]["fchrCoRetailDetailID"].ToString().Length > 0)
        //                {
        //                    if (objFormRetail.ItemData.Rows[i].RowState == DataRowState.Added)
        //                        objFormRetail.ItemData.Rows[i].AcceptChanges();
        //                    objFormRetail.ItemData.Rows[i].Delete();
        //                }
        //            }
        //        }
        //        objFormRetail.ItemData.AcceptChanges();
        //        isExistReferData = false;
        //    }
        //    return 2;
        //}

        private bool ExistNormalData()
        {
            bool isExistNormalData = false;

            for (int i = 0; i < objFormRetail.ItemData.Rows.Count; i++)
            {
                DataRow dr = objFormRetail.ItemData.Rows[i];
                if ((dr["fchrCoRetailDetailID"] == System.DBNull.Value || dr["fchrCoRetailDetailID"].ToString().Length == 0) &&
                     Tools.GetStringColumnValue(dr["fchrItemID"]).Length > 0 && Tools.GetDblColumnValue(dr["flotQuantity"]) < 0)
                {
                    isExistNormalData = true;
                    break;
                }
            }
            return isExistNormalData;
        }

        private void CheckStateChange891()
        {
            int iReturn = DeleteExistReferData();
            if (iReturn == 0)//取消
                return;
            else if (iReturn == 1)//不删除，切换状态后退出
            {
                ItemData.IsSaleState = !(ItemData.IsSaleState);
                objFormRetail.SetState();
                return;
            }
            //if (!DeleteExistReferData())//由销售切换为退货前，存在的原单数据需要删除。这是根据原单和非原单的互斥原则
            //    return;
            if (!ExistNormalData())
            {
                if (!SelectReturnType())
                    return;
            }

            if (ItemData.IsSaleState) //当前状态为销售
            {
                bool allowReturn = Tools.GetBoolSysPara("fbitAllowReturn");//零售开单时允许退货
                bool mustRefer = Tools.GetBoolSysPara("fbitReturnMustRefer");//是否必须参照原单退货

                if (ItemData.Sl_ZT_ZTSaleVouchFlag == "冲单")//原单权限控制
                {
                    if (!allowReturn && !ItemData.IsSetAllowReturn)
                    {
                        if (DialogResult.Yes != ItemData.MessageBox("退换货", "THH0012"))//当前操作员没有退货权限，是否使用其他操作员进行退货？
                        {
                            return;
                        }
                        frmInputOperator dlg = new frmInputOperator(UsingType.ForReturnMustRefer);
                        if (DialogResult.OK != dlg.ShowDialog())
                        {
                            return;
                        }
                        ItemData.IsSetAllowReturn = true;
                        SysPara.SetSysPara("fbitAllowReturn", (dlg.AllowReturn == true ? 1 : 0).ToString());

                        //用frmInputOperator取得的数据设置参数“退货时必须参照原单”,
                        SysPara.SetSysPara("fbitReturnMustRefer", (dlg.MustRefer == true ? 1 : 0).ToString());
                        //用frmInputOperator取得的数据设置参数“退货金额小于0”,
                        if (!Tools.GetBoolSysPara("fbitAllowNegative")) //控制“退货金额小于0”的权限为两者最大
                            SysPara.SetSysPara("fbitAllowNegative", (dlg.AllowNegative == true ? 1 : 0).ToString());
                    }
                }
                else//非原单权限控制
                {
                    if (!allowReturn || mustRefer)
                    {
                        if (!ItemData.IsSetAllowReturn)
                        {
                            if (DialogResult.Yes != ItemData.MessageBox("退换货", "THH0012"))//当前操作员没有退货权限，是否使用其他操作员进行退货？
                            {
                                return;
                            }
                            frmInputOperator dlg = new frmInputOperator(UsingType.ForReturnNormal);
                            if (DialogResult.OK != dlg.ShowDialog())
                            {
                                return;
                            }
                            ItemData.IsSetAllowReturn = true;
                            SysPara.SetSysPara("fbitAllowReturn", (dlg.AllowReturn == true ? 1 : 0).ToString());
                            SysPara.SetSysPara("fbitReturnMustRefer", (dlg.MustRefer == true ? 1 : 0).ToString());
                            //用frmInputOperator取得的数据设置参数“退货金额小于0”,
                            if (!Tools.GetBoolSysPara("fbitAllowNegative")) //控制“退货金额小于0”的权限为两者最大
                                SysPara.SetSysPara("fbitAllowNegative", (dlg.AllowNegative == true ? 1 : 0).ToString());
                        }
                    }
                }
            }

            if (ItemData.Sl_ZT_ZTSaleVouchFlag == "冲单")//如果为退货状态且必须原单为真，则弹出原单退货窗体。
            {
                ItemData.IsSaleState = !(ItemData.IsSaleState);
                objFormRetail.SetState();
                FillItems("展厅冲单");
            }
            else if (ItemData.Sl_ZT_ZTSaleVouchFlag == "补单")
            {
                ItemData.IsSaleState = true;
                objFormRetail.SetState();
                FillItems("展厅补单");
            }
        }

        /// <summary>
        /// 胜龙二次开发-展厅业务-待收冲单/补单处理
        /// </summary>
        private void FillItems(string FormName)
        {
            string sql = string.Empty;
            string path = string.Format(@"{0}\xml\Receipt\{1}.xml", Tools.GetStringSysPara("DataPath"), "单据_零售单模板");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNode xmlStructNode = xmlDoc.SelectSingleNode(@"Root/录入区/商品填充事件");

            //FormRetail formRetail = objForm.SourceForm as FormRetail;

            frmZTReturnForm ReturnForm = new frmZTReturnForm(FormName);
            if (ReturnForm.ShowDialog() == DialogResult.OK)
            {

                SqlParameter[] param = { 
                                      new SqlParameter("@FilterString",ReturnForm.SelDetailRel),
                                      new SqlParameter("@DisplayFileds",""),
                                      new SqlParameter("@fchrZTSaleVouchFlag",ItemData.Sl_ZT_ZTSaleVouchFlag)
                                   };
                DataTable objTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, "sl_ZT_proc_GetValidReturnDetailList", param).Tables[0];


                if (null == objTable || objTable.Rows.Count <= 0)
                {
                    RetailMessageBox.ShowWarning("没有可导入的数据。");
                    return;
                }

                //if (!ValidateRetailForPromotion(objTable))
                //{
                //    RetailMessageBox.ShowWarning("促销商品导入不完整，请保证选定相同促销的全部商品行。");
                //    return;
                //}

                if (objTable != null)
                {
                    for (int i = 0; i < objTable.Rows.Count; i++)
                    {
                        objFormRetail.myGridView.SelectLastRow();
                        bool returnValue = true;
                        if (returnValue)
                        {
                            int rowIndex = objFormRetail.myGridView.CurrentRow.Index;
                            objTable.Rows[i]["fchrCoRetailDetailID"] = objTable.Rows[i]["id"]; //设置原单退货参照的零售明细单的ID,因为需要写零售明细单的退货数量字段
                            objFormRetail.ItemData.InsertByRowRefer(rowIndex, objTable.Rows[i], xmlStructNode);
                            objFormRetail.myGridView.SelectLastRow();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 选择退货类型-展厅业务(冲单/补单) add by pj 20140225
        /// </summary>
        /// <returns></returns>
        public bool SelectReturnType()
        {
            //弹出原单，非原单选择界面
            frmZTSaleControlForm dlg = new frmZTSaleControlForm();
            if (DialogResult.Cancel == dlg.ShowDialog())
            {
                return false;
            }
            //CurSelType = dlg.returnType;
            ItemData.Sl_ZT_ZTSaleVouchFlag = dlg.returnType;
            return true;
        }

        /// <summary>
        /// 胜龙展厅业务-冲单/补单处理
        /// </summary>
        public void ZT_RepairBill()
        {
            ModelDiscountInfo objMdlDisInfo = objFormRetail.ModelDisInfo;
            this.objModelItem.modelRetailVouch = objFormRetail.ModelRetailVouch;
            ChangeStatus();
        }

        /// <summary>
        /// 展厅客户参照选择窗口
        /// </summary>
        public void CustomerRefForm()
        {
            ModelDiscountInfo objMdlDisInfo = objFormRetail.ModelDisInfo;
            this.objModelItem.modelRetailVouch = objFormRetail.ModelRetailVouch;
            DataTable myGridDataSource = new DataTable();
            if (ItemData.Sl_ZT_ZTSaleVouchFlag == "冲单" || ItemData.Sl_ZT_ZTSaleVouchFlag == "补单")
            {
                if ((objFormRetail.myGridView.DataSource as DataTable).Rows.Count > 1)
                {
                    myGridDataSource = (objFormRetail.myGridView.DataSource as DataTable).Copy();
                    myGridDataSource.Rows.RemoveAt(myGridDataSource.Rows.Count - 1);
                    myGridDataSource.AcceptChanges();
                    if (!sl_RetailCommom.CheckRetailVouchDetailIsExistsDiffCustomer(myGridDataSource))
                    {
                        RetailMessageBox.ShowInformation("冲单或补单状态下不允许修改展厅客户！");
                        return;
                    }
                }
            }

            string sql = string.Empty;
            string sqlTlbName = string.Empty;
//            sql = string.Format(@"select 0 as sel,fchrCusCode as '客户编码',fchrCusName as '客户名称',fchrMobileNum as '手机号码',fchrPhoneNum as '固定电话',fchrFax as '传真',fchrWorkPlace as '工作单位',ROW_NUMBER() over(order by fchrCusCode) as ID
//                                  from sl_ZT_Customer where 1=1");
//            sql = string.Format(@"SELECT 0 as sel,fchrCusCode as '客户编码',fchrCusName as '客户名称',fchrMobileNum as '手机号码',fchrPhoneNum as '固定电话',fchrFax as '传真',fchrWorkPlace as '工作单位',(select count(1) from sl_ZT_Customer where fdtmAddTime <= t.fdtmAddTime) AS ID FROM  
//                                  sl_ZT_Customer t where 1=1 ");

            sqlTlbName = string.Format(@"SELECT 0 as sel,fchrCusCode as '客户编码',fchrCusName as '客户名称',fchrMobileNum as '手机号码',fchrPhoneNum as '固定电话',fchrFax as '传真',fchrWorkPlace as '工作单位'
                                              FROM sl_ZT_Customer where 1=1");

            sql = string.Format(@"SELECT Count(1) FROM sl_ZT_Customer where 1=1");

            //if (!string.IsNullOrEmpty(TxtValue)) sql += string.Format(@" and fchrCusCode like '{0}' or fchrCusName like '%{0}%'", TxtValue);
            frmRefForm Ref = new frmRefForm("展厅客户", "展厅客户", sql, "fchrCusCode,fchrCusName,fchrMobileNum,fchrPhoneNum,fchrFax,fchrWorkPlace", sqlTlbName, "客户编码");
            if (Ref.ShowDialog() == DialogResult.OK)
            {
                //先删除整个展厅客户节点部分
                sl_RetailCommom.DeleteSection("ZTCustomer", @".\SL_ZT_RefInfo.ini");
                //写入展厅客户节点部分键值
                sl_RetailCommom.WritePrivateProfileString("ZTCustomer", "ZTCustomerText", Ref.CRefTxt, @".\SL_ZT_RefInfo.ini");
                sl_RetailCommom.WritePrivateProfileString("ZTCustomer", "ZTCustomerValue", Ref.CRefValue, @".\SL_ZT_RefInfo.ini");
            }
        }

        /// <summary>
        /// 胜龙展厅业务-删除已参照的冲单或补单商品行 add by pj 20140301
        /// </summary>
        /// <returns></returns>
        private int DeleteExistReferData()
        {
            bool isExistReferData = false;
            string Msg = string.Empty;
            foreach (DataRow dr in objFormRetail.ItemData.Rows)
            {
                //if (ItemData.Sl_ZT_ZTSaleVouchFlag == "冲单")
                //{
                //    if (dr["fchrCoRetailDetailID"] != System.DBNull.Value &&
                //        dr["fchrCoRetailDetailID"].ToString().Length > 0)
                //    {
                //        isExistReferData = true; //已经存在原单退货数据
                //        break;
                //    }
                //}
                //else if (ItemData.Sl_ZT_ZTSaleVouchFlag == "补单")
                //{
                    if (dr["fchrZTOrigVouchDetailId"] != System.DBNull.Value &&
                         dr["fchrZTOrigVouchDetailId"].ToString().Length > 0)
                    {
                        isExistReferData = true; //已经存在原单退货数据
                        break;
                    }
                //}
            }

            //如果存在则弹出提示窗口
            if (isExistReferData)
            {
                DialogResult result = MessageBox.Show(null, string.Format(@"是否清除已录入的【展厅{0}】商品行？",ItemData.Sl_ZT_ZTSaleVouchFlag), "用友连锁零售管理系统", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.No)
                    return 1;
                else if (result == DialogResult.Cancel)
                    return 0;
                //if (DialogResult.Yes != ItemData.MessageBox("退换货", "THH0013"))//是否删除已录入的原单数据
                //{
                //    return true;
                //}
                //删除
                for (int i = 0; i < objFormRetail.ItemData.Rows.Count; i++)
                {
                    //if (Tools.GetDblColumnValue(objFormRetail.ItemData.Rows[i]["flotQuantity"]) < 0)
                    //{
                    //    if (objFormRetail.ItemData.Rows[i]["fchrCoRetailDetailID"] != System.DBNull.Value &&
                    //        objFormRetail.ItemData.Rows[i]["fchrCoRetailDetailID"].ToString().Length > 0)
                    //    {
                            if (objFormRetail.ItemData.Rows[i].RowState == DataRowState.Added)
                                objFormRetail.ItemData.Rows[i].AcceptChanges();
                            objFormRetail.ItemData.Rows[i].Delete();
                    //    }
                    //}
                }
                objFormRetail.ItemData.AcceptChanges();
                //为ItemData.DataTable新增一行空行 add by pj 20140301
                if (objFormRetail.ItemData.Rows.Count == 0)
                {
                    objFormRetail.ItemData.Rows.Add(objFormRetail.ItemData.NewRow());
                    objFormRetail.ItemData.AcceptChanges();
                }
                isExistReferData = false;
            }

            return 2;
        }

        #region IDiscount 成员
        public bool CancelDiscount(ref ItemData objItemData, ref ModelDiscountInfo objModelDiscountInfo)
        {
            return true;
        }

        public bool CancelDiscount(ref ModelItem objModelItem, ref ModelDiscountInfo objModelDiscountInfo)
        {
            return true;
        }
        #endregion
    }
}
