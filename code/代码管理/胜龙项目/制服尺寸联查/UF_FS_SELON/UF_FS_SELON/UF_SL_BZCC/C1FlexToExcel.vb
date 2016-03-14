Imports C1.Win.C1FlexGrid
Imports System.Collections
Imports Microsoft.VisualBasic
Imports VBScript_RegExp_55


Public Class C1FlexToExcel

    Private C1FlexGrid1 = New C1FlexGrid()

    Public Sub New(ByVal mC1FlexGrid1 As C1FlexGrid)
        C1FlexGrid1 = mC1FlexGrid1
    End Sub

    Public Sub New()

    End Sub


    '导出EXCEL及打印
    Public Function flexgridtoexcel(ByVal grd As C1FlexGrid, ByVal mExcelApp As Object, ByVal mMocode As String, ByVal mCode As String, ByVal GolDataTab As DataTable, Optional ByVal m_DataTab As DataTable = Nothing, Optional ByVal bCombinePrt As Boolean = False, Optional ByVal bPrintPreview As Boolean = False, Optional ByVal IfoutExcel As Boolean = False) As Boolean
        On Error GoTo errhandle
        Dim ColCount As Integer
        Dim i As Integer
        Dim k As Integer
        Dim rowcount As Integer
        Dim xlApp As Excel.Application
        Dim xlBook As Excel.Workbook
        Dim xlsheet As Excel.Worksheet
        Dim sRange As String
        Dim icolpos As Integer             '电子表格的当前列 

        If (mExcelApp Is Nothing) Then
            xlApp = New Excel.Application
        Else
            xlApp = mExcelApp
        End If


        '打印前合并处理 add by pj 20121226
        Dim DataSourceTab As New DataTable
        Dim OldSourceTab As DataTable
        Dim OldDataTable As DataTable
        Dim OrigGolTmp As DataTable

        If Not GolDataTab Is Nothing Then
            OrigGolTmp = GolDataTab.Copy()
        End If

        OldSourceTab = Nothing
        If bCombinePrt = True Then
            If Not m_DataTab Is Nothing Then


                'DataSourceTab = GolDataTab
                DataSourceTab = grd.DataSource

                'If GolDataTab.Rows.Count > 0 Then

                '    DataSourceTab = GolDataTab.Copy()

                'End If


                OldSourceTab = DataSourceTab.Copy()

                OldDataTable = m_DataTab.Copy()

                'DataTable新增列版型编码
                Dim mNewCol As DataColumn
                If Not m_DataTab.Columns.Contains("newSCode") Then
                    mNewCol = New DataColumn()
                    mNewCol.ColumnName = "newSCode"
                    mNewCol.DataType = System.Type.GetType("System.String")
                    mNewCol.Caption = "newSCode"
                    m_DataTab.Columns.Add(mNewCol)
                End If


                'DataTable新增列合并关联标志
                mNewCol = New DataColumn()
                If Not m_DataTab.Columns.Contains("CombineRel") Then
                    mNewCol.ColumnName = "CombineRel"
                    mNewCol.DataType = System.Type.GetType("System.String")
                    mNewCol.Caption = "CombineRel"
                    m_DataTab.Columns.Add(mNewCol)
                End If

                'DataTable新增列短袖版型制服类型编码－长袖版型行用
                mNewCol = New DataColumn()
                If Not m_DataTab.Columns.Contains("DCol") Then
                    mNewCol.ColumnName = "DCol"
                    mNewCol.DataType = System.Type.GetType("System.String")
                    mNewCol.Caption = "DCol"
                    m_DataTab.Columns.Add(mNewCol)
                End If

                'DataTable新增列对应可合并的版型编码
                mNewCol = New DataColumn()
                If Not m_DataTab.Columns.Contains("DSCode") Then
                    mNewCol = New DataColumn()
                    mNewCol.ColumnName = "DSCode"
                    mNewCol.DataType = System.Type.GetType("System.String")
                    mNewCol.Caption = "DSCode"
                    m_DataTab.Columns.Add(mNewCol)
                End If

                For Each r1 As DataRow In m_DataTab.Rows
                    r1("newSCode") = r1("BxMc").Split("(")(1).Replace(")", "")
                    m_DataTab.AcceptChanges()
                Next

                'Dim dv As New DataView(m_DataTab)
                'dv.Sort = "newSCode"
                'dv.RowFilter = "cCode like 'K%' Or cCode like 'M%'"
                'm_DataTab = dv.Table()

                For r2 As Integer = 0 To m_DataTab.Rows.Count - 1
                    For r3 As Integer = 0 To m_DataTab.Rows.Count - 1
                        If Mid(m_DataTab.Rows(r2)("newSCode"), 1, m_DataTab.Rows(r2)("newSCode").ToString().Length - GetNumByStr(m_DataTab.Rows(r2)("newSCode")).Length) + "D" + GetNumByStr(m_DataTab.Rows(r2)("newSCode")) = m_DataTab.Rows(r3)("newSCode").ToString() Then
                            m_DataTab.Rows(r2)("CombineRel") = "C"
                            m_DataTab.Rows(r2)("DCol") = m_DataTab.Rows(r3)("cCode")
                            m_DataTab.Rows(r2)("DSCode") = m_DataTab.Rows(r3)("newSCode")
                            m_DataTab.Rows(r3)("CombineRel") = "D"
                            m_DataTab.Rows(r3)("DCol") = m_DataTab.Rows(r2)("cCode")
                            m_DataTab.Rows(r3)("DSCode") = m_DataTab.Rows(r2)("newSCode")
                            m_DataTab.AcceptChanges()
                        End If
                    Next
                Next

                Dim dv2 As DataView = m_DataTab.DefaultView
                dv2.Sort = "cCode,newSCode"
                dv2.RowFilter = "CombineRel <> 'D' or isnull(CombineRel,'') = ''"
                m_DataTab = dv2.ToTable("NewSoreceTab")

                Dim rindex As Integer
                rindex = 0

                Dim IsPrint As Boolean
                Dim CheckPrintMsg = ""
                Dim MsgResult As MsgBoxResult
                IsPrint = False

                CheckPrintMsg = CheckCombineIsSuccess(m_DataTab, DataSourceTab)
                '合并打印前检查
                If CheckPrintMsg <> "" Then
                    MsgResult = MsgBox(CheckPrintMsg, MsgBoxStyle.YesNo, "提示")
                    If MsgResult = MsgBoxResult.Yes Then
                        IsPrint = True
                    Else
                        IsPrint = False
                    End If
                Else
                    IsPrint = True
                End If

                If IsPrint = True Then
                    For Each m_OrigRow As DataRow In DataSourceTab.Rows
                        For Each m_row As DataRow In m_DataTab.Rows
                            'For m_OrigCol As Integer = 5 To DataSourceTab.Columns.Count - 1
                            '当前客户员工有选短袖版型时进行合并处理
                            If Not m_row.IsNull("CombineRel") Then
                                If Not (m_OrigRow.IsNull(m_row("DCol") + "cInvCode")) Then
                                    If m_row("DSCode") = Mid(m_OrigRow(m_row("DCol") + "cInvCode"), 1, m_row("DSCode").ToString().Length) Then
                                        '长袖长实际尺寸
                                        'm_OrigRow(m_row("cCode") + "Define_4") = m_OrigRow(DataSourceTab.Columns(m_row("DCol") + "Define_4").ColumnName)
                                        '长袖长差异数
                                        'm_OrigRow(m_row("cCode") + "iDefine4") = m_OrigRow(DataSourceTab.Columns(m_row("DCol") + "iDefine4").ColumnName)
                                        '短袖长实际尺寸
                                        m_OrigRow(m_row("cCode") + "Define_5") = m_OrigRow(DataSourceTab.Columns(m_row("DCol") + "Define_5").ColumnName)
                                        '短袖长差异数
                                        m_OrigRow(m_row("cCode") + "iDefine5") = m_OrigRow(DataSourceTab.Columns(m_row("DCol") + "iDefine5").ColumnName)
                                        '合计长短袖版型数量/备注
                                        '当长袖版型有数据时，即货号不为空时合并
                                        If Not (m_OrigRow.IsNull(m_row("cCode") + "cInvCode")) Then
                                            m_OrigRow(m_row("cCode") + "iQuantity") = CStr(CInt(m_OrigRow(m_row("cCode") + "iQuantity")) + CInt(m_OrigRow(m_row("DCol") + "iQuantity")))
                                            '合并备注
                                            If Not m_OrigRow.IsNull(m_row("cCode") + "cRemark") Then
                                                If Not m_OrigRow.IsNull(m_row("DCol") + "cRemark") Then
                                                    m_OrigRow(m_row("cCode") + "cRemark") = "(长" & CStr(CInt(m_OrigRow(m_row("cCode") + "iQuantity")) - CInt(m_OrigRow(m_row("DCol") + "iQuantity"))) & ")" & m_OrigRow(m_row("cCode") + "cRemark") & ";" & Chr(13) + Chr(10) & "(短" & m_OrigRow(m_row("DCol") + "iQuantity") & ")" & m_OrigRow(m_row("DCol") + "cRemark")
                                                End If
                                            Else
                                                If Not m_OrigRow.IsNull(m_row("DCol") + "cRemark") Then
                                                    m_OrigRow(m_row("cCode") + "cRemark") = "(长0);(短" & m_OrigRow(m_row("DCol") + "iQuantity") & ")" & m_OrigRow(m_row("DCol") + "cRemark")
                                                End If
                                            End If

                                        Else '当长袖版型无数据时，即货号为空时合并
                                            m_OrigRow(m_row("cCode") + "iQuantity") = m_OrigRow(m_row("DCol") + "iQuantity")
                                            m_OrigRow(m_row("cCode") + "cDfName") = m_OrigRow(m_row("DCol") + "cDfName")
                                            m_OrigRow(m_row("cCode") + "cAlias") = m_OrigRow(m_row("DCol") + "cAlias")
                                            m_OrigRow(m_row("cCode") + "cInvCode") = m_OrigRow(m_row("DCol") + "cInvCode")
                                            For dfindex As Integer = 1 To 8
                                                m_OrigRow(m_row("cCode") + "Define_" + CStr(dfindex)) = m_OrigRow(m_row("DCol") + "Define_" + CStr(dfindex))
                                                m_OrigRow(m_row("cCode") + "iDefine" + CStr(dfindex)) = m_OrigRow(m_row("DCol") + "iDefine" + CStr(dfindex))
                                            Next

                                            If Not m_OrigRow.IsNull(m_row("DCol") + "cRemark") Then
                                                m_OrigRow(m_row("cCode") + "cRemark") = "(长0);(短" & m_OrigRow(m_row("DCol") + "iQuantity") & ")" & m_OrigRow(m_row("DCol") + "cRemark")
                                            End If

                                        End If
                                        DataSourceTab.AcceptChanges()
                                        '清空短袖版型数据列
                                        ClearAllValue(DataSourceTab, m_row("DCol"), rindex)
                                    End If
                                End If
                            End If
                        Next
                        rindex += 1
                    Next
                    '处理合并版型列头显示名称
                    For Each rt As DataRow In m_DataTab.Rows
                        If Not rt.IsNull("CombineRel") Then
                            rt("BxMc") = rt("BxMc").ToString().Replace(")", "/" + rt("DSCode") + ")")
                            m_DataTab.AcceptChanges()
                        End If
                        For Each ct As DataColumn In DataSourceTab.Columns
                            If rt("cCode") = Left(ct.ColumnName, 2) Then
                                ct.Caption = rt("BxMc")
                            End If
                        Next
                    Next
                    'Next
                    DelDataTableCols(DataSourceTab, m_DataTab, OrigGolTmp)
                    '先清空网格数据，再重新加载
                    'DelAllRows(grd)

                    If Not OrigGolTmp Is Nothing Then
                        DelAfterCombCols(OrigGolTmp, DataSourceTab)
                    End If
                    SetDataGrid(DataSourceTab, C1FlexGrid1, m_DataTab, OrigGolTmp)

                End If
            End If
        End If


        ColCount = grd.Cols.Count              '取表格列数 

        Dim mArrList As New ArrayList

        mArrList = getColCount(grd)
        ColCount = mArrList.Count

        rowcount = grd.Rows.Count + 2             '取表格行数 


        'ColCount = grd.Cols.Count              '取表格列数 

        'xlApp.Visible = True                 '显示电子表格程序 

        xlBook = xlApp.Workbooks.Add
        'xlBook.Name = "BookExcel"
        'Set   xlsheet   =   xlBook.Worksheets(3) 
        'xlsheet.Visible   =   xlSheetHidden 
        'Set   xlsheet   =   xlBook.Worksheets(2) 
        'xlsheet.Visible   =   xlSheetHidden             '//隐藏sheet2 
        xlsheet = xlBook.Worksheets(1)
        ' xlsheet.Name = "Book1"

        With xlsheet
            .Range(.Cells(1, 1), .Cells(rowcount, ColCount)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous  '
            '.Range(.Cells(1, 1), .Cells(rowcount, ColCount)).ShrinkToFit = True
        End With
        'VB.Screen.MousePointer = vbHourglass


        xlApp.DisplayAlerts = False



        '下面合并单元格 
        xlsheet.Cells(1, 1) = "制服生产明细通知单：(" + mCode + ")" + "    " + "打印日期：" + Date.Today.Date.ToString("yyyy-MM-dd") + ""
        xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(1, ColCount)).Merge()
        xlsheet.Cells(1, 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter


        xlsheet.Cells(2, 1) = "制单号：" + mMocode + ""
        xlsheet.Range(xlsheet.Cells(2, 1), xlsheet.Cells(2, ColCount)).Merge()
        xlsheet.Cells(2, 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        '设置标题[注意：电子表格的行和列都是从1开始的,而flexgrid的行和列都是从0开始的] 


        icolpos = 0

        For i = 0 To ColCount - 1

            icolpos = icolpos + 1

            Dim medindex As Integer = -1

            medindex = GetMergeCell(grd.GetData(0, mArrList(i)), i, mArrList)
            xlsheet.Cells(3, icolpos) = grd.GetData(0, mArrList(i))

            If (medindex > 0) Then
                xlsheet.Range(xlsheet.Cells(3, icolpos), xlsheet.Cells(3, medindex + 1)).Merge()
                xlsheet.Cells(3, icolpos).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter '水平方向 
            End If

        Next

        '填入单元格  尺码

        For i = 3 To rowcount - 1
            icolpos = 0
            Dim medindex As Integer = -1

            For k = 0 To ColCount - 1
                icolpos = icolpos + 1

                xlsheet.Cells(4, icolpos).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter '水平方向 
                xlsheet.Cells(5, icolpos).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter '水平方向 

                xlsheet.Range(xlsheet.Cells(i + 1, icolpos), xlsheet.Cells(i + 1, icolpos)).RowHeight = xlApp.CentimetersToPoints(1.5)

                xlsheet.Cells(i + 1, icolpos).VerticalAlignment = Excel.XlVAlign.xlVAlignTop   '水平方向 

                If (i < 5) Then
                    xlsheet.Range(xlsheet.Cells(i + 1, icolpos), xlsheet.Cells(i + 1, icolpos)).RowHeight = xlApp.CentimetersToPoints(0.8)
                    If (i = 3) Then

                        If (mArrList(k) > medindex) Then
                            medindex = GetMergeCell(grd.GetData(i - 2, mArrList(k)), k, grd, i - 2, mArrList)
                            If (medindex > 0) Then
                                xlsheet.Range(xlsheet.Cells(4, icolpos), xlsheet.Cells(4, medindex + 1)).Merge()
                            End If
                        End If
                    End If
                    If (grd.GetData(i - 2, mArrList(k)) = "数量" Or grd.GetData(i - 2, mArrList(k)) = "备注" Or grd.GetData(i - 2, mArrList(k)) = "尺码" Or grd.GetData(i - 2, mArrList(k)) = "存货编码" Or icolpos < 5) Then
                        'If (icolpos <= 5) Then
                        '    xlsheet.Cells(4, icolpos) = Nothing
                        '    xlsheet.Cells(5, icolpos) = Nothing

                        '    xlsheet.Range(xlsheet.Cells(3, icolpos), xlsheet.Cells(5, icolpos)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        '    xlsheet.Range(xlsheet.Cells(3, icolpos), xlsheet.Cells(5, icolpos)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection
                        '    xlsheet.Range(xlsheet.Cells(3, icolpos), xlsheet.Cells(5, icolpos)).Merge()

                        'Else
                        '    xlsheet.Cells(5, icolpos) = Nothing
                        '    xlsheet.Range(xlsheet.Cells(4, icolpos), xlsheet.Cells(5, icolpos)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        '    xlsheet.Range(xlsheet.Cells(4, icolpos), xlsheet.Cells(5, icolpos)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection
                        '    xlsheet.Range(xlsheet.Cells(4, icolpos), xlsheet.Cells(5, icolpos)).Merge()
                        'End If
                        If (grd.GetData(i - 2, mArrList(k)) = "序号" Or grd.GetData(i - 2, mArrList(k)) = "工号" Or grd.GetData(i - 2, mArrList(k)) = "部门" Or grd.GetData(i - 2, mArrList(k)) = "姓名" Or grd.GetData(i - 2, mArrList(k)) = "性别") Then
                            xlsheet.Cells(4, icolpos) = Nothing
                            xlsheet.Cells(5, icolpos) = Nothing

                            xlsheet.Range(xlsheet.Cells(3, icolpos), xlsheet.Cells(5, icolpos)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                            xlsheet.Range(xlsheet.Cells(3, icolpos), xlsheet.Cells(5, icolpos)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection
                            xlsheet.Range(xlsheet.Cells(3, icolpos), xlsheet.Cells(5, icolpos)).Merge()
                        Else
                            xlsheet.Cells(5, icolpos) = Nothing
                            xlsheet.Range(xlsheet.Cells(4, icolpos), xlsheet.Cells(5, icolpos)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                            xlsheet.Range(xlsheet.Cells(4, icolpos), xlsheet.Cells(5, icolpos)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenterAcrossSelection
                            xlsheet.Range(xlsheet.Cells(4, icolpos), xlsheet.Cells(5, icolpos)).Merge()
                        End If

                    End If
                Else
                    If (grd.GetData(2, mArrList(k)).GetType().ToString().ToLower().Contains("string")) Then
                        Select Case grd.GetData(2, mArrList(k))
                            Case "差异"
                                xlsheet.Cells(i + 1, icolpos).ColumnWidth = 5
                                xlsheet.Cells(i + 1, icolpos).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter    '垂直方向
                                xlsheet.Cells(i + 1, icolpos).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight    '水平方向 
                                xlsheet.Cells(i + 1, icolpos).ColumnWidth = xlApp.CentimetersToPoints(0.2)
                                'xlsheet.Cells(i + 1, icolpos).ColumnWidth = 2
                                xlsheet.Cells(i + 1, icolpos).ShrinkToFit = False
                                xlsheet.Cells(i + 1, icolpos).NumberFormatLocal = "@"
                            Case "备注"
                                ''xlsheet.Cells(i + 1, icolpos).ColumnWidth = 10
                                'xlsheet.Cells(i + 1, icolpos).ShrinkToFit = True
                                xlsheet.Cells(i + 1, icolpos).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter    '垂直方向
                                xlsheet.Cells(i + 1, icolpos).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight    '水平方向 
                                'xlsheet.Cells(i + 1, icolpos).ColumnWidth = xlApp.CentimetersToPoints(0.2)
                                xlsheet.Cells(i + 1, icolpos).WrapText = True
                                'add by pj 20130330
                                xlsheet.Range(xlsheet.Cells(i + 1, icolpos), xlsheet.Cells(i + 1, icolpos)).EntireColumn.AutoFit() '自动调整列宽
                            Case "实际"
                                xlsheet.Cells(i + 1, icolpos).ColumnWidth = 5
                                xlsheet.Cells(i + 1, icolpos).ColumnWidth = xlApp.CentimetersToPoints(0.2)
                                xlsheet.Cells(i + 1, icolpos).ShrinkToFit = False
                                'xlsheet.Cells(i + 1, icolpos).ColumnWidth = 2
                            Case "数量"
                                xlsheet.Cells(i + 1, icolpos).ColumnWidth = 4
                                'xlsheet.Cells(i + 1, icolpos).ColumnWidth = xlApp.CentimetersToPoints(0.2)
                                xlsheet.Cells(i + 1, icolpos).ShrinkToFit = False
                            Case "序号"
                                xlsheet.Cells(i + 1, icolpos).ColumnWidth = 4
                                'xlsheet.Cells(i + 1, icolpos).ColumnWidth = xlApp.CentimetersToPoints(0.2)
                                xlsheet.Cells(i + 1, icolpos).ShrinkToFit = False
                            Case "尺码"
                                xlsheet.Cells(i + 1, icolpos).ColumnWidth = 5
                                'xlsheet.Cells(i + 1, icolpos).ColumnWidth = xlApp.CentimetersToPoints(0.2)
                                xlsheet.Cells(i + 1, icolpos).ShrinkToFit = False
                        End Select
                    End If
                End If
                xlsheet.Cells(i + 1, icolpos) = IIf(grd.GetData(i - 2, mArrList(k)).ToString().IndexOf("/") > 0, Left(grd.GetData(i - 2, mArrList(k)).ToString(), 2), grd.GetData(i - 2, mArrList(k)).ToString())
            Next
        Next

        '设置数量与尺码两列的值居中 add by pj 20121225
        For i = 5 To rowcount
            icolpos = 0
            For k = 0 To ColCount - 1
                icolpos = icolpos + 1
                '将值为0的单元格清空
                If xlsheet.Cells(i, icolpos).Value = "0" Then
                    xlsheet.Cells(i, icolpos) = ""
                End If

                If xlsheet.Cells(4, icolpos).Value = "数量" Or xlsheet.Cells(4, icolpos).Value = "尺码" Then
                    xlsheet.Cells(i, icolpos).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter    '垂直方向
                    xlsheet.Cells(i, icolpos).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter    '水平方向
                End If
            Next
        Next

        xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(rowcount, icolpos)).Font.Bold = True '设置字体加粗 add by pj 20121225
        xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(rowcount, icolpos)).Font.Name = "黑体"

        'xlsheet.Range(xlsheet.Cells(1, 1), xlsheet.Cells(rowcount, icolpos)).Font.Size = 14 '设置字体大小 add by pj 20130129

        'xlsheet.PageSetup.Zoom = 80
        'xlsheet.PageSetup.TopMargin = 3
        xlsheet.PageSetup.LeftMargin = 30
        xlsheet.PageSetup.RightMargin = 0.0000001
        xlsheet.PageSetup.BottomMargin = 0.01

        '指定第三到第五列为表头每页都打印  add by pj 20130330
        xlsheet.PageSetup.PrintTitleRows = "$1:$5"
        xlsheet.PageSetup.PrintTitleColumns = ""

        '保存Excel
        xlBook.Save()

        '导出Excel数据表  zxp 20130418
        If IfoutExcel Then
            Dim FileName As String = ((DateTime.Now.ToString().Replace(" ", "")).Replace("-", "")).Replace(":", "")
            Dim shl = CreateObject("Shell.application")
            Dim fd = shl.browseforfolder(0, "请选择你要保持的文件的路径", 0, "\")
            If Not fd Is Nothing Then
                xlBook.SaveCopyAs(fd.self.path + "\制服尺寸" + mCode + ".XLS")
                'xlBook.SaveAs(fd.self.path, Excel.XlFileFormat.xlExcel7, Nothing, Nothing, False, False, Excel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing)
            End If
            Exit Function
        End If


        xlApp.ActiveWindow.View = Excel.XlWindowView.xlPageBreakPreview 'xlPageBreakPreview

        '增加表格线 
        With xlsheet
            '.Range(.Cells(1, 1), .Cells(rowcount, icolpos)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous  'Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous 'xlContinuous

            '注释
            '.Range(.Cells(1, 1), .Cells(rowcount, icolpos)).Columns.AutoFit()

            .Range(.Cells(1, 1), .Cells(2, icolpos)).Borders.LineStyle = Excel.XlLineStyle.xlLineStyleNone

            '.PageSetup.Zoom = 80

            .PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4

            .PageSetup.FitToPagesTall = 1
            '注释
            .PageSetup.FitToPagesWide = 1
            .PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape

            .PageSetup.PrintArea = .Range(.Cells(1, 1), .Cells(rowcount, icolpos)).Address

            If (.VPageBreaks.Count > 0) Then
                .VPageBreaks(1).DragOff(Excel.XlDirection.xlToRight, 1)
                '.Range(.Cells(1, 1), .Cells(rowcount, icolpos)).ColumnWidth = xlApp.CentimetersToPoints(0.35)
                'For mPageCount As Integer = 1 To .VPageBreaks.Count
                '    .VPageBreaks(mPageCount).DragOff(Excel.XlDirection.xlToRight, RegionIndex:=1)
                'Next
            End If


            .PageSetup.TopMargin = 50
            '注销
            '.PageSetup.LeftMargin = 30
            '.PageSetup.RightMargin = 0.3 / 0.035
            '.PageSetup.LeftMargin = 0.2
            '.PageSetup.RightMargin = 0.0000002
            '.PageSetup.BottomMargin = 0.5 / 0.035


            '.PageSetup.CenterHorizontally = True
            '.Range(.Cells(1, 1), .Cells(rowcount, icolpos)).EntireColumn.AutoFit()
        End With

        '打印预览
        'If bPrintPreview Then
        '    'xlBook.Sheets.PrintPreview()
        '    xlApp.ActiveSheet.PrintPreview()
        'End If

        'xlBook.PrintOut(1, 1, False, False, Nothing, Nothing, Nothing, False)

        If bPrintPreview Then
            '打印预览
            xlApp.Visible = True
            xlApp.ActiveSheet.PrintPreview()
        Else
            'Excel打印输出 暂时注释 by pj 20121223
            xlBook.PrintOut()
        End If

        '重新刷新网格数据 add by pj 20121230
        If bCombinePrt = True Then
            'DelAllRows(grd)
            SetDataGrid(OldSourceTab, grd, OldDataTable, OrigGolTmp)
            '清理DataTable针对合并打印新增的数据列
            Dim dcol As Integer
            dcol = m_DataTab.Columns.Count - 1
            Do While dcol > 0
                Select Case m_DataTab.Columns(dcol).ColumnName
                    Case "newSCode"
                        m_DataTab.Columns.Remove(m_DataTab.Columns(dcol).ColumnName)
                    Case "CombineRel"
                        m_DataTab.Columns.Remove(m_DataTab.Columns(dcol).ColumnName)
                    Case "DCol"
                        m_DataTab.Columns.Remove(m_DataTab.Columns(dcol).ColumnName)
                    Case "DSCode"
                        m_DataTab.Columns.Remove(m_DataTab.Columns(dcol).ColumnName)
                End Select
                dcol = dcol - 1
            Loop
        End If

        'xlApp.ActiveSheet.PrintPreview()

        '  xlApp.DisplayAlerts = True
        'myexcel.activesheet.PageSetup.OrientaTion=2（1纵向）

        '45 单元格居中： cells(2,1).HorizontalAlignment=Excel.XlHAlign.xlHAlignCenter 水平方向 

        'cells(2,1).VerticalAlignment=Excel.XlVAlign.xlVAlignCenter 垂直方向

        'xlBook.Close   False                   '不提示保存就关闭 
        'xlBook.SaveAs("C:\\book1.XLS", Nothing, Nothing, Nothing, Nothing, Nothing, Excel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing)


        'Dim FilePath As Object = "C:\U8SOFT\EAI\TEMP\EXCEL.XLS"

        'If (System.IO.File.Exists(FilePath)) Then
        '    System.IO.File.Delete(FilePath)
        'End If

        'xlBook.SaveAs(FilePath, Excel.XlFileFormat.xlExcel7, Nothing, Nothing, False, False, Excel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing)

        xlsheet = Nothing
        xlBook.Close(False, Nothing, Nothing)

        Dim mbookcount As Integer = 0


        mbookcount = xlApp.Workbooks.Count

        xlApp.Workbooks.Close()

        If (mbookcount = 0) Then
            xlApp.Quit()
            KillExcel()
        End If


        xlBook = Nothing
        xlApp = Nothing

        GC.Collect()

        flexgridtoexcel = True
        Exit Function
errhandle:
        flexgridtoexcel = False
        MsgBox(Err.Description)
        'MsgBox("报表数据生成异常，请与用友技术支持联系")
    End Function


    'Public Function PrintPriviewExcelFile(ByVal filePath As String)
    '    Dim xlApp As Excel.ApplicationClass
    '    xlApp = New Excel.ApplicationClass()
    '    xlApp.Visible = True
    '    Dim oMissing As Object
    '    oMissing = System.Reflection.Missing.Value
    '    Dim xlWorkbook As Excel.Workbook
    '    xlWorkbook = xlApp.Workbooks.Open(filePath, 0, True, 5, oMissing, oMissing, True, 1, oMissing, False, False, oMissing, False)
    '        Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Worksheets[1];

    '        xlWorksheet.PrintPreview(null);
    '        xlApp.Visible = false;
    '        xlWorksheet = null;
    'End Function


    '返回C1FLEXGRID显示的列数
    Private Function getColCount(ByVal grd As C1FlexGrid) As ArrayList

        Dim mArrayList As New ArrayList

        For col As Integer = 0 To grd.Cols.Count - 1
            If (grd.Cols(col).Visible = True) Then
                mArrayList.Add(col)
            End If
        Next

        Return mArrayList

    End Function


    '取得合并单元格的位置
    Private Function GetMergeCell(ByVal mCellV As Object, ByVal mStartIndex As Integer, ByVal mArrList As ArrayList) As Integer

        Dim mdbtab As New DataTable()
        If (Me.C1FlexGrid1.DataSource Is Nothing) Then
            GetMergeCell = -1
        Else
            'mdbtab = Me.C1FlexGrid1.DataSource
            Dim mEndindex As Integer = -1
            'Dim mEndindex1 As Integer = mStartIndex + 1

            For min As Integer = mStartIndex + 1 To mArrList.Count - 1

                If (mCellV = C1FlexGrid1.GetData(0, mArrList(min))) Then
                    mEndindex = min
                    Continue For
                End If

                If (mStartIndex < min) Then
                    Exit For
                End If
            Next


            If (mStartIndex = mArrList.Count - 1) Then
                If (mCellV = C1FlexGrid1.GetData(0, mStartIndex - 1)) Then
                    mEndindex = mArrList.Count - 1
                End If
            End If

            GetMergeCell = mEndindex
        End If
    End Function


    '取得合并单元格的位置
    Private Function GetMergeCell(ByVal mCellV As Object, ByVal mStartIndex As Integer, ByVal grd As C1FlexGrid, ByVal mrowid As Integer, ByVal mArrList As ArrayList) As Integer

        Dim mdbtab As New DataTable()
        If (Me.C1FlexGrid1.DataSource Is Nothing) Then
            GetMergeCell = -1
        Else
            mdbtab = Me.C1FlexGrid1.DataSource
            Dim mEndindex As Integer = -1
            'Dim mEndindex1 As Integer = mStartIndex + 1

            For min As Integer = mStartIndex + 1 To mArrList.Count - 1

                'If (Me.C1FlexGrid1.Cols(min).Visible = True) Then
                '    mEndindex1 += 1
                'End If

                If (mCellV = grd.GetData(mrowid, mArrList(min))) Then
                    mEndindex = min
                    Continue For

                End If

                If (mStartIndex < min) Then
                    Exit For
                End If
            Next

            If (mStartIndex = mArrList.Count - 1) Then
                If (mCellV = grd.GetData(mrowid, mStartIndex - 1)) Then
                    mEndindex = mArrList.Count - 1
                End If
            End If

            GetMergeCell = mEndindex

        End If
    End Function

    '处理隐藏列打印临时表
    Public Function GetSortTab(ByVal Cols As Integer, ByVal DataTab As DataTable, ByVal bVisible As Boolean) As DataTable
        If Not bVisible Then
            DataTab.Columns.RemoveAt(Cols)
            DataTab.AcceptChanges()
        End If
        GetSortTab = DataTab
    End Function

    '同步更新全部显示状态临时表
    Public Sub UpdateGolDispTable(ByVal SortIndex As Integer, ByRef GolDt As DataTable, ByVal bSel As Boolean)
        GolDt.Rows(SortIndex)("IsDisp") = bSel
        GolDt.AcceptChanges()
    End Sub
End Class
