Imports C1.Win.C1FlexGrid
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class FrmSelonGrid

    Public mBatcth As New ArrayList()
    Private m_MainTab As New DataTable() '尺寸表主数据表
    Private m_SetGritdTab As New DataTable() '制服版型设置表
    'Private m_SetGridT As New DataTable() '制服版型设置表
    Public m_SetGridDataTab As New DataTable()
    Private m_saCode As String
    Private m_MoCode As String
    Private m_MidSetGridTab As New DataTable() '中间制服型版设置表
    Private m_MidMainTab As New DataTable() '中间制服型版设置表
    Private m_PopuMenu As New System.Windows.Forms.ContextMenu()
    Private m_SortVis As String
    Private currDB As String
    Private GolSortTabForSelGrid As DataTable


    '构造函数
    Public Sub New(ByVal mMainTab As DataTable, ByVal mSetGridTab As DataTable, ByVal msaCode As String, ByVal mcurrDB As String)
        currDB = mcurrDB

        m_MainTab = mMainTab

        m_SetGritdTab = mSetGridTab

        m_MidMainTab = mMainTab.Copy()


        m_MidSetGridTab = m_SetGritdTab.Copy()

        m_saCode = msaCode

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        RdBtAll.Checked = True


        ' 在 InitializeComponent() 调用之后添加任何初始化。
        SetGridDataSourceTab()


        CKTypeList.Items.Clear()

        Dim mHeight As Integer

        For Each mRow As DataRow In m_SetGritdTab.Rows

            CKTypeList.Items.Add(mRow("BxMc").ToString())
            mHeight += 20
        Next
        CKTypeList.Height = mHeight

        AddHandler Me.RdBtAll.Click, AddressOf RdBtWomen_CheckedChanged

        RbDispAll.Checked = True

        m_SortVis = "ALL"

        AddHandler Me.RbDispAll.CheckedChanged, AddressOf RbDispAll_CheckedChanged

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        'Me.WindowState = Windows.Forms.FormWindowState.Maximized

    End Sub

    '构造函数
    Public Sub New()

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
    End Sub

    '退出
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' ckeckBatch()
        Me.Close()

    End Sub

    '加载方法
    Private Sub FrmSelonGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mCreatMenu()
        Me.BackColor = Drawing.Color.FromArgb(194, 216, 240)
        Me.btnPreview.BackColor = Drawing.Color.FromArgb(197, 216, 240)
    End Sub

    '检查批号
    Private Sub ckeckBatch()
        If (C1FlexGrid1.DataSource Is Nothing) Then
            Exit Sub
        Else
            Dim mTabcou As New DataTable()
            mTabcou = C1FlexGrid1.DataSource
            If (mTabcou.Columns.Contains("imiquatity>0")) Then
                If (mTabcou.Select("imiquatity>0").Length <= 0) Then
                    'mBatcth()
                    ' mBatcth = mBatcth.Replace(mTabcou.Select("imiquatity=0")(0)("nCbatch").ToString(), "")
                End If
            End If
        End If
      
    End Sub

    '可入库数量
    Private Sub C1FlexGrid1_ValidateEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.ValidateEditEventArgs) Handles C1FlexGrid1.ValidateEdit

        Dim mC1Flex As C1FlexGrid
        Dim mTabcou As New DataTable()
        mC1Flex = sender

        If (mC1Flex.Cols(e.Col).Name.ToLower() = "imiquatity") Then

            Dim EmailRegex As New System.Text.RegularExpressions.Regex("[0-9]{1,3}")

            If (EmailRegex.Match(mC1Flex.Editor.Text).Success = True) Then

                If (CInt(mC1Flex.Editor.Text) > CInt(mC1Flex(e.Row, "canInIQuantity").ToString())) Then
                    System.Windows.Forms.MessageBox.Show("本次入库数量不能大于可入库数量！请重新录入正确的数量", "录入提示", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
                    mC1Flex.Editor.Text = 0
                End If

                mTabcou = mC1Flex.DataSource
                mTabcou.Rows(e.Row - 1)("imiquatity") = mC1Flex.Editor.Text
                If (mBatcth.Contains(mTabcou.Rows(e.Row - 1)("nCbatch")) = False) Then
                    mBatcth.Add(mTabcou.Rows(e.Row - 1)("nCbatch"))
                End If
            Else
                System.Windows.Forms.MessageBox.Show("请录入正确的数字", "录入提示", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
            End If


        ElseIf (mC1Flex.Cols(e.Col).Name.ToLower() = "outiquatity") Then

            If (CInt(mC1Flex.Editor.Text) > CInt(mC1Flex(e.Row, "canFHiQuantity").ToString())) Then
                System.Windows.Forms.MessageBox.Show("本次发货数量不能大于可发货数量！请重新录入正确的数量", "录入提示", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Stop)
                mC1Flex.Editor.Text = ""
            End If

        End If
    End Sub


    '设置列表数据源绑定
    Private Sub SetGridDataSourceTab()

        'Dim rowindex As Integer '行索引 add by pj 20121223
        'rowindex = 0

        m_SetGridDataTab.Columns.Clear()

        If (Not m_MainTab Is Nothing) Then

            For mCi As Integer = 0 To 3 Step 1
                Dim mNewCol As New DataColumn()
                mNewCol.ColumnName = m_MainTab.Columns(mCi).ColumnName
                mNewCol.DataType = m_MainTab.Columns(mCi).DataType

                Select Case mCi
                    Case 0
                        mNewCol.Caption = "工号"
                    Case 1
                        mNewCol.Caption = "部门"
                    Case 2
                        mNewCol.Caption = "姓名"
                    Case 3
                        mNewCol.Caption = "性别"
                End Select

                m_SetGridDataTab.Columns.Add(mNewCol)
            Next


            If (Not m_SetGritdTab Is Nothing) Then


                For Each mRow As DataRow In m_SetGritdTab.Rows

                    'rowindex = rowindex + 1 'add by pj 20121223
                    Dim mNewCol As New DataColumn()
                    mNewCol.ColumnName = mRow("cCode").ToString() + "iQuantity" '+ "_" + rowindex.ToString()
                    mNewCol.DataType = System.Type.GetType("System.Int32")
                    mNewCol.Caption = mRow("BxMc").ToString()
                    m_SetGridDataTab.Columns.Add(mNewCol)
                    m_SetGridDataTab.AcceptChanges()

                    mNewCol = New DataColumn()
                    mNewCol.ColumnName = mRow("cCode").ToString() + "cDfName" '+ "_" + rowindex.ToString()
                    mNewCol.DataType = System.Type.GetType("System.String")
                    mNewCol.Caption = mRow("BxMc").ToString()
                    m_SetGridDataTab.Columns.Add(mNewCol)
                    m_SetGridDataTab.AcceptChanges()

                    mNewCol = New DataColumn()
                    mNewCol.ColumnName = mRow("cCode").ToString() + "cAlias" '+ "_" + rowindex.ToString()
                    mNewCol.DataType = System.Type.GetType("System.String")
                    mNewCol.Caption = mRow("BxMc").ToString()
                    m_SetGridDataTab.Columns.Add(mNewCol)
                    m_SetGridDataTab.AcceptChanges()

                    mNewCol = New DataColumn()
                    mNewCol.ColumnName = mRow("cCode").ToString() + "cInvCode" '+ "_" + rowindex.ToString()
                    mNewCol.DataType = System.Type.GetType("System.String")
                    mNewCol.Caption = mRow("BxMc").ToString()
                    m_SetGridDataTab.Columns.Add(mNewCol)
                    m_SetGridDataTab.AcceptChanges()


                    'mNewCol = New DataColumn()
                    'mNewCol.ColumnName = mRow("cCode").ToString() + "cRemark"
                    'mNewCol.DataType = System.Type.GetType("System.String")
                    'mNewCol.Caption = mRow("BxMc").ToString()
                    'm_SetGridDataTab.Columns.Add(mNewCol)
                    'm_SetGridDataTab.AcceptChanges()

                    For i As Integer = 1 To 15 Step 1
                        If (mRow("define" + i.ToString()).ToString() = "True") Then
                            mNewCol = New DataColumn()
                            mNewCol.ColumnName = mRow("cCode").ToString() + m_MainTab.Columns("Define_" + i.ToString()).ColumnName '+ "_" + rowindex.ToString()
                            mNewCol.DataType = m_MainTab.Columns("Define_" + i.ToString()).DataType ' System.Type.GetType("System.String") 
                            mNewCol.Caption = mRow("BxMc").ToString()
                            m_SetGridDataTab.Columns.Add(mNewCol)
                            m_SetGridDataTab.AcceptChanges()

                            If (mRow("bdefine" + i.ToString()).ToString() = "True") Then
                                mNewCol = New DataColumn()
                                mNewCol.ColumnName = mRow("cCode").ToString() + m_MainTab.Columns("idefine" + i.ToString()).ColumnName ' + "_" + rowindex.ToString()
                                mNewCol.DataType = System.Type.GetType("System.String") 'm_MainTab.Columns("idefine" + i.ToString()).DataType
                                mNewCol.Caption = mRow("BxMc").ToString()
                                m_SetGridDataTab.Columns.Add(mNewCol)
                                m_SetGridDataTab.AcceptChanges()

                            End If

                        End If
                    Next
                    mNewCol = New DataColumn()
                    mNewCol.ColumnName = mRow("cCode").ToString() + "cRemark" '+ "_" + rowindex.ToString()
                    mNewCol.DataType = System.Type.GetType("System.String")
                    mNewCol.Caption = mRow("BxMc").ToString()
                    m_SetGridDataTab.Columns.Add(mNewCol)




                    m_SetGridDataTab.AcceptChanges()
                Next

            End If
            Dim mNewColcode As New DataColumn()
            mNewColcode.ColumnName = m_MainTab.Columns("ccode").ColumnName
            mNewColcode.DataType = m_MainTab.Columns("ccode").DataType

            m_SetGridDataTab.Columns.Add(mNewColcode)
            m_SetGridDataTab.AcceptChanges()

            ImDatatoGridTab()
        End If
    End Sub

    '绑定数据源
    Private Sub ImDatatoGridTab()
        m_SetGridDataTab.Rows.Clear()
        If (m_SetGridDataTab.Columns.Count > 0 And m_MainTab.Rows.Count > 0) Then
            Me.txtcCusName.Text = m_MainTab.Rows(0)("cCusName").ToString()
            For Each mrow As DataRow In m_MainTab.Rows

                'Dim rowindex As Integer '行索引 add by pj 20121223


                Dim mDRow As DataRow
                mDRow = m_SetGridDataTab.NewRow()
                mDRow("cPID") = mrow("cPID")
                mDRow("cDepName") = mrow("cDepName")
                mDRow("cName") = mrow("cName")
                mDRow("isex") = mrow("isex")
                mDRow("ccode") = mrow("ccode")

                '将值为0的单元格清空 add by pj 20121225
                'SetZeroToEmpety(m_MainTab)
                For Each mColN As DataColumn In m_MainTab.Columns
                    'rowindex = 0
                    For Each r As DataRow In m_SetGritdTab.Rows
                        'rowindex = rowindex + 1 'add by pj 20121223
                        If (m_SetGridDataTab.Columns.Contains(mrow("cCode").ToString().Trim() + mColN.ColumnName().Trim())) Then
                            mDRow(mrow("cCode").ToString().Trim() + mColN.ColumnName().Trim()) = mrow(mColN.ColumnName().Trim())
                            Try
                                If (mColN.ToString().ToLower().Trim().Contains("idefine")) Then
                                    If (String.IsNullOrEmpty(mrow(mColN.ColumnName().Trim()).ToString())) Then
                                        mDRow(mrow("cCode").ToString().Trim() + mColN.ColumnName().Trim()) = mrow(mColN.ColumnName().Trim())
                                        'mDRow(mrow("cCode").ToString().Trim() + mColN.ColumnName().Trim() + "_" + rowindex.ToString()) = ""
                                    Else
                                        If (CInt(mrow(mColN.ColumnName().Trim().ToString())) > 0) Then
                                            mDRow(mrow("cCode").ToString().Trim() + mColN.ColumnName().Trim()) = "+" + Convert.ToDouble(mrow(mColN.ColumnName().Trim())).ToString("N1")
                                        Else
                                            mDRow(mrow("cCode").ToString().Trim() + mColN.ColumnName().Trim()) = Convert.ToDouble(mrow(mColN.ColumnName().Trim())).ToString("N1")
                                        End If
                                    End If
                                End If
                            Catch ex As Exception

                            End Try

                        End If
                        'mDRow("cAlias") = mrow("cAlias")
                    Next
                Next
                If (m_SetGridDataTab.Select("cPID='" + mrow("cPID").ToString() + "' ").Length > 0) Then 'and ccode='" + mrow("ccode").ToString() + "'
                    Dim mURow As DataRow
                    mURow = m_SetGridDataTab.Select("cPID='" + mrow("cPID").ToString() + "' ")(0) 'and ccode='" + mrow("ccode").ToString() + "'
                    Dim mcl As Integer
                    mcl = 0
                    For Each mColN1 As DataColumn In m_SetGridDataTab.Columns
                        If Not IsDBNull(mDRow.ItemArray(mcl)) Then
                            mURow(mcl) = mDRow(mColN1)
                        End If
                        mcl += 1
                        m_SetGridDataTab.AcceptChanges()
                    Next

                Else
                    m_SetGridDataTab.Rows.Add(mDRow.ItemArray)
                End If

                m_SetGridDataTab.AcceptChanges()
            Next

        End If
        m_SetGridDataTab.Columns.Remove("ccode")
    End Sub

    '选版型
    Private Sub BTTypeChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTTypeChange.Click

        If (BTTypeChange.Text = "版型选择") Then

            BTTypeChange.Text = "生成报表"
            CKTypeList.Left = BTTypeChange.Left + 10
            CKTypeList.Top = BTTypeChange.Top + BTTypeChange.Height + 5
            CKTypeList.Visible = True
        Else

            Dim mFilterstr As String = String.Empty

            For mIndex As Integer = 0 To CKTypeList.Items.Count - 1
                If (CKTypeList.GetItemChecked(mIndex) = True) Then
                    mFilterstr += IIf(String.IsNullOrEmpty(mFilterstr), "", "','") + CKTypeList.Items(mIndex).ToString()
                    If (Not m_SetGritdTab.Select("BxMc='" + CKTypeList.Items(mIndex).ToString() + "'").Length > 0) Then
                        If (m_MidSetGridTab.Select("BxMc='" + CKTypeList.Items(mIndex).ToString() + "'").Length > 0) Then
                            Dim mRow As DataRow = m_SetGritdTab.NewRow()
                            'mRow = m_MidSetGridTab.Select("BxMc='" + CKTypeList.Items(mIndex).ToString() + "'")(0)
                            For Each mCN As DataColumn In m_SetGritdTab.Columns
                                'add by pj 20130330
                                If mCN.ColumnName <> "newSCode" And mCN.ColumnName <> "DCol" And mCN.ColumnName <> "DSCode" And mCN.ColumnName <> "CombineRel" Then
                                    mRow(mCN.ColumnName) = m_MidSetGridTab.Select("BxMc='" + CKTypeList.Items(mIndex).ToString() + "'")(0)(mCN.ColumnName)
                                End If
                            Next

                            m_SetGritdTab.Rows.Add(mRow)

                        End If
                    End If

                Else
                    If (m_SetGritdTab.Select("BxMc='" + CKTypeList.Items(mIndex).ToString() + "'").Length > 0) Then
                        m_SetGritdTab.Rows.Remove(m_SetGritdTab.Select("BxMc='" + CKTypeList.Items(mIndex).ToString() + "'")(0))
                    End If
                End If
            Next

            m_SetGritdTab.AcceptChanges()

            If (Not String.IsNullOrEmpty(mFilterstr)) Then

                Dim mselect As String = " and dName+'('+iName+')' in ('" + mFilterstr + "')  order by iRowNo "

                ReSetGrid(mselect)


                'm_MainTab.Columns.Clear()
                'm_MainTab = GetSizemainTab(m_saCode, mCnn, CommandType.Text, mselect)



                'SetGridDataSourceTab()

                'SetDataGrid(m_SetGridDataTab, C1FlexGrid1, m_SetGritdTab)



                RdBtAll.Checked = True

                'RdBtWomen_CheckedChanged(RdBtAll, EventArgs.Empty)
            End If

            If (m_SetGritdTab.Rows.Count <= 0) Then
                m_SetGritdTab = m_MidSetGridTab.Copy()
            End If

            BTTypeChange.Text = "版型选择"

            CKTypeList.Visible = False

            End If

    End Sub

    '选男女装
    Private Sub RdBtWomen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdBtMen.Click, RdBtWomen.Click
        'Dim mselect As String = "select cPID,cDepName,cName,isex,* from selonuinform.dbo.v_Tailordetail  where sacode='" + m_saCode + "' and iSex='女'  order by iRowNo "
        Dim mselect As String = "select cPID,cDepName,cName,isex,a.*,b.cAlias from selonuinform.dbo.v_Tailordetail a left join " + currDB + ".dbo.userdefine b on a.cdfname = b.cValue where sacode='" + m_saCode + "'"

        Dim mRad = New System.Windows.Forms.RadioButton
        mRad = sender

        Select Case mRad.Name
            Case "RdBtAll"   '全部
                mselect = " order by iRowNo "
                m_SortVis = "ALL"
            Case "RdBtWomen"
                mselect = " and iSex='女' order by iRowNo "
                m_SortVis = "Women"
            Case "RdBtMen"
                mselect = " and iSex='男' order by iRowNo "
                m_SortVis = "Men"

        End Select

        ReSetGrid(mselect)

    
    End Sub


    Private Sub ReSetGrid(ByVal mSelectstr As String)


        Dim mselect As String

        'mselect = "select cPID,cDepName,cName,isex,* from selonuinform.dbo.v_Tailordetail  where sacode='" + m_saCode + "'"
        mselect = "select cPID,cDepName,cName,isex,a.*,b.cAlias from selonuinform.dbo.v_Tailordetail a left join " + currDB + ".dbo.userdefine b on a.cdfname = b.cValue where sacode='" + m_saCode + "'"
        mselect = mselect + mSelectstr

        m_MainTab.Columns.Clear()
        m_MainTab = GetSizemainTab(m_saCode, mCnn, CommandType.Text, mselect)

        For Each rr As DataRow In m_SetGritdTab.Rows
            For Each r As DataRow In m_MainTab.Select("sid='" + rr("sid").ToString() + "'")
                r("ccode") = rr("ccode")
                m_MainTab.AcceptChanges()
            Next
        Next

        SetGridDataSourceTab()

        SetDataGrid(m_SetGridDataTab, C1FlexGrid1, m_SetGritdTab)

    End Sub


    '导出EXCEL及打印
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtPrint.Click

        Try

            Dim mWaitform = New FormWait()
            mWaitform.Label1.Text = "正在打印请稍后…………"
            mWaitform.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
            mWaitform.Show()
            mWaitform.Refresh()


            'Dim mgete As New GetExcelApp

            Dim mC1Toexcel = New C1FlexToExcel(Me.C1FlexGrid1)

            'C1FlexGrid1.Refresh()
            '新增制服尺寸表与是否合并打印复选参数 add by pj 20121230
            mC1Toexcel.flexgridtoexcel(C1FlexGrid1, GetExcel(), Me.BtPrint.Tag.ToString(), m_saCode, GolSortTabForSelGrid, m_SetGritdTab, ChkCombinePrint.Checked, False, False)

            mWaitform.Dispose()

        Catch ex As Exception


        End Try

        

    End Sub


    '实现右键菜单方法
    Private Sub C1FlexGrid1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles C1FlexGrid1.MouseDown


        C1FlexGrid1.Select(C1FlexGrid1.MouseRow, C1FlexGrid1.MouseCol, True)


        If (e.Button.ToString().ToLower().Equals("right")) Then
            If (C1FlexGrid1.Selection.r1 < 0 Or C1FlexGrid1.Selection.r2 < 0 Or C1FlexGrid1.Selection.c1 < 0 Or C1FlexGrid1.Selection.c2 < 0) Then

            Else
                Select Case (C1FlexGrid1.Selection.StyleDisplay.TextAlign.ToString().ToLower().Substring(0, 4))

                    Case "righ"
                        m_PopuMenu.MenuItems(2).MenuItems(0).Text = m_PopuMenu.MenuItems(2).MenuItems(0).Text.Replace("@", "")
                        m_PopuMenu.MenuItems(2).MenuItems(1).Text = m_PopuMenu.MenuItems(2).MenuItems(1).Text.Replace("@", "")
                        m_PopuMenu.MenuItems(2).MenuItems(2).Text = "@" + m_PopuMenu.MenuItems(2).MenuItems(2).Text.Replace("@", "")
                    Case "left"
                        m_PopuMenu.MenuItems(2).MenuItems(0).Text = m_PopuMenu.MenuItems(2).MenuItems(0).Text.Replace("@", "")
                        m_PopuMenu.MenuItems(2).MenuItems(1).Text = "@" + m_PopuMenu.MenuItems(2).MenuItems(1).Text.Replace("@", "")
                        m_PopuMenu.MenuItems(2).MenuItems(2).Text = m_PopuMenu.MenuItems(2).MenuItems(2).Text.Replace("@", "")
                    Case Else
                        m_PopuMenu.MenuItems(2).MenuItems(0).Text = "@" + m_PopuMenu.MenuItems(2).MenuItems(0).Text.Replace("@", "")
                        m_PopuMenu.MenuItems(2).MenuItems(1).Text = m_PopuMenu.MenuItems(2).MenuItems(1).Text.Replace("@", "")
                        m_PopuMenu.MenuItems(2).MenuItems(2).Text = m_PopuMenu.MenuItems(2).MenuItems(2).Text.Replace("@", "")
                End Select

            End If
            

            C1FlexGrid1.ContextMenu = m_PopuMenu


        End If

    End Sub

    '建立右键菜单项
    Private Sub mCreatMenu()

        Dim mMenuitem1 As New System.Windows.Forms.MenuItem("排序选择")

        'AddHandler mMenuitem1.Click, AddressOf mYPopup

        Dim mMenuitem2 As New System.Windows.Forms.MenuItem("对齐方式")

        Dim mMenuitem3 As New System.Windows.Forms.MenuItem("-")

        Dim mMenuitem4 As New System.Windows.Forms.MenuItem("居中对齐")

        Dim mMenuitem5 As New System.Windows.Forms.MenuItem("左对齐")

        Dim mMenuitem6 As New System.Windows.Forms.MenuItem("右对齐")

        Dim mMenuitem8 As New System.Windows.Forms.MenuItem("-")

        Dim mMenuitem7 As New System.Windows.Forms.MenuItem("列设置")


        mMenuitem2.MenuItems.Add(mMenuitem4)
        mMenuitem2.MenuItems.Add(mMenuitem5)
        mMenuitem2.MenuItems.Add(mMenuitem6)

        For Each mmeunid As System.Windows.Forms.MenuItem In mMenuitem2.MenuItems
            AddHandler mmeunid.Click, AddressOf mYPopup
        Next

        m_PopuMenu.MenuItems.Clear()

        m_PopuMenu.MenuItems.Add(mMenuitem1)
        m_PopuMenu.MenuItems.Add(mMenuitem3)
        m_PopuMenu.MenuItems.Add(mMenuitem2)
        m_PopuMenu.MenuItems.Add(mMenuitem8)
        m_PopuMenu.MenuItems.Add(mMenuitem7)


        For Each mmeunid As System.Windows.Forms.MenuItem In m_PopuMenu.MenuItems
            AddHandler mmeunid.Click, AddressOf mYPopup
        Next


    End Sub

    '右键菜单方法
    Private Sub mYPopup(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim aa As System.Windows.Forms.MenuItem
        aa = sender

        Select Case (aa.Text.Trim())

            Case "排序选择"
                Dim mSortTab = New DataTable()
                mSortTab = C1FlexGrid1.DataSource

                Dim mSortTab1 = New DataTable()

                mSortTab1 = mSortTab.Copy()

                'mSortTab1.DefaultView.Sort = "cDepName desc,BcDfName desc"

                'SetDataGrid(mSortTab1, C1FlexGrid1, m_SetGritdTab)


                Dim mFromSetfor = New SetGridSortType(Me.C1FlexGrid1, m_SortVis)

                mFromSetfor.ShowDialog()
                If (mFromSetfor.DialogResult = Windows.Forms.DialogResult.OK And Not String.IsNullOrEmpty(mFromSetfor.m_SortString)) Then
                    mSortTab1.DefaultView.Sort = mFromSetfor.m_SortString
                    SetDataGrid(mSortTab1, C1FlexGrid1, m_SetGritdTab)
                End If


            Case "右对齐"
                C1FlexGrid1.Cols(C1FlexGrid1.Selection.c1).Style.TextAlign = TextAlignEnum.RightCenter
            Case "左对齐"
                C1FlexGrid1.Cols(C1FlexGrid1.Selection.c1).Style.TextAlign = TextAlignEnum.LeftCenter
            Case "居中对齐"
                C1FlexGrid1.Cols(C1FlexGrid1.Selection.c1).Style.TextAlign = TextAlignEnum.CenterCenter
            Case "列设置"

                Dim mFromSetfor = New SetGridSortType(Me.C1FlexGrid1)

                'mFromSetfor.ShowDialog()

                mFromSetfor.ShowDialog()
                GolSortTabForSelGrid = mFromSetfor.GolTable
                'GolSortTabForSelGrid = mFromSetfor.GolSortTab
                '  C1FlexGrid1.Cols(C1FlexGrid1.Selection.c1).Style.TextAlign = TextAlignEnum.RightCenter

        End Select



    End Sub

    '设置查询条件
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim mVourForm = New VoucherQueryForm(m_MidMainTab, m_MidSetGridTab)

        mVourForm.ShowDialog()

        If (mVourForm.DialogResult = Windows.Forms.DialogResult.OK And Not mVourForm.m_ReturnStrquery Is Nothing) Then

            If (mVourForm.m_SetGridDatatab.Rows.Count > 0) Then
                m_SetGritdTab = mVourForm.m_SetGridDatatab
            Else
                m_SetGritdTab = m_MidSetGridTab
            End If

            ReSetGrid(" and " + mVourForm.m_ReturnStrquery)

        End If

    End Sub



    '显示实际尺寸
    Private Sub RbDispReal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbDispReal.CheckedChanged

        For i As Integer = 1 To C1FlexGrid1.Cols.Count - 1

            Select Case (C1FlexGrid1.Cols(i).Item(2).ToString())
                Case "实际"
                    C1FlexGrid1.Cols(i).Visible = True
                Case "差异"
                    C1FlexGrid1.Cols(i).Visible = False
            End Select
        Next

    End Sub


    '显示差异尺寸
    Private Sub RbDispDif_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbDispDif.CheckedChanged

        For i As Integer = 1 To C1FlexGrid1.Cols.Count - 1
           
            Select Case (C1FlexGrid1.Cols(i).Item(2).ToString())
                Case "实际"
                    C1FlexGrid1.Cols(i).Visible = False
                Case "差异"
                    C1FlexGrid1.Cols(i).Visible = True
            End Select
        Next

    End Sub


    '显示全部尺寸
    Private Sub RbDispAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        For i As Integer = 1 To C1FlexGrid1.Cols.Count - 1

            Select Case (C1FlexGrid1.Cols(i).Item(2).ToString())
                Case "实际"
                    C1FlexGrid1.Cols(i).Visible = True
                Case "差异"
                    C1FlexGrid1.Cols(i).Visible = True
            End Select
        Next

    End Sub

    Private Sub btnPrintCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            Dim mWaitform = New FormWait()
            mWaitform.Label1.Text = "正在打开预览窗口请稍后…………"
            mWaitform.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
            mWaitform.Show()
            mWaitform.Refresh()
            'Dim mgete As New GetExcelApp

            Dim mC1Toexcel = New C1FlexToExcel(Me.C1FlexGrid1)

            '新增制服尺寸表与是否合并打印复选参数 add by pj 20121230
            mC1Toexcel.flexgridtoexcel(C1FlexGrid1, GetExcel(), Me.BtPrint.Tag.ToString(), m_saCode, GolSortTabForSelGrid, m_SetGritdTab, ChkCombinePrint.Checked, True, False)

            mWaitform.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Dim mWaitform = New FormWait()
            mWaitform.Label1.Text = "请稍后正在整理数据…………"
            mWaitform.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
            mWaitform.Show()
            mWaitform.Refresh()
            'Dim mgete As New GetExcelApp

            Dim mC1Toexcel = New C1FlexToExcel(Me.C1FlexGrid1)

            '新增制服尺寸表与是否合并打印复选参数 add by pj 20121230
            mC1Toexcel.flexgridtoexcel(C1FlexGrid1, GetExcel(), Me.BtPrint.Tag.ToString(), m_saCode, GolSortTabForSelGrid, m_SetGritdTab, ChkCombinePrint.Checked, False, True)

            mWaitform.Dispose()

        Catch ex As Exception

        End Try
    End Sub
End Class