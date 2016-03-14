using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using UFIDA.Retail.Components;
using System.Windows.Forms;
using UFIDA.Retail.Utility;
using System.Collections;
using UFIDA.Retail.Barcode;
using UFIDA.Retail.Common;
using UFIDA.Retail.Business.Common;

namespace UFIDA.Retail.VIPCardControl
{
    public class InOutBarCode
    {
        private frmAddDetail objAddDetail = null;
        public frmAddDetail AddDetail
        {
            set { objAddDetail = value; }
            get { return objAddDetail; }
        }
        private ExternalMethodCallArgs objExternalMethodCall = null;
        public ExternalMethodCallArgs ExternalMethodCall
        {
            set { objExternalMethodCall = value; }
            get { return objExternalMethodCall; }
        }
        private object objSender = null;
        public object Sender
        {
            set { objSender = value; }
            get { return objSender; }
        }
       
        public void BarCodeQuery(string barCode, int iQuantity)
        {
            string errInfo = "";
            bool returnValue = StandardBarCode(barCode,iQuantity, ref errInfo);
            if (returnValue) {
                int sumNum = 0;
                double sumNum2 = 0.0;
                DataTable detailTable = this.ExternalMethodCall.HandleEvent.GetDetailTable();
                Form form = this.ExternalMethodCall.HandleEvent.InitFormClass.MainForm; 
                foreach (DataRow row in detailTable.Rows) {
                    sumNum += Convert.ToInt32(row["flotQuantity"]);
                   // sumNum += iQuantity; //Convert.ToInt32(row["flotQuantity"]);
                    sumNum2 += Convert.ToInt32(row["flotQuotePrice"]) * iQuantity;
                }
                (HandleEvent.FindControl("lblFlotQuantity", form) as ExNoBorderLabel).ControlValue = sumNum.ToString();
                (HandleEvent.FindControl("lblMoney", form) as ExNoBorderLabel).ControlValue = sumNum2.ToString();
                return;
            }
            ArchivesBarCode(barCode, errInfo);
        }
        /// <summary>
        /// �DataGrid
        /// </summary>
        /// <param name="tablelist">[0]:��Ʒ��[1]:�������</param>
        private bool BindGrid(List<DataTable> tablelist, string barCode, ArrayList freeFieldList, Hashtable freeFieldName, ref string errInfo) {
            bool flag6;
            errInfo = "";
            CheckUtility utility = new CheckUtility();
            Form form = ExternalMethodCall.HandleEvent.InitFormClass.MainForm;
            DataTable detailTable = this.ExternalMethodCall.HandleEvent.GetDetailTable();
            utility.MainFrom = this.ExternalMethodCall.HandleEvent.GetDataGrid().FindForm();
            DataTable table2 = tablelist[0];
            DataTable table3 = detailTable;
            DataTable objTable = tablelist[1];
            DataRow objRow = null;
            string str = Convert.ToString(table2.Rows[0]["fchritemcode"]);
            string cFree1 = Convert.ToString(objTable.Rows[0]["fchrFree1"]);
            bool flag = false;
            try {
                int num2;
                DataRow[] rowArray = detailTable.Select(string.Format("fchritemcode='{0}' and fchrFree1='{1}'", str,cFree1));
               
                if (rowArray.Length > 0) {
                    flag = false;
                    objRow = rowArray[0];
                } else {
                    flag = true;
                    objRow = table3.NewRow();
                }
                int num = 0;
                while (num < table3.Columns.Count) {
                    if (table3.Columns[num].ColumnName.Trim().ToLower() != "flotquantity") {
                        num2 = 0;
                        while (num2 < table2.Columns.Count) {
                            if (table3.Columns[table3.Columns[num].ColumnName].ToString().Trim().ToUpper() == table2.Columns[table2.Columns[num2].ColumnName].ToString().Trim().ToUpper()) {
                                objRow[num] = table2.Rows[0][num2];
                            }
                            num2++;
                        }
                    }
                    num++;
                }
                for (num = 0; num < table3.Columns.Count; num++) {
                    if (table3.Columns[num].ColumnName.Trim().ToLower() != "flotquantity") {
                        for (num2 = 0; num2 < objTable.Columns.Count; num2++) {
                            if (table3.Columns[table3.Columns[num].ColumnName].ToString().Trim().ToUpper() == objTable.Columns[objTable.Columns[num2].ColumnName].ToString().Trim().ToUpper()) {
                                objRow[num] = objTable.Rows[0][num2];
                            }
                        }
                    }
                }
                double dblColumnValue = 0.0;
                if (table2.Columns.Contains("flotQuantity") && objRow.Table.Columns.Contains("flotQuantity")) {
                    if (flag) {
                        objRow["flotQuantity"] = Convert.ToInt32(table2.Rows[0]["flotQuantity"]);
                    } else {
                        objRow["flotQuantity"] = Convert.ToInt32(objRow["flotQuantity"]) + Convert.ToInt32(table2.Rows[0]["flotQuantity"]);
                    }
                }
                if (objRow.Table.Columns.Contains("�����") && Convert.IsDBNull(table2.Rows[0]["�����"])) {
                    objRow["�����"] = "0";
                }
                if (table2.Columns.Contains("���ۼ�")) {
                    if (objRow.Table.Columns.Contains("flotQuotePrice")) {
                        objRow["flotQuotePrice"] = Convert.ToInt32(objRow["flotQuantity"]) * Convert.ToDouble(table2.Rows[0]["���ۼ�"]);
                    }
                    dblColumnValue = Tools.GetDblColumnValue(table2.Rows[0]["���ۼ�"]);
                }
                if (table2.Columns.Contains("fchritemname") && objRow.Table.Columns.Contains("��������")) {
                    objRow["��������"] = table2.Rows[0]["fchritemname"];
                }
                if (objRow.Table.Columns.Contains("����")) {
                    objRow["����"] = barCode;
                }
                objRow["flotmoney"] = Convert.ToInt32(objRow["flotQuantity"]) * Convert.ToDouble(table2.Rows[0]["���ۼ�"]);
                string fchrItemID = objRow["fchrItemID"].ToString();
                if (!utility.IsFreeCheck(objRow, barCode.Trim(), freeFieldList, freeFieldName, ref errInfo)) {
                    return false;
                }
                int index = 0;
                if (objRow.Table.Columns.Contains("fbitFree") && objRow.Table.Columns.Contains("fchrItemID")) {
                    objRow["fbitFree"] = this.GetFreeByItemID(fchrItemID);
                    if (Tools.GetBoolColumnValue(objRow["fbitFree"]) && objRow.Table.Columns.Contains("FreeItemXML1")) {
                        objRow["FreeItemXML1"] = this.GetFreeXML(objTable);
                    }
                }
                if (this.objAddDetail.JudgeIsBatch(fchrItemID) && this.objAddDetail.JudgeIsBatchEmpty(objTable)) {
                    errInfo = "������������κ�Ч��";
                    this.objAddDetail.txtBarCode.Text = "";
                    this.objAddDetail.txtBarCode.Select();
                    return false;
                }
                if (this.objAddDetail.JudgeIsValidDay(fchrItemID) && this.objAddDetail.JudgeValidDayIsEmpty(objTable)) {
                    errInfo = "������������κ�Ч��";
                    this.objAddDetail.txtBarCode.Text = "";
                    this.objAddDetail.txtBarCode.Select();
                    return false;
                }
                string positionID = this.GetPositionID(Tools.GetStringColumnValue(objRow["fchrItemID"]));
                if (string.IsNullOrEmpty(positionID)) {
                    objRow["fchrPosID"] = DBNull.Value;
                } else {
                    objRow["fchrPosID"] = positionID;
                }
                string positionName = this.GetPositionName(Tools.GetStringColumnValue(objRow["fchrItemID"]));
                objRow["fchrPosName"] = positionName;
                this.SetRowUseQuantity(objRow);
                if (rowArray.Length <= 0) {
                    table3.Rows.Add(objRow);
                }
                index = table3.Rows.IndexOf(objRow);
                DataGrid dataGrid = this.ExternalMethodCall.HandleEvent.GetDataGrid();
                (dataGrid as ExDataGrid).UnSelectAll();
                dataGrid.Select(index);
                table3.Dispose();
                flag6 = true;
            } catch (Exception exception) {
                Logger.WriteLine(exception.Message);
                throw new Exception(exception.Message);
            }
            return flag6;
        }
        #region 
        //private bool BindGrid(List<DataTable> tablelist, string barCode, ArrayList freeFieldList, Hashtable freeFieldName, ref string errInfo)
        //{
        //    errInfo = "";
        //    CheckUtility objCheckUtility = new CheckUtility();
        //    Form objMainForm = ExternalMethodCall.HandleEvent.InitFormClass.MainForm;
        //    DataTable objTBill = ExternalMethodCall.HandleEvent.GetDetailTable();
        //    objCheckUtility.MainFrom = ExternalMethodCall.HandleEvent.GetDataGrid().FindForm();
        //    //��Ʒ��
        //    DataTable itemTable = tablelist[0];
        //    DataTable gridTable = objTBill;
        //    //�������
        //    DataTable fchrFreeTable = tablelist[1];
        //    DataRow row = gridTable.NewRow();
        //    try
        //    {
        //        for (int i = 0; i < gridTable.Columns.Count; i++)
        //        {
        //            for (int j = 0; j < itemTable.Columns.Count; j++)
        //            {
        //                if (gridTable.Columns[gridTable.Columns[i].ColumnName].ToString().Trim().ToUpper()
        //                    == itemTable.Columns[itemTable.Columns[j].ColumnName].ToString().Trim().ToUpper())
        //                {
        //                    row[i] = itemTable.Rows[0][j];
        //                }
        //            }
        //        }

