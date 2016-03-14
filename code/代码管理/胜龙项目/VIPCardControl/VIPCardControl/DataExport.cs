using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Excel;
using System.Reflection;
using System.Collections;

namespace UFIDA.Retail.VIPCardControl
{
    public class DataExport
    {
        public Excel.Application m_xlApp = null;
        //public bool BandedGridViewToExcel(BandedGridView dgvData, DateTime dt, string marker, string _strTitle, string strSavePath, string strSheetName)
        //{
        //    return this.BandedGridViewToExcel(dgvData, dt, marker, _strTitle, false, strSavePath, strSheetName);
        //}

        //public bool BandedGridViewToExcel(BandedGridView dgvData, DateTime dt, string marker, string _strTitle, bool isConvertIntType, string strSavePath, string strSheetName)
        //{
        //    Excel.Application application = new ApplicationClass();
        //    //string strSheetName = strSheetName;
        //    //this.pb_Info.Maximum = dgvData.RowCount;
        //    //this.Refresh();
        //    application.Visible = false;
        //    Workbook workbook = application.Workbooks.Add(true);
        //    Worksheet activeSheet = (Worksheet)workbook.ActiveSheet;
        //    try
        //    {
        //        activeSheet.Name = strSheetName;
        //    }
        //    catch
        //    {
        //    }
        //    int num = 0;
        //    try
        //    {
        //        object fileFormat = Missing.Value;
        //        int num2 = 0;
        //        while (num2 < dgvData.Columns.Count)
        //        {
        //            if (dgvData.Columns[num2].Visible && (dgvData.Columns[num2].Width > 0))
        //            {
        //                num++;
        //                application.Cells[3, num2] = "'" + dgvData.Columns[num2].OwnerBand.Caption;
        //            }
        //            num2++;
        //        }
        //        activeSheet.get_Range(application.Cells[1, num], application.Cells[1, num]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
        //        application.Cells[1, 1] = _strTitle;
        //        activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, num]).Select();
        //        activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, num]).HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
        //        activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, 1]).Font.Bold = true;
        //        activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, 1]).Font.Size = 15;
        //        application.Cells[2, num - 1] = "制表时间：";
        //        application.Cells[2, num] = dt.Date.ToString("yyyy-MM-dd");
        //        activeSheet.get_Range(application.Cells[2, num], application.Cells[2, num]).ColumnWidth = 15;
        //        //this.Refresh();
        //        int num3 = 3;
        //        int num4 = 0;
        //        for (int i = 0; i < dgvData.RowCount; i++)
        //        {
        //            num4 = 0;
        //            num3++;
        //            activeSheet.get_Range(application.Cells[num3, 1], application.Cells[1, 1]).RowHeight = 0x12;
        //            for (num2 = 0; num2 < dgvData.Columns.Count; num2++)
        //            {
        //                if (dgvData.Columns[num2].Visible && (dgvData.Columns[num2].Width != 0))
        //                {
        //                    num4++;
        //                    if (isConvertIntType)
        //                    {
        //                        application.Cells[num3, num4] = "'" + dgvData.GetRowCellValue(i, dgvData.Columns[i]);
        //                    }
        //                    else
        //                    {
        //                        application.Cells[num3, num4] = dgvData.GetRowCellValue(i, dgvData.Columns[i]);
        //                    }
        //                }
        //            }
        //            this.RefreshNew(i, this.dgv.get_Rows().get_Count());
        //        }
        //        application.Cells[dgvData.RowCount + 5, 1] = "制表人：";
        //        application.Cells[dgvData.RowCount + 5, 2] = marker;
        //        application.Cells[dgvData.RowCount + 6, 1] = "审核人：";
        //        application.Cells[dgvData.RowCount + 6, 2] = string.Empty;
        //        activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, 1]).RowHeight = 30;
        //        workbook.SaveAs(strSavePath, fileFormat, fileFormat, fileFormat, fileFormat, fileFormat, XlSaveAsAccessMode.xlNoChange, fileFormat, fileFormat, fileFormat, fileFormat);
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message, "系统提示");
        //        return false;
        //    }
        //    finally
        //    {
        //        workbook = null;
        //        application.Quit();
        //        application = null;
        //    }
        //    return true;
        //}

