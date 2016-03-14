using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using UFIDA.Retail.Utility;
using UFIDA.Retail.Common;
using UFIDA.Retail.Barcode;
using System.Collections;
using System.Xml;
using UFIDA.Retail.Business.Common;

namespace UFIDA.Retail.VIPCardControl
{
    public partial class frmScanBarCode : Form
    {
        private C1.Win.C1FlexGrid.C1FlexGrid _dgvSource;

        public C1.Win.C1FlexGrid.C1FlexGrid DgvSource
        {
            get { return _dgvSource; }
            set { _dgvSource = value; }
        }

        private ArrayList freeFieldList = new ArrayList();
        public ArrayList FreeFieldList
        {
            set { freeFieldList = value; }
            get { return freeFieldList; }
        }
        private Hashtable freeFieldName = new Hashtable();
        public Hashtable FreeFieldName
        {
            set { freeFieldName = value; }
            get { return freeFieldName; }
        }

        private string _vouchtype;

        public string Vouchtype
        {
            get { return _vouchtype; }
            set { _vouchtype = value; }
        }

        public frmScanBarCode(C1.Win.C1FlexGrid.C1FlexGrid dgv,string cVouchType)
        {
            _dgvSource = dgv;
            _vouchtype = cVouchType;
            SetFreeNameOrField();
            InitializeComponent();
        }

        private void SetFreeNameOrField()
        {
            string strSql = "select fchrFieldName,fchrItemName from UserDefine";
            DataTable objTable = SqlAccess.ExecuteDataset(SysPara.ConnectionString, CommandType.Text, strSql).Tables[0];
            string freeField = "", freeValue = "", fchrItemName;
            for (int i = 0; i < objTable.Rows.Count; i++)
            {
                freeField = Tools.GetStringColumnValue(objTable.Rows[i]["fchrFieldName"]).ToLower();
                fchrItemName = Tools.GetStringColumnValue(objTable.Rows[i]["fchrItemName"]);
                freeFieldList.Add(freeField);
                freeFieldName.Add(freeField, fchrItemName);
            }
        }