        //        for (int i = 0; i < gridTable.Columns.Count; i++)
        //        {
        //            for (int j = 0; j < fchrFreeTable.Columns.Count; j++)
        //            {
        //                if (gridTable.Columns[gridTable.Columns[i].ColumnName].ToString().Trim().ToUpper()
        //                    == fchrFreeTable.Columns[fchrFreeTable.Columns[j].ColumnName].ToString().Trim().ToUpper())
        //                {
        //                    row[i] = fchrFreeTable.Rows[0][j];
        //                }
        //            }
        //        }

        //        double flotQuotePrice = 0.0;
        //        if (itemTable.Columns.Contains("flotQuotePrice"))
        //        {
        //            if (row.Table.Columns.Contains("���ۼ�"))
        //            {
        //                row["���ۼ�"] = itemTable.Rows[0]["flotQuotePrice"];
        //            }
        //            flotQuotePrice = Tools.GetDblColumnValue(itemTable.Rows[0]["flotQuotePrice"]);
        //        }
        //        if (row.Table.Columns.Contains("flotOutQuantity"))
        //        {
        //            row["flotOutQuantity"] = 0.0;
        //        }
        //        if (row.Table.Columns.Contains("flotQuantityOut"))
        //        {
        //            row["flotQuantityOut"] = 0.0;
        //        }
        //        if (itemTable.Columns.Contains("���ۼ�"))
        //        {
        //            if (row.Table.Columns.Contains("flotQuotePrice"))
        //            {
        //                row["flotQuotePrice"] = itemTable.Rows[0]["���ۼ�"];
        //            }
        //            flotQuotePrice = Tools.GetDblColumnValue(itemTable.Rows[0]["���ۼ�"]);
        //        }
        //        if (itemTable.Columns.Contains("fchritemname"))
        //        {
        //            if (row.Table.Columns.Contains("��������"))
        //            {
        //                row["��������"] = itemTable.Rows[0]["fchritemname"];
        //            }
        //        }
        //        if (row.Table.Columns.Contains("����"))
        //        {
        //            row["����"] = barCode;
        //        }

