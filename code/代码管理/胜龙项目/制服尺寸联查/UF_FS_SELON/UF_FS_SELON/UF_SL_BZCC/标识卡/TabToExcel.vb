Module TabToExcel


    Public Sub DataTabToExcel(ByVal mDTab As DataTable, ByVal mPath As String, ByVal mMocode As String, ByVal isPrint As Boolean, ByVal mIsPrintDept As Boolean, ByVal MarkToExcel As Boolean)

        On Error GoTo errhandle

        Dim mExcelApp = GetExcel()

        Dim ColCount As Integer = 10
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

        xlBook = xlApp.Workbooks.Add

        xlBook = xlApp.Workbooks(1)

        xlsheet = xlBook.Worksheets(1)

        xlsheet.Cells(1, 1) = mMocode
        rowcount = 1

        Dim mBxtab = mDTab.DefaultView.ToTable(True, "dName")

        If (mBxtab.Rows.Count > 0) Then

            For Each mRow As DataRow In mBxtab.Rows
                rowcount += 1
                xlsheet.Cells(rowcount, 1) = mRow("dName").ToString()
                Dim mrRow() As DataRow
                mrRow = mDTab.Select("dName='" + mRow("dName").ToString() + "'")

                Dim mMod As Int32 = Math.Ceiling(mrRow.Length / 10)

                For mrindex As Integer = 1 To mMod
                    rowcount = rowcount + 1

                    For mAdindex As Integer = 1 To 10

                        If ((mrindex - 1) * 10 + mAdindex - 1 <= mrRow.Length - 1) Then
                            xlsheet.Cells(rowcount, mAdindex) = mMocode
                            If (mIsPrintDept) Then
                                xlsheet.Cells(rowcount + 1, mAdindex) = mrRow((mrindex - 1) * 10 + mAdindex - 1)("cDepName").ToString()
                                xlsheet.Cells(rowcount + 2, mAdindex).NumberFormatLocal = "@"
                                xlsheet.Cells(rowcount + 2, mAdindex) = mrRow((mrindex - 1) * 10 + mAdindex - 1)("cPid").ToString()
                                xlsheet.Cells(rowcount + 3, mAdindex) = mrRow((mrindex - 1) * 10 + mAdindex - 1)("cName").ToString()
                            Else
                                xlsheet.Cells(rowcount + 1, mAdindex).NumberFormatLocal = "@"
                                xlsheet.Cells(rowcount + 1, mAdindex) = mrRow((mrindex - 1) * 10 + mAdindex - 1)("cPid").ToString()
                                xlsheet.Cells(rowcount + 2, mAdindex) = mrRow((mrindex - 1) * 10 + mAdindex - 1)("cName").ToString()
                            End If

                        Else
                            xlsheet.Cells(rowcount + 1, mAdindex) = ""
                            xlsheet.Cells(rowcount + 2, mAdindex) = ""
                            If (mIsPrintDept) Then
                                xlsheet.Cells(rowcount + 3, mAdindex) = ""
                            End If
                        End If

                        'xlsheet.Cells(rowcount, mAdindex).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        'xlsheet.Cells(rowcount, mAdindex).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        'xlsheet.Cells(rowcount + 1, mAdindex).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        'xlsheet.Cells(rowcount + 1, mAdindex).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                        'xlsheet.Cells(rowcount + 2, mAdindex).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
                        'xlsheet.Cells(rowcount + 2, mAdindex).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                        'If (mIsPrintDept) Then
                        '    xlsheet.Cells(rowcount + 3, mAdindex) = ""
                        'End If

                        xlsheet.Cells(rowcount, mAdindex).ShrinkToFit = True

                    Next

                    If (mIsPrintDept) Then
                        rowcount = rowcount + 3
                    Else
                        rowcount = rowcount + 2
                    End If

                Next
                rowcount += 1
                xlsheet.Cells(rowcount, 1) = "  "
            Next

        End If


        '标识卡导出功能  zxp20130418

        If MarkToExcel Then

            'Dim FileName As String = "标识卡" + ((DateTime.Now.ToString().Replace(" ", "")).Replace("-", "")).Replace(":", "")
            Dim FileName = "标识卡" + mMocode
            Dim shl = CreateObject("Shell.application")
            Dim fd = shl.browseforfolder(0, "请选择你要保存的文件的路径", 0, "\")
            If Not fd Is Nothing Then
                xlBook.SaveCopyAs(fd.self.path + "\" + FileName + ".XLS")
                'xlBook.SaveAs(fd.self.path, Excel.XlFileFormat.xlExcel7, Nothing, Nothing, False, False, Excel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing)
            End If
            Exit Sub
        End If

        'End

        xlApp.ActiveWindow.View = Excel.XlWindowView.xlPageBreakPreview

        With xlsheet

            .Range(.Cells(1, 1), .Cells(rowcount, 10)).ColumnWidth = 9.13

            .Range(.Cells(1, 1), .Cells(rowcount, 10)).RowHeight = 19

            .Range(.Cells(1, 1), .Cells(rowcount, 10)).Font.Bold = True

            .Range(.Cells(1, 1), .Cells(rowcount, 10)).Font.Size = 11


            .Range(.Cells(2, 1), .Cells(rowcount, 10)).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            .Range(.Cells(2, 1), .Cells(rowcount, 10)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

            .PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4

            .PageSetup.Orientation = 1

            .PageSetup.PrintArea = .Range(.Cells(1, 1), .Cells(rowcount, 10)).Address


            .PageSetup.TopMargin = 0.5 / 0.035
            .PageSetup.LeftMargin = 0.2 / 0.035
            .PageSetup.RightMargin = 0
            .PageSetup.BottomMargin = 0


            '.PageSetup.CenterHorizontally = True
            ' .Range(.Cells(1, 1), .Cells(rowcount, 10)).EntireColumn.AutoFit()
            '
        End With


        If (isPrint) Then
            xlBook.PrintOut()
        Else
            xlApp.Visible = True
            xlBook.PrintPreview(False)
        End If

        Dim mFileName = mPath + "\MyExcelSignCard.xls"


        If (System.IO.File.Exists(mFileName)) Then
            System.IO.File.Delete(mFileName)
        End If

        xlApp.DisplayAlerts = False

        xlBook.Save()

        xlBook.SaveAs(mFileName, Excel.XlFileFormat.xlExcel7, Nothing, Nothing, False, False, Excel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing)


        System.Threading.Thread.Sleep(1000)


        xlBook.Close(True, mFileName, Nothing)

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

        Exit Sub

errhandle:
        MsgBox(Err.Description)

    End Sub


End Module
