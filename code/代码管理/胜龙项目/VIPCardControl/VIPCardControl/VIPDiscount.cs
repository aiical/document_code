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
        private bool GetVIPDiscountParameter(ref ModelDiscountInfo objMdlDisInfo, ref ModelItem objModelItem) {
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

            objForm.chIsZheKouKa.Checked = IsZheKouKa;
            ArrayList objVIPList = new ArrayList();
            objVIPList.Add(strVipCardCode);
            objVIPList.Add(objModelItem.ItemData.RepairBillDate.ToString());
            objForm.Tag = objVIPList;
            //SWC ��������VIP����ȷ��֮���Ч�����⣬����frmVipCardCode�е�strVipConsumerID��ֵ���������ˣ��˴�ֻ����strVipCardCode��ֵ��strVipCardCode�Ĳ�ѯ�������в�ѯЧ�ʵ����⡣
            //����strVipConsumerID�Ļ���Ҫ�޸�һЩ���ݽӿ���������ֵ�����ڴ����ٴδ�ʱҪ���ݽ�ȥ��
            objForm.ShowDialog();
            IsZheKouKa = objForm.chIsZheKouKa.Checked;    //�Ƿ�ʹ���ۿۿ�
            IsPointForSP = objForm.chbIsPointForSP.Checked;  //�Ƿ���������ֻ���ֲ����� 
            IsPointForSD = objForm.chbIsPointForSD.Checked;  //�Ƿ������ֳ��ۿ�ֻ���ֲ�����
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

                try
                {
                    //ʤ���������ı��ۿۻ����ۿ���
                    objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "VIP�ȼ�", "0");
                    String vIPCardCode = xmlNode.Attributes["VipCardCode"].Value;
                    StringBuilder objSQL2 = new StringBuilder();
                    objSQL2.AppendFormat("SELECT COUNT(*) as Num FROM dbo.RetailVouch rv WHERE rv.fchrvipconsumerid =(select v.fchrvipconsumerid from vipconsumer v LEFT JOIN VipCodeCollate vcc ON v.fchrvipconsumerid = vcc.fchrvipconsumerid where vcc.fchrVipCode = '{0}') and flotGatheringMoney <> 0;", vIPCardCode);  //�ж��Ƿ��״�����
                    objSQL2.Append("SELECT * FROM dbo.vipcardtype WHERE fnarcardtypename='����';");  //Ĭ��Ϊ����
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
                    objSQL2.AppendFormat("select * from VipCodeCollate vcc left join VIPCardClass vc on vc.fchrVIPCardClassId = vcc.S01_fchrVIPCardClassID where fchrVipCode = '{0}';", vIPCardCode);  //��ȡ��������Ϣ by pj 20120815
                    SqlParameter[] param = {
                                                 new SqlParameter("@fchrVipCardCode",vIPCardCode),
                                                 new SqlParameter("@fchrVIPCardClassName",SqlDbType.VarChar,30)
                                               };
                    param[1].Direction = ParameterDirection.Output;
                    bool IsBirthDayFlag = Convert.ToBoolean(SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.StoredProcedure, "sl_proc_CheckCusIsBirthDay", param));  //���ݹ����Ԥ�õ��������������ж��Ƿ��������������ۿ۵����� by pj
                    //����VIP�ͻ������ϵ������ۿ۱�־ add by pj 20140219
                    UpdateBirFlag(vIPCardCode);
                    string fchrCurrentCardClassName = param[1].Value.ToString();
                    DataSet objDes3 = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, objSQL2.ToString());
                    if (Convert.ToInt32(objDes3.Tables[0].Rows[0]["Num"].ToString()) == 0 && (Convert.ToInt32(objDes3.Tables[2].Rows[0]["flotPointBalance"]) == 0 && Convert.ToInt32(objDes3.Tables[2].Rows[0]["fintTotalPoints"]) == 0) && (objDes3.Tables[3].Rows[0]["fbitDisCountforFirstConsume"].ToString() == "False"))  //�״����Ѳ�����
                    {
                        if (objDes3.Tables[1].Rows.Count > 0)
                        {
                            objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "�ۿ۵ȼ�", objDes3.Tables[1].Rows[0]["fchrvipcardtypeid"].ToString());
                        }
                    }
                    else if (IsPointForSP)  //������Ƿ�ֻ���ֲ�����
                    {
                        if (objDes3.Tables[1].Rows.Count > 0)
                        {
                            objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "�ۿ۵ȼ�", objDes3.Tables[1].Rows[0]["fchrvipcardtypeid"].ToString());
                        }
                    }
                    else if (IsPointForSD)   //�ֳ��ۿ��Ƿ�ֻ���ֲ�����
                    {
                        if (objDes3.Tables[1].Rows.Count > 0)
                        {
                            objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "�ۿ۵ȼ�", objDes3.Tables[1].Rows[0]["fchrvipcardtypeid"].ToString());
                        }
                    }
                    //else if (Convert.ToInt32(objDes3.Tables[2].Rows[0]["Num"].ToString()) > 0 &&Convert.ToInt32(objDes3.Tables[0].Rows[0]["Num"].ToString()) > 0)
                    else if (IsBirthDayFlag && GetBirthDiscountCount(vIPCardCode))  //�ж��Ƿ����������ۿ� by pj 20120221 //�жϵ�ǰ����VIP�ͻ��Ƿ������������ۿ۴����Ƿ���ڵ���1 by pj 20131106
                    {
                        if (MessageBox.Show("�ÿͻ���������һ�������ۿۣ��Ƿ�ʹ�������ۿۣ�", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            StringBuilder objSQL = new StringBuilder();
                            objSQL.Append("SELECT top 1  fchrvipcardtypeid FROM dbo.vipcardtype WHERE ISNULL(fnarmemo, '') =");
                            if (fchrCurrentCardClassName.IndexOf("���") != -1 && Convert.ToInt32(objDes3.Tables[2].Rows[0]["fbitCheck"]) == 1)
                            {
                                objSQL.AppendFormat(" RIGHT('{0}',2)", fchrCurrentCardClassName);
                            }
                            else
                            {
                                objSQL.AppendFormat(" ISNULL(( SELECT  fnarcardtypename FROM dbo.vipcardtype t LEFT JOIN dbo.VIPCardClass c ON t.fchrvipcardtypeid = c.fchrVIPCardTypeid LEFT JOIN dbo.VipConsumer s ON c.fchrVIPCardClassID = s.fchrVIPCardClassID WHERE  s.fchrVipCards = '{0}'), '')", vIPCardCode);
                            }
                            string strCardTypeId = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, objSQL.ToString()).ToString();  //��ȡ�ۿ۵ȼ�ID
                            if (strCardTypeId != "")
                            {
                                if (objModelItem.IsSpecial)
                                {
                                    objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "�ۿ۵ȼ�", strCardTypeId.ToString());
                                    //�ؼ�Ϊ VIP�ȼ�Ϊһ��
                                    objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "VIP�ȼ�", "1");
                                }
                                else
                                {
                                    objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "�ۿ۵ȼ�", strCardTypeId.ToString());
                                }
                            }
                            StringBuilder sbInsertTmp = new StringBuilder();
                            //Modify by pj 20130121
                            CreateTmpTable(GetComputerInfo() + "_" + SysPara.GetSysPara("����Ա����").ToString() + "_Temp1");  //������ʱ��
                            sbInsertTmp.AppendFormat("insert into [{0}](fchrVipCardCode,fbitBirDiscMonth)", GetComputerInfo() + "_" + SysPara.GetSysPara("����Ա����").ToString() + "_Temp1".Replace("-", "_").Replace("-", "_"));
                            sbInsertTmp.AppendFormat(" values('{0}',1)", vIPCardCode);
                            SqlAccess.ExecuteNonQuery(SysPara.ConnectionString, CommandType.Text, sbInsertTmp.ToString(), null);  //�����ݲ��뵽��ʱ����
                        }
                        else
                        {
                            if (fchrCurrentCardClassName.IndexOf("���") != -1 && Convert.ToInt32(objDes3.Tables[2].Rows[0]["fbitCheck"]) == 1)
                            {
                                SBdiscount(objMdlDisInfo, objDes3);
                            }
                            else
                            {
                                objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "�ۿ۵ȼ�", xmlNode.Attributes["VipDiscountLevelID"].Value);
                            }
                        }
                    }
                    else if (objDes3.Tables[2].Rows[0]["fchrVIPCardClassName"].ToString().IndexOf("���") != -1 && !string.IsNullOrEmpty(Convert.ToString(objDes3.Tables[2].Rows[0]["fbitCheck"])))  //�ж��Ƿ�Ϊ��쿨
                    {
                        if (Convert.ToInt32(objDes3.Tables[2].Rows[0]["fbitCheck"]) == 1)
                            SBdiscount(objMdlDisInfo, objDes3);
                        else
                            objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "�ۿ۵ȼ�", xmlNode.Attributes["VipDiscountLevelID"].Value);
                    }
                    else
                    {
                        string S01_VipDiscountLevelID = string.Empty;
                        string S01_NewVipCardCode = string.Empty;
                        //�����ǰʹ�õĿ����Ǿɿ����Ų����½�����VIP�Ѿ����ͨ����ʹ���¿�������ۿ�
                        if (Convert.ToInt32(SqlAccess.ExecuteScalar(SysPara.ConnectionString,CommandType.Text,string.Format(@"select Count(1) from S01_VIPCardChangeRecord where S01_fchrOldCardCode = '{0}' and isnull(fbitVerify,0) = 1",vIPCardCode))) > 0)
                        {
                            S01_NewVipCardCode = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, string.Format(@"select top 1 S01_fchrNewCardCode from S01_VIPCardChangeRecord where S01_fchrOldCardCode = '{0}' and isnull(fbitVerify,0) = 1", vIPCardCode)).ToString();
                            S01_VipDiscountLevelID = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, string.Format(@"select fchrVIPCardTypeid from vipcardclass vcc
                                                                                                                                         left join vipcodecollate vc on vcc.fchrvipcardclassid = vc.S01_fchrvipcardclassid
                                                                                                                                         where fchrVipCode = '{0}'", S01_NewVipCardCode)).ToString();
                            if(!string.IsNullOrEmpty(S01_VipDiscountLevelID))
                                objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "�ۿ۵ȼ�", S01_VipDiscountLevelID);
                        }
                        else
                        {
                            objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "�ۿ۵ȼ�", xmlNode.Attributes["VipDiscountLevelID"].Value);
                        }
                    }

                    if (IsZheKouKa)  //�ж��Ƿ�ʹ���ۿۿ�
                    {
                        if (objDes3.Tables[1].Rows.Count > 0)
                        {
                            objMdlDisInfo.Isvipused = "false";
                            objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "�ۿ۵ȼ�", objDes3.Tables[1].Rows[0]["fchrvipcardtypeid"].ToString());
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
            bool isDisplayList = Tools.GetBoolColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "�Ƿ���ʾ��ϸ"));
            if (!isDisplayList) return true;
            dir = Application.StartupPath;
            strComName = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "��ʾ�����"));
            strClassName = Tools.GetStringColumnValue(objMdlDisInfo.GetDisNodeAttributeValue("VIP�ۿ�", "��ʾ����"));
            dir += "\\" + strComName;
            return true;
        }

        /// <summary>
        /// ����VIP�ͻ������ϵ������ۿ۱�־
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
        /// ��ȡ��ǰ����VIP�ͻ��ڵ������������ۿ۴������������Ѳ��������1 by pj 20131106
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
        /// ��쿨�����ͨ������������������ۿ� by pj
        /// </summary>
        /// <param name="objMdlDisInfo"></param>
        /// <param name="objDes3"></param>
        private void SBdiscount(ModelDiscountInfo objMdlDisInfo, DataSet objDes3) {
            StringBuilder sbDisType = new StringBuilder();
            sbDisType.AppendFormat(@"SELECT top 1 vct.fchrvipcardtypeid FROM dbo.vipcardtype vct
		                                   LEFT JOIN dbo.VIPCardTypeDetail vctd ON vct.fchrvipcardtypeid = vctd.fchrVIPCardTypeID
		                                   WHERE vct.fnarcardtypename = RIGHT('{0}',2)", objDes3.Tables[2].Rows[0]["fchrVIPCardClassName"].ToString());
            string fchrvipcardtypeid = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, sbDisType.ToString()).Rows[0][0].ToString();

            objMdlDisInfo.SetDisNodeAttributeValue("VIP�ۿ�", "�ۿ۵ȼ�", fchrvipcardtypeid);   //������쿨�������״̬���ܹ�����VIP�ۿ�
        }

        /// <summary>
        /// ��ȡ�������
        /// </summary>
        /// <param name="sValueType"></param>
        /// <returns></returns>
        private string GetComputerInfo() {
            string MachineName = string.Empty;
            MachineName = Environment.MachineName.Replace('-', '_');
            return MachineName;
        }

        /// <summary>
        /// ������ʱ�� by pj
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
                //�ſ�ѡ��ִ�д������������ʹ��VIP�������� by pj 20130709
                //ItemData.MessageBox("VIP�ۿ�", "VIP0001");
                //return false;
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
                //�ſ�ִ���ֳ��ۿۺ�������ʹ��VIP�������� by pj 20130709
                //ItemData.MessageBox("VIP�ۿ�", "VIP0004");
                //return false;
            }

            return true;
        }

        /// <summary>
        /// �˻���״̬ add by pj 20140225
        /// </summary>
        public void ChangeStatus()
        {
            if (objFormRetail.ItemData.PresellState == 4 || objFormRetail.ItemData.PresellState == 3)
            {
                ItemData.MessageBox("Ԥ��", "YD0031");
                return;
            }
            if (objFormRetail.ItemData.PresellState == 5 || objFormRetail.ItemData.PresellState == 6)
            {
                ItemData.MessageBox("Ԥ��", "YD0032");
                return;
            }
            if (objFormRetail.ItemData.PresellState == 1 || objFormRetail.ItemData.PresellState == 2)
            {
                ItemData.MessageBox("Ԥ��", "YD0038");
                return;
            }
            string SalesPromotionGroupID = objFormRetail.ModelDisInfo.GetDisNodeAttributeValue("�������", "�������ID").ToString();
            bool IsSalesPromotion = Tools.GetBoolColumnValue(objFormRetail.ModelDisInfo.GetDisNodeAttributeValue("�����", "�ۿ�״̬"));
            if (ItemData.IsSaleState)//�˻�
            {
                if (SalesPromotionGroupID != string.Empty)
                {
                    ItemData.MessageBox("�˻���", "THH0002");//��ǰ״̬Ϊ��������������F11����������������˻�״̬�л���
                    return;
                }
                if (IsSalesPromotion)
                {
                    ItemData.MessageBox("�˻���", "THH0001");//��ǰ�Ѿ�ִ���˴����������F10����������������˻�״̬�л���
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
        //                isExistReferData = true; //�Ѿ�����ԭ���˻�����
        //                break;
        //            }
        //        }
        //    }

        //    if (isExistReferData)
        //    {
        //        DialogResult result = MessageBox.Show(null, "�Ƿ������¼���ԭ���˻���Ʒ�У�", "�����������۹���ϵͳ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        //        if (result == DialogResult.No)
        //            return 1;
        //        else if (result == DialogResult.Cancel)
        //            return 0;
        //        //if (DialogResult.Yes != ItemData.MessageBox("�˻���", "THH0013"))//�Ƿ�ɾ����¼���ԭ������
        //        //{
        //        //    return true;
        //        //}
        //        //ɾ��
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
            if (iReturn == 0)//ȡ��
                return;
            else if (iReturn == 1)//��ɾ�����л�״̬���˳�
            {
                ItemData.IsSaleState = !(ItemData.IsSaleState);
                objFormRetail.SetState();
                return;
            }
            //if (!DeleteExistReferData())//�������л�Ϊ�˻�ǰ�����ڵ�ԭ��������Ҫɾ�������Ǹ���ԭ���ͷ�ԭ���Ļ���ԭ��
            //    return;
            if (!ExistNormalData())
            {
                if (!SelectReturnType())
                    return;
            }

            if (ItemData.IsSaleState) //��ǰ״̬Ϊ����
            {
                bool allowReturn = Tools.GetBoolSysPara("fbitAllowReturn");//���ۿ���ʱ�����˻�
                bool mustRefer = Tools.GetBoolSysPara("fbitReturnMustRefer");//�Ƿ�������ԭ���˻�

                if (ItemData.Sl_ZT_ZTSaleVouchFlag == "�嵥")//ԭ��Ȩ�޿���
                {
                    if (!allowReturn && !ItemData.IsSetAllowReturn)
                    {
                        if (DialogResult.Yes != ItemData.MessageBox("�˻���", "THH0012"))//��ǰ����Աû���˻�Ȩ�ޣ��Ƿ�ʹ����������Ա�����˻���
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

                        //��frmInputOperatorȡ�õ��������ò������˻�ʱ�������ԭ����,
                        SysPara.SetSysPara("fbitReturnMustRefer", (dlg.MustRefer == true ? 1 : 0).ToString());
                        //��frmInputOperatorȡ�õ��������ò������˻����С��0��,
                        if (!Tools.GetBoolSysPara("fbitAllowNegative")) //���ơ��˻����С��0����Ȩ��Ϊ�������
                            SysPara.SetSysPara("fbitAllowNegative", (dlg.AllowNegative == true ? 1 : 0).ToString());
                    }
                }
                else//��ԭ��Ȩ�޿���
                {
                    if (!allowReturn || mustRefer)
                    {
                        if (!ItemData.IsSetAllowReturn)
                        {
                            if (DialogResult.Yes != ItemData.MessageBox("�˻���", "THH0012"))//��ǰ����Աû���˻�Ȩ�ޣ��Ƿ�ʹ����������Ա�����˻���
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
                            //��frmInputOperatorȡ�õ��������ò������˻����С��0��,
                            if (!Tools.GetBoolSysPara("fbitAllowNegative")) //���ơ��˻����С��0����Ȩ��Ϊ�������
                                SysPara.SetSysPara("fbitAllowNegative", (dlg.AllowNegative == true ? 1 : 0).ToString());
                        }
                    }
                }
            }

            if (ItemData.Sl_ZT_ZTSaleVouchFlag == "�嵥")//���Ϊ�˻�״̬�ұ���ԭ��Ϊ�棬�򵯳�ԭ���˻����塣
            {
                ItemData.IsSaleState = !(ItemData.IsSaleState);
                objFormRetail.SetState();
                FillItems("չ���嵥");
            }
            else if (ItemData.Sl_ZT_ZTSaleVouchFlag == "����")
            {
                ItemData.IsSaleState = true;
                objFormRetail.SetState();
                FillItems("չ������");
            }
        }

        /// <summary>
        /// ʤ�����ο���-չ��ҵ��-���ճ嵥/��������
        /// </summary>
        private void FillItems(string FormName)
        {
            string sql = string.Empty;
            string path = string.Format(@"{0}\xml\Receipt\{1}.xml", Tools.GetStringSysPara("DataPath"), "����_���۵�ģ��");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNode xmlStructNode = xmlDoc.SelectSingleNode(@"Root/¼����/��Ʒ����¼�");

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
                    RetailMessageBox.ShowWarning("û�пɵ�������ݡ�");
                    return;
                }

                //if (!ValidateRetailForPromotion(objTable))
                //{
                //    RetailMessageBox.ShowWarning("������Ʒ���벻�������뱣֤ѡ����ͬ������ȫ����Ʒ�С�");
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
                            objTable.Rows[i]["fchrCoRetailDetailID"] = objTable.Rows[i]["id"]; //����ԭ���˻����յ�������ϸ����ID,��Ϊ��Ҫд������ϸ�����˻������ֶ�
                            objFormRetail.ItemData.InsertByRowRefer(rowIndex, objTable.Rows[i], xmlStructNode);
                            objFormRetail.myGridView.SelectLastRow();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ѡ���˻�����-չ��ҵ��(�嵥/����) add by pj 20140225
        /// </summary>
        /// <returns></returns>
        public bool SelectReturnType()
        {
            //����ԭ������ԭ��ѡ�����
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
        /// ʤ��չ��ҵ��-�嵥/��������
        /// </summary>
        public void ZT_RepairBill()
        {
            ModelDiscountInfo objMdlDisInfo = objFormRetail.ModelDisInfo;
            this.objModelItem.modelRetailVouch = objFormRetail.ModelRetailVouch;
            ChangeStatus();
        }

        /// <summary>
        /// չ���ͻ�����ѡ�񴰿�
        /// </summary>
        public void CustomerRefForm()
        {
            ModelDiscountInfo objMdlDisInfo = objFormRetail.ModelDisInfo;
            this.objModelItem.modelRetailVouch = objFormRetail.ModelRetailVouch;
            DataTable myGridDataSource = new DataTable();
            if (ItemData.Sl_ZT_ZTSaleVouchFlag == "�嵥" || ItemData.Sl_ZT_ZTSaleVouchFlag == "����")
            {
                if ((objFormRetail.myGridView.DataSource as DataTable).Rows.Count > 1)
                {
                    myGridDataSource = (objFormRetail.myGridView.DataSource as DataTable).Copy();
                    myGridDataSource.Rows.RemoveAt(myGridDataSource.Rows.Count - 1);
                    myGridDataSource.AcceptChanges();
                    if (!sl_RetailCommom.CheckRetailVouchDetailIsExistsDiffCustomer(myGridDataSource))
                    {
                        RetailMessageBox.ShowInformation("�嵥�򲹵�״̬�²������޸�չ���ͻ���");
                        return;
                    }
                }
            }

            string sql = string.Empty;
            string sqlTlbName = string.Empty;
//            sql = string.Format(@"select 0 as sel,fchrCusCode as '�ͻ�����',fchrCusName as '�ͻ�����',fchrMobileNum as '�ֻ�����',fchrPhoneNum as '�̶��绰',fchrFax as '����',fchrWorkPlace as '������λ',ROW_NUMBER() over(order by fchrCusCode) as ID
//                                  from sl_ZT_Customer where 1=1");
//            sql = string.Format(@"SELECT 0 as sel,fchrCusCode as '�ͻ�����',fchrCusName as '�ͻ�����',fchrMobileNum as '�ֻ�����',fchrPhoneNum as '�̶��绰',fchrFax as '����',fchrWorkPlace as '������λ',(select count(1) from sl_ZT_Customer where fdtmAddTime <= t.fdtmAddTime) AS ID FROM  
//                                  sl_ZT_Customer t where 1=1 ");

            sqlTlbName = string.Format(@"SELECT 0 as sel,fchrCusCode as '�ͻ�����',fchrCusName as '�ͻ�����',fchrMobileNum as '�ֻ�����',fchrPhoneNum as '�̶��绰',fchrFax as '����',fchrWorkPlace as '������λ'
                                              FROM sl_ZT_Customer where 1=1");

            sql = string.Format(@"SELECT Count(1) FROM sl_ZT_Customer where 1=1");

            //if (!string.IsNullOrEmpty(TxtValue)) sql += string.Format(@" and fchrCusCode like '{0}' or fchrCusName like '%{0}%'", TxtValue);
            frmRefForm Ref = new frmRefForm("չ���ͻ�", "չ���ͻ�", sql, "fchrCusCode,fchrCusName,fchrMobileNum,fchrPhoneNum,fchrFax,fchrWorkPlace", sqlTlbName, "�ͻ�����");
            if (Ref.ShowDialog() == DialogResult.OK)
            {
                //��ɾ������չ���ͻ��ڵ㲿��
                sl_RetailCommom.DeleteSection("ZTCustomer", @".\SL_ZT_RefInfo.ini");
                //д��չ���ͻ��ڵ㲿�ּ�ֵ
                sl_RetailCommom.WritePrivateProfileString("ZTCustomer", "ZTCustomerText", Ref.CRefTxt, @".\SL_ZT_RefInfo.ini");
                sl_RetailCommom.WritePrivateProfileString("ZTCustomer", "ZTCustomerValue", Ref.CRefValue, @".\SL_ZT_RefInfo.ini");
            }
        }

        /// <summary>
        /// ʤ��չ��ҵ��-ɾ���Ѳ��յĳ嵥�򲹵���Ʒ�� add by pj 20140301
        /// </summary>
        /// <returns></returns>
        private int DeleteExistReferData()
        {
            bool isExistReferData = false;
            string Msg = string.Empty;
            foreach (DataRow dr in objFormRetail.ItemData.Rows)
            {
                //if (ItemData.Sl_ZT_ZTSaleVouchFlag == "�嵥")
                //{
                //    if (dr["fchrCoRetailDetailID"] != System.DBNull.Value &&
                //        dr["fchrCoRetailDetailID"].ToString().Length > 0)
                //    {
                //        isExistReferData = true; //�Ѿ�����ԭ���˻�����
                //        break;
                //    }
                //}
                //else if (ItemData.Sl_ZT_ZTSaleVouchFlag == "����")
                //{
                    if (dr["fchrZTOrigVouchDetailId"] != System.DBNull.Value &&
                         dr["fchrZTOrigVouchDetailId"].ToString().Length > 0)
                    {
                        isExistReferData = true; //�Ѿ�����ԭ���˻�����
                        break;
                    }
                //}
            }

            //��������򵯳���ʾ����
            if (isExistReferData)
            {
                DialogResult result = MessageBox.Show(null, string.Format(@"�Ƿ������¼��ġ�չ��{0}����Ʒ�У�",ItemData.Sl_ZT_ZTSaleVouchFlag), "�����������۹���ϵͳ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.No)
                    return 1;
                else if (result == DialogResult.Cancel)
                    return 0;
                //if (DialogResult.Yes != ItemData.MessageBox("�˻���", "THH0013"))//�Ƿ�ɾ����¼���ԭ������
                //{
                //    return true;
                //}
                //ɾ��
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
                //ΪItemData.DataTable����һ�п��� add by pj 20140301
                if (objFormRetail.ItemData.Rows.Count == 0)
                {
                    objFormRetail.ItemData.Rows.Add(objFormRetail.ItemData.NewRow());
                    objFormRetail.ItemData.AcceptChanges();
                }
                isExistReferData = false;
            }

            return 2;
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