        public bool DataGridViewToExcel(DataGridView dgv, string strSavePath, string strSheetName)
        {
            Excel.Application application = new ApplicationClass();
            //string strSheetName = strSheetName;
            //this.pb_Info.Maximum = dgv.get_Rows().get_Count() - 1;
            //this.Refresh();
            application.Visible = false;
            Workbook workbook = application.Workbooks.Add(true);
            Worksheet activeSheet = (Worksheet)workbook.ActiveSheet;
            try
            {
                activeSheet.Name = strSheetName;
            }
            catch
            {
            }
            try
            {
                int num3;
                object fileFormat = Missing.Value;
                int num = 1;
                int num2 = 0;
                for (num3 = 0; num3 < dgv.Columns.Count; num3++)
                {
                    if (dgv.Columns[num3].Visible)
                    {
                        num2++;
                        application.Cells[num, num2] = "'" + dgv.Columns[num3].HeaderText;
                    }
                }
                //this.Refresh();
                int irowcount = dgv.Rows.Count;
                for (num3 = 0; num3 < irowcount; num3++)
                {
                    num++;
                    if (dgv.Rows[num3].Visible)
                    {
                        num2 = 0;
                        for (int i = 0; i < dgv.Columns.Count; i++)
                        {
                            if (dgv.Columns[i].Visible)
                            {
                                string str2 = "System.String";
                                if (dgv.Columns[i].CellType != null)
                                {
                                    str2 = dgv.Columns[i].ValueType.ToString();
                                }
                                num2++;
                                if (str2.Equals("System.DateTime"))
                                {
                                    if (dgv.Rows[num3].Cells[i].Value != null)
                                    {
                                        application.Cells[num, num2] = Convert.ToDateTime(dgv.Rows[num3].Cells[i].Value);
                                    }
                                }
                                else if (str2.Equals("System.String"))
                                {
                                    application.Cells[num, num2] = "'" + dgv.Rows[num3].Cells[i].Value;
                                }
                                else
                                {
                                    application.Cells[num, num2] = "'" + dgv.Rows[num3].Cells[i].Value;
                                }
                            }
                        }
                        this.RefreshNew(num3, irowcount);
                    }
                }
                workbook.SaveAs(strSavePath, fileFormat, fileFormat, fileFormat, fileFormat, fileFormat, XlSaveAsAccessMode.xlNoChange, fileFormat, fileFormat, fileFormat, fileFormat);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "发生异常");
                return false;
            }
            finally
            {
                workbook = null;
                application.Quit();
                application = null;
            }
            return true;
        }

        public bool DataGridViewToExcel(DataGridView dgvData, DateTime dt, string marker, string _strTitle, string strSavePath, string strSheetName)
        {
            return this.DataGridViewToExcel(dgvData, dt, marker, _strTitle, false, strSavePath, strSheetName);
        }

        public bool DataGridViewToExcel(DataGridView dgvData, DateTime dt, string marker, string _strTitle, bool isConvertIntType, string strSavePath,string strSheetName)
        {
            Excel.Application application = new ApplicationClass();
            //string strSheetName = this.strSheetName;
            //this.pb_Info.Maximum = dgvData.get_Rows().get_Count();
            //this.Refresh();
            application.Visible = false;
            Workbook workbook = application.Workbooks.Add(true);
            Worksheet activeSheet = (Worksheet)workbook.ActiveSheet;
            try
            {
                activeSheet.Name = strSheetName;
            }
            catch
            {
            }
            int num = 0;
            try
            {
                object fileFormat = Missing.Value;
                int num2 = 0;
                while (num2 < dgvData.Columns.Count)
                {
                    if (dgvData.Columns[num2].Visible && (dgvData.Columns[num2].Width != 0))
                    {
                        num++;
                        application.Cells[3, num2] = "'" + dgvData.Columns[num2].HeaderText;
                    }
                    num2++;
                }
                activeSheet.get_Range(application.Cells[1, num], application.Cells[1, num]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                application.Cells[1, 1] = _strTitle;
                activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, num]).Select();
                activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, num]).HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, 1]).Font.Bold = true;
                activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, 1]).Font.Size = 15;
                application.Cells[2, num - 1] = "制表时间：";
                application.Cells[2, num] = dt.Date.ToString("yyyy-MM-dd");
                activeSheet.get_Range(application.Cells[2, num], application.Cells[2, num]).ColumnWidth = 15;
                //this.Refresh();
                int num3 = 3;
                int num4 = 0;
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    num4 = 0;
                    num3++;
                    activeSheet.get_Range(application.Cells[num3, 1], application.Cells[1, 1]).RowHeight = 0x12;
                    for (num2 = 0; num2 < dgvData.Columns.Count; num2++)
                    {
                        if (dgvData.Columns[num2].Visible && (dgvData.Columns[num2].Width != 0))
                        {
                            num4++;
                            string str2 = "System.String";
                            if (dgvData.Columns[num2].ValueType != null)
                            {
                                str2 = dgvData.Columns[num2].ValueType.ToString();
                            }
                            if (str2.Equals("System.DateTime") && (dgvData.Rows[num2].Cells[i].Value != null))
                            {
                                application.Cells[num3, num4] = "'" + dgvData.Rows[i].Cells[num2].Value;
                            }
                            else if (str2.Equals("System.String"))
                            {
                                application.Cells[num3, num4] = "'" + dgvData.Rows[i].Cells[num2].Value;
                            }
                            else if (isConvertIntType)
                            {
                                application.Cells[num3, num4] = "'" + dgvData.Rows[i].Cells[num2].Value;
                            }
                            else
                            {
                                application.Cells[num3, num4] = dgvData.Rows[i].Cells[num2].Value;
                            }
                        }
                    }
                    //this.RefreshNew(i, dgv.Rows.Count);
                }
                application.Cells[dgvData.Rows.Count + 5, 1] = "制表人：";
                application.Cells[dgvData.Rows.Count + 5, 2] = marker;
                application.Cells[dgvData.Rows.Count + 6, 1] = "审核人：";
                application.Cells[dgvData.Rows.Count + 6, 2] = string.Empty;
                activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, 1]).RowHeight = 30;
                workbook.SaveAs(strSavePath, fileFormat, fileFormat, fileFormat, fileFormat, fileFormat, XlSaveAsAccessMode.xlNoChange, fileFormat, fileFormat, fileFormat, fileFormat);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "系统提示");
                return false;
            }
            finally
            {
                workbook = null;
                application.Quit();
                application = null;
            }
            return true;
        }

        public bool FlexToExcel(C1.Win.C1FlexGrid.C1FlexGrid flex, string strSavePath, string strSheetName)
        {
            Excel.Application application = new ApplicationClass();
            //string strSheetName = strSheetName;
            //this.pb_Info.Maximum = flex.Rows.Count - 1;
            //this.Refresh();
            application.Visible = false;
            Workbook workbook = application.Workbooks.Add(true);
            Worksheet activeSheet = (Worksheet)workbook.ActiveSheet;
            try
            {
                activeSheet.Name = strSheetName;
            }
            catch
            {
            }
            try
            {
                int num3;
                object fileFormat = Missing.Value;
                int num = 1;
                int num2 = 0;
                for (num3 = 1; num3 < flex.Cols.Count; num3++)
                {
                    if (flex.Cols[num3].Visible)
                    {
                        num2++;
                        application.Cells[num, num2] = "'" + flex.Cols[num3].Caption;
                    }
                }
                //this.Refresh();
                int count = flex.Rows.Count;
                for (num3 = 1; num3 < count; num3++)
                {
                    num++;
                    if (flex.Rows[num3].Visible)
                    {
                        num2 = 0;
                        for (int i = 1; i < flex.Cols.Count; i++)
                        {
                            if (flex.Cols[i].Visible)
                            {
                                string str2 = "System.String";
                                if (flex.Cols[i].DataType != null)
                                {
                                    str2 = flex.Cols[i].DataType.ToString();
                                }
                                num2++;
                                if (str2.Equals("System.DateTime"))
                                {
                                    if ((!Convert.IsDBNull(flex.GetData(num3, i)) && (flex.GetData(num3, i) != null)) && (Convert.ToString(flex.GetData(num3, i)).Length > 0))
                                    {
                                        application.Cells[num, num2] = Convert.ToDateTime(flex[num3, i].ToString());
                                    }
                                }
                                else if (str2.Equals("System.String"))
                                {
                                    application.Cells[num, num2] = "'" + flex.GetDataDisplay(num3, i).ToString();
                                }
                                else
                                {
                                    application.Cells[num, num2] = flex.GetDataDisplay(num3, i).ToString();
                                }
                            }
                        }
                        this.RefreshNew(num3, count);
                    }
                }
                workbook.SaveAs(strSavePath, fileFormat, fileFormat, fileFormat, fileFormat, fileFormat, XlSaveAsAccessMode.xlNoChange, fileFormat, fileFormat, fileFormat, fileFormat);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "发生异常");
                return false;
            }
            finally
            {
                workbook = null;
                application.Quit();
                application = null;
            }
            return true;
        }

        public bool FlexToExcel(C1.Win.C1FlexGrid.C1FlexGrid flexData, DateTime dt, string marker, string _strTitle, string strSavePath, string strSheetName)
        {
            return this.FlexToExcel(flexData, dt, marker, _strTitle, false, strSavePath, strSheetName);
        }

        public bool FlexToExcel(C1.Win.C1FlexGrid.C1FlexGrid flexData, DateTime dt, string marker, string _strTitle, bool isConvertIntType, string strSavePath, string strSheetName)
        {
            Excel.Application application = new ApplicationClass();
            //string strSheetName = this.strSheetName;
            //this.pb_Info.Maximum = flexData.Rows.Count - 1;
            //this.Refresh();
            application.Visible = false;
            Workbook workbook = application.Workbooks.Add(true);
            Worksheet activeSheet = (Worksheet)workbook.ActiveSheet;
            try
            {
                activeSheet.Name = strSheetName;
            }
            catch
            {
            }
            int num = 0;
            try
            {
                int num2;
                int @fixed;
                object fileFormat = Missing.Value;
                for (num2 = 0; num2 < flexData.Rows.Fixed; num2++)
                {
                    int num3 = 0;
                    @fixed = flexData.Cols.Fixed;
                    while (@fixed < (flexData.Cols.Count - 1))
                    {
                        if (flexData.Cols[@fixed].Visible)
                        {
                            num3++;
                            if (num2 == 0)
                            {
                                num++;
                            }
                            else if (Convert.ToString(flexData.Rows[num2][@fixed]).Equals(Convert.ToString(flexData.Rows[num2 - 1][@fixed])))
                            {
                                goto Label_014F;
                            }
                            application.Cells[3 + num2, num3] = "'" + Convert.ToString(flexData.Rows[num2][@fixed]);
                        }
                    Label_014F:
                        @fixed++;
                    }
                }
                activeSheet.get_Range(application.Cells[1, num], application.Cells[1, num]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                application.Cells[1, 1] = _strTitle;
                activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, num]).Select();
                activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, num]).HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, 1]).Font.Bold = true;
                activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, 1]).Font.Size = 15;
                application.Cells[2, num - 1] = "制表时间：";
                application.Cells[2, num] = dt.Date.ToString("yyyy-MM-dd");
                activeSheet.get_Range(application.Cells[2, num], application.Cells[2, num]).ColumnWidth = 15;
                //this.Refresh();
                int num5 = flexData.Rows.Fixed + 2;
                int num6 = 0;
                for (num2 = flexData.Rows.Fixed; num2 < flexData.Rows.Count; num2++)
                {
                    num6 = 0;
                    num5++;
                    activeSheet.get_Range(application.Cells[num5, 1], application.Cells[1, 1]).RowHeight = 0x12;
                    for (@fixed = flexData.Cols.Fixed; @fixed < flexData.Cols.Count; @fixed++)
                    {
                        if (flexData.Cols[@fixed].Visible && (flexData.Cols[@fixed].Width != 0))
                        {
                            num6++;
                            string str2 = "System.String";
                            if (flexData.Cols[@fixed].DataType != null)
                            {
                                str2 = flexData.Cols[@fixed].DataType.ToString();
                            }
                            if (str2.Equals("System.DateTime"))
                            {
                                if ((!Convert.IsDBNull(flexData.GetData(num2, @fixed)) && (flexData.GetData(num2, @fixed) != null)) && (Convert.ToString(flexData.GetData(num2, @fixed)).Length > 0))
                                {
                                    application.Cells[num5, num6] = "'" + flexData.GetDataDisplay(num2, @fixed);
                                }
                            }
                            else if (str2.Equals("System.String"))
                            {
                                application.Cells[num5, num6] = "'" + flexData.GetDataDisplay(num2, @fixed);
                            }
                            else if (isConvertIntType)
                            {
                                application.Cells[num5, num6] = "'" + flexData.GetDataDisplay(num2, @fixed);
                            }
                            else
                            {
                                application.Cells[num5, num6] = flexData.GetDataDisplay(num2, @fixed);
                            }
                        }
                    }
                    this.RefreshNew(num2, flexData.Rows.Count);
                }
                application.Cells[flexData.Rows.Count + 5, 1] = "制表人：";
                application.Cells[flexData.Rows.Count + 5, 2] = marker;
                application.Cells[flexData.Rows.Count + 6, 1] = "审核人：";
                application.Cells[flexData.Rows.Count + 6, 2] = string.Empty;
                activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, 1]).RowHeight = 30;
                workbook.SaveAs(strSavePath, fileFormat, fileFormat, fileFormat, fileFormat, fileFormat, XlSaveAsAccessMode.xlNoChange, fileFormat, fileFormat, fileFormat, fileFormat);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "系统提示");
                return false;
            }
            finally
            {
                workbook = null;
                application.Quit();
                application = null;
            }
            return true;
        }

        //public bool GridViewToExcel(GridView dgvData, DateTime dt, string marker, string _strTitle, string strSavePath, string strSheetName)
        //{
        //    return this.GridViewToExcel(dgvData, dt, marker, _strTitle, false, strSavePath, strSheetName);
        //}

        //public bool GridViewToExcel(GridView dgvData, DateTime dt, string marker, string _strTitle, bool isConvertIntType, string strSavePath,string strSheetName)
        //{
        //    Excel.Application application = new ApplicationClass();
        //    //string strSheetName = this.strSheetName;
        //    //this.pb_Info.Maximum = dgvData.RowCount;
        //    //this.Refresh();
        //    application.Visible = false;
        //    Workbook workbook = application.Workbooks.Add(true);
        //    Worksheet activeSheet = (Worksheet)workbook.ActiveSheet;
        //    try
        //    {
        //        activeSheet.Name = strSheetName;
        //    }
        //    catch
        //    {
        //    }
        //    int num = 0;
        //    try
        //    {
        //        object fileFormat = Missing.Value;
        //        int num2 = 0;
        //        while (num2 < dgvData.Columns.Count)
        //        {
        //            if (dgvData.Columns[num2].Visible && (dgvData.Columns[num2].Width > 0))
        //            {
        //                num++;
        //                application.Cells[3, num2] = "'" + dgvData.Columns[num2].Caption;
        //            }
        //            num2++;
        //        }
        //        activeSheet.get_Range(application.Cells[1, num], application.Cells[1, num]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
        //        application.Cells[1, 1] = _strTitle;
        //        activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, num]).Select();
        //        activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, num]).HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
        //        activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, 1]).Font.Bold = true;
        //        activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, 1]).Font.Size = 15;
        //        application.Cells[2, num - 1] = "制表时间：";
        //        application.Cells[2, num] = dt.Date.ToString("yyyy-MM-dd");
        //        activeSheet.get_Range(application.Cells[2, num], application.Cells[2, num]).ColumnWidth = 15;
        //        //this.Refresh();
        //        int num3 = 3;
        //        int num4 = 0;
        //        for (int i = 0; i < dgvData.RowCount; i++)
        //        {
        //            num4 = 0;
        //            num3++;
        //            activeSheet.get_Range(application.Cells[num3, 1], application.Cells[1, 1]).RowHeight = 0x12;
        //            for (num2 = 0; num2 < dgvData.Columns.Count; num2++)
        //            {
        //                if (dgvData.Columns[num2].Visible && (dgvData.Columns[num2].Width != 0))
        //                {
        //                    num4++;
        //                    if (isConvertIntType)
        //                    {
        //                        application.Cells[num3, num4] = "'" + dgvData.GetRowCellValue(i, dgvData.Columns[i]);
        //                    }
        //                    else
        //                    {
        //                        application.Cells[num3, num4] = dgvData.GetRowCellValue(i, dgvData.Columns[i]);
        //                    }
        //                }
        //            }
        //            this.RefreshNew(i, this.dgv.get_Rows().get_Count());
        //        }
        //        application.Cells[dgvData.RowCount + 5, 1] = "制表人：";
        //        application.Cells[dgvData.RowCount + 5, 2] = marker;
        //        application.Cells[dgvData.RowCount + 6, 1] = "审核人：";
        //        application.Cells[dgvData.RowCount + 6, 2] = string.Empty;
        //        activeSheet.get_Range(application.Cells[1, 1], application.Cells[1, 1]).RowHeight = 30;
        //        workbook.SaveAs(strSavePath, fileFormat, fileFormat, fileFormat, fileFormat, fileFormat, XlSaveAsAccessMode.xlNoChange, fileFormat, fileFormat, fileFormat, fileFormat);
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message, "系统提示");
        //        return false;
        //    }
        //    finally
        //    {
        //        workbook = null;
        //        application.Quit();
        //        application = null;
        //    }
        //    return true;
        //}

        private void RefreshNew(int i, int irowcount)
        {
            //this.pb_Info.Value = i;
            //this.lab_Info.Text = ((((i + 1) * 100) / irowcount)).ToString() + "%";
            //this.RefreshGif();
            //this.Refresh();
        }

        //private bool SavetoExcel()
        //{
        //    if ((((this.flex == null) && (this.dgv == null)) && (this.advBandedGridView1 == null)) && (this.gridView1 == null))
        //    {
        //        MessageBox.Show("没有要导出的记录!!!", "系统提示");
        //        return false;
        //    }
        //    if (this.flex != null)
        //    {
        //        this.labRowCount.Text = "共有" + (this.flex.Rows.Count - 1) + "条记录：";
        //    }
        //    else if (this.dgv != null)
        //    {
        //        this.labRowCount.Text = "共有" + this.dgv.get_Rows().get_Count() + "条记录：";
        //    }
        //    else if (this.advBandedGridView1 != null)
        //    {
        //        this.labRowCount.Text = "共有" + this.advBandedGridView1.RowCount + "条记录：";
        //    }
        //    else if (this.gridView1 != null)
        //    {
        //        this.labRowCount.Text = "共有" + this.gridView1.RowCount + "条记录：";
        //    }
        //    if (this.rbtnQuick.Checked)
        //    {
        //        if (Export.ExportData(this.flex, this.strSavePath))
        //        {
        //            this.flgFinish = true;
        //            return true;
        //        }
        //        return false;
        //    }
        //    try
        //    {
        //        if (this.flex != null)
        //        {
        //            if (this.strTitle.Length > 0)
        //            {
        //                if (!this.FlexToExcel(this.flex, this.dtDateTime, this.strMarker, this.strTitle))
        //                {
        //                    return false;
        //                }
        //            }
        //            else if (!this.FlexToExcel())
        //            {
        //                return false;
        //            }
        //        }
        //        else if (this.dgv != null)
        //        {
        //            if (this.strTitle.Length > 0)
        //            {
        //                if (!this.DataGridViewToExcel(this.dgv, this.dtDateTime, this.strMarker, this.strTitle))
        //                {
        //                    return false;
        //                }
        //            }
        //            else if (!this.DataGridViewToExcel())
        //            {
        //                return false;
        //            }
        //        }
        //        else if (this.advBandedGridView1 != null)
        //        {
        //            if (!this.BandedGridViewToExcel(this.advBandedGridView1, this.dtDateTime, this.strMarker, this.strTitle))
        //            {
        //                return false;
        //            }
        //        }
        //        else if ((this.gridView1 != null) && !this.GridViewToExcel(this.gridView1, this.dtDateTime, this.strMarker, this.strTitle))
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message, "系统提示");
        //        return false;
        //    }
        //    finally
        //    {
        //        try
        //        {
        //            Process[] processesByName = Process.GetProcessesByName("Excel");
        //            foreach (Process process in processesByName)
        //            {
        //                if (process.get_MainWindowTitle() == string.Empty)
        //                {
        //                    process.Kill();
        //                }
        //            }
        //        }
        //        catch
        //        {
        //        }
        //    }
        //    this.flgFinish = true;
        //    return true;
        //}

        /// <summary>  
        /// 将DataTable数据导出到Excel表  
        /// </summary>  
        /// <param name="tmpDataTable">要导出的DataTable</param>  
        /// <param name="strFileName">Excel的保存路径及名称</param>  
        public void DataTabletoExcel(System.Data.DataTable tmpDataTable, string strFileName)
        {
            string strHyperlinks = "";
            Range tempRange = null;

            if (tmpDataTable == null)
            {
                return;
            }
            DelNoUseColumns(ref tmpDataTable);
            long rowNum = tmpDataTable.Rows.Count;//行数  
            int columnNum = tmpDataTable.Columns.Count;//列数  
            Excel.Application m_xlApp = new Excel.Application();
            m_xlApp.DisplayAlerts = false;//不显示更改提示  
            m_xlApp.Visible = false;
            string objValue = "";

            Excel.Workbooks workbooks = m_xlApp.Workbooks;
            Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  

            //設置固定裂開列寬
            //worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 1]).ColumnWidth = 15;
            //worksheet.get_Range(worksheet.Cells[1, 2], worksheet.Cells[1, 2]).ColumnWidth = 8;
            //worksheet.get_Range(worksheet.Cells[1, 3], worksheet.Cells[1, 3]).ColumnWidth = 41;
            //worksheet.get_Range(worksheet.Cells[1, 4], worksheet.Cells[1, 4]).ColumnWidth = 63.5;
            //worksheet.get_Range(worksheet.Cells[1, 5], worksheet.Cells[1, 5]).ColumnWidth = 6;
            //worksheet.get_Range(worksheet.Cells[1, 6], worksheet.Cells[1, 6]).ColumnWidth = 15;

            try
            {
                if (rowNum > 65536)//单张Excel表格最大行数  
                {
                    long pageRows = 65535;//定义每页显示的行数,行数必须小于65536  
                    int scount = (int)(rowNum / pageRows);//导出数据生成的表单数  
                    if (scount * pageRows < rowNum)//当总行数不被pageRows整除时，经过四舍五入可能页数不准  
                    {
                        scount = scount + 1;
                    }
                    for (int sc = 1; sc <= scount; sc++)
                    {
                        if (sc > 1)
                        {
                            object missing = System.Reflection.Missing.Value;
                            worksheet = (Excel.Worksheet)workbook.Worksheets.Add(
                                        missing, missing, missing, missing);//添加一个sheet  
                        }
                        else
                        {
                            worksheet = (Excel.Worksheet)workbook.Worksheets[sc];//取得sheet1  
                        }
                        string[,] datas = new string[pageRows + 1, columnNum];

                        for (int i = 0; i < columnNum; i++) //写入字段  
                        {
                            //if (tmpDataTable.Columns[i].Caption.StartsWith("fchrVIPCusDefine") || tmpDataTable.Columns[i].Caption.Contains("ID"))
                            //    continue;
                            //else
                                datas[0, i] = tmpDataTable.Columns[i].Caption;//表头信息  
                        }
                        Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, columnNum]);
                        range.Interior.ColorIndex = 15;//15代表灰色  
                        range.Font.Bold = true;
                        range.Font.Size = 9;

                        int init = int.Parse(((sc - 1) * pageRows).ToString());
                        int r = 0;
                        int index = 0;
                        int result;
                        if (pageRows * sc >= rowNum)
                        {
                            result = (int)rowNum;
                        }
                        else
                        {
                            result = int.Parse((pageRows * sc).ToString());
                        }

                        for (r = init; r < result; r++)
                        {
                            index = index + 1;
                            for (int i = 0; i < columnNum; i++)
                            {
                                //if (tmpDataTable.Columns[i].Caption.StartsWith("fchrVIPCusDefine") || tmpDataTable.Columns[i].Caption.Contains("ID"))
                                //    continue;
                                //else
                                //{
                                    object obj = tmpDataTable.Rows[r][tmpDataTable.Columns[i].ToString()];
                                    //datas[index, i] = obj == null ? "" : "'" + obj.ToString().Trim();//在obj.ToString()前加单引号是为了防止自动转化格式  
                                    if (obj == null)
                                        objValue = "";
                                    else {
                                        if (obj.ToString().Trim() == "True")
                                        {
                                            objValue = "是";
                                        }
                                        else if (obj.ToString().Trim() == "False")
                                        {
                                            objValue = "否";
                                        }
                                        else
                                            objValue = obj.ToString().Trim();
                                    }
                                    datas[index, i] = objValue;
                                //}
                            }
                            System.Windows.Forms.Application.DoEvents();
                            //添加进度条  
                        }

                        Excel.Range fchR = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[index + 1, columnNum]);
                        fchR.Value2 = datas;
                        worksheet.Columns.EntireColumn.AutoFit();//列宽自适应。  
                        m_xlApp.WindowState = Excel.XlWindowState.xlMaximized;//Sheet表最大化  
                        range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[index + 1, columnNum]);
                        //range.Interior.ColorIndex = 15;//15代表灰色  
                        range.Font.Size = 9;
                        range.RowHeight = 14.25;
                        range.Borders.LineStyle = 1;
                        range.HorizontalAlignment = 1;
                    }
                }
                else
                {
                    string[,] datas = new string[rowNum + 1, columnNum];
                    for (int i = 0; i < columnNum; i++) //写入字段  
                    {
                        //if (tmpDataTable.Columns[i].Caption.StartsWith("fchrVIPCusDefine") || tmpDataTable.Columns[i].Caption.Contains("ID"))
                        //    continue;
                        //else
                            datas[0, i] = tmpDataTable.Columns[i].Caption;
                    }
                    Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, columnNum]);
                    range.Interior.ColorIndex = 15;//15代表灰色  
                    range.Font.Bold = true;
                    range.Font.Size = 9;

                    int r = 0;
                    for (r = 0; r < rowNum; r++)    
                    {
                        for (int i = 0; i < columnNum; i++)
                        {
                            //if (tmpDataTable.Columns[i].Caption.StartsWith("fchrVIPCusDefine") || tmpDataTable.Columns[i].Caption.Contains("ID"))
                            //    continue;
                            //else
                            //{
                                object obj = tmpDataTable.Rows[r][tmpDataTable.Columns[i].ToString()];
                                //datas[r + 1, i] = obj == null ? "" : "'" + obj.ToString().Trim();//在obj.ToString()前加单引号是为了防止自动转化格式
                                if (obj == null)
                                    objValue = "";
                                else
                                {
                                    if (obj.ToString().Trim() == "True")
                                    {
                                        objValue = "是";
                                    }
                                    else if (obj.ToString().Trim() == "False")
                                    {
                                        objValue = "否";
                                    }
                                    else
                                        objValue = obj.ToString().Trim();
                                }
                                datas[r + 1, i] = objValue;
                            //}
                        }
                        System.Windows.Forms.Application.DoEvents();
                        //添加进度条  
                    }
                    Excel.Range fchR = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rowNum + 1, columnNum]);
                    fchR.Value2 = datas;

                    //for (int k = 2; k <= fchR.Rows.Count; k++)
                    //{
                    //    //獲取第一列沒一行的值，並加上超鏈接
                    //    tempRange = worksheet.get_Range(worksheet.Cells[k, 1], worksheet.Cells[k, 1]);
                    //    strHyperlinks = string.Format("http://www.sunstarmodelcars.com/{0}/{0}.htm", tempRange.Value.ToString());
                    //    worksheet.Hyperlinks.Add(tempRange, strHyperlinks, Missing.Value, tempRange.Value.ToString(), tempRange.Value.ToString());
                    //}

                    worksheet.Columns.EntireColumn.AutoFit();//列宽自适应。
                    m_xlApp.WindowState = Excel.XlWindowState.xlMaximized;

                    range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rowNum + 1, columnNum]);
                    //range.Interior.ColorIndex = 15;//15代表灰色  
                    range.Font.Size = 9;
                    range.RowHeight = 14.25;
                    range.Borders.LineStyle = 1;
                    range.HorizontalAlignment = 1;
                }
                //workbook.Saved = true;
                workbook.SaveAs(strFileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlNoChange, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                //workbook.SaveCopyAs(strFileName);
                System.Runtime.InteropServices.Marshal.ReleaseComObject((object)worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject((object)workbook);
                m_xlApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject((object)m_xlApp);
                System.GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("导出异常：" + ex.Message, "导出异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                EndReport();
            }
        }

        /// <summary>
        /// 删除没用的列
        /// </summary>
        /// <param name="dt"></param>
        private void DelNoUseColumns(ref System.Data.DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                for (int c = dt.Columns.Count - 1; c >= 0; c--)
                {
                    if (dt.Columns[c].ColumnName.EndsWith("ID") || dt.Columns[c].ColumnName.StartsWith("fchrVIPCusDefine"))
                    {
                        dt.Columns.RemoveAt(c);
                        continue;
                    }
                }
            }
        }

        /// <summary>  
        /// 退出报表时关闭Excel和清理垃圾Excel进程  
        /// </summary>  
        private void EndReport()
        {
            object missing = System.Reflection.Missing.Value;
            try
            {
                m_xlApp.Workbooks.Close();
                m_xlApp.Workbooks.Application.Quit();
                m_xlApp.Application.Quit();
                m_xlApp.Quit();
            }
            catch { }
            finally
            {
                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp.Workbooks);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp.Application);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp);
                    m_xlApp = null;
                }
                catch { }
                try
                {
                    //清理垃圾进程  
                    this.killProcessThread();
                }
                catch { }
                GC.Collect();
            }
        }
        /// <summary>  
        /// 杀掉不死进程  
        /// </summary>  
        private void killProcessThread()
        {
            ArrayList myProcess = new ArrayList();
            for (int i = 0; i < myProcess.Count; i++)
            {
                try
                {
                    System.Diagnostics.Process.GetProcessById(int.Parse((string)myProcess[i])).Kill();
                }
                catch { }
            }
        }
    }
}