        //        //��Ʒ����ȡ�����������õ�������V891һ�ڲ��� 
        //        //row["flotQuantity"] = 1;

        //        //�޸����������ܽ��
        //        string quantity = row["flotQuantity"].ToString();
        //        string lblFlotQuantity = (HandleEvent.FindControl("lblFlotQuantity", objMainForm) as ExNoBorderLabel).ControlValue;
        //        if (quantity == "")
        //        {
        //            quantity = "0";
        //        }
        //        if (lblFlotQuantity == "")
        //        {
        //            lblFlotQuantity = "0";
        //        }
        //        float totalQuantity = float.Parse(quantity) + float.Parse(lblFlotQuantity);

        //        string flotmoney = row["flotmoney"].ToString();
        //        string lblMoney = (HandleEvent.FindControl("lblMoney", objMainForm) as ExNoBorderLabel).ControlValue;

        //        if (flotmoney == "")
        //        {
        //            double flotTempmoney = (Tools.GetDblColumnValue(quantity) * flotQuotePrice);
        //            flotmoney = flotTempmoney.ToString();
        //        }
        //        if (flotmoney.Equals("")) flotmoney = "0";
        //        if (lblMoney == "")
        //        {
        //            lblMoney = "0";
        //        }
        //        float totalmoney = float.Parse(flotmoney) + float.Parse(lblMoney);
        //        row["flotmoney"] = flotmoney;
        //        string fchrItemID = row["fchrItemID"].ToString();
        //        if (!objCheckUtility.IsFreeCheck(row, barCode.Trim(), freeFieldList, freeFieldName, ref errInfo))
        //        {
        //            return false;//�������ж�
        //        }
        //        (HandleEvent.FindControl("lblFlotQuantity", objMainForm) as ExNoBorderLabel).ControlValue = totalQuantity.ToString();
        //        (HandleEvent.FindControl("lblMoney", objMainForm) as ExNoBorderLabel).ControlValue = totalmoney.ToString();
        //        //txtBarCode.Clear();
        //        int index = 0;
        //        //ɨ������ķ�ʽ�ڻ�дGridʱ��ȱ��fbitFree��FreeItemXML1�У��ᵼ���޸��������ڼ�¼ʱ���޷�����Ʒ�������Σ��Դ˷�ʽ��дGrid���е�ֵ��
                