        /// <summary>
        /// 是否第一次添加窗体高度
        /// </summary>
        private bool isFirstAddHeight = true;
        /// <summary>
        /// 错误编号
        /// </summary>
        private int errorNo = 1;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dgvErrorBarCode.Rows.Count == 0)
            {
                RetailMessageBox.Show("没有错误的条码可导出");
                return;
            }
            this.saveFileDialog1.FileName = "以下条码解析失败";
            this.saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this.saveFileDialog1.ShowDialog(this);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.txtBarCode.Text))
            {
                MessageBox.Show("文件不存在!");
                return;
            }

            try
            {
                using (StreamReader reader = new StreamReader(this.txtBarCode.Text, Encoding.Default))
                {
                    for (string str = reader.ReadLine(); str != null && !string.IsNullOrEmpty(str); str = reader.ReadLine())
                    {
                        string barCode = str.Split(new char[] { ',' })[4].Trim();
                        barCode = BarCodeConvert(barCode);

                        int iQuantity = string.IsNullOrEmpty(str.Split(new char[] { ',' })[5].Trim()) ? 0 : Convert.ToInt32(str.Split(new char[] { ',' })[5].Trim());
                        this.BarCodeQuery(barCode, iQuantity);  
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            string barCode = BarCodeConvert(txtBarCode.Text);
            InOutCheckBarCode(barCode, 1);
        }

        /// <summary>
        /// 第三代条码转换 by ljx
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        private string BarCodeConvert(string barCode)
        {
            if (barCode.Contains(" "))
            {
                string cinvccode = barCode.Substring(0, 1).Replace("0", "A").Replace("1", "B");
                string cFree1 = barCode.Substring(barCode.LastIndexOf(" ") + 1);
                if (cFree1 == "0")
                {
                    cFree1 = "Z";
                }
                string ml = barCode.Substring(barCode.IndexOf(" ") + 1);
                ml = ml.Substring(0, ml.IndexOf(" "));

                string bx = barCode.Substring(0, barCode.IndexOf(" "));//.Substring(0, 1).Replace("0", "").Replace("1", "");
                if (bx.Substring(0, 1) == "0" || bx.Substring(0, 1) == "1")
                {
                    bx = bx.Substring(1);
                }

                string sqlCmd = string.Format("SELECT Isnull(fchrBarCodeNo,'') FROM BarCodeRuleCollateDetail WHERE fchrItemID =(SELECT fchrItemID FROM ItemAllotAnalysis WHERE fchrFieldName='fchrFree1' AND fchrValue='{0}' AND fchrItemID =  (SELECT  fchrItemID FROM item WHERE fchrItemCDef7='{1}' and fchrItemCDef6=(SELECT cValue FROM U8UserDefine ud WHERE ud.cID=54 AND ud.cAlias='{2}' )AND fchrItemTypeID IN(SELECT fchrItemTypeID FROM ItemType it WHERE it.fchrItemType like '{3}%' )))  AND fchrFree1='{0}'"
                 , cFree1, ml, bx, cinvccode);

                object obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, sqlCmd);
                return Convert.ToString(obj);
            }
            return barCode;
        }

        public void BarCodeQuery(string barCode, int iQuantity)
        {
            string errInfo = "";
            bool returnValue = StandardBarCode(barCode, iQuantity, ref errInfo);
            //if (returnValue)
            //{
            //    int sumNum = 0;
            //    //DataTable detailTable = 
            //    foreach (DataRow row in detailTable.Rows)
            //    {
            //        sumNum += Convert.ToInt32(row["flotQuantity"]);
            //        // sumNum += iQuantity; //Convert.ToInt32(row["flotQuantity"]);
            //        sumNum2 += Convert.ToInt32(row["flotQuotePrice"]) * iQuantity;
            //    }
            //    return;
            //}
            //rchivesBarCode(barCode, errInfo);
        }

        public void InOutCheckBarCode(string barCode, int iQuantity)
        {
            if (barCode.Trim().Equals("")) return;
            try
            {
                this.BarCodeQuery(barCode, iQuantity);
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                txtBarCode.Text = "";
                txtBarCode.Select();
            }
        }


        /// <summary>
        ///黄色小鸭补丁 商品是否被禁用
        /// </summary>
        public bool IsNoUsedItem(string fchrItemID)
        {
            bool returnValue = false;
            if (fchrItemID != "")
            {
                string strCmd = string.Format("select 1 from Item where fchrItemID='{0}' and IsNull(fbitNoUsed,0)=0", fchrItemID);

                DataTable dt = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, strCmd);
                if (dt == null || dt.Rows.Count == 0)
                {
                    returnValue = true;
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 添加错误的条码
        /// </summary>
        /// <param name="barCode"></param>
        public void AddErrorBarCode(string barCode, string errorMessage)
        {

            this.txtBarCode.Clear();
            if (this.dgvErrorBarCode.DataSource != null)
            {
                this.dgvErrorBarCode.DataSource = null;
            }
            this.dgvErrorBarCode.Rows.Add();
            this.dgvErrorBarCode.Rows[this.dgvErrorBarCode.Rows.Count - 1].Cells[0].Value = errorNo.ToString();
            errorNo++;
            this.dgvErrorBarCode.Rows[this.dgvErrorBarCode.Rows.Count - 1].Cells[1].Value = barCode;
            this.dgvErrorBarCode.Rows[this.dgvErrorBarCode.Rows.Count - 1].Cells[2].Value = errorMessage;
            if (this.dgvErrorBarCode.Rows.Count > 8)
            {
                return;
            }
            if (isFirstAddHeight)
            {
                this.Height += 50;
                isFirstAddHeight = false;
            }
            else
            {
                this.Height += 25;
            }
            //MessageBox.Show("商品条码【" + barCode + "】" + errorMessage, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 匹配列表项
        /// liwenzhen2008.10.30
        /// </summary>
        /// <param name="filePath">xml文件路径</param>
        /// <param name="fchrItemTable">数据表</param>
        /// <returns></returns>
        public DataTable MatchColumn(string filePath, DataTable fchrItemTable)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNodeList nodeList = doc.GetElementsByTagName("Col");
            foreach (XmlNode node in nodeList)
            {
                fchrItemTable.Columns[node.Attributes["AssignValue"].Value].ColumnName = node.Attributes["Caption"].Value;
            }
            return fchrItemTable;
        }

        /// <summary>
        /// 邦定DataGrid
        /// </summary>
        /// <param name="tablelist">[0]:商品表[1]:自由项表</param>
        private bool BindGrid(List<DataTable> tablelist, string barCode, ArrayList freeFieldList, Hashtable freeFieldName, ref string errInfo)
        {
            bool flag6;
            errInfo = "";
            CheckUtility utility = new CheckUtility();
            sl_RetailCommom RetailCommom = new sl_RetailCommom();
            //Form form = ExternalMethodCall.HandleEvent.InitFormClass.MainForm;
            DataTable detailTable = RetailCommom.GetDetailTable(_dgvSource);
            //utility.MainFrom = this.ExternalMethodCall.HandleEvent.GetDataGrid().FindForm();
            DataTable table2 = tablelist[0];
            DataTable table3 = detailTable;
            DataTable objTable = tablelist[1];
            DataRow objRow = null;
            string fchrItemCode = Convert.ToString(table2.Rows[0]["fchritemcode"]);
            string cFree1 = Convert.ToString(objTable.Rows[0]["fchrFree1"]);
            bool flag = false;
            try
            {
                int num2;
                DataRow[] rowArray = detailTable.Select(string.Format("fchritemcode='{0}' and fchrFree1='{1}'", fchrItemCode, cFree1));

                if (rowArray.Length > 0)
                {
                    flag = false;
                    objRow = rowArray[0];
                }
                else
                {
                    flag = true;
                    objRow = table3.NewRow();
                }
                int num = 0;
                while (num < table3.Columns.Count)
                {
                    if (table3.Columns[num].ColumnName.Trim().ToLower() != "flotquantity")
                    {
                        num2 = 0;
                        while (num2 < table2.Columns.Count)
                        {
                            if (table3.Columns[table3.Columns[num].ColumnName].ToString().Trim().ToUpper() == table2.Columns[table2.Columns[num2].ColumnName].ToString().Trim().ToUpper())
                            {
                                objRow[num] = table2.Rows[0][num2];
                            }
                            num2++;
                        }
                    }
                    num++;
                }
                for (num = 0; num < table3.Columns.Count; num++)
                {
                    if (table3.Columns[num].ColumnName.Trim().ToLower() != "flotquantity")
                    {
                        for (num2 = 0; num2 < objTable.Columns.Count; num2++)
                        {
                            if (table3.Columns[table3.Columns[num].ColumnName].ToString().Trim().ToUpper() == objTable.Columns[objTable.Columns[num2].ColumnName].ToString().Trim().ToUpper())
                            {
                                objRow[num] = objTable.Rows[0][num2];
                            }
                        }
                    }
                }
                double dblColumnValue = 0.0;

                //获取商品ID
                if (objRow.Table.Columns.Contains("fchrItemID"))
                {
                    objRow["fchrItemID"] = table2.Rows[0]["存货Id"].ToString();
                }

                if (table2.Columns.Contains("flotQuantity") && objRow.Table.Columns.Contains("flotQuantity"))
                {
                    if (flag)
                    {
                        objRow["flotQuantity"] = Convert.ToInt32(table2.Rows[0]["flotQuantity"]);
                    }
                    else
                    {
                        objRow["flotQuantity"] = (string.IsNullOrEmpty(objRow["flotQuantity"].ToString()) ? 0 : Convert.ToInt32(objRow["flotQuantity"])) + (string.IsNullOrEmpty(table2.Rows[0]["flotQuantity"].ToString()) ? 0 : Convert.ToInt32(table2.Rows[0]["flotQuantity"]));
                    }
                }
                if (objRow.Table.Columns.Contains("库存量") && Convert.IsDBNull(table2.Rows[0]["库存量"]))
                {
                    objRow["库存量"] = "0";
                }
                if (table2.Columns.Contains("零售价"))
                {
                    //if (objRow.Table.Columns.Contains("flotQuotePrice"))
                    //{
                    //    objRow["flotQuotePrice"] = Convert.ToInt32(objRow["flotQuantity"]) * Convert.ToDouble(table2.Rows[0]["零售价"]);
                    //}
                    dblColumnValue = Tools.GetDblColumnValue(table2.Rows[0]["零售价"]);
                }
                if (table2.Columns.Contains("fchritemname") && objRow.Table.Columns.Contains("条码名称"))
                {
                    objRow["条码名称"] = table2.Rows[0]["fchritemname"];
                }
                if (objRow.Table.Columns.Contains("条码"))
                {
                    objRow["条码"] = barCode;
                }
                //objRow["flotmoney"] = Convert.ToInt32(objRow["flotQuantity"]) * Convert.ToDouble(table2.Rows[0]["零售价"]);
                string fchrItemID = objRow["fchrItemID"].ToString();
                if (!utility.IsFreeCheck(objRow, barCode.Trim(), freeFieldList, freeFieldName, ref errInfo))
                {
                    return false;
                }
                int index = 0;
                if (objRow.Table.Columns.Contains("fbitFree") && objRow.Table.Columns.Contains("fchrItemID"))
                {
                    objRow["fbitFree"] = this.GetFreeByItemID(fchrItemID);
                    if (Tools.GetBoolColumnValue(objRow["fbitFree"]) && objRow.Table.Columns.Contains("FreeItemXML1"))
                    {
                        objRow["FreeItemXML1"] = this.GetFreeXML(objTable);
                    }
                }
                if (this.JudgeIsBatch(fchrItemID) && this.JudgeIsBatchEmpty(objTable))
                {
                    errInfo = "条码带不出批次和效期";
                    this.txtBarCode.Text = "";
                    this.txtBarCode.Select();
                    return false;
                }
                if (this.JudgeIsValidDay(fchrItemID) && this.JudgeValidDayIsEmpty(objTable))
                {
                    errInfo = "条码带不出批次和效期";
                    this.txtBarCode.Text = "";
                    this.txtBarCode.Select();
                    return false;
                }
                //string positionID = this.GetPositionID(Tools.GetStringColumnValue(objRow["fchrItemID"]));
                //if (string.IsNullOrEmpty(positionID))
                //{
                //    objRow["fchrPosID"] = DBNull.Value;
                //}
                //else
                //{
                //    objRow["fchrPosID"] = positionID;
                //}
                //string positionName = this.GetPositionName(Tools.GetStringColumnValue(objRow["fchrItemID"]));
                //objRow["fchrPosName"] = positionName;
                this.SetRowUseQuantity(objRow);
                if (rowArray.Length <= 0)
                {
                    table3.Rows.Add(objRow);
                }

                if (objRow != null)
                {
                    RetailCommom.AddScanDataRow(_dgvSource, objRow);
                    //_dgvSource.AutoSizeCols();
                    RetailCommom.AutoSizeDgvCols(_dgvSource, _vouchtype);
                }
                //index = table3.Rows.IndexOf(objRow);
                //DataGrid dataGrid = this.ExternalMethodCall.HandleEvent.GetDataGrid();
                //(dataGrid as ExDataGrid).UnSelectAll();
                //dataGrid.Select(index);
                //_dgvSource.RowSel = index;
                table3.Dispose();
                flag6 = true;
            }
            catch (Exception exception)
            {
                Logger.WriteLine(exception.Message);
                throw new Exception(exception.Message);
            }
            return flag6;
        }

        /// <summary>
        /// 利用数据表中的记录生成自由项字符串。
        /// </summary>
        /// <param name="objTable"></param>
        /// <returns></returns>
        private string GetFreeXML(DataTable objTable)
        {
            StringBuilder objFree = new StringBuilder();
            objFree.Append("<Root number='1'>");
            objFree.Append("<Item ");
            for (int i = 1; i <= 10; i++)
            {
                string fchrFreeName = "fchrFree" + i.ToString();
                if (objTable.Columns.Contains(fchrFreeName))
                {
                    if (!objTable.Rows[0][fchrFreeName].ToString().Equals(""))
                    {
                        objFree.AppendFormat(" {0}='{1}' ", fchrFreeName, objTable.Rows[0][fchrFreeName].ToString());
                    }
                }
            }
            objFree.Append(" Index='-1' />");
            objFree.Append("</Root>");
            return objFree.ToString();
        }

        /// <summary>
        /// 利用存货ID取得fbitFree.tinyint
        /// </summary>
        /// <param name="fchrItemID"></param>
        /// <returns></returns>
        private bool GetFreeByItemID(string fchrItemID)
        {
            bool returnValue = false;
            try
            {
                StringBuilder objSql = new StringBuilder();
                objSql.Append("select Top 1 Cast(( (Cast(fbitFree1 as tinyint)+ Cast(fbitFree2 as tinyint) + ");
                objSql.Append(" Cast(fbitFree3 as tinyint)+ Cast(fbitFree4 as tinyint)+ ");
                objSql.Append("Cast(fbitFree5 as tinyint)+ Cast(fbitFree6 as tinyint)+");
                objSql.Append("Cast(fbitFree7 as tinyint)+ Cast(fbitFree8 as tinyint)+ ");
                objSql.Append("Cast(fbitFree9 as tinyint)+ Cast(fbitFree10 as tinyint))) AS bit)  AS fbitFree From Item Where ");
                objSql.AppendFormat(" fchrItemID ='{0}' ", fchrItemID);
                object obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, objSql.ToString());
                returnValue = Tools.GetBoolColumnValue(obj);
            }
            catch (Exception e)
            {
                Logger.Write(e.Message);
            }
            return returnValue;
        }

        /// <summary>
        /// 根据商品取相应货位ID
        /// </summary>
        /// <param name="fchrItemID">商品ID</param>
        //private string GetPositionID(string fchrItemID)
        //{
        //    string strVouchType = Tools.GetStringAttribute(this.ConfigNode as System.Xml.XmlElement, "vouchType");
        //    if (strVouchType == "InVouch")
        //    {
        //        StringBuilder objSql = new StringBuilder();
        //        objSql.AppendFormat("select dbo.f_GetPosID('{0}')", fchrItemID);
        //        object obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, objSql.ToString());
        //        return Tools.GetStringColumnValue(obj);
        //    }
        //    else if (strVouchType == "OutVouch")
        //    {
        //        StringBuilder objSql = new StringBuilder();
        //        objSql.AppendFormat("select dbo.f_GetOutPosID('{0}')", fchrItemID);
        //        object obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, objSql.ToString());
        //        return Tools.GetStringColumnValue(obj);
        //    }
        //    else
        //    {
        //        return "";
        //    }

        //}

        /// <summary>
        /// 根据商品取相应货位名称
        /// </summary>
        /// <param name="fchrItemID">商品ID</param>
        //private string GetPositionName(string fchrItemID)
        //{
        //    string strVouchType = Tools.GetStringAttribute(AddDetail.ConfigNode as System.Xml.XmlElement, "vouchType");
        //    if (strVouchType == "InVouch")
        //    {
        //        StringBuilder objSql = new StringBuilder();
        //        objSql.AppendFormat("select dbo.f_GetPosName('{0}')", fchrItemID);
        //        object obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, objSql.ToString());
        //        return Tools.GetStringColumnValue(obj);
        //    }
        //    else if (strVouchType == "OutVouch")
        //    {
        //        StringBuilder objSql = new StringBuilder();
        //        objSql.AppendFormat("select dbo.f_GetOutPosName('{0}')", fchrItemID);
        //        object obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, objSql.ToString());
        //        return Tools.GetStringColumnValue(obj);
        //    }
        //    else
        //    {
        //        return "";
        //    }

        //}

        /// <summary>
        /// 是否按批次管理
        /// </summary>
        /// <param name="fchrItemID"></param>
        /// <returns></returns>
        public bool JudgeIsBatch(string fchrItemID)
        {
            if (!Tools.GetBoolSysPara("ProductManageType"))
                return false;
            string sqlText = string.Format("SELECT fbitBatch FROM Item WHERE fchrItemID='{0}'", fchrItemID);
            DataTable fbitBatchTable = new DataTable();
            fbitBatchTable = this.GetDataTable(sqlText);
            if (fbitBatchTable.Rows.Count > 0)
            {
                if (Boolean.Parse(fbitBatchTable.Rows[0][0].ToString()) == true)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获得商品信息
        /// </summary>
        private DataTable GetDataTable(string sqlText, string barcode)
        {
            string connectionString = Tools.GetStringSysPara("SysConn");
            //string commandText = this.GetItemAndFreeSQLTextByBarCodeFromDB(barcode);
            //commandText = sqlText;
            DataTable dt = new DataTable();
            try
            {
                dt = SqlAccess.ExecuteDataTable(connectionString, sqlText);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private DataTable GetDataTable(string sqlText)
        {
            string connectionString = Tools.GetStringSysPara("SysConn");
            string commandText = sqlText;
            DataTable dt = new DataTable();
            try
            {
                dt = SqlAccess.ExecuteDataTable(connectionString, commandText);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 判断批次是否为空
        /// </summary>
        /// <param name="fbitTable"></param>
        /// <returns></returns>
        public bool JudgeIsBatchEmpty(DataTable fbitTable)
        {

            if (!fbitTable.Columns.Contains("fchrbatchcode") || fbitTable.Rows[0]["fchrbatchcode"].ToString() == string.Empty)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否按有效期管理
        /// </summary>
        /// <param name="fchrItemID"></param>
        /// <returns></returns>
        public bool JudgeIsValidDay(string fchrItemID)
        {
            bool isValidDay = false;
            string sqlText = string.Format("SELECT fbitValidDay FROM Item WHERE fchrItemID='{0}'", fchrItemID);
            DataTable validDayTable = new DataTable();
            validDayTable = this.GetDataTable(sqlText);
            if (validDayTable.Rows.Count > 0)
            {
                isValidDay = Tools.GetBoolColumnValue(validDayTable.Rows[0][0]);
            }
            return isValidDay;
        }
        /// <summary>
        /// 是否按有效期管理
        /// </summary>
        /// <param name="fchrItemID"></param>
        /// <returns></returns>
        public bool JudgeIsValidDay(string fchrItemID, string barcode)
        {
            if (!Tools.GetBoolSysPara("ProductManageType"))
                return false;
            bool isValidDay = false;
            string sqlText = string.Format("SELECT fbitValidDay FROM Item WHERE fchrItemID='{0}'", fchrItemID);
            DataTable validDayTable = new DataTable();
            validDayTable = this.GetDataTable(sqlText, barcode);
            if (validDayTable.Rows.Count > 0)
            {
                if (Boolean.Parse(validDayTable.Rows[0][0].ToString()) == true)
                {
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
        public bool JudgeValidDayIsEmpty(DataTable fbitFreeTable)
        {
            bool isEmpty = false;
            for (int i = 0; i < fbitFreeTable.Columns.Count; i++)
            {
                if (fbitFreeTable.Columns[i].ColumnName.ToUpper() == "fdtmproducedate".ToUpper())
                {
                    string value = fbitFreeTable.Rows[0][i].ToString();
                    if (value == null || value == string.Empty)
                    {
                        isEmpty = true;
                        break;
                    }
                }
            }
            return isEmpty;
        }

        /// <summary>
        /// 取得商品的可用量
        /// </summary>
        /// <param name="dr"></param>
        public void SetRowUseQuantity(DataRow dr)
        {
            if (dr == null)
                return;

            if (!dr.Table.Columns.Contains("flotUseQuantity"))
                return;

            StringBuilder objWhere = new StringBuilder();
            string fchrItemID = Tools.GetStringColumnValue(dr["fchrItemID"]);
            string fchrFreeValue = "";
            if (string.IsNullOrEmpty(fchrItemID))
                return;

            for (int j = 1; j <= 2; j++)  //modify by pj 20140115 由于胜龙只启用了两个自由项 
            {
                fchrFreeValue = Tools.GetStringColumnValue(dr["fchrFree" + j]);
                if (!fchrFreeValue.Equals(""))
                {
                    objWhere.Append(" And");
                    objWhere.AppendFormat(" fchrFree{0}='{1}' ", j.ToString(), fchrFreeValue.Replace("'", ""));
                }
            }

            //包含批号
            if (dr.Table.Columns.Contains("fchrBatchCode"))
            {
                objWhere.AppendFormat(" And IsNull(fchrBatchCode,'')='{0}' ", Tools.GetStringColumnValue(dr["fchrBatchCode"]));
            }
            //包含货位
            if (dr.Table.Columns.Contains("fchrPosID"))
            {
                if (string.IsNullOrEmpty(Tools.GetStringColumnValue(dr["fchrPosID"])))
                {
                    objWhere.Append(" AND fchrPosID IS NULL ");
                }
                else
                {
                    objWhere.AppendFormat(" AND fchrPosID ='{0}' ", dr["fchrPosID"]);
                }
            }
            //包含生成日期
            if (dr.Table.Columns.Contains("fdtmProduceDate"))
            {
                if (string.IsNullOrEmpty(Tools.GetStringColumnValue(dr["fdtmProduceDate"])))
                {
                    objWhere.Append(" AND ISNULL(fdtmProduceDate ,'')='' ");
                }
                else
                {
                    objWhere.AppendFormat(" AND IsNull(convert(varchar(10),fdtmProduceDate,121) ,'')=convert(varchar(10),cast ('{0}' as datetime),121) ", dr["fdtmProduceDate"]);
                }
            }

            dr["flotUseQuantity"] = BusinessHelper.GetUseQuantity(fchrItemID, objWhere.ToString());
        }

        /// <summary>
        /// 标准条形码
        /// </summary>
        private bool StandardBarCode(string barCode, int iQuantity, ref string errInfo)
        {            
            Parser parser = new Parser();
            parser.ConnectString = SysPara.ConnectionString;
            DataSet ds = new DataSet();
            bool returnValue = false;
            //条码扫描不处理联营商品.V891一期补丁
            parser.ParentCondition = "ftinItemModel=1";

            //解析条码
            parser.DoParse(barCode.Trim(), out ds, out errInfo);
            if ((errInfo == null || errInfo == "") && ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                returnValue = true;
                DataTable objTBarCode = new DataTable();
                objTBarCode = ds.Tables[0];

                foreach (DataRow row in objTBarCode.Rows)
                { //修改数量。数量来源于导入的最后一栏
                    row["flotQuantity"] = iQuantity;
                }

                string fchrItemID = objTBarCode.Rows[0]["存货id"].ToString();
                //检查商品是否已停用
                if (this.IsNoUsedItem(fchrItemID))
                {
                    //条码扫描错误提示音
                    Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

                    this.AddErrorBarCode(barCode.Trim(), "商品已被停用");
                    this.txtBarCode.Text = "";
                    this.txtBarCode.Select();
                    return false;
                }
                DataTable fbitFreeTable = new DataTable();
                if (ds.Tables.Count > 1)
                {
                    fbitFreeTable = ds.Tables[1];
                    foreach (DataRow row in fbitFreeTable.Rows)
                    { //修改数量。数量来源于导入的最后一栏
                        row["flotQuantity"] = iQuantity;
                    }
                }

                List<DataTable> resultTableList = new List<DataTable>();
                resultTableList.Add(objTBarCode);
                resultTableList.Add(fbitFreeTable);
                if (!BindGrid(resultTableList, barCode, this.FreeFieldList, this.FreeFieldName, ref errInfo))
                {
                    this.AddErrorBarCode(barCode.Trim(), errInfo);
                }
                this.txtBarCode.Text = "";
                this.txtBarCode.Focus();

                //条码扫描正确提示音
                Console.Beep(ApplicationConstraints.RIGHT_FRNQUENCY, ApplicationConstraints.RIGHT_DURATION);
            }
            else
            {
                this.AddErrorBarCode(barCode.Trim(), errInfo);
            }
            return returnValue;
        }

        ///// <summary>
        ///// 档案条形码
        ///// </summary>
        //private bool ArchivesBarCode(string barCode, string errInfo)
        //{
        //    DataTable itemTable = new DataTable();
        //    try
        //    {
        //        itemTable = GetArchivesBarCodeData(barCode);
        //    }
        //    catch
        //    {
        //        //条码扫描错误提示音
        //        Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

        //        objAddDetail.AddErrorBarCode(barCode.Trim(), errInfo);
        //        objAddDetail.txtBarCode.Text = "";
        //        objAddDetail.txtBarCode.Select();
        //        return false;
        //    }
        //    if (itemTable.Rows.Count == 0)
        //    {
        //        //条码扫描错误提示音
        //        Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

        //        objAddDetail.AddErrorBarCode(barCode.Trim(), "没有符合条件的商品或条码规则没有启用。");
        //        objAddDetail.txtBarCode.Text = "";
        //        objAddDetail.txtBarCode.Select();
        //        return false;
        //    }
        //    string fchrItemID = itemTable.Rows[0]["fchrItemID"].ToString();
        //    if (objAddDetail.IsNoUsedItem(fchrItemID))
        //    {
        //        //条码扫描错误提示音
        //        Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

        //        objAddDetail.AddErrorBarCode(barCode.Trim(), "商品已被停用");
        //        objAddDetail.txtBarCode.Text = "";
        //        objAddDetail.txtBarCode.Select();
        //        return false;
        //    }
        //    //如果启动检查是否都有值
        //    bool isEmptyFbitFree = objAddDetail.JudgeFbitFreeIsEmpty(fchrItemID);
        //    if (!isEmptyFbitFree)
        //    {
        //        //条码扫描错误提示音
        //        Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

        //        objAddDetail.AddErrorBarCode(barCode.Trim(), "条形码带不出商品自由项");
        //        objAddDetail.txtBarCode.Text = "";
        //        objAddDetail.txtBarCode.Select();
        //        return false;
        //    }
        //    bool isBatch = objAddDetail.JudgeIsBatch(fchrItemID);
        //    if (isBatch)
        //    {
        //        //条码扫描错误提示音
        //        Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

        //        objAddDetail.AddErrorBarCode(barCode.Trim(), "条码带不出批次和效期。");
        //        objAddDetail.txtBarCode.Text = "";
        //        objAddDetail.txtBarCode.Select();
        //        return false;
        //    }
        //    bool isValidDay = objAddDetail.JudgeIsValidDay(fchrItemID);
        //    if (isValidDay)
        //    {
        //        //条码扫描错误提示音
        //        Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

        //        objAddDetail.AddErrorBarCode(barCode.Trim(), "条码带不出批次和效期。");
        //        objAddDetail.txtBarCode.Text = "";
        //        objAddDetail.txtBarCode.Select();
        //        return false;
        //    }
        //    BindGrid(itemTable, barCode);

        //    //条码扫描正确提示音
        //    Console.Beep(ApplicationConstraints.RIGHT_FRNQUENCY, ApplicationConstraints.RIGHT_DURATION);

        //    return true;
        //}

        private void txtBarCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnFinish_Click(sender, null);
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            StreamWriter sw = null;
            try
            {
                string filePath = saveFileDialog1.FileName;
                sw = new StreamWriter(filePath);
                string head = "编号   以下条码解析失败";
                sw.WriteLine(head);
                string errorNo = string.Empty;
                string errorBarCode = string.Empty;
                string errorMessage = string.Empty;
                string body = string.Empty;
                foreach (DataGridViewRow row in this.dgvErrorBarCode.Rows)
                {
                    errorNo = row.Cells[0].Value.ToString();
                    errorBarCode = row.Cells[1].Value.ToString().Trim();
                    errorMessage = row.Cells[2].Value.ToString().Trim();
                    body = errorNo + "        " + errorBarCode + "                       " + errorMessage;
                    sw.WriteLine(body);
                }
                sw.Close();
                RetailMessageBox.Show("导出成功", "用友连锁管理系统");
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                RetailMessageBox.ShowError(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

        private void btnBarCodeFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "文本文件|*.txt"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtBarCode.Text = dialog.FileName;
            }
        }

        private void frmScanBarCode_Load(object sender, EventArgs e)
        {
            this.Height -= (dgvErrorBarCode.Height + 10);
        }
    }
}
