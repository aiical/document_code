using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UFIDA.Retail.Common;
using UFIDA.Retail.Utility;
using System.Xml;
using UFIDA.Retail.Components;
using UFIDA.Retail.Barcode;
using System.IO;
using UFIDA.Retail.DataAccess;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmAddDetail : Form {
        public frmAddDetail() {
            InitializeComponent();
            SetFreeNameOrField();
        }
        private ArrayList freeFieldList = new ArrayList();
        public ArrayList FreeFieldList {
            set { freeFieldList = value; }
            get { return freeFieldList; }
        }
        private Hashtable freeFieldName = new Hashtable();
        public Hashtable FreeFieldName {
            set { freeFieldName = value; }
            get { return freeFieldName; }
        }
        #region 属性
        public DataGrid DataGrid {
            get { return dataGrid; }
            set { dataGrid = value; }
        }
        DataGrid dataGrid;

        public HandleEvent HandleEvent {
            get { return handleEvent; }
            set { handleEvent = value; }
        }
        private HandleEvent handleEvent;

        public XmlNode ConfigNode {
            get { return configNode; }
            set { configNode = value; }
        }
        private XmlNode configNode;


        public CheckDoWith CheckDoWith {
            get { return checkDoWith; }
            set { checkDoWith = value; }
        }
        private CheckDoWith checkDoWith;
        #endregion
        /// <summary>
        /// 单据进入的类型
        /// </summary>
        RealCheckType realCheckType;

        /// <summary>
        /// 是否第一次添加窗体高度
        /// </summary>
        private bool isFirstAddHeight = true;
        /// <summary>
        /// 错误编号
        /// </summary>
        private int errorNo = 1;

        void btnExit_Click(object sender, EventArgs e) {
            HandleEvent.FilterEmptyRows(DataGrid);
            this.Close();
        }

        void btnFinsh_Click(object sender, EventArgs e) {
            string barCode = BarCodeConvert(txtBarCode.Text);            
            if (isInOutBill) {               
                this.InOutCheckBarCode(barCode, 1);
            } else {
                this.CheckBarCode(barCode);
            }
        }

        public void CheckBarCode(string barCode) {
            if (barCode.Length == 0) {
                //RetailMessageBox.ShowWarning(this, "请输入条码");
                return;
            }
            DataSet gridDataSet = this.DataGrid.DataSource as DataSet;
            if (gridDataSet.Tables.Count == 0) {
                return;
            }
            try {
                string templateFilePath = SysPara.GetSysPara("DataPath") + @"\xml\Refer\Ref_ScanBarCodeAllItem.xml";
                Parser parser = new Parser();
                parser.TemplateID = templateFilePath;
                string connectionString = Tools.GetStringSysPara("SysConn");
                parser.ConnectString = connectionString;
                string errStr = string.Empty;
                DataSet ds = new DataSet();
                string fchrCheckSetoutCode = string.Empty;

                //条码扫描不处理联营商品.V891一期补丁
                parser.ParentCondition = "ftinItemModel=1";

                //解析条码
                parser.DoParse(barCode.Trim(), out ds, out errStr);
                if ((errStr == null || errStr == "") && ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0) {
                    Logger.WriteLine(barCode + "  正确");
                    DataTable fchrItemTable = new DataTable();
                    fchrItemTable = ds.Tables[0];
                    string fchrItemID = fchrItemTable.Rows[0]["存货id"].ToString();
                    if (IsNoUsedItem(fchrItemID)) {
                        //条码扫描错误提示音
                        Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);
                        AddErrorBarCode(barCode.Trim(), "商品已被禁用");
                        txtBarCode.Text = "";
                        txtBarCode.Select();
                        return;
                    }
                    string sqlText = string.Empty;
                    if (this.realCheckType == RealCheckType.RealCheck) {
                        fchrCheckSetoutCode = (HandleEventHelper.FindControl("fchrCheckSetoutCode", HandleEvent.InitFormClass.MainForm) as RefControl).TextBox.Text;
                        sqlText = string.Format("SELECT TOP 1 * FROM viewCheckSetoutDetail WHERE (  fchrCode  = '{0}') AND ( 1=1 ) AND fchrItemID= '{1}' ORDER BY fchrItemCode ", fchrCheckSetoutCode, fchrItemID);
                    } else {
                        fchrCheckSetoutCode = (HandleEventHelper.FindControl("fchrCheckSetoutCode", HandleEvent.InitFormClass.MainForm) as ExLabel).ControlValue;
                        sqlText = string.Format("SELECT TOP 1 * FROM viewRealStocksDetail WHERE fchrRealStocksID IN (SELECT fchrRealStocksID FROM viewRealStocks WHERE fchrCheckSetoutCode='{0}') AND fchrItemID='{1}' ORDER BY ftinOrder", fchrCheckSetoutCode, fchrItemID);
                    }

                    DataTable fbitFreeTable = new DataTable();
                    if (ds.Tables.Count > 1) {
                        fbitFreeTable = ds.Tables[1];
                    }
                    //判断商品是否属于该实盘单
                    /*DataTable checkSetoutDT = this.GetDataTable(sqlText);
                    if (checkSetoutDT.Rows.Count == 0)
                    {
                        AddErrorBarCode(barCode.Trim(), ErrorMessage.ErrorBarCode);
                        txtBarCode.Select();
                        return;
                    }*/
                    //获得中文列名对应的英文名字
                    this.MatchColumn(templateFilePath, fchrItemTable);

                    List<DataTable> resultTableList = new List<DataTable>();
                    resultTableList.Add(fchrItemTable);
                    resultTableList.Add(fbitFreeTable);
                    this.BindGrid(resultTableList, barCode);

                    #region
                    /*
                    //商品信息
                    DataTable fchrItemTable = new DataTable();
                    //fchrItemTable = ds.Tables[0];
                    string fchrItemID = ds.Tables[0].Rows[0][0].ToString();
                    string fchrCheckSetoutCode = string.Empty;
                    string sqlText = string.Empty;
                    if (this.realCheckType == RealCheckType.RealCheck)
                    {
                        fchrCheckSetoutCode = (HandleEventHelper.FindControl("fchrCheckSetoutCode", HandleEvent.InitFormClass.MainForm) as RefControl).TextBox.Text;
                        sqlText = string.Format("SELECT TOP 1 * FROM viewCheckSetoutDetail WHERE (  fchrCode  = '{0}') AND ( 1=1 ) AND fchrItemID= '{1}' ORDER BY fchrItemCode ", fchrCheckSetoutCode, fchrItemID);
                    }
                    else
                    {
                        fchrCheckSetoutCode = (HandleEventHelper.FindControl("fchrCheckSetoutCode", HandleEvent.InitFormClass.MainForm) as ExLabel).ControlValue;
                        sqlText = string.Format("SELECT TOP 1 * FROM viewRealStocksDetail WHERE fchrRealStocksID IN (SELECT fchrRealStocksID FROM viewRealStocks WHERE fchrCheckSetoutCode='{0}') AND fchrItemID='{1}' ORDER BY ftinOrder", fchrCheckSetoutCode, fchrItemID);
                    }

                    fchrItemTable = this.GetDataTable(sqlText,barCode);
                    if (fchrItemTable.Rows.Count == 0)
                    {
                        AddErrorBarCode(barCode.Trim(), ErrorMessage.ErrorBarCode);
                        txtBarCode.Select();
                        return;
                    }
                    ////检查所解析出来的数据是否出现了错误
                    //foreach (DataRow itemRow in fchrItemTable.Rows)
                    //{
                    //    for (int i = 1; i <= 10; i++)
                    //    {
                    //        string fchrFree=string.Format("fchrFree{0}",i);
                    //        if (Tools.GetBoolColumnValue(itemRow[fchrFree]))
                    //        {
                    //            bool isSuccess = this.CheckDoWith.CheckItemFree(fchrItemID, fchrFree, itemRow[fchrFree].ToString());
                    //            if (!isSuccess)
                    //            {
                    //                AddErrorBarCode(barCode.Trim(), ErrorMessage.ErrorFchrFree);
                    //                txtBarCode.Select();
                    //                return;
                    //            }
                    //        }
                    //    }
                    //}

                    //商品自由项信息
                    DataTable fbitFreeTable = new DataTable();
                    if (ds.Tables.Count > 1)
                    {
                        fbitFreeTable = ds.Tables[1];
                    }
                    ////判断自由项是否启动
                    //List<string> startUpList = JudgeFbitFreeIsStartup(fchrItemID, barCode);
                    //if (startUpList.Count == 0)
                    //{
                    //    AddErrorBarCode(barCode.Trim(), ErrorMessage.NoFchrFree);
                    //    txtBarCode.Select();
                    //    return;
                    //}
                    ////如果启动检查是否都有值
                    //bool isEmptyFbitFree = this.JudgeFbitFreeIsEmpty(fbitFreeTable, startUpList, fchrItemID);
                    //if (!isEmptyFbitFree)
                    //{
                    //    AddErrorBarCode(barCode.Trim(), ErrorMessage.ErrorFchrFree);
                    //    txtBarCode.Select();
                    //    return;
                    //}
                    #region
                    
                    //判断是否有效期管理 
                    bool isValidDay = this.JudgeIsValidDay(fchrItemID);
                    if (isValidDay)
                    {
                        //判断效期是否为空
                        bool isValidDayEmpty = JudgeValidDayIsEmpty(fbitFreeTable);
                        if (isValidDay)
                        {
                            AddErrorBarCode(barCode.Trim());
                            txtBarCode.Select();
                            return;
                        }
                    } 
                    #endregion
                    ////判断是否批次管理
                    //bool isBatch = this.JudgeIsBatch(fchrItemID);
                    //if (isBatch)
                    //{
                    //    //判断批次是否为空
                    //    bool isBatchEmpty = this.JudgeIsBatchEmpty(fbitFreeTable);
                    //    if (isBatchEmpty)
                    //    {
                    //        AddErrorBarCode(barCode.Trim(), ErrorMessage.ErrorBach);
                    //        txtBarCode.Select();
                    //        return;
                    //    }
                    //}
                    
                    List<DataTable> resultTableList = new List<DataTable>();
                    resultTableList.Add(fchrItemTable);
                    resultTableList.Add(fbitFreeTable);
                    this.BindGrid(resultTableList);
                    */
                    #endregion
                } else {
                    string sqlText = this.GetItemAndFreeSQLTextByBarCodeFromDB(barCode);
                    DataTable itemTable = new DataTable();
                    try {
                        itemTable = this.GetDataTable(sqlText, barCode);
                    } catch {
                        //条码扫描错误提示音
                        Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

                        AddErrorBarCode(barCode.Trim(), errStr);
                        txtBarCode.Select();
                        return;
                    }
                    if (itemTable.Rows.Count == 0) {
                        //条码扫描错误提示音
                        Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

                        //AddErrorBarCode(barCode.Trim(), errStr);
                        AddErrorBarCode(barCode.Trim(), "没有符合条件的商品");
                        txtBarCode.Select();
                        return;
                    }
                    string fchrItemID = itemTable.Rows[0]["fchrItemID"].ToString();
                    if (IsNoUsedItem(fchrItemID)) {
                        //条码扫描错误提示音
                        Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

                        AddErrorBarCode(barCode.Trim(), "商品已被禁用");
                        txtBarCode.Text = "";
                        txtBarCode.Select();
                        return;
                    }
                    //如果启动检查是否都有值
                    bool isEmptyFbitFree = this.JudgeFbitFreeIsEmpty(itemTable, fchrItemID);
                    if (!isEmptyFbitFree) {
                        //条码扫描错误提示音
                        Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

                        AddErrorBarCode(barCode.Trim(), "条形码带不出商品自由项");
                        txtBarCode.Select();
                        return;
                    }
                    bool isBatch = this.JudgeIsBatch(fchrItemID);
                    if (isBatch) {
                        //判断批次是否为空
                        bool isBatchEmpty = this.JudgeIsBatchEmpty(itemTable);
                        if (isBatchEmpty) {
                            //条码扫描错误提示音
                            Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

                            AddErrorBarCode(barCode.Trim(), "条码带不出批次和效期。");
                            txtBarCode.Select();
                            return;
                        }
                    }
                    BindGrid(itemTable, barCode);
                }
                //条码扫描正确提示音
                Console.Beep(ApplicationConstraints.RIGHT_FRNQUENCY, ApplicationConstraints.RIGHT_DURATION);

                this.txtBarCode.Clear();
                //DataTable dt = (this.DataGrid.DataSource as DataSet).Tables[ApplicationConstraints.DetailTableName];
                //if (dt.Rows.Count > 0)
                //{
                //    if (this.realCheckType == RealCheckType.RealCheck)
                //    {
                //        (HandleEventHelper.FindControl("fchrCheckSetoutCode", HandleEvent.InitFormClass.MainForm) as RefControl).EnableControl = "false";
                //    }
                //}
            } catch (Exception ex) {
                Logger.WriteLine(ex.Message);
                //AddErrorBarCode(barCode.Trim());
                HandleEvent.FilterEmptyRows(DataGrid);
                txtBarCode.Select();
            }
        }

        /// <summary>
        /// 匹配列表项
        /// liwenzhen2008.10.30
        /// </summary>
        /// <param name="filePath">xml文件路径</param>
        /// <param name="fchrItemTable">数据表</param>
        /// <returns></returns>
        public DataTable MatchColumn(string filePath, DataTable fchrItemTable) {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNodeList nodeList = doc.GetElementsByTagName("Col");
            foreach (XmlNode node in nodeList) {
                fchrItemTable.Columns[node.Attributes["AssignValue"].Value].ColumnName = node.Attributes["Caption"].Value;
            }
            return fchrItemTable;
        }
        /// <summary>
        /// 获得商品信息
        /// </summary>
        private DataTable GetDataTable(string sqlText, string barcode) {
            string connectionString = Tools.GetStringSysPara("SysConn");
            //string commandText = this.GetItemAndFreeSQLTextByBarCodeFromDB(barcode);
            //commandText = sqlText;
            DataTable dt = new DataTable();
            try {
                dt = SqlAccess.ExecuteDataTable(connectionString, sqlText);
                return dt;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        private DataTable GetDataTable(string sqlText) {
            string connectionString = Tools.GetStringSysPara("SysConn");
            string commandText = sqlText;
            DataTable dt = new DataTable();
            try {
                dt = SqlAccess.ExecuteDataTable(connectionString, commandText);
                return dt;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        private bool CheckInputItemRange(string fchrCode, DataRow objRow, out string strErrorMessage) {
            //int intTemp = SysPara.GetInteger("CheckInputItemRange");
            //if (intTemp != 1) return true;
            //StringBuilder objSql = new StringBuilder();
            string fchrItemID = Tools.GetStringColumnValue(objRow["fchrItemID"]);

            //零售实盘单录入时，不允许录入准备单上没有，但库存余额表上有的商品。V891二期补丁
            if (CheckUtility.CheckRealStockInputItemRange(fchrCode, fchrItemID, out strErrorMessage)) {
                strErrorMessage = "";
                return true;
            } else {
                if (SysPara.GetInteger("CheckInputItemRange") == 1) {
                    strErrorMessage = "实盘商品必须来自于盘点准备单";
                } else {
                    strErrorMessage = "不能导入存在于店存余额表但不在盘点准备单中的商品";
                }
                return false;
            }

            //swc20091120 比较范围去掉自由项的比较，即盘点准备单商品为红色，实盘单可以包含该商品的绿色类型。
            //objSql.Append("Select [fchrFree1],[fchrFree2],[fchrFree3],[fchrFree4],[fchrFree5],");
            //objSql.Append(" [fchrFree6],[fchrFree7],[fchrFree8],[fchrFree9],[fchrFree10],");
            //objSql.Append("select [fdtmInvalidDate],[fdtmProduceDate],[fchrBatchCode],[fchrItemID]");
            //objSql.Append(" from [CheckSetoutDetail] Where fchrCheckSetoutID in ");
            //objSql.AppendFormat(" (Select top 1 fchrCheckSetoutID From CheckSetout Where fchrCode='{0}') AND fchrItemID='{1}'", fchrCode, fchrItemID);
            //上面的SQL语句可能会返回多条相同的数据。
            //DataTable objTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, objSql.ToString()).Tables[0];
            //if (objTable.Rows.Count < 1) 
            //    return false;
            //else
            //    return true;
            //当条码的批次 有效期 生产日期与准备单里的不同时，也可以进入实盘单,只要商品编码一致就行。
            //string columnName = "";
            //for (int i = 0; i < objTable.Rows.Count; i++)
            //{
            //    for (int j = 0; j < objTable.Columns.Count; j++)
            //    {
            //        columnName = objTable.Columns[j].ColumnName;
            //        if (!objRow.Table.Columns.Contains(columnName)) continue;
            //        if (columnName.ToLower().Equals("fdtmInvalidDate".ToLower()) || columnName.ToLower().Equals("fdtmProduceDate".ToLower()))
            //        {
            //            string dateSValue=objTable.Rows[i][columnName].ToString();
            //            string dateTValue = objRow[columnName].ToString();
            //            if (dateSValue.Equals("") && dateSValue == dateTValue) continue;
            //            if (dateTValue.Equals("") && dateSValue != dateTValue) break;

            //            DateTime dateSDValue = Tools.GetDateTime(dateSValue);
            //            DateTime dateTDValue = Tools.GetDateTime(dateTValue);
            //            if (dateSDValue != dateTDValue) break;
            //            if (objRow.Table.Columns[columnName].DataType.Name.ToLower().Equals("String".ToLower()))
            //            {
            //                objRow[columnName] = dateTDValue.ToString(SysPara.FormatDate());
            //            }
            //            else
            //            {
            //                objRow[columnName] = Tools.GetDateTime(dateTDValue.ToString(SysPara.FormatDate()));
            //            }
            //        }
            //        else
            //        {
            //            if (objTable.Rows[i][columnName].ToString() != objRow[columnName].ToString()) break;
            //        }
            //        if (j == objTable.Columns.Count - 1)
            //        {
            //            return true;
            //        }
            //    }
            //}
            //return false;
        }
        /// <summary>
        /// 自由项处理
        /// </summary>
        //private bool IsFreeCheck(DataRow objRow,string barCode)
        //{ 
        //    string freeField = "", freeValue = "", fchrItemName="", ErrInof="";
        //    for (int i = 1; i < 11; i++)
        //    {
        //        freeField = "fchrfree" + i.ToString();
        //        if (freeFieldList.Contains(freeField)) continue;
        //        freeValue = Tools.GetStringColumnValue(objRow[freeField]);
        //        fchrItemName = objRow["fchrItemName"].ToString();
        //        if (!freeValue.Equals(""))
        //        {
        //            ErrInof = string.Format("没有启动自由项[{0}]：“{1}”", freeField, freeValue);
        //            return false;
        //        }
        //    }
        //    if (freeFieldList.Count == 0) return true;

        //    string fchrItemID = Tools.GetStringColumnValue(objRow["fchrItemID"]);
        //    string strSql = string.Format("Select * from Item where fchrItemID='{0}'", fchrItemID);

        //    DataTable objTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, strSql).Tables[0];
        //    bool fbitFree = false;
        //    int intCount = 0;
        //    for (int i = 1; i < 11; i++)
        //    {
        //        freeField = "fchrfree" + i.ToString();
        //        if (!freeFieldList.Contains(freeField)) continue;
        //        fbitFree = Tools.GetBoolColumnValue(objTable.Rows[0]["fbitFree" + i.ToString()]);
        //        freeValue = Tools.GetStringColumnValue(objRow[freeField]);
        //        fchrItemName = freeFieldName[freeField].ToString();

        //        if (!freeValue.Equals("") && !fbitFree)
        //        {
        //            ErrInof = string.Format("没有启动自由项[{0}]：“{1}”", fchrItemName, freeValue);
        //            AddErrorBarCode(barCode, ErrInof);
        //            return false;
        //        }
        //        if (freeValue.Equals("") && !fbitFree) continue;
        //        if (freeValue.Equals("") && fbitFree)
        //        {
        //            ErrInof = string.Format("没有启动自由项[{0}]的值不能为空", fchrItemName);
        //            AddErrorBarCode(barCode, ErrInof);
        //            return false;
        //        }
        //        strSql = string.Format("select count(*) from UserDefineDatas where fchrFieldName='{0}' and fchrValue='{1}'", freeField, freeValue);
        //        intCount = Tools.GetIntColumnValue(SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, strSql));
        //        if (intCount < 1)
        //        {
        //            ErrInof = string.Format("“{0}”不是自由项[{1}]的值",freeValue,fchrItemName);
        //            AddErrorBarCode(barCode, ErrInof);
        //            return false;
        //        }

        //    }
        //    return true;
        //}
        private void SetFreeNameOrField() {
            string strSql = "select fchrFieldName,fchrItemName from UserDefine";
            DataTable objTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, strSql).Tables[0];
            string freeField = "", freeValue = "", fchrItemName;
            for (int i = 0; i < objTable.Rows.Count; i++) {
                freeField = Tools.GetStringColumnValue(objTable.Rows[i]["fchrFieldName"]).ToLower();
                fchrItemName = Tools.GetStringColumnValue(objTable.Rows[i]["fchrItemName"]);
                freeFieldList.Add(freeField);
                freeFieldName.Add(freeField, fchrItemName);
            }
        }
        /// <summary>
        /// 从数据库中的条码获得商品及自由项
        /// </summary>
        /// <returns></returns>
        private string GetItemAndFreeSQLTextByBarCodeFromDB(string barCode) {
            //string sql =
            //"SELECT i.fchrItemID,fchrItemName, fchrBarCode,fchrFree1,fchrFree2,fchrFree3,fchrFree4 " +
            //"fchrFree5,fchrFree6,fchrFree7,fchrFree8,fchrFree9,fchrFree10 " +
            //"FROM BarCodeRuleCollateDetail as b,Item as i " +
            //"WHERE i.fchrItemID=b.fchrItemID  " +
            //"AND fchrBarCode='{0}'";

            //"SELECT * FROM BarCodeRuleCollateDetail as b,Item as i " +
            //"WHERE i.fchrItemID=b.fchrItemID  " +
            //"AND fchrBarCode='{0}'";
            //"SELECT * FROM Item WHERE fchrBarCode='{0}'";
            StringBuilder objSql = new StringBuilder();
            objSql.Append("select fchrItemID,fchrItemName, fchrAddCode, fbitNoUsed, fchrItemTypeID,");
            objSql.Append("fchrBarCode,fbitDiscount, fbitSpecial, fbitValidDay,  fintValidDays,fbitBatch,");
            objSql.Append("fchrUnitID,fchrItemCode, fchrUnitName, flotQuotePrice,  fbitOTC, fchrLevel, fchrProducingArea, fchrSpec, ");
            objSql.Append("fchrItemCDef1,fchrItemCDef2,fchrItemCDef3,fchrItemCDef4,fchrItemCDef5,fchrItemCDef6,");
            objSql.Append("fchrItemCDef7,fchrItemCDef8,fchrItemCDef9,fchrItemCDef10,fchrItemCDef11,fchrItemCDef12,");
            objSql.Append("fchrItemCDef13,fchrItemCDef14,fchrItemCDef15,fchrItemCDef16, ");
            objSql.Append("fchrFree1='',fchrFree2='',fchrFree3='',fchrFree4='',fchrFree5='',");
            objSql.Append("fchrFree6='',fchrFree7='',fchrFree8='',fchrFree9='',fchrFree10='',fdtmProduceDate=null,fchrBatchCode='',");
            objSql.Append("Cast((select (Cast(fbitFree1 as tinyint)+ Cast(fbitFree2 as tinyint) + ");
            objSql.Append("Cast(fbitFree3 as tinyint)+ Cast(fbitFree4 as tinyint)+ ");
            objSql.Append("Cast(fbitFree5 as tinyint)+ Cast(fbitFree6 as tinyint)+");
            objSql.Append("Cast(fbitFree7 as tinyint)+ Cast(fbitFree8 as tinyint)+ ");
            objSql.Append("Cast(fbitFree9 as tinyint)+ Cast(fbitFree10 as tinyint))) AS bit)  AS fbitFree ,flotMoney=0.0,flotQuantity=1 ");
            objSql.AppendFormat(" FROM Item Where fchrBarCode='{0}'", barCode);

            //fchrGUID,id
            //,,,,flotOldQuantity,flotQuantity,fchrRealStocksDetailID,
            //fchrSerialNo,fintHashCode

            string fchrCheckSetoutCode = string.Empty;
            if (this.realCheckType == RealCheckType.RealCheck) {
                fchrCheckSetoutCode = (HandleEventHelper.FindControl("fchrCheckSetoutCode", HandleEvent.InitFormClass.MainForm) as RefControl).TextBox.Text;
            } else {
                fchrCheckSetoutCode = (HandleEventHelper.FindControl("fchrCheckSetoutCode", HandleEvent.InitFormClass.MainForm) as ExLabel).ControlValue;
            }
            string sqlText = string.Format("SELECT TOP 1 * FROM viewCheckSetoutDetail WHERE (  fchrCode  = '{0}') AND ( 1=1 ) AND fchrBarCode= '{1}' ORDER BY fchrItemCode ", fchrCheckSetoutCode, barCode);
            try {
                if (SysPara.GetInteger("CheckInputItemRange") == 2) {
                    DataTable objTable = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, sqlText);
                    if (objTable.Rows.Count == 0) {
                        sqlText = objSql.ToString();
                    }
                }
            } catch { }
            return sqlText;
        }

        /// <summary>
        /// 从条码规则中获得商品
        /// </summary>
        /// <param name="fchrItemID"></param>
        /// <returns></returns>
        private string GetItemSQLTextByBarCode(string fchrItemID) {
            string sql =
                "SELECT * FROM Item WHERE fchrItemID = '{0}'";
            return string.Format(sql, fchrItemID);
        }

        /// <summary>
        /// 邦定DataGrid
        /// </summary>
        /// <param name="itemTable"></param>
        private void BindGrid(DataTable itemTable) {

            DataTable gridTable = (DataGrid.DataSource as DataSet).Tables[ApplicationConstraints.DetailTableName];
            //if (itemTable.Rows.Count == 0)
            //{
            //    RetailMessageBox.Show("没有符合条件的商品");
            //    return;
            //}
            DataRow row = gridTable.NewRow();
            try {
                for (int i = 0; i < gridTable.Columns.Count; i++) {
                    for (int j = 0; j < itemTable.Columns.Count; j++) {
                        if (gridTable.Columns[gridTable.Columns[i].ColumnName].ToString().Trim().ToUpper()
                            == itemTable.Columns[itemTable.Columns[j].ColumnName].ToString().Trim().ToUpper()) {
                            try {
                                row[i] = itemTable.Rows[0][j];
                            } catch { }
                        }
                    }
                }
                //if (row["flotQuantity"].ToString() == string.Empty)
                //{
                row["flotQuantity"] = 1;
                //}
                if (row["flotmoney"].ToString() == string.Empty) {
                    row["flotmoney"] = (
                                        int.Parse(row["flotQuantity"].ToString())
                                        *
                                        float.Parse(row["flotQuotePrice"].ToString())).ToString();
                }
                for (int j = 1; j < 11; j++) {
                    string fchrName = string.Format("fchrFree{0}", j);
                    if (row[fchrName].ToString() == string.Empty) {
                        row[fchrName] = "无";
                    }
                }

                //修改总数量和总金额
                string quantity = row["flotQuantity"].ToString();
                string lblFlotQuantity = (HandleEvent.FindControl("lblFlotQuantity", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue;
                if (lblFlotQuantity == "") {
                    lblFlotQuantity = "0";
                }
                float totalQuantity = float.Parse(quantity) + float.Parse(lblFlotQuantity);
                (HandleEvent.FindControl("lblFlotQuantity", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue = totalQuantity.ToString();

                string flotmoney = row["flotmoney"].ToString();
                string lblMoney = (HandleEvent.FindControl("lblMoney", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue;
                if (lblMoney == "") {
                    flotmoney = (float.Parse(quantity) * float.Parse(row["flotQuotePrice"].ToString())).ToString();
                }
                float totalmoney = float.Parse(flotmoney) + float.Parse(lblMoney);
                (HandleEvent.FindControl("lblMoney", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue = totalmoney.ToString();
                row["flotmoney"] = flotmoney;

                gridTable.Rows.Add(row);
                txtBarCode.Clear();
                HandleEvent.FilterEmptyRows(DataGrid);
                if (!HandleEvent.HasEmptyRow(this.DataGrid, gridTable)) {
                    gridTable.Rows.Add(gridTable.NewRow());
                }
                DataGrid.Select(gridTable.Rows.Count - 1);
                gridTable.Dispose();
            } catch (Exception ex) {
                Logger.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 邦定DataGrid
        /// </summary>
        /// <param name="tablelist">[0]:商品表[1]:自由项表</param>
        private void BindGrid(List<DataTable> tablelist, string barCode) {
            //CheckUtility objCheckUtility = new CheckUtility();
            ////商品表
            //DataTable itemTable = tablelist[0];

            //string fchrCheckSetoutCode = (HandleEventHelper.FindControl("fchrCheckSetoutCode", HandleEvent.InitFormClass.MainForm) as RefControl).TextBox.Text;

            CheckUtility objCheckUtility = new CheckUtility();
            //商品表
            DataTable itemTable = tablelist[0];
            //黄色小鸭
            RefControl objRefControl = HandleEventHelper.FindControl("fchrCheckSetoutCode", HandleEvent.InitFormClass.MainForm) as RefControl;
            string fchrCheckSetoutCode = "";
            if (objRefControl != null) {
                fchrCheckSetoutCode = objRefControl.TextBox.Text.Trim();
                objCheckUtility.MainFrom = objRefControl.FindForm();
            } else {
                ExLabel objExLabel = HandleEventHelper.FindControl("fchrCheckSetoutCode", HandleEvent.InitFormClass.MainForm) as ExLabel;
                fchrCheckSetoutCode = objExLabel.ControlValue;
                objCheckUtility.MainFrom = objExLabel.FindForm();
            }
            DataTable gridTable = (DataGrid.DataSource as DataSet).Tables[ApplicationConstraints.DetailTableName];
            //自由项表
            DataTable fchrFreeTable = tablelist[1];
            DataRow row = gridTable.NewRow();
            try {
                for (int i = 0; i < gridTable.Columns.Count; i++) {
                    for (int j = 0; j < itemTable.Columns.Count; j++) {
                        if (gridTable.Columns[gridTable.Columns[i].ColumnName].ToString().Trim().ToUpper()
                            == itemTable.Columns[itemTable.Columns[j].ColumnName].ToString().Trim().ToUpper()) {
                            row[i] = itemTable.Rows[0][j];
                        }
                    }
                }
                for (int i = 0; i < gridTable.Columns.Count; i++) {
                    for (int j = 0; j < fchrFreeTable.Columns.Count; j++) {
                        if (gridTable.Columns[gridTable.Columns[i].ColumnName].ToString().Trim().ToUpper()
                            == fchrFreeTable.Columns[fchrFreeTable.Columns[j].ColumnName].ToString().Trim().ToUpper()) {
                            row[i] = fchrFreeTable.Rows[0][j];
                        }
                    }
                }
                //if (row["flotQuantity"].ToString() == string.Empty)
                //{
                //商品数量取自条码。 V891一期补丁。
                //row["flotQuantity"] = 1;
                //}

                //修改总数量和总金额
                string quantity = row["flotQuantity"].ToString();
                string lblFlotQuantity = (HandleEvent.FindControl("lblFlotQuantity", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue;
                if (quantity == "") {
                    quantity = "0";
                }
                if (lblFlotQuantity == "") {
                    lblFlotQuantity = "0";
                }
                float totalQuantity = float.Parse(quantity) + float.Parse(lblFlotQuantity);
                //(HandleEvent.FindControl("lblFlotQuantity", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue = totalQuantity.ToString();

                string flotmoney = row["flotmoney"].ToString();
                string lblMoney = (HandleEvent.FindControl("lblMoney", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue;
                if (flotmoney == "") {
                    flotmoney = (float.Parse(quantity) * float.Parse(row["flotQuotePrice"].ToString())).ToString();
                }
                if (lblMoney == "") {
                    lblMoney = "0";
                }
                float totalmoney = float.Parse(flotmoney) + float.Parse(lblMoney);
                //(HandleEvent.FindControl("lblMoney", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue = totalmoney.ToString();
                row["flotmoney"] = flotmoney;
                string errInfo = "";
                string fchrItemID = row["fchrItemID"].ToString();
                if (!objCheckUtility.IsFreeCheck(row, barCode.Trim(), freeFieldList, freeFieldName, ref errInfo)) {
                    AddErrorBarCode(barCode.Trim(), errInfo);
                    return;//自由项判断
                }
                //if (!IsFreeCheck(row, barCode.Trim())) return;//自由项判断
                //检查实盘商品范围
                string strErrorMessage = string.Empty;
                if (!CheckInputItemRange(fchrCheckSetoutCode, row, out strErrorMessage)) {
                    AddErrorBarCode(barCode.Trim(), strErrorMessage);
                    txtBarCode.Clear();
                    return;
                }

                //gridTable.Rows.Add(row);
                //黄色小鸭chb2009-10-30
                int intCount = 0;
                //swc20091120 实盘时，对于条码解析规则的条码，在解析时没有有效期或批次时，不让进入实盘单
                //判断批次是否为空


                bool isBatch = this.JudgeIsBatch(fchrItemID);
                if (isBatch) {
                    bool isBatchEmpty = this.JudgeIsBatchEmpty(fchrFreeTable);
                    if (isBatchEmpty) {
                        AddErrorBarCode(barCode.Trim(), "条码带不出批次和有效期");
                        txtBarCode.Select();
                        return;
                    }
                }
                //判断是否有效期管理 
                bool isValidDay = this.JudgeIsValidDay(fchrItemID);
                if (isValidDay) {
                    //判断效期是否为空
                    bool isValidDayEmpty = JudgeValidDayIsEmpty(fchrFreeTable);
                    if (isValidDayEmpty) {
                        AddErrorBarCode(barCode.Trim(), "条码带不出批次和有效期");
                        txtBarCode.Select();
                        return;
                    }
                }

                (HandleEvent.FindControl("lblFlotQuantity", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue = totalQuantity.ToString();
                (HandleEvent.FindControl("lblMoney", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue = totalmoney.ToString();
                //-------------
                //gridTable = objCheckUtility.UniteItem(gridTable, row, ref intCount, barCode);//合并商品行 
                gridTable.Rows.Add(row);
                intCount = gridTable.Rows.IndexOf(row);
                //---结束
                txtBarCode.Clear();
                HandleEvent.FilterEmptyRows(DataGrid);
                if (!HandleEvent.HasEmptyRow(this.DataGrid, gridTable)) {
                    gridTable.Rows.Add(gridTable.NewRow());
                }
                //DataGrid.Select(gridTable.Rows.Count - 1);
                //黄色小鸭chb2009-10-30
                ExDataGrid objExGrid = this.DataGrid as ExDataGrid;
                //效率优化
                //for (int j = 0; j < objCheckUtility.GetDataGridCount(gridTable); j++)
                //{
                //    objExGrid.UnSelect(j);
                //}
                //objExGrid.Select(0);
                //objExGrid.CurrentRowIndex = 0;
                //DataGrid.UnSelect(0);

                objExGrid.UnSelectAll();

                DataGrid.Select(intCount);
                DataGrid.CurrentRowIndex = intCount;
                //--结束
                gridTable.Dispose();
            } catch (Exception ex) {
                Logger.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 邦定DataGrid
        /// </summary>
        /// <param name="itemTable"></param>
        private void BindGridTemp(DataTable itemTable, string barCode) {/*
            //商品表
            string fchrCheckSetoutCode = (HandleEventHelper.FindControl("fchrCheckSetoutCode", HandleEvent.InitFormClass.MainForm) as RefControl).TextBox.Text;
            DataTable gridTable = (DataGrid.DataSource as DataSet).Tables[ApplicationConstraints.DetailTableName];
            //自由项表
            //--DataTable fchrFreeTable = tablelist[1];
            DataRow row = gridTable.NewRow();
            try
            {
                for (int i = 0; i < gridTable.Columns.Count; i++)
                {
                    for (int j = 0; j < itemTable.Columns.Count; j++)
                    {
                        if (gridTable.Columns[gridTable.Columns[i].ColumnName].ToString().Trim().ToUpper()
                            == itemTable.Columns[itemTable.Columns[j].ColumnName].ToString().Trim().ToUpper())
                        {
                            row[i] = itemTable.Rows[0][j];
                        }
                    }
                }
                row["flotQuantity"] = 1;
                //修改总数量和总金额
                string quantity = row["flotQuantity"].ToString();
                string lblFlotQuantity = (HandleEvent.FindControl("lblFlotQuantity", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue;
                if (quantity == "")
                {
                    quantity = "0";
                }
                if (lblFlotQuantity == "")
                {
                    lblFlotQuantity = "0";
                }
                float totalQuantity = float.Parse(quantity) + float.Parse(lblFlotQuantity);
                (HandleEvent.FindControl("lblFlotQuantity", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue = totalQuantity.ToString();

                double lblMoney = Tools.GetDblColumnValue((HandleEvent.FindControl("lblMoney", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue);

                double flotmoney = 1 * Tools.GetDblColumnValue(row["flotQuotePrice"]);
                double totalmoney = flotmoney + lblMoney;
                (HandleEvent.FindControl("lblMoney", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue = totalmoney.ToString(SysPara.FormatMoney());
                row["flotmoney"] = flotmoney;

                if (!IsFreeCheck(row, barCode.Trim())) return;//自由项判断
                //实盘商品必须来自于盘点准备单
                if (!CheckInputItemRange(fchrCheckSetoutCode, row))
                {
                    AddErrorBarCode(barCode.Trim(), "实盘商品必须来自于盘点准备单");
                    txtBarCode.Clear();
                    return;
                }
                gridTable.Rows.Add(row);
                txtBarCode.Clear();
                HandleEvent.FilterEmptyRows(DataGrid);
                if (!HandleEvent.HasEmptyRow(this.DataGrid, gridTable))
                {
                    gridTable.Rows.Add(gridTable.NewRow());
                }
                DataGrid.Select(gridTable.Rows.Count - 1);
                gridTable.Dispose();
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }*/
        }
        /// <summary>
        /// 邦定DataGrid
        /// </summary>
        /// <param name="itemTable"></param>
        private void BindGrid(DataTable itemTable, string barCode) {
            //商品表
            //黄色小鸭
            CheckUtility objCheckUtility = new CheckUtility();
            RefControl objRefControl = HandleEventHelper.FindControl("fchrCheckSetoutCode", HandleEvent.InitFormClass.MainForm) as RefControl;
            string fchrCheckSetoutCode = "";
            if (objRefControl != null) {
                objCheckUtility.MainFrom = objRefControl.FindForm();
                fchrCheckSetoutCode = objRefControl.TextBox.Text.Trim();
            } else {
                ExLabel objExLabel = HandleEventHelper.FindControl("fchrCheckSetoutCode", HandleEvent.InitFormClass.MainForm) as ExLabel;
                fchrCheckSetoutCode = objExLabel.ControlValue;
                objCheckUtility.MainFrom = objExLabel.FindForm();
            }
            DataTable gridTable = (DataGrid.DataSource as DataSet).Tables[ApplicationConstraints.DetailTableName];


            //自由项表
            //--DataTable fchrFreeTable = tablelist[1];
            DataRow row = gridTable.NewRow();
            try {
                for (int i = 0; i < gridTable.Columns.Count; i++) {
                    for (int j = 0; j < itemTable.Columns.Count; j++) {
                        if (gridTable.Columns[gridTable.Columns[i].ColumnName].ToString().Trim().ToUpper()
                            == itemTable.Columns[itemTable.Columns[j].ColumnName].ToString().Trim().ToUpper()) {
                            row[i] = itemTable.Rows[0][j];
                        }
                    }
                }
                row["flotQuantity"] = 1;
                //修改总数量和总金额
                string quantity = row["flotQuantity"].ToString();
                string lblFlotQuantity = (HandleEvent.FindControl("lblFlotQuantity", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue;
                if (quantity == "") {
                    quantity = "0";
                }
                if (lblFlotQuantity == "") {
                    lblFlotQuantity = "0";
                }
                float totalQuantity = float.Parse(quantity) + float.Parse(lblFlotQuantity);


                double lblMoney = Tools.GetDblColumnValue((HandleEvent.FindControl("lblMoney", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue);

                double flotmoney = 1 * Tools.GetDblColumnValue(row["flotQuotePrice"]);
                double totalmoney = flotmoney + lblMoney;

                row["flotmoney"] = flotmoney;
                string errInfo = "";
                if (!objCheckUtility.IsFreeCheck(row, barCode.Trim(), freeFieldList, freeFieldName, ref errInfo)) {
                    AddErrorBarCode(barCode.Trim(), errInfo);
                    return;//自由项判断
                }
                //检查实盘商品范围
                string strErrorMessage = string.Empty;
                if (!CheckInputItemRange(fchrCheckSetoutCode, row, out strErrorMessage)) {
                    AddErrorBarCode(barCode.Trim(), strErrorMessage);
                    txtBarCode.Clear();
                    return;
                }
                //gridTable.Rows.Add(row);
                //黄色小鸭chb2009-10-30
                (HandleEvent.FindControl("lblFlotQuantity", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue = totalQuantity.ToString();
                (HandleEvent.FindControl("lblMoney", this.HandleEvent.InitFormClass.MainForm) as ExNoBorderLabel).ControlValue = totalmoney.ToString(SysPara.FormatMoney());

                int intCount = 0;

                //gridTable = objCheckUtility.UniteItem(gridTable, row, ref intCount, barCode);//合并商品行 
                gridTable.Rows.Add(row);
                //---结束

                txtBarCode.Clear();
                HandleEvent.FilterEmptyRows(DataGrid);
                if (!HandleEvent.HasEmptyRow(this.DataGrid, gridTable)) {
                    gridTable.Rows.Add(gridTable.NewRow());
                }
                //黄色小鸭chb2009-10-30
                ExDataGrid objExGrid = this.DataGrid as ExDataGrid;
                //效率优化
                //for (int j = 0; j < objCheckUtility.GetDataGridCount(gridTable); j++)
                //{
                //    objExGrid.UnSelect(j);
                //}
                //objExGrid.Select(0);
                //objExGrid.CurrentRowIndex = 0;
                //DataGrid.UnSelect(0);

                objExGrid.UnSelectAll();

                objExGrid.Select(intCount);
                objExGrid.CurrentRowIndex = intCount;
                //--结束
                gridTable.Dispose();
            } catch (Exception ex) {
                Logger.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 添加错误的条码
        /// </summary>
        /// <param name="barCode"></param>
        public void AddErrorBarCode(string barCode, string errorMessage) {

            this.txtBarCode.Clear();
            if (this.dgvErrorBarCode.DataSource != null) {
                this.dgvErrorBarCode.DataSource = null;
            }
            this.dgvErrorBarCode.Rows.Add();
            this.dgvErrorBarCode.Rows[this.dgvErrorBarCode.Rows.Count - 1].Cells[0].Value = errorNo.ToString();
            errorNo++;
            this.dgvErrorBarCode.Rows[this.dgvErrorBarCode.Rows.Count - 1].Cells[1].Value = barCode;
            this.dgvErrorBarCode.Rows[this.dgvErrorBarCode.Rows.Count - 1].Cells[2].Value = errorMessage;
            if (this.dgvErrorBarCode.Rows.Count > 8) {
                return;
            }
            if (isFirstAddHeight) {
                this.Height += 50;
                isFirstAddHeight = false;
            } else {
                this.Height += 25;
            }
            //MessageBox.Show("商品条码【" + barCode + "】" + errorMessage, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 判断自由项是否启动
        /// </summary>
        /// <param name="fcrhItemID"></param>
        /// <returns></returns>
        private List<string> JudgeFbitFreeIsStartup(string fcrhItemID, string barcode) {
            List<string> startUpList = new List<string>();
            string sqlText = string.Format("SELECT fbitFree1,fbitFree2,fbitFree3,fbitFree4,fbitFree5,fbitFree6,fbitFree7,fbitFree8,fbitFree9,fbitFree10 FROM Item WHERE fchrItemID='{0}'", fcrhItemID);
            DataTable fbitFreeTable = this.GetDataTable(sqlText, barcode);
            //先判断是否有启动的自由项
            for (int i = 0; i < fbitFreeTable.Columns.Count; i++) {
                try {
                    bool b = Boolean.Parse(fbitFreeTable.Rows[0][i].ToString());
                    if (b) {
                        startUpList.Add(fbitFreeTable.Columns[i].ColumnName.ToString());
                    }
                } catch { }
            }
            return startUpList;
        }
        /// <summary>
        /// 判断自由项是否有空值
        /// </summary>
        /// <param name="fbitTable"></param>
        /// <returns></returns>
        public bool JudgeFbitFreeIsEmpty(DataTable fbitFreeTable, string fcrhItemID) {
            string sqlText = string.Format("SELECT fbitFree1,fbitFree2,fbitFree3,fbitFree4,fbitFree5,fbitFree6,fbitFree7,fbitFree8,fbitFree9,fbitFree10 FROM Item WHERE fchrItemID='{0}'", fcrhItemID);
            DataTable dt = this.GetDataTable(sqlText);
            string fchrFree = string.Empty;
            if (dt.Rows.Count > 0) {
                for (int i = 0; i < dt.Columns.Count; i++) {
                    string columnName = dt.Columns[i].ColumnName;
                    bool fbitFree = Tools.GetBoolColumnValue(dt.Rows[0][columnName]);
                    if (fbitFree) {
                        if (fbitFreeTable.Rows[0]["fchrFree" + (i + 1)].ToString().Equals("")) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 判断自由项是否有空值
        /// </summary>
        public bool JudgeFbitFreeIsEmpty(string fcrhItemID) {
            string sqlText = string.Format("SELECT fbitFree1,fbitFree2,fbitFree3,fbitFree4,fbitFree5,fbitFree6,fbitFree7,fbitFree8,fbitFree9,fbitFree10 FROM Item WHERE fchrItemID='{0}'", fcrhItemID);
            DataTable dt = this.GetDataTable(sqlText);
            string fchrFree = string.Empty;
            if (dt.Rows.Count > 0) {
                for (int i = 0; i < dt.Columns.Count; i++) {
                    string columnName = dt.Columns[i].ColumnName;
                    bool fbitFree = Tools.GetBoolColumnValue(dt.Rows[0][columnName]);
                    if (fbitFree) {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 是否按有效期管理
        /// </summary>
        /// <param name="fchrItemID"></param>
        /// <returns></returns>
        public bool JudgeIsValidDay(string fchrItemID) {
            bool isValidDay = false;
            string sqlText = string.Format("SELECT fbitValidDay FROM Item WHERE fchrItemID='{0}'", fchrItemID);
            DataTable validDayTable = new DataTable();
            validDayTable = this.GetDataTable(sqlText);
            if (validDayTable.Rows.Count > 0) {
                isValidDay = Tools.GetBoolColumnValue(validDayTable.Rows[0][0]);
            }
            return isValidDay;
        }
        /// <summary>
        /// 是否按有效期管理
        /// </summary>
        /// <param name="fchrItemID"></param>
        /// <returns></returns>
        public bool JudgeIsValidDay(string fchrItemID, string barcode) {
            if (!Tools.GetBoolSysPara("ProductManageType"))
                return false;
            bool isValidDay = false;
            string sqlText = string.Format("SELECT fbitValidDay FROM Item WHERE fchrItemID='{0}'", fchrItemID);
            DataTable validDayTable = new DataTable();
            validDayTable = this.GetDataTable(sqlText, barcode);
            if (validDayTable.Rows.Count > 0) {
                if (Boolean.Parse(validDayTable.Rows[0][0].ToString()) == true) {
                    isValidDay = true;
                }
            }
            return isValidDay;
        }

        /// <summary>
        /// 判断有效日期是否为空
        /// </summary>
        /// <param name="fbitTable"></param>
        /// <returns></returns>
        public bool JudgeValidDayIsEmpty(DataTable fbitFreeTable) {
            bool isEmpty = false;
            for (int i = 0; i < fbitFreeTable.Columns.Count; i++) {
                if (fbitFreeTable.Columns[i].ColumnName.ToUpper() == "fdtmproducedate".ToUpper()) {
                    string value = fbitFreeTable.Rows[0][i].ToString();
                    if (value == null || value == string.Empty) {
                        isEmpty = true;
                        break;
                    }
                }
            }
            return isEmpty;
        }

        /// <summary>
        /// 是否按批次管理
        /// </summary>
        /// <param name="fchrItemID"></param>
        /// <returns></returns>
        public bool JudgeIsBatch(string fchrItemID) {
            if (!Tools.GetBoolSysPara("ProductManageType"))
                return false;
            string sqlText = string.Format("SELECT fbitBatch FROM Item WHERE fchrItemID='{0}'", fchrItemID);
            DataTable fbitBatchTable = new DataTable();
            fbitBatchTable = this.GetDataTable(sqlText);
            if (fbitBatchTable.Rows.Count > 0) {
                if (Boolean.Parse(fbitBatchTable.Rows[0][0].ToString()) == true) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断批次是否为空
        /// </summary>
        /// <param name="fbitTable"></param>
        /// <returns></returns>
        public bool JudgeIsBatchEmpty(DataTable fbitTable) {

            if (!fbitTable.Columns.Contains("fchrbatchcode") || fbitTable.Rows[0]["fchrbatchcode"].ToString() == string.Empty) {
                return true;
            }
            return false;
        }

        private List<string> GetFbitFreeList() {
            List<string> list = new List<string>();
            for (int i = 1; i <= 10; i++) {
                list.Add("fchrfree" + i);
            }
            return list;
        }

        /// <summary>
        /// 回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBarCode_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.btnFinsh_Click(sender, null);
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOutTxt_Click(object sender, EventArgs e) {
            if (this.dgvErrorBarCode.Rows.Count == 0) {
                RetailMessageBox.Show("没有错误的条码可导出");
                return;
            }
            this.saveFileDialog1.FileName = "以下条码解析失败";
            this.saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this.saveFileDialog1.ShowDialog(this);
        }

        /// <summary>
        /// 导入txt文本中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e) {
            StreamWriter sw = null;
            try {
                string filePath = saveFileDialog1.FileName;
                sw = new StreamWriter(filePath);
                string head = "编号   以下条码解析失败";
                sw.WriteLine(head);
                string errorNo = string.Empty;
                string errorBarCode = string.Empty;
                string errorMessage = string.Empty;
                string body = string.Empty;
                foreach (DataGridViewRow row in this.dgvErrorBarCode.Rows) {
                    errorNo = row.Cells[0].Value.ToString();
                    errorBarCode = row.Cells[1].Value.ToString().Trim();
                    errorMessage = row.Cells[2].Value.ToString().Trim();
                    body = errorNo + "        " + errorBarCode + "                       " + errorMessage;
                    sw.WriteLine(body);
                }
                sw.Close();
                RetailMessageBox.Show("导出成功", "用友连锁管理系统");
            } catch (Exception ex) {
                Logger.WriteLine(ex.Message);
                RetailMessageBox.ShowError(ex.Message);
            } finally {
                if (sw != null) {
                    sw.Close();
                }
            }
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar.ToString() == " ") {
                e.Handled = true;
            }
        }

        private void frmAddDetail_FormClosing(object sender, FormClosingEventArgs e) {
            HandleEvent.FilterEmptyRows(DataGrid);
        }

        private void frmAddDetail_Load(object sender, EventArgs e) {
            //if (isInOutBill) return;
            //判断外部函数的种类（从实盘单进入或实盘单列表进入）
            //string param = Tools.GetStringAttribute(this.ConfigNode as XmlElement, "param");
            //if (param == "RealCheckDetail") {
            //    this.realCheckType = RealCheckType.RealCheckDetail;
            //} else {
            //    this.realCheckType = RealCheckType.RealCheck;
            //}
        }
        //===============
        private ExternalMethodCallArgs objExternalMethodCall = null;
        public ExternalMethodCallArgs ExternalMethodCall {
            set { objExternalMethodCall = value; }
            get { return objExternalMethodCall; }
        }
        private object objSender = null;
        public object Sender {
            set { objSender = value; }
            get { return objSender; }
        }
        private bool isInOutBill = false;
        public bool IsInOutBill {
            set { isInOutBill = value; }
            get { return isInOutBill; }
        }
        public void InOutCheckBarCode(string barCode,int iQuantity) {
            if (barCode.Trim().Equals("")) return;
            try {
                InOutBarCode objAddInOutDetail = new InOutBarCode();
                objAddInOutDetail.ExternalMethodCall = this.ExternalMethodCall;
                objAddInOutDetail.AddDetail = this;
                objAddInOutDetail.Sender = Sender;
                objAddInOutDetail.BarCodeQuery(barCode,iQuantity);
            } catch (Exception ex) {
                Logger.WriteLine(ex.Message);
                txtBarCode.Text = "";
                txtBarCode.Select();
            }
        }
        /// <summary>
        ///黄色小鸭补丁 商品是否被禁用
        /// </summary>
        public bool IsNoUsedItem(string fchrItemID) {
            bool returnValue = false;
            if (fchrItemID != "") {
                string strCmd = string.Format("select 1 from Item where fchrItemID='{0}' and IsNull(fbitNoUsed,0)=0", fchrItemID);

                DataTable dt = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, strCmd);
                if (dt == null || dt.Rows.Count == 0) {
                    returnValue = true;
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 第三代条码转换 by ljx
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        private string BarCodeConvert(string barCode) { 
            if (barCode.Contains(" ")) {
                string cinvccode = barCode.Substring(0, 1).Replace("0", "A").Replace("1", "B");
                string cFree1 = barCode.Substring(barCode.LastIndexOf(" ") + 1);
                if (cFree1 == "0") {
                    cFree1 = "Z";
                }
                string ml = barCode.Substring(barCode.IndexOf(" ") + 1);
                ml = ml.Substring(0, ml.IndexOf(" "));

                string bx = barCode.Substring(0, barCode.IndexOf(" "));//.Substring(0, 1).Replace("0", "").Replace("1", "");
                if (bx.Substring(0, 1) == "0" || bx.Substring(0, 1) == "1") {
                    bx = bx.Substring(1);
                }

                string sqlCmd = string.Format("SELECT Isnull(fchrBarCodeNo,'') FROM BarCodeRuleCollateDetail WHERE fchrItemID =(SELECT fchrItemID FROM ItemAllotAnalysis WHERE fchrFieldName='fchrFree1' AND fchrValue='{0}' AND fchrItemID =  (SELECT  fchrItemID FROM item WHERE fchrItemCDef7='{1}' and fchrItemCDef6=(SELECT cValue FROM U8UserDefine ud WHERE ud.cID=54 AND ud.cAlias='{2}' )AND fchrItemTypeID IN(SELECT fchrItemTypeID FROM ItemType it WHERE it.fchrItemType like '{3}%' )))  AND fchrFree1='{0}'"
                 , cFree1, ml, bx, cinvccode);

                object obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sqlCmd);
               return Convert.ToString(obj);
            }
            return barCode;
        }
        private void btnImport_Click(object sender, EventArgs e) {
            if (!File.Exists(this.txtBarCode.Text)) {
                MessageBox.Show("文件不存在!");
                return;
            }
            try {
                using (StreamReader reader = new StreamReader(this.txtBarCode.Text, Encoding.Default)) {
                    for (string str = reader.ReadLine(); str != null; str = reader.ReadLine()) {
                        string barCode = str.Split(new char[] { ',' })[4].Trim();
                        barCode=BarCodeConvert(barCode);
                         
                        int iQuantity =string.IsNullOrEmpty( str.Split(new char[] { ',' })[5].Trim())?0:Convert.ToInt32( str.Split(new char[] { ',' })[5].Trim());
                        new InOutBarCode { ExternalMethodCall = this.ExternalMethodCall, AddDetail = this, Sender = this.Sender }.BarCodeQuery(barCode, iQuantity);
                    }
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = "文本文件|*.txt"
            };
            if (dialog.ShowDialog() == DialogResult.OK) {
                this.txtBarCode.Text = dialog.FileName;
            }
        }
    }

    public enum RealCheckType {
        /// <summary>
        /// 实盘单
        /// </summary>
        RealCheck,
        /// <summary>
        /// 实盘单列表
        /// </summary>
        RealCheckDetail
    }

    public class ErrorMessage {
        /// <summary>
        /// 条码错误
        /// </summary>
        public const string ErrorBarCode = "条码错误";
        /// <summary>
        /// 自由项值不全
        /// </summary>
        public const string ErrorFchrFree = "自由项值不全";
        /// <summary>
        /// 没有启动自由项
        /// </summary>
        public const string NoFchrFree = "没有启动自由项";
        /// <summary>
        /// 批次没有录入
        /// </summary>
        public const string ErrorBach = "批次没有录入";
    }
}