        //        if (row.Table.Columns.Contains("fbitFree")&&row.Table.Columns.Contains("fchrItemID"))
        //        {
        //            row["fbitFree"] = GetFreeByItemID(fchrItemID);
        //            if (Tools.GetBoolColumnValue(row["fbitFree"]) && row.Table.Columns.Contains("FreeItemXML1"))
        //            {
        //                row["FreeItemXML1"] = GetFreeXML(fchrFreeTable);
        //            }
        //        }
        //        bool isBatch = objAddDetail.JudgeIsBatch(fchrItemID);
        //        if (isBatch)
        //        {
        //            bool isBatchEmpty = objAddDetail.JudgeIsBatchEmpty(fchrFreeTable);
        //            if (isBatchEmpty)
        //            {
        //                errInfo = "������������κ�Ч��";
        //                objAddDetail.txtBarCode.Text = "";
        //                objAddDetail.txtBarCode.Select();
        //                return false;
        //            }
        //        }
        //        //�ж��Ƿ���Ч�ڹ��� 
        //        bool isValidDay = objAddDetail.JudgeIsValidDay(fchrItemID);
        //        if (isValidDay)
        //        {
        //            //�ж�Ч���Ƿ�Ϊ��
        //            bool isValidDayEmpty = objAddDetail.JudgeValidDayIsEmpty(fchrFreeTable);
        //            if (isValidDayEmpty)
        //            {
        //                errInfo = "������������κ�Ч��";
        //                objAddDetail.txtBarCode.Text = "";
        //                objAddDetail.txtBarCode.Select();
        //                return false;
        //            }
        //        }

        //        //���û�λֵ��V8.91, libo, 2010-02-01
        //        string strPosID = this.GetPositionID(Tools.GetStringColumnValue(row["fchrItemID"]));
        //        if (string.IsNullOrEmpty(strPosID))
        //        {
        //            row["fchrPosID"] = DBNull.Value;
        //        }
        //        else
        //        {
        //            row["fchrPosID"] = strPosID;
        //        }
        //        string strPosName = this.GetPositionName(Tools.GetStringColumnValue(row["fchrItemID"]));
        //        row["fchrPosName"] = strPosName;

