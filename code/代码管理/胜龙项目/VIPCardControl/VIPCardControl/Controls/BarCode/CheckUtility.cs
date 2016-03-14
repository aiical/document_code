using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using UFIDA.Retail.Common;
using UFIDA.Retail.Utility;
using System.Windows.Forms;
using UFIDA.Retail.Components;

namespace UFIDA.Retail.VIPCardControl
{
    public class CheckUtility
    {
        private Form objFrom = new Form();
        public Form MainFrom
        {
            set { objFrom = value; }
            get { return objFrom; }
        }
        /// <summary>
        /// 自由项处理
        /// </summary>
        public bool IsFreeCheck(DataRow objRow, string barCode, ArrayList freeFieldList, Hashtable freeFieldName, ref string errInfo)
        {
            errInfo = "";
            string freeField = "", freeValue = "", fchrItemName = "";
            for (int i = 1; i < 3; i++)  //modify by pj 20140116 由于胜龙只启用了两个自定义项 只需修改成3
            {
                freeField = "fchrfree" + i.ToString();
                if (freeFieldList.Contains(freeField)) continue;
                freeValue = Tools.GetStringColumnValue(objRow[freeField]);
                fchrItemName = objRow["fchrItemName"].ToString();
                if (!freeValue.Equals(""))
                {
                    errInfo = string.Format("没有启动自由项[{0}]：“{1}”", freeField, freeValue);
                    return false;
                }
            }
            if (freeFieldList.Count == 0) return true;

            string fchrItemID = Tools.GetStringColumnValue(objRow["fchrItemID"]);
            string strSql = string.Format("Select * from Item where fchrItemID='{0}'", fchrItemID);

            DataTable objTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, strSql).Tables[0];
            bool fbitFree = false;
            int intCount = 0;
            for (int i = 1; i < 3; i++)  //modify by pj 20140116 由于胜龙只启用了两个自定义项 只需修改成3
            {
                freeField = "fchrfree" + i.ToString();
                if (!freeFieldList.Contains(freeField)) continue;
                fbitFree = Tools.GetBoolColumnValue(objTable.Rows[0]["fbitFree" + i.ToString()]);
                freeValue = Tools.GetStringColumnValue(objRow[freeField]);
                fchrItemName = freeFieldName[freeField].ToString();
       
                if (!freeValue.Equals("") && !fbitFree)
                {
                    //errInfo = string.Format("没有启动自由项[{0}]：“{1}”", fchrItemName, freeValue);
                    //return false;
                    objRow[freeField] = "";
                    continue;
                }
                if (freeValue.Equals("") && !fbitFree) continue;
                if (freeValue.Equals("") && fbitFree)
                {
                    errInfo = string.Format("没有启动自由项[{0}]的值不能为空", fchrItemName);
                    return false;
                }
                strSql = string.Format("select count(*) from UserDefineDatas where fchrFieldName='{0}' and fchrValue='{1}'", freeField, freeValue);
                intCount = Tools.GetIntColumnValue(SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, strSql));
                if (intCount < 1)
                {
                    errInfo = string.Format("“{0}”不是自由项[{1}]的值", freeValue, fchrItemName);
                    return false;
                }

            }
            return true;
        }
        /// <summary>
        /// 总行数
        /// </summary>
        public int GetDataGridCount(DataTable objTDetail)
        {
            //效率优化
            //int intCont = 0;
            //for (int i = 0; i < objTDetail.Rows.Count; i++)
            //{
            //    if (!(objTDetail.Rows[i].RowState == DataRowState.Deleted || objTDetail.Rows[i].RowState == DataRowState.Detached))
            //    {
            //        intCont += 1;
            //    }
            //}

            DataRow[] dataRows = objTDetail.Select("", "", DataViewRowState.CurrentRows);

            return dataRows.Length;
        }
        /// <summary>
        /// 合并商品
        /// </summary>
        public DataTable UniteItem(DataTable objSTable, DataRow objRow, ref int intCount, string barCode)
        {
            intCount = 0;
            DataColumn objColumn = new DataColumn();
            objColumn.ColumnName = "fstrTempColumn";
            objColumn.DataType = typeof(string);
            objSTable.Columns.Add(objColumn);
            ExComboBox objControl = HandleEventHelper.FindControl("ftinOutVouchType", objFrom) as ExComboBox;
            if (objControl != null) objControl.EnableControl = "False";
            if (objSTable.Rows.Count > 0)
            {
                int index = objSTable.Rows.Count - 1;
                if (!(objSTable.Rows[index].RowState == DataRowState.Deleted
                    || objSTable.Rows[index].RowState == DataRowState.Detached))
                {
                    if (objSTable.Rows[index]["fchrItemID"].ToString().Equals(""))
                    {
                        objSTable.Rows.RemoveAt(index);
                    }
                }
            }
            for (int i = 0; i < objSTable.Rows.Count; i++)
            {
                if (objSTable.Rows[i].RowState == DataRowState.Deleted
                    || objSTable.Rows[i].RowState == DataRowState.Detached) continue;
                if (objSTable.Rows[i]["fchrBatchCode"].ToString().Equals(""))
                    objSTable.Rows[i]["fchrBatchCode"] = "";
                if (objSTable.Columns["fdtmProduceDate"].DataType.Name == "String")
                {
                    if (objSTable.Rows[i]["fdtmProduceDate"].ToString().Equals(""))
                        objSTable.Rows[i]["fdtmProduceDate"] = "";
                }
                objSTable.Rows[i]["fstrTempColumn"] = Guid.NewGuid().ToString();
                for (int j = 1; j <= 10; j++)
                {
                    if (objSTable.Rows[i]["fchrfree" + j.ToString()].ToString().Equals(""))
                        objSTable.Rows[i]["fchrfree" + j.ToString()] = "";
                }
            }
            DataTable objTTable = objSTable.Copy();
            DataTable objTFilter = objTTable.Copy();
            DataView objVFilter = objTTable.Copy().DefaultView;
            DataTable objTTemp = new DataTable();
            Hashtable objUpdateItemID = new Hashtable();
            ArrayList objDeleteItemID = new ArrayList();
            double quantity = 0.0;
            string strFilter = GetUniteItemSql(objSTable, objRow);
            
            objVFilter = objTFilter.DefaultView;
            objVFilter.RowFilter = strFilter.ToString();
            objTTemp = objVFilter.ToTable();

            if (objTTemp.Rows.Count == 0)
            {
                //条码,条码名称
                if (objSTable.Columns.Contains("fchritemname"))
                {
                    if (objSTable.Columns.Contains("条码名称"))
                    {
                        objRow["条码名称"] = objRow["fchritemname"];
                    }
                    if (objSTable.Columns.Contains("条码"))
                    {
                        objRow["条码"] = barCode;
                    }
                }
                objSTable.Rows.Add(objRow);
                intCount = -1;
                for (int i = 0; i < objSTable.Rows.Count; i++)
                {
                    if (objSTable.Rows[i].RowState == DataRowState.Deleted
                      || objSTable.Rows[i].RowState == DataRowState.Detached) continue;
                    intCount++;
                }
                objSTable.Columns.Remove("fstrTempColumn");
                return objSTable;
            }
            string fstrTempColumn = "";
            ArrayList objList = new ArrayList();
            for (int j = 0; j < objTTemp.Rows.Count; j++)
            {
                objList.Add(objTTemp.Rows[j]["fstrTempColumn"].ToString());
                quantity += Tools.GetDblColumnValue(objTTemp.Rows[j]["flotQuantity"]);
            }
            for (int i = 0; i < (objList.Count - 1); i++)
            {
                fstrTempColumn = objList[i].ToString();
                for (int j = 0; j < objSTable.Rows.Count; j++)
                {
                    if (objSTable.Rows[j].RowState == DataRowState.Deleted
                    || objSTable.Rows[j].RowState == DataRowState.Detached) continue;

                    if (objSTable.Rows[j]["fstrTempColumn"].ToString().Equals(fstrTempColumn))
                    {
                        objSTable.Rows.RemoveAt(j);
                        break;
                    }
                }
            }
            fstrTempColumn = objList[objList.Count - 1].ToString();
            for (int i = 0; i < objSTable.Rows.Count; i++)
            {
                if (objSTable.Rows[i].RowState == DataRowState.Deleted
                  || objSTable.Rows[i].RowState == DataRowState.Detached) continue;

                if (objSTable.Rows[i]["fstrTempColumn"].ToString().Equals(fstrTempColumn))
                {
                    objSTable.Rows[i]["flotQuantity"] = quantity + 1;
                    double flotQuotePrice = 0.0;
                    if (objSTable.Columns.Contains("flotQuotePrice"))
                    {
                        flotQuotePrice = Tools.GetDblColumnValue(objSTable.Rows[i]["flotQuotePrice"]);
                    }
                    if (objSTable.Columns.Contains("零售价"))
                    {
                        flotQuotePrice = Tools.GetDblColumnValue(objSTable.Rows[i]["零售价"]);
                    }
                    if (objSTable.Columns.Contains("flotMoney"))
                    {
                        objSTable.Rows[i]["flotMoney"] = flotQuotePrice * (quantity + 1);
                    }

                    
                    //-----
                    //下面的语句先保存一下，所属方法暂时不会用到。
                    //此外还有必要设置一下PrimaryKey(sDetailPrimaryValue----问题是取哪个的值。默认取第一条的好了。若增加进来的数据也需要合并，则增加进来的也同样要做此考虑。)
                    if (objSTable.Rows[i].RowState == DataRowState.Added)
                    {
                        objSTable.Rows[i].AcceptChanges();
                        if (objSTable.Rows[i].RowState == DataRowState.Unchanged)
                        objSTable.Rows[i].SetModified();
                    }
                    //-----
                    break;
                }
                intCount++;
            }
            objSTable.Columns.Remove("fstrTempColumn");
            return objSTable;
        }
        /// <summary>
        /// 获取合并的脚本
        /// </summary>
        /// <returns></returns>
        private string GetUniteItemSql(DataTable objSTable, DataRow objRow)
        {
            StringBuilder objFilter = new StringBuilder();
            objFilter = new StringBuilder();
            objFilter.AppendFormat("(fchrItemID='{0}') AND ", objRow["fchrItemID"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrBatchCode='{0}') AND ", objRow["fchrBatchCode"].ToString().Replace("'", ""));
            string fdtmProduceDate = objRow["fdtmProduceDate"].ToString().Replace("'", "");
            if (fdtmProduceDate.Equals(""))
            {
                if (objSTable.Columns["fdtmProduceDate"].DataType.Name == "String")
                    objFilter.Append("(fdtmProduceDate ='') AND ");
                else
                    objFilter.Append("(fdtmProduceDate is  Null) AND ");
            }
            else
            {
                objFilter.AppendFormat("(fdtmProduceDate='{0}') AND ", objRow["fdtmProduceDate"].ToString().Replace("'", ""));
            }
            objFilter.AppendFormat("(fchrfree1='{0}') AND ", objRow["fchrfree1"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree2='{0}') AND ", objRow["fchrfree2"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree3='{0}') AND ", objRow["fchrfree3"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree4='{0}') AND ", objRow["fchrfree4"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree5='{0}') AND ", objRow["fchrfree5"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree6='{0}') AND ", objRow["fchrfree6"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree7='{0}') AND ", objRow["fchrfree7"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree8='{0}') AND ", objRow["fchrfree8"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree9='{0}') AND ", objRow["fchrfree9"].ToString().Replace("'", ""));
            objFilter.AppendFormat("(fchrfree10='{0}') ", objRow["fchrfree10"].ToString().Replace("'", ""));

            return objFilter.ToString();
        }

        /// <summary>
        /// 判断实盘盘单录入商品的范围
        /// </summary>
        /// <param name="fchrCheckSetoutCode">盘点准备单编码</param>
        /// <param name="fchrItemID">商品ID</param>
        /// <returns></returns>
        public static bool CheckRealStockInputItemRange(string fchrCheckSetoutCode, string fchrItemID, out string strErrorMessage)
        {
            StringBuilder objSql = new StringBuilder();
            if (Tools.GetIntSysPara("CheckInputItemRange") == 1)
            {
                objSql.Append("select [fchrItemID]");
                objSql.Append(" from [CheckSetoutDetail] Where fchrCheckSetoutID in ");
                objSql.AppendFormat(" (Select top 1 fchrCheckSetoutID From CheckSetout Where fchrCode='{0}') AND fchrItemID='{1}'", fchrCheckSetoutCode, fchrItemID);

                DataTable objTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, objSql.ToString()).Tables[0];
                if (objTable.Rows.Count < 1)
                {
                    strErrorMessage = "输入的商品不在当前盘点准备单内！";
                    return false;
                }
                else
                {
                    strErrorMessage = string.Empty;
                    return true;
                }
            }
            else
            {
                //零售实盘单录入时，不允许录入准备单上没有，但库存余额表上有的商品。
                objSql.Append("select [fchrItemID]");
                objSql.Append(" from [CheckSetoutDetail] Where fchrCheckSetoutID in ");
                objSql.AppendFormat(" (Select top 1 fchrCheckSetoutID From CheckSetout Where fchrCode='{0}') AND fchrItemID='{1}'", fchrCheckSetoutCode, fchrItemID);
                objSql.AppendFormat(" UNION ALL SELECT  DISTINCT fchrItemID FROM Item WHERE fchrItemID NOT IN (SELECT DISTINCT fchrItemID FROM ItemStocks) AND fchrItemID='{0}' ", fchrItemID);

                DataTable objTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, objSql.ToString()).Tables[0];
                if (objTable.Rows.Count < 1)
                {
                    strErrorMessage = "输入的商品不在当前盘点准备单内！";
                    return false;
                }
                else
                {
                    strErrorMessage = string.Empty;
                    return true;
                }
            }
        }
    }
}
