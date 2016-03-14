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

        public VIPDiscount()
        {
        }

        public void VIPCardClick()
        {
            clearBtnClick();
            objFormRetail.btUpdate1.Click += new EventHandler(btUpdate_Click);
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
            //三、进行VIP计算

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
        private bool GetVIPDiscountParameter(ref ModelDiscountInfo objMdlDisInfo, ref ModelItem objModelItem)
        {
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
            ArrayList objVIPList = new ArrayList();
            objVIPList.Add(strVipCardCode);
            objVIPList.Add(objModelItem.ItemData.RepairBillDate.ToString());
            objForm.Tag = objVIPList;
            //SWC 开单界面VIP窗体确定之后的效率问题，窗体frmVipCardCode中的strVipConsumerID的值不延续到此，此处只延续strVipCardCode的值，strVipCardCode的查询按理不会有查询效率的问题。
            //延续strVipConsumerID的话需要修改一些数据接口以延续其值。且在窗体再次打开时要传递进去。
            objForm.ShowDialog();
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
                objMdlDisInfo.SetDisNodeAttributeValue("VIP折扣", "折扣等级", xmlNode.Attributes["VipDiscountLevelID"].Value);
                strVipCardCode = xmlNode.Attributes["VipCardCode"].Value;
                InitVipInfo(strVipCardCode);
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
                ItemData.MessageBox("VIP折扣", "VIP0001");
                return false;
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
                ItemData.MessageBox("VIP折扣", "VIP0004");
                return false;
            }

            return true;
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