        //        //bool isBatch = objAddDetail.JudgeIsBatch(fchrItemID);
        //        //if (isBatch)
        //        //{
        //        //    errInfo = "������������κ�Ч��";
        //        //    objAddDetail.txtBarCode.Text = "";
        //        //    objAddDetail.txtBarCode.Select();
        //        //    return false;
        //        //}
        //        //bool isValidDay = objAddDetail.JudgeIsValidDay(fchrItemID);
        //        //if (isValidDay)
        //        //{
        //        //    errInfo = "������������κ�Ч��";
        //        //    objAddDetail.txtBarCode.Text = "";
        //        //    objAddDetail.txtBarCode.Select();
        //        //    return false;
        //        //}
        //        //gridTable = objCheckUtility.UniteItem(gridTable, row, ref index, barCode);//�ϲ���Ʒ�� 

        //        //ȡ����Ʒ��Ʒ��������V891���ڲ���
        //        this.SetRowUseQuantity(row);

        //        gridTable.Rows.Add(row);
        //        index = gridTable.Rows.IndexOf(row);
        //        DataGrid objExGrid = ExternalMethodCall.HandleEvent.GetDataGrid();
        //        //Ч���Ż�
        //        //for (int j = 0; j < objCheckUtility.GetDataGridCount(gridTable); j++)
        //        //{
        //        //    objExGrid.UnSelect(j);
        //        //}
        //        //objExGrid.Select(0);
        //        //objExGrid.CurrentRowIndex = 0;
        //        //objExGrid.UnSelect(0);

        //        (objExGrid as ExDataGrid).UnSelectAll();

