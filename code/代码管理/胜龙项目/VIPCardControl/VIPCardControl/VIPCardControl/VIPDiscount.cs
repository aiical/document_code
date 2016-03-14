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
    /// VIPDiscount ��ժҪ˵����
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
        /// VIP��Ʒ����
        /// </summary>
        /// <param name="objModelItem"></param>
        /// <param name="MdlDisInfo"></param>
        /// <returns></returns>
        public bool ItemDiscount(ref ModelItem objModelItem, ref ModelDiscountInfo objMdlDisInfo)
        {
            //���޸�ԭ���˻��е�VIP��Ϣ
            if (objModelItem.IsReferData)
                return true;
            string strVipCode = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "VIP����"));
            bool IsNewItem = Tools.GetBoolColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "������Ʒ"));

            //VIP�ۿ��жϴ���
            if (!ExecuteDistinguish(ref objModelItem, ref objMdlDisInfo))
            {
                return false;
            }
            if (strVipCode.Trim().Equals("") || (!IsNewItem))
            {
                //��ʾVIP������Դ�Ƿ����
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
                //VIP��������
                ItemData objItemData = objModelItem.ItemData;
                return ItemDiscount(ref  objItemData, ref objMdlDisInfo);
            }
            //VIP�ۿ��㷨
            return ItemVIPDiscount(ref objModelItem, ref objMdlDisInfo);
        }

        /// <summary>
        /// VIP��������
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
                //���޸�ԭ���˻��е�VIP��Ϣ
                if (objModelItem.IsReferData)
                    continue;
                //VIP�ۿ��㷨
                ItemVIPDiscount(ref objModelItem, ref objMdlDisInfo);
            }
            return true;
        }
        /// <summary>
        /// VIP�ۿ��㷨
        /// </summary>
        /// <param name="objModelItem">��Ʒ��Ϣ</param>
        /// <param name="objMdlDisInfo">�ۿ���Ϣ</param>
        /// <returns>�����ۿ��Ƿ���ȷ</returns>
        private bool ItemVIPDiscount(ref ModelItem objModelItem, ref ModelDiscountInfo objMdlDisInfo)
        {
            //����ȡVIP����
            string VipDiscountLevelID = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "�ۿ۵ȼ�"));
            string strVipCode = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "VIP����"));
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
            //һ����Ʒ�Ƿ���ʹ��VIP��
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
            objModelItem.AccountReceivable = objModelItem.Quantity * objModelItem.QuotePrice;     //Ӧ����
            //��������VIP����

            objModelItem.DisUnitPrice = objModelItem.ModelVIP.VIPUnitPrice;
            objModelItem.FactSellMoney = objModelItem.Quantity * objModelItem.DisUnitPrice;       //ʵ����
            objModelItem.DiscountRate = ItemData.Mod(objModelItem.FactSellMoney, objModelItem.AccountReceivable) * 100;

            objModelItem.ModelVIP.VipDiscountMoney = objModelItem.AccountReceivable - objModelItem.FactSellMoney;//VIP�ۿ۶�
            objModelItem.ModelVIP.VipDiscountRate = ItemData.Mod((objModelItem.AccountReceivable - objModelItem.ModelVIP.VipDiscountMoney), objModelItem.AccountReceivable) * 100;
            objModelItem.ModelVIP.IsVIP = true;
            //�塢���㿨���ۿ۴���
            objModelItem.CardTypeDisMoney = objModelItem.ModelVIP.VipDiscountMoney;
            objModelItem.CardTypeDisRate = ItemData.Mod((objModelItem.AccountReceivable - objModelItem.CardTypeDisMoney), objModelItem.AccountReceivable) * 100;
            objModelItem.DiscountMoney = objModelItem.AccountReceivable - objModelItem.FactSellMoney;
            objModelItem.SalesPromotionPrice = objModelItem.DisUnitPrice;
            objModelItem.ItemData.Update(objModelItem, objModelItem.RowIndex);
            return true;
        }
        /// <summary>
        /// ��ȡVIP�ۿ۲�������
        /// </summary>
        /// <returns>���ز�����Ϣ</returns>
        private bool GetVIPDiscountParameter(ref ModelDiscountInfo objMdlDisInfo, ref ModelItem objModelItem)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode xmlNode;
            System.Reflection.Assembly objAss;
            object obj;
            string OutXML = "";

            //���ò���
            string dir = Application.StartupPath;
            string strComName = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "�������"));
            string strClassName = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "������"));
            dir += "\\" + strComName;
            objAss = System.Reflection.Assembly.LoadFile(dir);
            obj = objAss.CreateInstance(strClassName);
            string strVipCardCode = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "VIP����"));
            string VipDiscountType = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "�ۿ۵ȼ�"));

            System.Text.StringBuilder objXML = new System.Text.StringBuilder();
            //--------------------------------
            //��ȯ����ʱ����VIP�ۿ۵�����ж�
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
            //SWC ��������VIP����ȷ��֮���Ч�����⣬����frmVipCardCode�е�strVipConsumerID��ֵ���������ˣ��˴�ֻ����strVipCardCode��ֵ��strVipCardCode�Ĳ�ѯ�������в�ѯЧ�ʵ����⡣
            //����strVipConsumerID�Ļ���Ҫ�޸�һЩ���ݽӿ���������ֵ�����ڴ����ٴδ�ʱҪ���ݽ�ȥ��
            objForm.ShowDialog();
            OutXML = (string)objForm.Tag;
            if (OutXML.Equals(""))//VIP�����ȡ���󣬻�ԭ��ȯ����ʹ�ֵ�������VIP�ۿ۵Ŀ��ơ�
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
                objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "�ۿ�״̬", "True");
                objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "VIP����", xmlNode.Attributes["VipCardCode"].Value);
                objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "�ۿ۵ȼ�", xmlNode.Attributes["VipDiscountLevelID"].Value);
                strVipCardCode = xmlNode.Attributes["VipCardCode"].Value;
                InitVipInfo(strVipCardCode);
            }
            objAss = null;
            obj = null;
            bool isDisplayList = Tools.GetBoolColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "�Ƿ���ʾ��ϸ"));
            if (!isDisplayList) return true;
            dir = Application.StartupPath;
            strComName = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "��ʾ�����"));
            strClassName = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "��ʾ����"));
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
        /// ��ȯ�����ۿ۴���
        /// </summary>
        private void GiftTokenSetVIPDiscount(ref ModelItem objModelItem)
        {
            bool IsGiftToken = SysPara.GetBoolean("IsGiftToken");//�Ƿ�������ȯ
            bool SettleByVIP = SysPara.GetBoolean("SettleByVIP");//��ȯ����ʱ����VIP�ۿ�
            bool IsExistSettleStyleByGiftToken = DiscountData.IsExistSettleStyleByGiftToken();//�Ƿ����ȯ�Ľ��㷽ʽ
            if (IsGiftToken && !SettleByVIP && IsExistSettleStyleByGiftToken)
            {
                if (ItemData.MessageBox("VIP�ۿ�", "VIP0025") == DialogResult.Yes)
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
        /// ��ֵ�������ۿ۴���
        /// </summary>
        private void CardSetVIPDiscount(ref ModelItem objModelItem)
        {
            bool IsGiftToken = SysPara.GetBoolean("IsStoredCard");//�Ƿ����ô�ֵ��
            bool SettleByVIP = SysPara.GetBoolean("StoredCardAllowVIPDiscount");//��ֵ������ʱ����VIP�ۿ�
            bool IsExistSettleStyleByGiftToken = DiscountData.IsExistSettleStyleByCard();//�Ƿ���ڴ�ֵ���Ľ��㷽ʽ
            if (IsGiftToken && !SettleByVIP && IsExistSettleStyleByGiftToken)
            {
                if (ItemData.MessageBox("VIP�ۿ�", "VIP0026") == DialogResult.Yes)
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
        /// VIP�ۿ��жϴ���
        /// </summary>
        /// <param name="objModelItem">��Ʒ��Ϣ</param>
        /// <param name="objMdlDisInfo">�ۿ���Ϣ</param>
        /// <returns>�����жϴ�����</returns>
        public bool ExecuteDistinguish(ref ModelItem objModelItem, ref ModelDiscountInfo objMdlDisInfo)
        {
            bool IsNewItem = Tools.GetBoolColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "������Ʒ"));
            objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "������Ʒ", "False"); //����Ϊ������Ʒ
            ItemData objItemData = objModelItem.ItemData;
            string strVipCode = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "VIP����"));

            if (objItemData.PresellState == 4 || objItemData.PresellState == 3)
            {
                if (strVipCode.Equals(""))
                {
                    ItemData.MessageBox("Ԥ��", "YD0023");
                }
                else
                {
                    ItemData.MessageBox("Ԥ��", "YD0041");
                }
                return false;
            }
            if (objItemData.PresellState == 5 || objItemData.PresellState == 6)
            {
                if (strVipCode.Equals(""))
                {
                    ItemData.MessageBox("Ԥ��", "YD0024");
                }
                else
                {
                    ItemData.MessageBox("Ԥ��", "YD0042");
                }
                return false;
            }
            //�ġ��˻�״̬
            //if (!ItemData.IsSaleState)
            //{
            //    ItemData.MessageBox("VIP�ۿ�", "VIP0005");
            //    return false;
            //}
            //һ�������
            bool IsSalesPromotionExecuteState = Tools.GetBoolColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("�����", "�ۿ�״̬"));
            if (IsSalesPromotionExecuteState && (!IsNewItem))
            {
                ItemData.MessageBox("VIP�ۿ�", "VIP0001");
                return false;
            }
            //�����������
            bool IsSalesPromotionGroupExecuteState = Tools.GetBoolColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("�������", "�ۿ�״̬"));
            if (IsSalesPromotionGroupExecuteState && (!IsNewItem))
            {
                string salesPromotionGroupID = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("�������", "�������ID"));
                if ((!objModelItem.ItemData.IsEndPromotionGroup(objModelItem.ItemData.Count - 1) && objModelItem.ItemData[objModelItem.ItemData.Count - 1].IsPromotionGroup) || !salesPromotionGroupID.Equals(""))
                {
                    ItemData.MessageBox("VIP�ۿ�", "VIP0006");
                    return false;
                }
                else
                {
                    if (!IsNewItem)
                    {
                        ItemData.MessageBox("VIP�ۿ�", "VIP0002");
                        return false;
                    }
                }
            }
            //�����ۿۿ�
            bool IsDiscountCardExecuteState = Tools.GetBoolColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("�ۿۿ�", "�ۿ�״̬"));
            if (IsDiscountCardExecuteState && (!IsNewItem))
            {
                ItemData.MessageBox("VIP�ۿ�", "VIP0003");
                return false;
            }
            //�ġ��ֳ��ۿ�
            bool IsSceneDiscountExecuteState = Tools.GetBoolColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("�ֳ��ۿ�", "�ۿ�״̬"));
            if (IsSceneDiscountExecuteState && (!IsNewItem))
            {
                ItemData.MessageBox("VIP�ۿ�", "VIP0004");
                return false;
            }

            return true;
        }
        #region IDiscount ��Ա
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
