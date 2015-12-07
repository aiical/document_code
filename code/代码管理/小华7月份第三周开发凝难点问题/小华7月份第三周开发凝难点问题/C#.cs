using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TE.ServerInterface;
using TE.BusinessEntity;
using System.Data;
using TF.Util;
using TF.Util.Services;

namespace TF.Order.OrderWeaveNew
{
    public class OAMapper : CommonMapper
    {


        //大红马
        public List<string> GetstrScanID(string strFlowCardCode, string strInputCode, float fOutQty, bool bIsModify, string strCustomerOrderCode, string strOutputDetailID)
        {
            List<string> ScanID = new List<string>();
            DataSet ds = new DataSet();
            ds = BL.GetDataSetBySQLCommand(string.Format(@"SELECT ProductionAreaXM.strStorehousePlace,ProductionAreaXM.strStoreShelf,ProductionArea.strFlowCardCode,dbo.ProductionArea.strInputBillCode,strScanID,ProductionAreaXM.fTotalPieceQty,ProductionAreaXM.bIsOutput,ProductionAreaXM.fWeight,strOutputDetailID
                                                                       FROM dbo.ProductionArea INNER JOIN dbo.ProductionAreaXM ON dbo.ProductionArea.strRecordID = dbo.ProductionAreaXM.strRecordID 
                                                                       WHERE ProductionArea.strFlowCardCode like '%{0}%' AND dbo.ProductionArea.strInputBillCode LIKE '%{1}%' and dbo.ProductionAreaXM.bIsOutput=0 ", strFlowCardCode, strInputCode));

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string[] str = strCustomerOrderCode.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (str.Length > 0)
                {
                    float fTotalQty = 0;
                    foreach (string c in str)
                    {

                        float fPieceQty = Convert.ToSingle(c);
                        foreach (DataRow r in ds.Tables[0].Rows)
                        {
                            if (ScanID.Contains(r[BEProductionAreaXM.strScanID_].ToString().Trim())) continue; //已经标记了的不能再标记，否则就会重复计数fTotalQty += Convert.ToSingle(c) Shi
                            float fTotalPieceQty = Convert.ToSingle(r[BEProductionAreaXM.fTotalPieceQty_]);
                            if (fTotalQty < fOutQty && fPieceQty == fTotalPieceQty)
                            {
                                fTotalQty += Convert.ToSingle(c);
                                r["bIsOutput"] = 1;
                                if (!ScanID.Contains(r[BEProductionAreaXM.strScanID_].ToString().Trim()))
                                {
                                    ScanID.Add(r[BEProductionAreaXM.strScanID_].ToString().Trim());
                                }
                                //break;
                            }

                        }
                        if (fTotalQty < fOutQty) continue;
                        if (fTotalQty == fOutQty)
                        {
                            return ScanID;


                        }
                    }
                    if (fTotalQty < fOutQty)
                    {
                        DataRow[] rx = null;
                        rx = ds.Tables[0].Select("  bIsOutput=0 ", "fTotalPieceQty");
                        if (rx.Length > 0)
                        {
                            foreach (DataRow r in rx)
                            {
                                if (!ScanID.Contains(r[BEProductionAreaXM.strScanID_].ToString().Trim()))
                                {
                                    float ss = Convert.ToSingle(r[BEProductionAreaXM.fTotalPieceQty_]);
                                    if (fTotalQty < fOutQty && (fTotalQty + Convert.ToSingle(r[BEProductionAreaXM.fTotalPieceQty_]) < fOutQty))//1 件不足时 SHI2012-7-18
                                    {
                                        fTotalQty += Convert.ToSingle(r[BEProductionAreaXM.fTotalPieceQty_]);
                                        r["bIsOutput"] = 1;
                                        ScanID.Add(r[BEProductionAreaXM.strScanID_].ToString().Trim());
                                        if (fTotalQty == fOutQty)
                                        {
                                            return ScanID;
                                        }
                                    }
                                    //这个IF有问题，如果余下的bIsOutput=0的条每条记录的粒数都小于要出库量时，系统不做为，这样就少标记了出库细码，Shi 2012-7-18
                                    else if (fTotalQty < fOutQty && (fTotalQty + Convert.ToSingle(r[BEProductionAreaXM.fTotalPieceQty_]) >= fOutQty))
                                    {
                                        float fDiffQty = fOutQty - fTotalQty;
                                        fTotalQty += fDiffQty;
                                        string strScanID = r[BEProductionAreaXM.strScanID_].ToString().Trim();
                                        if (!ScanID.Contains(r[BEProductionAreaXM.strScanID_].ToString().Trim()))
                                        {

                                            ScanID.Add(r[BEProductionAreaXM.strScanID_].ToString().Trim());
                                            if (Math.Round(fDiffQty, 0) > 0)
                                            {
                                                DataSet dsTmp = new DataSet();
                                                string strCondition = string.Format("strScanID ='" + strScanID.Trim() + "'");
                                                dsTmp = BL.GetProductionAreaXMAllByCondition(strCondition);
                                                if (dsTmp != null && dsTmp.Tables.Count > 0 && dsTmp.Tables[0].Rows.Count > 0)
                                                {
                                                    float fAddPieceQty = Convert.ToSingle(r[BEProductionAreaXM.fTotalPieceQty_]) - fDiffQty;
                                                    string strNewGruid = System.Guid.NewGuid().ToString(); ;
                                                    dsTmp.Tables[BEProductionAreaXM.BEName].Rows[0][BEProductionAreaXM.strScanID_] = strNewGruid;
                                                    dsTmp.Tables[BEProductionAreaXM.BEName].Rows[0][BEProductionAreaXM.strStorehousePlace_] = r[BEProductionAreaXM.strStorehousePlace_].ToString();
                                                    dsTmp.Tables[BEProductionAreaXM.BEName].Rows[0][BEProductionAreaXM.strStoreShelf_] = r[BEProductionAreaXM.strStoreShelf_].ToString();
                                                    dsTmp.Tables[BEProductionAreaXM.BEName].Rows[0][BEProductionAreaXM.bIsOutput_] = 0;
                                                    dsTmp.Tables[BEProductionAreaXM.BEName].Rows[0][BEProductionAreaXM.strDetailNote_] = strFlowCardCode + "卡号出库时补录一件" + fAddPieceQty.ToString() + "粒";
                                                    float fAddWeight = 0;
                                                    float fRate = (Convert.ToSingle(r[BEProductionAreaXM.fWeight_]) / Convert.ToSingle(r[BEProductionAreaXM.fTotalPieceQty_]));
                                                    fAddWeight = fRate * fAddPieceQty;
                                                    dsTmp.Tables[BEProductionAreaXM.BEName].Rows[0][BEProductionAreaXM.fWeight_] = fAddWeight;
                                                    dsTmp.Tables[BEProductionAreaXM.BEName].Rows[0][BEProductionAreaXM.fTotalPieceQty_] = Convert.ToSingle(r[BEProductionAreaXM.fTotalPieceQty_]) - fDiffQty;
                                                    dsTmp.Tables[BEProductionAreaXM.BEName].Rows[0][BEProductionAreaXM.strOutputDetailID_] = strOutputDetailID;//增加此行在删除时回收，shi2012-7-18
                                                    SaveProductionAreaXM(dsTmp);
                                                }
                                            }
                                        }
                                        if (fTotalQty == fOutQty)
                                        {
                                            return ScanID;
                                        }
                                    }

                                }
                            }
                        }

                    }
                }
            }
            return ScanID;
        }

        /*下订单时，如果色号没有单价，禁止开流程卡。
        1、同一张订单有几个色号，有单价的色号能开出流程卡，没有单价的色号禁止开流程卡。     
        2、客户报均价，开卡那里先搜索染整单价，如果没有，再搜索基础信息注册的单价标准，
         安装客户，布类来匹配是否有单价。
        3、订单色号处只输中文字，这写色号不限制。色号处输的色号后面跟着中文字，
         把中文字过滤掉再去搜索符合条件的数据。
         备注:
        4. 订单查询界面需要增加 单价审核/反审核功能. 拥有"特殊权限" 的用户, 
          可以使用该功能将 某个没有单价的色号标记为有单价, 即可以开运转卡.
        5. 若有 "特殊权限" 的用户进订单查询界面, 需将没有单价的色号的背景色用特殊颜色标记(没有权限的用户不做该处理). 
        6. 单价审核操作需要记录日志.
         */
        //先查找 染整单价里面的, 若有记录就当做1. 否则继续 找单价标准中的. 同样有记录即可
        internal bool UpdateBisPrice(string strOrderCode, string strCustomerName, string strFabricClass, string strColorNumber, string strOrderCNDetailID, out float fDyePrice, out bool bIsExistPrice)
        {
            float fPrice = 0;
            string strCNumber = strColorNumber;
            //4.色号分三种情况：a.英文字母加汉字，截取英文字母与数字部分作为搜索条件,b.全部是汉字，则单价标志设为1,c.全部是英文字母，则按英文字母作为搜索条件
            if (strColorNumber.ToString().Contains("-"))
                strCNumber = strColorNumber.ToString().Remove(strColorNumber.ToString().IndexOf('-'));
            if (strColorNumber.ToString().Contains("/"))
                strCNumber = strColorNumber.Remove(strColorNumber.IndexOf('/'));
            else
                strCNumber = strColorNumber;

            if (strCNumber.Contains("DS") && strCNumber.Length > 7)
            {
                strCNumber = strCNumber.Substring(0, 8);
            }
            bool bIsPrice = false;
            DataSet dsDyeCoordinateAvgPrice = new DataSet();
            string strDyeCondition = string.Empty;
            //根据鼎盛需求:色号有DS开头这些就要去取染整单价，或者查单价标准那里其他那些输的色号不是DS开头那些直接更新为1
            if (strCNumber.Contains("DS"))
            {
                if (strCNumber.Length > 7)
                {
                    strDyeCondition = string.Format(" DyeCoordinateAvgPriceDetail.strMultCustomers like '%{0}%'  and (DyeCoordinateAvgPriceDetail.strColorNumber like '{1}[A-Z]%' or DyeCoordinateAvgPriceDetail.strColorNumber like '%{1}%' ) "
                       , strCustomerName, strCNumber);
                    dsDyeCoordinateAvgPrice = BLWF.GetDataSetBySpName("GetDyeCoordinateAvgPriceAndDetailALLData", strDyeCondition);
                    if (dsDyeCoordinateAvgPrice != null && dsDyeCoordinateAvgPrice.Tables.Count > 0 && dsDyeCoordinateAvgPrice.Tables[0].Rows.Count > 0)
                    {
                        bIsPrice = true;
                        if (dsDyeCoordinateAvgPrice != null && dsDyeCoordinateAvgPrice.Tables.Count > 0 && dsDyeCoordinateAvgPrice.Tables[0].Rows.Count > 0 &&
                            dsDyeCoordinateAvgPrice.Tables[0].Rows[0]["fPrice"].ToString() != string.Empty)
                        {
                            fPrice = Convert.ToSingle(dsDyeCoordinateAvgPrice.Tables[0].Rows[0]["fPrice"]);

                        }

                    }
                    else
                    {
                        DataSet dsAdjustPriceStand = new DataSet();
                        string strAdjCondition = string.Format(" strCustomerName like '%{0}%'  and strFabricClass like '%{1}%' "
                            , strCustomerName, strFabricClass);
                        dsAdjustPriceStand = BLWF.GetDataSetBySpName("AdjustPriceStand_List", strAdjCondition);
                        if (dsAdjustPriceStand != null && dsAdjustPriceStand.Tables.Count > 0 && dsAdjustPriceStand.Tables[0].Rows.Count > 0)
                        {
                            if (dsAdjustPriceStand != null && dsAdjustPriceStand.Tables.Count > 0 && dsAdjustPriceStand.Tables[0].Rows.Count > 0 &&
                                dsAdjustPriceStand.Tables[0].Rows[0]["fPrice"].ToString() != string.Empty)
                            {
                                fPrice = Convert.ToSingle(dsAdjustPriceStand.Tables[0].Rows[0]["fPrice"]);

                            }
                            bIsPrice = true;
                        }

                    }
                }
                else
                {

                    bIsPrice = false;

                }
            }
            else //色号全部是汉字，则单价标志直接设为1,(在上面色号处理中已将色号全部是汉字的设为空了)
            {
                bIsPrice = true;
            }
            fDyePrice = fPrice;
            bIsExistPrice = bIsPrice;
            return BLWF.Update<BEOrderColorNumber>(string.Format("{0}='{1}' ", "bIsPrice", bIsPrice),
            string.Format("{0}='{1}'and {2}='{3}' ", BEOrderColorNumber.strOrderCode_, strOrderCode, BEOrderColorNumber.strOrderCNDetailID_, strOrderCNDetailID));
        }

        //用于输入色号时调用
        internal float GetfDyePrice(string strCustomerName, string strFabricClass, string strColorNumber)
        {
            float fPrice = 0;
            string strCNumber = strColorNumber;
            //4.色号分三种情况：a.英文字母加汉字，截取英文字母与数字部分作为搜索条件,b.全部是汉字，则单价标志设为1,c.全部是英文字母，则按英文字母作为搜索条件
            if (strColorNumber.ToString().Contains("-"))
                strCNumber = strColorNumber.ToString().Remove(strColorNumber.ToString().IndexOf('-'));
            if (strColorNumber.ToString().Contains("/"))
                strCNumber = strColorNumber.Remove(strColorNumber.IndexOf('/'));
            else
                strCNumber = strColorNumber;

            if (strCNumber.Contains("DS") && strCNumber.Length > 7)
            {
                strCNumber = strCNumber.Substring(0, 8);
            }
            DataSet dsDyeCoordinateAvgPrice = new DataSet();
            string strDyeCondition = string.Empty;
            //根据鼎盛需求:色号有DS开头这些就要去取染整单价，或者查单价标准那里其他那些输的色号不是DS开头那些直接更新为1
            if (strCNumber.Contains("DS"))
            {
                if (strCNumber.Length > 7)
                {
                    strDyeCondition = string.Format(" DyeCoordinateAvgPriceDetail.strMultCustomers like '%{0}%'  and (DyeCoordinateAvgPriceDetail.strColorNumber like '{1}[A-Z]%' or DyeCoordinateAvgPriceDetail.strColorNumber like '%{1}%' ) "
                       , strCustomerName, strCNumber);
                    dsDyeCoordinateAvgPrice = BLWF.GetDataSetBySpName("GetDyeCoordinateAvgPriceAndDetailALLData", strDyeCondition);
                    if (dsDyeCoordinateAvgPrice != null && dsDyeCoordinateAvgPrice.Tables.Count > 0 && dsDyeCoordinateAvgPrice.Tables[0].Rows.Count > 0)
                    {
                        if (dsDyeCoordinateAvgPrice.Tables[0].Rows[0]["fPrice"].ToString() != string.Empty)
                        {
                            fPrice = Convert.ToSingle(dsDyeCoordinateAvgPrice.Tables[0].Rows[0]["fPrice"]);

                        }
                    }
                    else
                    {
                        if (strFabricClass != string.Empty)
                        {
                            DataSet dsAdjustPriceStand = new DataSet();
                            string strAdjCondition = string.Format(" strCustomerName like '%{0}%'  and strFabricClass like '%{1}%' "
                                , strCustomerName, strFabricClass);
                            dsAdjustPriceStand = BLWF.GetDataSetBySpName("AdjustPriceStand_List", strAdjCondition);
                            if (dsAdjustPriceStand != null && dsAdjustPriceStand.Tables.Count > 0 && dsAdjustPriceStand.Tables[0].Rows.Count > 0)
                            {
                                if (dsAdjustPriceStand != null && dsAdjustPriceStand.Tables.Count > 0 && dsAdjustPriceStand.Tables[0].Rows.Count > 0 &&
                                    dsAdjustPriceStand.Tables[0].Rows[0]["fPrice"].ToString() != string.Empty)
                                {
                                    fPrice = Convert.ToSingle(dsAdjustPriceStand.Tables[0].Rows[0]["fPrice"]);

                                }

                            }
                        }
                    }
                }
                else
                {

                    fPrice = 0;

                }
            }
            else //色号全部是汉字，则单价标志直接设为1,(在上面色号处理中已将色号全部是汉字的设为空了)
            {
                fPrice = 0;
            }
            return fPrice;
        }
        //注解：这段代码两个方法实际上可以合成一个方法，实际上可以合成一个方法，分两上地方调用可以增加参数区别，修改为如下:可节省很多重复代码,系统中类似于这种方式的代码还存在很多，
        internal bool UpdateBisPrice(bool isUpdate,string strOrderCode, string strCustomerName, string strFabricClass, string strColorNumber, string strOrderCNDetailID, out float fDyePrice, out bool bIsExistPrice)
        {
            float fPrice = 0;
            string strCNumber = strColorNumber;
            //4.色号分三种情况：a.英文字母加汉字，截取英文字母与数字部分作为搜索条件,b.全部是汉字，则单价标志设为1,c.全部是英文字母，则按英文字母作为搜索条件
            if (strColorNumber.ToString().Contains("-"))
                strCNumber = strColorNumber.ToString().Remove(strColorNumber.ToString().IndexOf('-'));
            if (strColorNumber.ToString().Contains("/"))
                strCNumber = strColorNumber.Remove(strColorNumber.IndexOf('/'));
            else
                strCNumber = strColorNumber;

            if (strCNumber.Contains("DS") && strCNumber.Length > 7)
            {
                strCNumber = strCNumber.Substring(0, 8);
            }
            bool bIsPrice = false;
            DataSet dsDyeCoordinateAvgPrice = new DataSet();
            string strDyeCondition = string.Empty;
            //根据鼎盛需求:色号有DS开头这些就要去取染整单价，或者查单价标准那里其他那些输的色号不是DS开头那些直接更新为1
            if (strCNumber.Contains("DS"))
            {
                if (strCNumber.Length > 7)
                {
                    strDyeCondition = string.Format(" DyeCoordinateAvgPriceDetail.strMultCustomers like '%{0}%'  and (DyeCoordinateAvgPriceDetail.strColorNumber like '{1}[A-Z]%' or DyeCoordinateAvgPriceDetail.strColorNumber like '%{1}%' ) "
                       , strCustomerName, strCNumber);
                    dsDyeCoordinateAvgPrice = BLWF.GetDataSetBySpName("GetDyeCoordinateAvgPriceAndDetailALLData", strDyeCondition);
                    if (dsDyeCoordinateAvgPrice != null && dsDyeCoordinateAvgPrice.Tables.Count > 0 && dsDyeCoordinateAvgPrice.Tables[0].Rows.Count > 0)
                    {
                        bIsPrice = true;
                        if (dsDyeCoordinateAvgPrice != null && dsDyeCoordinateAvgPrice.Tables.Count > 0 && dsDyeCoordinateAvgPrice.Tables[0].Rows.Count > 0 &&
                            dsDyeCoordinateAvgPrice.Tables[0].Rows[0]["fPrice"].ToString() != string.Empty)
                        {
                            fPrice = Convert.ToSingle(dsDyeCoordinateAvgPrice.Tables[0].Rows[0]["fPrice"]);

                        }

                    }
                    else
                    {
                        DataSet dsAdjustPriceStand = new DataSet();
                        string strAdjCondition = string.Format(" strCustomerName like '%{0}%'  and strFabricClass like '%{1}%' "
                            , strCustomerName, strFabricClass);
                        dsAdjustPriceStand = BLWF.GetDataSetBySpName("AdjustPriceStand_List", strAdjCondition);
                        if (dsAdjustPriceStand != null && dsAdjustPriceStand.Tables.Count > 0 && dsAdjustPriceStand.Tables[0].Rows.Count > 0)
                        {
                            if (dsAdjustPriceStand != null && dsAdjustPriceStand.Tables.Count > 0 && dsAdjustPriceStand.Tables[0].Rows.Count > 0 &&
                                dsAdjustPriceStand.Tables[0].Rows[0]["fPrice"].ToString() != string.Empty)
                            {
                                fPrice = Convert.ToSingle(dsAdjustPriceStand.Tables[0].Rows[0]["fPrice"]);

                            }
                            bIsPrice = true;
                        }

                    }
                }
                else
                {

                    bIsPrice = false;

                }
            }
            else //色号全部是汉字，则单价标志直接设为1,(在上面色号处理中已将色号全部是汉字的设为空了)
            {
                bIsPrice = true;
            }
            fDyePrice = fPrice;
            bIsExistPrice = bIsPrice;
            if (isUpdate)
            {
                return BLWF.Update<BEOrderColorNumber>(string.Format("{0}='{1}' ", "bIsPrice", bIsPrice),
                string.Format("{0}='{1}'and {2}='{3}' ", BEOrderColorNumber.strOrderCode_, strOrderCode, BEOrderColorNumber.strOrderCNDetailID_, strOrderCNDetailID));
            }
        }

   
        

    }
}