        //        objExGrid.Select(index);
        //        objExGrid.CurrentRowIndex = index;
        //        gridTable.Dispose();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteLine(ex.Message);
        //        throw new Exception(ex.Message);
        //    }
        //}
        #endregion
        /// <summary>
        /// ��׼������
        /// </summary>
        private bool StandardBarCode(string barCode, int iQuantity, ref string errInfo)
        {
            string templateFilePath = SysPara.GetSysPara("DataPath") + @"\xml\Refer\Ref_ScanBarCodeInOutItem.xml";
            Parser parser = new Parser();
            parser.TemplateID = templateFilePath;
            parser.ConnectString = SysPara.ConnectionString;
            DataSet ds = new DataSet();
            bool returnValue = false;
            //����ɨ�費������Ӫ��Ʒ.V891һ�ڲ���
            parser.ParentCondition = "ftinItemModel=1";

            //��������
            parser.DoParse(barCode.Trim(), out ds, out errInfo);
            if ((errInfo == null || errInfo == "") && ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                returnValue = true;
                DataTable objTBarCode = new DataTable();
                objTBarCode = ds.Tables[0];

                foreach (DataRow row in objTBarCode.Rows) { //�޸�������������Դ�ڵ�������һ��
                    row["flotQuantity"] = iQuantity;
                }

                string fchrItemID = objTBarCode.Rows[0]["���id"].ToString();
                if (objAddDetail.IsNoUsedItem(fchrItemID))
                {
                    //����ɨ�������ʾ��
                    Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

                    objAddDetail.AddErrorBarCode(barCode.Trim(), "��Ʒ�ѱ�ͣ��");
                    objAddDetail.txtBarCode.Text = "";
                    objAddDetail.txtBarCode.Select();
                    return false;
                }
                DataTable fbitFreeTable = new DataTable();
                if (ds.Tables.Count > 1)
                {
                    fbitFreeTable = ds.Tables[1];
                    foreach (DataRow row in fbitFreeTable.Rows) { //�޸�������������Դ�ڵ�������һ��
                        row["flotQuantity"] = iQuantity;
                    }
                }
                //�������������Ӧ��Ӣ������
                objAddDetail.MatchColumn(templateFilePath, objTBarCode);

                List<DataTable> resultTableList = new List<DataTable>();
                resultTableList.Add(objTBarCode);
                resultTableList.Add(fbitFreeTable);
                if (!BindGrid(resultTableList, barCode, objAddDetail.FreeFieldList, objAddDetail.FreeFieldName, ref errInfo))
                {
                    objAddDetail.AddErrorBarCode(barCode.Trim(), errInfo);
                }
                objAddDetail.txtBarCode.Text = "";
                objAddDetail.txtBarCode.Focus();

                //����ɨ����ȷ��ʾ��
                Console.Beep(ApplicationConstraints.RIGHT_FRNQUENCY, ApplicationConstraints.RIGHT_DURATION);
            }
            else
            {

            }
            return returnValue;
        }
        /// <summary>
        /// ����������
        /// </summary>
        private bool ArchivesBarCode(string barCode, string errInfo)
        {
            DataTable itemTable = new DataTable();
            try
            {
                itemTable = GetArchivesBarCodeData(barCode);
            }
            catch
            {
                //����ɨ�������ʾ��
                Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

                objAddDetail.AddErrorBarCode(barCode.Trim(), errInfo);
                objAddDetail.txtBarCode.Text = "";
                objAddDetail.txtBarCode.Select();
                return false;
            }
            if (itemTable.Rows.Count == 0)
            {
                //����ɨ�������ʾ��
                Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

                objAddDetail.AddErrorBarCode(barCode.Trim(), "û�з�����������Ʒ���������û�����á�");
                objAddDetail.txtBarCode.Text = "";
                objAddDetail.txtBarCode.Select();
                return false;
            }
            string fchrItemID = itemTable.Rows[0]["fchrItemID"].ToString();
            if (objAddDetail.IsNoUsedItem(fchrItemID))
            {
                //����ɨ�������ʾ��
                Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

                objAddDetail.AddErrorBarCode(barCode.Trim(), "��Ʒ�ѱ�ͣ��");
                objAddDetail.txtBarCode.Text = "";
                objAddDetail.txtBarCode.Select();
                return false;
            }
            //�����������Ƿ���ֵ
            bool isEmptyFbitFree = objAddDetail.JudgeFbitFreeIsEmpty(fchrItemID);
            if (!isEmptyFbitFree)
            {
                //����ɨ�������ʾ��
                Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

                objAddDetail.AddErrorBarCode(barCode.Trim(), "�������������Ʒ������");
                objAddDetail.txtBarCode.Text = "";
                objAddDetail.txtBarCode.Select();
                return false;
            }
            bool isBatch = objAddDetail.JudgeIsBatch(fchrItemID);
            if (isBatch)
            {
                //����ɨ�������ʾ��
                Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

                objAddDetail.AddErrorBarCode(barCode.Trim(), "������������κ�Ч�ڡ�");
                objAddDetail.txtBarCode.Text = "";
                objAddDetail.txtBarCode.Select();
                return false;
            }
            bool isValidDay = objAddDetail.JudgeIsValidDay(fchrItemID);
            if (isValidDay)
            {
                //����ɨ�������ʾ��
                Console.Beep(ApplicationConstraints.WRONG_FRNQUENCY, ApplicationConstraints.WRONG_DURATION);

                objAddDetail.AddErrorBarCode(barCode.Trim(), "������������κ�Ч�ڡ�");
                objAddDetail.txtBarCode.Text = "";
                objAddDetail.txtBarCode.Select();
                return false;
            }
            BindGrid(itemTable, barCode);

            //����ɨ����ȷ��ʾ��
            Console.Beep(ApplicationConstraints.RIGHT_FRNQUENCY, ApplicationConstraints.RIGHT_DURATION);

            return true;
        }
        /// <summary>
        /// �DataGrid
        /// </summary>
        /// <param name="itemTable"></param>
        private void BindGrid(DataTable itemTable, string barCode)
        {
            //��Ʒ��
            //��ɫСѼ
            CheckUtility objCheckUtility = new CheckUtility();
            DataTable gridTable = objExternalMethodCall.HandleEvent.GetDetailTable();
            DataRow row = gridTable.NewRow();
            Form objForm = objExternalMethodCall.HandleEvent.InitFormClass.MainForm;
            DataGrid objGrid = objExternalMethodCall.HandleEvent.GetDataGrid();
            objCheckUtility.MainFrom = objGrid.FindForm();
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
                if (row.Table.Columns.Contains("flotOutQuantity"))
                {
                    row["flotOutQuantity"] = 0.0;
                }
                if (row.Table.Columns.Contains("flotQuantityOut"))
                {
                    row["flotQuantityOut"] = 0.0;
                }
                if (row.Table.Columns.Contains("���ۼ�"))
                {
                    row["���ۼ�"] = Tools.GetDblColumnValue(itemTable.Rows[0]["flotQuotePrice"]);
                }
                if (row.Table.Columns.Contains("��������"))
                {
                    row["��������"] = itemTable.Rows[0]["fchrItemName"].ToString();
                }
                if (row.Table.Columns.Contains("����"))
                {
                    row["����"] = barCode;//fbitValidDay
                }
                if (row.Table.Columns.Contains("�Ƿ���Ч�ڹ���"))
                {
                    row["�Ƿ���Ч�ڹ���"] = Tools.GetBoolColumnValue(itemTable.Rows[0]["fbitValidDay"]);
                }

                //��Ʒ����ȡ�����������õ�������V891һ�ڲ��� 
                //row["flotQuantity"] = 1;
                //�޸����������ܽ��
                string quantity = row["flotQuantity"].ToString();
                string lblFlotQuantity = (HandleEvent.FindControl("lblFlotQuantity", objForm) as ExNoBorderLabel).ControlValue;
                if (quantity == "")
                {
                    quantity = "0";
                }
                if (lblFlotQuantity == "")
                {
                    lblFlotQuantity = "0";
                }
                float totalQuantity = float.Parse(quantity) + float.Parse(lblFlotQuantity);
                double lblMoney = Tools.GetDblColumnValue((HandleEvent.FindControl("lblMoney", objForm) as ExNoBorderLabel).ControlValue);
                double flotQuotePrice = 0.0;
                if (row.Table.Columns.Contains("���ۼ�"))
                {
                    flotQuotePrice = Tools.GetDblColumnValue(row["���ۼ�"]);
                }
                if (row.Table.Columns.Contains("flotQuotePrice"))
                {
                    flotQuotePrice = Tools.GetDblColumnValue(row["flotQuotePrice"]);
                }
                double flotmoney = 1 * flotQuotePrice;
                double totalmoney = flotmoney + lblMoney;
                row["flotmoney"] = flotmoney;
                string errInfo = "";
                (HandleEvent.FindControl("lblFlotQuantity", objForm) as ExNoBorderLabel).ControlValue = totalQuantity.ToString();
                (HandleEvent.FindControl("lblMoney", objForm) as ExNoBorderLabel).ControlValue = totalmoney.ToString(SysPara.FormatMoney());

                //���û�λֵ��V8.91, libo, 2010-02-01
                string strPosID = this.GetPositionID(Tools.GetStringColumnValue(row["fchrItemID"]));
                if (string.IsNullOrEmpty(strPosID))
                {
                    row["fchrPosID"] = DBNull.Value;
                }
                else
                {
                    row["fchrPosID"] = strPosID;
                }
                string strPosName = this.GetPositionName(Tools.GetStringColumnValue(row["fchrItemID"]));
                row["fchrPosName"] = strPosName;

                int intCount = 0;

                //gridTable = objCheckUtility.UniteItem(gridTable, row, ref intCount, barCode);//�ϲ���Ʒ�� 

                //ȡ����Ʒ��Ʒ��������V891���ڲ���
                this.SetRowUseQuantity(row);

                gridTable.Rows.Add(row);
                intCount = gridTable.Rows.IndexOf(row);
                HandleEvent.FilterEmptyRows(objGrid);
                if (!HandleEvent.HasEmptyRow(objGrid, gridTable))
                {
                    gridTable.Rows.Add(gridTable.NewRow());
                }
                //��ɫСѼchb2009-10-30
                ExDataGrid objExGrid = objGrid as ExDataGrid;
                //Ч���Ż�
                //for (int j = 0; j < objCheckUtility.GetDataGridCount(gridTable); j++)
                //{
                //    objExGrid.UnSelect(j);
                //}
                //objExGrid.Select(0);
                //objExGrid.CurrentRowIndex = 0;
                //objExGrid.UnSelect(0);

                objExGrid.UnSelectAll();

                objExGrid.Select(intCount);
                objExGrid.CurrentRowIndex = intCount;
                objAddDetail.txtBarCode.Text = "";
                objAddDetail.txtBarCode.Select();
                //--����
                gridTable.Dispose();
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                objAddDetail.txtBarCode.Text = "";
                objAddDetail.txtBarCode.Select();
                throw new Exception(ex.Message);

            }
        }
        /// <summary>
        /// ��ȡ�����ű�
        /// </summary>
        private DataTable GetArchivesBarCodeData(string barCode)
        {
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
            objSql.AppendFormat(" FROM Item  Where  fchrBarCode='{0}' and ftinItemModel=1", barCode);
            DataTable objTable = SqlAccess.ExecuteDataTable(SysPara.ConnectionString, objSql.ToString());
            return objTable;
        }

