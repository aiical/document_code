Imports C1.Win.C1FlexGrid

Public Class SetGridSortType

    Public m_SortString As String  '排序串
    Public m_MSortString As String  '男排序串
    Public m_WSortString As String  '女排序串
    Private m_C1Flex As C1FlexGrid
    Public GolSortTab As DataTable
    Public GolTable As DataTable '全局数据源临时表
    Public bLoad As Boolean = False

    Public Sub New(ByVal mC1FlexGrid1 As C1FlexGrid, ByVal mSortStyle As String)

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        Dim mdtab = New DataTable()
        mdtab = mC1FlexGrid1.DataSource


        Dim mSetSortTab = New DataTable() '女装排序表
        Dim mColField = New DataColumn()
        mColField.ColumnName = "SortField"
        mColField.DataType = GetType(System.String)

        Dim mColValue = New DataColumn()
        mColValue.ColumnName = "SortValue"
        mColValue.DataType = GetType(System.String)
        mSetSortTab.Columns.Add(mColField)
        mSetSortTab.Columns.Add(mColValue)


        Dim mROW1 As DataRow
        mROW1 = mSetSortTab.NewRow
        mROW1("SortField") = ""
        mROW1("SortValue") = ""

        mSetSortTab.Rows.Add(mROW1)

        Dim mMSetSortTab = New DataTable() '男装排序数据表
        mMSetSortTab = mSetSortTab.Copy()

        For cIn As Integer = 1 To mC1FlexGrid1.Cols.Count - 1
            Dim mROW As DataRow
            Dim mMROW As DataRow
            mROW = mSetSortTab.NewRow
            mMROW = mMSetSortTab.NewRow
            mROW("SortField") = mdtab.Columns(cIn - 1).ColumnName
            mMROW("SortField") = mdtab.Columns(cIn - 1).ColumnName
            If (mC1FlexGrid1.Cols(cIn).Item(0).ToString().Equals(mC1FlexGrid1.Cols(cIn).Item(1).ToString()) And mC1FlexGrid1.Cols(cIn).Item(1).ToString().Equals(mC1FlexGrid1.Cols(cIn).Item(2).ToString())) Then
                mROW("SortValue") = mC1FlexGrid1.Cols(cIn).Item(0).ToString()
                mMROW("SortValue") = mC1FlexGrid1.Cols(cIn).Item(0).ToString()
                mSetSortTab.Rows.Add(mROW)
                mMSetSortTab.Rows.Add(mMROW)
            Else
                If (mC1FlexGrid1.Cols(cIn).Item(1).ToString().Equals(mC1FlexGrid1.Cols(cIn).Item(2).ToString())) Then
                    mROW("SortValue") = mC1FlexGrid1.Cols(cIn).Item(0).ToString() + "|" + mC1FlexGrid1.Cols(cIn).Item(1).ToString()
                Else
                    mROW("SortValue") = mC1FlexGrid1.Cols(cIn).Item(0).ToString() + "|" + mC1FlexGrid1.Cols(cIn).Item(1).ToString() + "|" + mC1FlexGrid1.Cols(cIn).Item(2).ToString()
                End If

                If (mC1FlexGrid1.Cols(cIn).Item(0).ToString().Contains("男")) Then
                    mMROW("SortValue") = mROW("SortValue")
                    mMSetSortTab.Rows.Add(mMROW)
                Else
                    mSetSortTab.Rows.Add(mROW)
                End If

            End If

            mSetSortTab.AcceptChanges()
            mMSetSortTab.AcceptChanges()
        Next

        ClearBinddata()

        Select Case (mSortStyle)
            Case "ALL"
                BindComboBox(mSetSortTab)
                MBindComboBox(mMSetSortTab)
            Case "Women"
                BindComboBox(mSetSortTab)
            Case "Men"
                MBindComboBox(mMSetSortTab)
        End Select


        Panel1.Left = Me.Left + 5
        Me.Width = Panel1.Width + 10

        Panel1.Top = Me.Top + 2
        Me.Height = Panel1.Height + 20

        Panel2.Visible = False
        Panel1.Visible = True
    End Sub

    Public Sub New(ByVal mC1FlexGrid1 As C1FlexGrid)

        m_C1Flex = mC1FlexGrid1

        ' 此调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。

        'Dim mdtab = New DataTable()
        'mdtab = mC1FlexGrid1.DataSource


        Dim mSetSortTab = New DataTable() '是否显示
        Dim mColField = New DataColumn()
        mColField.ColumnName = "IsDisp"
        mColField.DataType = GetType(System.Boolean)

        Dim mColValue = New DataColumn()
        mColValue.ColumnName = "SortValue"
        mColValue.DataType = GetType(System.String)
        mSetSortTab.Columns.Add(mColField)
        mSetSortTab.Columns.Add(mColValue)

        '首次加载时从界面获取数据源
        If bLoad = False Then
            For cIn As Integer = 1 To mC1FlexGrid1.Cols.Count - 1
                Dim mROW As DataRow
                mROW = mSetSortTab.NewRow
                mROW("IsDisp") = mC1FlexGrid1.Cols(cIn).Visible
                If (mC1FlexGrid1.Cols(cIn).Item(0).ToString().Equals(mC1FlexGrid1.Cols(cIn).Item(1).ToString()) And mC1FlexGrid1.Cols(cIn).Item(1).ToString().Equals(mC1FlexGrid1.Cols(cIn).Item(2).ToString())) Then
                    mROW("SortValue") = mC1FlexGrid1.Cols(cIn).Item(0).ToString()
                Else
                    If (mC1FlexGrid1.Cols(cIn).Item(1).ToString().Equals(mC1FlexGrid1.Cols(cIn).Item(2).ToString())) Then
                        mROW("SortValue") = mC1FlexGrid1.Cols(cIn).Item(0).ToString() + "|" + mC1FlexGrid1.Cols(cIn).Item(1).ToString()
                    Else
                        mROW("SortValue") = mC1FlexGrid1.Cols(cIn).Item(0).ToString() + "|" + mC1FlexGrid1.Cols(cIn).Item(1).ToString() + "|" + mC1FlexGrid1.Cols(cIn).Item(2).ToString()
                    End If
                End If
                mSetSortTab.Rows.Add(mROW)
                mSetSortTab.AcceptChanges()
            Next
            GolTable = mSetSortTab.Copy()
            bLoad = True
        End If


        Panel2.Left = Me.Left + 5
        Me.Width = Panel2.Width + 10

        Panel2.Top = Me.Top + 2
        Me.Height = Panel2.Height + 20

        Panel2.Visible = True
        Panel1.Visible = False

        Panel2.Height = Me.CheckedListBox1.Height

        Me.Text = "列显示设置"

        BindChecklist(GolTable)

        CheckedListBox1.CheckOnClick = True

    End Sub


    Private Sub ClearBinddata()

        For I As Integer = 1 To 5
            CType(Me.Controls.Find("SortCB" & I.ToString(), True)(0), System.Windows.Forms.ComboBox).Items.Clear()
            CType(Me.Controls.Find("MenSortCB" & I.ToString(), True)(0), System.Windows.Forms.ComboBox).Items.Clear()
        Next

    End Sub

    '确定返回
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        m_SortString = String.Empty
        For I As Integer = 1 To 5

            If (CType(Me.Controls.Find("SortCB" & I.ToString(), True)(0), System.Windows.Forms.ComboBox).Items.Count > 0) Then
                If (Not String.IsNullOrEmpty(CType(Me.Controls.Find("SortCB" & I.ToString(), True)(0), System.Windows.Forms.ComboBox).SelectedValue.ToString())) Then
                    m_WSortString += IIf(String.IsNullOrEmpty(m_WSortString), "", ",") + CType(Me.Controls.Find("SortCB" & I.ToString(), True)(0), System.Windows.Forms.ComboBox).SelectedValue.ToString() + " " + (IIf(CType(Me.Controls.Find("SortCk" & I.ToString(), True)(0), System.Windows.Forms.CheckBox).Checked, " desc", "asc"))
                End If
            End If

            If (CType(Me.Controls.Find("MenSortCB" & I.ToString(), True)(0), System.Windows.Forms.ComboBox).Items.Count > 0) Then
                If (Not String.IsNullOrEmpty(CType(Me.Controls.Find("MenSortCB" & I.ToString(), True)(0), System.Windows.Forms.ComboBox).SelectedValue.ToString())) Then
                    m_MSortString += IIf(String.IsNullOrEmpty(m_MSortString), "", ",") + CType(Me.Controls.Find("MenSortCB" & I.ToString(), True)(0), System.Windows.Forms.ComboBox).SelectedValue.ToString() + " " + (IIf(CType(Me.Controls.Find("MenSortCk" & I.ToString(), True)(0), System.Windows.Forms.CheckBox).Checked, " desc", "asc"))
                End If
            End If

        Next

        m_SortString = IIf(String.IsNullOrEmpty(m_MSortString), "", m_MSortString + IIf(String.IsNullOrEmpty(m_WSortString), "", ",")) + m_WSortString
        Me.DialogResult = Windows.Forms.DialogResult.OK

        Me.Close()

    End Sub

    '绑定下拉框数据
    Private Sub BindComboBox(ByVal mBindTab As DataTable)

        For I As Integer = 1 To 5
            Dim mSortT1 = New DataTable()
            mSortT1 = mBindTab.Copy()
            CType(Me.Controls.Find("SortCB" & I.ToString(), True)(0), System.Windows.Forms.ComboBox).DataSource = mSortT1
            CType(Me.Controls.Find("SortCB" & I.ToString(), True)(0), System.Windows.Forms.ComboBox).DisplayMember = "SortValue"
            CType(Me.Controls.Find("SortCB" & I.ToString(), True)(0), System.Windows.Forms.ComboBox).ValueMember = "SortField"
        Next

    End Sub

    '男装绑定下拉框数据
    Private Sub MBindComboBox(ByVal mBindTab As DataTable)

        For I As Integer = 1 To 5
            Dim mSortT2 = New DataTable()
            mSortT2 = mBindTab.Copy()
            CType(Me.Controls.Find("MenSortCB" & I.ToString(), True)(0), System.Windows.Forms.ComboBox).DataSource = mSortT2
            CType(Me.Controls.Find("MenSortCB" & I.ToString(), True)(0), System.Windows.Forms.ComboBox).DisplayMember = "SortValue"
            CType(Me.Controls.Find("MenSortCB" & I.ToString(), True)(0), System.Windows.Forms.ComboBox).ValueMember = "SortField"
        Next

    End Sub


    Private Sub BindChecklist(ByVal mtab As DataTable)
        Dim mIndex As Integer = 0
        For Each mRow As DataRow In mtab.Rows
            Me.CheckedListBox1.Items.Add(mRow("SortValue").ToString())
            Me.CheckedListBox1.SetItemChecked(mIndex, IIf(mRow("IsDisp").ToString().Equals("True"), True, False))
            mIndex += 1
        Next
    End Sub

    '取消返回
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If (Button3.Text = "高级") Then
            Panel2.Height = Me.Height - 10
            CheckedListBox1.CheckOnClick = False
            Button3.Text = "简单"
        Else
            Button3.Text = "高级"
            Panel2.Height = Me.Height - 90
            CheckedListBox1.CheckOnClick = True
        End If
    End Sub


    Private Sub CheckedListBox1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedValueChanged

        Dim mdbtab As New DataTable()
        Dim App As New C1FlexToExcel

        Me.TxtColName.Text = CheckedListBox1.SelectedItem
        Me.TxtColWidth.Text = m_C1Flex.Cols(CheckedListBox1.SelectedIndex + 1).Width.ToString()

        m_C1Flex.Cols(CheckedListBox1.SelectedIndex + 1).Visible = CheckedListBox1.GetItemChecked(CheckedListBox1.SelectedIndex)
        App.UpdateGolDispTable(CheckedListBox1.SelectedIndex, GolTable, CheckedListBox1.GetItemChecked(CheckedListBox1.SelectedIndex))

        'mdbtab = Me.m_C1Flex.DataSource

        'CType(mdbtab)

        'GolSortTab = App.GetSortTab(CheckedListBox1.SelectedIndex + 1, mdbtab, CheckedListBox1.GetItemChecked(CheckedListBox1.SelectedIndex))

    End Sub

End Class

