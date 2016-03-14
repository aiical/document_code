Imports C1.Win.C1FlexGrid
Imports System.Data
Imports System.Data.SqlClient


Module MdlCommon

    Public txtConSQL As String '存放SQL语句
    Public DBSet As DataSet '查询得到的记录集 
    Public DbTab As DataTable '查询得到的记录表
    Public ErrorMsg As String '存放错误信息 
    Public mCnn As SqlClient.SqlConnection '数据连接对象
    Public madpt As SqlClient.SqlDataAdapter '数据适配器
    Public currDB As String '当前数据库
    Private m_C1Flex As C1FlexGrid  '控件信息


    Public Function GetCurrentDB(ByVal strDB As String) As String
        Dim words As String() = (strDB.ToUpper()).Split(New Char() {";"c})
        Dim word As String
        Dim sFlag As String = ("CATALOG=UFDATA_").ToUpper()
        For Each word In words
            If InStr(1, word, sFlag) Then
                GetCurrentDB = Right(word, Len(word) - InStr(1, word, "="))
                Exit Function
            End If
        Next
        GetCurrentDB = ""
    End Function

    Public Function GetSizemainTab(ByVal mCode As String, ByVal mcnn As SqlClient.SqlConnection, ByVal mCmdType As CommandType, ByVal mCmdText As String) As DataTable

        Dim mCmd = New SqlCommand()

        Dim adpt As SqlClient.SqlDataAdapter

        Dim mTable As New DataSet()
        Dim dv As New DataView

        mCmd.CommandType = mCmdType
        mCmd.Connection = mcnn

        If (mCmdType = CommandType.Text) Then
            mCmd.CommandText = mCmdText '"select cDepName,cName,isex,* from selonuinform.dbo.v_Tailordetail  where sacode='" + mCode + "'  order by iRowNo "
        Else
            mCmd.CommandText = "Get_v_Tailorsizes"
            mCmd.Parameters.Add(New SqlParameter("@cSocode", SqlDbType.NVarChar, 60, ParameterDirection.Input))
            mCmd.Parameters(0).Value = mCode
        End If

        Try
            adpt = New SqlDataAdapter(mCmd)
            adpt.Fill(mTable)

            Dim smid As Integer
            smid = 0
            For Each mrow As DataRow In mTable.Tables(0).Rows
                smid += 1
                mrow("cCode") = mrow("cCode") + smid.ToString()
            Next
            'GetSizemainTab = mTable.Tables(0)
            '默认按制服类型编码排序 add by pj 20130115
            dv = mTable.Tables(0).DefaultView
            'dv.Sort = "cCode"
            GetSizemainTab = dv.ToTable("GetSizemainTab")


        Catch ex As Exception
            GetSizemainTab = Nothing
        End Try

    End Function
    '标示卡重新获取数据，脱离制服打印调用同一个函数的耦合度  20130417 zxp
    Public Function GetMarkmainTab(ByVal mCode As String, ByVal mcnn As SqlClient.SqlConnection, ByVal mCmdType As CommandType, ByVal mCmdText As String) As DataTable

        Dim mCmd = New SqlCommand()

        Dim adpt As SqlClient.SqlDataAdapter

        Dim mTable As New DataSet()
        Dim dv As New DataView

        mCmd.CommandType = mCmdType
        mCmd.Connection = mcnn

        If (mCmdType = CommandType.Text) Then
            mCmd.CommandText = mCmdText '"select cDepName,cName,isex,* from selonuinform.dbo.v_Tailordetail  where sacode='" + mCode + "'  order by iRowNo "
        Else
            mCmd.CommandText = "Get_v_Tailorsizes"
            mCmd.Parameters.Add(New SqlParameter("@cSocode", SqlDbType.NVarChar, 60, ParameterDirection.Input))
            mCmd.Parameters(0).Value = mCode
        End If

        Try
            adpt = New SqlDataAdapter(mCmd)
            adpt.Fill(mTable)

            'Dim smid As Integer
            'smid = 0
            'For Each mrow As DataRow In mTable.Tables(0).Rows
            '    smid += 1
            '    mrow("cCode") = mrow("cCode") + smid.ToString()
            'Next
            'GetSizemainTab = mTable.Tables(0)
            '默认按制服类型编码排序 add by pj 20130115
            dv = mTable.Tables(0).DefaultView
            'dv.Sort = "cCode"
            GetMarkmainTab = dv.ToTable("GetSizemainTab")


        Catch ex As Exception
            GetMarkmainTab = Nothing
        End Try

    End Function


    '设置数据列表的格式
    Public Function SetDataGridFormat(ByVal mDataGrid As C1FlexGrid) As Boolean

        Try
            If (mDataGrid.Cols.Count > 0) Then

                'mDataGrid.Cols(0).Visible = False

                mDataGrid.Cols(0).Width = 30

                Dim cs As C1.Win.C1FlexGrid.CellStyle

                cs = mDataGrid.Styles(CellStyleEnum.Fixed)

                cs.BackColor = Drawing.Color.FromArgb(192, 227, 255)

                cs = mDataGrid.Styles(CellStyleEnum.EmptyArea)

                cs.BackColor = Drawing.Color.FromArgb(200, 216, 240)

                cs = mDataGrid.Styles(CellStyleEnum.Focus)

                cs.BackColor = Drawing.Color.DeepSkyBlue

                'Drawing.Color.FromArgb(200, 216, 240)

                mDataGrid.Cols.Frozen = 4

                mDataGrid.Rows.Fixed = 3

                ' mDataGrid.AllowEditing = False

                mDataGrid.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.FixedOnly
                mDataGrid.Rows(0).AllowMerging = True
                mDataGrid.Cols(0).AllowMerging = True
                mDataGrid.Rows(1).AllowMerging = True
                mDataGrid.Rows(2).AllowMerging = True



                mDataGrid.AllowSorting = AllowSortingEnum.None

                'mDataGrid.Styles.Alternate.TextAlign = TextAlignEnum.CenterCenter

                mDataGrid.Styles.Fixed.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter

                mDataGrid.AutoSizeCols(1, mDataGrid.Cols.Count - 1, 10)

            End If


        Catch ex As Exception

        End Try

    End Function


    '设置表头列序号
    Public Function SetDataGrid(ByVal mDataset As DataTable, ByVal mDataGrid As C1FlexGrid, ByVal mSetgridtab As DataTable, Optional ByVal GolDispDT As DataTable = Nothing) As Boolean

        'Dim rowindex As Integer 'add by pj 20121223

        SetDataGridFormat(mDataGrid)
        If (mDataset Is Nothing) Then
            Exit Function
        Else
            mDataGrid.DataSource = mDataset
            Dim ran As C1.Win.C1FlexGrid.CellRange

            mDataGrid.Cols(0).Caption = "序号"
            mDataGrid.Cols(1).Caption = "工号"
            mDataGrid.Cols(2).Caption = "部门"
            mDataGrid.Cols(3).Caption = "姓名"
            mDataGrid.Cols(4).Caption = "性别"

            mDataGrid.Cols(0).AllowEditing = False
            mDataGrid.Cols(1).AllowEditing = False
            mDataGrid.Cols(2).AllowEditing = False
            mDataGrid.Cols(3).AllowEditing = False
            mDataGrid.Cols(4).AllowEditing = False

            If (mDataset.Rows.Count > 0) Then

                mDataGrid.Cols(0).AllowMerging = True

                ran = mDataGrid.GetCellRange(0, 0, 3, 0)
                ran.Data = "序号"
                For mRow As Integer = 1 To mDataset.Rows.Count Step 1
                    ran = mDataGrid.GetCellRange(mRow + 2, 0)
                    ran.Data = mRow.ToString()
                Next

                Dim ran1 As C1.Win.C1FlexGrid.CellRange
                mDataGrid.Cols(1).AllowMerging = True

                '判断列显示设置临时表是否有数据存在
                If Not GolDispDT Is Nothing Then
                    mDataGrid.Cols(1).Visible = GetDispSelValue("工号", GolDispDT)
                Else
                    mDataGrid.Cols(1).Visible = False
                End If

                ran1 = mDataGrid.GetCellRange(0, 1, 2, 1)
                ran1.Data = "工号"

                Dim ran11 As C1.Win.C1FlexGrid.CellRange
                mDataGrid.Cols(2).AllowMerging = True
                '判断列显示设置临时表是否有数据存在
                If Not GolDispDT Is Nothing Then
                    mDataGrid.Cols(2).Visible = GetDispSelValue("部门", GolDispDT)
                Else
                    mDataGrid.Cols(2).Visible = False
                End If

                ran11 = mDataGrid.GetCellRange(0, 2, 2, 2)
                ran11.Data = "部门"

                mDataGrid.Cols(3).AllowMerging = True
                ran = mDataGrid.GetCellRange(0, 3, 2, 3)
                ran.Data = "姓名"

                mDataGrid.Cols(4).AllowMerging = True
                '判断列显示设置临时表是否有数据存在
                If Not GolDispDT Is Nothing Then
                    mDataGrid.Cols(4).Visible = GetDispSelValue("性别", GolDispDT)
                Else
                    mDataGrid.Cols(4).Visible = False
                End If

                ran = mDataGrid.GetCellRange(0, 4, 2, 4)
                ran.Data = "性别"


            End If


            For mci As Integer = 5 To mDataset.Columns.Count Step 1

                'If Convert.ToInt16(mDataset.Columns(mci - 1).ColumnName.Substring(mDataset.Columns(mci - 1).ColumnName.Length - 1, 1)) > 0 Then
                '    rowindex = Convert.ToInt16(mDataset.Columns(mci - 1).ColumnName.Substring(mDataset.Columns(mci - 1).ColumnName.Length - 1, 1))
                'End If

                mDataGrid.Cols(mci).Caption = mDataset.Columns(mci - 1).Caption

                mDataGrid.Cols(mci).AllowEditing = False

                If (Not mSetgridtab.Select("BxMc='" + mDataset.Columns(mci - 1).Caption + "'").Length > 0) Then
                    mDataGrid.Cols(mci).Visible = False
                Else
                    mDataGrid.Cols(mci).Visible = True
                End If

                If (mDataset.Columns(mci - 1).ColumnName.Substring(1).ToLower().Contains("iquantity")) Then

                    mDataGrid.Cols(mci).AllowMerging = True
                    mDataGrid.Cols(mci).TextAlign = TextAlignEnum.CenterCenter
                    ran = mDataGrid.GetCellRange(1, mci, 2, mci)
                    ran.Data = "数量"
                Else
                    If (mDataset.Columns(mci - 1).ColumnName.Substring(1).ToLower().Contains("cdfname")) Then

                        mDataGrid.Cols(mci).AllowMerging = True
                        mDataGrid.Cols(mci).TextAlign = TextAlignEnum.CenterCenter
                        ran = mDataGrid.GetCellRange(1, mci, 2, mci)
                        ran.Data = "尺码"
                    ElseIf (mDataset.Columns(mci - 1).ColumnName.Substring(1).ToLower().Contains("calias")) Then
                        mDataGrid.Cols(mci).AllowMerging = True
                        mDataGrid.Cols(mci).Visible = False
                        ran = mDataGrid.GetCellRange(1, mci, 2, mci)
                        ran.Data = "尺码排序"
                    ElseIf (mDataset.Columns(mci - 1).ColumnName.Substring(1).ToLower().Contains("cinvcode")) Then

                        mDataGrid.Cols(mci).AllowMerging = True
                        mDataGrid.Cols(mci).Visible = False
                        ran = mDataGrid.GetCellRange(1, mci, 2, mci)
                        ran.Data = "存货编码"

                    Else
                        If (mDataset.Columns(mci - 1).ColumnName.Substring(1).ToLower().Contains("cremark")) Then
                            mDataGrid.Cols(mci).AllowMerging = True
                            mDataGrid.Cols(mci).AllowEditing = True

                            ran = mDataGrid.GetCellRange(1, mci, 2, mci)
                            ran.Data = "备注"

                        Else

                            Dim mCN As String = String.Empty
                            mDataGrid.Rows(2).AllowMerging = False

                            mDataGrid.Cols(mci).Style.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter

                            If (mDataset.Columns(mci - 1).ColumnName.Substring(1).ToLower().Contains("idefine")) Then
                                mDataGrid.SetData(2, mci, "差异") ' + (mci - 1).ToString())
                                mCN = "idefine"
                            Else
                                mDataGrid.SetData(2, mci, "实际")
                                mCN = "define_"
                            End If

                            'If (mDataset.Columns(mci - 1).ColumnName.Substring(1).ToLower().Contains("define")) Then

                            '    mDataGrid.SetData(2, mci, "实际")
                            '    mCN = "Define"
                            'End If


                            If (mSetgridtab.Select("BxMc='" + mDataset.Columns(mci - 1).Caption + "'").Length > 0) Then
                                mCN = mSetgridtab.Select("BxMc='" + mDataset.Columns(mci - 1).Caption + "'")(0)("cCode").ToString().ToLower() + mCN
                                mCN = mDataset.Columns(mci - 1).ColumnName.ToLower().Replace(mCN, "")
                                mDataGrid.SetData(1, mci, mSetgridtab.Select("BxMc='" + mDataset.Columns(mci - 1).Caption + "'")(0)("cdefine" + mCN).ToString())
                            End If
                        End If
                    End If
                End If
            Next
        End If
    End Function

    'add by pj 20121227  获取字符串中的数字
    Function GetNumByStr(ByVal Srg As String, Optional ByVal n As Integer = False, _
            Optional ByVal start_num As Integer = 1) As String
        Dim i As Integer
        Dim s As String
        Dim MyString As String
        Dim Bol As Boolean

        For i = start_num To Len(Srg)
            s = Mid(Srg, i, 1)
            If n = 1 Then
                Bol = Asc(s) < 0           '分離漢字
            ElseIf n = 2 Then
                Bol = s Like "[a-z,A-Z, ]" '分離字母
            ElseIf n = 0 Then
                Bol = s Like "#"           '分離數字
            End If
            If Bol Then MyString = MyString & s
        Next
        GetNumByStr = IIf(n = 1 Or n = 2, MyString, MyString)
    End Function

    'add by pj 20121227 清除短袖版型对应的值
    Public Sub ClearAllValue(ByVal m_DataTab As DataTable, ByVal cCode As String, ByVal rowindex As Integer)
        For Each col As DataColumn In m_DataTab.Columns
            If Left(col.ColumnName, 2) = cCode Then
                m_DataTab.Rows(rowindex)(col.ColumnName) = DBNull.Value
                m_DataTab.AcceptChanges()
            End If
        Next
    End Sub

    '删除DataTable中的指定列 add by pj 20121230
    Public Sub DelDataTableCols(ByVal m_GridDataTab As DataTable, ByVal m_SourceTab As DataTable, ByRef GolT As DataTable)
        Dim ColIndex, icol As Integer
        icol = m_GridDataTab.Columns.Count - 1
        For Each sRow As DataRow In m_SourceTab.Rows
            If Not sRow.IsNull("CombineRel") Then
                Do While icol >= 5
                    If Left(m_GridDataTab.Columns(icol).ColumnName, 2) = sRow("DCol") Then
                        ColIndex = icol
                        m_GridDataTab.Columns.Remove(m_GridDataTab.Columns(icol).ColumnName)

                        If Not GolT Is Nothing Then
                            GolT.Rows.RemoveAt(icol)
                            GolT.AcceptChanges()
                        End If
                        m_GridDataTab.AcceptChanges()
                    End If
                    icol = icol - 1
                Loop
            End If
        Next
        '删除隐藏列信息 20130402
        'For Each sRow As DataRow In m_SourceTab.Rows
        '    Do While icol >= 5
        '        If m_C1Flex.Cols(icol).Visible = False Then
        '            ColIndex = icol
        '            m_GridDataTab.Columns.Remove(m_GridDataTab.Columns(icol).ColumnName)
        '            'm_GridDataTab.AcceptChanges()
        '        End If
        '    Loop
        'Next
    End Sub

    '删除网格中所有数据行(含二维列头) add by pj 20121230
    Public Sub DelAllRows(ByVal C1FlexGrid1 As C1FlexGrid)
        For r As Integer = 0 To C1FlexGrid1.Rows.Count - 1
            'If C1FlexGrid1.Rows.Count > 3 Then
            C1FlexGrid1.Rows.Remove(0)
            'End If
        Next
    End Sub

    '错误提示处理，发挥错误提示字符串 by pj 20121230
    Private Function ErrMsg(ByVal CusName As String, ByVal CAlias As String, ByVal DAlias As String, ByVal position As String) As String
        ErrMsg = "客户人员 " & CusName & " 长袖版型 " & CAlias & " 与短袖版型 " & DAlias & position & " 的数值不匹配，不能合并打印，是否继续打印?"
    End Function

    'add by pj 20121227 检查合并打印是否符合合并条件
    Public Function CheckCombineIsSuccess(ByVal m_OrigTab As DataTable, ByVal m_DataSourece As DataTable) As String
        CheckCombineIsSuccess = ""
        For Each r_tab As DataRow In m_OrigTab.Rows
            For Each r_source As DataRow In m_DataSourece.Rows
                If Not r_tab.IsNull("CombineRel") Then
                    '当前客户员工都具有长短袖版型时才进行合并打印合法性验证
                    If Not r_source.IsNull(r_tab("cCode") + "cInvCode") And Not r_source.IsNull(r_tab("DCol") + "cInvCode") Then
                        '比较尺码
                        If Not (r_source(r_tab("cCode") + "cDfName") = r_source(r_tab("DCol") + "cDfName")) Then
                            CheckCombineIsSuccess = ErrMsg(r_source("cName"), r_tab("newSCode"), r_tab("DSCode").ToString(), "尺码")
                            Exit Function
                        End If
                        '比较版型号
                        If Not (r_source(r_tab("cCode") + "cAlias") = r_source(r_tab("DCol") + "cAlias")) Then
                            CheckCombineIsSuccess = ErrMsg(r_source("cName"), r_tab("newSCode"), r_tab("DSCode").ToString(), "版型号")
                            Exit Function
                        End If
                        '比较领围实际
                        If Not (r_source(r_tab("cCode") + "Define_1") = r_source(r_tab("DCol") + "Define_1")) Then
                            CheckCombineIsSuccess = ErrMsg(r_source("cName"), r_tab("newSCode"), r_tab("DSCode").ToString(), "领围实际尺寸")
                            Exit Function
                        End If
                        '比较领围差异
                        If Not (r_source(r_tab("cCode") + "iDefine1") = r_source(r_tab("DCol") + "iDefine1")) Then
                            CheckCombineIsSuccess = ErrMsg(r_source("cName"), r_tab("newSCode"), r_tab("DSCode").ToString(), "领围差异尺寸")
                            Exit Function
                        End If
                        '比较后衫长实际
                        If Not (r_source(r_tab("cCode") + "Define_2") = r_source(r_tab("DCol") + "Define_2")) Then
                            CheckCombineIsSuccess = ErrMsg(r_source("cName"), r_tab("newSCode"), r_tab("DSCode").ToString(), "后衫长实际尺寸")
                            Exit Function
                        End If
                        '比较后衫长差异
                        If Not (r_source(r_tab("cCode") + "iDefine2") = r_source(r_tab("DCol") + "iDefine2")) Then
                            CheckCombineIsSuccess = ErrMsg(r_source("cName"), r_tab("newSCode"), r_tab("DSCode").ToString(), "后衫长差异尺寸")
                            Exit Function
                        End If
                        '比较肩宽实际
                        If Not (r_source(r_tab("cCode") + "Define_3") = r_source(r_tab("DCol") + "Define_3")) Then
                            CheckCombineIsSuccess = ErrMsg(r_source("cName"), r_tab("newSCode"), r_tab("DSCode").ToString(), "肩宽实际尺寸")
                            Exit Function
                        End If
                        '比较肩宽差异
                        If Not (r_source(r_tab("cCode") + "iDefine3") = r_source(r_tab("DCol") + "iDefine3")) Then
                            CheckCombineIsSuccess = ErrMsg(r_source("cName"), r_tab("newSCode"), r_tab("DSCode").ToString(), "肩宽差异尺寸")
                            Exit Function
                        End If
                        '比较上围实际
                        If Not (r_source(r_tab("cCode") + "Define_6") = r_source(r_tab("DCol") + "Define_6")) Then
                            CheckCombineIsSuccess = ErrMsg(r_source("cName"), r_tab("newSCode"), r_tab("DSCode").ToString(), "上围实际尺寸")
                            Exit Function
                        End If
                        '比较上围差异
                        If Not (r_source(r_tab("cCode") + "iDefine6") = r_source(r_tab("DCol") + "iDefine6")) Then
                            CheckCombineIsSuccess = ErrMsg(r_source("cName"), r_tab("newSCode"), r_tab("DSCode").ToString(), "上围差异尺寸")
                            Exit Function
                        End If
                        '比较中围实际
                        If Not (r_source(r_tab("cCode") + "Define_7") = r_source(r_tab("DCol") + "Define_7")) Then
                            CheckCombineIsSuccess = ErrMsg(r_source("cName"), r_tab("newSCode"), r_tab("DSCode").ToString(), "中围实际尺寸")
                            Exit Function
                        End If
                        '比较中围差异
                        If Not (r_source(r_tab("cCode") + "iDefine7") = r_source(r_tab("DCol") + "iDefine7")) Then
                            CheckCombineIsSuccess = ErrMsg(r_source("cName"), r_tab("newSCode"), r_tab("DSCode").ToString(), "中围差异尺寸")
                            Exit Function
                        End If
                        '比较下围实际
                        If Not (r_source(r_tab("cCode") + "Define_8") = r_source(r_tab("DCol") + "Define_8")) Then
                            CheckCombineIsSuccess = ErrMsg(r_source("cName"), r_tab("newSCode"), r_tab("DSCode").ToString(), "下围实际尺寸")
                            Exit Function
                        End If
                        '比较下围差异
                        If Not (r_source(r_tab("cCode") + "iDefine8") = r_source(r_tab("DCol") + "iDefine8")) Then
                            CheckCombineIsSuccess = ErrMsg(r_source("cName"), r_tab("newSCode"), r_tab("DSCode").ToString(), "下围差异尺寸")
                            Exit Function
                        End If
                    End If
                End If
            Next
        Next
    End Function

    '删除合并处理后数据源的列
    Public Sub DelAfterCombCols(ByVal SourceTab As DataTable, ByRef TargetTab As DataTable)
        Dim CurIndex As Integer
        CurIndex = 0
        For i As Integer = 0 To SourceTab.Rows.Count - 1
            If SourceTab.Rows(i)("IsDisp") = False And i > 5 Then
                TargetTab.Columns.RemoveAt(i - CurIndex)
                TargetTab.AcceptChanges()
                CurIndex = CurIndex + 1
            Else
                Continue For
            End If
        Next
    End Sub

    '获取列显示设置列表中指定列的设置值
    Public Function GetDispSelValue(ByVal ValueName As String, ByVal OrigSetTable As DataTable) As Boolean

        If Not OrigSetTable Is Nothing Then

            For i As Integer = 0 To OrigSetTable.Rows.Count - 1

                If OrigSetTable.Rows(i)("SortValue") = ValueName Then
                    GetDispSelValue = OrigSetTable.Rows(i)("IsDisp")
                Else
                    Continue For
                End If
            Next

        End If

    End Function

    '将可合并打印的版型中，可以合并删除的版型中指定属性列的设置值协同到另一对应版型中
    'Public Sub SyncCombineDispValue(ByVal m_DataTab As DataTable, ByVal SourceTab As DataTable, ByVal TargetTable As DataTable)

    '    If True Then

    '    End If

    'End Sub
End Module