        /// <summary>
        /// ���ô��IDȡ��fbitFree.tinyint
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
                object obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString,CommandType.Text, objSql.ToString());
                returnValue = Tools.GetBoolColumnValue(obj);
            }
            catch (Exception e)
            {
                Logger.Write(e.Message);
            }
            return returnValue;
        }

        /// <summary>
        /// �������ݱ��еļ�¼�����������ַ�����
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
                string fchrFreeName="fchrFree"+i.ToString();
                if(objTable.Columns.Contains(fchrFreeName))
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
        /// ������Ʒȡ��Ӧ��λID
        /// </summary>
        /// <param name="fchrItemID">��ƷID</param>
        private string GetPositionID(string fchrItemID)
        {
            string strVouchType = Tools.GetStringAttribute(AddDetail.ConfigNode as System.Xml.XmlElement, "vouchType");
            if (strVouchType == "InVouch")
            {
                StringBuilder objSql = new StringBuilder();
                objSql.AppendFormat("select dbo.f_GetPosID('{0}')", fchrItemID);
                object obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, objSql.ToString());
                return Tools.GetStringColumnValue(obj);
            }
            else if (strVouchType == "OutVouch")
            {
                StringBuilder objSql = new StringBuilder();
                objSql.AppendFormat("select dbo.f_GetOutPosID('{0}')", fchrItemID);
                object obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, objSql.ToString());
                return Tools.GetStringColumnValue(obj);
            }
            else
            {
                return "";
            }

        }

        /// <summary>
        /// ������Ʒȡ��Ӧ��λ����
        /// </summary>
        /// <param name="fchrItemID">��ƷID</param>
        private string GetPositionName(string fchrItemID)
        {
            string strVouchType = Tools.GetStringAttribute(AddDetail.ConfigNode as System.Xml.XmlElement, "vouchType");
            if (strVouchType == "InVouch")
            {
                StringBuilder objSql = new StringBuilder();
                objSql.AppendFormat("select dbo.f_GetPosName('{0}')", fchrItemID);
                object obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, objSql.ToString());
                return Tools.GetStringColumnValue(obj);
            }
            else if (strVouchType == "OutVouch")
            {
                StringBuilder objSql = new StringBuilder();
                objSql.AppendFormat("select dbo.f_GetOutPosName('{0}')", fchrItemID);
                object obj = SqlAccess.ExecuteScalar(SysPara.ConnectionString, CommandType.Text, objSql.ToString());
                return Tools.GetStringColumnValue(obj);
            }
            else
            {
                return "";
            }

        }

        /// <summary>
        /// ȡ����Ʒ�Ŀ�����
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

            for (int j = 1; j <= 10; j++)
            {
                fchrFreeValue = Tools.GetStringColumnValue(dr["fchrFree" + j]);
                if (!fchrFreeValue.Equals(""))
                {
                    objWhere.Append(" And");
                    objWhere.AppendFormat(" fchrFree{0}='{1}' ", j.ToString(), fchrFreeValue.Replace("'", ""));
                }
            }

            //��������
            if (dr.Table.Columns.Contains("fchrBatchCode"))
            {
                objWhere.AppendFormat(" And IsNull(fchrBatchCode,'')='{0}' ", Tools.GetStringColumnValue(dr["fchrBatchCode"]));
            }
            //������λ
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
            //������������
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
    }
}
